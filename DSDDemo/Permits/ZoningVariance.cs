using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSDDemo.Permits
{
    class ZoningVariance : BasePermit
    {
        public ZoningVariance()
        {
            permitCount = 16;
            prefix = "ZV";
            displayLabel = "Zoning Variance (ZV)";
            int group = 1;
            Field field;

            field = new Field("Location");
            field.GroupOrder = group++;
            field.GroupName = "Additional Info";
            AddField(field);
            field = new Field("Use");
            AddField(field);
            field = new Field("Short Description");
            AddField(field);
            field = new Field("Existing Floor Space");
            AddField(field);
            field = new Field("Lot Dimensions");
            AddField(field);
            field = new Field("Proposed Floor Space");
            AddField(field);
            field = new Field("Parking");
            AddField(field);
            field = new Field("Total Floor Space");
            AddField(field);
            field = new Field("Zoning Section");
            AddField(field);
            field = new Field("Documentation");
            AddField(field);


        }
    }
}
