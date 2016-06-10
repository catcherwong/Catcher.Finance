using Android.App;
using Android.Views;
using Android.Widget;
using Catcher.Finance.APP.Models;
using System;
using System.Collections.Generic;

namespace Catcher.Finance.APP.Extensions
{
    public class MoneyDetialAdapter : BaseAdapter<Detial>
    {

        private readonly Activity _context;
        private readonly IList<Detial> _detial;
        public MoneyDetialAdapter(Activity context, IList<Detial> detial)
        {
            this._context = context;
            this._detial = detial;
        }

        public override Detial this[int position]
        {
            get
            {
                return this._detial[position];
            }
        }

        public override int Count
        {
            get
            {
                return this._detial.Count;
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
                view = this._context.LayoutInflater.Inflate(Resource.Layout.detiallistview, null);
            }

            //set display value
            view.FindViewById<TextView>(Resource.Id.lv_tv_category).Text = " Category£º" + this._detial[position].CategoryName;

            view.FindViewById<TextView>(Resource.Id.lv_tv_money).Text = "Money£º" + this._detial[position].MoneyValue;


            view.FindViewById<TextView>(Resource.Id.lv_tv_type).Text = "type£º" + this._detial[position].MoneyType;

            view.FindViewById<TextView>(Resource.Id.lv_tv_about).Text = "Mark£º" + this._detial[position].MoneyAbout;

            view.FindViewById<TextView>(Resource.Id.lv_tv_date).Text = " Date£º" + DateTime.Parse(this._detial[position].MoneyDate).ToString("yyyy-MM-dd");

            return view;
        }
    }
}