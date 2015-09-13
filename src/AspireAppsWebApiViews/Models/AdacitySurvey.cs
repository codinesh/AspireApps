using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AspireAppsWebApiViews.Models
{
    public class AdacitySurvey
    {
        public int ID { get; set; }
        [DisplayName("Age Group")]
        public string AgeGroup { get; set; }
        public string Employment { get; set; }
        public string Option { get; set; }
        [DisplayName("Entertainment Category")]
        public string EntertainmentCategory { get; set; }
    }
}
