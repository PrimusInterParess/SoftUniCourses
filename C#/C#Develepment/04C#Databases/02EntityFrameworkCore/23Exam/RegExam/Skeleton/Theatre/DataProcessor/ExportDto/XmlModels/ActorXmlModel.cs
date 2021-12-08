using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ExportDto.XmlModels
{
    [XmlType("Actor")]
  public  class ActorXmlModel
    {
        [XmlAttribute("FullName")]
        public string FullName { get; set; }

        [XmlAttribute("MainCharacter")]
        public string MainCharacter { get; set; }

        //<Actor FullName="Sylvia Felipe" MainCharacter="Plays main character in 'A Raisin in the Sun'." />
    }
}
