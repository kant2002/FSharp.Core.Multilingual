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
    let всеПары = Seq.allPairs
    let добавить = Seq.append
    let inline среднее (источник: ^T seq) : ^T when ^T: (static member (+) : ^T * ^T -> ^T) and ^T: (static member DivideByInt: ^T * int -> ^T) and ^T: (static member Zero: ^T)  = Seq.average источник
    let inline среднееПо (проєкция: 'T -> ^U) (источник: ^T seq) : ^U when ^U: (static member (+) : ^U * ^U -> ^U) and ^U: (static member DivideByInt: ^U * int -> ^U) and ^U: (static member Zero: ^U) = Seq.averageBy проєкция источник
    let кешировать = Seq.cache
    let преобразовать = Seq.cast
    let отобрать = Seq.choose
    let кусокПоРазмеру = Seq.chunkBySize
    let собрать = Seq.collect
    let сравнитьС = Seq.compareWith
    let сцепить = Seq.concat
    let inline содержит значение источник = Seq.contains значение источник
    let посчитатьПо = Seq.countBy
    let задержка = Seq.delay
    let уникальные = Seq.distinct
    let уникальныеПо = Seq.distinctBy
    let пустая = Seq.empty
    let толькоОдин = Seq.exactlyOne
    let заИсключением = Seq.except
    let существует = Seq.exists
    let существует2 = Seq.exists2
    let фильтр = Seq.filter
    let найти = Seq.find
    let найтиСзади = Seq.findBack
    let найтиИндекс = Seq.findIndex
    let найтиИндексСзади = Seq.findIndexBack
    let свернуть = Seq.fold
    let свернуть2 = Seq.fold2
    let свернутьСзади = Seq.foldBack
    let свернутьСзади2 = Seq.foldBack2
    let длявсех = Seq.forall
    let длявсех2 = Seq.forall2
    let сгруппироватьПо = Seq.groupBy
    let голова = Seq.head
    let индексированая = Seq.indexed
    let иниц = Seq.init
    let иницБесконечную = Seq.initInfinite
    let вставитьВ = Seq.insertAt
    let вставитьМногоВ = Seq.insertManyAt
    let естьПустая = Seq.isEmpty
    let элемент = Seq.item
    let итер = Seq.iter
    let итер2 = Seq.iter2
    let итери = Seq.iteri
    let итери2 = Seq.iteri2
    let последний = Seq.last
    let длина = Seq.length
    let отобразить = Seq.map
    let отобразить2 = Seq.map2
    let отобразить3 = Seq.map3
    let отобразитьСвернуть = Seq.mapFold
    let отобразитьСвернутьСзади = Seq.mapFoldBack
    let отобразитьи = Seq.mapi
    let отобразитьи2 = Seq.mapi2
    let inline макс источник = Seq.max источник
    let inline максПо проєкция источник = Seq.maxBy проєкция источник
    let inline мин источник = Seq.min источник
    let inline минПо проєкция источник = Seq.minBy проєкция источник
    let нный = Seq.nth
    let изМассива = Seq.ofArray
    let изСписка = Seq.ofList
    let попарно = Seq.pairwise
    let переставить = Seq.permute
    let выбрать = Seq.pick
    let длячтения = Seq.readonly
    let редуцировать = Seq.reduce
    let редуцироватьСзади = Seq.reduceBack
    let удалитьИз = Seq.removeAt
    let удалитьМногоИз = Seq.removeManyAt
    let реплицировать = Seq.replicate
    let перевер = Seq.rev
    let сканировать = Seq.scan
    let сканироватьСзади = Seq.scanBack
    let синглтон = Seq.singleton
    let пропустить = Seq.skip
    let пропуститьПока = Seq.skipWhile
    let сортировать = Seq.sort
    let сортироватьПо = Seq.sortBy
    let сортироватьПоУбывание = Seq.sortByDescending
    let сортироватьУбывание = Seq.sortDescending
    let сортироватьС = Seq.sortWith
    let разделитьНа = Seq.splitInto
    let inline сумма источник = Seq.sum источник
    let inline суммаПо ([<InlineIfLambda>] проєкция: 'T -> ^U) (источник: seq<'T>) : ^U = Seq.sumBy проєкция источник
    let хвост = Seq.tail
    let взять = Seq.take
    let взятьПока = Seq.takeWhile
    let кМассиву = Seq.toArray
    let кСписку = Seq.toList
    let транспонировать = Seq.transpose
    let обрезать = Seq.truncate
    let попробоватьТолькоОдин = Seq.tryExactlyOne
    let попробоватьНайти = Seq.tryFind
    let попробоватьНайтиСзади = Seq.tryFindBack
    let попробоватьНайтиИндекс = Seq.tryFindIndex
    let попробоватьНайтиИндексСзади = Seq.tryFindIndexBack
    let попробоватьГолову = Seq.tryHead
    let попробоватьЭлемент = Seq.tryItem
    let попробоватьПоследний = Seq.tryLast
    let попробоватьВыбрать = Seq.tryPick
    let развернуть = Seq.unfold
    let обновитьВ = Seq.updateAt
    let где = Seq.where
    let оконная = Seq.windowed
    let упаковать = Seq.zip
    let упаковать3 = Seq.zip3

///<summary>Contains operations for working with values of type <see cref="T:Microsoft.FSharp.Collections.list`1" />.</summary>
///<namespacedoc><summary>Operations for collections such as lists, arrays, sets, maps and sequences. See also 
///    <a href="https://docs.microsoft.com/dotnet/fsharp/language-reference/fsharp-collection-types">F# Collection Types</a> in the F# Language Guide.
/// </summary></namespacedoc>
[<RequireQualifiedAccess; CompilationRepresentation (CompilationRepresentationFlags.ModuleSuffix)>]
module Список =
    let всеПары = List.allPairs
    let добавить = List.append
    let inline среднее (источник: ^T list) : ^T when ^T: (static member (+) : ^T * ^T -> ^T) and ^T: (static member DivideByInt: ^T * int -> ^T) and ^T: (static member Zero: ^T)  = List.average источник
    let inline среднееПо (проєкция: 'T -> ^U) (источник: ^T list) : ^U when ^U: (static member (+) : ^U * ^U -> ^U) and ^U: (static member DivideByInt: ^U * int -> ^U) and ^U: (static member Zero: ^U) = List.averageBy проєкция источник
    let отобрать = List.choose
    let кусокПоРазмеру = List.chunkBySize
    let собрать = List.collect
    let сравнитьС = List.compareWith
    let сцепить = List.concat
    let inline содержит значение источник = List.contains значение источник
    let посчитатьПо = List.countBy
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
    let уникальныеПо = List.distinctBy
    let пустая = List.empty
    let толькоОдин = List.exactlyOne
    let заИсключением = List.except
    let существует = List.exists
    let существует2 = List.exists2
    let фильтр = List.filter
    let найти = List.find
    let найтиСзади = List.findBack
    let найтиИндекс = List.findIndex
    let найтиИндексСзади = List.findIndexBack
    let свернуть = List.fold
    let свернуть2 = List.fold2
    let свернутьСзади = List.foldBack
    let свернутьСзади2 = List.foldBack2
    let длявсех = List.forall
    let длявсех2 = List.forall2
    let сгруппироватьПо = List.groupBy
    let голова = List.head
    let индексированая = List.indexed
    let иниц = List.init
    let вставитьВ = List.insertAt
    let вставитьМногоВ = List.insertManyAt
    let естьПустая = List.isEmpty
    let inline элемент действие список = List.item действие список
    let итер = List.iter
    let итер2 = List.iter2
    let итери = List.iteri
    let итери2 = List.iteri2
    let последний = List.last
    let длина = List.length
    let отобразить = List.map
    let отобразить2 = List.map2
    let отобразить3 = List.map3
    let отобразитьСвернуть = List.mapFold
    let отобразитьСвернутьСзади = List.mapFoldBack
    let отобразитьи = List.mapi
    let отобразитьи2 = List.mapi2
    let inline макс источник = List.max источник
    let inline максПо проєкция источник = List.maxBy проєкция источник
    let inline мин источник = List.min источник
    let inline минПо проєкция источник = List.minBy проєкция источник
    let нный = List.nth
    let изМассива = List.ofArray
    let изПосл = List.ofSeq
    let попарно = List.pairwise
    let разделить = List.partition
    let переставить = List.permute
    let выбрать = List.pick
    let редуцировать = List.reduce
    let редуцироватьСзади = List.reduceBack
    let удалитьИз = List.removeAt
    let удалитьМногоИз = List.removeManyAt
    let реплицировать = List.replicate
    let перевер = List.rev
    let сканировать = List.scan
    let сканироватьСзади = List.scanBack
    let inline синглтон значение = List.singleton значение
    let пропустить = List.skip
    let пропуститьПока = List.skipWhile
    let сортировать = List.sort
    let сортироватьПо = List.sortBy
    let inline сортироватьПоУбывание проэкция список = List.sortByDescending проэкция список
    let inline сортироватьУбывание список = List.sortDescending список
    let сортироватьС = List.sortWith
    let разделитьВ = List.splitAt
    let разделитьНа = List.splitInto
    let inline сумма список = List.sum список
    let inline суммаПо ([<InlineIfLambda>] проэкция: 'T -> ^U) (список: list<'T>) : ^U = List.sumBy проэкция список
    let хвост = List.tail
    let взять = List.take
    let взятьПока = List.takeWhile
    let кМассиву = List.toArray
    let кПосл = List.toSeq
    let транспонировать = List.transpose
    let обрезать = List.truncate
    let попробоватьТолькоОдин = List.tryExactlyOne
    let попробоватьНайти = List.tryFind
    let попробоватьНайтиСзади = List.tryFindBack
    let попробоватьНайтиИндекс = List.tryFindIndex
    let попробоватьНайтиИндексСзади = List.tryFindIndexBack
    let попробоватьГолову = List.tryHead
    let попробоватьЭлемент = List.tryItem
    let попробоватьПоследний = List.tryLast
    let попробоватьВыбрать = List.tryPick
    let развернуть = List.unfold
    let распаковать = List.unzip
    let распаковать3 = List.unzip3
    let обновитьВ = List.updateAt
    let где = List.where
    let оконная = List.windowed
    let упаковать = List.zip
    let упаковать3 = List.zip3

[<RequireQualifiedAccess; CompilationRepresentation (CompilationRepresentationFlags.ModuleSuffix)>]
module Массив =
    let всеПары = Array.allPairs
    let добавить = Array.append
    let inline среднее (массив: ^T array) : ^T when ^T: (static member (+) : ^T * ^T -> ^T) and ^T: (static member DivideByInt: ^T * int -> ^T) and ^T: (static member Zero: ^T)  = Array.average массив
    let inline среднееПо (проєкция: 'T -> ^U) (массив: ^T array) : ^U when ^U: (static member (+) : ^U * ^U -> ^U) and ^U: (static member DivideByInt: ^U * int -> ^U) and ^U: (static member Zero: ^U) = Array.averageBy проєкция массив
    let inline блит источник индексИсточника цель индексЦели количество = Array.blit источник индексИсточника цель индексЦели количество
    let отобрать = Array.choose
    let кусокПоРазмеру = Array.chunkBySize
    let собрать = Array.collect
    let inline сравнитьС сравниватель массив1 массив2 = Array.compareWith сравниватель массив1 массив2
    let сцепить = Array.concat
    let inline содержит значение массив = Array.contains значение массив
    let скопировать = Array.copy
    let посчитатьПо = Array.countBy
    let создать = Array.create
    let уникальные = Array.distinct
    let уникальныеПо = Array.distinctBy
    let пустая = Array.empty
    let толькоОдин = Array.exactlyOne
    let заИсключением = Array.except
    let inline существует предикат массив = Array.exists предикат массив
    let существует2 = Array.exists2
    let заполнить = Array.fill
    let фильтр = Array.filter
    let найти = Array.find
    let найтиСзади = Array.findBack
    let найтиИндекс = Array.findIndex
    let найтиИндексСзади = Array.findIndexBack
    let свернуть = Array.fold
    let свернуть2 = Array.fold2
    let свернутьСзади = Array.foldBack
    let свернутьСзади2 = Array.foldBack2
    let длявсех = Array.forall
    let длявсех2 = Array.forall2
    let получить = Array.get
    let сгруппироватьПо = Array.groupBy
    let голова = Array.head
    let индексированая = Array.indexed
    let inline иниц количество инициализатор = Array.init количество инициализатор
    let вставитьВ = Array.insertAt
    let вставитьМногоВ = Array.insertManyAt
    let естьПустая = Array.isEmpty
    let inline элемент действие список = Array.item действие список
    let итер = Array.iter
    let итер2 = Array.iter2
    let итери = Array.iteri
    let итери2 = Array.iteri2
    let inline последний массив = Array.last массив
    let длина = Array.length
    let inline отобразить отображение массив = Array.map отображение массив
    let отобразить2 = Array.map2
    let отобразить3 = Array.map3
    let отобразитьСвернуть = Array.mapFold
    let отобразитьСвернутьСзади = Array.mapFoldBack
    let отобразитьи = Array.mapi
    let отобразитьи2 = Array.mapi2
    let inline макс источник = Array.max источник
    let inline максПо проєкция источник = Array.maxBy проєкция источник
    let inline мин источник = Array.min источник
    let inline минПо проєкция источник = Array.minBy проєкция источник
    let изСписка = Array.ofList
    let изПосл = Array.ofSeq
    let попарно = Array.pairwise
    let разделить = Array.partition
    let переставить = Array.permute
    let выбрать = Array.pick
    let редуцировать = Array.reduce
    let редуцироватьСзади = Array.reduceBack
    let удалитьИз = Array.removeAt
    let удалитьМногоИз = Array.removeManyAt
    let реплицировать = Array.replicate
    let перевер = Array.rev
    let сканировать = Array.scan
    let сканироватьСзади = Array.scanBack
    let установить = Array.set
    let inline синглтон значение = Array.singleton значение
    let пропустить = Array.skip
    let пропуститьПока = Array.skipWhile
    let сортировать = Array.sort
    let сортироватьПо = Array.sortBy
    let inline сортироватьПоУбывание проэкция список = Array.sortByDescending проэкция список
    let inline сортироватьУбывание список = Array.sortDescending список
    let сортироватьНаМесте = Array.sortInPlace
    let сортироватьНаМестеПо = Array.sortInPlaceBy
    let сортироватьНаМестеС = Array.sortInPlaceWith
    let сортироватьС = Array.sortWith
    let разделитьВ = Array.splitAt
    let разделитьНа = Array.splitInto
    let под = Array.sub
    let inline сумма список = Array.sum список
    let inline суммаПо projection source = Array.sumBy projection source
    let хвост = Array.tail
    let взять = Array.take
    let взятьПока = Array.takeWhile
    let кСписку = Array.toList
    let кПосл = Array.toSeq
    let транспонировать = Array.transpose
    let обрезать = Array.truncate
    let попробоватьТолькоОдин = Array.tryExactlyOne
    let попробоватьНайти = Array.tryFind
    let попробоватьНайтиСзади = Array.tryFindBack
    let попробоватьНайтиИндекс = Array.tryFindIndex
    let попробоватьНайтиИндексСзади = Array.tryFindIndexBack
    let попробоватьГолову = Array.tryHead
    let попробоватьЭлемент = Array.tryItem
    let попробоватьПоследний = Array.tryLast
    let попробоватьВыбрать = Array.tryPick
    let развернуть = Array.unfold
    let распаковать = Array.unzip
    let распаковать3 = Array.unzip3
    let обновитьВ = Array.updateAt
    let где = Array.where
    let оконная = Array.windowed
    let создатьЗануленный = Array.zeroCreate
    let упаковать = Array.zip
    let упаковать3 = Array.zip3
