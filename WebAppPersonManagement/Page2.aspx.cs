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
        

    }

}