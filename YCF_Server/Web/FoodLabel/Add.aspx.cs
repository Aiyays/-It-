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
namespace YCF_Server.Web.FoodLabel
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtFID.Text))
			{
				strErr+="外键-菜品格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtLID.Text))
			{
				strErr+="外键-标签格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int FID=int.Parse(this.txtFID.Text);
			int LID=int.Parse(this.txtLID.Text);

			YCF_Server.Model.FoodLabel model=new YCF_Server.Model.FoodLabel();
			model.FID=FID;
			model.LID=LID;

			YCF_Server.BLL.FoodLabel bll=new YCF_Server.BLL.FoodLabel();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
