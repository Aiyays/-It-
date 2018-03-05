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
namespace YCF_Server.Web.PersonalService
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
				strErr+="外键-病人格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtGID.Text))
			{
				strErr+="外键-组格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtSID.Text))
			{
				strErr+="外键-服务格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtPTime.Text))
			{
				strErr+="时间格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int PID=int.Parse(this.txtPID.Text);
			int GID=int.Parse(this.txtGID.Text);
			int SID=int.Parse(this.txtSID.Text);
			DateTime PTime=DateTime.Parse(this.txtPTime.Text);

			YCF_Server.Model.PersonalService model=new YCF_Server.Model.PersonalService();
			model.PID=PID;
			model.GID=GID;
			model.SID=SID;
			model.PTime=PTime;

			YCF_Server.BLL.PersonalService bll=new YCF_Server.BLL.PersonalService();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
