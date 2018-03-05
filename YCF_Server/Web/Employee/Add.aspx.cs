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
namespace YCF_Server.Web.Employee
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtUID.Text))
			{
				strErr+="(外键 关联)云服务 User格式错误！\\n";	
			}
			if(this.txtNateTime.Text.Trim().Length==0)
			{
				strErr+="入职时间不能为空！\\n";	
			}
			if(this.txtDaparturTime.Text.Trim().Length==0)
			{
				strErr+="离职时间不能为空！\\n";	
			}
			if(this.txtState.Text.Trim().Length==0)
			{
				strErr+="目前装填 是否请假不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtGID.Text))
			{
				strErr+="（外键）属于哪个组格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int UID=int.Parse(this.txtUID.Text);
			string NateTime=this.txtNateTime.Text;
			string DaparturTime=this.txtDaparturTime.Text;
			string State=this.txtState.Text;
			int GID=int.Parse(this.txtGID.Text);

			YCF_Server.Model.Employee model=new YCF_Server.Model.Employee();
			model.UID=UID;
			model.NateTime=NateTime;
			model.DaparturTime=DaparturTime;
			model.State=State;
			model.GID=GID;

			YCF_Server.BLL.Employee bll=new YCF_Server.BLL.Employee();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
