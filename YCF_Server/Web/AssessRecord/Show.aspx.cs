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
namespace YCF_Server.Web.AssessRecord
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
					int AID=(Convert.ToInt32(strid));
					ShowInfo(AID);
				}
			}
		}
		
	private void ShowInfo(int AID)
	{
		YCF_Server.BLL.AssessRecord bll=new YCF_Server.BLL.AssessRecord();
		YCF_Server.Model.AssessRecord model=bll.GetModel(AID);
		this.lblAID.Text=model.AID.ToString();
		this.lblUName.Text=model.UName;
		this.lblSex.Text=model.Sex.ToString();
		this.lblFN.Text=model.FN;
		this.lblBirthDate.Text=model.BirthDate.ToString();
		this.lblTheBed.Text=model.TheBed;
		this.lblValuationDate.Text=model.ValuationDate.ToString();
		this.lblEvaluator.Text=model.Evaluator;
		this.lblRegistrar.Text=model.Registrar;
		this.lblRecordData.Text=model.RecordData.ToString();
		this.lblBADL.Text=model.BADL.ToString();
		this.lblLADL.Text=model.LADL.ToString();
		this.lblLSP.Text=model.LSP.ToString();
		this.lblSysEvaluation.Text=model.SysEvaluation;
		this.lblAssessment.Text=model.Assessment;
		this.lblUID.Text=model.UID.ToString();
		this.lblComment.Text=model.Comment;

	}


    }
}
