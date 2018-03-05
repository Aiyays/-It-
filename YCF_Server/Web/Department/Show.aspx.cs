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
namespace YCF_Server.Web.Department
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
					int DID=(Convert.ToInt32(strid));
					ShowInfo(DID);
				}
			}
		}
		
	private void ShowInfo(int DID)
	{
		YCF_Server.BLL.Department bll=new YCF_Server.BLL.Department();
		YCF_Server.Model.Department model=bll.GetModel(DID);
		this.lblDID.Text=model.DID.ToString();
		this.lblEdepartmentName.Text=model.EdepartmentName;
		this.lblDNumber.Text=model.DNumber;

	}


    }
}
