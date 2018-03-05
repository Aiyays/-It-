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
namespace YCF_Server.Web.Bed
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
		YCF_Server.BLL.Bed bll=new YCF_Server.BLL.Bed();
		YCF_Server.Model.Bed model=bll.GetModel(BID);
		this.lblBID.Text=model.BID.ToString();
		this.lblNumber.Text=model.Number;
		this.lblPosture.Text=model.Posture;
		this.lblPID.Text=model.PID.ToString();
		this.lblEID.Text=model.EID.ToString();
		this.lblAID.Text=model.AID.ToString();

	}


    }
}
