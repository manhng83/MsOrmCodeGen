using System.IO;
using System.Text.RegularExpressions;

namespace Jodo.CodeGenerator.Core.Templating
{
    public class ClassTemplate : TemplateBase
    {
        #region Private Fields

        private string propertiesSection;		

        #endregion

        #region Properties

        public string PropertiesSection
        {
            get 
            {
                if (propertiesSection == null)
                    propertiesSection = GetPropertiesSection();

                return propertiesSection; 
            }
        }
		
        #endregion

        #region Contructors

        public ClassTemplate(FileInfo fileInfo) : base(fileInfo) { }

        #endregion

		/// <summary>
		/// Returns the Property template section of the class file.
		/// Property section must be no more then ten lines in length.
		/// </summary>
		/// <remarks>
		/// TODO: possibly optimize this regex. Right now the number of lines
		//  it will allow is set to 10({1,10}) and it works fine, although as you 
		//  increase the number of lines it can get very slow.
		/// </remarks>
		/// <returns></returns>
        protected virtual string GetPropertiesSection()
        {           
			Regex r = new Regex(@"(?<=\#PropertiesStart\#)((\n*.*){1,10})(?=\#PropertiesEnd\#)");            
            return r.Match(Content).Value;
        }

        public enum Token
        {
            Namespace,
            ClassName,
            PrivateFields,
            PropertiesStart,
            PropertType,
            PropertyName,
            PropertyReturnField,
            PropertySetField,
            PropertiesEnd
        }
    }
}
