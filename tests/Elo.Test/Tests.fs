module Tests

open Xunit
open FsUnit.Xunit

open Elo

[<Fact>]
let ``Equal rated players should have an equal expected scores`` () =
    let rA = Rating 1500
    let rB = Rating 1500

    Elo.expectedOutcome rA rB |> should equal { ScoreA = Score 0.5m; ScoreB = Score 0.5m }

[<Fact>]
let ``Difference of 400 in ratings gives 10 times difference in score`` () =
    let rA = Rating 1200
    let rB = Rating 1700

    Elo.expectedOutcome rA rB |> should equal { ScoreA = Score 0.05m; ScoreB = Score 0.95m }
