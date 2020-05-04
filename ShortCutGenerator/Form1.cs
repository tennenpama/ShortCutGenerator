using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortCutGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
#if DEBUG
            Test.TestCode();
#endif
            //ショートカットファイル君を作成する(´・ω・｀)
            ShortCutsGenerator generator = new ShortCutsGenerator();
            generator.GenerateWithCurrentDirFiles();

            MessageBox.Show("ショートカットが作成されました！！", "(´・ω・｀)");

            this.Close();
        }
    }
}
