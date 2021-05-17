using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using Jodo.CodeGenerator.Core.Entities;

namespace Jodo.CodeGenerator.MsOrmCodeGen.Entities
{
	[Export(typeof(IEntity))]
    public class Entity : IEntity
    {
        private string nameSpace;
		private IList<IPropertyMember> properties;

		/// <summary>
		/// Returns "DefaultNamespace" if not set.
		/// </summary>
        public string NameSpace 
        {
            get
            {
                if(String.IsNullOrEmpty(nameSpace))
                    nameSpace = "DefaultNamespace";
                return nameSpace;
            }
            set { nameSpace = value;}
        }  

		/// <summary>
		/// The name of the Entity.
		/// </summary>
        public string Name { get; set; }	
	
		/// <summary>
		/// The code that has been generated for this Entity.
		/// </summary>
        public string GeneratedCode { get; set; }

		/// <summary>
		/// Return the collection of <see cref="IPropertyMember"/>s,
		/// ordered by Name.
		/// </summary>
		public IList<IPropertyMember> Properties 
		{
			get { return properties.OrderBy(p => p.Name).ToList(); }
			set { properties = value; }
		}

		/// <summary>
		/// Returns the value for the GeneratedCode property.
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return GeneratedCode;
		}
    }
}
