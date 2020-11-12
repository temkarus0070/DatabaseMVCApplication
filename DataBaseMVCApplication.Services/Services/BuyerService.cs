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

        public void AddBuyer(BuyerDto buyerDto)
        {
            repositories.buyerRepository.Create(Convert(buyerDto,false));
        }

        public IEnumerable<Buyer> GetBuyers()
        {
            return repositories.buyerRepository.Get();
        }

        public Buyer GetBuyer(long id)
        {
            return repositories.buyerRepository.GetById(id);
        }

        public void EditBuyer(BuyerDto buyerDto)
        {
            repositories.buyerRepository.Update(Convert(buyerDto,true));
        }

        public void DeleteBuyer(long buyerId)
        {
            repositories.buyerRepository.Delete(buyerId);
        }

        private Buyer Convert(BuyerDto buyerDto,bool isUpdate)
        {
            Buyer buyer = new Buyer() { FIO = buyerDto.FIO, IsLegalEntity = buyerDto.IsLegalEntity, Phone = buyerDto.Phone };
            if (isUpdate)
                buyer.Id = buyerDto.Id;
            return buyer;
        }
    }
}
