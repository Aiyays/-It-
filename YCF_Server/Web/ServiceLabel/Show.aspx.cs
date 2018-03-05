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
namespace YCF_Server.Web.ServiceLabel
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
					int SLID=(Convert.ToInt32(strid));
					ShowInfo(SLID);
				}
			}
		}
		
	private void ShowInfo(int SLID)
	{
		YCF_Server.BLL.ServiceLabel bll=new YCF_Server.BLL.ServiceLabel();
		YCF_Server.Model.ServiceLabel model=bll.GetModel(SLID);
		this.lblSLID.Text=model.SLID.ToString();
		this.lblSID.Text=model.SID.ToString();
		this.lblLID.Text=model.LID.ToString();

	}


    }
}
