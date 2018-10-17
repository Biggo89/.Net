using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GuestResponse.Models
{
    [MetadataType(typeof(BaseMetadata))]
    public class BaseViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class BaseMetadata
    {
        [Custom(ColumnName = "Il mio Nome")]
        public string Name { get; set; }
        [Custom(ColumnName = "Il mio cognome")]
        public string Surname { get; set; }
    }
    public class CustomAttribute : Attribute
    {
        public string ColumnName { get; set; }
    }
}