# Guide for deploy API

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Setup mysql and workbench, link here: https://dev.mysql.com/downloads/mysql/

Setup IIS, link here: https://www.iis.net/
  - Create User Bluezone and database Bluezone
  - Run sql in file ApiForApp/DB/Bluezone.sql to create structure database
  - Open ApiForApp/web.config to update appsetting connection string database MSSQL
  ```sh
  <add key="MSSQL" value="Server=localhost; Port=3306; Database=bluezone; Uid=Bluezone; Pwd=;CharSet=utf8;" /> 
  ```
  - Deploy Api on IIS


# Guide for send notification to devices (android, ios)

[![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)](https://travis-ci.org/joemccann/dillinger)

Setup nodejs 12.16.2, linkhere: https://nodejs.org/dist/v12.16.2/node-v12.16.2-x64.msi
  - Goto SendNotify folder
  - Open serviceAccountKey.json file -> Update parameters Firebase
  - At SendNotify folder open (cmd, terminal) here and execute command 'npm install' to download library
    ```sh
    $ npm install
    ```
  - Execute command 'npm start' to run port 3000
    ```sh
    $ npm start
    ```
  - Open 'localhost:3000' on browser

### Tech

Bluezone uses a number of open source projects to work properly:

* [Mysql] - Database
* [IIS] - Deploy .NET project
* [Firebase] - Database realtime
* [Bootstrap] - great UI boilerplate for modern web apps
* [node.js] - evented I/O for the backend
* [Express] - fast node.js network app framework
* [jQuery] - duh

And of course Bluezone itself is open source with a [public repository][dill]
 on GitHub.

