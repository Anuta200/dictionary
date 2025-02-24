namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FileStream en_fs = File.Open(@"EnRuDict.dat", FileMode.OpenOrCreate); en_fs.Close();
            FileStream ru_fs = File.Open(@"RuEnDict.dat", FileMode.OpenOrCreate); ru_fs.Close();
        }
        private void addFile(string fileName, string textAdd)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.WriteLine(textAdd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error:{ex.Message}");
            }
        }
        private void scanFile(string fileName, ListBox targetListBox)
        {
            try
            {
                using (var sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        targetListBox.Items.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("error:{ex.Message}");
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string f = textBox1.Text;
            string n = textBox2.Text;
            string k = f + " " + n;
            listBox1.Items.Add(k);
            addFile("EnRuDict.dat", k);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string f = textBox3.Text;
            string n = textBox4.Text;
            string k = f + " " + n;
            listBox2.Items.Add(k);
            addFile("RuEnDict.dat", k);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            scanFile("EnRuDict.dat", listBox1);
            scanFile("RuEnDict.dat", listBox2);
        }
    }
}