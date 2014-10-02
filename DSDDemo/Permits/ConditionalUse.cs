using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSDDemo.Permits
{
    class ConditionalUse : BasePermit
    {
        public ConditionalUse()
        {
            permitCount = 956;
            prefix = "CU";
            displayLabel = "Conditional Use (CU)";
        }

        public string Conditional_Use { get; set; }
        public string Number_of_Parcels { get; set; }
        public string Fire_District { get; set; }
        public string State_Federal_1 { get; set; }
        public string State_Federal_2 { get; set; }
    }
}
