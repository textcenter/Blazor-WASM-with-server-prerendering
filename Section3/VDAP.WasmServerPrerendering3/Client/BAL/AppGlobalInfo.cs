using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VDAP.WasmServerPrerendering2.Shared;

namespace VDAP.WasmServerPrerendering2.Client.BAL
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
