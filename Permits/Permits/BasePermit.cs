using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * All permit types
--Administrative Lot Split (LS)
Appeal (AP)
--Building (BP)
Canyon County Ordinance (OR)
Comp Plan/Rezone (CPR)
Conditional Rezone (CR)
--Conditional Use (CU)
Conditional Use Revocation (CUR)
Conditional Use Vacation (CUV)
Demolition (DM)
Development Permit (DP)
Electrical (EL)
ESA (EP)
Excavating & Grading (EG)
Home Business (HB)
Home Occupation (HO)
House Moving (HM)
House Number (HN)
Impact Area Agreement (IA)
Mechanical (MC)
Mineral Extract Short Term (MST)
Parcel Inquiry (PI)
Planned Unit Development (PU)
Plat Vacation (PV)
Private Road Name Change (PRNC)
Property Line Adjustment (PLA)
Property Research (PR)
Public Road Name Change (RNC)
Request for Extension (RFE)
Rezone (RZ)
Road Name (Road)
Short Plat (SP)
Sign (SG)
Sign Variance (SV)
Street Vacation (VC)
Subdivision (SD)
Temporary Residence Permit (TP)
Waivers/Irrigation Plan (WI)
Zone Compliance (ZC)
--Zoning Variance (ZV)
*/
namespace DSDDemo.Permits
{
    // Custom Exceptions
    public class ValidationDateException : Exception
    {
        public ValidationDateException(string errorMessage) : base(errorMessage) { }
        public ValidationDateException(string errorMessage, Exception innerEx) : base(errorMessage, innerEx) { }
    }
    
    interface Permit
    {
        string ToString();
        string NextPermitNumber();
    }

    public abstract class BasePermit : Permit
    {
        protected string prefix = "";
        protected int permitCount = 0;
        protected Field first = null;
        protected int maxGroup = 0;
        protected string displayLabel;
        protected int curGroup = 1;
        protected int prevGroup = 0;
        protected int curSort = 1;
        public int MaxGroup { get { return maxGroup; } }
        private List<Field> FieldList = new List<Field>();

        public string NextPermitNumber()
        {
            permitCount++;
            return prefix + DateTime.Now.ToString("yyyy") + "-" + permitCount.ToString();
            // TODO: update field/database
        }

        public override string ToString()
        {
            return this.displayLabel;
        }

        public void AddField(Field field)
        {
            if (string.IsNullOrEmpty(field.OriginalValue)) field.OriginalValue = "";
            field.CurrentValue = field.OriginalValue; // The could not have changed it yet.
            if (field.GroupOrder > maxGroup) maxGroup = field.GroupOrder;
            //if (field.GroupOrder == 0) field.GroupOrder = maxGroup + 1;
            if (string.IsNullOrEmpty(field.GroupName)) field.GroupName = "Additional Information";
            if (field.GroupOrder == 0)
                field.GroupOrder = curGroup;
            else
                curGroup = field.GroupOrder;
            
            if (prevGroup != curGroup) 
                curSort = 0;

            if (field.SortOrder == 0)
                field.SortOrder = curSort++;

            if (first == null) first = field;
            
            
            // Do some field checking
            if (field.ValidationRule == ValidationRules.DateAfter)
            {
                if (field.ValidationField == null)
                    throw new ValidationDateException("Field Validation Rule is set to DateAfter, but no ValidationDate is set.");
            }
            if (field.ValidationRule == ValidationRules.DateBefore)
            {
                if (field.ValidationField == null)
                    throw new ValidationDateException("Field Validation Rule is set to DateBefore, but no ValidationDate is set.");
            }


            // If we make it this far we're good to go!
            FieldList.Add(field);
            prevGroup = curGroup;
        }

        public List<Field> GetFields()
        {
            //FieldList.Reverse(); // moved to DrawPermitPanel
            return FieldList;
        }

        public Field First()
        {
            return first;
        }

        public int FieldCount()
        {
            return FieldList.Count();
        }

        public Field FindField(string displayLabel)
        {
            Field ret = null;
            foreach (Field f in FieldList)
            {
                if (f.DisplayLabel == displayLabel)
                {
                    ret = f;
                    break;
                }
            }

            return ret;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            BasePermit p = obj as BasePermit;
            if ((Object)p == null)
            {
                return false;
            }

            return (prefix == p.prefix) && (displayLabel == p.displayLabel);
        }

        public bool Equals(BasePermit p)
        {
            if ((object)p == null)
            {
                return false;
            }

            return (prefix == p.prefix) && (displayLabel == p.displayLabel);
        }

        public override int GetHashCode()
        {
            return prefix.GetHashCode() ^ displayLabel.GetHashCode();
        }
    }
}
