using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AF.DataValidation.Sample
{
    public class Result
    {
        public bool IsValid { get; set; }
        public IList<string> Message { get; set; }
    }
}