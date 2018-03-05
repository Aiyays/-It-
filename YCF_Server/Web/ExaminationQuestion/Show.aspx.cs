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
namespace YCF_Server.Web.ExaminationQuestion
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
					int EID=(Convert.ToInt32(strid));
					ShowInfo(EID);
				}
			}
		}
		
	private void ShowInfo(int EID)
	{
		YCF_Server.BLL.ExaminationQuestion bll=new YCF_Server.BLL.ExaminationQuestion();
		YCF_Server.Model.ExaminationQuestion model=bll.GetModel(EID);
		this.lblEID.Text=model.EID.ToString();
		this.lblQuestion.Text=model.Question;
		this.lblEGroup.Text=model.EGroup.ToString();
		this.lblEType.Text=model.EType;
		this.lblIsRadio.Text=model.IsRadio.ToString();

	}


    }
}
