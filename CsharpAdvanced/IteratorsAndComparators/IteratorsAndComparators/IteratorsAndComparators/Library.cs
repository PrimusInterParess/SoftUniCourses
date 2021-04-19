using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> Books;

        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
        }


        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> Books;

            private int Index;

            public LibraryIterator(IEnumerable<Book> books)
            {
                Reset();

                this.Books = new List<Book>(books);

                this.Books.Sort(new BookComparator());

            }

            public bool MoveNext()
            {
                return ++this.Index < this.Books.Count;
            }

            public void Reset()
            {
                this.Index = -1;
            }

            public Book Current => this.Books[this.Index];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                
            }
        }
    }
}
