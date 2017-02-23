using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Exam
{
    public partial class Form1 : Form
    {
        readonly BindingSource data = new BindingSource();
        readonly List<Student> list = new List<Student>();

        public Form1()
        {
            InitializeComponent();
            data.DataSource = list;
            dataGridView1.DataSource = data;
            dataGridView1.Columns[0].HeaderText = "Фамилия";
            dataGridView1.Columns[1].HeaderText = "Группа";
            dataGridView1.Columns[2].HeaderText = "Оценка";
            treeView1.Nodes.Add(Application.StartupPath);
            BuildTree(Application.StartupPath, treeView1.Nodes[0]);
            treeView1.SelectedNode = treeView1.Nodes[0];
            comboBox1.SelectedIndex = 0;
            timer1.Start();
        }

        void ReadStudents(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(';');
                    data.Add(new Student
                    {
                        Name = parts[0],
                        Group = parts[1],
                        Mark = int.Parse(parts[2])
                    });
                }
            }
        }

        void SaveStudents(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (Student student in list)
                {
                    writer.WriteLine($"{student.Name};{student.Group};{student.Mark}");
                }
            }
        }

        void button1_Click(object sender, EventArgs e)
        {
            data.Clear();
            try
            {
                ReadStudents(treeView1.SelectedNode.FullPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            UpdateChart();
        }


        void BuildTree(string directoryName, TreeNode parent)
        {
            DirectoryInfo dir = new DirectoryInfo(directoryName);
            try
            {
                DirectoryInfo[] directories = dir.GetDirectories();

                foreach (DirectoryInfo d in directories)
                {
                    TreeNode node = new TreeNode(d.Name);
                    parent.Nodes.Add(node);
                    BuildTree(d.FullName, node);
                }
                FileInfo[] files = dir.GetFiles();
                foreach (FileInfo item in files)
                {
                    TreeNode node = new TreeNode(item.Name)
                    {
                        ImageIndex = 2
                    };

                    parent.Nodes.Add(node);
                }
            }
            catch
            {
                // ignored
            }
        }

        void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog
            {
                InitialDirectory = treeView1.SelectedNode.Parent?.FullPath ?? @"D:",
                RestoreDirectory = true,
                Filter = @"CSV files (*.csv)|*.csv|All files (*.*)|*.*"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                SaveStudents(dlg.FileName);
            }
        }

        void UpdateChart()
        {
            var dic = list
                .GroupBy(l => l.Mark)
                .Select(g => new
                {
                    Mark = g.Key,
                    Count = g.Select(l => l).Count()
                });

            foreach (var item in dic)
            {
                chart1.Series[0].Points.Add(item.Count);
                chart1.Series[0].Points[chart1.Series[0].Points.Count - 1].Label = item.Mark.ToString();
            }
        }

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                int max = 0;
                if (list.Count > 0)
                {
                    max = list.Max(x => x.Mark);
                }
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if ((int) row.Cells[2].Value == max)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Green;
                    }
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                int min = 0;
                if (list.Count > 0)
                {
                    min = list.Min(x => x.Mark);
                }
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if ((int) row.Cells[2].Value == min)
                    {
                        row.DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            data.AddNew();
        }

        private void update_Click(object sender, EventArgs e)
        {
            UpdateChart();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = $"Alexander Matuzov {DateTime.Now:G}";
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = fontDialog1.ShowDialog();
            // See if OK was pressed.
            if (result == DialogResult.OK)
            {
                // Get Font.
                Font = fontDialog1.Font;

            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void changeFontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DialogResult result = fontDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                Font = fontDialog1.Font;
            }
        }

        private void readToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                InitialDirectory = treeView1.SelectedNode.Parent?.FullPath ?? @"D:",
                RestoreDirectory = true,
                Filter = @"CSV files (*.csv)|*.csv|All files (*.*)|*.*"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ReadStudents(dlg.FileName);
            }
           
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            new AboutBox1().Show();
        }
    }
}