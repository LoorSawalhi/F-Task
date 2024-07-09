open System
open System.Collections.Generic


(*7.Delimiters can be of any length with the following format:  “//[delimiter]\n” for example: “//[***]\n1***2***3” should return 6*)

exception NegativeNumber of string
let ConvertStringToInteger ( number : string) =
    let trimmedNumber = number.Trim()
    if(trimmedNumber.Length <= 0) then
        0
    else
        let x : int = int number
        x
      
let Add( numbers : string )( delimiter : string) =
    
    if (numbers.Length <= 0) then
        Some(0)
    else
        
        let numbersArray = numbers.Split @$"{delimiter}"
        let mutable sum : int = 0

        try
            for num in numbersArray do
                let splitByComma = num.Split ","
                let stringLength = num.Length - 1
                for i in splitByComma do
                    let x = ConvertStringToInteger i
                    sum <- x + sum

            Some(sum)        
        with
            | :? FormatException -> None

let mutable condition = true

while condition do
    printf @"Enter your string of numbers, separate by new lines \n :"
    let numbersString = Console.ReadLine()
    let inputs =  numbersString.Split @"\n"
    let delimiter = inputs[0].Trim('/').Trim('[').Trim(']')
    
    printfn $"Your delimiter is {delimiter}"
    
    let answer = Add inputs[1] delimiter
    
    match answer with
    | None -> printfn $"Wrong Format"
    | _ -> printfn $"Answer is %d{answer.Value}"
    
    printf "Wants to exit? press 1 is yes : "
    
    let exitCondition = Console.ReadLine()
    
    if exitCondition = "1" then
        condition <- false