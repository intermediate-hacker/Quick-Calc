using System;
using System.Collections.Generic;

namespace test
{
	class MainClass
	{
		public static void ShowIntro()
		{	
			Console.WriteLine("========================================================");
			Console.WriteLine("{ ~Quick Calculations~ V 1.0 By Muhammad Ahmad Tirmazi }");
			Console.WriteLine("{ For more help and contact information run program    }");
			Console.WriteLine("{ with the '--help' and '--info' command line arguments}");
			Console.WriteLine("========================================================");
		}
		
		public static void Main (string[] prim_args)
		{
			var args = new List<string>(prim_args);
			HandleArguments(args);
		}
		
		public static void HandleArguments(List<string> args)
		{
			if(args.Contains("--info"))
			{
				DisplayMoreInfo();
			}
			
			
			else if(args.Contains("--help"))
			{
				DisplayHelp();
			}
			
			else if(args.Contains("--silent"))
			{
				StartParser();
			}
			
			else
			{
				ShowIntro();
				StartParser();
			}
			
			if(args.Contains("--run"))
			{
				ShowIntro();
				StartParser();
			}
		}
		
		public static void StartParser()
		{			
			var arithparser = new ArithmeticExpressionParser<decimal>();
			string input = string.Empty;
			
			while(true)
			{
				try
				{
					Console.Write(">>>");
					input = Console.ReadLine();
					Console.WriteLine(arithparser.Parse(input));
				}
				catch(Exception e)
				{
					if(input == "exit")
						Environment.Exit(0);
					else
						Console.WriteLine("Error: {0}",e.Message);	
				}
			}
		}
		
		public static void DisplayMoreInfo()
		{
			Console.WriteLine("Program Name: ~Quick Calculations~");
			Console.WriteLine("Description: 'A quick calculator for home and office use'");
			Console.WriteLine("Programmer: 'Muhammad Ahmad Tirmazi'");
			Console.WriteLine("Creation Date: 'January 4 , 2011'");
			Console.WriteLine("License: 'MIT License'");
			Console.WriteLine("Contact: smat1995@gmail.com");
			Console.WriteLine("Address: Flat-6, Building Opp. Al-Maha Super-Market");
			Console.WriteLine("         Al-Buraimi , Sultanate of Oman");
		}
				
		public static void DisplayHelp()
		{
			string help = 
@"'Quick Calculations' is a simple Console Calculator Made for Home and
Office Use.

qcalcs [options]
--info     About 'Quick Calculations'
--help      Display More Info
--silent    Do not display introductory text and logo
--run        Run the program after arguments. 

Note: normally the calculator does not run if you pass
and argument like '--help' or '--info', however including
'--run' will indefinitely run the program after the arguments 
have been processed.

in program:
type your expression after '>>>'
type 'exit' to quit program
";
			
			Console.WriteLine(help);

		}
	}
}
