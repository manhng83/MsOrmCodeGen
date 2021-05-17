using System;

namespace Jodo.CodeGenerator.Core.Generator
{
	public class CodeGenerationCompletedArgs : EventArgs
	{		
		public ICodeGenerator CodeGenerator { get; private set; }

		public CodeGenerationCompletedArgs(ICodeGenerator codeGenerator)
		{		
			CodeGenerator = codeGenerator;
		}
	}
}
