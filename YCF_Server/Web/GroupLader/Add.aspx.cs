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
namespace YCF_Server.Web.GroupLader
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
				strErr+="组名不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtUID.Text))
			{
				strErr+="（外键）组长的个人信息格式错误！\\n";	
			}
			if(this.txtRemak.Text.Trim().Length==0)
			{
				strErr+="描述不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string Name=this.txtName.Text;
			int UID=int.Parse(this.txtUID.Text);
			string Remak=this.txtRemak.Text;

			YCF_Server.Model.GroupLader model=new YCF_Server.Model.GroupLader();
			model.Name=Name;
			model.UID=UID;
			model.Remak=Remak;

			YCF_Server.BLL.GroupLader bll=new YCF_Server.BLL.GroupLader();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
