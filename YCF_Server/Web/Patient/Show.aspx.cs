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
namespace YCF_Server.Web.Patient
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
					int PID=(Convert.ToInt32(strid));
					ShowInfo(PID);
				}
			}
		}
		
	private void ShowInfo(int PID)
	{
		YCF_Server.BLL.Patient bll=new YCF_Server.BLL.Patient();
		YCF_Server.Model.Patient model=bll.GetModel(PID);
		this.lblPID.Text=model.PID.ToString();
		this.lblBailorID.Text=model.BailorID.ToString();
		this.lblRelationship.Text=model.Relationship;
		this.lblCheckInTime.Text=model.CheckInTime.ToString();
		this.lblOutTime.Text=model.OutTime.ToString();
		this.lblEmergencyContact.Text=model.EmergencyContact;
		this.lblECTEL.Text=model.ECTEL;
		this.lblBloodType.Text=model.BloodType;
		this.lblHeight.Text=model.Height;
		this.lblUID.Text=model.UID.ToString();

	}


    }
}
