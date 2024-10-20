# FizzBuzz with a Twist

**Objective**: Write a program that receives an ordered array of integers and returns an array of strings. The program should follow the classic FizzBuzz rules with an additional twist based on the order of input numbers.

## Rules

- For multiples of 3, output "Fizz".
- For multiples of 5, output "Buzz".
- For multiples of both 3 and 5, output "FizzBuzz".
- If a number does not meet any of the above conditions, output the number itself as a string.

Twist: If the input array is in descending order, reverse the output string for each FizzBuzz result ("zzif" instead of "Fizz", "zzub" instead of "Buzz", and "zzubzzif" instead of "FizzBuzz"). 

Output strings are case-insensitive, meaning that `"Fizz"`, `"fizz"`, `"FIZZ"`, and so on, are all valid outputs.

## Examples

- Input: `[1, 2, 3, 4, 5]`  
  Output: `["1", "2", "Fizz", "4", "Buzz"]`

- Input: `[5, 4, 3, 2, 1]` (Descending order)   
  Output: `["Buzz", "4", "zzif", "2", "1"]`

- Input: `[15, 10, 5, 3, 1]`   
  Output: `["zzubzzif", "zzub", "zzub", "zzif", "1"]`
