open System

(*1.Create a simple String calculator with a method int Add(string numbers)
The method can take 0, 1 or 2 numbers, and will return their sum (for an empty string it will return 0) for example “” or “1” or “1,2”
Start with the simplest test case of an empty string and move to 1 and two numbers*)

let ConvertStringToInteger ( number : string) =
    let tremmedNumber = number.Trim()
    if(tremmedNumber.Length <= 0) then
        0
    else
        let x : int = int number
        x
      
let Add( numbers : string ) =
    
    if (numbers.Length <= 0) then
        Some(0)
    else
        
        let numbersArray = numbers.Split ","
        let mutable sum : int = 0
        
        if (numbersArray.Length > 3) then
           None
        else
            try
                for num in numbersArray do
                    let x = ConvertStringToInteger num
                    sum <- x + sum
                Some(sum)
            with
                | :? FormatException ->  None
        

let mutable condition = true

while condition do
    printf @"Enter your string of numbers, separate by comma :"
    let numbersString = Console.ReadLine()
    let answer = Add numbersString
    
    match answer with
    | None -> printfn $"Wrong Format"
    | _ -> printfn $"Answer is %d{answer.Value}"
    
    printf "Wants to exit? press 1 is yes : "
    
    let exitCondition = Console.ReadLine()
    
    if exitCondition = "1" then
        condition <- false
    
