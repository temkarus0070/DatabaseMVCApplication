using DataBaseMVCApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Services
{
    public class ServiceForService
    {
        private Repositories repositories;
        public ServiceForService()
        {
            repositories = new Repositories();
        }

        public void AddService(Service service)
        {
            repositories.serviceRepository.Create(service);
        }

        public void EditService(Service service)
        {
            repositories.serviceRepository.Update(service);
        }

        public void DeleteService(long serviceId)
        {
            repositories.serviceRepository.Delete(serviceId);
        }
    }
}
