using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Collections;
using System.Windows.Forms;

namespace DSDDemo
{
    public enum ValidationRules
    {
        None,       // No checking
        NotNull,    // Required
        ValidDate,  // Date has to be set
        DateBefore, // Date has to be before another field
        DateAfter   // Date has to be after another field
    }

    public enum FieldTypes
    {
        String,     // varchar values
        Date,       // datetime values
        Number,     // int values
        Float,      // float values
        Currency,   // dollar values
        Memo,       // text values
        Lookup,     // foriegn key values
        Search,     // foreign keys for crapload of values
        Many        // Allows the user to select many values
    }

    public class Field
    {
        private string displayLabel;
        private string fieldName;
        private bool def;
        private bool req;
        private bool shown;
        public string OriginalValue { get; set; }
        public string CurrentValue { get; set; }
        public Field ValidationField { get; set; }

        public string FieldName { get { return fieldName; } }
        public string DisplayLabel
        {
            get { return displayLabel; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    displayLabel = value;
                    fieldName = displayLabel.Replace(" ", "");
                }
            }
        }
        public ValidationRules ValidationRule { get; set; }
        public FieldTypes FieldType { get; set; }
        public string LookupTable { get; set; }
        public ArrayList LookupValues { get; set; }

        public bool Default {               // What Dan will set up
            get { return def; } 
            set 
            { 
                def = value;
                shown = def;
            } 
        }   
        public bool Required {              // Required for data entry
            get { return req; }
            set
            {
                req = value;
                shown = req;
            }
        }  
        public bool Shown {                 // User overridable
            get { return shown; }
            set
            {
                if (!req | !def)
                    shown = value;
                //else
                //{
                //    MessageBox.Show("Can't do this");
                //}
            }
        }     
        public int GroupOrder { get; set; }   // Which group this field is a part of
        public string GroupName { get; set; } // The name of the group (label)
        public int SortOrder { get; set; }    // Which sort order in the group 

        // Require at least DisplayLabel
        //public Field()
        //{
        //}
        
        public Field(string DisplayLabel) :
            this(DisplayLabel, false, false, ValidationRules.None, FieldTypes.String)
        {
            // Nothing special here
        }

        public Field(string DisplayLabel, bool Default, bool Shown,
            ValidationRules rule, FieldTypes type)
        {
            this.DisplayLabel = DisplayLabel;
            this.Default = Default;
            this.Shown = Shown;
            this.ValidationRule = rule;
            this.FieldType = type;

            this.ValidationField = null;
            
            this.GroupOrder = 0;
            this.SortOrder = 0;
        }

    }
}
