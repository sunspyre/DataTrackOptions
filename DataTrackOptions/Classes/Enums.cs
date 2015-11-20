using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace DataTrackOptions
{
    public static class Enums
    {
        public static Type GetType(string type)
        {
            switch (type)
            {
                case "text":
                    return typeof(TextBox);
                case "bool":
                    return typeof(PropertyGridBool);
                case "list":
                    return typeof(PropertyGridCombo);
                default:
                    return typeof(TextBox);
            }
        }
    }

    //public class EnumList
    //{
    //    public string Yes { get; set; }
    //    public string No { get; set; }
    //}

    //public class YesNo : IItemsSource
    //{
    //    public ItemCollection GetValues()
    //    {
    //        ItemCollection value = new ItemCollection();
    //        value.Add(0, "No");
    //        value.Add(1, "Yes");
    //        return value;
    //    }

    //}

    //public class SpecialReports : IItemsSource
    //{
    //    public ItemCollection GetValues()
    //    {
    //        ItemCollection value = new ItemCollection();
    //        value.Add("avg pieces per hour", "Average Pieces per Hour");
    //        value.Add("cost hours only", "Cost (Hours only)");
    //        value.Add("cost pieces only", "Cost (Pieces only)");
    //        return value;
    //    }


    //}
}
