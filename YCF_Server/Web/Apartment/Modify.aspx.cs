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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int AID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(AID);
				}
			}
		}
			
	private void ShowInfo(int AID)
	{
		YCF_Server.BLL.Apartment bll=new YCF_Server.BLL.Apartment();
		YCF_Server.Model.Apartment model=bll.GetModel(AID);
		this.lblAID.Text=model.AID.ToString();
		this.txtName.Text=model.Name;
		this.txtNumber.Text=model.Number;
		this.txtAreaID.Text=model.AreaID.ToString();
		this.txtTID.Text=model.TID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			int AID=int.Parse(this.lblAID.Text);
			string Name=this.txtName.Text;
			string Number=this.txtNumber.Text;
			int AreaID=int.Parse(this.txtAreaID.Text);
			int TID=int.Parse(this.txtTID.Text);


			YCF_Server.Model.Apartment model=new YCF_Server.Model.Apartment();
			model.AID=AID;
			model.Name=Name;
			model.Number=Number;
			model.AreaID=AreaID;
			model.TID=TID;

			YCF_Server.BLL.Apartment bll=new YCF_Server.BLL.Apartment();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
