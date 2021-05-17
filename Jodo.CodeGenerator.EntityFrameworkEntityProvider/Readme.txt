Overview:

This implementation of an IEntityProvider relies on generating Entity Framework complient code
using the Microsoft provided Entity Framework code generator (Edmgen.exe).

Once the Edmgen.exe generates the necessary code and associated xml mapping files, 
the files will parsed to rename classes and properties to the Pascal Case naming convention and 
to extract a collection of IEntity objects that will be passed to the ICodeGenerator.

Program Flow:

First - the Edmgen.exe is executed in FullGeneration mode in order to generate a complete
set of Entity Framework data access files.

Second - the generated .ssdl file is parsed in order to create a new
.ssdl file with all classes and properties following the Pascal Case naming convention.
The altered .ssdl is then saved over top of the previously generated version.
(Note: Edmgen.exe does not enforce that object code be created with Pascal Case classes and properties. It will create 
classes and properties using the same exact names as the database tables and columns. This is not desirable.)

Third - the Edmgen.exe is executed in FromSSDLGeneration mode in order to generate a complete
set of Entity Framework data access files from the altered .ssdl created in the previous step.
We now have a complete set of Entity Framework data access files with classes and properties 
in the Pascal Case naming convention.

Building the CodeGenerator.Core.Entities.IEntity collection:

There are many ways to skin this cat, but this implementation simply reads the CSharp code generated
by the Edmgen.exe one line at a time and looks for patterns that allows IEntities to be identified.

This method works fairly quickly and will be reliable provided the Edmgen.exe does not change its
generation output.
