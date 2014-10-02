using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Collections;

namespace DSDDemo.Permits
{
    public class BuildingPermit : BasePermit
    {
        public BuildingPermit()
        {
            permitCount = 10; // get real count from data store
            prefix = "BP";
            displayLabel = "Building (BP)";
            DBLists lists = new DBLists();
            Field field;
            
            field = new Field("Project Type");
            field.Default = true;
            field.Shown = true;
            field.ValidationRule = ValidationRules.NotNull;
            field.FieldType = FieldTypes.Lookup;
            field.LookupTable = "zz01"; // PTWin crap
            field.GroupOrder = 1;
            field.GroupName = "Description";    
            //field.SortOrder = 1;
            field.Required = true;
            field.OriginalValue = "Addition";
            field.FieldType = FieldTypes.Lookup;
            field.LookupValues = lists.GetList(field.LookupTable, false);
            AddField(field);

            field = new Field("Type of Construction");
            field.Default = true;
            field.Shown = true;
            field.ValidationRule = ValidationRules.None;
            field.FieldType = FieldTypes.Lookup;
            field.LookupTable = "cstr";
            field.LookupValues = lists.GetList(field.LookupTable, false);
            field.GroupOrder = 1;
            //field.SortOrder = 2;
            field.Shown = false;

            AddField(field);

            field = new Field("Occupancy Types");
            field.Default = true;
            field.Shown = true;
            field.ValidationRule = ValidationRules.None;
            field.FieldType = FieldTypes.Lookup;
            //field.FieldType = FieldTypes.Many;
            field.LookupTable = "zz30";
            field.LookupValues = lists.GetList(field.LookupTable, true);
            field.GroupOrder = 1;
            //field.SortOrder = 3;
            field.Shown = false;
            AddField(field);

            field = new Field("Occupancy Group", true, true, ValidationRules.None,
                FieldTypes.String);
            field.LookupTable = "use";
            field.GroupOrder = 1;
            //field.SortOrder = 4;
            field.Default = true;
            AddField(field);

            // just to pad things
            field = new Field("Item Number");
            //field.GroupOrder = 1;
            field.Shown = false;
            AddField(field);
            
            field = new Field("Occupancy Load");
            //field.GroupOrder = 1;
            field.Shown = false;
            AddField(field);
            
            field = new Field("Main Inspector");
            //field.GroupOrder = 1;
            field.Shown = false;
            AddField(field);
            
            field = new Field("Temp Cert Occ Exp");
            //field.GroupOrder = 1;
            field.Shown = false;
            AddField(field);
            
            field = new Field("Auto Sprinkler");
            //field.GroupOrder = 1;
            field.Shown = false;
            AddField(field);

            field = new Field("Zone"); 
            //field.GroupOrder = 1;
            field.Shown = false;
            AddField(field);
            
            field = new Field("Code Edition");
            field.GroupOrder = 1;
            field.Shown = false;
            AddField(field);
            
            field = new Field("Project Notes");
            //field.GroupOrder = 1;
            field.Shown = false;
            AddField(field);
            
            field = new Field("Received Plans");
            //field.GroupOrder = 1;
            field.Shown = false;
            AddField(field);
            
            field = new Field("Construction Value");
            //field.GroupOrder = 1;
            field.Required = true;
            field.Shown = false;
            AddField(field);

            field = new Field("Plans Approved");
            AddField(field);

            field = new Field("Additional Const Value");
            AddField(field);

            field = new Field("First Floor");
            field.GroupOrder = 2;
            field.GroupName = "Floor Areas";
            AddField(field);
            field = new Field("Other");
            AddField(field);
            field = new Field("Second Floor");
            AddField(field);
            field = new Field("Porches");
            AddField(field);
            field = new Field("Bonus Room");
            AddField(field);
            field = new Field("Decks");
            AddField(field);
            field = new Field("Basement");
            AddField(field);
            field = new Field("Patios");
            AddField(field);
            field = new Field("Garage");
            AddField(field);
            field = new Field("Site Area");
            AddField(field);
            field = new Field("Structure Area");
            AddField(field);
            field = new Field("Percentage of Site");
            AddField(field);


            field = new Field("House");
            field.GroupOrder = 3;
            field.GroupName = "Impervious Surface";
            AddField(field);
            field = new Field("Garage (Again?)");
            AddField(field);
            field = new Field("Driveways");
            AddField(field);
            field = new Field("Porch-Walk");
            AddField(field);
            field = new Field("Other (Again?)");
            AddField(field);
            field = new Field("Desc");
            AddField(field);
            field = new Field("Tot. Impervious Surface");
            AddField(field);


            field = new Field("Application Type");
            field.GroupOrder = 4;
            field.GroupName = "Zoning Information"; 
            AddField(field);
            field = new Field("Parcel Acerage");
            AddField(field);
            field = new Field("Sq Ft");
            AddField(field);
            field = new Field("Land Use Case #");
            AddField(field);
            field = new Field("Original Parcel");
            AddField(field);
            field = new Field("Flood Hazard Zone/Use");
            AddField(field);
            field = new Field("County Set Backs");
            AddField(field);
            field = new Field("Sec Line");
            AddField(field);
            field = new Field("1/4 Sec Line");
            AddField(field);
            field = new Field("CoFront");
            AddField(field);
            field = new Field("CoSide");
            AddField(field);
            field = new Field("CoRear");
            AddField(field);
            field = new Field("Corner Lot F/S");
            AddField(field);
            field = new Field("City Set Backs");
            AddField(field);
            field = new Field("CiFront");
            AddField(field);
            field = new Field("CiSide");
            AddField(field);
            field = new Field("CiRear");
            AddField(field);
            field = new Field("Corner Lot F/S");
            AddField(field);
            field = new Field("City Address");
            AddField(field);
            field = new Field("# of Perm Residence");
            AddField(field);
            field = new Field("# of Temp Residence");
            AddField(field);
            field = new Field("C");
            AddField(field);
            field = new Field("Special Conditions");
            AddField(field);


            field = new Field("Approved by 911");
            field.GroupOrder = 5;
            field.GroupName = "Private Road Information";
            AddField(field);
            field = new Field("Easement Recordation #");
            AddField(field);
            field = new Field("# of Res Serviced");
            AddField(field);
            field = new Field("Range of Addresses");
            AddField(field);
            field = new Field("Length of Existing Road");
            AddField(field);
            field = new Field("Length to be Certified");
            AddField(field);
            field = new Field("Certified By");
            AddField(field);
            field = new Field("Date of Certification");
            AddField(field);
            field = new Field("Additional Information");
            AddField(field);
            
            field = new Field("Notification Type");
            field.GroupOrder = 6;
            field.GroupName = "Notification";
            field.LookupTable = "zz40";
            field.FieldType = FieldTypes.Many;
            field.LookupValues = lists.GetList(field.LookupTable, false);
            //field.OriginalValue = "Fax,Email";
            //field.OriginalValue = "Text";
            field.OriginalValue = "";
            //field.GroupOrder = 2;
            field.Default = true;
            AddField(field);
            

        }

    }
}
