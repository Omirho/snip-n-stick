using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace snip_n_stick.Models
{
    public class Snip
    {
        [ScaffoldColumn(false)]
        public string SnipID { get; set; }

        [Required, StringLength(100), Display(Name = "Title")]
        public string SnipTitle { get; set; }

        [Required, StringLength(100), Display(Name = "Language"), DefaultValue("None")]
        public string SnipLanguage { get; set; }

        [Required, Display(Name = "CreatedTime"), DataType(DataType.DateTime)]
        public DateTime SnipCreatedTime { get; set; }

        [Required, Display(Name = "ExpirationTime"), DataType(DataType.DateTime)]
        public DateTime SnipExpirationTime { get; set; }

        [Required, StringLength(100), Display(Name = "CreatedBy"), DataType(DataType.EmailAddress), DefaultValue("default@default.com")]
        public string SnipCreatedBy { get; set; }

        [Required, Display(Name = "AccessType"), DefaultValue(0)]
        public int SnipAccessType { get; set; }

        [StringLength(100), Display(Name = "AccessPass"), DataType(DataType.Password)]
        public string SnipAccessPass { get; set; }

        [Required, StringLength(10000), Display(Name = "Content"), DataType(DataType.MultilineText)]
        public string SnipContent { get; set; }
    }
}