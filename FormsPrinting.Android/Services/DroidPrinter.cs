using System;
using Android.Content;
using Android.OS;
using Android.Print;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using DroidWebView = Android.Webkit.WebView;

namespace FormsPrinting.Droid.Services
{
    public class DroidPrinter
    {
        public void Print(WebView viewToPrint)
        {
            var renderer = Platform.CreateRenderer(viewToPrint);
            var webView = renderer.ViewGroup.GetChildAt(0) as DroidWebView;

            if (webView != null)
            {
                var version = Build.VERSION.SdkInt;

                if (version >= BuildVersionCodes.Kitkat)
                {
                    PrintDocumentAdapter documentAdapter = webView.CreatePrintDocumentAdapter();
                    var printMgr = (PrintManager)Forms.Context.GetSystemService(Context.PrintService);
                    printMgr.Print("Forms-EZ-Print", documentAdapter, null);
                }
            }
        }
    }
}