# CityGuideBackend

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## Installation
1. Clone the repository.
```sh
git clone https://github.com/oguzhankaymak/CityGuideBackend.git
```
2. New account create necessary in Cloudinary. Because Cloud Name, Api Key and Api Secret infos must write in <b>app.settings.json</b>. These infos positions like "--"  define in app.setting.json  
```sh
https://cloudinary.com/users/register/free
```
3.  You must add migration in Data Access Layer and do database update
```sh
dotnet ef migrations add FirstMigration

dotnet ef database update
```

## Usage
```sh
Visual Studio Code 

dotnet watch run
```

