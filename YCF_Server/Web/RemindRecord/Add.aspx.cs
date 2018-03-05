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
namespace YCF_Server.Web.RemindRecord
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtPID.Text))
			{
				strErr+="病人格式错误！\\n";	
			}
			if(this.txtRcontent.Text.Trim().Length==0)
			{
				strErr+="内容不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtRemindTime.Text))
			{
				strErr+="时间格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int PID=int.Parse(this.txtPID.Text);
			string Rcontent=this.txtRcontent.Text;
			DateTime RemindTime=DateTime.Parse(this.txtRemindTime.Text);

			YCF_Server.Model.RemindRecord model=new YCF_Server.Model.RemindRecord();
			model.PID=PID;
			model.Rcontent=Rcontent;
			model.RemindTime=RemindTime;

			YCF_Server.BLL.RemindRecord bll=new YCF_Server.BLL.RemindRecord();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
