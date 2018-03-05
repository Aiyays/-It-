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
namespace YCF_Server.Web.Equipment
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int EID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(EID);
				}
			}
		}
			
	private void ShowInfo(int EID)
	{
		YCF_Server.BLL.Equipment bll=new YCF_Server.BLL.Equipment();
		YCF_Server.Model.Equipment model=bll.GetModel(EID);
		this.lblEID.Text=model.EID.ToString();
		this.txtSN.Text=model.SN;
		this.txtEName.Text=model.EName;
		this.txtManufactureDate.Text=model.ManufactureDate.ToString();
		this.txtValidTime.Text=model.ValidTime.ToString();
		this.txtSpecification.Text=model.Specification;
		this.txtModel.Text=model.Model;
		this.txtMaintenanceCycle.Text=model.MaintenanceCycle;
		this.txtPrice.Text=model.Price;
		this.txtColor.Text=model.Color;
		this.txtCount.Text=model.Count.ToString();
		this.txtTID.Text=model.TID.ToString();
		this.txtRemark.Text=model.Remark;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtSN.Text.Trim().Length==0)
			{
				strErr+="设备编号不能为空！\\n";	
			}
			if(this.txtEName.Text.Trim().Length==0)
			{
				strErr+="设备名称不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtManufactureDate.Text))
			{
				strErr+="生产日期格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtValidTime.Text))
			{
				strErr+="有效期格式错误！\\n";	
			}
			if(this.txtSpecification.Text.Trim().Length==0)
			{
				strErr+="规格不能为空！\\n";	
			}
			if(this.txtModel.Text.Trim().Length==0)
			{
				strErr+="型号不能为空！\\n";	
			}
			if(this.txtMaintenanceCycle.Text.Trim().Length==0)
			{
				strErr+="维护周期不能为空！\\n";	
			}
			if(this.txtPrice.Text.Trim().Length==0)
			{
				strErr+="价格不能为空！\\n";	
			}
			if(this.txtColor.Text.Trim().Length==0)
			{
				strErr+="颜色不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtCount.Text))
			{
				strErr+="数量格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtTID.Text))
			{
				strErr+="外键-设备类型格式错误！\\n";	
			}
			if(this.txtRemark.Text.Trim().Length==0)
			{
				strErr+="备注不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int EID=int.Parse(this.lblEID.Text);
			string SN=this.txtSN.Text;
			string EName=this.txtEName.Text;
			DateTime ManufactureDate=DateTime.Parse(this.txtManufactureDate.Text);
			DateTime ValidTime=DateTime.Parse(this.txtValidTime.Text);
			string Specification=this.txtSpecification.Text;
			string Model=this.txtModel.Text;
			string MaintenanceCycle=this.txtMaintenanceCycle.Text;
			string Price=this.txtPrice.Text;
			string Color=this.txtColor.Text;
			int Count=int.Parse(this.txtCount.Text);
			int TID=int.Parse(this.txtTID.Text);
			string Remark=this.txtRemark.Text;


			YCF_Server.Model.Equipment model=new YCF_Server.Model.Equipment();
			model.EID=EID;
			model.SN=SN;
			model.EName=EName;
			model.ManufactureDate=ManufactureDate;
			model.ValidTime=ValidTime;
			model.Specification=Specification;
			model.Model=Model;
			model.MaintenanceCycle=MaintenanceCycle;
			model.Price=Price;
			model.Color=Color;
			model.Count=Count;
			model.TID=TID;
			model.Remark=Remark;

			YCF_Server.BLL.Equipment bll=new YCF_Server.BLL.Equipment();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
