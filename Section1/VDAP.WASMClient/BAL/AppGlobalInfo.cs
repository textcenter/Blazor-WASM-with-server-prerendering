using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VDAP.WASMClient.Shared;

namespace VDAP.WASMClient.BAL
{
    public class AppGlobalInfo
    {
        public static AppSettings AppSettings { get; set; }
        static AppGlobalInfo()
        {
            AppSettings = new AppSettings();
        }
    }
}
