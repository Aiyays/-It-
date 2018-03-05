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
namespace YCF_Server.Web.FoodLabel
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
					int FLID=(Convert.ToInt32(strid));
					ShowInfo(FLID);
				}
			}
		}
		
	private void ShowInfo(int FLID)
	{
		YCF_Server.BLL.FoodLabel bll=new YCF_Server.BLL.FoodLabel();
		YCF_Server.Model.FoodLabel model=bll.GetModel(FLID);
		this.lblFLID.Text=model.FLID.ToString();
		this.lblFID.Text=model.FID.ToString();
		this.lblLID.Text=model.LID.ToString();

	}


    }
}
