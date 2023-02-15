using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Temperatura_humedad_arduino
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try {
                serialPort1.Open();
                btnConectar.Enabled = false;
                btnDesconectar.Enabled = true;
            }
            catch (Exception ex){ 
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                string[] serialLine = serialPort1.ReadLine().Split(' ');
                
                int temp = Convert.ToInt32(serialLine[0]);

                int hum = Convert.ToInt32(serialLine[1]);

                chart1.Invoke((MethodInvoker)(() => chart1.Series["Temperatura"].Points.AddY(temp)));
                chart2.Invoke((MethodInvoker)(() => chart2.Series["Humedad"].Points.AddY(hum)));
            }

        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnDesconectar.Enabled = false;
        }
    }
}
