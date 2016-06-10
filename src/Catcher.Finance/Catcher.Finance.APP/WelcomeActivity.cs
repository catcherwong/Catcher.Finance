using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;

namespace Catcher.Finance.APP
{
    [Activity(Label = "Finance", MainLauncher = true, Theme = "@android:style/Theme.Black.NoTitleBar.Fullscreen", Icon = "@drawable/logo")]
    public class WelcomeActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.welcome);

            TextView tvVersion = FindViewById<TextView>(Resource.Id.tv_version);

            PackageManager pm = this.PackageManager;

            PackageInfo pi = pm.GetPackageInfo(this.PackageName, PackageInfoFlags.MatchAll);

            tvVersion.Text = "Version" + pi.VersionName;
            
            //delay
            new Handler().PostDelayed(() =>
            {
                Intent intent = new Intent(this, typeof(LoginActivity));
                StartActivity(intent);
                this.Finish();
            }, 5000);
        }
    }
}