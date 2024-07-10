open System

// The Final Version
exception NegativeNumber of string
let convertStringToInteger ( number : string) =
    let trimmedNumber = number.Trim()
    if(trimmedNumber.Length = 0) then
        0
    else
        let x : int = int number
        x
let delimiterAndNumbersExtractor (numbersString: string) =
    if numbersString.StartsWith("//") then
        let index = numbersString.IndexOf(@"\n")
        let delimiter = numbersString[2..index - 1]
        let numbers = numbersString[index + 2..]
        let cleanedDelimiters = delimiter.Replace("][",  " ").Trim('[').Trim(']')
        let mutable arrayOfDelimiters = cleanedDelimiters.Split " "
        arrayOfDelimiters <- Array.append arrayOfDelimiters [|","; @"\n"|]
        arrayOfDelimiters, numbers
    else
        [|","; @"\n"|], numbersString
        
let add( numbersString : string ) =
    
    let mutable delimiters, numbers = delimiterAndNumbersExtractor numbersString
    
    if (numbers = "") then
        Some(0)
    else
        try
            if numbers.Contains(@",\n") || numbers.Contains(@"\n,") then
                raise (FormatException())
                      
            let numbersArray = numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
            let negativeNums = Array.filter (fun n -> int n < 0) numbersArray
            if negativeNums.Length > 0 then
                let fullString = String.concat ", " negativeNums
                raise (NegativeNumber(fullString))
            let mutable sum : int = 0
            for num in numbersArray do
                let x = convertStringToInteger num
                if (x < 1000) then
                    sum <- x + sum
            Some(sum)
        with
            | :? FormatException -> None
            | NegativeNumber(e)-> printfn $"Negatives are not allowed : {e}";  None

let mutable condition = true

while condition do
    printf @"Enter your string of numbers :"
    let numbersString = Console.ReadLine()
    
    let answer = add numbersString
    
    match answer with
    | None -> printfn "Wrong Format"
    | _ -> printfn $"Answer is %d{answer.Value}"
    
    //commented this for easy testing
    // printf "Wants to exit? press 1 is yes : "
    //
    // let exitCondition = Console.ReadLine()
    //
    // if exitCondition = "1" then
    //     condition <- false