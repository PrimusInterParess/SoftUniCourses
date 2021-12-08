namespace _02.DOM.Models
{
    using System;
    using System.Collections.Generic;
    using _02.DOM.Interfaces;

    public class HtmlElement : IHtmlElement
    {
        private List<IHtmlElement> children;
        private Dictionary<string, string> attributes;

        public HtmlElement(ElementType type, params IHtmlElement[] children)
        {
            this.Type = type;
            this.Parent = null;
            this.children = new List<IHtmlElement>();

            this.attributes = new Dictionary<string, string>();
            foreach (var child in children)
            {
                child.Parent = this;
                this.children.Add(child);
            }

        }

        public ElementType Type { get; set; }

        public IHtmlElement Parent { get; set; }


        public List<IHtmlElement> Children
        {
            get => this.children;
        }

        public Dictionary<string, string> Attributes { get => this.attributes; }
    }
}
