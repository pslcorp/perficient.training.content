## Exercise
Create a console app that will receive as a parameter the developer user email e.g. `Sincere@april.biz`. Based on the entered user email get the user personal information and the user ToDos list by calling following services.

- https://jsonplaceholder.typicode.com/users 
- https://jsonplaceholder.typicode.com/todos 

Once you have all the user information (Personal and ToDos) it is necessary to writte the result info in a json file in the following format. 

```json
{
   "id":1,
   "name":"Leanne Graham",
   "username":"Bret",
   "email":"Sincere@april.biz",
   "address":{
      "street":"Kulas Light",
      "suite":"Apt. 556",
      "city":"Gwenborough",
      "zipcode":"92998-3874",
      "geo":{
         "lat":"-37.3159",
         "lng":"81.1496"
      }
   },
   "phone":"1-770-736-8031 x56442",
   "website":"hildegard.org",
   "todos":[
      {
         "userId":1,
         "id":1,
         "title":"delectus aut autem",
         "completed":false
      }
   ]
}
```

