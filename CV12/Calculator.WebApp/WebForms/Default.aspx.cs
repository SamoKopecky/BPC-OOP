using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator.WebApp.WebForms
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void submit_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(
                $"Result.aspx?first={firstNumber.Text}" +
                $"&second={secondNumber.Text}" +
                $"&op={operation.SelectedValue}"
            );
        }
    }
}