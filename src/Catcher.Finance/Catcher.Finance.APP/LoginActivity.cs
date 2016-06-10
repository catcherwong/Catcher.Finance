using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Catcher.Finance.APP.Activities;
using Catcher.Finance.APPLib;
using Catcher.Finance.Common;
using System;
using System.Collections.Generic;
using System.Json;

namespace Catcher.Finance.APP
{
    [Activity(Label = "Login", Icon = "@drawable/logo")]
    public class LoginActivity : Activity
    {
        Button btnLogin;
        EditText txtName;
        EditText txtPwd;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.login);
            btnLogin = FindViewById<Button>(Resource.Id.btn_login);
           
            btnLogin.Click += LoginClickEven;

            var share = GetSharedPreferences("finance", FileCreationMode.Private);

            if (!string.IsNullOrEmpty(share.GetString("name", "")))
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
                Finish();
            }
        }

        /// <summary>
        /// login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LoginClickEven(object sender, EventArgs e)
        {
            txtName = FindViewById<EditText>(Resource.Id.txt_name);
            txtPwd = FindViewById<EditText>(Resource.Id.txt_pwd);
            
            string domain = this.GetString(Resource.String.domain);
            string url = domain + "user/login";
            IDictionary<string, string> routeParames = new Dictionary<string, string>();
            routeParames.Add("userName", DESHelper.DESEncrypt(this.txtName.Text));
            routeParames.Add("userPassword",DESHelper.DESEncrypt(HMACMD5Encrypt.GetEncryptResult(this.txtPwd.Text)));

            var test = HMACMD5Encrypt.GetEncryptResult(this.txtPwd.Text);

            var result = await EasyWebRequest.SendPostRequestBasedOnHttpClient(url, routeParames);
            //var result = await EasyWebRequest.SendPostHttpRequestBaseOnHttpWebRequest(url, routeParames);
            var data = (JsonObject)result;
            if (data["Code"] == "0000")
            {
                var share = GetSharedPreferences("finance", FileCreationMode.Private);
                var editor = share.Edit();
                editor.PutString("name", txtName.Text).Commit();

                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
                Finish();
            }
            else
            { 
                Toast.MakeText(this,"Login fail,please check your name and password",ToastLength.Long).Show();                
            }
        }

        /// <summary>
        /// set the menu
        /// </summary>
        /// <param name="menu">menu</param>
        /// <returns></returns>
        public override bool OnCreateOptionsMenu(IMenu menu)
        {            
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return true;
        }

        /// <summary>
        /// Registration
        /// </summary>
        /// <param name="item">the menu item</param>
        /// <returns></returns>
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Resource.Id.btnReg)
            {
                Intent intent = new Intent(this, typeof(RegActivity));
                StartActivity(intent);                
            }
            return true;
        }
    }
}