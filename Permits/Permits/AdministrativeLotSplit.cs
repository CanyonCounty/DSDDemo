using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DSDDemo.Permits
{
    public class AdministrativeLotSplit : BasePermit
    {
        public AdministrativeLotSplit()
        {
            permitCount = 56;
            prefix = "LS";
            displayLabel = "Administrative Lot Split (LS)";
            int group = 1;
            Field field;

            field = new Field("Blank Field");
            field.GroupOrder = group++;
            field.GroupName = "Application";
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
            field = new Field("Memo Field");
            field.FieldType = FieldTypes.Memo;
            //field.OriginalValue = "This is a test, this is only a test.";
            AddField(field);

        }
    }
}
