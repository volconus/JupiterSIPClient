using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using JupiterSIPClient1.wsReference;
using System.Dynamic;
using Ozeki.VoIP;
using Ozeki.VoIP.SDK;
using Ozeki.VoIP.SIP;
using Ozeki.Media;
using Ozeki.Media.MediaHandlers;
using System.Drawing;
using Ozeki.VoIP.SIP.Logger;
using Ozeki.Common.Logger;


namespace JupiterSIPClient1
{   
    class main
    {
        public static string announcePath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic) + "\\";
        public static int currentAgentState;
        public static int second = 0;
        public static string agentId, domainName, sipUserName, sipAuth, sipPassword, sipServerIp, sipServerHostname, sipServerPort;
        public static string sipHostName = "", agentCurrentSkillName = "", agentCurrentFromNumber = "";
        public static string defMicrophone = "", defSpeaker = "", defAudioCodec = "", defVideoCodec = "";
        public JupiterWS jws = new JupiterWS();

        public static int getStartPosition(int formWidth)
        {
            Screen myScreen = Screen.PrimaryScreen;
            return myScreen.WorkingArea.Width - formWidth;
        }

        public static void resetTimer()
        {
            second = 0;
        }

        public static void loadActions()
        {
            try
            {
                sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();
                sipClient.answerPanel.Visible = false;
                sipClient.downloadBar.Visible = false;
                Screen myScreen = Screen.PrimaryScreen;
                Ozeki.VoIP.SDK.Protection.LicenseManager.Instance.SetLicense("OZSDK-DNA2CALL-151119-282F5AEA", "TUNDOjIsTVBMOjIsRzcyOTp0cnVlLE1TTEM6MixNRkM6MixVUDoyMDE2LjExLjE5LFA6MjE5OS4wMS4wMXxGdnd4ZEt6SnFRbzI1eXdvMmpVaVkrdVVscUpoRXg0OGNta2w4WDYzMGFJMENOWkx4dmtobXgrWURXMERaQjAwNHcvbE4xL25FYnpORGh2Qm5WUWdXZz09");
                sipClient.softphone = SoftPhoneFactory.CreateSoftPhone(5000, 10000);
                sipClient.statusScreen.Text = "Started";
                sipClient.Height = myScreen.WorkingArea.Height;
                sipClient.Location = new Point(getStartPosition(sipClient.Width), 0);
                logAdd("", 1, "Application Started");
                bool result = registerToSIP();
                if (result == true)
                {
                    sipClient.phoneLine1.RegistrationStateChanged += sipClient.sipAccount_RegStateChanged;
                    sipClient.softphone.IncomingCall += sipClient.softphone_IncomingCall;
                    
                    sipClient.sipMessageLogger = new SIPMessageLogger();
                    sipClient.sipMessageLogger.SIPMessageReceived += (sipClient.sipMessageLogger_SIPMessageReceived);                   

                    bool microphoneSuccess = false;
                    Microphone.GetDevices().ForEach(delegate(Ozeki.Media.Audio.DeviceInfo mic)
                    {
                        if (mic.ProductName.Contains(defMicrophone))
                        {
                            sipClient.microphone = Microphone.GetDevice(mic);
                            MessageBox.Show("Mikrofon seçildi = " + mic.ProductName.ToString());
                            microphoneSuccess = true;
                        }
                    });

                    bool speakerSuccess = false;
                    Speaker.GetDevices().ForEach(delegate(Ozeki.Media.Audio.DeviceInfo speaker)
                    {
                        if (speaker.ProductName.Contains(defSpeaker))
                        {
                            sipClient.speaker = Speaker.GetDevice(speaker);
                            MessageBox.Show("Kulaklık seçildi = " + speaker.ProductName.ToString());
                            speakerSuccess = true;
                        }
                    });

                    if (microphoneSuccess == false)
                    {
                        sipClient.microphone = Microphone.GetDefaultDevice();
                        main.errorModal("Daha önce seçtğiniz " + defMicrophone + " adlı cihaz şuan bu PC'ye bağlı değil. Bu sebeple varsayılan mikrofon seçildi.");
                    }
                    if (speakerSuccess == false)
                    {
                        sipClient.speaker = Speaker.GetDefaultDevice();
                        main.errorModal("Daha önce seçtğiniz " + defSpeaker + " adlı cihaz şuan bu PC'ye bağlı değil. Bu sebeple varsayılan kulaklık/hoparlör seçildi.");
                    }


                    sipClient.mediaReceiver = new PhoneCallAudioReceiver();
                    sipClient.mediaSender = new PhoneCallAudioSender();
                    sipClient.connector = new MediaConnector();
                    disableAllAudioCodecs();
                    disableAllVideoCodecs();
                    enableAudioCodec(defAudioCodec);
                    enableVideoCodec(defVideoCodec);
                    wsc.getAgentAnnounces();
                }
            }
            catch (Exception err) { errorModal("LoadActions: " + err.Message.ToString()); }
        }

        public static void activateDefaultMP3Player(string fileName)
        {        
            sipClient.mediaSender.Detach();
            sipClient.mp3Player = new MP3StreamPlayback(main.announcePath + fileName);
            System.IO.Stream stream;
            sipClient.speaker.Start();
            sipClient.connector.Connect(sipClient.mp3Player, sipClient.speaker);
            sipClient.mp3Player.Start();
            logAdd(null, 1, fileName + " playing...");
        }



        public static bool registerToSIP()
        {
            try
            {
                settingSIP settingSIP = (from p in Application.OpenForms.OfType<settingSIP>() select p).FirstOrDefault();
                sipClient.sipMessageManipulator = new SIP_CustomMessageManipulator(); 
                sipClient.softphone.SetSIPMessageManipulator(sipClient.sipMessageManipulator);

                /*if (sipHostName.Length > 1) // eğer hostname varsa, IP yerine hostname ile bağlan.
                    sipServerIp = sipHostName;*/

                var account = new SIPAccount(true, sipUserName,
                    sipUserName,
                    sipAuth,
                    sipPassword,
                    sipServerIp,
                    Int32.Parse(sipServerPort)
                );
                sipClient.phoneLine1 = sipClient.softphone.CreatePhoneLine(account);
                sipClient.softphone.RegisterPhoneLine(sipClient.phoneLine1);                
                return true;
            }
            catch (InvalidCastException err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }

        internal static bool unRegisterToSIP()
        {
            try
            {
                sipClient.softphone.UnregisterPhoneLine(sipClient.phoneLine1);
                return true;
            }
            catch (InvalidCastException err)
            {
                MessageBox.Show(err.Message);
                return false;
            }
        }

        public static void disableAllAudioCodecs()
        {
            sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();

            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.G722);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.G723);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.G726_16);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.G726_24);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.G726_32);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.G726_40);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.G728);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.G729);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.GSM);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.iLBC);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.L16);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.L16_44_1);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.L16_44_2);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.PCMA);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.PCMU);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.Speex_Narrowband);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.Speex_Ultrawideband);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.Speex_Wideband);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.telephone_event);
        }

        public static void disableAllVideoCodecs()
        {
            sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.MPEG4);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.H264);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.H263_plus);
            sipClient.softphone.DisableCodec(Ozeki.Media.Codec.CodecPayloadType.H263);
        }

        public static void enableAudioCodec(string codecName)
        {
            sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();
            if (codecName == "G729")
                sipClient.softphone.EnableCodec(Ozeki.Media.Codec.CodecPayloadType.G729);
            else if (codecName == "G722")
                sipClient.softphone.EnableCodec(Ozeki.Media.Codec.CodecPayloadType.G722);

        }

        public static void enableVideoCodec(string codecName)
        {
            if (codecName == "H264")
                sipClient.softphone.EnableCodec(Ozeki.Media.Codec.CodecPayloadType.H264);
            else if (codecName == "H263")
                sipClient.softphone.EnableCodec(Ozeki.Media.Codec.CodecPayloadType.H263);
        }

        public static void regStateChanged(RegistrationStateChangedArgs e)
        {
            sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();
            if (e.State == RegState.Error)
            {
                sipClient.statusScreen.Text = "Registration failed: " + e.ReasonPhrase.ToString();
                logAdd("error", 1, "Registration Failed.");
                sipClient.Hide();
                errorModal("Registration failed: " + e.ReasonPhrase.ToString());
                Application.Exit();
            }
            else if (e.State == RegState.RegistrationRequested)
            {
                sipClient.statusScreen.Text = "Registering...";
                logAdd("", 1, "Registering...");
            }
            else if (e.State == RegState.RegistrationSucceeded)
            {
                sipClient.statusScreen.Text = "Registration success.";
                sipClient.phoneLine1.DoNotDisturb = true;
                //agentState.SelectedItem = "Logged In";
                sipClient.timer1.Enabled = true;
                sipClient.timer1.Start();
                logAdd("", 1, "Registration succesfully.");
            }
            else if (e.State == RegState.NotRegistered)
            {
                MessageBox.Show("Sunucu ile bağlantı koptu.");
            }        
        }

   
        internal static void activateDefaultVoiceDevices()
        {
            sipClient.connector.Connect(sipClient.mediaReceiver, sipClient.speaker);
            sipClient.connector.Connect(sipClient.microphone, sipClient.mediaSender);

            sipClient.mediaSender.AttachToCall(sipClient.call);
            sipClient.mediaReceiver.AttachToCall(sipClient.call);

            sipClient.microphone.Start();
            sipClient.speaker.Start();
            sipClient.microphone.Muted = false;
        }

        internal static void addCallToGrid()
        {
            sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();            
        }

        internal static void onMinimize()
        {
            sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();
            if (sipClient.WindowState == FormWindowState.Minimized)
            {
                //sipClientMin sipClientMin = new sipClientMin();
                //sipClientMin.Show();
                sipClient.Height = 180;
                Screen myScreen = Screen.PrimaryScreen;
                sipClient.Location = new Point(main.getStartPosition(sipClient.Width), myScreen.WorkingArea.Height - 500);
                sipClient.WindowState = FormWindowState.Normal;

            }

            if (sipClient.WindowState == FormWindowState.Maximized)
            {
                sipClientMin sipClientMin = new sipClientMin();
                sipClientMin.Hide();
            }
        }
     

        /*public static void getForm(string formName)
        {
            sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();
            if (sipClient != null)
                sipClient.Text = "Text Değişti";
        }*/

        public static void logAdd(string logType, int logLevel, string text) {
            sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();
            if (sipClient != null)
            {
                if (logType == "error")
                    text = text.ToUpper();
                if (logLevel == 2)
                    text = "--" + text;
                if (logLevel == 3)
                    text = "---" + text;

                sipClient.logs.Text += "[" + DateTime.Now.ToLongTimeString().ToString() + "] " + text + System.Environment.NewLine;
            }
        }

        public static void infoAdd(string field, string value)
        {
            sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();
            if (field == "skillName") {
                main.agentCurrentSkillName = value.ToString();
                sipClient.infoTable.Rows.Add(null, value);
            }           
        }

        public static string getPublicIP()
        {
            String direction = "";
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org/");
            using (WebResponse response = request.GetResponse())
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                direction = stream.ReadToEnd();
            }

            //Search for the ip in the html
            int first = direction.IndexOf("Address: ") + 9;
            int last = direction.LastIndexOf("</body>");
            direction = direction.Substring(first, last - first);

            return direction;
        }

        public static string getLocalIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        public static string base64Encode(string plainText, int second)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            string encoded = System.Convert.ToBase64String(plainTextBytes);
            byte[] ch = Encoding.ASCII.GetBytes(encoded);
            char newChar;
            string result = null;
            foreach (byte ascii in ch)
            {
                //MessageBox.Show(ascii.ToString());
                var encoded2 = (ascii) + second;
                newChar = (char)encoded2;
                result = string.Concat(result, newChar.ToString());
            }
            return result;
        }

        public static string base64Decode(string base64EncodedData, int second)
        {
            //MessageBox.Show("Encoded:" + base64EncodedData);
            byte[] ch = Encoding.ASCII.GetBytes(base64EncodedData);
            char newChar;
            string result = null;
            foreach (byte ascii in ch)
            {                
                var decoded2 = (ascii) - second;
                newChar = (char)decoded2;
                //MessageBox.Show(newChar.ToString());
                result = string.Concat(result, newChar.ToString());
            }
            //MessageBox.Show("Result1" + result);
            var base64EncodedBytes = System.Convert.FromBase64String(result);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);                        
        }

        public static string getMACAddress()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            } return sMacAddress;
        }

        public static string packUp(string[] args)
        {
            string str = "OK|";
            Random rand = new Random();
            int sec = rand.Next(1, 5);

            foreach (string value in args)
            {
                str += string.Concat(value, "|");
            }
            return base64Encode(base64Encode(str, sec), sec);
        }

        public static void errorModal(string message)
        {
            logAdd("error", 1, message);
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void infoModal(string message)
        {
            MessageBox.Show(message, "Jupiter - CCS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

  
    }
}
