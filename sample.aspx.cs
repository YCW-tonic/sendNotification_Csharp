using System;
using System.Web.UI.WebControls;
using System.Data.Odbc;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.IO;

public partial class version_project : System.Web.UI.Page
{
    private static HttpWebRequest CreateWebRequest(string url, string action)
    {
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
        webRequest.Headers.Add("SOAPAction", action);
        webRequest.ContentType = "application/json";
        webRequest.Method = "POST";
        return webRequest;
    }
    void WebRequestTest()
    {
        var myUri = new Uri("https://fcm.googleapis.com/fcm/send"); 
        var myWebRequest = WebRequest.Create(myUri);
        var myHttpWebRequest = (HttpWebRequest)myWebRequest;
        myHttpWebRequest.PreAuthenticate = true;
        myHttpWebRequest.Headers.Add("Authorization", "key=AAAAGMjHGqw:APA91bF3px1Z3_lbXkIMZOx9HERPd90unaajs1qM6svTcJUyfDivREyB_B9-IEuoJpHQekOVSHg2WVkKLPhWkZVNAkt6AcfiN36_GoWgWBhcDlv0xDP9EHGvk_Q5k7CWL8-ENmQLt4Uy");
        //myHttpWebRequest.Accept = "application/json";
        myHttpWebRequest.ContentType = "application/json";
        myHttpWebRequest.Method = "POST";

        using(var streamWriter = new StreamWriter(myHttpWebRequest.GetRequestStream()))
        {
            string json = "{\"condition\":\"'test' in topics\",\"priority\":\"high\",\"content_available\":true,\"notification\":{\"title\":\"標題0928\",\"body\":\"內容\"}}";
            streamWriter.Write(json);
        }

        var httpResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
        using(var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var result = streamReader.ReadToEnd();
            Response.Write(result);
        }

        //var myWebResponse = myWebRequest.GetResponse();
        //var responseStream = myWebResponse.GetResponseStream();
        //if (responseStream == null) return null;

        //var myStreamReader = new StreamReader(responseStream, Encoding.Default);
        //var json = myStreamReader.ReadToEnd();

        //responseStream.Close();
        //myWebResponse.Close();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        WebRequestTest();
    }
}

   
