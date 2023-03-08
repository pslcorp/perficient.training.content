## Exercise
Create a console app that runs a background process to print the current time of the following cities each 30 seconds.<br>


| City  | TimeZone  |
|---|---|
| Bogota  | America/Bogota |
| Chicago | America/Chicago   |
| Argentina  | America/Argentina/Buenos_Aires  |
| Detroit  | America/Detroit   |
| London  | America/London   |

This information should be stored as a private static [read only collection](https://docs.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.readonlycollection-1?view=net-6.0).

Once you read the information you should print the information in the following format.<br>

```c#
City: Bogota 
TimeZone: America/Bogota 
Time:2022-05-06T14:29:00.5-05:00

City: Chicago 
TimeZone: America/Chicago 
Time: 2022-05-06T14:29:00.5-05:00

City: Argentina 
TimeZone: America/Argentina/Buenos_Aires 
Time: 2022-05-06T16:29:00.5-05:00

City: Detroit 
TimeZone: America/Detroit 
Time: 2022-05-06T15:29:00.5-05:00

City: London 
TimeZone: Europe/London 
Time: 2022-05-06T20:29:00.5-05:00
``` 
 
**TimeZone Package:** [repo](https://github.com/mattjohnsonpint/TimeZoneConverter)<br>
**TimeZone Country List:** [link](https://en.wikipedia.org/wiki/List_of_tz_database_time_zones)<br>
**TimeStringFormat:** yyyy-MM-dd'T'HH:mm:ss.FFFzzz

### Increase
Encapsulate the time converter implementation in a single class (TimeService/TimeProvider) and inject it in the hosted/background service as Transient, Singleton and then Scoped.<br>

**Note:** For this one Scoped the idea is to see how this behaves in a hosted service as it is not the same for the others. See more info [here](https://docs.microsoft.com/en-us/dotnet/core/extensions/scoped-service).

### Increase
Read the info for the cities from a different source. Instead of having it as an static read only collection read it from a database.
 

### Increase
Display a message once the service is stopped:
```c# 
"Background service completed" 
```

### Material
- [Hosted services](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-6.0&tabs=visual-studio)
- [Worker services in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/workers)
