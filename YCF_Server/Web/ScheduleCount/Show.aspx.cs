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
namespace YCF_Server.Web.ScheduleCount
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
					int SCID=(Convert.ToInt32(strid));
					ShowInfo(SCID);
				}
			}
		}
		
	private void ShowInfo(int SCID)
	{
		YCF_Server.BLL.ScheduleCount bll=new YCF_Server.BLL.ScheduleCount();
		YCF_Server.Model.ScheduleCount model=bll.GetModel(SCID);
		this.lblSCID.Text=model.SCID.ToString();
		this.lblName.Text=model.Name;
		this.lblStartTime.Text=model.StartTime;
		this.lblEndTime.Text=model.EndTime;

	}


    }
}
