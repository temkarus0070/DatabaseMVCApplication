using ClosedXML.Excel;
using DataBaseMVCApplication.Domain;
using DataBaseMVCApplication.Services;
using DataBaseMVCApplication.ViewModels;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataBaseMVCApplication.Controllers
{
    public class ReportController : Controller
    {
        Services.Services services = new Services.Services();
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SellersReport()
        {
            var sellers = new HashSet<SellerViewModel>();
            var sellersData = services.sellerService.GetSellers();
            foreach (var e in sellersData)
            {
                var seller = new SellerViewModel() { FIO = e.FIO, Id = e.Id };
                if (!sellers.Contains(seller))
                    sellers.Add(seller);
                else
                {
                    seller.FIO += " " + e.Phone;
                    sellers.Add(seller);
                }
            }
            return View(sellers);
        }

        [HttpPost]
        public FileResult SellersReport(FormCollection form)

        {
            string selectedValues = form["Id"];
            var array = selectedValues.Split(',');

            HashSet<long> sellersSet = new HashSet<long>();
            foreach (var e in array)
            {
                int pos = e.IndexOf(" ");
                sellersSet.Add(long.Parse(e.Substring(0, pos)));
            }
            Dictionary<SellerDto, (int, double, double)> dictionary = new Dictionary<SellerDto, (int, double, double)>();
            var orders = services.orderService.GetOrders().ToList();
            foreach (var order in orders)
            {
                if (sellersSet.Contains(order.BuyerId))
                {
                    if (dictionary.ContainsKey(order.Seller))
                    {
                        var sellerData = dictionary[order.Seller];
                        var ordersPosition = services.orderPositionService.GetOrderPositions(order.Id);
                        sellerData.Item1 += ordersPosition.Count();
                        sellerData.Item2 += order.Price;
                        dictionary[order.Seller] = sellerData;
                    }
                    else
                    {
                        var ordersPosition = services.orderPositionService.GetOrderPositions(order.Id);
                        dictionary[order.Seller] = (ordersPosition.Count(), order.Price, 0);
                    }
                }
            }
            var list = dictionary.Keys.ToList();
            for (int i = 0; i < dictionary.Keys.Count; i++)
            {
                var data = dictionary[list[i]];
                data.Item3 = dictionary[list[i]].Item2 / dictionary[list[i]].Item1;
                dictionary[list[i]] = data;
            }

            MemoryStream memoryStream = new MemoryStream();
            using (XLWorkbook wb = new XLWorkbook())
            {
                DataSet set = new DataSet();
                DataTable dataTable = new DataTable();
                dataTable.Columns.AddRange(new[]{new DataColumn("Продавец"), new DataColumn("Кол-во проданных окон"),
                    new DataColumn("Средний чек"), new DataColumn("Общая сумма продаж")});
                foreach (var e in dictionary.Keys)
                {
                    var data = dictionary[e];
                    dataTable.Rows.Add(string.Format("{0} {1}", e.FIO, e.Phone), data.Item1, data.Item3, data.Item2);
                }
                set.Tables.Add(dataTable);
                wb.Worksheets.Add(set.Tables[0], "Продавцы");
                wb.SaveAs(memoryStream);
                return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Sellers.xlsx");
            }

        }

        public ActionResult OrdersReport()
        {
            return View();
        }

        [HttpPost]
        public FileResult OrdersReport(DateTime begin, DateTime end)
        {
            Dictionary<string, (int, double)> dictionary = new Dictionary<string, (int, double)>();
            var orders = services.orderService.GetOrders().Where(
                e => ((e.OrderDate >= begin) && (e.OrderDate <= end))
                );
            foreach (var e in orders)
            {
                var orderPositions = services.orderPositionService.GetOrderPositions(e.Id);
                foreach (var orderPos in orderPositions)
                {
                    if (dictionary.ContainsKey(orderPos.Window.Manufactor.Name))
                    {
                        var windowData = dictionary[orderPos.Window.Manufactor.Name];
                        windowData.Item1++;
                        windowData.Item2 += (orderPos.Window.Price * (orderPos.Width * orderPos.Length));
                        dictionary[orderPos.Window.Manufactor.Name] = windowData;
                    }
                    else
                        dictionary[orderPos.Window.Manufactor.Name] = (1, orderPos.Window.Price * (orderPos.Width * orderPos.Length));
                }
            }

            MemoryStream memoryStream = new MemoryStream();
            using (XLWorkbook wb = new XLWorkbook())
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("Производитель окон");
                dt.Columns.Add("Кол-во продаж");
                dt.Columns.Add("Сумма продаж");
                dt.Columns[0].MaxLength = 200;
                foreach (var e in dictionary.Keys)
                {
                    var entry = dictionary[e];
                    dt.Rows.Add(e, entry.Item1, entry.Item2);

                }
                ds.Tables.Add(dt);
                wb.Worksheets.Add(ds.Tables[0], "Заказы");
                wb.SaveAs(memoryStream);
                return File(memoryStream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Orders.xlsx");
            }






        }


    }
}