open System
type Tree =
    | Node of string * Tree * Tree 
    | Empty                        

let rec treeMap f tree =
    match tree with
    | Node(data, left, right) ->
        Node(f data, treeMap f left, treeMap f right)
    | Empty -> Empty  

let duplicate (s: string) = s + s

// Создание бинарного дерева
let Tree =
    Node("Март",
        Node("Январь",
            Node("Ноябрь", Empty, Empty),  // Левое поддерево: узел со значением "Я"
            Node("Февраль", Empty, Empty)  // Правое поддерево: узел со значением "Sonik"
        ),
        Node("Май",
            Node("Апрель", Empty, Empty),  // Левое поддерево: узел со значением "Lsp"
            Node("Июнь", Empty, Empty)  // Правое поддерево: узел со значением "4567"
        )
    )

let newTree = treeMap duplicate Tree
// Функция для вывода дерева
let rec printTree tree space =
    match tree with
    | Node(data, left, right) ->
        printTree right (space + 10)
        printfn "%s%s" (String(' ', space)) data
        printTree left (space + 10)
    | Empty -> ()

printfn "Исходное дерево:"
printTree Tree 0
printfn "\nДерево с дублированными строками:"
printTree newTree 0