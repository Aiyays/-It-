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
namespace YCF_Server.Web.Employee
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
					int EID=(Convert.ToInt32(strid));
					ShowInfo(EID);
				}
			}
		}
		
	private void ShowInfo(int EID)
	{
		YCF_Server.BLL.Employee bll=new YCF_Server.BLL.Employee();
		YCF_Server.Model.Employee model=bll.GetModel(EID);
		this.lblEID.Text=model.EID.ToString();
		this.lblUID.Text=model.UID.ToString();
		this.lblNateTime.Text=model.NateTime;
		this.lblDaparturTime.Text=model.DaparturTime;
		this.lblState.Text=model.State;
		this.lblGID.Text=model.GID.ToString();

	}


    }
}
