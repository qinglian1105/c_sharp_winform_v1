using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformDemoV01
{
    public class GlobalFunc
    {        
        private static GlobalFunc _Instance = null;

        public static GlobalFunc Instance
        {
            get
            {
                if (_Instance == null)
                    _Instance = new GlobalFunc();
                return _Instance;
            }
        }
      
        public string storeUsername = null;
        public string storePassword = null;
        public string storeAuthority = null;
        
        public FormLogin formLogin = null;
    }
}
