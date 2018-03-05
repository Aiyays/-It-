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
namespace YCF_Server.Web.ExaminationQuestion
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int EID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(EID);
				}
			}
		}
			
	private void ShowInfo(int EID)
	{
		YCF_Server.BLL.ExaminationQuestion bll=new YCF_Server.BLL.ExaminationQuestion();
		YCF_Server.Model.ExaminationQuestion model=bll.GetModel(EID);
		this.lblEID.Text=model.EID.ToString();
		this.txtQuestion.Text=model.Question;
		this.txtEGroup.Text=model.EGroup.ToString();
		this.txtEType.Text=model.EType;
		this.txtIsRadio.Text=model.IsRadio.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtQuestion.Text.Trim().Length==0)
			{
				strErr+="考题题目不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtEGroup.Text))
			{
				strErr+="考题分组（1,2,3）格式错误！\\n";	
			}
			if(this.txtEType.Text.Trim().Length==0)
			{
				strErr+="题目类型（BADL、IADL、不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtIsRadio.Text))
			{
				strErr+="是否单选题（0是,1否）格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int EID=int.Parse(this.lblEID.Text);
			string Question=this.txtQuestion.Text;
			int EGroup=int.Parse(this.txtEGroup.Text);
			string EType=this.txtEType.Text;
			int IsRadio=int.Parse(this.txtIsRadio.Text);


			YCF_Server.Model.ExaminationQuestion model=new YCF_Server.Model.ExaminationQuestion();
			model.EID=EID;
			model.Question=Question;
			model.EGroup=EGroup;
			model.EType=EType;
			model.IsRadio=IsRadio;

			YCF_Server.BLL.ExaminationQuestion bll=new YCF_Server.BLL.ExaminationQuestion();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
