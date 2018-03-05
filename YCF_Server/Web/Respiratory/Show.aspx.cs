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
namespace YCF_Server.Web.Respiratory
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
					int RID=(Convert.ToInt32(strid));
					ShowInfo(RID);
				}
			}
		}
		
	private void ShowInfo(int RID)
	{
		YCF_Server.BLL.Respiratory bll=new YCF_Server.BLL.Respiratory();
		YCF_Server.Model.Respiratory model=bll.GetModel(RID);
		this.lblRID.Text=model.RID.ToString();
		this.lblRtime.Text=model.Rtime.ToString();
		this.lblBreathe.Text=model.Breathe.ToString();
		this.lblHeartRate.Text=model.HeartRate.ToString();
		this.lblPID.Text=model.PID.ToString();

	}


    }
}
