using paytm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PayTMPaymentGateway
{
    public partial class Response : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			String merchantKey = //"Enter Your Merchant Key";
			Dictionary<string, string> parameters = new Dictionary<string, string>();
			string paytmChecksum = "";
			foreach (string key in Request.Form.Keys)
			{
				parameters.Add(key.Trim(), Request.Form[key].Trim());
			}
			if (parameters.ContainsKey("CHECKSUMHASH"))
			{
				paytmChecksum = parameters["CHECKSUMHASH"];
				parameters.Remove("CHECKSUMHASH");
			}
			if (CheckSum.verifyCheckSum(merchantKey, parameters, paytmChecksum))
			{
				string paytmStatus = parameters["STATUS"];
				string txnId = parameters["TXNID"];
			
				if (paytmStatus == "TXN_SUCCESS")
				{
				 Label1.Text="Your payment is success";
				}
				else if (paytmStatus == "PENDING")
				{
					Label1.Text ="Payment is pending !";
				}
				else if (paytmStatus == "TXN_FAILURE")
				{
					Label1.Text ="Payment Failure !";
				}
			}
			else
			{
				Response.Write("Checksum MisMatch");
			}
		}
    }
}