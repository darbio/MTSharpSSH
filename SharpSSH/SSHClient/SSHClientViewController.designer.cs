// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace SSHClient
{
	[Register ("SSHClientViewController")]
	partial class SSHClientViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITextField txtinput { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView txtview { get; set; }

		[Action ("send:")]
		partial void send (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (txtinput != null) {
				txtinput.Dispose ();
				txtinput = null;
			}

			if (txtview != null) {
				txtview.Dispose ();
				txtview = null;
			}
		}
	}
}
