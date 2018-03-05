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
namespace YCF_Server.Web.Equipment
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int EID=(Convert.ToInt32(strid));
					ShowInfo(EID);
				}
			}
		}
		
	private void ShowInfo(int EID)
	{
		YCF_Server.BLL.Equipment bll=new YCF_Server.BLL.Equipment();
		YCF_Server.Model.Equipment model=bll.GetModel(EID);
		this.lblEID.Text=model.EID.ToString();
		this.lblSN.Text=model.SN;
		this.lblEName.Text=model.EName;
		this.lblManufactureDate.Text=model.ManufactureDate.ToString();
		this.lblValidTime.Text=model.ValidTime.ToString();
		this.lblSpecification.Text=model.Specification;
		this.lblModel.Text=model.Model;
		this.lblMaintenanceCycle.Text=model.MaintenanceCycle;
		this.lblPrice.Text=model.Price;
		this.lblColor.Text=model.Color;
		this.lblCount.Text=model.Count.ToString();
		this.lblTID.Text=model.TID.ToString();
		this.lblRemark.Text=model.Remark;

	}


    }
}
