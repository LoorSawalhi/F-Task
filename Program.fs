open System

(* 2.Allow the Add method to handle an unknown amount of numbers *)
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
    
