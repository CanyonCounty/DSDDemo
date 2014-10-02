using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace DSDDemo
{
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
        // I'm sorting based on this number - ones no one cares about will be this number
        // so they will appear at the end of the list
        private int max = 100;
        private string displayLabel;
        private string fieldName;
        private bool def;
        private bool req;
        private bool shown;

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
        public int GroupOrder { get; set; } // Which group this field is a part of
        public int SortOrder { get; set; }  // Which sort order in the group 

        public Field()
        {
            // don't need to do anything
            GroupOrder = max;
            SortOrder = max;
        }

        public Field(string DisplayLabel, bool Default, bool Shown,
            ValidationRules rule, FieldTypes type, string LookupTable)
        {
            //this.FieldName = DisplayLabel.Replace(" ", "");
            this.DisplayLabel = DisplayLabel;
            this.Default = Default;
            this.Shown = Shown;
            this.ValidationRule = rule;
            this.FieldType = type;
            this.LookupTable = LookupTable;
            GroupOrder = max;
            SortOrder = max;
        }

        public Field(string DisplayLabel)
        {
            this.DisplayLabel = DisplayLabel;
            this.Default = true;
            this.Shown = true;
            this.ValidationRule = ValidationRules.None;
            this.FieldType = FieldTypes.String;
            GroupOrder = max;
            SortOrder = max;
        }

    }
}
