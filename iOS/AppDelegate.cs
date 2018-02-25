using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using KaraokeTOP.iOS.Helpers;
using SQLite.Net.Platform.XamarinIOS;
using UIKit;

namespace KaraokeTOP.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            string dbPath = FileAccessHelper.GetLocalFilePath("Songs.db");

            LoadApplication(new App(dbPath, new SQLitePlatformIOS()));

            return base.FinishedLaunching(app, options);
        }
    }
}
