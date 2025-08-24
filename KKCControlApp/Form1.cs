using Microsoft.VisualBasic;
using System;
using System.IO.Ports;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KKCControlApp
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort1;
        private string receivedDataBuffer = ""; // BUFFER EKLE

        public Form1()
        {
            InitializeComponent();

            // SerialPort nesnesi oluştur
            serialPort1 = new SerialPort();

            // Başlangıçta UI ayarları
            RefreshComPorts();

            // Baud combo doldurma
            cmbBaud.Items.Clear();
            cmbBaud.Items.AddRange(new object[] { "9600", "19200", "38400", "57600", "115200" });
            cmbBaud.SelectedItem = "115200";

            UpdateControls(false); // bağlantı yokken butonları disable et

            // Event handler'ları bağla
            btnRefresh.Click += btnRefresh_Click;
            btnConnect.Click += btnConnect_Click;
            btnClearLog.Click += btnClearLog_Click;
            btnSendRaw.Click += btnSendRaw_Click;

            // Phase butonları - GUI'de gördüğüm butonlara göre
            btnPhaseNorth.Click += (s, e) => SendCommand("PM=1");
            btnPhaseSouth.Click += (s, e) => SendCommand("PM=2");
            btnPhaseEast.Click += (s, e) => SendCommand("PM=3");
            btnPhaseWest.Click += (s, e) => SendCommand("PM=4");



            // Diğer eksik butonlar için event handler'lar
            if (btnSM != null)
                btnSM.Click += (s, e) => SendCommand("SM");

            if (btnFM != null)
                btnFM.Click += (s, e) => SendCommand("FM");

            if (btnRST != null)
                btnRST.Click += (s, e) => SendCommand("RST");

            if (btnStop != null)
                btnStop.Click += (s, e) => SendCommand("STOP");

            if (btnOff != null)
                btnOff.Click += (s, e) => SendCommand("OFF");

            if (btnModeQuery != null)
                btnModeQuery.Click += (s, e) => SendCommand("MODE?");

            if (btnPhaseQuery != null)
                btnPhaseQuery.Click += (s, e) => SendCommand("PHASE?");

            // Time/Date butonları
            if (btnSetTZ != null)
                btnSetTZ.Click += btnSetTimeZone_Click;

            if (btnSetDate != null)
                btnSetDate.Click += btnSetDate_Click;

            if (btnSetTime != null)
                btnSetTime.Click += btnSetTime_Click;

            // Learn butonları
           if (btnLearnD != null)
                btnLearnD.Click += (s, e) => SendCommand("D?");

            if (btnLearnTZ != null)
                btnLearnTZ.Click += (s, e) => SendCommand("TZ?");

            // All Group butonu
            if (btnPhaseAllGroupInfo != null)
                btnPhaseAllGroupInfo.Click += (s, e) => SendCommand("SIG?");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshComPorts();
        }

        private void btnSetTimeZone_Click(object sender, EventArgs e)
        {
            if (cmbTimeZone != null && cmbTimeZone.SelectedItem != null)
            {
                SendCommand($"TZ={cmbTimeZone.SelectedItem}");
            }
        }

        private void btnSetDate_Click(object sender, EventArgs e)
        {
            if (dtpSetDate != null)
            {
                string dateStr = dtpSetDate.Value.ToString("dd/MM/yyyy");
                SendCommand($"SD={dateStr}");
            }
        }

        private void btnSetTime_Click(object sender, EventArgs e)
        {
            if (dtpSetTime != null)
            {
                string timeStr = dtpSetTime.Value.ToString("HH:mm:ss");
                SendCommand($"ST={timeStr}");
            }
        }

        private void RefreshComPorts()
        {
            try
            {
                cmbPorts.Items.Clear();
                string[] ports = SerialPort.GetPortNames();
                cmbPorts.Items.AddRange(ports);
                if (cmbPorts.Items.Count > 0)
                    cmbPorts.SelectedIndex = 0;
                else
                    AppendLog("Hiç COM port bulunamadı!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Port listeleme hatası: " + ex.Message);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort1 == null)
                    serialPort1 = new SerialPort();

                if (!serialPort1.IsOpen)
                {
                    if (cmbPorts.SelectedItem == null)
                    {
                        MessageBox.Show("Lütfen bir COM port seçin.");
                        return;
                    }

                    serialPort1.PortName = cmbPorts.SelectedItem.ToString();
                    serialPort1.BaudRate = int.Parse(cmbBaud.SelectedItem.ToString());
                    serialPort1.DataBits = 8;
                    serialPort1.Parity = Parity.None;
                    serialPort1.StopBits = StopBits.One;
                    serialPort1.Handshake = Handshake.None;
                    serialPort1.DtrEnable = true;  // DTR'ı aktif et
                    serialPort1.RtsEnable = true;  // RTS'yi aktif et
                    serialPort1.NewLine = "\r\n";
                    serialPort1.ReadTimeout = 2000;
                    serialPort1.WriteTimeout = 2000;

                    // Data received event'ini bağla
                    serialPort1.DataReceived += SerialPort1_DataReceived;

                    serialPort1.Open();

                    // Bağlantı sonrası kısa bekleme
                    System.Threading.Thread.Sleep(100);

                    AppendLog($"Bağlandı: {serialPort1.PortName} @{serialPort1.BaudRate}");
                    UpdateControls(true);

                    receivedDataBuffer = "";
                }
                else
                {
                    //Bağlantı kesme
                    if (!serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                        receivedDataBuffer = "";
                        AppendLog("Bağlantı Kesildi");
                        UpdateControls(false);
                    }
                }
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Port başka bir uygulama tarafından kullanılıyor!");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Geçersiz port parametresi: " + ex.Message);
            }
            catch (Exception ex)
            {
                string errorMsg = $"Bağlantı hatası: {ex.Message}\nStackTrace: {ex.StackTrace}";
                MessageBox.Show(errorMsg);
                AppendLog(errorMsg);
            }
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

            
            try
            {
                if (serialPort1 == null || !serialPort1.IsOpen) return;

                // Gelen veriyi buffer'a ekle
                string newData = serialPort1.ReadExisting();
                receivedDataBuffer += newData;

                // Satırları ayır
                string[] lines = receivedDataBuffer.Split('\n');

                // Son eleman tam satır değilse buffer'da bırak
                receivedDataBuffer = lines[lines.Length - 1];

                // Tam satırları işle (son hariç)
                for (int i = 0; i < lines.Length - 1; i++)
                {
                    string line = lines[i].Trim('\r', '\n', ' ');
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        if (this.InvokeRequired)
                        {
                            this.BeginInvoke(new Action(() =>
                            {
                                //AppendLog("Alındı: " + line);
                                ParseAndUpdateLed(line); // LED güncelle

                                if (line.Contains("Current Time (UTC"))
                                {
                                    // "Current Time (UTC +0): 17:30:58"
                                    string[] parts = line.Split(':');
                                    if (parts.Length >= 2)
                                    {
                                        string timeValue = parts[1].Trim() +":" + parts[2].Trim() + ":" + parts[3].Trim(); // 17:30:58 kısmı
                                        lblTime.Text = timeValue;
                                    }
                                }
                                else if (line.Contains("Current Date"))
                                {
                                    // "Current Date: 23/08/2025"
                                    string[] parts = line.Split(':');
                                    if (parts.Length >= 2)
                                    {
                                        string dateValue = parts[1].Trim();
                                        lblDate.Text = dateValue;
                                    }
                                }
                                else if (line.Contains("Current Time Zone"))
                                {
                                    // "Current Time Zone: UTC +0"
                                    string[] parts = line.Split(':');
                                    if (parts.Length >= 2)
                                    {
                                        string tzValue = parts[1].Trim();
                                        lblTimeZone.Text = tzValue;
                                    }
                                }
                            }));
                        }
                        else
                        {
                            //AppendLog("Alındı: " + line);
                            ParseAndUpdateLed(line);
                        }
                    }


                }
            }
            catch (Exception)
            {
                // Hataları yoksay
            }
        }

        private void ParseAndUpdateLed(string line)
        {
            // Örnek line: "North Green OFF" veya "South Red ON"
            var parts = line.Split(' ');
            if (parts.Length < 3) return;

            string ledName = parts[0] + " " + parts[1]; // Örn: "North Green"
            string stateStr = parts[2]; // ON veya OFF

            bool isOn = stateStr.Equals("ON", StringComparison.OrdinalIgnoreCase);

            // LedName göre PictureBox güncelle
            switch (ledName)
            {
                case "South Red": SetLight(pbSouthRed, isOn, Color.Red); break;
                case "South Yellow": SetLight(pbSouthYellow, isOn, Color.Yellow); break;
                case "South Green": SetLight(pbSouthGreen, isOn, Color.Lime); break;

                case "West Red": SetLight(pbWestRed, isOn, Color.Red); break;
                case "West Yellow": SetLight(pbWestYellow, isOn, Color.Yellow); break;
                case "West Green": SetLight(pbWestGreen, isOn, Color.Lime); break;

                case "North Red": SetLight(pbNorthRed, isOn, Color.Red); break;
                case "North Yellow": SetLight(pbNorthYellow, isOn, Color.Yellow); break;
                case "North Green": SetLight(pbNorthGreen, isOn, Color.Lime); break;

                case "East Red": SetLight(pbEastRed, isOn, Color.Red); break;
                case "East Yellow": SetLight(pbEastYellow, isOn, Color.Yellow); break;
                case "East Green": SetLight(pbEastGreen, isOn, Color.Lime); break;
            }
        }

        private void SetLight(PictureBox pb, bool isOn, Color activeColor)
        {
            pb.BackColor = isOn ? activeColor : Color.Gray;
        }





        private void MakeCircle(PictureBox pb)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pb.Width - 1, pb.Height - 1);
            pb.Region = new Region(gp);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Tüm PictureBox’ları yuvarlak yap
            MakeCircle(pbSouthRed);
            MakeCircle(pbSouthYellow);
            MakeCircle(pbSouthGreen);

            MakeCircle(pbWestRed);
            MakeCircle(pbWestYellow);
            MakeCircle(pbWestGreen);

            MakeCircle(pbNorthRed);
            MakeCircle(pbNorthYellow);
            MakeCircle(pbNorthGreen);

            MakeCircle(pbEastRed);
            MakeCircle(pbEastYellow);
            MakeCircle(pbEastGreen);
        }
        




        private Color GetColorFromString(string color)
        {
            return color switch
            {
                "RED" => Color.Red,
                "YELLOW" => Color.Yellow,
                "GREEN" => Color.Lime,
                _ => Color.Gray,
            };
        }


        private void AppendLog(string text)
        {
            try
            {
                string line = $"[{DateTime.Now:HH:mm:ss}] {text}{Environment.NewLine}";

                if (txtLog.InvokeRequired)
                {
                    txtLog.BeginInvoke(new Action(() =>
                    {
                        txtLog.AppendText(line);
                        txtLog.ScrollToCaret(); // En alta kaydır
                    }));
                }
                else
                {
                    txtLog.AppendText(line);
                    txtLog.ScrollToCaret(); // En alta kaydır
                }
            }
            catch (Exception)
            {
                // Log yazma hatası görmezden gel
            }
        }

        private void btnSendRaw_Click(object sender, EventArgs e)
        {
            string cmd = atxtRawCmd.Text.Trim();
            if (!string.IsNullOrEmpty(cmd))
            {
                SendCommand(cmd);
                atxtRawCmd.Clear(); // Gönderildikten sonra temizle
            }
        }

        private void SendCommand(string cmd)
        {
            try
            {
                if (serialPort1 != null && serialPort1.IsOpen)
                {
                    if (!cmd.EndsWith("\r\n"))
                        cmd += "\r\n";

                    serialPort1.Write(cmd);
                    AppendLog("Gönderildi: " + cmd.Trim());
                }
                else
                {
                    MessageBox.Show("Port bağlı değil!");
                    AppendLog("HATA: Port bağlı değil!");
                    UpdateControls(false); // UI'yı güncelle
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gönderme hatası: " + ex.Message);
                AppendLog("Gönderme hatası: " + ex.Message);
                if (!serialPort1.IsOpen)
                {
                    AppendLog("HATA: Port kapandı, yeniden bağlanmayı deneyin");
                    UpdateControls(false);
                }
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            AppendLog("Log temizlendi");
        }

        private void UpdateControls(bool connected)
        {
            // Bağlantı kontrolları
            cmbPorts.Enabled = !connected;
            cmbBaud.Enabled = !connected;
            btnRefresh.Enabled = !connected;

            // Komut butonları
            btnSendRaw.Enabled = connected;

            // Phase butonları
            if (btnPhaseNorth != null) btnPhaseNorth.Enabled = connected;
            if (btnPhaseSouth != null) btnPhaseSouth.Enabled = connected;
            if (btnPhaseEast != null) btnPhaseEast.Enabled = connected;
            if (btnPhaseWest != null) btnPhaseWest.Enabled = connected;

            // Diğer kontrol butonları
            if (btnSM != null) btnSM.Enabled = connected;
            if (btnFM != null) btnFM.Enabled = connected;
            if (btnRST != null) btnRST.Enabled = connected;
            if (btnStop != null) btnStop.Enabled = connected;
            if (btnOff != null) btnOff.Enabled = connected;
            if (btnModeQuery != null) btnModeQuery.Enabled = connected;
            if (btnPhaseQuery != null) btnPhaseQuery.Enabled = connected;
            if (btnSigInfo != null) btnSigInfo.Enabled = connected;
            if (btnPhaseAllGroupInfo != null) btnPhaseAllGroupInfo.Enabled = connected;

            // Time/Date kontrolları
            if (btnSetTZ != null) btnSetTZ.Enabled = connected;
            if (btnSetDate != null) btnSetDate.Enabled = connected;
            if (btnSetTime != null) btnSetTime.Enabled = connected;
            if (btnLearnD != null) btnLearnD.Enabled = connected;
            if (btnLearnTZ != null) btnLearnTZ.Enabled = connected;

            // Delay kontrolları
            if (btnApplyNorth != null) btnApplyNorth.Enabled = connected;

            // Status güncelle
            if (lblStatus != null)
                lblStatus.Text = connected ? $"Bağlı: {serialPort1.PortName} @{serialPort1.BaudRate}" : "Bağlantı Yok";

            btnConnect.Text = connected ? "Bağlantıyı Kes" : "Bağlan";
        }

        // Form kapanırken port'u kapat
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                if (serialPort1 != null && serialPort1.IsOpen)
                {
                    serialPort1.DataReceived -= SerialPort1_DataReceived;
                    serialPort1.Open();
                    serialPort1.Dispose();
                }
            }
            catch (Exception)
            {
                // Kapanış hatası görmezden gel
            }
            base.OnFormClosing(e);
        }

        // Boş event handler'lar (Designer için)
        private void cmbTimeZone_SelectedIndexChanged(object sender, EventArgs e) { }
        private void button12_Click(object sender, EventArgs e) { }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e) { }
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        //private void Form1_Load(object sender, EventArgs e) { }

        private void btnApplySouth_Click(object sender, EventArgs e)
        {
            try
            {
                // NumericUpDown kontrollerinden değerleri al
                if (numSouth != null)
                    SendCommand($"south={numSouth.Value}");

                AppendLog("Gecikmeler uygulandı");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gecikme uygulama hatası: " + ex.Message);
            }
        }

        private void btnApplyNorth_Click(object sender, EventArgs e)
        {
            try
            {
                // NumericUpDown kontrollerinden değerleri al
                if (numNorth != null)
                    SendCommand($"north={numNorth.Value}");

                AppendLog("Gecikmeler uygulandı");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gecikme uygulama hatası: " + ex.Message);
            }
        }

        private void btnApplyWest_Click(object sender, EventArgs e)
        {
            try
            {
                // NumericUpDown kontrollerinden değerleri al
                if (numWest != null)
                    SendCommand($"west={numWest.Value}");

                AppendLog("Gecikmeler uygulandı");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gecikme uygulama hatası: " + ex.Message);
            }
        }

        private void btnApplyEast_Click(object sender, EventArgs e)
        {
            try
            {
                // NumericUpDown kontrollerinden değerleri al
                if (numEast != null)
                    SendCommand($"east={numEast.Value}");

                AppendLog("Gecikmeler uygulandı");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gecikme uygulama hatası: " + ex.Message);
            }
        }

        private void btnApplyTransition_Click(object sender, EventArgs e)
        {
            try
            {
                // NumericUpDown kontrollerinden değerleri al
                if (numTransition != null)
                    SendCommand($"transition={numTransition.Value}");

                AppendLog("Gecikmeler uygulandı");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gecikme uygulama hatası: " + ex.Message);
            }
        }

        private void btnSigInfo_Click(object sender, EventArgs e)
        {
            if (cmbSig != null && cmbSig.SelectedItem != null)
            {
                SendCommand($"SIG={cmbSig.SelectedItem}");
            }
        }

        private void btnResetDelays_Click(object sender, EventArgs e)
        {
            SendCommand("RST Delay");
        }
    }
}