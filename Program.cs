// See https://aka.ms/new-console-template for more information
using System.Globalization;
using TradeAdmissionTest;
using TradeAdmissionTest.Contracts;

Console.WriteLine("Welcome");
Console.Write("Please type a reference date: ");
var refDateInput = Console.ReadLine();
Console.WriteLine("");

DateTime refDate;
if (!DateTime.TryParse(refDateInput, new CultureInfo("en-US"), out refDate))
{
    Console.WriteLine("The ref date must a date on USA format");
}


Console.Write("Please type the number of trades: ");
var numTradesInput = Console.ReadLine();
int numTrades;
if (!int.TryParse(numTradesInput, out numTrades))
{
    Console.WriteLine("The trades quantity must be a number");
}

string[] trades = new string[numTrades];

Console.WriteLine("Please type the trades space separated.");
for (int x = 0; x < numTrades; x++)
{
    Console.Write($"{x} : ");
    trades[x] = Console.ReadLine();
}

List<ITrade> tradesList = new List<ITrade>();

foreach( string tradesInput in trades)
{
    var trade = new Trade(tradesInput, refDate);
    tradesList.Add(trade);
    Console.WriteLine(trade.Category);
}

