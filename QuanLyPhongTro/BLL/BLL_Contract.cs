using QuanLyPhongTro.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyPhongTro.DTO;
using QuanLyPhongTro.GUI.Custom;
using System.Data;

namespace QuanLyPhongTro.BLL
{
    internal class BLL_Contract
    {
        DAL_Contract dal = new DAL_Contract();

        // GET --- 
        public List<Contract> getListContract()
        {
            return dal.getListContract();
        }
        public List<DetailContract> GetDetailContractList(string idhd)
        {
            return dal.FindDetailContractByIDContract(idhd);
        }
        public string getIDContractByIDGuest(int idGuest)
        {
            return dal.getIdContractByIDGuest(idGuest);
        }

        public string getIDContractByIDRoom(string idRoom)
        {
           
            return dal.getIDContractByIDRoom(idRoom);
        }
        // CHECK -- 
        public bool ExistContract(string id)
        {
            return dal.ExistContract(id);
        }
        public bool CheckCancelContract(string mahd)
        {
            
            return dal.CheckCancelContract(mahd);
        }

        // CRUD -- 
        public bool AddContract(Contract contract)
        {
            if (contract.HanThue <= contract.NgayThue) {
                throw new BusinessException("Hạn thuê không được nhỏ hơn ngày thuê");
            }
            if (string.IsNullOrEmpty(contract.SoPhong.ToString()))
            {
                throw new BusinessException("Số phòng không thể để trống");
            }
            if (string.IsNullOrEmpty(contract.TrangThai))
            {
                throw new BusinessException("Trạng thái tạo hóa đơn không hợp lệ");
            }
            if (string.IsNullOrEmpty(contract.GiaPhong.ToString())) {
                throw new BusinessException("Giá phòng không thể để trống");
            }
            
            return dal.AddContract(contract);
        }
        public bool AddDetailContract(DetailContract dtc)
        {
            return dal.AddDetailContract(dtc);
        }
        public bool RemoveContract(string idcontract)
        {
            return dal.RemoveContract(idcontract);
        }
        public bool CancelContract(string id)
        {
            return dal.CancelContract(id);
        }

        // FILL AND FIND
        public List<Contract> FillContractStatus(string status)
        {
            return dal.FillContractStatus(status);
        }
        public Contract FindContractByIDContract(string idhd)
        {
            return dal.FindContractByIDContract(idhd);
        }
        public decimal FindContractByIDRoom(string id)
        {
            return dal.FindContractByIDRoom(id);
        }
        public List<int> getlistIdGuestByIDContract(string id)
        {
            return dal.getlistIdGuestByIDContract(id);
        }
    }
}
