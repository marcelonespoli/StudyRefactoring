using Example1_Refactoring.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace Example1_Refactoring.Reports
{
    public class CustomerStatementReport
    {
        public string Statement(Invoice invoice, List<Play> plays)
        {            
            return RenderPlainText(new StatementData().Create(invoice, plays));
        }        

        public string RenderPlainText(StatementData data)
        {            
            var result = $"Statement for { data.Customer}\n";

            foreach (var perf in data.Performances)
            {
                // print line for this order
                result += $" { perf.Play.Name}: { Usd(perf.Aumont / 100)} ({ perf.Performance.Audience} seats)\n";                
            }

            result += $"Amount owed is { Usd(data.TotalAumont / 100) }\n";
            result += $"You earned { data.TotalVolumeCredits } credits\n";
            return result;
        }

        public string HtmlStatement(Invoice invoice, List<Play> plays)
        {
            return RenderHtml(new StatementData().Create(invoice, plays));
        }

        public string RenderHtml(StatementData data)
        {
            var result = $"<h1> Statement for { data.Customer }</h1>\n";
            result += "<table>\n";
            result += "<tr><th>play</th><th>seats</th><th>cost</th></tr>";
            foreach (var perf in data.Performances)
            {
                result += $"<tr><td>{ perf.Play.Name}</td><td>{ perf.Performance.Audience}</td>";
                result += $"<td>{ Usd(perf.Aumont)}</td></tr>\n";
            }
            result += "</table>\n";
            result += $"<p> Amount owed is <em> { Usd(data.TotalAumont)} </em></p>\n";
            result += $"<p> You earned <em> { data.TotalVolumeCredits} </em> credits </p>\n";
            return result;
        }

        private string Usd(decimal value)
        {
            var usCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = usCulture;
            var format = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            format.CurrencySymbol = "$";
            return value.ToString("c", format);
        }
    }
}
