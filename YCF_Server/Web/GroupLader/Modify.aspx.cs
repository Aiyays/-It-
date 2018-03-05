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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int GID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(GID);
				}
			}
		}
			
	private void ShowInfo(int GID)
	{
		YCF_Server.BLL.GroupLader bll=new YCF_Server.BLL.GroupLader();
		YCF_Server.Model.GroupLader model=bll.GetModel(GID);
		this.lblGID.Text=model.GID.ToString();
		this.txtName.Text=model.Name;
		this.txtUID.Text=model.UID.ToString();
		this.txtRemak.Text=model.Remak;

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			int GID=int.Parse(this.lblGID.Text);
			string Name=this.txtName.Text;
			int UID=int.Parse(this.txtUID.Text);
			string Remak=this.txtRemak.Text;


			YCF_Server.Model.GroupLader model=new YCF_Server.Model.GroupLader();
			model.GID=GID;
			model.Name=Name;
			model.UID=UID;
			model.Remak=Remak;

			YCF_Server.BLL.GroupLader bll=new YCF_Server.BLL.GroupLader();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
