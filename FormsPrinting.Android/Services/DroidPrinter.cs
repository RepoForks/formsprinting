using System;
using Android.Content;
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
        		// Only valid for API 19+
        		var version = Android.OS.Build.VERSION.SdkInt;

        		if (version >= Android.OS.BuildVersionCodes.Kitkat)
        		{
        			var printMgr = (PrintManager)Forms.Context.GetSystemService(Context.PrintService);
                    var documentAdapter = webView.CreatePrintDocumentAdapter();
                    printMgr.Print("Forms-EZ-Print", documentAdapter, null);
             }
        }
    }
}
