## __Companies__

Create a Web Application written in C# (.NET Core or .NET Framework) + Angular (or any other framework) wich:
1. Reads a list of companies with accompanying information from files formatted in different ways and compile it into one master list that is then displayed on screen.
2. The data should be sortable in at least the following ways through the user interface:
    * By company name
    * By contact name
    * By years in business, then company name
3. The screen should allow exporting to __CSV__ using the current sorting.

__Input files and format:__
* The input file comma.txt will have a comma as a delimiter, and have fields in the order: __Company Name__, __Contact Name__, __Contact Phone Number__, __Years in business__, __Contact Email__
* The input file hash.txt will have a hash tag as a delimiter, and have fields in the order: __Company Name__, __Year Founded__, __Contact Name__, __Contact Phone Number__
* The input file hyphen.txt will have hyphen as a delimiter, and have fields in the order: __Company Name__, __Year Founded__, __Contact Phone Number__, __Contact Email__, __Contact First Name__, __Contact Last Name__

Data should be processed and displayed in the browser, in the following columns, whenever available:
* __Company Name__, __Years in Business__, __Contact Name__, __Contact Phone Number__, __Contact Email__

---

## Technical details:
* Project Name: Companies.sln
* Web Application
* .Net 6 + Angular v.14
* Visual Studio 2022
