using System.Text;

namespace _02.DOM
{
    using System;
    using System.Collections.Generic;
    using _02.DOM.Interfaces;
    using _02.DOM.Models;

    public class DocumentObjectModel : IDocument
    {
        public DocumentObjectModel(IHtmlElement root)
        {
            this.Root = root;

        }

        public IHtmlElement Root { get; set; }

        public IHtmlElement GetElementByType(ElementType type)
        {
            Queue<IHtmlElement> q = new Queue<IHtmlElement>();

            IHtmlElement element = null;

            q.Enqueue(this.Root);

            while (q.Count > 0)
            {
                var currentTree = q.Dequeue();

                if (currentTree.Type.Equals(type))
                {
                    return currentTree;
                }

                foreach (var child in currentTree.Children)
                {
                    q.Enqueue(child);
                }
            }

            return element;
        }

        public List<IHtmlElement> GetElementsByType(ElementType type)
        {

            var result = new List<IHtmlElement>();

            this.Dfs(this.Root, result, type);

            return result;


        }

        public bool Contains(IHtmlElement htmlElement)
        {
            var queue = new Queue<IHtmlElement>();

            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();

                if (subTree.Equals(htmlElement))
                {
                    return true;
                }

                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return false;
        }

        public void InsertFirst(IHtmlElement parent, IHtmlElement child)
        {

            var father = this.FindTreeDfs(parent, this.Root);

            if (father == null)
            {
                throw new InvalidOperationException();
            }

            child.Parent = father;
            parent.Children.Insert(0, child);


            //var queue = new Queue<IHtmlElement>();
            //bool hasParent = false;

            //queue.Enqueue(this.Root);

            //while (queue.Count > 0)
            //{
            //    var subTree = queue.Dequeue();

            //    if (subTree.Equals(parent))
            //    {
            //        subTree.Parent.Children[0]=child;
            //        hasParent = true;

            //    }

            //    foreach (var kids in subTree.Children)
            //    {
            //        queue.Enqueue(child);
            //    }
            //}

            //if (!hasParent)
            //{
            //    throw new InvalidOperationException();
            //}

        }

        private IHtmlElement FindTreeDfs(IHtmlElement parent, IHtmlElement root)
        {

            foreach (var child in root.Children)
            {
                IHtmlElement current = FindTreeDfs(parent, child);

                if (current != null && current.Equals(parent))
                {
                    return current;
                }
            }

            if (root.Equals(parent))
            {
                return root;
            }

            return null;
        }

        public void InsertLast(IHtmlElement parent, IHtmlElement child)
        {

            var father = this.FindTreeDfs(parent, this.Root);

            if (father == null)
            {
                throw new InvalidOperationException();
            }

            child.Parent = father;
            parent.Children.Add(child);
        }

        public void Remove(IHtmlElement htmlElement)
        {

            IHtmlElement current = FindTreeBfs(htmlElement);

            if (current == null)
            {
                throw new InvalidOperationException();
            }

            foreach (var child in current.Children)
            {
                child.Parent = null;
            }

            current.Children.Clear();

            var parent = current.Parent;

            parent.Children.Remove(current);
            current.Parent = null;



        }



        public void RemoveAll(ElementType elementType)
        {
            Queue<IHtmlElement> q = new Queue<IHtmlElement>();

            q.Enqueue(this.Root);

            while (q.Count > 0)
            {
                var currentNode = q.Dequeue();

                foreach (var child in currentNode.Children)
                {
                    q.Enqueue(child);
                }

                if (currentNode.Type.Equals(elementType))
                {
                    currentNode.Parent.Children.Remove(currentNode);
                    currentNode.Parent = null;
                    currentNode.Children.Clear();

                }
            }


        }

        public bool AddAttribute(string attrKey, string attrValue, IHtmlElement htmlElement)
        {
            IHtmlElement element = FindTreeBfs(htmlElement);

            if (element == null)
            {
                throw new InvalidOperationException();
            }

            if (element.Attributes.ContainsKey(attrKey))
            {
                return false;
            }

            element.Attributes.Add(attrKey, attrValue);

            return true;
        }

        public bool RemoveAttribute(string attrKey, IHtmlElement htmlElement)
        {
            IHtmlElement element = FindTreeBfs(htmlElement);

            if (element == null)
            {
                throw new InvalidOperationException();
            }

            if (!element.Attributes.ContainsKey(attrKey))
            {
                return false;
            }

            element.Attributes.Remove(attrKey);

            return true;
        }

        public IHtmlElement GetElementById(string idValue)
        {
            IHtmlElement element = this.GetByIdBfs(this.Root, idValue);

            return element;


        }

        private IHtmlElement GetByIdBfs(IHtmlElement root, string idValue)
        {
            var queue = new Queue<IHtmlElement>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();



                if (subTree.Attributes.ContainsKey("id"))
                {
                    if (subTree.Attributes["id"] == idValue)
                    {
                        return subTree;
                    }

                }

                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;


        }

        private void Dfs(IHtmlElement tree, List<IHtmlElement> result, ElementType type)
        {

            foreach (var child in tree.Children)
            {
                this.Dfs(child, result, type);

            }

            if (tree.Type.Equals(type))
            {
                result.Add(tree);
            }

        }

        private IHtmlElement FindTreeBfs(IHtmlElement htmlElement)
        {
            Queue<IHtmlElement> q = new Queue<IHtmlElement>();

            q.Enqueue(this.Root);

            while (q.Count > 0)
            {
                var currentNode = q.Dequeue();

                foreach (var child in currentNode.Children)
                {
                    q.Enqueue(child);
                }

                if (currentNode.Equals(htmlElement))
                {
                    return currentNode;
                }
            }

            return null;
        }


        public override string ToString()
        {

            StringBuilder sb = new StringBuilder();

            this.AppendingSb(sb);

            return sb.ToString().TrimEnd();
        }

        private void AppendingSb(StringBuilder sb)
        {

            int indent = 0;

            this.ReturnsString(this.Root, sb, indent);
        }

        private void ReturnsString(IHtmlElement root, StringBuilder sb, int indent)
        {
            sb.AppendLine(new string(' ', indent) + root.Type);

            foreach (var child in root.Children)
            {
                this.ReturnsString(child, sb, indent + 2);
            }
        }
    }
}
