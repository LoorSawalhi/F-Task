open System
open System.Collections.Generic


(*6.Numbers bigger than 1000 should be ignored, so adding 2 + 1001  = 2*)

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
        
        let numbersArray = numbers.Split @$"{delimiter}"
        
        let mutable result : int = 0
       
        try
            for num in numbersArray do
                let splitByComma = num.Split ","
                let stringLength = num.Length - 1
                let mutable sum : int = 0
                let innerValues =
                    if (num.Length <> 0 && (num[0] = ',' || num[stringLength] = ',')) then
                        None
                    else
                        for i in splitByComma do
                            let x = ConvertStringToInteger i
                            
                            if (x < 1000) then
                                sum <- x + sum
                        Some(sum)
                
                result <-
                    match innerValues with
                    | None -> raise (FormatException("Wrong Formating"))
                    | _ -> result + innerValues.Value
                    

            Some(result)        
        with
            | :? FormatException -> None

let mutable condition = true

while condition do
    printf @"Enter your string of numbers, separate by new lines \n :"
    let numbersString = Console.ReadLine()
    let index = numbersString.IndexOf @"\n"
    let delimiter = numbersString[2]
    let numbers = numbersString[index..].Replace(@"\n", delimiter.ToString()).Replace(',', delimiter)
    
    
    printfn $"Your delimiter is {delimiter}"
    
    let answer = Add numbers delimiter
    
    match answer with
    | None -> printfn $"Wrong Format"
    | _ -> printfn $"Answer is %d{answer.Value}"
    
    printf "Wants to exit? press 1 is yes : "
    
    let exitCondition = Console.ReadLine()
    
    if exitCondition = "1" then
        condition <- false
    
