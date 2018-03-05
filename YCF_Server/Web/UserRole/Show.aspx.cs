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
namespace YCF_Server.Web.UserRole
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
					int URID=(Convert.ToInt32(strid));
					ShowInfo(URID);
				}
			}
		}
		
	private void ShowInfo(int URID)
	{
		YCF_Server.BLL.UserRole bll=new YCF_Server.BLL.UserRole();
		YCF_Server.Model.UserRole model=bll.GetModel(URID);
		this.lblURID.Text=model.URID.ToString();
		this.lblUID.Text=model.UID.ToString();
		this.lblRID.Text=model.RID.ToString();

	}


    }
}
