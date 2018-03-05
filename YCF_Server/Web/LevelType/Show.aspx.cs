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
namespace YCF_Server.Web.LevelType
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
					int LTID=(Convert.ToInt32(strid));
					ShowInfo(LTID);
				}
			}
		}
		
	private void ShowInfo(int LTID)
	{
		YCF_Server.BLL.LevelType bll=new YCF_Server.BLL.LevelType();
		YCF_Server.Model.LevelType model=bll.GetModel(LTID);
		this.lblLTID.Text=model.LTID.ToString();
		this.lblLID.Text=model.LID.ToString();
		this.lblSTID.Text=model.STID.ToString();

	}


    }
}
