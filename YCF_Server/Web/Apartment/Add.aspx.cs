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
namespace YCF_Server.Web.Apartment
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
				strErr+="房间名不能为空！\\n";	
			}
			if(this.txtNumber.Text.Trim().Length==0)
			{
				strErr+="房间号不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtAreaID.Text))
			{
				strErr+="外键-房间区域格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtTID.Text))
			{
				strErr+="外键-房间类型格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string Name=this.txtName.Text;
			string Number=this.txtNumber.Text;
			int AreaID=int.Parse(this.txtAreaID.Text);
			int TID=int.Parse(this.txtTID.Text);

			YCF_Server.Model.Apartment model=new YCF_Server.Model.Apartment();
			model.Name=Name;
			model.Number=Number;
			model.AreaID=AreaID;
			model.TID=TID;

			YCF_Server.BLL.Apartment bll=new YCF_Server.BLL.Apartment();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
