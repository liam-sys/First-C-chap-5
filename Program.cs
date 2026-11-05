/*
Chap 5 Summary (Conditional Statements)
-This chapter introduces the conditional statements in C#, which let a program execute different actions depending on a given condition.
-The main things i covered in this chapter are:
1. Comparison Operators and Boolean Expressions:
   I was reminded of the comparison operators (==, !=, >, <, >=, <=) which compare two expressions and always give a bool result (true or false). I learned that different numeric types can be compared (like an int with a double) but a string cannot be compared with a number.
2. Comparison of Integers and Characters:
   I learned that when integers and characters are compared, their values are compared directly. For example 'a' == 'b' is false and 5.0 == 5L is true.
3. Comparison of References to Objects:
   I learned that reference types (strings, arrays, classes) hold the address of their value in the heap, so == normally checks if two variables point to the same object. I also learned that string is a special case because == compares the text, but if both are cast to object then the addresses are compared.
4. Logical Operators:
   I was reminded of the logical operators and how they only work on bool values. && (AND) and || (OR) stop early once the result is known, while & and | always evaluate both sides. I also learned that ^ (XOR) is true only when exactly one side is true and ! reverses a bool value.
5. The if Statement:
   I learned the format of the if statement: the keyword if, a bool condition in brackets, and a body that only runs when the condition is true. I also learned that curly brackets should always be used, even for one statement, because leaving them out can make the code misleading.
6. The if-else Statement:
   I learned that else adds a second body which runs when the condition is false, so exactly one of the two bodies is executed.
7. Nested if Statements:
   I learned that an if or if-else can be placed inside another one, and that every else belongs to the closest previous if. I also learned that going deeper than three levels is bad practice and the code should be moved into a separate method.
8. Good Practices for if:
   I learned to always use curly brackets, to indent the code after if and else, and to prefer switch-case over a long chain of if-else-if when possible.
9. The switch-case Statement:
   I learned that switch chooses which code to run by comparing a selector (integer, char, string or enum, but not float or array) to the case labels. Each case section must end with break, default runs when nothing matches, labels must be unique, and several labels can share one block by stacking them without code in between.
10. Good Practices for switch-case:
   I learned to put default at the end, to place the most common cases first, to sort integer labels in ascending order and char labels alphabetically, and to always include default to handle unexpected values.
*/

//Chap 5 Code Snippet

using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Comparison operators (the result is always bool)
        int a = 6, b = 4;
        Console.WriteLine((a > b) + " " + (a == b) + " " + (a != b) + " " + (a <= b));   // True False True False

        // 2. Comparing integers and characters (their values are compared)
        Console.WriteLine(('a' == 'b') + " " + (5.0 == 5L) + " " + ('a' < 'b'));         // False True True

        // 3. Comparing references: == on strings compares the TEXT
        string str = "beer";
        string third = "bee";
        third = third + 'r';                        // a new string object with the same text
        Console.WriteLine((str == third) + " " + ((object)str == (object)third));        // True False (cast to object compares addresses)

        // 4. Logical operators
        bool isStudent = true, hasId = false;
        Console.WriteLine((isStudent && hasId) + " " + (isStudent || hasId) + " " + !isStudent + " " + (isStudent ^ hasId));   // False True False True
        int zero = 0;
        Console.WriteLine((zero != 0) && (10 / zero > 1));   // False: && stops early, so there is no divide by zero
        // (zero != 0) & (10 / zero > 1) would crash because & evaluates BOTH sides

        // 5. if statement
        int number = 7;
        if (number > 5)
        {
            Console.WriteLine("Greater than 5");    // always use { } even for one statement
        }

        // 6. if-else statement
        if (number % 2 == 0)
        {
            Console.WriteLine("Even");
        }
        else
        {
            Console.WriteLine("Odd");               // exactly one of the two bodies runs
        }

        // 7. Nested if (each else belongs to the closest previous if)
        int score = 72;
        if (score >= 50)
        {
            if (score >= 70)
            {
                Console.WriteLine("Grade B or better");
            }
            else
            {
                Console.WriteLine("Grade C");
            }
        }
        else
        {
            Console.WriteLine("Fail");
        }

        // 8. switch-case (selector can be int, char, string or enum)
        int digit = 6;
        switch (digit)
        {
            case 1:
            case 4:
            case 6:                                 // stacked labels share one block
                Console.WriteLine("Not prime");
                break;                              // break is REQUIRED after a section that has code
            case 2:
            case 3:
            case 5:
                Console.WriteLine("Prime");
                break;
            default:                                // runs when no label matches, keep it last
                Console.WriteLine("Unknown number");
                break;
        }

        // 9. Score checker (Chapter 4 input + Chapter 5 decisions)
        Console.Write("Enter your score (0-100): ");
        int mark;
        bool valid = int.TryParse(Console.ReadLine(), out mark);
        string remark;
        if (!valid || mark < 0 || mark > 100)
        {
            remark = "Invalid score";
        }
        else if (mark >= 70)                        // else if chain: only the first true condition runs
        {
            remark = "Excellent";
        }
        else if (mark >= 50)
        {
            remark = "Pass";
        }
        else
        {
            remark = "Fail";
        }
        Console.WriteLine(remark);

        Console.ReadKey();
    }
}
