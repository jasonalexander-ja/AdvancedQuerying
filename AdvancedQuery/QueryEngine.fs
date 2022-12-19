namespace AdvancedQuery

open System
open System.Collections.Generic
open Microsoft.EntityFrameworkCore


type Extractor<'T> = 
    |String of ('T -> string)
    |Integer of ('T -> int)
    |Decimal of ('T -> decimal)
    |DateTime of ('T -> DateTime)
    |Set of struct(('T -> string) * List<string>)

    member this.WithString ext = 
        Extractor.String (FSharpFunc.FromConverter ext)

    member this.WithInt ext = 
        Extractor.Integer (FSharpFunc.FromConverter ext)

    member this.WithDecimal ext = 
        Extractor.Decimal (FSharpFunc.FromConverter ext)

    member this.WithDate ext = 
        Extractor.DateTime (FSharpFunc.FromConverter ext)

    member this.WithSet ext options = 
        let f = FSharpFunc.FromConverter ext
        Extractor.Set struct(f, options)

    member this.WithBool ext trufy falsy =
        let f = FSharpFunc.FromConverter ext
        Extractor.Set struct (f, new List<string>([trufy; falsy;]))


type QueryEngine<'T when 'T: not struct>(
    contextExt,
    extractors
) =

    member this.ContextExt: DbContext -> DbSet<'T>  = contextExt
    member this.Extractors: IDictionary<string, Extractor<'T>> = extractors



