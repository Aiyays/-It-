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
namespace YCF_Server.Web.Week
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
					int WID=(Convert.ToInt32(strid));
					ShowInfo(WID);
				}
			}
		}
		
	private void ShowInfo(int WID)
	{
		YCF_Server.BLL.Week bll=new YCF_Server.BLL.Week();
		YCF_Server.Model.Week model=bll.GetModel(WID);
		this.lblWID.Text=model.WID.ToString();
		this.lblWeek.Text=model.Week;

	}


    }
}
