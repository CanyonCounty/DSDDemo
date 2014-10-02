using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSDDemo.Permits
{
    public class ConditionalUse : BasePermit
    {
        public ConditionalUse()
        {
            permitCount = 956;
            prefix = "CU";
            displayLabel = "Conditional Use (CU)";
            int group = 1;
            Field field;

            field = new Field("Conditional Use Desc");
            field.GroupOrder = group++;
            field.GroupName = "1";
            AddField(field);

            field = new Field("# of Parcels Approved");
            AddField(field);
            field = new Field("Ave Acreage per Parcel");
            AddField(field);
            field = new Field("City Impact/JEPA");
            AddField(field);
            field = new Field("Fire District");
            AddField(field);
            field = new Field("Irrigation District");
            AddField(field);
            field = new Field("Highway District");
            AddField(field);
            field = new Field("Flood District");
            AddField(field);
            field = new Field("School District");
            AddField(field);
            field = new Field("State/Federal #1");
            AddField(field);
            field = new Field("State/Federal #2");
            AddField(field);
            field = new Field("Notification Distance");
            AddField(field);

            
            field = new Field("Photo");
            field.GroupOrder = group++;
            field.GroupName = "Traffic";
            AddField(field);
            field = new Field("Existing Parking");
            AddField(field);
            field = new Field("Proposed Parking");
            AddField(field);
            field = new Field("Eliminated Parking");
            AddField(field);
            field = new Field("Other Parking Provision");
            AddField(field);
            field = new Field("Residents-Workers");
            AddField(field);
            field = new Field("Hours");
            AddField(field);
            field = new Field("Traffic");
            AddField(field);
            field = new Field("Shoreline");
            AddField(field);
            field = new Field("Designation");
            AddField(field);

            
            field = new Field("Blank Field");
            field.GroupOrder = group++;
            field.GroupName = "Request Schedule";
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);

            field = new Field("Blank Field");
            field.GroupOrder = group++;
            field.GroupName = "FCO's info";
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);


            field = new Field("Blank Field");
            field.GroupOrder = group++;
            field.GroupName = "General info";
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);


            field = new Field("Blank Field");
            field.GroupOrder = group++;
            field.GroupName = "Appeal Info";
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);
            field = new Field("Blank Field");
            AddField(field);

        }
    }
}
