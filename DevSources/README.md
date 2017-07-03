# Dev Sources 

Repositories for Analysis on the Acquisition Process Hackfest

## [Angular Front-end Dev](AngularWebDev/)

- Source codes for Web front-end UI that communicate with [Microsoft Bot App](https://dev.botframework.com/)
- deveploed with modern web-techs like Angular 4, [TypeScript](https://www.typescriptlang.org/), Angular CLI, Bootstrap, etc.
- included Power BI Embedded UI for analysis report
- also included Web Chat Bot and Skype Web Chat Bot for communicating with Bot app

## [Azure Resource Group Dev](AzureResourceGroupDev/)
- Azure resource template and parameter file for deploying Azure resources of Analysis Acquisition system.
- Azure resource template files can be used for rebuilding their existing resources of current system or deploying a new Azure resources to customer's Azure environment.

## [Bot Dev](BotDev/)

- Source code for Bot app(UBone Bot)
- developed with [Microsoft Bot framework](https://dev.botframework.com/) using C#, ASP.NET
- used multi-dialogs for conversation flow
- User can send/upload a document file(PDF only now) to Bot for asking analysis
- Bot simply rename it for preventing file-name duplicattion and forward it to Azure Blob storage for following analysis process

## [Function Apps Dev](FunctionAppsDev/)
- Used Azure Functions feature for embracing elastic and reactive serverless hosting model.
- [ConvertPdfToTextDocument](FunctionAppsDev/wwwroot/ConvertPdfToTextDocument) is for converting pdf file the customer uploaded into multiple image files(png format) per page and making up the document file from recognized result through cognitive services(Vision API, OCR) 
 - [SendTextToTextAnalytics](FunctionAppsDev/wwwroot/SendTextToTextAnalytics) is in charge of transferring documentation [ConvertPdfToTextDocument](FunctionAppsDev/wwwroot/ConvertPdfToTextDocument) made up to Ubiqone TextAnalytics Service. 





## [Logic Apps Dev](LogicAppDev/)
- 

## [SQL Dev](SQLDev/)
- Migrating schemas and data from Oracle database into Azure SQL Databases
- Creating Stored procedures for retrieving and inserting data into Azure SQL databases

## [Power BI Dev](PowerBIDev/)
- Creating Power BI Reports based on inserted data to Azure SQL databases
- Power BI report is connected to Azure SQL database using Direct Query and report is configured to refresh data on a regular basis

### Utilized Technologies
> Angular, TypeScript, Bootstrap, ASP.NET Core, Bot Framework, App Service(Web App), Azure Functions, Azure Logic App, SQL Database, Power BI, etc.