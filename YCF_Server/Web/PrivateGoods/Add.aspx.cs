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
namespace YCF_Server.Web.PrivateGoods
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="名称不能为空！\\n";	
			}
			if(this.txtNumber.Text.Trim().Length==0)
			{
				strErr+="编号不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtCount.Text))
			{
				strErr+="数量格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtParID.Text))
			{
				strErr+="外键-病人格式错误！\\n";	
			}
			if(this.txtRemark.Text.Trim().Length==0)
			{
				strErr+="备注不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string Name=this.txtName.Text;
			string Number=this.txtNumber.Text;
			int Count=int.Parse(this.txtCount.Text);
			int ParID=int.Parse(this.txtParID.Text);
			string Remark=this.txtRemark.Text;

			YCF_Server.Model.PrivateGoods model=new YCF_Server.Model.PrivateGoods();
			model.Name=Name;
			model.Number=Number;
			model.Count=Count;
			model.ParID=ParID;
			model.Remark=Remark;

			YCF_Server.BLL.PrivateGoods bll=new YCF_Server.BLL.PrivateGoods();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
