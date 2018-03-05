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
namespace YCF_Server.Web.Role
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
		YCF_Server.BLL.Role bll=new YCF_Server.BLL.Role();
		YCF_Server.Model.Role model=bll.GetModel(RID);
		this.lblRID.Text=model.RID.ToString();
		this.lblRoleName.Text=model.RoleName;
		this.lblRNumber.Text=model.RNumber;
		this.lblDID.Text=model.DID.ToString();

	}


    }
}
