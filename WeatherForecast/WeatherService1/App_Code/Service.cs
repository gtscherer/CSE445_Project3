using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using weatherService;
using USZip;
using System.Xml;
using System.Xml.XPath;
using System.IO;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}
    public string getWeather(string zipCode)
    {
        USZip.USZipSoapClient byZip = new USZip.USZipSoapClient("USZipSoap");
        XmlNode rtNode = byZip.GetInfoByZIP(zipCode);
        XPathNavigator nav = rtNode.CreateNavigator();
        XPathNodeIterator it = nav.Select("/NewDataSet/Table/City");
        weatherService.ndfdXML graphicalWeather = new weatherService.ndfdXML();
        string city = it.Current.Value;
        it.MoveNext();
        string state = it.Current.Value;
        string latituteLongitude = graphicalWeather.LatLonListZipCode(zipCode);
        string latLong;
        using (XmlReader reader = XmlReader.Create(new StringReader(latituteLongitude)))
        {
            reader.ReadToFollowing("latLonList");
            latLong = reader.ReadElementContentAsString();
        }
        string forecastInfo;
        if (latLong != "")
        {
            forecastInfo = graphicalWeather.NDFDgenByDayLatLonList(latLong, DateTime.Today, "5", "e", "24 hourly");
        }
        else
        {
            forecastInfo = "";
        }
        return forecastInfo;
    }
}
