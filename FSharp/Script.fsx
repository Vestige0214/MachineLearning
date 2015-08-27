open System.IO
type Observation = {Label:string; Pixels: int[]} //record: immutable class with the properties

let toObservation (csvData:string) = 
    let columns = csvData.Split(',')
    let label = columns.[0]
    let pixels = columns.[1..] |> Array.map int
    { Label = label; Pixels = pixels }

let reader path =
    let data = File.ReadAllLines path //File.ReadAllLines the inference machine will look for the right overload to use based on the parameter u passed in in this case path:string
    //expression based therefore bind the results to the last expression, in this case binds value to data
    data.[1..] //other examples:[5..10] or [..3]
    |> Array.map toObservation //take array data pass it to function and apply mapping to each element

let trainingPath = @"C:\Users\Jeramy Wu\Source\Repos\MachineLearning\Data\trainingsample.csv"
let trainingData = reader trainingPath

let manhattanDistance (pixels1,pixels2) =
    Array.zip pixels1 pixels2 //Array.zip = create single array of tuples
    |> Array.map (fun (x,y) -> abs (x-y))
    |> Array.sum

let train (trainingset:Observation[]) =
    let classify (pixels:int[]) =
        trainingset
        |> Array.minBy(fun x -> manhattanDistance x.Pixels pixels)
        |> fun x -> x.Label
    classify

let classifier = train training

let validationPath = @"C:\Users\Jeramy Wu\Source\Repos\MachineLearning\Data\validationsample.csv"
let validationData = reader validationPath