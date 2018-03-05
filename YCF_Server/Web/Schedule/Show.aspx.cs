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
namespace YCF_Server.Web.Schedule
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
					int SID=(Convert.ToInt32(strid));
					ShowInfo(SID);
				}
			}
		}
		
	private void ShowInfo(int SID)
	{
		YCF_Server.BLL.Schedule bll=new YCF_Server.BLL.Schedule();
		YCF_Server.Model.Schedule model=bll.GetModel(SID);
		this.lblSID.Text=model.SID.ToString();
		this.lblSCID.Text=model.SCID.ToString();
		this.lblWID.Text=model.WID.ToString();

	}


    }
}
