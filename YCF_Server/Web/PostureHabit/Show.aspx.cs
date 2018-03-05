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
namespace YCF_Server.Web.PostureHabit
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
					int PHID=(Convert.ToInt32(strid));
					ShowInfo(PHID);
				}
			}
		}
		
	private void ShowInfo(int PHID)
	{
		YCF_Server.BLL.PostureHabit bll=new YCF_Server.BLL.PostureHabit();
		YCF_Server.Model.PostureHabit model=bll.GetModel(PHID);
		this.lblPHID.Text=model.PHID.ToString();
		this.lblHeight.Text=model.Height.ToString();
		this.lblMedicine.Text=model.Medicine.ToString();
		this.lblBack.Text=model.Back.ToString();
		this.lblHead.Text=model.Head.ToString();
		this.lblWaist.Text=model.Waist.ToString();
		this.lblLeg.Text=model.Leg.ToString();
		this.lblUID.Text=model.UID.ToString();

	}


    }
}
