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
namespace YCF_Server.Web.GroupLader
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
					int GID=(Convert.ToInt32(strid));
					ShowInfo(GID);
				}
			}
		}
		
	private void ShowInfo(int GID)
	{
		YCF_Server.BLL.GroupLader bll=new YCF_Server.BLL.GroupLader();
		YCF_Server.Model.GroupLader model=bll.GetModel(GID);
		this.lblGID.Text=model.GID.ToString();
		this.lblName.Text=model.Name;
		this.lblUID.Text=model.UID.ToString();
		this.lblRemak.Text=model.Remak;

	}


    }
}
