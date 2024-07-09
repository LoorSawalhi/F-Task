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
        try
            if numbers.Contains(@",\n") || numbers.Contains(@"\n,") then
                raise (FormatException())
            
            let numbersArray = numbers.Replace(@"\n",delimiter).Replace(",",delimiter).Split @$"{delimiter}"
            
            let negativeNums = new List<string>()
            let mutable sum : int = 0

        
            for num in numbersArray do
                let x = ConvertStringToInteger num
                if (x < 0) then
                    negativeNums.Add(num)
                elif (x < 1000) then
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
    printf "Enter your string of numbers:"
    let numbersString = Console.ReadLine()
    
    let mutable delimiter = ","
    let mutable numbers = numbersString
        
    if numbersString.Contains("//") then
        let index = numbersString.IndexOf @"\n"
        delimiter <- numbersString[ .. (index - 1)].Trim('/').Trim('[').Trim(']')
        numbers <- numbersString[index ..]
    else
        numbers <- numbersString
        delimiter <- ","

    printfn $"Your delimiter is {delimiter}"
    
    let answer = Add numbers delimiter
    
    match answer with
    | None -> printfn $"Wrong Format"
    | _ -> printfn $"Answer is %d{answer.Value}"
    
    printf "Wants to exit? press 1 is yes : "
    
    let exitCondition = Console.ReadLine()
    
    if exitCondition = "1" then
        condition <- false