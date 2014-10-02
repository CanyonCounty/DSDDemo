using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSDDemo
{
    interface Permit
    {
        string DisplayLabel();
        string NextPermitNumber();
    }

    abstract class BasePermit : Permit
    {
        protected string prefix = "";
        protected int permitCount = 0;

        public List<Field> FieldList = new List<Field>();

        public string NextPermitNumber()
        {
            permitCount++;
            return prefix + DateTime.Now.ToString("yyyy") + "-" + permitCount.ToString();
        }

        public abstract string DisplayLabel();
    }

    enum ValidationRules
    {
        None,
        NotNull,
        ValidDate
    }

    enum FieldTypes
    {
        String,
        Date,
        Number,
        Float,
        Memo,
        Lookup
    }

    class Field
    {
        public string FieldName { get; set; }
        public string DisplayLabel { get; set; }
        public ValidationRules ValidationRule { get; set; }
        public FieldTypes FieldType { get; set; }
        public string LookupTable { get; set; }
        public bool Default { get; set; }
        public bool Shown { get; set; }

        public Field()
        {
            // don't need to do anything
        }

        public Field(string DisplayLabel, bool Default, bool Shown,
            ValidationRules rule, FieldTypes type, string LookupTable)
        {
            this.FieldName = DisplayLabel.Replace(" ", "");
            this.DisplayLabel = DisplayLabel;
            this.Default = Default;
            this.Shown = Shown;
            this.ValidationRule = rule;
            this.FieldType = type;
            this.LookupTable = LookupTable;
        }
    }

    class BuildingPermit : BasePermit
    {
        public BuildingPermit()
        {
            permitCount = 10; // get real count from data store
            prefix = "BP";

            //List<Field> FieldList = new List<Field>();

            ProjectType = new Field();
            ProjectType.Default = true;
            ProjectType.DisplayLabel = "Project Type";
            ProjectType.FieldName = "ProjectType";
            ProjectType.Shown = true;
            ProjectType.ValidationRule = ValidationRules.NotNull;
            ProjectType.FieldType = FieldTypes.Lookup;
            ProjectType.LookupTable = "zz01"; // PTWin crap
            
            FieldList.Add(ProjectType);

            TypeOfConstriction = new Field();
            TypeOfConstriction.Default = true;
            TypeOfConstriction.DisplayLabel = "Type of Construction";
            TypeOfConstriction.Shown = true;
            TypeOfConstriction.FieldName = "TypeOfConstruction";
            TypeOfConstriction.ValidationRule = ValidationRules.None;
            TypeOfConstriction.FieldType = FieldTypes.Lookup;
            TypeOfConstriction.LookupTable = "cstr";

            FieldList.Add(TypeOfConstriction);

            Field field = new Field();
            field.Default = true;
            field.DisplayLabel = "Occupancy Types";
            field.Shown = true;
            field.FieldName = "OccupancyTypes";
            field.ValidationRule = ValidationRules.None;
            field.FieldType = FieldTypes.Lookup;
            field.LookupTable = "zz30";
            OccupancyTypes = field;

            FieldList.Add(field);

            OccupancyGroup = new Field("Occupancy Group", true, true, ValidationRules.None,
                FieldTypes.String, "use");

            FieldList.Add(OccupancyGroup);

        }
        
        public override string DisplayLabel()
        {
            return "Building (BP)";
        }

        public Field ProjectType { get; set; }
        public Field TypeOfConstriction { get; set; }
        public Field OccupancyTypes { get; set; }
        public Field OccupancyGroup { get; set; }
    }
/*
    class ConditionalUse : BasePermit
    {
        public ConditionalUse()
        {
            permitCount = 956;
            prefix = "CU";
        }

        public override string DisplayLabel()
        {
            return "Conditional Use (CU)";
        }

        public string Conditional_Use { get; set; }
        public string Number_of_Parcels { get; set; }
        public string Fire_District { get; set; }
        public string State_Federal_1 { get; set; }
        public string State_Federal_2 { get; set; }
    }
 */
}
