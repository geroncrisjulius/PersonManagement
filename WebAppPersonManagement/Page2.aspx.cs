using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using Nito.AsyncEx;

namespace WebAppPersonManagement
{
    public partial class Page2 : System.Web.UI.Page
    {
        private APIConnector _api;

        public string name { get; set; }
        public string age { get; set; }
        public string persontype { get; set; }

        public Page2()
        {
            string apiUrl = Properties.Settings.Default.api_url;
            _api = new APIConnector(apiUrl);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            string strID = Request.QueryString["id"];
            if (int.TryParse(strID, out id))
            {

                var p = AsyncContext.Run(() => _api.GetPersonAsync(id));
                
                name = p.Name;
                age = p.Age.ToString();
                persontype = p.PersonTypeDescription;
                


            }
        }

        //private Highcharts CreateHighChart(List<DataPoint> points)
        //{
        //    Highcharts hc = new Highcharts("bar");

        //    hc.InitChart(new Chart
        //    {
        //        Type = DotNet.Highcharts.Enums.ChartTypes.Column
        //    });
        //    hc.SetTitle(new Title { Text = "Sample Highchart" });
        //    hc.SetXAxis(new XAxis
        //    {
        //        Type = DotNet.Highcharts.Enums.AxisTypes.Category,
        //        Title = new XAxisTitle() { Text = "Dates" },
        //        Categories = points.Select(p => p.Date).ToArray()
        //    }) ;
        //    hc.SetYAxis(new YAxis
        //    {
        //        Title = new YAxisTitle() { Text = "Random" },
        //        ShowFirstLabel = false,
        //        ShowLastLabel = false,
        //        Min = 0,
        //        Max = 110
        //    });
        //    hc.SetSeries(new Series
        //    {
        //        Data = new Data(points.Select(p => (object)p.Random).ToArray())
        //    });

        //    return hc ;
        //}

        //private List<DataPoint> CreateData()
        //{
        //    DateTime date = DateTime.Now;
        //    List<DataPoint> ls = new List<DataPoint>();
        //    Random r = new Random();


        //    for (int i = 0; i < 10; i++)
        //    {
        //        DataPoint dp = new DataPoint
        //        {
        //            Date = date.AddDays(i).ToShortDateString(),
        //            Random = r.Next(0, 100)
        //        };
        //        ls.Add(dp);
        //    }

        //    return ls;

        //}

    }

}