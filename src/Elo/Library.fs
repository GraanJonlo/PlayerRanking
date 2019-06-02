namespace Elo

module Rating =
    type T = Rating of int

    let create x =
        if x >= 100 then
            Some (Rating x)
        else
            None

    let value (Rating x) = x

module Score =
    open System

    type T = Score of decimal

    let create x =
        if x >= 0m && x <= 1m then
            Some (Score x)
        else
            None

    let value (Score x) = x

    let reciprocal = (/) 1.0

    let expectedScore rA rB =
        let eA =
            1.0 + (10.0 ** ((float (Rating.value rB - Rating.value rA)) / 400.0))
            |> reciprocal
            |> decimal
            |> fun x -> Decimal.Round(x, 2)
        let eB = 1m - eA
        Score eA, Score eB
