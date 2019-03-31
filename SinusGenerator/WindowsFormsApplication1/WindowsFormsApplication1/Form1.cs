using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float startFreq = 205000;
            float stopFreq = 205000;

            int nPingLength_us = 2000;

            int nSTM_period = 300; // 400ns

            int nStepCount = nPingLength_us * 1000 / nSTM_period;
            double dRes;
            int Res;
            int nAmplitude = 0x70;

            String arrayText = "int sinArray [] ={";

            for (int i = 0; i < nStepCount; i++)
            {
                dRes = nAmplitude * (1 + Math.Sin(-1*Math.PI/2 + i * 2*Math.PI / nStepCount)) * Math.Sin(2 * Math.PI * (startFreq + (stopFreq - startFreq) * i / nStepCount) * i * nSTM_period / 1000000000);
                Res = (int)(dRes + 0.5);
                arrayText += ""  + Res + ",";
            }
            arrayText += "};\r\n";
            arrayText += "int sinSize = " + nStepCount + ";";
            System.IO.File.WriteAllText("myText.txt", arrayText); 
        }
    }
}
