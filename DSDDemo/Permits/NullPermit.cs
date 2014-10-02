using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSDDemo.Permits
{
    // At the moment it's only used for a blank item in the combo box
    // but I might want this for a compare or similar
    class NullPermit : BasePermit
    {
        public NullPermit()
        {
            permitCount = 0;
            prefix = "";
            displayLabel = "";
        }
    }
}
