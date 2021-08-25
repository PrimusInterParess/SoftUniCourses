namespace _02.Two_Three
{
    using System;
    using System.Text;

    public class TwoThreeTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public void Insert(T key)
        {
            root = this.InsertNode(root, key);
        }

        private TreeNode<T> InsertNode(TreeNode<T> node, T key)
        {
            if (node == null)
            {
                return new TreeNode<T>(key);
            }

            TreeNode<T> toReturn = null;

            if (node.IsLeaf())
            {
                return MergeNode(node, new TreeNode<T>(key));
            }

            if (key.CompareTo(node.LeftKey) < 0)
            {
                toReturn = this.InsertNode(node.LeftChild, key);

                if (toReturn == node.LeftChild)
                {
                    return node;
                }
                else
                {
                     return this.MergeNode(node, toReturn);
                }
            }
            else if (node.IsTwoNode() || key.CompareTo(node.RightKey) < 0)
            {
                toReturn = this.InsertNode(node.MiddleChild, key);

                if (toReturn == node.MiddleChild)
                {
                    return node;
                }

                else
                {
                    return this.MergeNode(node,toReturn);
                }
            }
            else
            {
                toReturn = this.InsertNode(node.RightChild, key);
                if (toReturn == node.RightChild)
                {
                    return node;
                }
                else
                {
                     return this.MergeNode(node, toReturn);
                }
            }

        }

        private TreeNode<T> MergeNode(TreeNode<T> a, TreeNode<T> b)
        {
            if (a.RightKey == null)
            {
                if (a.LeftKey.CompareTo(b.LeftKey) < 0)
                {
                    a.RightKey = b.LeftKey;
                    a.MiddleChild = b.LeftChild;
                    a.RightChild = b.MiddleChild;
                }
                else
                {
                    a.RightKey = a.LeftKey;
                    a.RightChild = a.MiddleChild;
                    a.LeftKey = b.LeftKey;
                    a.MiddleChild = b.MiddleChild;
                }

                return a;
            }
            else if (a.LeftKey.CompareTo(b.LeftKey) >= 0)
            {
                TreeNode<T> mergeNode = new TreeNode<T>(a.LeftKey)
                {
                    LeftChild = b,
                    MiddleChild = a
                };

                b.LeftChild=a.LeftChild;
                a.LeftChild = a.MiddleChild;
                a.MiddleChild = a.RightChild;
                a.RightChild = null;
                a.LeftKey = a.RightKey;
                a.RightKey = default(T);

                return mergeNode;

            }
            else if (a.RightKey.CompareTo(b.LeftKey) >= 0)
            {
                b.MiddleChild = new TreeNode<T>(a.RightKey)
                {
                    LeftChild =b.MiddleChild,
                    MiddleChild = a.RightChild 
                };
                b.LeftChild = a;
                a.RightKey = default(T);
                a.RightChild = null;

                return b;
            }
            else
            {
                TreeNode<T> mergedNode = new TreeNode<T>(a.RightKey)
                {
                    LeftChild = a,
                    MiddleChild = b
                };

                b.LeftChild = a.RightChild;
                a.RightChild = null;
                a.RightKey = default(T);

                return mergedNode;
            }


        }


        public override String ToString()
        {
            StringBuilder sb = new StringBuilder();
            RecursivePrint(this.root, sb);
            return sb.ToString();
        }

        private void RecursivePrint(TreeNode<T> node, StringBuilder sb)
        {
            if (node == null)
            {
                return;
            }

            if (node.LeftKey != null)
            {
                sb.Append(node.LeftKey).Append(" ");
            }

            if (node.RightKey != null)
            {
                sb.Append(node.RightKey).Append(Environment.NewLine);
            }
            else
            {
                sb.Append(Environment.NewLine);
            }

            if (node.IsTwoNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
            }
            else if (node.IsThreeNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
                RecursivePrint(node.RightChild, sb);
            }
        }
    }
}
