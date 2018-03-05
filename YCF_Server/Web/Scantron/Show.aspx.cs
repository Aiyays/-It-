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
namespace YCF_Server.Web.Scantron
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
					int SID=(Convert.ToInt32(strid));
					ShowInfo(SID);
				}
			}
		}
		
	private void ShowInfo(int SID)
	{
		YCF_Server.BLL.Scantron bll=new YCF_Server.BLL.Scantron();
		YCF_Server.Model.Scantron model=bll.GetModel(SID);
		this.lblSID.Text=model.SID.ToString();
		this.lblAID.Text=model.AID.ToString();
		this.lblEID.Text=model.EID.ToString();
		this.lblOID.Text=model.OID.ToString();
		this.lblSingleScore.Text=model.SingleScore.ToString();
		this.lblSGroup.Text=model.SGroup.ToString();
		this.lblONumber.Text=model.ONumber.ToString();

	}


    }
}
