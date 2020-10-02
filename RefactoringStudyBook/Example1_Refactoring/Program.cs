using Example1_Refactoring.Data;
using Example1_Refactoring.Reports;
using System;

namespace Example1_Refactoring
{
    class Program
    {
        static void Main(string[] args)
        {
            var plays = RequestData.GetPlays();
            var invoice = RequestData.GetInvoice();

            var result = new CustomerStatementReport().Statement(invoice, plays);

            Console.WriteLine(result);

            result = new CustomerStatementReport().HtmlStatement(invoice, plays);

            Console.WriteLine(result);
            Console.ReadLine();
        }

    }
}
