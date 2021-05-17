using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using Jodo.CodeGenerator.Core.Entities;
using Jodo.CodeGenerator.Core.Generator;

namespace CodeGeneratorFake
{
	[Export(typeof(ICodeGenerator))]
	[PartCreationPolicy(CreationPolicy.NonShared)]
	public class CodeGenerator : ICodeGenerator
	{
		public void GenerateCodeFor(IEnumerable<IEntity> entities)
		{
			// do nothing
		}

		public string GetCodeOutput()
		{
			return "CodeGeneratorFake Output";
		}

		public event EventHandler<CodeGenerationCompletedArgs> CodeGenerationCompleted;
	}
}
