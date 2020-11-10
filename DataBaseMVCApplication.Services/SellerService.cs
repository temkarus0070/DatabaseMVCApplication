using DataBaseMVCApplication.Domain;
using DataBaseMVCApplication.Infractracure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Services
{
   public class SellerService
    {
        private Repositories repositories;
        public SellerService()
        {
            repositories = new Repositories();
        }

        public void AddSeller(SellerDto sellerDto)
        {
            repositories.sellerRepository.Create(Convert(sellerDto));
        }

        public void DeleteSeller(SellerDto sellerDto)
        {
            repositories.sellerRepository.Delete(Convert(sellerDto));
        }

        public void UpdateSeller(SellerDto sellerDto)
        {
            repositories.sellerRepository.Update(Convert(sellerDto));
        }

        private Seller Convert(SellerDto sellerDto)
        {
            return new Seller()
            {
                Email = sellerDto.Email,
                FIO = sellerDto.FIO,
                PercentFromOrder = sellerDto.PercentFromOrder,
                Phone = sellerDto.Phone
            };
        }
    }
}
