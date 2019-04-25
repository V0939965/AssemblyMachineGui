using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
namespace Main
{
    public partial class ConfigCamera : Form
    {
        Main main = new Main();
        Configuration db = new Configuration();
        public ConfigCamera(Main mOriginGUI)
        {
            InitializeComponent();
            main = mOriginGUI;
        }

        private void tLight_Scroll(object sender, EventArgs e)
        {
            valueLight.Text = tLight.Value.ToString();
            //if (!Serial_Light.IsOpen)
            //    Serial_Light.Open();
            //label9.Text = trackBar1.Value.ToString();
            //byte[] a = { 0xab, 0xba, 0x03, 0x31, 0x00, 0x09 };
            //a[5] = (byte)trackBar1.Value;
            //Serial_Light.Write(a, 0, a.Length);
            if(!main.Serial_Light.IsOpen)
                main.Serial_Light.Open();
            byte[] a = { 0xab, 0xba, 0x03, 0x31, 0x00, 0x09 };
            a[5] = (byte)tLight.Value;
            main.Serial_Light.Write(a, 0, a.Length);
            //main.Serial_Light.Close();
        }

        private void ConfigCamera_Load(object sender, EventArgs e)
        {
            GroupImagesProcessing.Enabled = false;
            foreach (string s in SerialPort.GetPortNames())
            {
                cLight.Items.Add(s);
                cScanner.Items.Add(s);
                cIT.Items.Add(s);
            }
            cLight.SelectedItem = main.Serial_Light.PortName;
            cScanner.SelectedItem = main.Serial_Scanner.PortName;
            cIT.SelectedItem = main.IT.PortName;
            db.Init();
            tExposureTime.Text = db.save.ExposureTime;
            tRoi.Text = db.save.Roi;
            tPulseX.Text = db.save.PulseX;
            tPulseY.Text = db.save.PulseY;
            tPulseZ.Text = db.save.PulseZ;
            tRoutationCenter.Text = db.save.RotationCenter;
            tLight.Value = Convert.ToInt16( db.save.LightValue);
            bLogout.Enabled = false;
            tLight_Scroll(null, null);
            eLabelLocate.Checked = main.modeLocateLabel;
            eLabelScan.Checked = main.modeScanLabel;
            eSynchronizePLC.Checked = main.modeSynchronizePLC;
            checkBox1.Checked = main.saveimage;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bExposureTime_Click(object sender, EventArgs e)
        {
            bool result =  db.Update(exposuretime: tExposureTime.Text);
            if (result == false)
                MessageBox.Show("Update fail");
        }

        private void bRoi_Click(object sender, EventArgs e)
        {
            bool result = db.Update(roi: tRoi.Text);
            if (result == false)
                MessageBox.Show("Update fail");

        }

        private void bPulseX_Click(object sender, EventArgs e)
        {
            bool result = db.Update(pulsex: tPulseX.Text);
            if (result == false)
                MessageBox.Show("Update fail");
        }

        private void bRoutationCenter_Click(object sender, EventArgs e)
        {
            bool result = db.Update(Center: tRoutationCenter.Text);
            if (result == false)
                MessageBox.Show("Update fail");
        }

        private void bPulseY_Click(object sender, EventArgs e)
        {
            bool result = db.Update(pulsey: tPulseY.Text);
            if (result == false)
                MessageBox.Show("Update fail");
        }

        private void bPulseZ_Click(object sender, EventArgs e)
        {
            bool result = db.Update(pulsez: tPulseZ.Text);
            if (result == false)
                MessageBox.Show("Update fail");
        }

        private void bSignin_Click(object sender, EventArgs e)
        {
            if(tPassword.Text == "foxconn168!!" && tUsers.Text == "v0939965".ToUpper())
            {
                statusLogin.Text = string.Empty;
                bLogout.Enabled = true;
                bLogin.Enabled = false;
                GroupImagesProcessing.Enabled = true;
                tUsers.Enabled = false;
                tPassword.Enabled = false;
            }
            else
            {
                statusLogin.Text = "The user or password is incorrect";
                statusLogin.ForeColor = Color.Red;
            }
        }

        private void bLogout_Click(object sender, EventArgs e)
        {
            GroupImagesProcessing.Enabled = false;
            bLogin.Enabled = true;
            bLogout.Enabled = false;
            tPassword.Text = string.Empty;
            tUsers.Enabled = true;
            tPassword.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            main.saveimage = checkBox1.Checked;
        }

        private void eLabelLocate_CheckedChanged(object sender, EventArgs e)
        {
            main.modeLocateLabel = eLabelLocate.Checked;
        }

        private void eLabelScan_CheckedChanged(object sender, EventArgs e)
        {
            main.modeScanLabel = eLabelScan.Checked;
        }

        private void eSynchronizePLC_CheckedChanged(object sender, EventArgs e)
        {
            main.modeSynchronizePLC = eSynchronizePLC.Checked;
        }

        private void cLight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (main.Serial_Light.IsOpen)
                main.Serial_Light.Close();
            main.Serial_Light.PortName = cLight.SelectedItem.ToString();
            OpenPort(1);
        }
        void OpenPort(int index)
        {
            lLight.ForeColor = Color.Red;
            lIT.ForeColor = Color.Red;
            lScanner.ForeColor = Color.Red;
            try
            {
                if (!main.Serial_Scanner.IsOpen)
                {
                    main.Serial_Scanner.Open();
                }
                lScanner.ForeColor = Color.Black;

            }
            catch (Exception)
            { }
            try
            {
                if (!main.Serial_Light.IsOpen)
                {
                    main.Serial_Light.Open();
                }
                lLight.ForeColor = Color.Black;
            }
            catch (Exception)
            { }
            try
            {
                if (!main.IT.IsOpen)
                {
                    main.IT.Open();
                }
                lIT.ForeColor = Color.Black;

            }
            catch (Exception)
            { }
        }
        private void cScanner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (main.Serial_Scanner.IsOpen)
                main.Serial_Scanner.Close();
            main.Serial_Scanner.PortName = cScanner.SelectedItem.ToString();
            OpenPort(2);
        }

        private void cIT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (main.IT.IsOpen)
                main.IT.Close();
            main.IT.PortName = cIT.SelectedItem.ToString();
            OpenPort(3);
        }
    }
}
