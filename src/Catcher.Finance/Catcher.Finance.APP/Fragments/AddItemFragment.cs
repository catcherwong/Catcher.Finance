using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Catcher.Finance.APP.Extensions;
using Catcher.Finance.APP.Models;
using Catcher.Finance.APPLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Json;
using System.Threading.Tasks;

namespace Catcher.Finance.APP.Fragments
{
    /// <summary>
    /// the fragment is used to add the money record
    /// </summary>
    public class AddItemFragment : Fragment
    {
        EditText edDate, etMoney,etAbout;
        Spinner spType,spCategory;
        
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {           
            View addItemView = inflater.Inflate(Resource.Layout.fragment_addItem, container,false);

            // the category
            spCategory = addItemView.FindViewById<Spinner>(Resource.Id.sp_category);
            var data = GetCategory().Result["Data"].ToString();
            var categoryList = JsonConvert.DeserializeObject<List<CategoryInfo>>(data);
            spCategory.Adapter = new CategoryAdapter(this.Activity, categoryList);         
            //type
            spType = addItemView.FindViewById<Spinner>(Resource.Id.sp_type);

            //the date
            ImageButton dateSelect = addItemView.FindViewById<ImageButton>(Resource.Id.imgbtn_date);
            dateSelect.Click += DateSelect;
            edDate = addItemView.FindViewById<EditText>(Resource.Id.ed_date);
            edDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            //other data
            etMoney = addItemView.FindViewById<EditText>(Resource.Id.et_money);
            etAbout = addItemView.FindViewById<EditText>(Resource.Id.et_about);    

            //add
            Button btnAdd = addItemView.FindViewById<Button>(Resource.Id.btn_addItem);

            btnAdd.Click += AddItemClickEven;

            return addItemView;
        }        

        /// <summary>
        /// even of the add button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void AddItemClickEven(object sender, EventArgs e)
        {
            //get the data
            string date = edDate.Text;
            string category = spCategory.SelectedItem.ToString();
            string type = (string)spType.SelectedItem;
            string money = etMoney.Text;
            string about = etAbout.Text;

            var shared = this.Activity.GetSharedPreferences("finance", FileCreationMode.Private);

            string uName = shared.GetString("name", "");

            string domain = this.Activity.GetString(Resource.String.domain);
            //web request
            string url = domain+"money/addmoneyrecord";
            IDictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("uName", uName);
            dic.Add("moneyType", type);
            dic.Add("categoryId", category);
            dic.Add("moneyValue", money);
            dic.Add("moneyDate", date);
            dic.Add("moneyAbout", about);

            var result = await EasyWebRequest.SendPostRequestBasedOnHttpClient(url, dic);
            var data = (JsonObject)result;
            if (data["Code"] == "0000")
            {
                Toast.MakeText(this.Activity, "OK", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this.Activity, "Fail", ToastLength.Long).Show();
            }            
        }

        /// <summary>
        /// open the dialog to select the date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DateSelect(object sender, EventArgs e)
        {
            
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                edDate.Text = time.ToString("yyyy-MM-dd");
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        /// <summary>
        /// request the categories 
        /// </summary>
        /// <returns></returns>
        private async Task<JsonObject> GetCategory()
        {
            string domain = this.Activity.GetString(Resource.String.domain);
            string url = domain + "category/getallcategory";
            IDictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("1", "1");
            var result = await EasyWebRequest.SendGetHttpRequestBaseOnHttpWebRequest(url, dic);
            var data = (JsonObject)result;

            if (data["Code"] == "0000")
            {
                return data;
            }
            else
            {
                return new JsonObject();
            }
        }
    }
}