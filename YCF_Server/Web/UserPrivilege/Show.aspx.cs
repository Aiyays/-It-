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
namespace YCF_Server.Web.UserPrivilege
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
					int ID=(Convert.ToInt32(strid));
					ShowInfo(ID);
				}
			}
		}
		
	private void ShowInfo(int ID)
	{
		YCF_Server.BLL.UserPrivilege bll=new YCF_Server.BLL.UserPrivilege();
		YCF_Server.Model.UserPrivilege model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lblURID.Text=model.URID.ToString();
		this.lblMID.Text=model.MID.ToString();

	}


    }
}
