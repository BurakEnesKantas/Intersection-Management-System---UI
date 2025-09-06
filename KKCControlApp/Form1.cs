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
        private string receivedDataBuffer = "";

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

            // Phase butonları
            btnPhaseNorth.Click += (s, e) => SendCommand("PM=1");
            btnPhaseSouth.Click += (s, e) => SendCommand("PM=2");
            btnPhaseEast.Click += (s, e) => SendCommand("PM=3");
            btnPhaseWest.Click += (s, e) => SendCommand("PM=4");

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

            
            if (btnSigInfo != null)
                btnSigInfo.Click += btnSigInfo_Click;
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
                    AppendLog("Hiç COM port bulunamadı!", true); 
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
                    serialPort1.DtrEnable = true;
                    serialPort1.RtsEnable = true;
                    serialPort1.NewLine = "\r\n";
                    serialPort1.ReadTimeout = 2000;
                    serialPort1.WriteTimeout = 2000;

                    serialPort1.DataReceived += SerialPort1_DataReceived;
                    serialPort1.Open();
                    System.Threading.Thread.Sleep(100);

                    AppendLog($"Bağlandı: {serialPort1.PortName} @{serialPort1.BaudRate}", true); // Bağlantı mesajları için true
                    UpdateControls(true);
                    receivedDataBuffer = "";
                }
                else
                {
                    if (!serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                        receivedDataBuffer = "";
                        AppendLog("Bağlantı Kesildi", true); 
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
                AppendLog(errorMsg, true); 
            }
        }

        private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (serialPort1 == null || !serialPort1.IsOpen) return;

                string newData = serialPort1.ReadExisting();
                receivedDataBuffer += newData;

                string[] lines = receivedDataBuffer.Split('\n');
                receivedDataBuffer = lines[lines.Length - 1];

                for (int i = 0; i < lines.Length - 1; i++)
                {
                    string line = lines[i].Trim('\r', '\n', ' ');
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        if (this.InvokeRequired)
                        {
                            this.BeginInvoke(new Action(() =>
                            {
                                ProcessReceivedData(line);
                            }));
                        }
                        else
                        {
                            ProcessReceivedData(line);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Sessizce geçer
            }
        }

        private void ProcessReceivedData(string line)
        {
            
            if (line.Contains("Current Time (UTC"))
            {
                string[] parts = line.Split(':');
                if (parts.Length >= 2)
                {
                    string timeValue = parts[1].Trim() + ":" + parts[2].Trim() + ":" + parts[3].Trim();
                    lblTime.Text = timeValue;
                }
                return; 
            }
            else if (line.Contains("Current Date"))
            {
                string[] parts = line.Split(':');
                if (parts.Length >= 2)
                {
                    string dateValue = parts[1].Trim();
                    lblDate.Text = dateValue;
                }
                return; 
            }
            else if (line.Contains("Current Time Zone"))
            {
                string[] parts = line.Split(':');
                if (parts.Length >= 2)
                {
                    string tzValue = parts[1].Trim();
                    lblTimeZone.Text = tzValue;
                }
                return; // Log'a yazma
            }

            // LED durumlarını kontrol et ve güncelle (sadece LED status mesajları için)
            if (IsLedStatusMessage(line))
            {
                ParseAndUpdateLed(line);
                
                return;
            }

            // Sadece query komutlarının cevaplarını ve önemli mesajları log'a yaz
            if (IsImportantMessage(line))
            {
                AppendLog("Alındı: " + line, true);
            }
        }

        private bool IsLedStatusMessage(string line)
        {
            // LED durum mesajlarını tanımla
            string[] ledKeywords = {
                "South Red", "South Yellow", "South Green",
                "West Red", "West Yellow", "West Green",
                "North Red", "North Yellow", "North Green",
                "East Red", "East Yellow", "East Green"
            };

            foreach (string keyword in ledKeywords)
            {
                if (line.Contains(keyword) && (line.Contains("ON") || line.Contains("OFF")))
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsImportantMessage(string line)
        {
            // Hangi mesajların log'da görünmesini istiyorsanız buraya ekleyin
            string[] importantKeywords = {
                "MODE?", "PHASE?", "SIG?", "D?", "TZ?", // Query cevapları
                "ERROR", "HATA", // Hata mesajları
                "OK", "BAŞARILI", "SUCCESS", // Başarı mesajları
                "RST", "RESET", // Reset mesajları
                "SM", "FM" // Mod değişiklikleri
            };

            foreach (string keyword in importantKeywords)
            {
                if (line.ToUpper().Contains(keyword))
                    return true;
            }

            return false;
        }

        private void ParseAndUpdateLed(string line)
        {
            var parts = line.Split(' ');
            if (parts.Length < 3) return;

            string ledName = parts[0] + " " + parts[1];
            string stateStr = parts[2];

            bool isOn = stateStr.Equals("ON", StringComparison.OrdinalIgnoreCase);

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
            // Tüm PictureBox'ları yuvarlak yap ve başlangıç rengini gri olarak ayarla
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

            
            InitializeTrafficLights();
        }

        private void InitializeTrafficLights()
        {
            // Tüm trafik ışıklarını başlangıçta gri (kapalı)
            pbSouthRed.BackColor = Color.Gray;
            pbSouthYellow.BackColor = Color.Gray;
            pbSouthGreen.BackColor = Color.Gray;

            pbWestRed.BackColor = Color.Gray;
            pbWestYellow.BackColor = Color.Gray;
            pbWestGreen.BackColor = Color.Gray;

            pbNorthRed.BackColor = Color.Gray;
            pbNorthYellow.BackColor = Color.Gray;
            pbNorthGreen.BackColor = Color.Gray;

            pbEastRed.BackColor = Color.Gray;
            pbEastYellow.BackColor = Color.Gray;
            pbEastGreen.BackColor = Color.Gray;
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

        
        private void AppendLog(string text, bool showInLog = false)
        {
            if (!showInLog) return; // showInLog false ise log'a yazma

            try
            {
                string line = $"[{DateTime.Now:HH:mm:ss}] {text}{Environment.NewLine}";

                if (txtLog.InvokeRequired)
                {
                    txtLog.BeginInvoke(new Action(() =>
                    {
                        txtLog.AppendText(line);
                        txtLog.ScrollToCaret();
                    }));
                }
                else
                {
                    txtLog.AppendText(line);
                    txtLog.ScrollToCaret();
                }
            }
            catch (Exception)
            {
                // Sessizce geçer
            }
        }

        private void btnSendRaw_Click(object sender, EventArgs e)
        {
            string cmd = atxtRawCmd.Text.Trim();
            if (!string.IsNullOrEmpty(cmd))
            {
                SendCommand(cmd);
                atxtRawCmd.Clear();
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
                    AppendLog("Gönderildi: " + cmd.Trim(), true); 
                }
                else
                {
                    MessageBox.Show("Port bağlı değil!");
                    AppendLog("HATA: Port bağlı değil!", true);
                    UpdateControls(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gönderme hatası: " + ex.Message);
                AppendLog("Gönderme hatası: " + ex.Message, true);
                if (!serialPort1.IsOpen)
                {
                    AppendLog("HATA: Port kapandı, yeniden bağlanmayı deneyin", true);
                    UpdateControls(false);
                }
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
            AppendLog("Log temizlendi", true);
        }

        private void UpdateControls(bool connected)
        {
            cmbPorts.Enabled = !connected;
            cmbBaud.Enabled = !connected;
            btnRefresh.Enabled = !connected;

            btnSendRaw.Enabled = connected;

            if (btnPhaseNorth != null) btnPhaseNorth.Enabled = connected;
            if (btnPhaseSouth != null) btnPhaseSouth.Enabled = connected;
            if (btnPhaseEast != null) btnPhaseEast.Enabled = connected;
            if (btnPhaseWest != null) btnPhaseWest.Enabled = connected;

            if (btnSM != null) btnSM.Enabled = connected;
            if (btnFM != null) btnFM.Enabled = connected;
            if (btnRST != null) btnRST.Enabled = connected;
            if (btnStop != null) btnStop.Enabled = connected;
            if (btnOff != null) btnOff.Enabled = connected;
            if (btnModeQuery != null) btnModeQuery.Enabled = connected;
            if (btnPhaseQuery != null) btnPhaseQuery.Enabled = connected;
            if (btnSigInfo != null) btnSigInfo.Enabled = connected;
            if (btnPhaseAllGroupInfo != null) btnPhaseAllGroupInfo.Enabled = connected;

            if (btnSetTZ != null) btnSetTZ.Enabled = connected;
            if (btnSetDate != null) btnSetDate.Enabled = connected;
            if (btnSetTime != null) btnSetTime.Enabled = connected;
            if (btnLearnD != null) btnLearnD.Enabled = connected;
            if (btnLearnTZ != null) btnLearnTZ.Enabled = connected;

            if (btnApplyNorth != null) btnApplyNorth.Enabled = connected;

            if (lblStatus != null)
                lblStatus.Text = connected ? $"Bağlı: {serialPort1.PortName} @{serialPort1.BaudRate}" : "Bağlantı Yok";

            btnConnect.Text = connected ? "❌ Disconnect" : "🔗 Connect";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                if (serialPort1 != null && serialPort1.IsOpen)
                {
                    serialPort1.DataReceived -= SerialPort1_DataReceived;
                    serialPort1.Close();
                    serialPort1.Dispose();
                }
            }
            catch (Exception)
            {
                // Sessizce geç
            }
            base.OnFormClosing(e);
        }

        private void cmbTimeZone_SelectedIndexChanged(object sender, EventArgs e) { }
        private void button12_Click(object sender, EventArgs e) { }
        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e) { }
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }

        private void btnApplySouth_Click(object sender, EventArgs e)
        {
            try
            {
                if (numSouth != null)
                    SendCommand($"south={numSouth.Value}");
                AppendLog("Güney gecikmesi uygulandı", true);
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
                if (numNorth != null)
                    SendCommand($"north={numNorth.Value}");
                AppendLog("Kuzey gecikmesi uygulandı", true);
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
                if (numWest != null)
                    SendCommand($"west={numWest.Value}");
                AppendLog("Batı gecikmesi uygulandı", true);
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
                if (numEast != null)
                    SendCommand($"east={numEast.Value}");
                AppendLog("Doğu gecikmesi uygulandı", true);
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
                if (numTransition != null)
                    SendCommand($"transition={numTransition.Value}");
                AppendLog("Geçiş gecikmesi uygulandı", true);
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
            numNorth.Value = 0;
            numSouth.Value = 0;
            numWest.Value = 0;
            numEast.Value = 0;
            numTransition.Value = 0;
            AppendLog("Gecikmeler sıfırlandı", true);
        }
    }
}