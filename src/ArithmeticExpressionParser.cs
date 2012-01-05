using System;
using System.Text;

namespace test
{
	public class ArithmeticExpressionParser<Type> : Parser
	{
		public Type Result;
		
		public override string Parse (string expr)
		{
			 base.Parse(expr);
			 return ParsePlusMinus().ToString();
		}
		
		protected virtual Type ParsePlusMinus()
		{		
			dynamic t = ParseDivideMultiply();
			
			if(Token == '+')
			{
				GetNextToken();
				
				t += ParsePlusMinus();
			}
			
			else if(Token == '-')
			{
				GetNextToken();
				
				t -= ParsePlusMinus();
			}

			return t;
		}
		
		protected virtual Type ParseDivideMultiply()
		{
			dynamic t = ParseDigit();
			
			if(Token == '/')
			{
				GetNextToken();
				
				t /= ParseDivideMultiply();
			}
			
			else if(Token == '*')
			{		
				GetNextToken();
				
				t *= ParseDivideMultiply();
			}
			
			else if(Token == '%')
			{				
				GetNextToken();
				
				t %= ParseDivideMultiply();
			}
														
			return t;
		}
		
		protected virtual Type ParseDigit()
		{
			StringBuilder digit = new StringBuilder();
			
			while(char.IsDigit(Token) || Token == '.')
			{				
				digit.Append(Token);
				
				GetNextToken();
			}
						
			return (Type)Convert.ChangeType(digit.ToString(), typeof(Type));
		}
	}
}

