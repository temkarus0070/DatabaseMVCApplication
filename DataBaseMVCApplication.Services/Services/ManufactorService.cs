using DataBaseMVCApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Services
{
    public class ManufactorService
    {
        private Repositories repositories;

        public ManufactorService()
        {
            repositories = new Repositories();
        }

        public IEnumerable<Manufactor> GetManufactors()
        {
            return repositories.manufactorRepository.Get();
        }

        public Manufactor GetManufactor(long id)
        {
            return repositories.manufactorRepository.GetById(id);
        }

        public void AddManufactor(ManufactorDto manufactorDto)
        {
            repositories.manufactorRepository.Create(Convert(manufactorDto, false));
        }


        public void DeleteManufactor(long manufactorId)
        {
            repositories.manufactorRepository.Delete(manufactorId);
        }

        public void EditManufactor(ManufactorDto manufactorDto)
        {
            repositories.manufactorRepository.Update(Convert(manufactorDto, true));
        }

        private Manufactor Convert(ManufactorDto manufactorDto, bool isUpdate)
        {
            var manufactor = new Manufactor()
            {
                Address = manufactorDto.Address,
                Email = manufactorDto.Email,
                Name = manufactorDto.Name,
                Phone = manufactorDto.Phone
            };
            if (isUpdate)
                manufactor.Id = manufactorDto.Id;
            return manufactor;
        }
    }
}
