using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Reflection;
using DSDDemo.Permits;

namespace DSDDemo
{
    // Just gets Classes based on the generic<T> type
    class AssemblyFilter<T>
    {
        ListControl list;
        Dictionary<string, T> dic;

        private void GetDictionary()
        {
            //Assembly assembly = Assembly.GetExecutingAssembly();
            Assembly assembly = Assembly.GetAssembly(typeof(T));
            Type[] types = assembly.GetTypes();

            dic = new Dictionary<string, T>();

            foreach (Type type in types)
            {
                if (type.BaseType == typeof(T))
                {
                    //Type t = assembly.GetType(tp.FullName);
                    object obj = (T)Activator.CreateInstance(type);
                    dic.Add(obj.ToString(), (T)obj);
                }
            }
        }

        public AssemblyFilter(ListControl lb)
        {
            // Moved to Bind - IndexChanged event was firing before constructor finished
            //Dictionary<string, T> dic = GetDictionary();
            //lb.DataSource = new BindingSource(dic, null);
            //lb.DisplayMember = "Key";
            list = lb;
            GetDictionary();
        }

        public void Bind()
        {
            list.DataSource = new BindingSource(dic, null);
            list.DisplayMember = "Key";
        }

        public T GetItem(object obj)
        {
            KeyValuePair<string, T> Item = (KeyValuePair<string, T>)obj;
            return Item.Value;
        }

        public string GetString(object obj)
        {
            KeyValuePair<string, T> Item = (KeyValuePair<string, T>)obj;
            return Item.Key;
        }

    }
}
