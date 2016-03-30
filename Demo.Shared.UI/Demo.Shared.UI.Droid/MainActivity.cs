using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin;
using System.Threading.Tasks;

namespace Demo.Shared.UI.Droid
{
    [Activity(Label = "Demo.Shared.UI", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        //public const string HOCKEYAPP_APPID = "YOUR-APP-ID";

        protected override void OnCreate(Bundle bundle)
        {
            //// Register the crash manager before Initializing the trace writer 
            //HockeyApp.CrashManager.Register(this, HOCKEYAPP_APPID);

            ////Register to with the Update Manager 
            //HockeyApp.UpdateManager.Register(this, HOCKEYAPP_APPID);

            //// Initialize the Trace Writer 
            //HockeyApp.TraceWriter.Initialize();

            //// Wire up Unhandled Expcetion handler from Android 
            //AndroidEnvironment.UnhandledExceptionRaiser += (sender, args) =>
            //{
            //    // Use the trace writer to log exceptions so HockeyApp finds them 
            //    HockeyApp.TraceWriter.WriteTrace(args.Exception);
            //    args.Handled = true;
            //};

            //// Wire up the .NET Unhandled Exception handler 
            //AppDomain.CurrentDomain.UnhandledException += (sender, args) => HockeyApp.TraceWriter.WriteTrace(args.ExceptionObject);

            //// Wire up the unobserved task exception handler 
            //TaskScheduler.UnobservedTaskException += (sender, args) => HockeyApp.TraceWriter.WriteTrace(args.Exception);

            Insights.Initialize("faec20791c9e72b9442a82c2ed86839842845b1b", this.ApplicationContext);

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

