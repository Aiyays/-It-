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
namespace YCF_Server.Web.ServiceNote
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
					int NID=(Convert.ToInt32(strid));
					ShowInfo(NID);
				}
			}
		}
		
	private void ShowInfo(int NID)
	{
		YCF_Server.BLL.ServiceNote bll=new YCF_Server.BLL.ServiceNote();
		YCF_Server.Model.ServiceNote model=bll.GetModel(NID);
		this.lblNID.Text=model.NID.ToString();
		this.lblNote.Text=model.Note;
		this.lblPicture.Text=model.Picture;
		this.lblNTime.Text=model.NTime.ToString();
		this.lblEID.Text=model.EID.ToString();
		this.lblPID.Text=model.PID.ToString();

	}


    }
}
