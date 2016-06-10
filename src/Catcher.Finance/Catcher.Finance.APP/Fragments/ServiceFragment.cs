using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Catcher.Finance.APP.Activities;

namespace Catcher.Finance.APP.Fragments
{
    public class ServiceFragment : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }


        string[] data =  new string[5];

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {            
            View serviceView =  inflater.Inflate(Resource.Layout.fragment_service, container,false);
            ListView serviceLV = serviceView.FindViewById<ListView>(Resource.Id.lv_service);            

            data[0] = "Personal Infomation";
            data[1] = "About Finance";
            data[2] = "Other";
            data[3] = "Author : Catcher Wong";
            data[4] = "Version : " +  this.Activity.PackageManager.GetPackageInfo(this.Activity.PackageName,Android.Content.PM.PackageInfoFlags.MatchAll).VersionName;


            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this.Activity, Android.Resource.Layout.SimpleListItem1, data );

            //ListAdapter = adapter;
            serviceLV.Adapter = adapter;

            serviceLV.ItemClick += ListViewItemClickEven;
            
            return serviceView;
        }

        private void ListViewItemClickEven(object sender, AdapterView.ItemClickEventArgs e)
        {
            //personal infomation
            if (e.Position == 0)
            {
                Intent intent = new Intent(this.Activity, typeof(PersonalActivity));
                StartActivity(intent);
            }
            //about infomation
            if (e.Position == 1)
            {
                Intent intent = new Intent(this.Activity, typeof(AboutActivity));
                StartActivity(intent);
            }
            if (e.Position == 2)
            {

            }
            //author infomation
            if (e.Position == 3)
            {
                Intent intent = new Intent(this.Activity, typeof(AuthorActivity));
                StartActivity(intent);
            }
            if (e.Position == 4)
            {

            }
            if (e.Position == 5)
            {

            }
        }
    }
}