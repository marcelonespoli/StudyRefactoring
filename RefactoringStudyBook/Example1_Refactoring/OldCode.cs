using Example1_Refactoring.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Linq;

namespace Example1_Refactoring
{
    /*
        Copy of the code on initiate state before to be refactored 
        Based on book Refactoring of Martin Fowler
    */

    public class OldCode
    {
        public string Statement(Invoice invoice, List<Play> plays)
        {
            var totalAmount = 0;
            decimal volumeCredits = 0;
            var result = $"Statement for { invoice.Customer}\n";
            CultureInfo usCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = usCulture;
            NumberFormatInfo format = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
            format.CurrencySymbol = "$";

            foreach (var perf in invoice.Performances)
            {
                var play = plays.FirstOrDefault(x => x.Id == perf.PlayId).Details;
                var thisAmount = 0;

                switch (play.Type)
                {
                    case "tragedy":
                        thisAmount = 40000;
                        if (perf.Audience > 30)
                        {
                            thisAmount += 1000 * (perf.Audience - 30);
                        }
                        break;
                    case "comedy":
                        thisAmount = 30000;
                        if (perf.Audience > 20)
                        {
                            thisAmount += 10000 + 500 * (perf.Audience - 20);
                        }
                        thisAmount += 300 * perf.Audience;
                        break;
                    default:
                        throw new Exception($"unknown type: { play.Type }");
                }


                // add volume credits
                volumeCredits += Math.Max(perf.Audience - 30, 0);
                // add extra credit for every ten comedy attendees
                if ("comedy" == play.Type) volumeCredits += perf.Audience / 5;

                // print line for this order
                result += $"  { play.Name}: { (thisAmount / 100).ToString("c", format)} ({ perf.Audience} seats)\n";
                totalAmount += thisAmount;
            }

            result += $"Amount owed is {(totalAmount / 100).ToString("c", format)}\n";
            result += $"You earned {volumeCredits} credits\n";
            return result;
        }
    }
}
