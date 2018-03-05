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
namespace YCF_Server.Web.TransferClass
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
					int TID=(Convert.ToInt32(strid));
					ShowInfo(TID);
				}
			}
		}
		
	private void ShowInfo(int TID)
	{
		YCF_Server.BLL.TransferClass bll=new YCF_Server.BLL.TransferClass();
		YCF_Server.Model.TransferClass model=bll.GetModel(TID);
		this.lblTID.Text=model.TID.ToString();
		this.lblA_OID.Text=model.A_OID.ToString();
		this.lblR_OID.Text=model.R_OID.ToString();
		this.lblReason.Text=model.Reason;
		this.lblTransferTime.Text=model.TransferTime;
		this.lblNowTime.Text=model.NowTime;

	}


    }
}
