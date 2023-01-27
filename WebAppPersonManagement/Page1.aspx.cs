using Nito.AsyncEx;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace WebAppPersonManagement
{
    public partial class Page1 : System.Web.UI.Page
    {
        //private NorthwindReadWriteEntities _dataContext;

        //protected NorthwindReadWriteEntities DbContext
        //{
        //    get
        //    {
        //        if (_dataContext == null)
        //        {
        //            _dataContext = new NorthwindReadWriteEntities();
        //        }
        //        return _dataContext;
        //    }
        //}

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
            //var editableItem = ((GridEditableItem)e.Item);
            //var productId = (int)editableItem.GetDataKeyValue("ProductID");

            ////retrive entity form the Db
            //var product = DbContext.Products.Where(n => n.ProductID == productId).FirstOrDefault();
            //if (product != null)
            //{
            //    //update entity's state
            //    editableItem.UpdateValues(product);

            //    try
            //    {
            //        //save chanages to Db
            //        DbContext.SaveChanges();
            //    }
            //    catch (System.Exception)
            //    {
            //        ShowErrorMessage();
            //    }
            //}
            var editableItem = ((GridEditableItem)e.Item);
            var id = (int)editableItem.GetDataKeyValue("ID");

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

            //DbContext.AddToProducts(product);
            //try
            //{
            //    //save chanages to Db
            //    DbContext.SaveChanges();
            //}
            //catch (System.Exception)
            //{
            //    ShowErrorMessage();
            //}

            var editableItem = ((GridEditableItem)e.Item);
            Hashtable values = new Hashtable();
            editableItem.ExtractValues(values);

            try
            {
                Person p = new Person();
                p.Name = (string)values["Name"];
                p.Age = values["Age"] == null ? 0 : int.Parse(values["Age"].ToString());
                p.PersonTypeID = values["PersonTypeID"] == null ? 0 : int.Parse(values["PersonTypeID"].ToString());
            }
            catch
            {
                ShowErrorMessage();
            }
            AsyncContext.Run(() => _api.CreatePerson(p));


        }

        protected void RadGrid1_DeleteCommand(object source, GridCommandEventArgs e)
        {
            
            var id = (int)((GridDataItem)e.Item).GetDataKeyValue("ID");

            AsyncContext.Run(() => _api.DeletePersonAsync(id));

        }
    }
}