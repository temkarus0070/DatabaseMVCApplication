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
        private BaseRepository<Window> windowRepository;
        private WindowsDatabaseContext context;

        public WindowsServices()
        {
            context = new WindowsDatabaseContext();
            windowRepository = new BaseRepository<Window>(context);
        }

        public IEnumerable<Window> GetWindows()
        {
            return windowRepository.Get();
        }

        public void AddWindow(Window window)
        {
            windowRepository.Create(window);
        }


        public void DeleteWindow(Window window)
        {
            windowRepository.Delete(window);
        }

        public void EditWindow(Window window)
        {
            windowRepository.Update(window);
        }
    }
}
