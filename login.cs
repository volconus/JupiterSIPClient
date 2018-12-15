using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;
using JupiterSIPClient1;
using JupiterSIPClient1.wsReference;

namespace JupiterSIPClient1
{
    public partial class login : Form
    {
        public JupiterWS jws = new JupiterWS();
        settingSIP settingSIP = new settingSIP();
        public login()
        {
            InitializeComponent();
        }
        
        private void login_Load(object sender, EventArgs e)
        {            
            localIp.Text = main.getLocalIP().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (validate.isEmail(username.Text) != true)
            {                
                main.errorModal("Kullanıcı adı hatalı. Kullanıcı adı şu formatta olmalı: isim@alanadi.com veya isim@alanadi gibi.");
                return;
            }            
            if (validate.notNull(password.Text) != true)
            {
                main.errorModal("Bir şifre yazmalısınız.");
                return;
            }
            string publicIp = wsc.getPublicIp();
            if (publicIp == "0")
            {
                main.errorModal("Public IP algılanamadı. Lütfen bir yetkiliyle ile görüşün.");
                return;
            }
            publicIpShow.Text = publicIp;

            try
            {
                string[] package = { 
                                       username.Text, 
                                       password.Text, 
                                       main.getMACAddress().ToString(), 
                                       main.getLocalIP().ToString(), 
                                       publicIp
                                   };
                var answer = jws.jAgentLogin(main.packUp(package));
                if (answer.result == "OK" && answer.sessionId.ToString().Length > 0)
                {
                    this.Hide();
                    var sipClient = new sipClient();
                    sipClient.jwsSessionId = answer.sessionId.ToString();
                    main.sipUserName = answer.sipUserName.ToString();
                    main.sipAuth = answer.sipAuth.ToString();
                    main.sipPassword = answer.sipPassword.ToString();
                    main.sipServerIp = answer.sipServerIp.ToString();
                    main.sipServerHostname = answer.sipServerHostname.ToString();
                    main.sipServerPort = answer.sipServerPort.ToString();
                    main.agentId = answer.agentId.ToString();
                    main.domainName = answer.domainName.ToString();
                    main.defMicrophone = answer.defMicrophone.ToString();
                    main.defSpeaker = answer.defSpeaker.ToString();
                    main.defAudioCodec = answer.defAudioCodec.ToString();
                    main.defVideoCodec = answer.defVideoCodec.ToString();
                    sipClient.Show();
                    sipClient.stationExt.Text = answer.sipUserName.ToString();
                    sipClient.domainName.Text = answer.domainName.ToString();
                    wsc.fillStates(answer.states);
                    wsc.fillSkills(answer.skills);
                }
                else
                {
                    main.errorModal("Login Error: " + answer.result);
                }
            }
            catch (Exception err) { main.errorModal("Login: " + err.Message.ToString()); }
                           
        }


        private void username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                password.Focus();
            }
        }

        private void password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                loginButton.Focus();
                button1_Click(sender, e);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
