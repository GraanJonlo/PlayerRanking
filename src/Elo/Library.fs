module Elo

open System

type Rating = Rating of int

type Score = Score of decimal

type Outcome = {
    ScoreA : Score
    ScoreB : Score
}

let expectedOutcome (Rating rA) (Rating rB) =
    let expectedScore rA rB =
        1.0 / (1.0 + (10.0 ** ((float (rB - rA)) / 400.0)))
        |> decimal
        |> fun x -> Decimal.Round(x, 2)
    let expectedScoreForA = expectedScore rA rB
    {
        ScoreA = Score expectedScoreForA
        ScoreB = Score <| 1m - expectedScoreForA }
