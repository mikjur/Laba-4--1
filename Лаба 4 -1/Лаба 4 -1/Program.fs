open System

// Определение типа дерева
type Tree =
    | Node of string * Tree * Tree 
    | Empty                        

// Функция для применения функции к каждому узлу дерева
let rec treeMap f tree =
    match tree with
    | Node(data, left, right) ->
        Node(f data, treeMap f left, treeMap f right)
    | Empty -> Empty  

// Функция для дублирования строки
let two_word (s: string) = s + s

// Функция для ввода дерева с клавиатуры
let rec inputTree () =
    printfn "Введите значение узла (или 'stop' для завершения):"
    let input = Console.ReadLine()
    if input = "stop" then
        Empty
    else
        printfn "Введите левое поддерево для узла '%s':" input
        let left = inputTree ()
        printfn "Введите правое поддерево для узла '%s':" input
        let right = inputTree ()
        Node(input, left, right)

// Функция для вывода дерева
let rec printTree tree space =
    match tree with
    | Node(data, left, right) ->
        printTree right (space + 10)
        printfn "%s%s" (String(' ', space)) data
        printTree left (space + 10)
    | Empty -> ()

// Основная программа
[<EntryPoint>]
let main argv =
    printfn "Введите бинарное дерево:"
    let tree = inputTree ()  

    printfn "\nИсходное дерево:"
    printTree tree 0

    let newTree = treeMap two_word tree  
    printfn "\nДерево с дублированными строками:"
    printTree newTree 0

    0 // Возвращаем код завершения программы