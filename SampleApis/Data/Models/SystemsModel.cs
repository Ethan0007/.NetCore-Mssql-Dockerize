using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApis.Data.Models
{
    public class SystemsModel
    {
        public string Id { set; get; }
        [StringLength(45)]
        public string Key { set; get; }
        [StringLength(75)]
        public string Expiration { set; get; }
        [StringLength(50)]
        public string  Version { set; get; }
    }
}
