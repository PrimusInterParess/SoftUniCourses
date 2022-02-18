using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Models.ErrorViewModels
{
    public class ErrorViewModel
    {
        public ErrorViewModel(string error)
        {
            this.Error = error;
        }
        public string Error { get; init; }
    }
}
