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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int FID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(FID);
				}
			}
		}
			
	private void ShowInfo(int FID)
	{
		YCF_Server.BLL.Food bll=new YCF_Server.BLL.Food();
		YCF_Server.Model.Food model=bll.GetModel(FID);
		this.lblFID.Text=model.FID.ToString();
		this.txtName.Text=model.Name;
		this.txtPrice.Text=model.Price;
		this.txtUnit.Text=model.Unit;
		this.txtQuantity.Text=model.Quantity.ToString();
		this.txtTID.Text=model.TID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			int FID=int.Parse(this.lblFID.Text);
			string Name=this.txtName.Text;
			string Price=this.txtPrice.Text;
			string Unit=this.txtUnit.Text;
			int Quantity=int.Parse(this.txtQuantity.Text);
			int TID=int.Parse(this.txtTID.Text);


			YCF_Server.Model.Food model=new YCF_Server.Model.Food();
			model.FID=FID;
			model.Name=Name;
			model.Price=Price;
			model.Unit=Unit;
			model.Quantity=Quantity;
			model.TID=TID;

			YCF_Server.BLL.Food bll=new YCF_Server.BLL.Food();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
