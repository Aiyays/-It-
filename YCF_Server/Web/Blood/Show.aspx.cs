using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace YCF_Server.Web.Blood
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int BID=(Convert.ToInt32(strid));
					ShowInfo(BID);
				}
			}
		}
		
	private void ShowInfo(int BID)
	{
		YCF_Server.BLL.Blood bll=new YCF_Server.BLL.Blood();
		YCF_Server.Model.Blood model=bll.GetModel(BID);
		this.lblBID.Text=model.BID.ToString();
		this.lblBtime.Text=model.Btime.ToString();
		this.lblBloodPressure.Text=model.BloodPressure.ToString();
		this.lblBloodFat.Text=model.BloodFat.ToString();
		this.lblBlooGlucose.Text=model.BlooGlucose.ToString();
		this.lblPID.Text=model.PID.ToString();

	}


    }
}
