using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataTrackOptions.Forms
{
    public partial class Tables : MetroFramework.Forms.MetroForm
    {
        public Tables()
        {
            InitializeComponent();
        }
        public Tables(List<GridProperty> gridList) : this()
        {
            tableGrid.ColumnCount = 7;
            tableGrid.Columns[0].Name = "DT Code";
            tableGrid.Columns[1].Name = "Category";
            tableGrid.Columns[2].Name = "Display Name";
            tableGrid.Columns[3].Name = "Value";
            tableGrid.Columns[4].Name = "Description";
            tableGrid.Columns[5].Name = "Default Value";
            tableGrid.Columns[6].Name = "Value type";

            foreach (var item in gridList)
            {
                tableGrid.Rows.Add(new string[]
                {
                    item.CodeName,
                    item.Category,
                    item.Name,
                    item.Value,
                    item.Desc,
                    item.Default,
                    item.DataType

                });
            }
        }
    }
}
