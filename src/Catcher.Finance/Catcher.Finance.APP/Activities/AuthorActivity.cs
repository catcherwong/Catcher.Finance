using Android.App;
using Android.OS;
using Android.Webkit;

namespace Catcher.Finance.APP.Activities
{
    [Activity(Label = "AuthorActivity")]
    public class AuthorActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.author);

            WebView wv = FindViewById<WebView>(Resource.Id.wv_author);

            wv.LoadUrl("http://www.cnblogs.com/catcher1994");

            wv.Settings.JavaScriptEnabled = true;
            wv.SetWebViewClient(new WebViewClient());
            wv.Settings.UseWideViewPort = true;
        }
    }
}