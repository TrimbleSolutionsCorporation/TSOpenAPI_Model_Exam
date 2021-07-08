using System;
using System.Windows.Forms;
using Tekla.Structures.Geometry3d;
using Tekla.Structures.Model;

namespace Example_Test_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            try
            {
                ModelInfo mi = new Model().GetInfo();

                if (!mi.ModelName.Contains("API_Developer_Exam"))
                {
                    CloseTestAppNotConnected();
                    return;
                }

                var moe = new Model().GetModelObjectSelector().GetAllObjectsWithType(ModelObject.ModelObjectEnum.BEAM);

                if (!(moe.GetSize() == 4237))
                {
                    CloseTestAppNotConnected();
                    return;
                }

                Beam newBeam = new Beam(new Point(0, 0, 0), new Point(100, 0, 0));
                newBeam.Profile.ProfileString = "HEA100";
                bool resultInsert = newBeam.Insert();
                bool resultDelete = newBeam.Delete();

                if (!(resultInsert && resultDelete))
                {
                    CloseTestAppNotConnected();
                    return;
                }

                label1.Text = "Project is connected with Exam model.";
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
            }
            catch
            {
                CloseTestAppNotConnected();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Model myModel = new Model();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Model myModel = new Model();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Model myModel = new Model();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Model myModel = new Model();
        }

        void CloseTestAppNotConnected()
        {
            string errorMessage = "Project cannot connect with exam model.";
            label1.Text = errorMessage;

            buttonTest.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;

            return;
        }
    }
}
