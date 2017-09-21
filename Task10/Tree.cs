using System;
using System.Collections.Generic;
using System.Text;

namespace Task10
{
    public class Tree //создание дерева
    {
        public class Node //узел дерева
        {
            public Node Left { get; set; } //указатели узла
            public Node Right { get; set; }
            public int value; //вставляемое значение

            public Node(int val)
            {
                value = val; //конструктор заполняет узел значением
                Left = null;
                Right = null;
            }

            public int Length()
            {
                if (Left == null && Right == null)
                    return 1;

                if (Left == null)
                    return Right.Length() + 1;
                if (Right == null)
                    return Left.Length() + 1;
                return Math.Max(Right.Length(), Left.Length()) + 1;
            }

            public List<int> level(int i)
            {
                if(i == 0)
                    return new List<int>{value};

                var result = new List<int>(0);
                if (Right != null)
                    result.AddRange(Right.level(i - 1));
                if (Left != null)
                    result.AddRange(Left.level(i - 1));
                return result;
            }
        }

        public Node Root; //корень дерева
        public int Length => Root.Length();

        private int[] _nodesOnLevels;

        public Tree() //конструктор (по умолчанию) создания дерева
        {
            Root = null; //при создании корень не определен
        }
        public Tree(int value)
        {
            Root = new Node(value); //если изначально задаём корневое значение
        }

        //нерекурсивное добавление
        public void Add(int value) //узел и его значение
        {
            if (Root == null) //если элемента нет
            {
                Root = new Node(value); //добавляем 
                return;
            }

            Node current = Root; //текущий равен корневому


            bool added = false;
            //обходим дерево
            do
            {
                if (value >= current.value) //идём вправо
                {
                    if (current.Right == null)
                    {
                        current.Right = new Node(value);
                        added = true;

                    }
                    else
                    {
                        current = current.Right;
                    }

                }
                if (value < current.value) //идём влево
                {
                    if (current.Left == null)
                    {
                        current.Left = new Node(value);
                        added = true;
                    }
                    else
                    {
                        current = current.Left;
                    }
                }
            } while (!added);
        }

        public static void Create(int[] values, Tree t)
        {
            foreach (var t1 in values)
            {
                t.Add(t1);
            }
        }

        public List<int> Level(int level)
        {
            return Root.level(level);
        }
        public int[] NodesOnLevel()
        {
            _nodesOnLevels = new int[Length];
            var result = new List<int>(0);
            for (int i = 0; i < Length; i++)
            {
                result.AddRange(Level(i));
                _nodesOnLevels[i] = Root.level(i).Count;
            }
            return _nodesOnLevels;
        }

        public static void ShowTree(Node r, int size) // вывод дерева
        {
            if (r != null)
            {
                ShowTree(r.Left, size + 4);//переход к левому поддереву
                for (int i = 0; i < size; i++) Console.Write(" ");
                Console.WriteLine(r.value);
                ShowTree(r.Right, size + 4);//переход к правому поддереву
            }
        }
    }
}


