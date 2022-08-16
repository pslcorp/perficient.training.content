## Excercise
Create a web API that manages employment information and calculates the salary of the developers who work for it. 
 
In order to store the developer information, it will be necessary to design a database model that satisfies the following criteria.
 
Developer attributes: 
- First name 
- Last name 
- Full name -> The concatenation of the First name + Last name 
- Age 
- Worked hours 
- Salary by hours 
- Developer type 
- Email 

A developer might be classified in one of the following types: 
- Junior 
- Intermediate 
- Senior 
- Lead 

The requirements for the web API are basically exposes a swagger page to access each of the methods the API exposes.<br>
The solution should expose the capability of
- Create a developer:  This functionality should receive and validate as a parameter the developers attributes such as: 
    - First name: 3 characters of minimum length and 20 characters of max 
    - Last name: 3 characters of minimum length and 30 characters of max 
    - Age: Greater than 10 and numeric 
    - Worked hours: Greater than 30 and less than 50 
    - Salary by hours: Greater than 13 
    - Developer type: Must be one of the accepted dev type Junior, Intermediate, Senior, and Lead 
- Get the developer list information 
- Search a developer by criteria: First name, Last name, Age, Worked Hours (Return a list of devs that met the criteria) 
- Get developer by email (Return dev object is found and null/empty if not) 
- Delete a developer by passing the email 
- Update the developer information: For this the payload can be the same passed in the create developer and the validations should be the same 

### Material
- https://docs.microsoft.com/en-us/azure/architecture/best-practices/api-design 
- https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-6.0&tabs=visual-studio 
- https://tomasznowok.medium.com/generic-repository-unit-of-work-patterns-in-net-b830b7fb5668 
- https://www.programmingwithwolfgang.com/repository-pattern-net-core/ 

