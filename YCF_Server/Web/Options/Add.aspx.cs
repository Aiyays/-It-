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
namespace YCF_Server.Web.Options
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
				strErr+="考题ID格式错误！\\n";	
			}
			if(this.txtContent.Text.Trim().Length==0)
			{
				strErr+="选项内容不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtScore.Text))
			{
				strErr+="ADL评分格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtOGroup.Text))
			{
				strErr+="分组（1,2,3）格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtNumber.Text))
			{
				strErr+="选项编号格式错误！\\n";	
			}
			if(this.txtLabel.Text.Trim().Length==0)
			{
				strErr+="标签-对应护理标签（联想补充不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int EID=int.Parse(this.txtEID.Text);
			string Content=this.txtContent.Text;
			int Score=int.Parse(this.txtScore.Text);
			int OGroup=int.Parse(this.txtOGroup.Text);
			int Number=int.Parse(this.txtNumber.Text);
			string Label=this.txtLabel.Text;

			YCF_Server.Model.Options model=new YCF_Server.Model.Options();
			model.EID=EID;
			model.Content=Content;
			model.Score=Score;
			model.OGroup=OGroup;
			model.Number=Number;
			model.Label=Label;

			YCF_Server.BLL.Options bll=new YCF_Server.BLL.Options();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
