# BikeStoreMVC
Bike Store demo app for Redweb. Created using MVC in Visual Studio 2015  

Normalised database and all project files included.

Deliverables 
* Created normalised SQL database
* Created MVC app using Entity Framework Database First
* Products can be added, updated and deleted from the database
* Products page features paging
* Product code and name can be searched
* Category, Sub Category and Model can be sorted.
* Created Metadata class to provide data annotations and validation
* Source control using GIT

Bugs
* Issue when editing a product, category ddl needs changing from it's selected item to trigger the sub cat and model drop down changes.
* Colour and Size table need to allow null for their descriptions as some products may not have this data.  Alternative would be to add a new 'NA' option and update the Nulls to this.
