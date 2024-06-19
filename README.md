<h1>Setup Project</h1>

### Clone this project to your machine
```git
git clone https://github.com/Nik211885/rooms_manager_api.git
```
Cd src befor open source project in VsCode 


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
In Jwt Object put key, this key make signature to jwt authorization
Value in Jwt
Issuer : indicate that where the whole Jwt you have come from.
Audience: Claim in jwt

Finnaly information to connection string and jwt make secert so let put all in secert file 
In VsCode Install extnesion .NET Core User Secrets and left click to src.csproj and choose Manage User Secret
![image](https://github.com/Nik211885/rooms_manager_api/assets/119054771/f2eee85f-8027-49e6-88f3-39d829f49f49)

Put all information secret in here and this file always overide to appsetting.json


### Migration 
Open terminal in this project and run 

Create Migeration
```dotnet
dotnet ef migrations add InitialCreate
```
Create Database
```dotnet
dotnet ef database update
```

### Seeeder Data
If you want change information about entiy open seeder data and change information if you want

![image](https://github.com/Nik211885/rooms_manager_api/assets/119054771/1801b232-b5ef-44a1-8190-faead360a27e)

### Run App
In terminal run 
```dotnet
dotnet watch
```

