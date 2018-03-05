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
namespace YCF_Server.Web.GetDrug
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
		YCF_Server.BLL.GetDrug bll=new YCF_Server.BLL.GetDrug();
		YCF_Server.Model.GetDrug model=bll.GetModel(ID);
		this.lblID.Text=model.ID.ToString();
		this.lblEID.Text=model.EID.ToString();
		this.lblDID.Text=model.DID.ToString();
		this.lblGDTime.Text=model.GDTime.ToString();

	}


    }
}
