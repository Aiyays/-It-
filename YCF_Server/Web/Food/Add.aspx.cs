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
namespace YCF_Server.Web.Food
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
				strErr+="菜品名称不能为空！\\n";	
			}
			if(this.txtPrice.Text.Trim().Length==0)
			{
				strErr+="价格不能为空！\\n";	
			}
			if(this.txtUnit.Text.Trim().Length==0)
			{
				strErr+="单位不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtQuantity.Text))
			{
				strErr+="数量格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtTID.Text))
			{
				strErr+="外键-菜品类型格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string Name=this.txtName.Text;
			string Price=this.txtPrice.Text;
			string Unit=this.txtUnit.Text;
			int Quantity=int.Parse(this.txtQuantity.Text);
			int TID=int.Parse(this.txtTID.Text);

			YCF_Server.Model.Food model=new YCF_Server.Model.Food();
			model.Name=Name;
			model.Price=Price;
			model.Unit=Unit;
			model.Quantity=Quantity;
			model.TID=TID;

			YCF_Server.BLL.Food bll=new YCF_Server.BLL.Food();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
