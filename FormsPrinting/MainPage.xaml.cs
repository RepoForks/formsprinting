using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormsPrinting.Templates;
using FormsPrinting.Services;
using Xamarin.Forms;

namespace FormsPrinting
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

		protected void Handle_Clicked(object sender, System.EventArgs e)
		{
            var ticket = new Ticket
            {
                Amount = 1302,
                Customer = "Neil Armstrong",
                OrderId = 12312
            };

            var template = new TicketTemplate();
            template.Model = ticket;

            var rendered = template.GenerateString();


            // Create a source for the webview
            var htmlSource = new HtmlWebViewSource();
            htmlSource.Html = rendered;

            // Create and populate the Xamarin.Forms.WebView
            var browser = new WebView();
            browser.Source = htmlSource;

            var printService = DependencyService.Get<IPrinter>();
            printService.Print(browser);
        }
	}
}
