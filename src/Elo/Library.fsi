namespace Elo

[<RequireQualifiedAccess>]
module Rating =

    type T

    val create : int -> T option
    val value : T -> int

[<RequireQualifiedAccess>]
module Score =
    type T

    val create : decimal -> T option
    val value : T -> decimal

    val expectedScore : Rating.T -> Rating.T -> T * T
