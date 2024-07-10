# String Calculator using F#

The code is divided into eight different parts as branches, each part represents adding a new functionality. For the main branch, it represents the final code after adding all the required functionalities.

For the provided functionalities, here is the roles:
```
1.Create a simple String calculator with a method int Add(string numbers)
                The method can take 0, 1 or 2 numbers, and will return their sum (for an empty string it will return 0) for example “” or “1” or “1,2”
                Start with the simplest test case of an empty string and move to 1 and two numbers

2.Allow the Add method to handle an unknown amount of numbers

3.Allow the Add method to handle new lines between numbers (instead of commas).
                the following input is ok:  “1\n2,3”  (will equal 6)
                the following input is NOT ok:  “1,\n” (not need to prove it - just clarifying)

4.Support different delimiters
                to change a delimiter, the beginning of the string will contain a separate line that looks like this:  
                 “//[delimiter]\n[numbers…]” for example “//;\n1;2” should return three where the default delimiter is ‘;’ .
                the first line is optional. all existing scenarios should still be supported

5.Calling Add with a negative number will throw an exception “negatives not allowed” - and the negative that was passed.if there are multiple negatives, show all of them in the exception message

6.Numbers bigger than 1000 should be ignored, so adding 2 + 1001  = 2

7.Delimiters can be of any length with the following format:  “//[delimiter]\n” for example: “//[***]\n1***2***3” should return 6

8.Allow multiple delimiters like this:  “//[delim1][delim2]\n” for example “//[*][%]\n1*2%3” should return 6.

9.make sure you can also handle multiple delimiters with length longer than one char
```
 
 For the used tested cases:
```
Enter your string of numbers : 
Answer is 0
Enter your string of numbers :1
Answer is 1
Enter your string of numbers :1,2
Answer is 3
Enter your string of numbers :1\n2
Answer is 3
Enter your string of numbers :1\n2,3
Answer is 6
Enter your string of numbers ://;\n2
Answer is 2
Enter your string of numbers ://;\n2,3
Answer is 5
Enter your string of numbers ://;\n2,3\n4
Answer is 9
Enter your string of numbers ://;\n2,3\n4;5
Answer is 14
Enter your string of numbers ://[;]\n2,3\n4;5 
Answer is 14
Enter your string of numbers ://[;*&]\n2,3\n4;*&5 
Answer is 14
Enter your string of numbers ://[;*&][(((]\n2,3\n4;*&5(((6
Answer is 20
Enter your string of numbers ://[;*&][(((]\n2,3\n4;*&5(((-6 
Negatives are not allowed : -6
Wrong Format
Enter your string of numbers ://[;*&][(((]\n2,3\n4;*&5(((6000
Answer is 14
Enter your string of numbers ://[;*&][(((]\n2,3\n4;*&5((6000
Wrong Format
Enter your string of numbers :1,-2,3
Negatives are not allowed : -2
Wrong Format
Enter your string of numbers :1,\n
Wrong Format
```
