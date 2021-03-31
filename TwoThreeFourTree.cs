using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alg_Lab2
{
    class TwoThreeFourTree
    {
        public TwoThreeFourTree Parent
        {
            get; private set;
        }
        public TwoThreeFourTree Left
        {
            get; private set;
        }
        public TwoThreeFourTree MiddleLeft
        {
            get; private set;
        }
        public TwoThreeFourTree MiddleRight
        {
            get; private set;
        }
        public TwoThreeFourTree Right
        {
            get; private set;
        }

        private List<int> _values = new List<int>();

        public List<int> Values
        {
            get => _values;
            set => _values = value.OrderBy(number => number).ToList();
        }

        public int Type => _values.Count + 1;

        public TwoThreeFourTree(int value, TwoThreeFourTree parent = null)
        {
            ValueMiddle = value;
        }

        public TwoThreeFourTree(int? valueMiddle, TwoThreeFourTree parent)
        {
            ValueMiddle = valueMiddle;
            Parent = parent;
        }

        public List<TwoThreeFourTree> Children = new List<TwoThreeFourTree>();

        public bool IsParent => Parent == null;

        public static TwoThreeFourTree GetHead(TwoThreeFourTree tree)
        {
            if (tree == null)
                return null;

            var head = tree;

            while (!head.IsParent)
            {
                head =  head.Parent;
            }

            return head;
        }

        public static void Add(int value, TwoThreeFourTree tree)
        {
            switch (tree.Type)
            {
                case 4:
                    if (tree.IsParent)
                    {
                        int middle = tree.Values[1];
                        var vals = tree.Values;

                        var list = new List<int>
                        {
                            middle
                        };
                        tree.Values = list;

                        var tree1 = new TwoThreeFourTree(vals[0], tree);
                        var tree2 = new TwoThreeFourTree(vals[2], tree);

                        if (tree.Left!= null)
                            tree.Left.Parent = tree1;
                        if (tree.MiddleLeft != null)
                            tree.MiddleLeft.Parent = tree1;
                        if (tree.MiddleRight != null)
                            tree.MiddleRight.Parent = tree2;
                        if (tree.Right != null)
                            tree.Right.Parent = tree2;

                        tree1.Left = tree.Left;
                        tree1.Right = tree.MiddleLeft;

                        tree2.Left = tree.MiddleRight;
                        tree2.Right = tree.Right;
                    }
                    else
                    {
                        var valsParent = tree.Parent.Values;
                        valsParent.Add(tree.Values[1]);
                        tree.Values = valsParent;

                        var vals = tree.Values;

                        var tree3 = new TwoThreeFourTree(vals[1], tree.Parent);

                        for (int i = 0; i < tree.Parent.Children.Count; i++)
                        {
                            if (tree == tree.Parent.Children[i])
                            {
                                tree.Parent.Children[i] = tree3;
                                break;
                            }
                        }
                        
                        var tree1 = new TwoThreeFourTree(vals[0], tree3);
                        var tree2 = new TwoThreeFourTree(vals[2], tree3);

                        tree3.Left = tree1;
                        tree3.Right = tree2;

                        tree1.Left = tree.Left;
                        tree1.Right = tree.MiddleLeft;

                        tree2.Left = tree.MiddleRight;
                        tree2.Right = tree.Right;
                    }
                    if ()
                    {

                    }
                    break;
                default:
                    break;
            }


            //4-узел
            /*if (ValueLeft != null && ValueMiddle != null && ValueRight != null)
            {
                int middle = (int)ValueMiddle;

                ValueMiddle = null;
                Left = new TwoThreeFourTree((int)ValueLeft, this);
                Right = new TwoThreeFourTree((int)ValueRight, this);

                ValueLeft = null;
                ValueRight = null;

                if (IsParent)
                {
                    var root = new TwoThreeFourTree(middle);
                    Parent = root;
                    if ()
                    {

                    }
                }
            }
            //Лист
            if (Left == null && MiddleLeft == null && MiddleRight == null && Right == null)
            {

            }*/
        }
    }
}
