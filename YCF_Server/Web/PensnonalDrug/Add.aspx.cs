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
namespace YCF_Server.Web.PensnonalDrug
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtDTime.Text))
			{
				strErr+="时间格式错误！\\n";	
			}
			if(this.txtFrequency.Text.Trim().Length==0)
			{
				strErr+="频次不能为空！\\n";	
			}
			if(this.txtDose.Text.Trim().Length==0)
			{
				strErr+="剂量不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtDID.Text))
			{
				strErr+="外键-药品格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtEID.Text))
			{
				strErr+="外键-员工格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtPID.Text))
			{
				strErr+="外键-病人格式错误！\\n";	
			}
			if(this.txtIMG.Text.Trim().Length==0)
			{
				strErr+="图片不能为空！\\n";	
			}
			if(this.txtRemark.Text.Trim().Length==0)
			{
				strErr+="Remark不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			DateTime DTime=DateTime.Parse(this.txtDTime.Text);
			string Frequency=this.txtFrequency.Text;
			string Dose=this.txtDose.Text;
			int DID=int.Parse(this.txtDID.Text);
			int EID=int.Parse(this.txtEID.Text);
			int PID=int.Parse(this.txtPID.Text);
			string IMG=this.txtIMG.Text;
			string Remark=this.txtRemark.Text;

			YCF_Server.Model.PensnonalDrug model=new YCF_Server.Model.PensnonalDrug();
			model.DTime=DTime;
			model.Frequency=Frequency;
			model.Dose=Dose;
			model.DID=DID;
			model.EID=EID;
			model.PID=PID;
			model.IMG=IMG;
			model.Remark=Remark;

			YCF_Server.BLL.PensnonalDrug bll=new YCF_Server.BLL.PensnonalDrug();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
