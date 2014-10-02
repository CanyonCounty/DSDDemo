using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSDDemo.Permits
{
    class BuildingPermit : BasePermit
    {
        public BuildingPermit()
        {
            permitCount = 10; // get real count from data store
            prefix = "BP";
            displayLabel = "Building (BP)";

            Field field;
            
            field = new Field();
            field.Default = true;
            field.DisplayLabel = "1.1 Project Type";
            field.Shown = true;
            field.ValidationRule = ValidationRules.NotNull;
            field.FieldType = FieldTypes.Lookup;
            field.LookupTable = "zz01"; // PTWin crap
            field.GroupOrder = 1;
            field.SortOrder = 1;
            field.Required = true;
            AddField(field);

            field = new Field();
            field.Default = true;
            field.DisplayLabel = "1.2 Type of Construction";
            field.Shown = true;
            field.ValidationRule = ValidationRules.None;
            field.FieldType = FieldTypes.Lookup;
            field.LookupTable = "cstr";
            field.GroupOrder = 1;
            field.SortOrder = 2;
            field.Shown = false;

            AddField(field);

            field = new Field();
            field.Default = true;
            field.DisplayLabel = "2.2 Occupancy Types";
            field.Shown = true;
            field.ValidationRule = ValidationRules.None;
            field.FieldType = FieldTypes.Lookup;
            field.LookupTable = "zz30";
            field.GroupOrder = 2;
            field.SortOrder = 2;
            field.Shown = false;
            AddField(field);

            field = new Field("2.1 Occupancy Group", true, true, ValidationRules.None,
                FieldTypes.String, "use");
            field.GroupOrder = 2;
            field.SortOrder = 1;
            field.Default = true;
            AddField(field);

            // just to pad things
            field = new Field("Item Number");
            field.Shown = false;
            AddField(field);
            
            field = new Field("Occupancy Load");
            field.Shown = false;
            AddField(field);
            
            field = new Field("Main Inspector");
            field.Shown = false;
            AddField(field);
            
            field = new Field("Temp Cert Occ Exp");
            field.Shown = false;
            AddField(field);
            
            field = new Field("Auto Sprinkler");
            field.Shown = false;
            AddField(field);
            
            field = new Field("Zone");
            field.Shown = false;
            AddField(field);
            
            field = new Field("Code Edition");
            field.Shown = false;
            AddField(field);
            
            field = new Field("Project Notes");
            field.Shown = false;
            AddField(field);
            
            field = new Field("Received Plans");
            field.Shown = false;
            AddField(field);
            
            field = new Field("Construction Value");
            field.Required = true;
            field.Shown = false;
            AddField(field);
        }

    }
}
