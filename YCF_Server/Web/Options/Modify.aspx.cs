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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int OID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(OID);
				}
			}
		}
			
	private void ShowInfo(int OID)
	{
		YCF_Server.BLL.Options bll=new YCF_Server.BLL.Options();
		YCF_Server.Model.Options model=bll.GetModel(OID);
		this.lblOID.Text=model.OID.ToString();
		this.txtEID.Text=model.EID.ToString();
		this.txtContent.Text=model.Content;
		this.txtScore.Text=model.Score.ToString();
		this.txtOGroup.Text=model.OGroup.ToString();
		this.txtNumber.Text=model.Number.ToString();
		this.txtLabel.Text=model.Label;

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			int OID=int.Parse(this.lblOID.Text);
			int EID=int.Parse(this.txtEID.Text);
			string Content=this.txtContent.Text;
			int Score=int.Parse(this.txtScore.Text);
			int OGroup=int.Parse(this.txtOGroup.Text);
			int Number=int.Parse(this.txtNumber.Text);
			string Label=this.txtLabel.Text;


			YCF_Server.Model.Options model=new YCF_Server.Model.Options();
			model.OID=OID;
			model.EID=EID;
			model.Content=Content;
			model.Score=Score;
			model.OGroup=OGroup;
			model.Number=Number;
			model.Label=Label;

			YCF_Server.BLL.Options bll=new YCF_Server.BLL.Options();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
