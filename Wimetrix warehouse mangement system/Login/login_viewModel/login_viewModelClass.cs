using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wimetrix_warehouse_mangement_system.Assets;

namespace Wimetrix_warehouse_mangement_system.Login.login_viewModel
{
    class login_viewModelClass
    {
        errorCode errorCod = new errorCode();
        public Boolean http_loginRequest(System.Collections.Specialized.NameValueCollection reqparm)
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            using (WebClient client = new WebClient())
            {
                byte[] responsebytes = client.UploadValues("http://localhost/traffic_lights_round/login.php", "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(responsebytes);
                JObject json = JObject.Parse(responsebody);
                //Checking the erro Flag sent from PHP
                //String errorCode = 
                

            }
            return false;
        }
    }
}
