namespace Фшарп.Ядро

[<assembly:AutoOpen("Фшарп.Ядро.Коллекции")>]
do()
[<assembly:AutoOpen("Фшарп.Ядро.ДополнительныеОперацииВерхнегоУровня")>]
do()

module Коллекции =
    type Словарь<'ТКлюч,'ТЗначение> = System.Collections.Generic.Dictionary<'ТКлюч,'ТЗначение>
    type МассивИзменяемогоРозмера<'ТЗначение> = ResizeArray<'ТЗначение>

[<AutoOpen>]
module ДополнительныеОперацииВерхнегоУровня =
    
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
  let асинх = async

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
  let слов = dict
  type плаващее = float
  let inline плаващее значение = float значение
  type байт = byte
  let inline байт значение = byte значение
  type логічний = bool
  let уменьш = decr
  type цел = int  
  let inline цел значение = int значение
  type строка = string
  let inline строка значение = string значение
  type объ = System.Object
  let inline игноровать значение = ignore значение
  let inline не значение = not значение
  let inline ссыл значение = ref значение
  type ссыл<'Т> = ref<'Т>

  ///<summary>Печатает в <c>stdout</c> используя заданий формат, и добаляетт символ новой строки.</summary>
  ///<param name="format">Форматировщик.</param>
  ///<returns>Отформатований результат.</returns>
  ///<example>Смотрите <c>Printf.printfn</c> (ссылка: <see cref="M:Microsoft.FSharp.Core.PrintfModule.PrintFormatLine``1" />) для примеров.</example>
  let inline напечататьфн формат = printfn формат

  ///<summary>Печатает в <c>stdout</c> используя заданий формат.</summary>
  ///<param name="format">Форматировщик.</param>
  ///<returns>Отформатований результат.</returns>
  ///<example>Смотрите <c>Printf.printfn</c> (ссылка: <see cref="M:Microsoft.FSharp.Core.PrintfModule.PrintFormatLine``1" />) для примеров.</example>
  let inline напечататьф формат = printf формат

  type Асинх = 
      static member ДочекатисяЗадачу(задача) = Async.AwaitTask задача
      static member Запустити(обчислення: Async<unit>, ?маркерСкасування: System.Threading.CancellationToken) = 
        let маркерСкасування =
            defaultArg маркерСкасування Async.DefaultCancellationToken
        Async.Start( обчислення, маркерСкасування)


///<summary>Contains operations for working with values of type <see cref="T:Microsoft.FSharp.Collections.seq`1" />.</summary>
[<RequireQualifiedAccess; CompilationRepresentation (CompilationRepresentationFlags.ModuleSuffix)>]
module Посл =
    let иниц = Seq.init
    let уникальные = Seq.distinct
    let фильтр = Seq.filter
    let inline суммаПо ([<InlineIfLambda>] projection: 'T -> ^U) (source: seq<'T>) : ^U = Seq.sumBy projection source
    let обрезать = Seq.truncate
    let кСписку = Seq.toList
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
    let уникальные = List.distinct
    let изПосл = List.ofSeq
    let обр = List.rev
    //let фільтр = List.map
    let фильтр = List.filter
    let inline суммаПо ([<InlineIfLambda>] projection: 'T -> ^U) (source: list<'T>) : ^U = List.sumBy projection source
    let обрезать = List.truncate

[<RequireQualifiedAccess; CompilationRepresentation (CompilationRepresentationFlags.ModuleSuffix)>]
module Массив =
    let иниц = Array.init
    let фильтр = Array.filter
    let inline суммаПо projection source = Array.sumBy projection source
    let обрезать = Array.truncate
    let кСписку = Array.toList