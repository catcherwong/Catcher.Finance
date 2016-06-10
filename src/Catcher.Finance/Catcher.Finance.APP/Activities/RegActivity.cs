using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Catcher.Finance.APPLib;
using Catcher.Finance.Common;
using System;
using System.Collections.Generic;
using System.Json;

namespace Catcher.Finance.APP.Activities
{
    [Activity(Label = "Registration")]
    public class RegActivity : Activity
    {
        Button btnReg;
        EditText txtName,txtEmail,txtPwd;
        RadioGroup rg;
        private string _userGender;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.reg);
       
            //set the back button
            View btnBack = FindViewById(Android.Resource.Id.Home);
            btnBack.SetBackgroundResource(Resource.Drawable.back);
            btnBack.Visibility = ViewStates.Visible;

            btnReg = FindViewById<Button>(Resource.Id.btn_reg);
            rg = FindViewById<RadioGroup>(Resource.Id.rdg_gender);            

            //the Registrate button 
            btnReg.Click += RegistrateEven;
            //the customer back button
            btnBack.Click += BackClickEven;
        }      

        private void BackClickEven(object sender, EventArgs e)
        {
            Finish();
        }

        /// <summary>
        /// user registrate button click even
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RegistrateEven(object sender, EventArgs e)
        {
            txtName = FindViewById<EditText>(Resource.Id.et_name);
            txtPwd = FindViewById<EditText>(Resource.Id.et_pwd);
            txtEmail = FindViewById<EditText>(Resource.Id.et_email);
            _userGender = rg.CheckedRadioButtonId == Resource.Id.rbtn_man ? "male" : "female";

            string domain = this.GetString(Resource.String.domain);
            string url = domain + "user/register";
            IDictionary<string, string> routeParames = new Dictionary<string, string>();
            routeParames.Add("userName", DESHelper.DESEncrypt(this.txtName.Text));
            routeParames.Add("userPassword", DESHelper.DESEncrypt(HMACMD5Encrypt.GetEncryptResult(this.txtPwd.Text)));
            routeParames.Add("gender", DESHelper.DESEncrypt(this._userGender));
            routeParames.Add("email", DESHelper.DESEncrypt(this.txtEmail.Text));

            var result = await EasyWebRequest.SendPostRequestBasedOnHttpClient(url, routeParames);
            var data = (JsonObject)result;
            if (data["Code"] == "0000")
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
                Finish();
            }
            else
            {
                Toast.MakeText(this, "Register fail", ToastLength.Long).Show();
            }            
        }        
    }
}