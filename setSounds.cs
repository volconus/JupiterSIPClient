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
using Ozeki.VoIP;
using Ozeki.VoIP.SDK;
using Ozeki.VoIP.SIP;
using Ozeki.Media;
using Ozeki.Media.MediaHandlers;
using JupiterSIPClient1;
using JupiterSIPClient1.wsReference;
using System.Text.RegularExpressions;

namespace JupiterSIPClient1
{
    public partial class setSounds : Form
    {
        public JupiterWS jws = new JupiterWS();
        internal static int second = 0;    
        public setSounds()
        {
            InitializeComponent();
        }

        private void callWelcome_Load(object sender, EventArgs e)
        {
            sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();
            
            wsc.getAgentAnnounces();           
            
            ComboBox skills = sipClient.agentSkill;
            foreach (sipClient.ComboboxItem skill in skills.Items)
            {
                recordSkills.Items.Add(skill.Text);
            }

            Microphone.GetDevices().ForEach(delegate(Ozeki.Media.Audio.DeviceInfo mic) {
                mics.Items.Add(mic.ProductName);
                if (mic.ProductName == main.defMicrophone)
                    mics.SelectedItem = main.defMicrophone;
            });

            Speaker.GetDevices().ForEach(delegate(Ozeki.Media.Audio.DeviceInfo speaker)
            {
                speakers.Items.Add(speaker.ProductName);
                if (speaker.ProductName == main.defSpeaker)
                    speakers.SelectedItem = main.defSpeaker;
            });

            foreach (Ozeki.Media.Codec.CodecInfo codec in sipClient.softphone.Codecs)
            {
                audioCodecs.Items.Add(codec.CodecName);
                if (codec.CodecName == main.defAudioCodec)
                    audioCodecs.SelectedItem = main.defAudioCodec;

                videoCodecs.Items.Add(codec.CodecName);
                if (codec.CodecName == main.defVideoCodec)
                    videoCodecs.SelectedItem = main.defVideoCodec;
            }
            //sipClient.audioProcessor.AutoGainControl = true;
            
            //sipClient.audioProcessor.GainSpeed = ;
        }

        private void microphoneLevelChanged()
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (recordSkills.SelectedItem != null && newAnnounceName.Text != null)
            {
                bool match = Regex.IsMatch(newAnnounceName.Text, @"[A-Za-z0-9\-]$", RegexOptions.IgnoreCase);
	            if (match == false)
                {
                    main.errorModal("Anonsa vereceğiniz isim, sadece ingilizce alfabetik harfler ve rakamlar ile - (tire) işaretini içerebilir.");
                    return;
                }
                try
                {
                    sipClient.connector = new MediaConnector();
                    sipClient.microphone.Start();
                    sipClient.connector.Connect(sipClient.microphone, sipClient.mediaSender);

                    sipClient.speaker.Start();
                    sipClient.connector.Connect(sipClient.mediaReceiver, sipClient.speaker);

                    fileName.Text = string.Format("{0}-{1}-{2}.mp3", main.agentId, recordSkills.SelectedItem.ToString(), newAnnounceName.Text);
                    sipClient.mp3Recorder = new MP3StreamRecorder(main.announcePath + fileName.Text);

                    sipClient.connector.Connect(sipClient.microphone, sipClient.mp3Recorder);
                    sipClient.connector.Connect(sipClient.mediaReceiver, sipClient.mp3Recorder);

                    sipClient.mp3Recorder.Start();  // starts the recording

                    second = 0;
                    timer1.Enabled = true;
                    timer1.Start();
                }
                catch (Exception err) { main.errorModal(err.Message.ToString()); }
            }
            else {
                main.errorModal("Yeni bir anons oluşturmak için, bu anonsa bir isim vermeli ve bir skill seçmelisiniz.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            second += 1;
            timer1LabelHour.Text = (second / 3600).ToString("00");
            timer1LabelMin.Text = ((second % 3600) / 60).ToString("00");
            timer1LabelSec.Text = (second % 60).ToString("00");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();
                sipClient.mp3Recorder.Stop();
                sipClient.mp3Recorder.Dispose();
                timer1.Stop();                             
                if (File.Exists(main.announcePath + fileName.Text))
                {                                
                Byte[] bytes = File.ReadAllBytes(main.announcePath + fileName.Text);
                String file = Convert.ToBase64String(bytes);

                string[] package = {                                        
                                    sipClient.jwsSessionId,
                                    fileName.Text,
                                    newAnnounceName.Text,
                                    recordSkills.SelectedItem.ToString(),
                                    second.ToString(),
                                    main.agentId.ToString()
                               };

                var answer = jws.jAgentAddAnnounce(main.packUp(package), bytes);
                    if (answer.result == "OK")
                    {
                        second = 0; 
                        wsc.getAgentAnnounces();
                    }
                    else
                    {
                        main.errorModal("Error: " + answer.result);
                    }
            }   
        } catch (Exception err) { main.errorModal("Error: " + err.Message.ToString()); }
        }

        private void kaydıSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();
            
            if (announces.SelectedRows.Count >= 0) {
                if (MessageBox.Show("Seçili olan " + announces.SelectedRows.Count.ToString() + " karşılama anonsunu silmek istediğinize emin misiniz ?", "Emin misiniz ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) {
                    string allId = null;
                    foreach (DataGridViewRow row in announces.SelectedRows)
                    {
                        allId += row.Cells[0].Value.ToString() + ",";
                    }

                    string[] package = {
                                        sipClient.jwsSessionId,
                                        allId
                                       };
                    var answer = jws.jAgentRemoveAnnounce(main.packUp(package));
                    if (answer.result == "OK")
                    {
                        foreach (DataGridViewRow row in announces.SelectedRows)
                        {
                            if (File.Exists(main.announcePath + row.Cells[1].Value))
                            {                                
                                File.Delete(main.announcePath + row.Cells[1].Value);
                            }                                                        
                            announces.Rows.RemoveAt(row.Index);
                        }                        
                    }
                    else
                    {
                        main.errorModal(answer.reason);
                    }
                }
            }


        }

        private void devredışıBırakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (announces.SelectedRows.Count >= 0)
                {
                    if (MessageBox.Show("Seçili olan " + announces.SelectedRows.Count.ToString() + " karşılama anonsunu devredışı bırakmak istediğinize emin misiniz ?", "Emin misiniz ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();

                        string allId = null;
                        foreach (DataGridViewRow row in announces.SelectedRows)
                        {
                            allId += row.Cells[0].Value.ToString() + ",";
                        }

                        string[] package = {                                        
                                    sipClient.jwsSessionId,
                                    allId,
                                    "P"
                               };
                        var answer = jws.jAgentSetAnnounceState(main.packUp(package));
                        if (answer.result == "OK")
                        {
                            wsc.getAgentAnnounces();
                        }
                        else
                        {
                            main.errorModal("Error: " + answer.result);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                main.errorModal(err.Message.ToString());
            }
        }

        private void aktifEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
             try
            {
                if (announces.SelectedRows.Count >= 0)
                {
                    if (MessageBox.Show("Seçili olan " + announces.SelectedRows.Count.ToString() + " karşılama anonsunu aktif etmek istediğinize emin misiniz ?", "Emin misiniz ?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();

                        string allId = null;
                        foreach (DataGridViewRow row in announces.SelectedRows)
                        {
                            allId += row.Cells[0].Value.ToString() + ",";
                        }

                        string[] package = {                                        
                                    sipClient.jwsSessionId,
                                    allId,
                                    "A"
                               };
                        var answer = jws.jAgentSetAnnounceState(main.packUp(package));
                        if (answer.result == "OK")
                        {
                            wsc.getAgentAnnounces();
                        }
                        else
                        {
                            main.errorModal("Error: " + answer.result);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                main.errorModal(err.Message.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();

            if (mics.SelectedItem == null || speakers.SelectedItem == null || audioCodecs.SelectedItem == null || videoCodecs.SelectedItem == null)
            {
                main.errorModal("Tüm alanları (Mikrofon, Kulaklık, Ses ve Video codecleri dahil) eksiksiz doldurmalısınız.");
                return;
            }

             string[] package = {                                        
                                    sipClient.jwsSessionId,
                                    mics.SelectedItem.ToString(),
                                    speakers.SelectedItem.ToString(),
                                    audioCodecs.SelectedItem.ToString(),
                                    videoCodecs.SelectedItem.ToString(),
                               };
             
            
                var answer = jws.jAgentSetSoundOption(main.packUp(package));
                if (answer.result == "OK")
                {
                    main.defMicrophone = mics.SelectedItem.ToString();
                    main.defSpeaker = speakers.SelectedItem.ToString();
                    main.defAudioCodec = audioCodecs.SelectedItem.ToString();
                    main.defVideoCodec = videoCodecs.SelectedItem.ToString();
                    main.disableAllAudioCodecs();
                    main.disableAllVideoCodecs();
                    main.enableAudioCodec(audioCodecs.SelectedItem.ToString());
                    main.enableVideoCodec(videoCodecs.SelectedItem.ToString());
                    main.infoModal("Ses ayarlarınız başarıyla kaydedildi.");
                }
                else
                {
                    main.errorModal("Error: " + answer.result);
                }
        }

        private void records_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (File.Exists(main.announcePath + senderGrid.CurrentRow.Cells[1].Value))
                {
                    main.activateDefaultMP3Player(senderGrid.CurrentRow.Cells[1].Value.ToString());
                }
            }
        }

        private void setSounds_FormClosing(object sender, FormClosingEventArgs e)
        {

        }     
    }
}
