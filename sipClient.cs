using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ozeki.VoIP;
using Ozeki.VoIP.SDK;
using Ozeki.VoIP.SIP;
using Ozeki.Media;
using Ozeki.Media.MediaHandlers;
using JupiterSIPClient1.wsReference;
using System.Text.RegularExpressions;
using System.IO;
using Ozeki.VoIP.SIP.Logger;
using Ozeki.Common;

namespace JupiterSIPClient1
{
    public partial class sipClient : Form
    {
        main main = new main();
        settingSIP settingSIP = new settingSIP();
        internal JupiterWS jws = new JupiterWS();
        internal static ISoftPhone softphone;
        internal static IPhoneLine phoneLine1;  
        internal static IPhoneCall call;
        internal static Microphone microphone;
        internal static Speaker speaker;
        internal static MediaConnector connector;
        internal static PhoneCallAudioSender mediaSender;
        internal static PhoneCallAudioReceiver mediaReceiver;
        internal static MP3StreamPlayback mp3Player;
        internal static MP3StreamRecorder mp3Recorder;
        internal static SIP_CustomMessageManipulator sipMessageManipulator;
        internal static SIPMessageLogger sipMessageLogger;
        internal string jwsSessionId;

        public sipClient()
        {            
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {
            main.loadActions();
            wsc.getAgentAnnounceFiles();
        }

        private void InitializeSoftPhone()
        {
            MessageBox.Show("Yes");
        }


        private void call_CallStateChanged(object sender, CallStateChangedArgs e)
        {
            
            if (e.State == CallState.Ringing && cStateDirection.Text == "In")
                answerPanel.Visible = true;
            else
                answerPanel.Visible = false;
                
            if (e.State == CallState.Setup || e.State == CallState.Cancelled || e.State == CallState.Busy)
            {
                caller.Text = null;
                cState.Text = "Dialing";
                agentCurrentState.Text = "Dialing";
                main.resetTimer();
                infoTable.Rows.Clear();
                
            }
            else if (e.State == CallState.Ringing || e.State == CallState.RingingWithEarlyMedia)
            {
                cState.Text = "Ringing";
                agentCurrentState.Text = "Ringing";
                main.resetTimer();
                main.activateDefaultVoiceDevices();
            }
            else if (e.State == CallState.Answered)
            {
                // web browser event ?
                main.activateDefaultVoiceDevices();
            }
            else if (e.State == CallState.InCall)
            {
                cState.Text = "InCall";
                agentCurrentState.Text = "InCall";
                main.resetTimer();
            }
            else if (e.State == CallState.Completed)
            {
                caller.Text = null;
                cState.Text = "Available";
                agentCurrentState.Text = "Available";
                main.resetTimer();
                infoTable.Rows.Clear();
            }
            else if (e.State == CallState.LocalHeld)
            {
                cState.Text = "Hold";
                agentCurrentState.Text = "Hold";
                main.resetTimer();
            }
        }

        public void softphone_IncomingCall(object sender, VoIPEventArgs<IPhoneCall> e)
        {
            caller.Text = e.Item.DialInfo.CallerDisplay.ToString();
            call = e.Item;
            call.CallStateChanged += call_CallStateChanged;
            cStateDirection.Text = "In";
            main.agentCurrentFromNumber = e.Item.DialInfo.ToString();
        }
        public void sipMessageLogger_SIPMessageReceived(object sender, VoIPEventArgs<string> e)
        {
            MessageBox.Show("Trigger");
        }  

        private void dialButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (agentSkill.SelectedItem != null && agentCurrentState.Text == "Dialing")
                {
                    call = softphone.CreateCallObject(phoneLine1, to.Text);
                    call.CallStateChanged += call_CallStateChanged;
                    cStateDirection.Text = "Out";                    
                    call.Start();
                    main.activateDefaultVoiceDevices();
                    caller.Text = to.Text;
                }
                else {
                    DialogResult result = MessageBox.Show("Dış arama yaparken statünüzün Dialing olması ve dış arama için kullanacağınız skill'i seçmeniz gerekir.", "Dialing ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    if (result == DialogResult.Yes)
                    {                        
                        wsc.changeAgentState("Dialing", e);
                    }
                    else
                    {
                        main.errorModal("Dış arama yaparken statünüzün Dialing olması ve dış arama için kullanacağınız skill'i seçmeniz gerekir.");
                    }
                }
            }
            catch (Exception err) { main.errorModal("Çağrı başlatılamadı. Hata:" + err);  }
        }

        internal static void sipAccount_RegStateChanged(object sender, RegistrationStateChangedArgs e)
        {
            main.regStateChanged(e);
        }

        private void unRegisterSIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool result = main.unRegisterToSIP();
        }


        private void keysClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            to.Text += btn.Text;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            main.onMinimize();
        }

        private void hangupButton_Click(object sender, EventArgs e)
        {
            if (call != null) 
                call.HangUp();
        }



        private void holdButton_Click(object sender, EventArgs e)
        {
            if (call != null)  
                call.ToggleHold();
        }


        private void deleteKeyEvent(object sender, EventArgs e)
        {
            if (to.Text.Length > 0 && to.SelectedText.Length == 0)
                to.Text = to.Text.Remove(to.Text.Length - 1);
            else if (to.Text.Length > 0 && to.SelectedText.Length > 0)
                to.Text = "";
        }

        private void answerButton_Click(object sender, EventArgs e)
        {
            call.Answer();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            main.second += 1;
            timer1LabelHour.Text = (main.second / 3600).ToString("00");
            timer1LabelMin.Text = ((main.second % 3600) / 60).ToString("00");
            timer1LabelSec.Text = (main.second % 60).ToString("00");
        }

        private void transferButton_Click(object sender, EventArgs e)
        {
            if (call != null && !string.IsNullOrEmpty(to.Text))  
                call.BlindTransfer(to.Text);
        }



        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void registerSIPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main.registerToSIP();    
        }

        private void enterToLineButton_Click(object sender, EventArgs e)
        {            
            main.currentAgentState = 2;
            wsc.changeAgentState("Available", e);
        }

        private void sIPSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            settingSIP.ShowDialog();
        }

   

        public void agentState_SelectedIndexChanged(object sender, EventArgs e)
        {
            //main.infoModal(agentState.FindStringExact(agentState.SelectedItem.ToString()).ToString());            
            //main.changeAgentState();
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            wsc.getSkills(jwsSessionId, jws);
        }

        private void sipClient_Closing(object sender, FormClosingEventArgs e)
        {
            try
            {
                softphone.UnregisterPhoneLine(phoneLine1);                
                this.Dispose();
                Application.Exit();
            }
            catch {}
        }

        private void karşılamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setSounds callWelcome = new setSounds();
            callWelcome.ShowDialog();
        }

        private void rejectButton_Click(object sender, EventArgs e)
        {
            infoTable.Rows.Clear();
            call.Reject();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main.activateDefaultMP3Player("1-DIGITURK_IQ.mp3");
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            main.activateDefaultVoiceDevices();

            if (microphone.State == Ozeki.Media.Audio.CaptureState.Recording)
                MessageBox.Show("Mic started");
            else if (microphone.State == Ozeki.Media.Audio.CaptureState.Paused)
                MessageBox.Show("Mic Paused");
            else if (microphone.State == Ozeki.Media.Audio.CaptureState.Stopped)
                MessageBox.Show("Mic Stopped");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (microphone.Muted == true)
                microphone.Muted = false;
            else if (microphone.Muted == false)
                microphone.Muted = true;
        }

        private void announces_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (File.Exists(main.announcePath + senderGrid.CurrentRow.Cells[1].Value))
                {
                    MP3StreamPlayback mp3Player = new MP3StreamPlayback(main.announcePath + senderGrid.CurrentRow.Cells[1].Value);
                    sipClient.speaker.Start();
                    sipClient.connector.Connect(mp3Player, sipClient.speaker);
                    mp3Player.Start();
                }

            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }


    class SIP_CustomMessageManipulator : ISIPMessageManipulator    // the class to implement a custom message manipulator needs to use the ISIPMessageManipulator interface
    {
        public string ModifyIncomingMessage(MessageModifierInfo incomingMessageInfo)  // modifies the incoming SIP message, if set
        {
            MatchCollection matches = Regex.Matches(incomingMessageInfo.Message.ToString(), @"Jupiter-Data: (.*)\r\n");
            foreach (Match match in matches)
            {
                // skillId=1|Bok=ABC| diye geliyor
                string[] fields = match.ToString().Split('|');
                foreach (string field in fields)
                {
                    // skillId=1 kaldı sadece                    
                    string[] lastField = field.Split('=');                    
                    // lastField[0] = field, lastField[1] = value
                    try {
                        lastField[0] = lastField[0].Replace("Jupiter-Data: ", "");
                        main.logAdd(null, 2, lastField[0] + "===" + lastField[1]);
                        main.infoAdd(lastField[0], lastField[1]);
                    }
                    catch { } 
                    //infoTable.Items.Add("asd");
                }
                
            }            
            return incomingMessageInfo.Message; // gives back the message without any modification
        }

        public string ModifyOutgoingMessage(MessageModifierInfo outgoingMessageInfo)    // modifies the outgoing sip message, if set
        {
            outgoingMessageInfo.Message.Replace("Ozeki call v12.1.0", "Jupiter Single Call");
            outgoingMessageInfo.Message.Replace("Ozeki VoIP SIP SDK v12.1.0", "Jupiter CCS Agent UI v2.11.1");
            main.logAdd(null, 1, outgoingMessageInfo.Message);
            return outgoingMessageInfo.Message;   // modifies the message's part to the set string
        }

        public IEnumerable<PreparedExtensionHeader> PrepareAdditionalHeaders(MessageModifierInfo outgoingMessageInfo)   // you can add additional headers to the SIP message
        {            
            return null;    // no additional headers has been added to the sip message
        }
    }
}

