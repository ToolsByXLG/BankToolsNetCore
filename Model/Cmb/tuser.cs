using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model.Cmb
{
    [Table("tuser")]
    public class tuser
    {
        public int id { get; set; }
        public string username { get; set; }
        public string pwd { get; set; }
        public string phone { get; set; }

    }
}
