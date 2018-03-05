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
namespace YCF_Server.Web.PostureHabit
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int PHID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(PHID);
				}
			}
		}
			
	private void ShowInfo(int PHID)
	{
		YCF_Server.BLL.PostureHabit bll=new YCF_Server.BLL.PostureHabit();
		YCF_Server.Model.PostureHabit model=bll.GetModel(PHID);
		this.lblPHID.Text=model.PHID.ToString();
		this.txtHeight.Text=model.Height.ToString();
		this.txtMedicine.Text=model.Medicine.ToString();
		this.txtBack.Text=model.Back.ToString();
		this.txtHead.Text=model.Head.ToString();
		this.txtWaist.Text=model.Waist.ToString();
		this.txtLeg.Text=model.Leg.ToString();
		this.txtUID.Text=model.UID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtHeight.Text))
			{
				strErr+="高格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtMedicine.Text))
			{
				strErr+="医学格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtBack.Text))
			{
				strErr+="背格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtHead.Text))
			{
				strErr+="头格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtWaist.Text))
			{
				strErr+="腰格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtLeg.Text))
			{
				strErr+="腿格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtUID.Text))
			{
				strErr+="外键-个人格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int PHID=int.Parse(this.lblPHID.Text);
			int Height=int.Parse(this.txtHeight.Text);
			int Medicine=int.Parse(this.txtMedicine.Text);
			int Back=int.Parse(this.txtBack.Text);
			int Head=int.Parse(this.txtHead.Text);
			int Waist=int.Parse(this.txtWaist.Text);
			int Leg=int.Parse(this.txtLeg.Text);
			int UID=int.Parse(this.txtUID.Text);


			YCF_Server.Model.PostureHabit model=new YCF_Server.Model.PostureHabit();
			model.PHID=PHID;
			model.Height=Height;
			model.Medicine=Medicine;
			model.Back=Back;
			model.Head=Head;
			model.Waist=Waist;
			model.Leg=Leg;
			model.UID=UID;

			YCF_Server.BLL.PostureHabit bll=new YCF_Server.BLL.PostureHabit();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
