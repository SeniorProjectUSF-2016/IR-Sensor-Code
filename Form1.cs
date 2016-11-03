using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace IRsensor
{
    public partial class Form1 : Form
    {
        //public static System.IO.Ports.SerialPort serialPort1;
        //private delegate void LineReceivedEvent(string line);
        public Form1()
        {
            InitializeComponent();
            System.ComponentModel.IContainer components = new System.ComponentModel.Container();
            SerialPort serialPort1 = new SerialPort("COM8"); //This needs to be changed depending on what port Arduino plugged into
            serialPort1.BaudRate = 9600;
            serialPort1.DtrEnable = true;
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.Open();
                    serialPort1.Write("A");
                    serialPort1.Close();
                }
                catch
                {
                    MessageBox.Show("There was an error. Please make sure that the correct port was selected, and the device, plugged in.");
                }
            }
            serialPort1.Open();
       

            string sensor = serialPort1.ReadLine();

            string posResult = "true";

            if (String.Compare(sensor, posResult, true) == 1)
            {
                //Put the camera activation code in here
                MessageBox.Show("Motion Detected");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
    }
}
