## Exercise
Create a console app that reads a csv file that contains the information of a groups of developers classified by type. 
A developer might be classified in one of the following types: 
- Junior 
- Intermediate 
- Senior 
- Lead 
  
Once you read the csv file it will be required to map each row in a defined type and then print all the information in the console in the following way.<br>
**Dev Name:** John Doe<br>
**Dev Type:** Junior<br>
**Worked Hours:** 40<br>
**SalaryByHour:** 120 USD

### Increase Requirement
Instead of reading the data from a csv file you should read it from a simple table configure in a database 

### Increase Requirement 
Once you have all the developer data read done. You should create a method that calculates the salary of a list of developers and print the data in the console.

```c#
// Salary Rules
BaseRule => Hours*SalaryByHour 
Junior => BaseRule 
Intermediate => BaseRule * 1.12 
Senior => BaseRule * 1.25 
Lead => BaseRule * 1.5 

//Format to print the data: 
Dev Name: John Doe 
Dev Type: Junior 
Worked Hours: 40 
SalaryByHour: 120 USD

Resume: 
Total Salary: 1500 USD 
Total Hours: 90 
Total Devs: 4 
```

### Skills to evaluate
- File stream operations
- Model definition
- Value types (float, integers, string)
- Single Responsibility
- Polymorphism 
- Strategy Pattern 
