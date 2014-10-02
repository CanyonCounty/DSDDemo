using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSDDemo.Permits
{
    interface Permit
    {
        string ToString();
        string NextPermitNumber();
    }

    abstract class BasePermit : Permit
    {
        protected string prefix = "";
        protected int permitCount = 0;
        protected Field first = null;
        protected int maxGroup = 0;
        protected string displayLabel;

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
            FieldList.Add(field);
            if (field.GroupOrder > maxGroup) maxGroup = field.GroupOrder;

            if (first == null) first = field;
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
    }
}
