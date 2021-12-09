using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PANKBANK.Models
{
    public class GetAppli
    {
        public int Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public int Total { get; set; }
        public string CredOrDep { get; set; }

    }
}
