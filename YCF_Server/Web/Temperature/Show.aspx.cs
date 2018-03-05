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
namespace YCF_Server.Web.Temperature
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
					int TID=(Convert.ToInt32(strid));
					ShowInfo(TID);
				}
			}
		}
		
	private void ShowInfo(int TID)
	{
		YCF_Server.BLL.Temperature bll=new YCF_Server.BLL.Temperature();
		YCF_Server.Model.Temperature model=bll.GetModel(TID);
		this.lblTID.Text=model.TID.ToString();
		this.lblMeasureDateTime.Text=model.MeasureDateTime.ToString();
		this.lblTemperature.Text=model.Temperature;
		this.lblPID.Text=model.PID.ToString();

	}


    }
}
