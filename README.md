# docker-kube-test-1
Testing Docker / Kubernetes / Vs Code Dev Environments

# Requirements (Windows)
- [Docker Desktop](https://docs.docker.com/docker-for-windows/install/)
- [VS Code](https://code.visualstudio.com/download)

# Running/Debugging the MVC project
- Open a new command window and change to your local projects directory, e.g. `cd c:\projects`
- Git clone into a local directory: `git clone https://github.com/abeardsley-vertex/docker-kube-test-1.git`
- Change into the new project directory: `cd docker-kube-test-1`
- Open the project in VS Code: `code .`
- Go to the `Run and Debug` window: View > Run or `Ctrl+Shift+D`
- Make sure `.NET Core Launch (MVC)` is selected in the top "Run and Debug" dropdown
- Press F5 to launch the app for debugging
- You will maybe/probably get an exception that the database is not avaiable, this is because SQL Server hasn't fully started when the MVC Web application runs for the first time.
- If this happens return to VS Code, press the red square/stop buttonm and then F5 again to re-launch the app.
- You should see the app launch and load in a browser.

# Running the Web API Project
- Perform the steps for `Running/Debugging the MVC project` but choose `.NET Core Launch (Web API)` instead.

# Running the Wordpress Project
- From the command line (or the terminal within vscode) for the project run `docker compose up -d wordpress`
- Open a browser and navigate to http://localhost:5003
- Live the MVC project above, if you get a database connection error in the browser, wait a few seconds and then reload the page, the database was probably not fully running.

# Other notes:
- If you want to make sure the database is running in Docker, open up Docker desktop and you should see it is running in a container on port 1499.

# FAQ
## Why is SQL Server running on port 1499 instead of 1433 like a *normal* SQL Server?  
You cannot run a named instance with the Docker SQL Server image, only expose it on a different port.   
If it was exposed on the normal 1433 port it might conflict with other locally-running SQL Servers (like SQLEXPRESS).  

## Does that mean the Docker containers all communicate with SQL Server on port 1499 too?
No.  When/if you run all Docker containers together (i.e. if you were to run `docker compose up --build -d`) then they all communicate on their "internal" network and the ports specified there.  

## Can I connect to the SQL Server Docker Database from SSMS?  
Yes! Go to open a new database connection in SSMS like you normally would and then enter the following for connection details:  
Server name: `localhost,1499`  
Login: `sa`  
Password: `Password123`  

## Where is the SQL Server Data?
The data for the SQL Server database is stored in a project-local folder: `.sqldatafiles`.  These are *NOT* committed to source control.  
Entity Framework is responsible for creating and populating the SQL Server Database.

## Where is the My SQL Data stored?
In a docker volume.



