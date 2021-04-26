using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Calculator.WebApp.WebForms
{
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var switcher = new Dictionary<string, string>()
            {
                {"addition", "+"},
                {"subtraction", "-"},
                {"multiplication", "*"},
                {"division", "/"}
            };

            var service = new CalcServiceReference.CalcServiceClient();
            var firstNumber = Convert.ToDouble(Request.QueryString["first"]);
            var secondNumber = Convert.ToDouble(Request.QueryString["second"]);
            var operation = Request.QueryString["op"];

            if (operation == null) return;
            var operationSign = switcher[operation];
            var result = service.Calculate(firstNumber, secondNumber, operationSign);
            Response.Write($"{firstNumber}{operationSign}{secondNumber}={result}");
        }
    }
}