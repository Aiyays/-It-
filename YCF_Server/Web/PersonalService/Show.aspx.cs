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
namespace YCF_Server.Web.PersonalService
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
					int PSID=(Convert.ToInt32(strid));
					ShowInfo(PSID);
				}
			}
		}
		
	private void ShowInfo(int PSID)
	{
		YCF_Server.BLL.PersonalService bll=new YCF_Server.BLL.PersonalService();
		YCF_Server.Model.PersonalService model=bll.GetModel(PSID);
		this.lblPSID.Text=model.PSID.ToString();
		this.lblPID.Text=model.PID.ToString();
		this.lblGID.Text=model.GID.ToString();
		this.lblSID.Text=model.SID.ToString();
		this.lblPTime.Text=model.PTime.ToString();

	}


    }
}
