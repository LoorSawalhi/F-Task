open System
open System.Collections.Generic


(*8.Allow multiple delimiters like this:  “//[delim1][delim2]\n” for example “//[*][%]\n1*2%3” should return 6.*)

exception NegativeNumber of string
let ConvertStringToInteger ( number : string) =
    let trimmedNumber = number.Trim()
    if(trimmedNumber.Length <= 0) then
        0
    else
        let x : int = int number
        x
let delimiterExtractor (delimiter : string) =
    let cleaningDelimiters = delimiter.Replace("[",  "").Replace("]", " ").Trim()
    let delimitersList = cleaningDelimiters.Split " "
    
    delimitersList
let Add( numbers : string )( delimiter : string) =
    
    if (numbers.Length <= 0) then
        Some(0)
    else
        let delimiters = delimiterExtractor delimiter
        let numbersArray = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
        
        let mutable sum : int = 0

        try
            for num in numbersArray do
                let x = ConvertStringToInteger num
                sum <- x + sum

            Some(sum)        
        with
            | :? FormatException -> None

let mutable condition = true

while condition do
    printf @"Enter your string of numbers, separate by new lines \n :"
    let numbersString = Console.ReadLine()
    let inputs =  numbersString.Split @"\n"
    let delimiter = inputs[0].Trim('/').Trim()
    
    printfn $"Your delimiters are {delimiter}"
    
    let answer = Add inputs[1] delimiter
    
    match answer with
    | None -> printfn $"Wrong Format"
    | _ -> printfn $"Answer is %d{answer.Value}"
    
    printf "Wants to exit? press 1 is yes : "
    
    let exitCondition = Console.ReadLine()
    
    if exitCondition = "1" then
        condition <- false