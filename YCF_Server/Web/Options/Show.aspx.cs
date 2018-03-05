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
namespace YCF_Server.Web.Options
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
					int OID=(Convert.ToInt32(strid));
					ShowInfo(OID);
				}
			}
		}
		
	private void ShowInfo(int OID)
	{
		YCF_Server.BLL.Options bll=new YCF_Server.BLL.Options();
		YCF_Server.Model.Options model=bll.GetModel(OID);
		this.lblOID.Text=model.OID.ToString();
		this.lblEID.Text=model.EID.ToString();
		this.lblContent.Text=model.Content;
		this.lblScore.Text=model.Score.ToString();
		this.lblOGroup.Text=model.OGroup.ToString();
		this.lblNumber.Text=model.Number.ToString();
		this.lblLabel.Text=model.Label;

	}


    }
}
