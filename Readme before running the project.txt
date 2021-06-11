Here are the steps for you to run the project onto your local machine.

1. Map the back-end code first into your local machine.
2. Double Click on the "Assignment-Back-end.sln" file in order to open the application into your local machine. MAke sure, you use visual studio 2019 community edition in order to run the back-end application.
3. Once the application is opened,install all the dependencies which are required to run the back-end application.
4. When you successfully download the dependencies, go to the appsettings.json file and change the connection string with your local MSSQL server local connection string.
5. Once changed, go to the tools section of the topbar menu, go to NuGet Package Manager -> Package Manager Console.
6. run the command as "update-database" in order to generate a table in the database of your local machine.
7. Once successfully done with the migration, run the application, by clicking on IIS Express.
8. Once the application is set up, make sure you copy the port number from the link which gets opened in the browser, when you run the application.
9. Map the Assignment-FrontEnd project into your local machine.
10. Open the project either by using visual studio code or visual studio community edition.
11. Once the project is opened, look for the file EndpointConst.ts for replacing the port number which you previously copied,with the port number which is mentioned in that file. 
12. Open the command prompt and navigate it till the location where you have mapped the angular project.
13. Restore the packages that are required for running the application by running a command as "npm install" in your command prompt. The command prompt will help you in restoring the package.
14. Once all the packages are restored, run the command as "ng serve --o" in your command prompt for running an angular made application for front-end.
15. Make sure you keep the back-end front-end project running in order to use the application.

 