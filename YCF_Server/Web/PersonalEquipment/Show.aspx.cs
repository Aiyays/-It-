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
namespace YCF_Server.Web.PersonalEquipment
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
					int PEID=(Convert.ToInt32(strid));
					ShowInfo(PEID);
				}
			}
		}
		
	private void ShowInfo(int PEID)
	{
		YCF_Server.BLL.PersonalEquipment bll=new YCF_Server.BLL.PersonalEquipment();
		YCF_Server.Model.PersonalEquipment model=bll.GetModel(PEID);
		this.lblPEID.Text=model.PEID.ToString();
		this.lblEID.Text=model.EID.ToString();
		this.lblPID.Text=model.PID.ToString();
		this.lblEmpID.Text=model.EmpID.ToString();
		this.lblGID.Text=model.GID.ToString();
		this.lblPTime.Text=model.PTime.ToString();
		this.lblNumber.Text=model.Number.ToString();

	}


    }
}
