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
namespace YCF_Server.Web.PersonalEquipment
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtEID.Text))
			{
				strErr+="外键-设备格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtPID.Text))
			{
				strErr+="外键-病人格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtEmpID.Text))
			{
				strErr+="外键-员工格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtGID.Text))
			{
				strErr+="外键-组格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtPTime.Text))
			{
				strErr+="时间格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtNumber.Text))
			{
				strErr+="数量格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int EID=int.Parse(this.txtEID.Text);
			int PID=int.Parse(this.txtPID.Text);
			int EmpID=int.Parse(this.txtEmpID.Text);
			int GID=int.Parse(this.txtGID.Text);
			DateTime PTime=DateTime.Parse(this.txtPTime.Text);
			int Number=int.Parse(this.txtNumber.Text);

			YCF_Server.Model.PersonalEquipment model=new YCF_Server.Model.PersonalEquipment();
			model.EID=EID;
			model.PID=PID;
			model.EmpID=EmpID;
			model.GID=GID;
			model.PTime=PTime;
			model.Number=Number;

			YCF_Server.BLL.PersonalEquipment bll=new YCF_Server.BLL.PersonalEquipment();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
