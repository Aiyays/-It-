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
namespace YCF_Server.Web.Weight
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsDateTime(txtWTime.Text))
			{
				strErr+="时间格式错误！\\n";	
			}
			if(this.txtWeight.Text.Trim().Length==0)
			{
				strErr+="体重不能为空！\\n";	
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
			DateTime WTime=DateTime.Parse(this.txtWTime.Text);
			string Weight=this.txtWeight.Text;
			int PID=int.Parse(this.txtPID.Text);

			YCF_Server.Model.Weight model=new YCF_Server.Model.Weight();
			model.WTime=WTime;
			model.Weight=Weight;
			model.PID=PID;

			YCF_Server.BLL.Weight bll=new YCF_Server.BLL.Weight();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
