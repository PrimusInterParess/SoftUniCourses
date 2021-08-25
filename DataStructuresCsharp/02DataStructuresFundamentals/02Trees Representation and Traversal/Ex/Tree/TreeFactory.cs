﻿using System.Linq;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class TreeFactory
    {
        private Dictionary<int, Tree<int>> nodesBykeys;

        public TreeFactory()
        {
            this.nodesBykeys = new Dictionary<int, Tree<int>>();
        }

        public Tree<int> CreateTreeFromStrings(string[] input)
        {
            foreach (var data in input)
            {
                int[] values = data.Split(' ').Select(int.Parse).ToArray();

                int parentKey = values[0];
                int childKey = values[1];

                this.AddEdge(parentKey,childKey);
            }

           return this.GetRoot();
        }

        public Tree<int> CreateNodeByKey(int key)
        {
            if (!this.nodesBykeys.ContainsKey(key))
            {
                this.nodesBykeys.Add(key, new Tree<int>(key));
            }

            return this.nodesBykeys[key];
        }

        public void AddEdge(int parent, int child)
        {
            Tree<int> parentNode = this.CreateNodeByKey(parent);
            Tree<int> childNode = this.CreateNodeByKey(child);

            parentNode.AddChild(childNode);
            childNode.AddParent(parentNode);
        }

        private Tree<int> GetRoot()
        {
            //Tree<int> root = null;

            //foreach (var tree in nodesBykeys.Values)
            //{
            //    if (tree.Parent==null)
            //    {

            //        root = tree;
            //    }
            //}

            var toReturn = (Tree<int>)this.nodesBykeys.Values.FirstOrDefault(t => t.Parent == null);

            return toReturn;

           // return root;
        }
    }
}
