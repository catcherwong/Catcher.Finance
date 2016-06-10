using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Catcher.Finance.APPLib;
using System.Collections.Generic;
using System.Json;

namespace Catcher.Finance.APP.Fragments
{
    public class MainFragment : Fragment
    {
        TextView tvIncome, tvPay;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View mainFragment = inflater.Inflate(Resource.Layout.fragment_main, container, false);

            tvIncome = mainFragment.FindViewById<TextView>(Resource.Id.tv_income);
            tvPay = mainFragment.FindViewById<TextView>(Resource.Id.tv_pay);

            var shared =this.Activity.GetSharedPreferences("finance", FileCreationMode.Private);            

            string uName = shared.GetString("name", "");            

            GetSummaryDate(uName);

            return mainFragment;
        }

        /// <summary>
        /// get the summary data 
        /// </summary>
        /// <param name="uName">the name of the user</param>
        private async void GetSummaryDate(string uName)
        {
            string domain = this.Activity.GetString(Resource.String.domain);
            string url = domain+"money/gettotalinfo";
            IDictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("uname", string.IsNullOrEmpty(uName) ? "" : uName);
            var result = await EasyWebRequest.SendGetHttpRequestBaseOnHttpWebRequest(url, dic);
            var data = (JsonObject)result;
            if (data["Code"] == "0000")
            {
                tvIncome.Text = "Your total income is гд "+ data["Income"].ToString();
                tvPay.Text = "Your total pay is гд " + data["Pay"].ToString();
            }
            else
            {

            }                        
        }
    }
}