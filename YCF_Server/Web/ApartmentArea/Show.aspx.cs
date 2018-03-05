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
namespace YCF_Server.Web.ApartmentArea
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
					int AID=(Convert.ToInt32(strid));
					ShowInfo(AID);
				}
			}
		}
		
	private void ShowInfo(int AID)
	{
		YCF_Server.BLL.ApartmentArea bll=new YCF_Server.BLL.ApartmentArea();
		YCF_Server.Model.ApartmentArea model=bll.GetModel(AID);
		this.lblAID.Text=model.AID.ToString();
		this.lblApartmentArea.Text=model.ApartmentArea;

	}


    }
}
