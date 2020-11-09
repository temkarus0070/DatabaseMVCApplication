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
        
        private WindowsDatabaseContext context;
        public SellerService()
        {
            context = new WindowsDatabaseContext();
            this.sellerRepository = new BaseRepository<Seller>(context);
        }

        public void AddSeller(SellerDto sellerDto)
        {
            sellerRepository.Create(Convert(sellerDto));
        }

        public void DeleteSeller(SellerDto sellerDto)
        {
            sellerRepository.Delete(Convert(sellerDto));
        }

        public void UpdateSeller(SellerDto sellerDto)
        {
            sellerRepository.Update(Convert(sellerDto));
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
