using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace DataTrackOptions
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        List<GridProperty> gridList;
        BasicPropertyBag bag;
        bool expanded;
        int skipped;

        public Form1()
        {
            InitializeComponent();
            ReadPropertyFile();
            LoadPropertyGrid();
        }

        private void ReadPropertyFile()
        {
            skipped = 0;
            gridList = new List<GridProperty>();
            string[] contents;
            using (var sr = new StreamReader("file.txt"))
            {
                contents = sr.ReadToEnd().Split('\n');
            }
            
            for (int i = 0; i < contents.Length; i++)
            {
                string[] properties = contents[i].Trim().Split(';');

                if (properties.Length < 7)
                {
                    skipped++;

                    continue;
                }

                gridList.Add(new GridProperty
                {
                    CodeName = properties[0],
                    Category = properties[1],
                    Name = properties[2],
                    Value = properties[3],
                    Desc = properties[4],
                    Default = properties[5],
                    DataType = properties[6]
                });

            }
        }

        private void LoadPropertyGrid()
        {
            bag = new BasicPropertyBag();
            for (int i = 0; i < gridList.Count; i++)
            {
                string type = gridList[i].DataType.Trim().ToLower();

                bag.Properties.Add(new MetaProp(gridList[i].CodeName.ToString(), typeof(string),
                new DefaultValueAttribute(gridList[i].CodeName.ToString()),
                new TypeConverterAttribute(Enums.GetType(type)),
                new CategoryAttribute(gridList[i].Category.ToString()),
                new DisplayNameAttribute(gridList[i].Name.ToString()),
                new DescriptionAttribute(gridList[i].Desc.ToString()))
                

                );
                bag[gridList[i].Default] = "Distribute"; 
                bag[gridList[i].CodeName] = gridList[i].Value;
            }

            propertyGridMain.SelectedObject = bag;
            propertyGridMain.CollapseAllGridItems();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var sw = new StreamWriter("newoptions.txt"))
            {
                foreach (var prop in bag.Properties)
                {
                    string name = prop.Name;
                    string value = bag[prop.Name].ToString();

                    sw.WriteLine(string.Join(";", name, value));
                }
            }
        }

        private void btnExpandCollapse_Click(object sender, EventArgs e)
        {
            if (!expanded)
            {
                propertyGridMain.ExpandAllGridItems();
                btnExpandCollapse.Text = "Collapse All";
                expanded = true;
            }
            else
            {
                propertyGridMain.CollapseAllGridItems();
                btnExpandCollapse.Text = "Expand All";
                expanded = false;
            }

        }

        private void btnViewTable_Click(object sender, EventArgs e)
        {
            Forms.Tables tables = new Forms.Tables(gridList);
            tables.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }



}
