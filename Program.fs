open System

exception NegativeNumber of string
let convertStringToInteger ( number : string) =
    match number.Trim() with
    | "" -> Some(0) 
    | trimmed ->
        match Int32.TryParse(trimmed) with
        | true, parsed -> Some(parsed)  
        | _ -> None  

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
    
let filterNegatives (numbers : int option array) =
    let negatives =
        numbers
        |> Array.filter (fun n -> int n.Value < 0)
        |> Array.map(string) 
        |> String.concat ", "
        
    let hasNegatives =
        match negatives with
        | "" -> (false, "")
        | _ -> (true, negatives)
    hasNegatives
    
let processNumbers (numbers : int option array) =

    match Array.TrueForAll (numbers, _.IsSome) with
    | true ->
        numbers
        |> filterNegatives
        |> fun (hasNegatives, negativeList) ->
           try
               match hasNegatives with
               | true -> raise (NegativeNumber(negativeList))
               | false -> Some(Array.sum <| Array.choose id numbers)
           with
           | NegativeNumber(e)-> printfn $"Negatives are not allowed : {e}";  None
    | false ->
        None

let add( numbersString : string ) =
    
    let delimiters, numbers = delimiterAndNumbersExtractor numbersString
    let result =
        match numbers with
        | _ when numbers.Contains(@",\n") || numbers.Contains(@"\n,") ->
            None
        | _ -> numbers.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
                |> Array.map(convertStringToInteger)
                |> Array.filter (fun n ->
                    match n with
                    | None -> true
                    | Some(v) -> v < 1000)
                |> processNumbers 
   
    result
  
printf @"Enter your string of numbers :"
let numbersString = Console.ReadLine()
let answer = add numbersString

match answer with
| None -> printfn "Wrong Format"
| Some i -> printfn $"Answer is %d{i}"