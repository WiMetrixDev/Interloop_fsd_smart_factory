using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Wimetrix_warehouse_mangement_system.Properties;

namespace Wimetrix_warehouse_mangement_system.Http
{
    class http_request
    {
        public HttpResult send_request(System.Collections.Specialized.NameValueCollection reqparm, String filename)
        {
            System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            String ip = Settings.Default.serverIP.ToString();
            if (pingServer(ip))
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        byte[] responsebytes = client.UploadValues("http://" + ip + filename, "POST", reqparm);
                        string responsebody = Encoding.UTF8.GetString(responsebytes);
                        try
                        {
                            JObject json = JObject.Parse(responsebody);
                            //Checking the erro Flag sent from PHP
                            String errorCode = json.GetValue("Error_No").ToString();
                            String ErrorDescription = json.GetValue("Error_Description").ToString();
                            if (errorCode == "0")
                            {
                                System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                                return (new HttpResult(true, errorCode,ErrorDescription, json));                          
                            }
                            else
                            {
                                if (errorCode == "API-Duplicate")
                                {
                                    System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                                    return (new HttpResult(false, "API-Duplicate", ErrorDescription, json));
                                }
                                System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                                return (new HttpResult(false,"API-001",ErrorDescription ,json));
                            }
                           
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                            return (new HttpResult(false, "API:","API ERROR", null));
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                        return (new HttpResult(false, "HTTP","HTTP ERROR" ,null));
                    }
                }
                // return (new HttpResult(false, "", null));
            }
            else
            {
                System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                return (new HttpResult(false, "server001","IP address Unreachable" ,null));
            }


        }
        public HttpResult send_request_for_error_codes_in_return(System.Collections.Specialized.NameValueCollection reqparm, String filename)
        {
            System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            string ip = Settings.Default.serverIP.ToString();
            if (pingServer(ip))
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        byte[] responsebytes = client.UploadValues("http://" + ip + filename, "POST", reqparm);
                        string responsebody = Encoding.UTF8.GetString(responsebytes);
                        try
                        {
                            JObject json = JObject.Parse(responsebody);
                            //Checking the erro Flag sent from PHP
                            String errorCode = json.GetValue("Error_No").ToString();
                            String ErrorDescription = json.GetValue("Error_Description").ToString();
                            if (errorCode == "0")
                            {
                                System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                                return (new HttpResult(true, errorCode, ErrorDescription, json));
                            }
                            else
                            {
                                if (errorCode == "API03")
                                {
                                    System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                                    return (new HttpResult(false, "API-001", ErrorDescription, json));
                                }
                                if (errorCode == "API04")
                                {
                                    System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                                    return (new HttpResult(false, "API-001", ErrorDescription, json));                              
                                }
                                if (errorCode == "API02")
                                {
                                    System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                                    return (new HttpResult(false, "API-001", ErrorDescription, json));
                                }
                                if (errorCode == "API01")
                                {
                                    System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                                    return (new HttpResult(false, "API-001", ErrorDescription, json));
                                }
                                System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                                return (new HttpResult(false, "DB-001", ErrorDescription, json));
                            }

                        }
                        catch (Exception ex)
                        {
                            System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                            return (new HttpResult(false, "API", "API ERROR", null));
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                        return (new HttpResult(false, "HTTP", "HTTP ERROR", null));
                    }
                }
                // return (new HttpResult(false, "", null));
            }
            else
            {
                System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                return (new HttpResult(false, "server001", "IP address Unreachable", null));
            }


        }
        public HttpResult send_node_request(String requestBody, String api_name, String method)
        {
            System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            string ip = Settings.Default.nodeServerIP.ToString();
            Console.WriteLine(ip);
            if (pingServer(ip))
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        Console.WriteLine("http://" + ip + api_name);
                        Console.WriteLine(method);
                        Console.WriteLine(requestBody);
                        client.Headers[HttpRequestHeader.ContentType] = "application/json";
                        string responsebody = client.UploadString($"http://{ip}{api_name}", method, requestBody);

                        JObject json = JObject.Parse(responsebody);
                        //Checking the erro Flag sent from PHP
                        String errorCode = json.GetValue("ErrorNumber").ToString();
                        String ErrorDescription = json.GetValue("ErrorMessage").ToString();
                        if (errorCode == "0")
                        {
                            System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                            return (new HttpResult(true, errorCode, ErrorDescription, json));
                        }
                        else
                        {
                            if (errorCode == "API-Duplicate")
                            {
                                System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                                return (new HttpResult(false, "API-Duplicate", ErrorDescription, json));
                            }
                            System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                            return (new HttpResult(false, "API-001", ErrorDescription, json));
                        }
                    }
                    catch (WebException ex)
                    {
                        System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                        using (WebResponse response = ex.Response)
                        {
                            HttpWebResponse httpResponse = (HttpWebResponse)response;
                            Console.WriteLine("Error code: {0}", httpResponse.StatusCode);
                            using (Stream data = response.GetResponseStream())
                            using (var reader = new StreamReader(data))
                            {
                                string responseText = reader.ReadToEnd();
                                JObject responseJson = JObject.Parse(responseText);
                                if (responseJson.GetValue("message") != null)
                                {
                                    Console.WriteLine(responseJson.GetValue("message").ToString());
                                    return (new HttpResult(false, "API-001", responseJson.GetValue("message").ToString(), null));
                                }
                                else if (responseJson.GetValue("ErrorMessage") != null)
                                {
                                    Console.WriteLine(responseJson.GetValue("ErrorMessage").ToString());
                                    return (new HttpResult(false, "API-001", responseJson.GetValue("ErrorMessage").ToString(), null));
                                }
                                else
                                {
                                    return (new HttpResult(false, "HTTP", "HTTP ERROR", null));
                                }

                            }

                        }
                    }
                }
                // return (new HttpResult(false, "", null));
            }
            else
            {
                System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                return (new HttpResult(false, "server001", "IP address Unreachable", null));
            }


        }
        public HttpResult get_node_request(String api_name, String reqParams)
        {
            System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            string ip = Settings.Default.nodeServerIP.ToString();
            if (pingServer(ip))
            {
                using (WebClient client = new WebClient())
                {

                    try
                    {
                        //Console.WriteLine("http://" + ip + api_name);
                        string request_address = $"http://{ip}{api_name}?{reqParams}";
                        byte[] responsebytes = client.DownloadData(request_address);
                        string responsebody = Encoding.UTF8.GetString(responsebytes);

                        JObject json = JObject.Parse(responsebody);
                        //Checking the erro Flag sent from PHP
                        JToken items = json.GetValue("items");

                        if (items != null && items.Type == JTokenType.Array)
                        {
                            System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                            return (new HttpResult(true, "0", "", json));
                        }
                        else
                        {
                            System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                            String ErrorMessage = json.GetValue("ErrorMessage").ToString();
                            return (new HttpResult(false, "API-001", ErrorMessage, json));
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                        return (new HttpResult(false, "HTTP", "HTTP ERROR", null));
                    }
                }
                // return (new HttpResult(false, "", null));
            }
            else
            {
                System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                return (new HttpResult(false, "server001", "IP address Unreachable", null));
            }


        }
        public bool pingServer(String IP)
        {
            Ping ping = new Ping();
            String[] ip_address = IP.Split('/');
            try
            {
                String ip = ip_address[0];
                if (ip.Contains(":"))
                {
                    String[] ip_address_without_colons = IP.Split(':');
                    ip = ip_address_without_colons[0];
                }
                PingReply pingresult = ping.Send(ip);
                if (pingresult.Status.ToString() == "Success")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }

        }
    } 
    public class HttpResult
    {
        bool resultFlag { get; set; }
        String errorCode { get; set; }
        String errorDescription { get; set; }
        JObject jsonResult { get; set; }

        public HttpResult(bool resultFlag, String errorCode,String errorDescription, JObject jsonResult)
        {
            this.resultFlag = resultFlag;
            this.errorCode = errorCode;
            this.jsonResult = jsonResult;
            this.errorDescription = errorDescription;
        }

        public bool getresultFlag()
        {
            return this.resultFlag;
        }
        public String getDescription()
        {
            return this.errorDescription;
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
