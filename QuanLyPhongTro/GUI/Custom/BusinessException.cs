using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongTro.GUI.Custom
{
    internal class BusinessException:Exception
    {
        public BusinessException(string massage):base(massage) { 
            
        }
    }
}
