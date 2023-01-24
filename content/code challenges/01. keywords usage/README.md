## Exercise
Create a method that receives 3 variables as parameters: name, age and email then print this out in the following format.

```c#
name: John
age: 25
email: test@test.com 
```

 ---

 ## Excercise
 Create a method that sums 1,...,n numbers as parameters and print the operation result.

 ```c#
 // Input arguments
 2,4,5,8,10

 // Output. A string that contains the operation result in this format
  2 + 4 + 5 + 8 + 10 = 29 
 ```


  ---

## Excercise
Create a number to word helper method that receives as a parameter (Read the salary from console redline) the salary of a developer. The requirements for the helper method are the following. 
 
•	Validates if the salary meets the criteria of being greater than 50.000 USD and return true or false in that case. 
•	If the salary meets the criteria in another variable, then returns the salary in letters "seventy-five thousand dollars".

Number to word code snippet.
```c#
string CurrencyToWord(int number, string word)
{
    if (number / 1_000_000 != 0)
    {
        word = string.Concat(CurrencyToWord(number / 1_000_000, word), " million ");
        number %= 1_000_000;
    }

    if (number / 1_000 != 0)
    {
        word = string.Concat(CurrencyToWord(number / 1_000, word), " thousand ");
        number %= 1_000;
    }

    if (number / 100 != 0)
    {
        word = string.Concat(CurrencyToWord(number / 100, word), " hundred ");
        number %= 100;
    }

    word = NumberToWord(number, word);

    return word;
}

string NumberToWord(int number, string words)
{
    if (words != "") words += " ";

    var unitValues = new[]
    {
        "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve",
        "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
    };
    var tensValues = new[]
        { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };


    if (number >= 20)
    {
        words += tensValues[number / 10];
        if (number % 10 > 0) words += "-" + unitValues[number % 10];
    }
    else
        words += unitValues[number];

    return words;
}


// Usage
var phrase = CurrencyToWord(85000, string.Empty);
```
