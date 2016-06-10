using Android.App;
using Android.OS;
using Android.Widget;

namespace Catcher.Finance.APP.Activities
{
    [Activity(Label = "AboutActivity", Icon = "@drawable/logo")]
    public class AboutActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.about);

            var tvAbout = FindViewById<TextView>(Resource.Id.tv_about);

            tvAbout.Text = "";            
        }
    }
}