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
module Операції =
  нехай inline провалитисяз повідомлення = failwith повідомлення
  нехай inline провалитисязф повідомлення = failwithf повідомлення

[<AutoOpen>]
module ДодатковіОпераціїВерхньогоРівня =
    
  ///<summary>Builds an asynchronous workflow using computation expression syntax.</summary>
  ///<example id="async-1"><code lang="fsharp">
  /// нехай sleepExample() =
  ///     async {
  ///         printfn "sleeping"
  ///         do! Async.Sleep 10
  ///         printfn "waking up"
  ///         return 6
  ///      }
  ///
  /// sleepExample() |&gt; Async.RunSynchronously
  /// </code></example>
  [<CompiledName ("DefaultAsyncBuilder")>]
  нехай асинх = async

  ///<summary>Builds a read-only lookup table from a sequence of key/value pairs. The key objects are indexed using generic hashing and equality.</summary>
  ///<example id="dict-1"><code lang="fsharp">
  /// нехай table = dict [ (1, 100); (2, 200) ]
  ///
  /// table[1]
  /// </code>
  /// Evaluates to <c>100</c>.
  /// </example>
  ///<example id="dict-2"><code lang="fsharp">
  /// нехай table = dict [ (1, 100); (2, 200) ]
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
        нехай маркерСкасування =
            defaultArg маркерСкасування Async.DefaultCancellationToken
        Async.Start( обчислення, маркерСкасування)
      static member ВиконатиСинхронно(обчислення: Async<unit>, ?таймаут: int, ?маркерСкасування: System.Threading.CancellationToken) = 
        нехай маркерСкасування =
            defaultArg маркерСкасування Async.DefaultCancellationToken
        нехай таймаут =
            defaultArg таймаут System.Threading.Timeout.Infinite
        Async.RunSynchronously( обчислення, таймаут, маркерСкасування)


///<summary>Contains operations for working with values of type <see cref="T:Microsoft.FSharp.Collections.seq`1" />.</summary>
[<RequireQualifiedAccess; CompilationRepresentation (CompilationRepresentationFlags.ModuleSuffix)>]
module Посл =
    нехай усіПари = Seq.allPairs
    нехай додати = Seq.append
    нехай inline середне (джерело: ^T seq) : ^T when ^T: (static member (+) : ^T * ^T -> ^T) and ^T: (static member DivideByInt: ^T * int -> ^T) and ^T: (static member Zero: ^T)  = Seq.average джерело
    нехай inline середнеПо (проекція: 'T -> ^U) (джерело: ^T seq) : ^U when ^U: (static member (+) : ^U * ^U -> ^U) and ^U: (static member DivideByInt: ^U * int -> ^U) and ^U: (static member Zero: ^U) = Seq.averageBy проекція джерело
    нехай кешувати = Seq.cache
    нехай перетворити = Seq.cast
    нехай відібрати = Seq.choose
    нехай кусокПоРозміру = Seq.chunkBySize
    нехай зібрати = Seq.collect
    нехай порівнятиІз = Seq.compareWith
    нехай зчепити = Seq.concat
    нехай inline містить значення джерело = Seq.contains значення джерело
    нехай кількістьЗа = Seq.countBy
    нехай затримка = Seq.delay
    нехай уникальні = Seq.distinct
    нехай унікальніЗа = Seq.distinctBy
    нехай пуста = Seq.empty
    нехай лишеОдин = Seq.exactlyOne
    нехай заВиключенням = Seq.except
    нехай існує = Seq.exists
    нехай існує2 = Seq.exists2
    нехай фільтр = Seq.filter
    нехай знайти = Seq.find
    нехай знайтиЗзаду = Seq.findBack
    нехай знайтиІндекс = Seq.findIndex
    нехай знайтиІндексЗзаду = Seq.findIndexBack
    нехай скласти = Seq.fold
    нехай скласти2 = Seq.fold2
    нехай скластиЗзаду = Seq.foldBack
    нехай скластиЗзаду2 = Seq.foldBack2
    нехай дляусіх = Seq.forall
    нехай дляусіх2 = Seq.forall2
    нехай згрупуватиЗа = Seq.groupBy
    нехай голова = Seq.head
    нехай індексована = Seq.indexed
    нехай ініц = Seq.init
    нехай ініцНескінченну = Seq.initInfinite
    нехай вставитиУ = Seq.insertAt
    нехай вставитиБагатоУ = Seq.insertManyAt
    нехай єПуста = Seq.isEmpty
    нехай елемент = Seq.item
    нехай ітер = Seq.iter
    нехай ітер2 = Seq.iter2
    нехай ітері = Seq.iteri
    нехай ітері2 = Seq.iteri2
    нехай останній = Seq.last
    нехай довжина = Seq.length
    нехай відобразити = Seq.map
    нехай відобразити2 = Seq.map2
    нехай відобразити3 = Seq.map3
    нехай відобразитиСкласти = Seq.mapFold
    нехай відобразитиСкластиЗзаду = Seq.mapFoldBack
    нехай відобразитиі = Seq.mapi
    нехай відобразитиі2 = Seq.mapi2
    нехай inline макс джерело = Seq.max джерело
    нехай inline максЗа проекция джерело = Seq.maxBy проекция джерело
    нехай inline мін джерело = Seq.min джерело
    нехай inline мінЗа проекция джерело = Seq.minBy проекция джерело
    нехай нний = Seq.nth
    нехай ізМасива = Seq.ofArray
    нехай ізСписку = Seq.ofList
    нехай попарно = Seq.pairwise
    нехай переставити = Seq.permute
    нехай вибрати = Seq.pick
    нехай длячитання = Seq.readonly
    нехай редуцирувати = Seq.reduce
    нехай редуцируватиЗзаду = Seq.reduceBack
    нехай видалитиЗ = Seq.removeAt
    нехай видалитиБагатоЗ = Seq.removeManyAt
    нехай репликувати = Seq.replicate
    нехай перевер = Seq.rev
    нехай сканувати = Seq.scan
    нехай скануватиЗзаду = Seq.scanBack
    нехай сінглтон = Seq.singleton
    нехай пропустити = Seq.skip
    нехай пропуститьДоки = Seq.skipWhile
    нехай сортувати = Seq.sort
    нехай сортуватиЗа = Seq.sortBy
    нехай сортуватиЗаЗменшування = Seq.sortByDescending
    нехай сортуватиЗменшування = Seq.sortDescending
    нехай сортуватиІз = Seq.sortWith
    нехай розділитиНа = Seq.splitInto
    нехай inline сума источник = Seq.sum источник
    нехай inline сумаПо ([<InlineIfLambda>] проекція: 'T -> ^U) (джерело: seq<'T>) : ^U = Seq.sumBy проекція джерело
    нехай хвіст = Seq.tail
    нехай взяти = Seq.take
    нехай взятиДоки = Seq.takeWhile
    нехай доМасива = Seq.toArray
    нехай доСписка = Seq.toList
    нехай транспонувати = Seq.transpose
    нехай урізати = Seq.truncate
    нехай спробуватиЛишеОдин = Seq.tryExactlyOne
    нехай спробуватиЗнайти = Seq.tryFind
    нехай спробуватиЗнайтиЗзаду = Seq.tryFindBack
    нехай спробуватиЗнайтиІндекс = Seq.tryFindIndex
    нехай спробуватиЗнайтиІндексЗзаду = Seq.tryFindIndexBack
    нехай спробуватиГолову = Seq.tryHead
    нехай спробуватиЕлемент = Seq.tryItem
    нехай спробуватиОстанній = Seq.tryLast
    нехай спробуватиВибрати = Seq.tryPick
    нехай развернути = Seq.unfold
    нехай оновитиУ = Seq.updateAt
    нехай де = Seq.where
    нехай віконна = Seq.windowed
    нехай упакувати = Seq.zip
    нехай упакувати3 = Seq.zip3
    ;
///<summary>Contains operations for working with values of type <see cref="T:Microsoft.FSharp.Collections.list`1" />.</summary>
///<namespacedoc><summary>Operations for collections such as lists, arrays, sets, maps and sequences. See also 
///    <a href="https://docs.microsoft.com/dotnet/fsharp/language-reference/fsharp-collection-types">F# Collection Types</a> in the F# Language Guide.
/// </summary></namespacedoc>
[<RequireQualifiedAccess; CompilationRepresentation (CompilationRepresentationFlags.ModuleSuffix)>]
module Список =    
    нехай усіПари = List.allPairs
    нехай додати = List.append
    нехай inline середне (джерело: ^T list) : ^T when ^T: (static member (+) : ^T * ^T -> ^T) and ^T: (static member DivideByInt: ^T * int -> ^T) and ^T: (static member Zero: ^T)  = List.average джерело
    нехай inline середнеПо (проекція: 'T -> ^U) (джерело: ^T list) : ^U when ^U: (static member (+) : ^U * ^U -> ^U) and ^U: (static member DivideByInt: ^U * int -> ^U) and ^U: (static member Zero: ^U) = List.averageBy проекція джерело
    нехай відібрати = List.choose
    нехай кусокПоРозміру = List.chunkBySize
    нехай зібрати = List.collect
    нехай порівнятиІз = List.compareWith
    нехай зчепити = List.concat
    нехай inline містить значення джерело = List.contains значення джерело
    нехай кількістьЗа = List.countBy
    ///<summary>Returns a list that contains no duplicate entries according to generic hash and
    /// equality comparisons on the entries.
    /// If an element occurs multiple times in the list then the later occurrences are discarded.</summary>
    ///<param name="list">The input list.</param>
    ///<returns>The result list.</returns>
    ///<example id="distinct-1"><code lang="fsharp">
    /// нехай input = [6;1;2;3;1;4;5;5]
    ///
    /// input |&gt; List.distinct
    /// </code>
    /// Evaluates to <c>[6; 1; 2; 3; 4; 5]</c>.
    /// </example>
    нехай уникальні = List.distinct
    нехай унікальніЗа = List.distinctBy
    нехай пустий = List.empty
    нехай лишеОдин = List.exactlyOne
    нехай заВиключенням = List.except
    нехай існує = List.exists
    нехай існує2 = List.exists2
    нехай фільтр = List.filter
    нехай знайти = List.find
    нехай знайтиЗзаду = List.findBack
    нехай знайтиІндекс = List.findIndex
    нехай знайтиІндексЗзаду = List.findIndexBack
    нехай скласти = List.fold
    нехай скласти2 = List.fold2
    нехай скластиЗзаду = List.foldBack
    нехай скластиЗзаду2 = List.foldBack2
    нехай дляусіх = List.forall
    нехай дляусіх2 = List.forall2
    нехай згрупуватиЗа = List.groupBy
    нехай голова = List.head
    нехай індексована = List.indexed
    нехай ініц = List.init
    нехай вставитиУ = List.insertAt
    нехай вставитиБагатоУ = List.insertManyAt
    нехай єПустий = List.isEmpty
    нехай inline елемент дія список = List.item дія список
    нехай ітер = List.iter
    нехай ітер2 = List.iter2
    нехай ітері = List.iteri
    нехай ітері2 = List.iteri2
    нехай останній = List.last
    нехай довжина = List.length
    нехай відобразити = List.map
    нехай відобразити2 = List.map2
    нехай відобразити3 = List.map3
    нехай відобразитиСкласти = List.mapFold
    нехай відобразитиСкластиЗзаду = List.mapFoldBack
    нехай відобразитиі = List.mapi
    нехай відобразитиі2 = List.mapi2
    нехай inline макс джерело = List.max джерело
    нехай inline максПо проекция джерело = List.maxBy проекция джерело
    нехай inline мін джерело = List.min джерело
    нехай inline мінПо проекция джерело = List.minBy проекция джерело
    нехай нний = List.nth
    нехай ізМасива = List.ofArray
    нехай ізПосл = List.ofSeq
    нехай попарно = List.pairwise
    нехай розділити = List.partition
    нехай переставити = List.permute
    нехай вибрати = List.pick
    нехай редуцирувати = List.reduce
    нехай редуцируватиЗзаду = List.reduceBack
    нехай видалитиЗ = List.removeAt
    нехай видалитиБагатоЗ = List.removeManyAt
    нехай репликувати = List.replicate
    нехай перевер = List.rev
    нехай сканувати = List.scan
    нехай скануватиЗзаду = List.scanBack
    нехай inline сінглтон значення = List.singleton значення
    нехай пропустити = List.skip
    нехай пропуститьДоки = List.skipWhile
    нехай сортувати = List.sort
    нехай сортуватиЗа = List.sortBy
    нехай inline сортуватиЗаЗменшування проекция список = List.sortByDescending проекция список
    нехай inline сортуватиЗменшування список = List.sortDescending список
    нехай сортуватиІз = List.sortWith
    нехай разделитьУ = List.splitAt
    нехай розділитиНа = List.splitInto
    нехай inline сума список = List.sum список
    нехай inline сумаПо ([<InlineIfLambda>] проекция: 'T -> ^U) (список: list<'T>) : ^U = List.sumBy проекция список
    нехай хвіст = List.tail
    нехай взяти = List.take
    нехай взятиДоки = List.takeWhile
    нехай доМасива = List.toArray
    нехай доПосл = List.toSeq
    нехай транспонувати = List.transpose
    нехай урізати = List.truncate
    нехай спробуватиЛишеОдин = List.tryExactlyOne
    нехай спробуватиЗнайти = List.tryFind
    нехай спробуватиЗнайтиЗзаду = List.tryFindBack
    нехай спробуватиЗнайтиІндекс = List.tryFindIndex
    нехай спробуватиЗнайтиІндексЗзаду = List.tryFindIndexBack
    нехай спробуватиГолову = List.tryHead
    нехай спробуватиЕлемент = List.tryItem
    нехай спробуватиОстанній = List.tryLast
    нехай спробуватиВибрати = List.tryPick
    нехай развернути = List.unfold
    нехай разпакувати = List.unzip
    нехай разпакувати3 = List.unzip3
    нехай оновитиУ = List.updateAt
    нехай де = List.where
    нехай віконна = List.windowed
    нехай упакувати = List.zip
    нехай упакувати3 = List.zip3

[<RequireQualifiedAccess; CompilationRepresentation (CompilationRepresentationFlags.ModuleSuffix)>]
module Масив =
    нехай усіПари = Array.allPairs
    нехай додати = Array.append
    нехай inline середне (масив: ^T array) : ^T when ^T: (static member (+) : ^T * ^T -> ^T) and ^T: (static member DivideByInt: ^T * int -> ^T) and ^T: (static member Zero: ^T)  = Array.average масив
    нехай inline середнеПо (проекція: 'T -> ^U) (масив: ^T array) : ^U when ^U: (static member (+) : ^U * ^U -> ^U) and ^U: (static member DivideByInt: ^U * int -> ^U) and ^U: (static member Zero: ^U) = Array.averageBy проекція масив
    нехай inline бліт джерело індексДжерела ціль індексЦілі кількість = Array.blit джерело індексДжерела ціль індексЦілі кількість
    нехай відібрати = Array.choose
    нехай кусокПоРозміру = Array.chunkBySize
    нехай зібрати = Array.collect
    нехай inline порівнятиІз порівнювач масив1 масив2 = Array.compareWith порівнювач масив1 масив2
    нехай зчепити = Array.concat
    нехай inline містить значення масив = Array.contains значення масив
    нехай скопіювати = Array.copy
    нехай кількістьЗа = Array.countBy
    нехай створити = Array.create
    нехай уникальні = Array.distinct
    нехай унікальніЗа = Array.distinctBy
    нехай пустий = Array.empty
    нехай лишеОдин = Array.exactlyOne
    нехай заВиключенням = Array.except
    нехай inline існує предікат масив = Array.exists предікат масив
    нехай існує2 = Array.exists2
    нехай заповнити = Array.fill
    нехай фільтр = Array.filter
    нехай знайти = Array.find
    нехай знайтиЗзаду = Array.findBack
    нехай знайтиІндекс = Array.findIndex
    нехай знайтиІндексЗзаду = Array.findIndexBack
    нехай скласти = Array.fold
    нехай скласти2 = Array.fold2
    нехай скластиЗзаду = Array.foldBack
    нехай скластиЗзаду2 = Array.foldBack2
    нехай дляусіх = Array.forall
    нехай дляусіх2 = Array.forall2
    нехай отримати = Array.get
    нехай згрупуватиЗа = Array.groupBy
    нехай голова = Array.head
    нехай індексована = Array.indexed
    нехай inline іниц кількість ініціалізатор = Array.init кількість ініціалізатор
    нехай вставитиУ = Array.insertAt
    нехай вставитиБагатоУ = Array.insertManyAt
    нехай єПустий = Array.isEmpty
    нехай inline елемент дія масив = Array.item дія масив
    нехай ітер = Array.iter
    нехай ітер2 = Array.iter2
    нехай ітері = Array.iteri
    нехай ітері2 = Array.iteri2
    нехай inline останній масив = Array.last масив
    нехай довжина = Array.length
    нехай inline відобразити відображення масив = Array.map відображення масив
    нехай відобразити2 = Array.map2
    нехай відобразити3 = Array.map3
    нехай відобразитиСкласти = Array.mapFold
    нехай відобразитиСкластиЗзаду = Array.mapFoldBack
    нехай відобразитиі = Array.mapi
    нехай відобразитиі2 = Array.mapi2
    нехай inline макс масив = Array.max масив
    нехай inline максПо проекция масив = Array.maxBy проекция масив
    нехай inline мін масив = Array.min масив
    нехай inline мінПо проекция масив = Array.minBy проекция масив
    нехай ізСписка = Array.ofList
    нехай ізПосл = Array.ofSeq
    нехай попарно = Array.pairwise
    нехай розділити = Array.partition
    нехай переставити = Array.permute
    нехай вибрати = Array.pick
    нехай редуцирувати = Array.reduce
    нехай редуцируватиЗзаду = Array.reduceBack
    нехай видалитиЗ = Array.removeAt
    нехай видалитиБагатоЗ = Array.removeManyAt
    нехай репликувати = Array.replicate
    нехай перевер = Array.rev
    нехай сканувати = Array.scan
    нехай скануватиЗзаду = Array.scanBack
    нехай встановити = Array.set
    нехай inline сінглтон значення = Array.singleton значення
    нехай пропустити = Array.skip
    нехай пропуститьДоки = Array.skipWhile
    нехай сортувати = Array.sort
    нехай сортуватиЗа = Array.sortBy
    нехай inline сортуватиЗаЗменшування проекция масив = Array.sortByDescending проекция масив
    нехай inline сортуватиЗменшування масив = Array.sortDescending масив
    нехай сортуватиНаМісці = Array.sortInPlace
    нехай сортуватиНаМісціЗі = Array.sortInPlaceBy
    нехай сортуватиНаМісціІз = Array.sortInPlaceWith
    нехай сортуватиІз = Array.sortWith
    нехай разделитьУ = Array.splitAt
    нехай розділитиНа = Array.splitInto
    нехай під = Array.sub
    нехай inline сумма масив = Array.sum масив
    нехай inline суммаПо проекція масив = Array.sumBy проекція масив
    нехай хвіст = Array.tail
    нехай взяти = Array.take
    нехай взятиДоки = Array.takeWhile
    нехай доМасива = Array.toList
    нехай доПосл = Array.toSeq
    нехай транспонувати = Array.transpose
    нехай урізати = Array.truncate
    нехай спробуватиЛишеОдин = Array.tryExactlyOne
    нехай спробуватиЗнайти = Array.tryFind
    нехай спробуватиЗнайтиЗзаду = Array.tryFindBack
    нехай спробуватиЗнайтиІндекс = Array.tryFindIndex
    нехай спробуватиЗнайтиІндексЗзаду = Array.tryFindIndexBack
    нехай спробуватиГолову = Array.tryHead
    нехай спробуватиЕлемент = Array.tryItem
    нехай спробуватиОстанній = Array.tryLast
    нехай спробуватиВибрати = Array.tryPick
    нехай развернути = Array.unfold
    нехай разпакувати = Array.unzip
    нехай разпакувати3 = Array.unzip3
    нехай оновитиУ = Array.updateAt
    нехай де = Array.where
    нехай віконна = Array.windowed
    нехай створитиЗанульований = Array.zeroCreate
    нехай упакувати = Array.zip
    нехай упакувати3 = Array.zip3
