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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace YCF_Server.Web.AssessRecord
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtUName.Text.Trim().Length==0)
			{
				strErr+="姓名不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtSex.Text))
			{
				strErr+="性别格式错误！\\n";	
			}
			if(this.txtFN.Text.Trim().Length==0)
			{
				strErr+="档案号不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtBirthDate.Text))
			{
				strErr+="生日格式错误！\\n";	
			}
			if(this.txtTheBed.Text.Trim().Length==0)
			{
				strErr+="病床号不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtValuationDate.Text))
			{
				strErr+="评估日期格式错误！\\n";	
			}
			if(this.txtEvaluator.Text.Trim().Length==0)
			{
				strErr+="评估员不能为空！\\n";	
			}
			if(this.txtRegistrar.Text.Trim().Length==0)
			{
				strErr+="登记员不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtRecordData.Text))
			{
				strErr+="登记日期格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtBADL.Text))
			{
				strErr+="BADL指数格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtLADL.Text))
			{
				strErr+="LADL指数格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtLSP.Text))
			{
				strErr+="LSP指数格式错误！\\n";	
			}
			if(this.txtSysEvaluation.Text.Trim().Length==0)
			{
				strErr+="系统评估不能为空！\\n";	
			}
			if(this.txtAssessment.Text.Trim().Length==0)
			{
				strErr+="综合评估（评估人员进行评估）不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtUID.Text))
			{
				strErr+="用户ID（被评估人员ID）-外格式错误！\\n";	
			}
			if(this.txtComment.Text.Trim().Length==0)
			{
				strErr+="护理等级分配备注不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string UName=this.txtUName.Text;
			int Sex=int.Parse(this.txtSex.Text);
			string FN=this.txtFN.Text;
			DateTime BirthDate=DateTime.Parse(this.txtBirthDate.Text);
			string TheBed=this.txtTheBed.Text;
			DateTime ValuationDate=DateTime.Parse(this.txtValuationDate.Text);
			string Evaluator=this.txtEvaluator.Text;
			string Registrar=this.txtRegistrar.Text;
			DateTime RecordData=DateTime.Parse(this.txtRecordData.Text);
			int BADL=int.Parse(this.txtBADL.Text);
			int LADL=int.Parse(this.txtLADL.Text);
			int LSP=int.Parse(this.txtLSP.Text);
			string SysEvaluation=this.txtSysEvaluation.Text;
			string Assessment=this.txtAssessment.Text;
			int UID=int.Parse(this.txtUID.Text);
			string Comment=this.txtComment.Text;

			YCF_Server.Model.AssessRecord model=new YCF_Server.Model.AssessRecord();
			model.UName=UName;
			model.Sex=Sex;
			model.FN=FN;
			model.BirthDate=BirthDate;
			model.TheBed=TheBed;
			model.ValuationDate=ValuationDate;
			model.Evaluator=Evaluator;
			model.Registrar=Registrar;
			model.RecordData=RecordData;
			model.BADL=BADL;
			model.LADL=LADL;
			model.LSP=LSP;
			model.SysEvaluation=SysEvaluation;
			model.Assessment=Assessment;
			model.UID=UID;
			model.Comment=Comment;

			YCF_Server.BLL.AssessRecord bll=new YCF_Server.BLL.AssessRecord();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
