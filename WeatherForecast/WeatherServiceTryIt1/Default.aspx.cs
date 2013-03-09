using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WeatherService;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void accptBtn_Click(object sender, EventArgs e)
    {
        string zip = zipBox.Text;
        WeatherService.ServiceClient forecast = new WeatherService.ServiceClient();
        string output = forecast.getWeather(zip);
        outputBox.Text = output;
    }
}
