using System;
using System.Text;

namespace test
{
	public class VariableParser<Type> : ArithmeticExpressionParser<Type>
	{	
		public static VariableTable<Type> varTable;
		
		public VariableParser ()
			:base()
		{
			varTable = new VariableTable<Type>();
		}
		
		Type ParseVariables ()
		{
			if(Token == '%')
			{
				string key = ParseVariableName();
				
				if(varTable.ContainsKey(key))
				{
					return varTable[key];
				}
				
				else
				{
					throw new Exception(string.Format("No variable called '{0}' exists",key));
				}
			}
			
			return default(Type);
		}
		
		string ParseVariableName ()
		{
			StringBuilder varName = new StringBuilder();		
			
			GetNextToken();
			
			if(!Expression.Contains("%"))
			{
				throw new Exception("Expected '%'");
			}
			
			while(Token != '%')
			{
				varName.Append(Token);
				GetNextToken();
			}
			
			return varName.ToString();
		}
	}
}

