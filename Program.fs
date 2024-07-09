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
        
        let numbersArray = numbers.Split @$"{delimiter}"
        
        let mutable result : int = 0
       
        try
            let negativeNums = new List<string>()
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
                            if (x < 0) then
                                negativeNums.Add(i)
                            sum <- x + sum
                        Some(sum)
                
                result <-
                    match innerValues with
                    | None -> raise (FormatException("Wrong Formating"))
                    | _ -> result + innerValues.Value
                    

            if (negativeNums.Count <> 0) then
                let fullString = String.concat ", " negativeNums
                raise (NegativeNumber(fullString))
            Some(result)        
        with
            | :? FormatException -> None
            | NegativeNumber(e)-> printfn $"Negatives are not allowed : {e}";  None

let mutable condition = true

while condition do
    printf @"Enter your string of numbers, separate by new lines \n :"
    let numbersString = Console.ReadLine()
    let inputs =  numbersString.Split @"\n"
    let delimiter = inputs[0][2]
    
    printfn $"Your delimiter is {delimiter}"
    
    let answer = Add inputs[1] delimiter
    
    match answer with
    | None -> printfn $"Wrong Format"
    | _ -> printfn $"Answer is %d{answer.Value}"
    
    printf "Wants to exit? press 1 is yes : "
    
    let exitCondition = Console.ReadLine()
    
    if exitCondition = "1" then
        condition <- false
    
