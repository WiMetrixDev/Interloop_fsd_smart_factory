using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wimetrix_warehouse_mangement_system.Assets
{
    class errorCode
    {
        public String getErrorInfo(String btErrorCode)
        {
            string strErrorCode = "";
            switch (btErrorCode)
            {
                case "DB00":
                    strErrorCode = "Database operation succeeded";
                    break;
                case "DB01":
                    strErrorCode = "Database connection failed";
                    break;
                case "DB02":
                    strErrorCode = "Missing parameters";
                    break;
                case "DB03":
                    strErrorCode = "Invalid query";
                    break;
                case "DB04":
                    strErrorCode = "No data found";
                    break;
                default:
                    break;
            }
            return strErrorCode;
        }
    }
}
