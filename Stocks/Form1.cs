using System;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Stocks
{
    public partial class Stocks : Form
    {
        string[] myArr;
        int count = 0;


        public Stocks()
        {
            InitializeComponent();
            label1.Hide();
            comboBox1.Items.Add("USD/CAD (USDCAD=X)");
            comboBox1.Items.Add("EUR/CAD (EURCAD=X)");
            comboBox1.Items.Add("Randgold Resources Limited (GOLD)");
            comboBox1.Items.Add("SPDR Gold Shares (GLD)");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clearBoxes();
            count++;

            if (comboBox1.Text.Equals("USD/CAD (USDCAD=X)"))
            {
                string path = @"C:\Downloads\usd_cad_rate.csv";
                string url = "http://download.finance.yahoo.com/d/quotes.csv?s=USDCAD=X&f=sl1d1t1c1ohgv&e=.csv";

                Downloadfile(path, url);

                FileStream fs = new FileStream(path, FileMode.Open);
                StreamReader sr = new StreamReader(fs);

                myArr = sr.ReadLine().Split(',');

                TextBoxes();

                fs.Close();
            }

            else if (comboBox1.Text.Equals("EUR/CAD (EURCAD=X)"))
            {
                string path = @"C:\Downloads\euro_cad_rate.csv";
                string url = "http://download.finance.yahoo.com/d/quotes.csv?s=EURCAD=X&f=sl1d1t1c1ohgv&e=.csv";

                Downloadfile(path, url);

                FileStream fs = new FileStream(path, FileMode.Open);
                StreamReader sr = new StreamReader(fs);

                myArr = sr.ReadLine().Split(',');

                TextBoxes();

                fs.Close();
            }

            else if (comboBox1.Text.Equals("Randgold Resources Limited (GOLD)"))
            {
                string path = @"C:\Downloads\RRL_GLD_rate.csv";
                string url = "http://download.finance.yahoo.com/d/quotes.csv?s=GOLD&f=sl1d1t1c1ohgv&e=.csv";

                Downloadfile(path, url);

                FileStream fs = new FileStream(path, FileMode.Open);
                StreamReader sr = new StreamReader(fs);

                myArr = sr.ReadLine().Split(',');

                TextBoxes();

                fs.Close();
            }

            else if (comboBox1.Text.Equals("SPDR Gold Shares (GLD)"))
            {
                string path = @"C:\Downloads\SPDR_GLD_rate.csv";
                string url = "http://download.finance.yahoo.com/d/quotes.csv?s=GLD&f=sl1d1t1c1ohgv&e=.csv";

                Downloadfile(path, url);

                FileStream fs = new FileStream(path, FileMode.Open);
                StreamReader sr = new StreamReader(fs);


                myArr = sr.ReadLine().Split(',');

                TextBoxes();

                fs.Close();
            }
            else
            {
                MessageBox.Show("Please choose one of the options in the combo box.", "Error");
            }

        }
        
        private void clearBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private static void Downloadfile(string path, string url)
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(url, path);
            }
        }

        private void TextBoxes()
        {
            myArr[2] = myArr[2].Substring(1, (myArr[2].Length -2));
            textBox1.Text += myArr[2].ToString(); //Date
            myArr[3] = myArr[3].Substring(1, (myArr[3].Length -2));
            textBox2.Text += myArr[3].ToString();  //Time
            textBox3.Text += myArr[1].ToString();  //Price
            textBox4.Text += myArr[4].ToString();  //up/down
        }

    }
}
