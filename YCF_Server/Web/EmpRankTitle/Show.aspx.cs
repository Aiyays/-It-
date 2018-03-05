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
namespace YCF_Server.Web.EmpRankTitle
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
					int ERTID=(Convert.ToInt32(strid));
					ShowInfo(ERTID);
				}
			}
		}
		
	private void ShowInfo(int ERTID)
	{
		YCF_Server.BLL.EmpRankTitle bll=new YCF_Server.BLL.EmpRankTitle();
		YCF_Server.Model.EmpRankTitle model=bll.GetModel(ERTID);
		this.lblERTID.Text=model.ERTID.ToString();
		this.lblEID.Text=model.EID.ToString();
		this.lblTID.Text=model.TID.ToString();
		this.lblRTID.Text=model.RTID.ToString();

	}


    }
}
