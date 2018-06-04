# UnitData


unit data made for unit/Integration testing.
with the help of unitdata you can create a dummy database on your local db connection.


what you can do with unitdata:
1. create database 
2. create tables in created data 
3. create functions, PS
4. seed tables with data in xml format
5. create setup (by running this tool on actual db, it will give "create table query” and "data in xml files" for given table (in xml file we will have table rows data))
6. execute any query on db 

setup the unitdata:

1. clone this repo to your local and include in your solution.
2. Attached the reference of this project to your testing project.
3. in app/web config of your project add local db with key: "TEST"
	eg: 
  <connectionStrings>
    <add name="Test" connectionString="Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True" providerName="System.Data.SqlClient" />
  </connectionStrings>
  
4. setup the data with helper method 
	-  to setup the data for testing use "UnitData.DataSetup(dbname, dirpath, connectionstring, prefix)"
	where 
	dbname is your database name.
	dirpath is where you want to dump your xml and sql files.
	connectionString is your actual database connection string.  this tool only read your data its not doing (insert,update,delete) in your actual database.
	prefix if you want some type of prefix on your sql and xml file name.
	
5. create database 
	To create database you have to call "UnitData.CreatDatabase(schemaFilePath, connectionString, location, dbname);"
	schemaFilePath - this file contains whatever you want to insert in your newly created database.
	connectionString - connection String of your local db 
	location - where you want to setup db phycically (.mdf,.ldf files)
	dbname - name of the db you want to create
	
6. seed table
	To seed the tables you need to call " UnitData.SeedTable(dbName,tableName,seedFilePath,connectionString,datetymetype)"
	dbname is your database name.
	tableName is table name in which you want to seed data.
	seedFilePath  file path from which you want to seed.
	connectionString - connection String of your local db 
	datetymetype : its a style of your datatime ref: https://www.w3schools.com/sql/func_sqlserver_convert.asp

	
after this setup you can use your localdb connection string as real connection string for your tests.


* don't go for design and architecture of this project ill update this soon.  
