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
namespace YCF_Server.Web.ServiceNote
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtNote.Text.Trim().Length==0)
			{
				strErr+="笔记不能为空！\\n";	
			}
			if(this.txtPicture.Text.Trim().Length==0)
			{
				strErr+="图片不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtNTime.Text))
			{
				strErr+="时间格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtEID.Text))
			{
				strErr+="外键-员工格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtPID.Text))
			{
				strErr+="外键-病人格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string Note=this.txtNote.Text;
			string Picture=this.txtPicture.Text;
			DateTime NTime=DateTime.Parse(this.txtNTime.Text);
			int EID=int.Parse(this.txtEID.Text);
			int PID=int.Parse(this.txtPID.Text);

			YCF_Server.Model.ServiceNote model=new YCF_Server.Model.ServiceNote();
			model.Note=Note;
			model.Picture=Picture;
			model.NTime=NTime;
			model.EID=EID;
			model.PID=PID;

			YCF_Server.BLL.ServiceNote bll=new YCF_Server.BLL.ServiceNote();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
