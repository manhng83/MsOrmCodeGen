using System;
using System.IO;

namespace Jodo.CodeGenerator.Core.Templating
{
    public class TemplateBase
    {
		private CodeTypeEnum codeType;
		private string content; 
        private FileInfo templateFile;            
        private const string tokenQualifier = "#";	
		
		public CodeTypeEnum CodeType
		{
			get { return codeType; }
		}

		public string Content
		{
			get { return content; }
		}

        public TemplateBase(FileInfo fileInfo)
        {
            if (!fileInfo.Exists)
                throw new ArgumentException(string.Format("The fileInfo or filePath supplied '{0}' does not contain a valid file", fileInfo.FullName));
            
            this.templateFile = fileInfo;
            Load();

			if (content.Contains(" class "))
				codeType = CodeTypeEnum.Class;
			else if (content.Contains(" interface "))
				codeType = CodeTypeEnum.Interface;
			else 
				codeType = CodeTypeEnum.Undefined;
        }      
		        
        public void ReplaceSection(string section, string replacementValue)
        {
            ReplaceSection(section, replacementValue, null);
        }

        public void ReplaceSection(string section, string replacementValue, params string[] tokensToRemove)
        {
            content = content.Replace(section, replacementValue);

            foreach (string token in tokensToRemove)
                content = content.Replace(FormatToken(token), String.Empty);
        }

        public void ReplaceToken(string token, string replacementValue)
        {
            content = ReplaceToken(content, token, replacementValue);          
        }

        public string ReplaceToken(string source, string token, string replacementValue)
        {
            return source.Replace(FormatToken(token), replacementValue);
        }

		public void InsertContent(int startIndex, string value)
		{
			content = content.Insert(startIndex, value);
		}	

        public string GetOutput()
        {
            return content.ToString();
        }

		private void Load()
		{
			using (TextReader sr = new StreamReader(templateFile.FullName))
				content = sr.ReadToEnd();
		}

        private string FormatToken(string token)
        {
            return String.Format("{0}{1}{2}", tokenQualifier, token, tokenQualifier);
        }		
    }
}
