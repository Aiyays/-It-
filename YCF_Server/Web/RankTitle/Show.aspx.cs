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
namespace YCF_Server.Web.RankTitle
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
					int RTID=(Convert.ToInt32(strid));
					ShowInfo(RTID);
				}
			}
		}
		
	private void ShowInfo(int RTID)
	{
		YCF_Server.BLL.RankTitle bll=new YCF_Server.BLL.RankTitle();
		YCF_Server.Model.RankTitle model=bll.GetModel(RTID);
		this.lblRTID.Text=model.RTID.ToString();
		this.lblNub.Text=model.Nub.ToString();

	}


    }
}
