open System
open System.Collections.Generic


(*5.Calling Add with a negative number will throw an exception “negatives not allowed”
- and the negative that was passed.if there are multiple negatives, show all of them in the exception message*)

exception NegativeNumber of string
let ConvertStringToInteger ( number : string) =
    let trimmedNumber = number.Trim()
    if(trimmedNumber.Length <= 0) then
        0
    else
        let x : int = int number
        x
      
let Add( numbers : string )( delimiter : char) =
    
    if (numbers.Length <= 0) then
        Some(0)
    else
        try
            if numbers.Contains(@",\n") || numbers.Contains(@"\n,") then
                raise (FormatException())
            
            let numbersArray = numbers.Replace(@"\n",",").Split @$"{delimiter}"
            
            let mutable sum : int = 0
       
        
            let negativeNums = new List<string>()
            for num in numbersArray do
                let x = ConvertStringToInteger num
                if (x < 0) then
                    negativeNums.Add(num)
                sum <- x + sum
                    

            if (negativeNums.Count <> 0) then
                let fullString = String.concat ", " negativeNums
                raise (NegativeNumber(fullString))
            Some(sum)        
        with
            | :? FormatException -> None
            | NegativeNumber(e)-> printfn $"Negatives are not allowed : {e}";  None

let mutable condition = true

while condition do
    printf @"Enter your string of numbers, separate by new lines \n :"
    let numbersString = Console.ReadLine()
    let mutable delimiter = ','
    let mutable numbers = numbersString
        
    if numbersString.Contains("//") then
        let index = numbersString.IndexOf @"\n"
        delimiter <- numbersString[2]
        numbers <- numbersString[index..].Replace(@"\n", delimiter.ToString()).Replace(',', delimiter)
    else
        numbers <- numbersString
        delimiter <- ','
    
    printfn $"Your delimiter is {delimiter}"
    
    let answer = Add numbers delimiter
    
    match answer with
    | None -> printfn $"Wrong Format"
    | _ -> printfn $"Answer is %d{answer.Value}"
    
    printf "Wants to exit? press 1 is yes : "
    
    let exitCondition = Console.ReadLine()
    
    if exitCondition = "1" then
        condition <- false
    
