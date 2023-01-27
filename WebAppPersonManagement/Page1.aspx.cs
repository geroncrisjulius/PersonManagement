using Nito.AsyncEx;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Telerik.Web.UI;

namespace WebAppPersonManagement
{
    public partial class Page1 : Page
    {

        private APIConnector _api;

        public Page1()
        {
            //string apiUrl = ConfigurationManager.AppSettings["api_url"];
            string apiUrl = Properties.Settings.Default.api_url;
            _api = new APIConnector(apiUrl);
        }


        protected void RadGrid1_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            var result = AsyncContext.Run(() => _api.GetAllPersonsAsync());
            RadGrid1.DataSource = result;
        }


        protected void RadGrid1_UpdateCommand(object source, GridCommandEventArgs e)
        {


            var editableItem = (GridEditableItem)e.Item;
            var id = (int)editableItem.GetDataKeyValue("ID");

            Person_WriteModel p = new Person_WriteModel();
            editableItem.UpdateValues(p);
            AsyncContext.Run(() => _api.UpdatePersonAsync(id, p));


        }


        private void ShowErrorMessage()
        {
            RadAjaxManager1.ResponseScripts.Add(string.Format("window.radalert(\"Please enter valid data!\")"));
        }

        protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridEditableItem && (e.Item.IsInEditMode))
            {
                GridEditableItem editableItem = (GridEditableItem)e.Item;
                SetupInputManager(editableItem);
            }
        }

        private void SetupInputManager(GridEditableItem editableItem)
        {
            var textBox =
                ((GridTextBoxColumnEditor)editableItem.EditManager.GetColumnEditor("Name")).TextBoxControl;


            InputSetting inputSetting = RadInputManager1.GetSettingByBehaviorID("TextBoxSetting1");
            inputSetting.TargetControls.Add(new TargetInput(textBox.UniqueID, true));
            inputSetting.InitializeOnClient = true;
            inputSetting.Validation.IsRequired = true;

            textBox =
                ((GridTextBoxColumnEditor)editableItem.EditManager.GetColumnEditor("Age")).TextBoxControl;

            inputSetting = RadInputManager1.GetSettingByBehaviorID("NumericTextBoxSetting1");
            inputSetting.InitializeOnClient = true;
            inputSetting.TargetControls.Add(new TargetInput(textBox.UniqueID, true));

            textBox =
                ((GridTextBoxColumnEditor)editableItem.EditManager.GetColumnEditor("PersonTypeID")).TextBoxControl;

            inputSetting = RadInputManager1.GetSettingByBehaviorID("NumericTextBoxSetting2");
            inputSetting.InitializeOnClient = true;
            inputSetting.TargetControls.Add(new TargetInput(textBox.UniqueID, true));
        }

        protected void RadGrid1_InsertCommand(object source, GridCommandEventArgs e)
        {

            var editableItem = ((GridEditableItem)e.Item);
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            Person_WriteModel p = new Person_WriteModel();
            try
            {
                p.Name = (string)values["Name"];
                p.Age = values["Age"] == null ? 0 : int.Parse(values["Age"].ToString());
                p.PersonTypeID = values["PersonTypeID"] == null ? 0 : int.Parse(values["PersonTypeID"].ToString());
            }
            catch
            {
                ShowErrorMessage();
            }
            AsyncContext.Run(() => _api.CreatePersonAsync(p));


        }

        protected void RadGrid1_DeleteCommand(object source, GridCommandEventArgs e)
        {

            var id = (int)((GridDataItem)e.Item).GetDataKeyValue("ID");

            AsyncContext.Run(() => _api.DeletePersonAsync(id));

        }

        protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
        {
            //if (e.Item is GridDataItem)
            //{
            //    GridDataItem item = (GridDataItem)e.Item;
            //    int type = int.Parse(item["PersonTypeID"].Text);
            //    if (type == 1) { }
            //    else
            //    {
            //        item["GoToPage2"].Controls.Clear();
            //    }
            //}
        }

        protected void RadGrid1_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem dataItem in RadGrid1.Items)
            {
                int type = int.Parse(dataItem["PersonTypeID"].Text);
                if (type == 1) { }
                else
                {
                    dataItem["GoToPage2"].Controls.Clear();
                }
            }
        }

        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName.ToUpper())
            {
                case "GOTOPAGE2":
                    if(e.Item is GridDataItem)
                    {
                        GridDataItem item = (GridDataItem)e.Item;
                        string id = item["ID"].Text;

                        OpenPage2PopUp(id);
                    }
                    break;
            }
        }

        private void OpenPage2PopUp(string id)
        {
            string url = $"Page2.aspx?id={id}";
            string fullURL = $"window.open('{url}', '_blank', 'height=700,width=800,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=no,titlebar=no' );";
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);

        }

        //TODO fix design
        //TODO asign default page
    }
}