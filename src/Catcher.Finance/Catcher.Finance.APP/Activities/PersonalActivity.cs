using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Catcher.Finance.APPLib;
using System.Collections.Generic;
using System.Json;

namespace Catcher.Finance.APP.Activities
{
    [Activity(Label = "Personal Infomation")]
    public class PersonalActivity : Activity
    {
        EditText etName, etEmail;
        TextView tvGender;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.personal);
                            
            etName = FindViewById<EditText>(Resource.Id.et_uName);
            etEmail = FindViewById<EditText>(Resource.Id.et_uEmail);
            tvGender = FindViewById<TextView>(Resource.Id.tv_uGender);

            //get the name from the shared
            var shared = GetSharedPreferences("finance", FileCreationMode.Private);
            string uName = shared.GetString("name", "");

            GetPersonalInfo(uName);
        }

        /// <summary>
        /// get the user's infomation
        /// </summary>
        /// <param name="uName">the name of the user</param>
        private async void GetPersonalInfo(string uName)
        {
            //get the domain of the web request
            string domain = this.GetString(Resource.String.domain);            
            string url = domain + "user/getuserinfo";

            IDictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("uName", uName);

            var result = await EasyWebRequest.SendGetHttpRequestBaseOnHttpWebRequest(url, dic);
            var data = (JsonObject)result;
            if (data["Code"] == "0000")//success
            {
                string user = data["Data"].ToString();
                JsonObject jo = JsonObject.Parse(user) as JsonObject; 

                etEmail.Text = jo["UserEmail"];
                etName.Text = jo["UserName"];
                tvGender.Text = jo["UserGender"];
            }
            else//fault
            {
                etEmail.Text = "";
                etName.Text = "";
                tvGender.Text = "";
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                Finish();
            }
            return true;
        }

    }
}