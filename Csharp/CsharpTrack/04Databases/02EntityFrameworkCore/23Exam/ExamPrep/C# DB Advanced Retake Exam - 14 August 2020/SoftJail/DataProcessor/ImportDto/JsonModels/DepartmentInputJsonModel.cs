using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto.JsonModels
{
    public class DepartmentInputJsonModel
    {
        public DepartmentInputJsonModel()
        {
            this.Cells = new HashSet<CellInputJsonModel>();
        }

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MinLength(4)]
        [MaxLength(25)]
        public string Name { get; set; }


        public ICollection<CellInputJsonModel> Cells { get; set; }
    }
}
