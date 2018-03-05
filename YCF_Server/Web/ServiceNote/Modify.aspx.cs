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
namespace YCF_Server.Web.ServiceNote
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int NID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(NID);
				}
			}
		}
			
	private void ShowInfo(int NID)
	{
		YCF_Server.BLL.ServiceNote bll=new YCF_Server.BLL.ServiceNote();
		YCF_Server.Model.ServiceNote model=bll.GetModel(NID);
		this.lblNID.Text=model.NID.ToString();
		this.txtNote.Text=model.Note;
		this.txtPicture.Text=model.Picture;
		this.txtNTime.Text=model.NTime.ToString();
		this.txtEID.Text=model.EID.ToString();
		this.txtPID.Text=model.PID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtNote.Text.Trim().Length==0)
			{
				strErr+="笔记不能为空！\\n";	
			}
			if(this.txtPicture.Text.Trim().Length==0)
			{
				strErr+="图片不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtNTime.Text))
			{
				strErr+="时间格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtEID.Text))
			{
				strErr+="外键-员工格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtPID.Text))
			{
				strErr+="外键-病人格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int NID=int.Parse(this.lblNID.Text);
			string Note=this.txtNote.Text;
			string Picture=this.txtPicture.Text;
			DateTime NTime=DateTime.Parse(this.txtNTime.Text);
			int EID=int.Parse(this.txtEID.Text);
			int PID=int.Parse(this.txtPID.Text);


			YCF_Server.Model.ServiceNote model=new YCF_Server.Model.ServiceNote();
			model.NID=NID;
			model.Note=Note;
			model.Picture=Picture;
			model.NTime=NTime;
			model.EID=EID;
			model.PID=PID;

			YCF_Server.BLL.ServiceNote bll=new YCF_Server.BLL.ServiceNote();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
