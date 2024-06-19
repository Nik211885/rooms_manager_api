<h1>Setup Project</h1>

### Clone this project to your machine
```git
git clone https://github.com/Nik211885/rooms_manager_api.git
```
Open project in VsCode


I use database is SqlServer if you want changed database you need instaled nuget package related and open Program file in solution and change options in DbContext

![image](https://github.com/Nik211885/rooms_manager_api/assets/119054771/daf09534-9672-4d17-adf6-0e3e105efd17)

### Setup appsetting
Open file appsetting.json
![image](https://github.com/Nik211885/rooms_manager_api/assets/119054771/d3f21852-0a6a-4584-902b-c698fc3f2346)
 Put your connection string to ConnectString:DefaultConnection
[Connection Strings Reference](https://www.connectionstrings.com/)
```connectstring
Server=ServerName;Database=RoomsManager;Trusted_Connection=False;Integrated Security=true;TrustServerCertificate=True"
```

### Migration 

