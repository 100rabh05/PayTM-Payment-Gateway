using paytm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayTMPaymentGateway
{
    public partial class PaytmPaymentGateway : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			String merchantKey = //"Enter Your Merchant key";
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			parameters.Add("MID", "Merchant ID");
			parameters.Add("CHANNEL_ID", "WEB");
			parameters.Add("INDUSTRY_TYPE_ID", "Retail");
			parameters.Add("WEBSITE", "WEBSTAGING");
			parameters.Add("EMAIL", "100rabhjaiswal05@gmail.com");
			parameters.Add("MOBILE_NO","123456789");
			parameters.Add("CUST_ID", "CUST_001");
			parameters.Add("ORDER_ID", "001");
			parameters.Add("TXN_AMOUNT","1");
			parameters.Add("CALLBACK_URL", "https://localhost:44399/Response.aspx"); //This parameter is not mandatory. Use this to pass the callback url dynamically.
			string checksum = CheckSum.generateCheckSum(merchantKey, parameters);
			string paytmURL = "https://securegw-stage.paytm.in/order/process";
			string outputHTML = "<html>";
			outputHTML += "<head>";
			outputHTML += "<title>Merchant Check Out Page</title>";
			outputHTML += "</head>";
			outputHTML += "<body>";
			outputHTML += "<center>Please do not refresh this page...</center>"; //you can put h1 tag here
			outputHTML += "<form method='post' action='" + paytmURL + "' name='f1'>";
			outputHTML += "<table border='1'>";
			outputHTML += "<tbody>";
			foreach (string key in parameters.Keys)
			{
				outputHTML += "<input type='hidden' name='" + key + "' value='" + parameters[key] + "'>";
			}
			outputHTML += "<input type='hidden' name='CHECKSUMHASH' value='" + checksum + "'>";
			outputHTML += "</tbody>";
			outputHTML += "</table>";
			outputHTML += "<script type='text/javascript'>";
			outputHTML += "document.f1.submit();";
			outputHTML += "</script>";
			outputHTML += "</form>";
			outputHTML += "</body>";
			outputHTML += "</html>";
			Response.Write(outputHTML);
		}
	}
    
}