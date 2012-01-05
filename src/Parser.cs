using System;

namespace test
{
	public class Parser
	{
		public string Expression;		
		public string OriginalExpression;
		
		public Parser ()
		{					
		}		
		
		public virtual string Parse(string expr)
		{
			Expression = OriginalExpression = expr;	
			return string.Empty;
		}
		
		public char Token
		{
			get
			{
				if(string.IsNullOrEmpty(Expression))
					return default(char);
				while(char.IsWhiteSpace(Expression[0]))
					GetNextToken();
				
				return Expression[0];
			}	
		}
		
		public void GetNextToken()
		{
			Expression = Expression.Substring(1);				
		}
	}
}

