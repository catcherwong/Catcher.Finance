package md59cf8326c85cec1d59c797932b20af767;


public class Category
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Catcher.Finance.APP.Models.Category, Catcher.Finance.APP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Category.class, __md_methods);
	}


	public Category () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Category.class)
			mono.android.TypeManager.Activate ("Catcher.Finance.APP.Models.Category, Catcher.Finance.APP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
