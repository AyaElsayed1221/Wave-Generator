using System.IO.Ports;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        SerialPort port = null;
        string[] waveform = { "Square Wave", "Staircase Wave", "Triangle Wave", "Sine Wave" };
        int mp, fq, temp;
        public Form1()
        {
            InitializeComponent();
            refresh_com();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            refresh_com();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect();
        }

        private void refresh_com()
        {
            comboBox1.DataSource = SerialPort.GetPortNames();
            comboBox2.DataSource = waveform;
            
            }

            private void connect()
        {
            port = new SerialPort(comboBox1.SelectedItem.ToString());
            port.BaudRate = 2400;
            port.DataBits = 8;
            port.StopBits = StopBits.One;
            try
            {
                if (!port.IsOpen)
                {
                    port.Open();
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            port.Write("@");
            port.Write(comboBox2.SelectedIndex.ToString());
            mp = (int)numericUpDown1.Value;
            temp = mp / 100;
            port.Write(temp.ToString());
            temp = mp % 100;
            temp = temp / 10;
            port.Write(temp.ToString());
            temp = mp % 100;
            temp = temp % 10;
            port.Write(temp.ToString());
            fq = (int)numericUpDown2.Value;
            temp = fq / 100;
            port.Write(temp.ToString());
            temp = fq % 100;
            temp = temp / 10;
            port.Write(temp.ToString());
            temp = fq % 100;
            temp = temp % 10;
            port.Write(temp.ToString());
            port.Write(";");
        }
    }
}