using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Wimetrix_warehouse_mangement_system.Properties;

namespace Wimetrix_warehouse_mangement_system.Warehouse_Management.Upload_Excel
{
    class httpRequests
    {
        public HttpResult send_request(System.Collections.Specialized.NameValueCollection reqparm,String filename)
        {

            String ip = Settings.Default.serverIP;
            using (WebClient client = new WebClient())
            {
                try
                {
                    byte[] responsebytes = client.UploadValues("http://" + ip + filename, "POST", reqparm);
                    string responsebody = Encoding.UTF8.GetString(responsebytes);
                    JObject json = JObject.Parse(responsebody);
                    //Checking the erro Flag sent from PHP
                    String errorCode = json.GetValue("Error_Number").ToString();
                    String ErrorDescription = json.GetValue("Error_Description").ToString();
                    if (errorCode == "0")
                    {
                        Console.WriteLine(errorCode);
                        Console.WriteLine(ErrorDescription);
                    }
                    

                    return (new HttpResult(true,errorCode,json));
                }
                catch (Exception ex)
                {
                    return (new HttpResult(false, "server001", null));
                }
            }
           // return (new HttpResult(false, "", null));
        }
    }

    public class HttpResult{
        bool resultFlag { get; set; }
        String errorCode { get; set; }
        JObject jsonResult { get; set; }

        public HttpResult(bool resultFlag,String errorCode, JObject jsonResult)
        {
            this.resultFlag = resultFlag;
            this.errorCode = errorCode;
            this.jsonResult = jsonResult;
        }

        public bool getresultFlag()
        {
            return this.resultFlag;
        }
        public String geterrorCode()
        {
            return this.errorCode;
        }
        public JObject getjsonResult()
        {
            return this.jsonResult;
        }
    }

}
