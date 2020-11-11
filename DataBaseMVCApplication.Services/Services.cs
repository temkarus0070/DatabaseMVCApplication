using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Services
{
    public class Services
    {
        public BuyerService buyerService;
        public ManufactorService manufactorService;
        public OrderPositionService orderPositionService;
        public OrderService orderService;
        public SellerService sellerService;
        public ServiceForService serviceForService;
        public WindowsServices windowsServices;

        public Services()
        {
            buyerService = new BuyerService();
            manufactorService = new ManufactorService();
            orderPositionService = new OrderPositionService();
            orderService = new OrderService();
            sellerService = new SellerService();
            serviceForService = new ServiceForService();
            windowsServices = new WindowsServices();
        }

    }
}
