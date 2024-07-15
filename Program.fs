open System

exception NegativeNumber of int array
let convertStringToInteger ( number : string) =
    match number.Trim() with
    | "" -> Some(0) 
    | trimmed ->
        match Int32.TryParse(trimmed) with
        | true, parsed -> Some(parsed)  
        | _ -> raise(FormatException())  

let delimiterAndNumbersExtractor (numbersString: string) =
    let cleanedDelimiters, numbers =
        match numbersString with
        | _ when numbersString.StartsWith("//") ->
            let index = numbersString.IndexOf(@"\n")
            let numbers = numbersString[index + 2..]
            let cleanedDelimiters =
                numbersString[2..index - 1].Replace("][",  " ").Trim('[').Trim(']').Split " "
                |> Array.append [|","; @"\n"|]

            cleanedDelimiters, numbers
        | _ ->
            [|","; @"\n"|], numbersString
            
    cleanedDelimiters, numbers
    
let filterNegatives (numbers : int array) =
    let negatives =
        numbers
        |> Array.filter (fun n -> int n < 0)
    match negatives.Length with
    | 0 -> numbers
    | _ -> raise(NegativeNumber(negatives))

let add( numbersString : string ) =
    
    let delimiters, numbers = delimiterAndNumbersExtractor numbersString

    numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
    |> Array.map(convertStringToInteger)
    |> Array.choose id
    |> Array.filter (fun v -> v <= 1000)
    |> filterNegatives
    |> Array.sum
    
     
printf @"Enter your string of numbers :"
let numbersString = Console.ReadLine()

try
    let answer = add numbersString

    printfn $"Answer is %d{answer}"
with
 | NegativeNumber(e)-> printfn $"Negatives are not allowed : {e}"
 | _ -> printfn "Wrong Format"