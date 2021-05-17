using System;
using System.Collections.Generic;
using Jodo.CodeGenerator.Core.Entities;

namespace Jodo.CodeGenerator.Core.Generator
{
	public interface ICodeGenerator
	{
		/// <summary>
		/// Generates code for the provided list of <see cref="IEntity"/>s.
		/// </summary>
		/// <param name="entities"></param>
		void GenerateCodeFor(IEnumerable<IEntity> entities);

		/// <summary>
		/// Provides access to the generated code that is available after calling 
		/// the GenerateCodeFor method.
		/// </summary>
		/// <returns></returns>
		string GetCodeOutput();

		/// <summary>
		/// Event that fires after the generation process has completed.
		/// </summary>
		event EventHandler<CodeGenerationCompletedArgs> CodeGenerationCompleted;
	}
}
