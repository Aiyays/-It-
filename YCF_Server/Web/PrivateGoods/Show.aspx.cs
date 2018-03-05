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
namespace YCF_Server.Web.PrivateGoods
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
		YCF_Server.BLL.PrivateGoods bll=new YCF_Server.BLL.PrivateGoods();
		YCF_Server.Model.PrivateGoods model=bll.GetModel(PID);
		this.lblPID.Text=model.PID.ToString();
		this.lblName.Text=model.Name;
		this.lblNumber.Text=model.Number;
		this.lblCount.Text=model.Count.ToString();
		this.lblParID.Text=model.ParID.ToString();
		this.lblRemark.Text=model.Remark;

	}


    }
}
