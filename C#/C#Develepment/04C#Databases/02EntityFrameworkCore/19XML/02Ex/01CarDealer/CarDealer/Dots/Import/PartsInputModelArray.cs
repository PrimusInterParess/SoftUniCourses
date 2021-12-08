using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dots.Import
{
    [XmlType("partId")]
    public class PartsInputModelArray
    {

        [XmlAttribute("id")]
        public int Id { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as PartsInputModelArray;

            return this.Id.Equals(other.Id);
        }



        public override int GetHashCode() => this.Id;

    }



}
