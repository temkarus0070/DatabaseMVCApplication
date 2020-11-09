using DataBaseMVCApplication.Domain;
using DataBaseMVCApplication.Infractracure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseMVCApplication.Services
{
    public class WindowsServices
    {
        private Repositories repositories;

        public WindowsServices()
        {
            repositories = new Repositories();
        }

        public IEnumerable<Window> GetWindows()
        {
            return repositories.windowRepository.Get();
        }

        public void AddWindow(WindowDto windowDto)
        {
            repositories.windowRepository.Create(Convert(windowDto,false));
        }


        public void DeleteWindow(long windowId)
        {
            repositories.windowRepository.Delete(windowId));
        }

        public void EditWindow(WindowDto window)
        {
            repositories.windowRepository.Update(Convert(window,true));
        }

        private Window Convert(WindowDto windowDto,bool isUpdate)
        {
            var window = new Window()
            {
                Color = windowDto.Color,
                Description = windowDto.Description,
                Having = windowDto.Having,
                Image = windowDto.Image,
                 ManufactorId = windowDto.ManufactorId,
                 Manufactor = repositories.manufactorRepository.GetById(windowDto.ManufactorId),
                  Price = windowDto.Price
            };
            if (isUpdate)
                window.Id = windowDto.Id;
            return window;
        }
    }
}
