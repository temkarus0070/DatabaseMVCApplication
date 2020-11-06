using DataBaseMVCApplication.Domain;
using DataBaseMVCApplication.Infractracure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Services
{
  public class BuyerService
    {
        private BaseRepository<Buyer> buyerRepository;
        private WindowsDatabaseContext context;

        public BuyerService()
        {
            context = new WindowsDatabaseContext();
            this.buyerRepository = new BaseRepository<Buyer>(context);
        }

        public void AddBuyer(Buyer buyer)
        {
            buyerRepository.Create(buyer);
        }

        public void EditBuyer(Buyer buyer)
        {
            buyerRepository.Update(buyer);
        }

        public void DeleteBuyer(Buyer buyer)
        {
            buyerRepository.Delete(buyer);
        }
    }
}
