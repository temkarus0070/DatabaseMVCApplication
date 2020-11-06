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
        private BaseRepository<Seller> sellerRepository;
        private WindowsDatabaseContext context;
        public SellerService()
        {
            context = new WindowsDatabaseContext();
            this.sellerRepository = new BaseRepository<Seller>(context);
        }

        public void AddSeller(Seller seller)
        {
            sellerRepository.Create(seller);
        }

        public void DeleteSeller(Seller seller)
        {
            sellerRepository.Delete(seller);
        }

        public void UpdateSeller(Seller seller)
        {
            sellerRepository.Update(seller);
        }
    }
}
