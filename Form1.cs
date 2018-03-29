using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class btnWriteToFile : Form
    {
        Lab2.GameFactory gameFactory;

        public btnWriteToFile()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gameFactory = new Lab2.GameFactory();

            gameFactory.CreateGameList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gameFactory.FilePath = @"..\..\games.xml";
            gameFactory.SerializeGameList();

        }

        private void btnReadFromFile_Click(object sender, EventArgs e)
        {


            gameFactory.DeserializeGameList();
            
            foreach(Lab2.Game g in gameFactory.listOfGames)
            {
                listBox1.Items.Add(g.ToString());
            }
            
        }
    }
}
