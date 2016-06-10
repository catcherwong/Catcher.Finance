using Android.App;
using Android.OS;
using Android.Widget;
using Catcher.Finance.APP.Fragments;

namespace Catcher.Finance.APP.Activities
{
    [Activity(Label = "MainActivity")]
    public class MainActivity : Activity
    {
        RadioGroup rgMenu;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.main);
            rgMenu = FindViewById<RadioGroup>(Resource.Id.menuGroup);
            
            MainFragment mainFragment = new MainFragment();

            var fm = FragmentManager.BeginTransaction();
            fm.Add(Resource.Id.framelayout_Show, mainFragment).Show(mainFragment);
            fm.Commit();            

            rgMenu.CheckedChange += GroupButtonSelect;            
        }

        /// <summary>
        /// group button select
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupButtonSelect(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            var fm = FragmentManager.BeginTransaction();
            //add item
            if (e.CheckedId == Resource.Id.rbtn_addItem)
            {
                AddItemFragment addItemFragment = new AddItemFragment();
                fm = FragmentManager.BeginTransaction();
                fm.Replace(Resource.Id.framelayout_Show, addItemFragment);
                fm.Commit();
            }
            //the detial
            if (e.CheckedId == Resource.Id.rbtn_itemDetial)
            {
                DetialFragment detialFragment = new DetialFragment();
                fm = FragmentManager.BeginTransaction();
                fm.Replace(Resource.Id.framelayout_Show,detialFragment);    
                fm.Commit();
            }
            //the service 
            if (e.CheckedId == Resource.Id.rbtn_service)
            {
                ServiceFragment personalFragment = new ServiceFragment();
                fm = FragmentManager.BeginTransaction();
                fm.Replace(Resource.Id.framelayout_Show, personalFragment);
                fm.Commit();                
            }
        }
    }
}