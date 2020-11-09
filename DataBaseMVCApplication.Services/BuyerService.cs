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
        private Repositories repositories;

        public BuyerService()
        {
            repositories = new Repositories();
        }

        public void AddBuyer(Buyer buyer)
        {
            repositories.buyerRepository.Create(buyer);
        }

        public void EditBuyer(Buyer buyer)
        {
            repositories.buyerRepository.Update(buyer);
        }

        public void DeleteBuyer(long buyerId)
        {
            repositories.buyerRepository.Delete(buyerId);
        }
    }
}
