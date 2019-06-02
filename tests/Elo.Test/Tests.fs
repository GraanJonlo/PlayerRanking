module Tests

open Xunit
open FsUnit.Xunit

open Elo

let unwrap x =
    match x with
    | Some y -> y
    | None -> raise <| System.Exception()

[<Fact>]
let ``Equal rated players should have an equal expected scores`` () =
    let rA = unwrap <| Rating.create 1500
    let rB = unwrap <| Rating.create 1500

    Score.expectedScore rA rB
    |> fun (x, y) -> Score.value x, Score.value y
    |> should equal (0.5m, 0.5m)

[<Fact>]
let ``Difference of 400 in ratings gives 10 times difference in score`` () =
    let rA = unwrap <| Rating.create 1200
    let rB = unwrap <| Rating.create 1700

    Score.expectedScore rA rB
    |> fun (x, y) -> Score.value x, Score.value y
    |> should equal (0.05m, 0.95m)
