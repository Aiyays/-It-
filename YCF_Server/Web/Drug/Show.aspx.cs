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
namespace YCF_Server.Web.Drug
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
					int DID=(Convert.ToInt32(strid));
					ShowInfo(DID);
				}
			}
		}
		
	private void ShowInfo(int DID)
	{
		YCF_Server.BLL.Drug bll=new YCF_Server.BLL.Drug();
		YCF_Server.Model.Drug model=bll.GetModel(DID);
		this.lblDID.Text=model.DID.ToString();
		this.lblDrugName.Text=model.DrugName;
		this.lblDlevel.Text=model.Dlevel.ToString();
		this.lblManufactureDate.Text=model.ManufactureDate.ToString();
		this.lblValidTime.Text=model.ValidTime.ToString();
		this.lblPrice.Text=model.Price;
		this.lblSpecification.Text=model.Specification;
		this.lblDrugSource.Text=model.DrugSource;
		this.lblInDate.Text=model.InDate.ToString();
		this.lblStoragetempera.Text=model.Storagetempera;
		this.lblManufacturers.Text=model.Manufacturers;
		this.lblBrand.Text=model.Brand;
		this.lblDrugIMG.Text=model.DrugIMG;
		this.lblTID.Text=model.TID.ToString();

	}


    }
}
