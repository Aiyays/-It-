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
namespace YCF_Server.Web.PensnonalDrug
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
					int PDID=(Convert.ToInt32(strid));
					ShowInfo(PDID);
				}
			}
		}
		
	private void ShowInfo(int PDID)
	{
		YCF_Server.BLL.PensnonalDrug bll=new YCF_Server.BLL.PensnonalDrug();
		YCF_Server.Model.PensnonalDrug model=bll.GetModel(PDID);
		this.lblPDID.Text=model.PDID.ToString();
		this.lblDTime.Text=model.DTime.ToString();
		this.lblFrequency.Text=model.Frequency;
		this.lblDose.Text=model.Dose;
		this.lblDID.Text=model.DID.ToString();
		this.lblEID.Text=model.EID.ToString();
		this.lblPID.Text=model.PID.ToString();
		this.lblIMG.Text=model.IMG;
		this.lblRemark.Text=model.Remark;

	}


    }
}
