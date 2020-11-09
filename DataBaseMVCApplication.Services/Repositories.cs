using DataBaseMVCApplication.Domain;
using DataBaseMVCApplication.Infractracure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Services
{
    internal class Repositories
    {
        private WindowsDatabaseContext context = new WindowsDatabaseContext();
        public BaseRepository<Order> orderRepository;
        public BaseRepository<Buyer> buyerRepository;
        public BaseRepository<Seller> sellerRepository;
        public BaseRepository<OrderPosition> orderPositionRepository;
        public BaseRepository<Window> windowRepository;
        public BaseRepository<Manufactor> manufactorRepository;
        public BaseRepository<Service> serviceRepository;

        public Repositories()
        {
            sellerRepository = new BaseRepository<Seller>(context);
            orderRepository = new BaseRepository<Order>(context);
            orderPositionRepository = new BaseRepository<OrderPosition>(context);
            buyerRepository = new BaseRepository<Buyer>(context);
            windowRepository = new BaseRepository<Window>(context);
            manufactorRepository = new BaseRepository<Manufactor>(context);
            serviceRepository = new BaseRepository<Service>(context);
        }

    }
}
