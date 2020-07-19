# TestProject
1.	Project -  Evolent Health Test UI
    Technology used: Angular 6
  Steps to Run the Project:
    1.	Open Project in Visual Studio code
    2.	Change Base Api URL in environment.ts file to access web api
        apiURL: 'http://localhost:53339/api/’
    3.	Run ng serve command in visual studio command 
    4.	if you are facing any dependency issue please run npm install command

2.	Project – EvolentHelathTestApi
    Technology used:  .NET core Web API 2.0 
    Testing Framework: Nunit
    Database: MySql 
  Steps to Run the Project:
    1.	Open Project in Visual Studio both project will be open in same solution EvolentHelathTestApi & NunitTestEvolent.
    2.	Change database connection string in Startup.cs file
    3.	Run scripts form script file to create table and store procedures
    4.	Then build project and run from visual studio
    5.	Set same base api URL in angular project
    
3.	Project – NunitTestEvolent
    Technology Used: NUnit Framework 
  Steps to Run the Project:
    1.	Build project from visual studio
    2.	Then open Test Explorer from View menu
    3.	Right click on ContactControllerTest and run test cases

