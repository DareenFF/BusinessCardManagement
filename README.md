# Business Card Management


## Table of Contents

- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Contributing](#contributing)


## Features
 - list business cards.
 - create a new business card either through a form or through uploading xml or csv files.
 - preview the card before submitting when added through the form.
 - Export all business cards either to XML or CSV files.
 - ability to delete a specific card.
 - filter cards based on Address.

## Installation

1. Clone the repository:
   
   ```git clone https://github.com/fretto/BusinessCardManagement.git```
   
3. Navigate to Backend project

   ```cd backend```
   
4. Restore nuget packages

    ```dotnet restore```
5. build the solution
   
   ```dotnet build```
6. run
   
   ```dotnet run```

   run the client app:
1. Navigate to client app directory ```cd ClientApp```
2. Install node packages ```npm install```
3. build the project ``` ng build ```
4. run the project ```ng serve```


## Database configuration :
1. Using entity framework core:
   
   a.Create the firtst migration
   
   ``` dotnet ef migrations add First migration```
   
   b. Update database
   
   ```dotnet ef database update```


   




   
