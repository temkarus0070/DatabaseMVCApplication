﻿using DataBaseMVCApplication.Domain;
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

        public IEnumerable<SellerDto> GetSellers()
        {
            return repositories.sellerRepository.Get().Select(e => new SellerDto()
            {
                Email = e.Email,
                FIO = e.FIO,
                Id = e.Id,
                PercentFromOrder = e.PercentFromOrder,
                Phone = e.Phone
            });
        }

        public Seller GetSeller(long id)
        {
            return repositories.sellerRepository.GetById(id);
        }

        public void AddSeller(SellerDto sellerDto)
        {
            repositories.sellerRepository.Create(Convert(sellerDto,false));
        }

        public void DeleteSeller(long sellerId)
        {
            repositories.sellerRepository.Delete(sellerId);
        }

        public void UpdateSeller(SellerDto sellerDto)
        {
            repositories.sellerRepository.Update(Convert(sellerDto,true));
        }

        private Seller Convert(SellerDto sellerDto,bool isUpdate)
        {
            var seller = new Seller()
            {
                Email = sellerDto.Email,
                FIO = sellerDto.FIO,
                PercentFromOrder = sellerDto.PercentFromOrder,
                Phone = sellerDto.Phone
            };
            if (isUpdate)
                seller.Id = sellerDto.Id;
            return seller;

        }
    }
}
