using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Veripark.Business.Abstract;
using Veripark.Business.Concrete;
using Veripark.DataAccess.Abstract;
using Veripark.DataAccess.Concrete.Entity_Framework;

namespace Veripark.WebUI
{
    public partial class index : System.Web.UI.Page
    {
        private ICountryService _IBookService = new CountryManager(new CountryDal());
        private ICalculatePenalty _ICalculatePenalty = new CalculatePenaltyManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            FillCountry();
        }

        private void FillCountry()
        {
            drpCountry.DataSource = _IBookService.GetList();
            drpCountry.DataValueField = "ID";
            drpCountry.DataTextField = "CountryName";
            drpCountry.DataBind();
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
          var response=  _ICalculatePenalty.CalculatePenalty(new Entities.Request.rqCalculatePenalty()
            {
                dateCheck = DateTime.Parse(clnDateCheck.Value.ToString()),
                dateReturn = DateTime.Parse(clnDateReturn.Value.ToString()),
                countries =hdSelectCountry.Value
          });

            if (response.isSuccess)
            {
                List<string> list = (List<string>)response.Data;
                string tmp = "";
                foreach (var item in list)
                {
                    tmp += item + "</br>";
                }
                lblResult.InnerHtml = tmp;
            }
            else
            {
                lblResult.InnerHtml = response.Error.ToString();
            }
        }
    }
}