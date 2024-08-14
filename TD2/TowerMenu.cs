using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TD2.Utilities;



namespace TD2
{
    public partial class TowerMenu : Form
    {



        public TowerMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Globals.money >= Globals.blackcatPrice)
            {
                Globals.spawnTower = true;
                Globals.currentType = Globals.TowerType.mage;
                Globals.canMove = true;
            }

            // add type of tower

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Globals.money >= Globals.orangecatPrice)
            {
                Globals.spawnTower = true;
                Globals.currentType = Globals.TowerType.other;
                Globals.canMove = true;
            }

            // ass type of tower
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // upgrade black cat
            Globals.upgradeBlackCat = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // upgrade orange cat
            Globals.upgradeOrangeCat = true;
        }
    }
}

