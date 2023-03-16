простір Фшарп.Ядро

//[<AutoOpen>]
[<assembly:AutoOpen("Фшарп.Ядро.Коллекції")>]
do()
[<assembly:AutoOpen("Фшарп.Ядро.ДодатковіОпераціїВерхньогоРівня")>]
do()

module Коллекції =
    тип Словник<'ТКлюч,'ТЗначення> = System.Collections.Generic.Dictionary<'ТКлюч,'ТЗначення>
    тип МасивЗмінногоРозміру<'ТЗначення> = ResizeArray<'ТЗначення>

[<AutoOpen>]
module ДодатковіОпераціїВерхньогоРівня =
    
  ///<summary>Builds an asynchronous workflow using computation expression syntax.</summary>
  ///<example id="async-1"><code lang="fsharp">
  /// let sleepExample() =
  ///     async {
  ///         printfn "sleeping"
  ///         do! Async.Sleep 10
  ///         printfn "waking up"
  ///         return 6
  ///      }
  ///
  /// sleepExample() |&gt; Async.RunSynchronously
  /// </code></example>
  нехай асинх = async

  ///<summary>Builds a read-only lookup table from a sequence of key/value pairs. The key objects are indexed using generic hashing and equality.</summary>
  ///<example id="dict-1"><code lang="fsharp">
  /// let table = dict [ (1, 100); (2, 200) ]
  ///
  /// table[1]
  /// </code>
  /// Evaluates to <c>100</c>.
  /// </example>
  ///<example id="dict-2"><code lang="fsharp">
  /// let table = dict [ (1, 100); (2, 200) ]
  ///
  /// table[3]
  /// </code>
  /// Throws <c>System.Collections.Generic.KeyNotFoundException</c>.
  /// </example>
  нехай слов = dict
  тип плаваюча = float
  нехай inline плаваюча значення = float значення
  тип байт = byte
  нехай inline байт значення = byte значення
  тип логічний = bool
  нехай зменьш = decr
  тип цел = int  
  нехай inline цел значення = int значення
  тип строка = string
  нехай inline строка значення = string значення
  тип об' = System.Object
  нехай inline ігнорувати значення = ignore значення
  нехай inline не значення = not значення
  нехай inline ссил значення = ref значення
  тип ссил<'Т> = ref<'Т>

  ///<summary>Печатає до <c>stdout</c> використовуючи заданий формат, та додає символ нового рядка.</summary>
  ///<param name="format">Форматувальник.</param>
  ///<returns>Форматований результат.</returns>
  ///<example>Дивиться <c>Printf.printfn</c> (посилання: <see cref="M:Microsoft.FSharp.Core.PrintfModule.PrintFormatLine``1" />) за прикладами.</example>
  нехай inline напечататифн формат = printfn формат

  ///<summary>Печатає до <c>stdout</c> використовуючи заданий формат.</summary>
  ///<param name="format">Форматувальник.</param>
  ///<returns>Форматований результат.</returns>
  ///<example>Дивиться <c>Printf.printf</c> (посилання: <see cref="M:Microsoft.FSharp.Core.PrintfModule.PrintFormat``1" />) за прикладами.</example>
  нехай inline напечататиф формат = printf формат

  тип Асинх = 
      static member ДочекатисяЗадачу(задача) = Async.AwaitTask задача
      static member Запустити(обчислення: Async<unit>, ?маркерСкасування: System.Threading.CancellationToken) = 
        let маркерСкасування =
            defaultArg маркерСкасування Async.DefaultCancellationToken
        Async.Start( обчислення, маркерСкасування)


///<summary>Contains operations for working with values of type <see cref="T:Microsoft.FSharp.Collections.seq`1" />.</summary>
[<RequireQualifiedAccess; CompilationRepresentation (CompilationRepresentationFlags.ModuleSuffix)>]
module Посл =
    нехай ініц = Seq.init
    нехай уникальні = Seq.distinct
    нехай фільтр = Seq.filter
    нехай inline сумаПо ([<InlineIfLambda>] projection: 'T -> ^U) (source: seq<'T>) : ^U = Seq.sumBy projection source
    нехай урізати = Seq.truncate
    нехай доСписка = Seq.toList
    ;
///<summary>Contains operations for working with values of type <see cref="T:Microsoft.FSharp.Collections.list`1" />.</summary>
///<namespacedoc><summary>Operations for collections such as lists, arrays, sets, maps and sequences. See also 
///    <a href="https://docs.microsoft.com/dotnet/fsharp/language-reference/fsharp-collection-types">F# Collection Types</a> in the F# Language Guide.
/// </summary></namespacedoc>
[<RequireQualifiedAccess; CompilationRepresentation (CompilationRepresentationFlags.ModuleSuffix)>]
module Список =
    ///<summary>Returns a list that contains no duplicate entries according to generic hash and
    /// equality comparisons on the entries.
    /// If an element occurs multiple times in the list then the later occurrences are discarded.</summary>
    ///<param name="list">The input list.</param>
    ///<returns>The result list.</returns>
    ///<example id="distinct-1"><code lang="fsharp">
    /// let input = [6;1;2;3;1;4;5;5]
    ///
    /// input |&gt; List.distinct
    /// </code>
    /// Evaluates to <c>[6; 1; 2; 3; 4; 5]</c>.
    /// </example>
    нехай уникальні = List.distinct
    нехай ізПосл = List.ofSeq
    нехай обр = List.rev
    //нехай фільтр = List.map
    нехай фільтр = List.filter
    нехай inline сумаПо ([<InlineIfLambda>] projection: 'T -> ^U) (source: list<'T>) : ^U = List.sumBy projection source
    нехай урізати = List.truncate

[<RequireQualifiedAccess; CompilationRepresentation (CompilationRepresentationFlags.ModuleSuffix)>]
module Масив =
    нехай ініц = Array.init
    нехай фільтр = Array.filter
    нехай inline сумаПо ([<InlineIfLambda>] projection: 'T -> ^U) (source: array<'T>) : ^U = Array.sumBy projection source
    нехай урізати = Array.truncate
    нехай доСписка = Array.toList
