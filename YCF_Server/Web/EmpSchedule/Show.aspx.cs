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
namespace YCF_Server.Web.EmpSchedule
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
					int ESID=(Convert.ToInt32(strid));
					ShowInfo(ESID);
				}
			}
		}
		
	private void ShowInfo(int ESID)
	{
		YCF_Server.BLL.EmpSchedule bll=new YCF_Server.BLL.EmpSchedule();
		YCF_Server.Model.EmpSchedule model=bll.GetModel(ESID);
		this.lblESID.Text=model.ESID.ToString();
		this.lblEID.Text=model.EID.ToString();
		this.lblSID.Text=model.SID.ToString();
		this.lblDataTime.Text=model.DataTime;

	}


    }
}
