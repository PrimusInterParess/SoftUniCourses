using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
  public  class ProjectXMLExportModel
    {
        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }

        [XmlElement("ProjectName")]
        public string Name { get; set; }

        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlArray("Tasks")] 
        public TaskXMLExportModel[] TaskXmlExportModel { get; set; }

        /*
         * <Project TasksCount="10">
                <ProjectName>Hyster-Yale</ProjectName>
                 <HasEndDate>No</HasEndDate>

         */
    }
}
