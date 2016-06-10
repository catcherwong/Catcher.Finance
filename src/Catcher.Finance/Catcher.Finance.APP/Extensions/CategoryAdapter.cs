using Android.App;
using Android.Views;
using Android.Widget;
using Catcher.Finance.APP.Models;
using System.Collections.Generic;

namespace Catcher.Finance.APP.Extensions
{
    /// <summary>
    /// this adapter is used to binding data from the web request
    /// </summary>
    public class CategoryAdapter : BaseAdapter<CategoryInfo>
    {
        private readonly Activity _context;
        //the data binding to the spinner
        private readonly IList<CategoryInfo> _types;

        public CategoryAdapter(Activity context, IList<CategoryInfo> types)
        {
            this._context = context;
            this._types = types;
        }

        public override CategoryInfo this[int position]
        {
            get
            {
                return this._types[position];
            }
        }

        public override int Count
        {
            get
            {
                return this._types.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;
            if (view == null)
            {
                view = this._context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            }

            //set display value
            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = this._types[position].CategoryName;
            return view;
        }
    }
}