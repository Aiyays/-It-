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
namespace YCF_Server.Web.Food
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
					int FID=(Convert.ToInt32(strid));
					ShowInfo(FID);
				}
			}
		}
		
	private void ShowInfo(int FID)
	{
		YCF_Server.BLL.Food bll=new YCF_Server.BLL.Food();
		YCF_Server.Model.Food model=bll.GetModel(FID);
		this.lblFID.Text=model.FID.ToString();
		this.lblName.Text=model.Name;
		this.lblPrice.Text=model.Price;
		this.lblUnit.Text=model.Unit;
		this.lblQuantity.Text=model.Quantity.ToString();
		this.lblTID.Text=model.TID.ToString();

	}


    }
}
