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
namespace YCF_Server.Web.TransferClass
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtA_OID.Text))
			{
				strErr+="申请调代班格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtR_OID.Text))
			{
				strErr+="接收调代班格式错误！\\n";	
			}
			if(this.txtReason.Text.Trim().Length==0)
			{
				strErr+="申请调代班的原因不能为空！\\n";	
			}
			if(this.txtTransferTime.Text.Trim().Length==0)
			{
				strErr+="请求调代班的时间不能为空！\\n";	
			}
			if(this.txtNowTime.Text.Trim().Length==0)
			{
				strErr+="确认通过时间不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int A_OID=int.Parse(this.txtA_OID.Text);
			int R_OID=int.Parse(this.txtR_OID.Text);
			string Reason=this.txtReason.Text;
			string TransferTime=this.txtTransferTime.Text;
			string NowTime=this.txtNowTime.Text;

			YCF_Server.Model.TransferClass model=new YCF_Server.Model.TransferClass();
			model.A_OID=A_OID;
			model.R_OID=R_OID;
			model.Reason=Reason;
			model.TransferTime=TransferTime;
			model.NowTime=NowTime;

			YCF_Server.BLL.TransferClass bll=new YCF_Server.BLL.TransferClass();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
