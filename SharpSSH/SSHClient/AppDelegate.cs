using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Tamir.SharpSsh.jsch;

namespace SSHClient
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		UIWindow window;
		Tamir.SharpSsh.SshStream ssh;
		UITextView txtConsole = new UITextView(new System.Drawing.RectangleF(0,20,UIScreen.MainScreen.Bounds.Width,UIScreen.MainScreen.Bounds.Height-20));
		System.Threading.Thread ConsoleReader;

		NSTimer T;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);
			txtConsole.BackgroundColor = UIColor.Black;
			txtConsole.TextColor = UIColor.LightGray;
			txtConsole.Font = UIFont.FromName ("Courier New",11);

						
			txtConsole.Text = "SharpSSH for iPhone\r\n";

			window.Add (txtConsole);
			
			ConsoleReader = new System.Threading.Thread(ReadConsole);
			ConsoleReader.Start ();			
			T = NSTimer.CreateRepeatingScheduledTimer(1, delegate() {
				InvokeOnMainThread (delegate {
					string x = ssh.ReadResponse ();
					txtConsole.Text += x+"\r\n";	
				});						
			});
			window.MakeKeyAndVisible ();
			
			return true;
		}
		
		void ReadConsole() {
			InvokeOnMainThread(delegate {
				String host = "";
				String user="";
				String password = "";
	
				txtConsole.Text += "Establishing connection to: "+host+"\r\n";
				ssh = new Tamir.SharpSsh.SshStream(host,user,password);
				ssh.RemoveTerminalEmulationCharacters = true;
				
				ssh.Write ("ls /");
				
				ssh.Write ("df -m");
			});
			
			
			while(true) {
				NSRunLoop.Current.RunUntil(DateTime.Now.AddMilliseconds(500));
			}
		}
	
	}




}

