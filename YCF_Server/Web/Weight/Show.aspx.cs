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
namespace YCF_Server.Web.Weight
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
		YCF_Server.BLL.Weight bll=new YCF_Server.BLL.Weight();
		YCF_Server.Model.Weight model=bll.GetModel(WID);
		this.lblWID.Text=model.WID.ToString();
		this.lblWTime.Text=model.WTime.ToString();
		this.lblWeight.Text=model.Weight;
		this.lblPID.Text=model.PID.ToString();

	}


    }
}
