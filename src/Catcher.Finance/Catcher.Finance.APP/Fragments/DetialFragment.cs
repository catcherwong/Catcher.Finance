using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Catcher.Finance.APP.Extensions;
using Catcher.Finance.APP.Models;
using Catcher.Finance.APPLib;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Json;
using System.Threading.Tasks;

namespace Catcher.Finance.APP.Fragments
{
    public class DetialFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);         
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_detial, null);

            ListView lvDetial = view.FindViewById<ListView>(Resource.Id.lv_detial);

            //get the name from the share
            var shared = this.Activity.GetSharedPreferences("finance", FileCreationMode.Private);

            string uName = shared.GetString("name", "");

            var data = GetMoneyDetial(uName).Result["Data"].ToString();
            var list = JsonConvert.DeserializeObject<List<Detial>>(data);
            lvDetial.Adapter = new MoneyDetialAdapter(this.Activity, list);

            return view;
        }

        /// <summary>
        /// get the detials
        /// </summary>
        /// <param name="uName">the name of the user</param>
        /// <returns></returns>
        private async Task<JsonObject> GetMoneyDetial(string uName)
        {
            string domain = this.Activity.GetString(Resource.String.domain);
            string url = domain + "money/getmoneydetial";
            IDictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("uName", uName);
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