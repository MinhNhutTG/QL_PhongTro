using QuanLyPhongTro.DAL;
using QuanLyPhongTro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.BLL
{
    internal class BLL_Service
    {
        DAL_Service dalService = new DAL_Service(); 
        public Service GetServiceByName(string name)
        {
            return dalService.getServiceByName(name);
        }
        public List<Service> getListService()
        {
            return dalService.getlistService();
        }
        public bool AddService(Service sv)
        {
            return dalService.Add(sv);
        }
        public bool UpdateService(Service sv)
        {
            return dalService.Update(sv);
        }
        public bool DeleteService(string nameService)
        {
            return dalService.Delete(nameService);
        }
        public bool ExistService(string nameService)
        {
            return dalService.Exist(nameService);
        }
    }
}
