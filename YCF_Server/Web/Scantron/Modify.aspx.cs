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
namespace YCF_Server.Web.Scantron
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int SID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(SID);
				}
			}
		}
			
	private void ShowInfo(int SID)
	{
		YCF_Server.BLL.Scantron bll=new YCF_Server.BLL.Scantron();
		YCF_Server.Model.Scantron model=bll.GetModel(SID);
		this.lblSID.Text=model.SID.ToString();
		this.txtAID.Text=model.AID.ToString();
		this.txtEID.Text=model.EID.ToString();
		this.txtOID.Text=model.OID.ToString();
		this.txtSingleScore.Text=model.SingleScore.ToString();
		this.txtSGroup.Text=model.SGroup.ToString();
		this.txtONumber.Text=model.ONumber.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtAID.Text))
			{
				strErr+="评估记录表ID-外键格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtEID.Text))
			{
				strErr+="考题ID-外键格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtOID.Text))
			{
				strErr+="考题选项ID-外键格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtSingleScore.Text))
			{
				strErr+="单项评分格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtSGroup.Text))
			{
				strErr+="分组（1,2,3）格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtONumber.Text))
			{
				strErr+="具体选项编号格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int SID=int.Parse(this.lblSID.Text);
			int AID=int.Parse(this.txtAID.Text);
			int EID=int.Parse(this.txtEID.Text);
			int OID=int.Parse(this.txtOID.Text);
			int SingleScore=int.Parse(this.txtSingleScore.Text);
			int SGroup=int.Parse(this.txtSGroup.Text);
			int ONumber=int.Parse(this.txtONumber.Text);


			YCF_Server.Model.Scantron model=new YCF_Server.Model.Scantron();
			model.SID=SID;
			model.AID=AID;
			model.EID=EID;
			model.OID=OID;
			model.SingleScore=SingleScore;
			model.SGroup=SGroup;
			model.ONumber=ONumber;

			YCF_Server.BLL.Scantron bll=new YCF_Server.BLL.Scantron();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
