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


namespace JupiterSIPClient1
{
    class wsc
    {
        internal static JupiterWS jws = new JupiterWS();
        public static void fillStates(string answerStates)
        { // buraya Mola|1;Yemek|2; şeklinde data geliyor answer.states içerisinde. Split edip kullanıyoruz.
            string[] states = answerStates.Split(';');
            int i = 0;
            main.logAdd("", 1, "Downloading States...");
            foreach (string state in states)
            {
                try
                {
                    string[] stateInfo = state.Split('|');
                    sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();
                    if (sipClient != null && stateInfo[0].Length > 0)
                    {
                        ToolStripItem subItem = new ToolStripMenuItem(stateInfo[0]);
                        subItem.Click += new EventHandler(changeAgentState);
                        sipClient.states.DropDownItems.Add(subItem);
                        //sipClient.states.DropDownItems[Convert.ToInt16(stateInfo[1])].Click += new EventHandler(changeAgentState);

                        main.logAdd("", 2, "New State: " + stateInfo[0]);
                        i++;
                    }
                    else if (sipClient == null)
                    {
                        main.errorModal("Form'a erişilemedi. Kaynak: fillStates");
                    }
                }
                catch (Exception e)
                {
                    main.logAdd("error", 1, e.Message.ToString());
                }
            }
            main.logAdd("", 1, "Downloaded States.");
        }

        public static void changeAgentState(object sender, EventArgs e)
        {
            sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();
            string newStateName = sender.ToString();
            if (newStateName == sipClient.agentCurrentState.Text)
                return;

            if (sipClient != null)
            {
                string[] package = {
                    sipClient.jwsSessionId, 
                    main.currentAgentState.ToString(),
                    newStateName
                };
                try
                {
                    var answer = sipClient.jws.jAgentChangeState(main.packUp(package));
                    if (answer.result == "OK")
                    {
                        sipClient.agentCurrentState.Text = newStateName;
                        main.logAdd("", 1, "Agent State Changed to " + newStateName);
                        main.resetTimer();
                        sipClient.enterToLinePanel.Hide();
                        if (sipClient.agentCurrentState.Text == "Logged In" && newStateName != "Available") // logged in -> otherBreak başka bir molaya falan geçiyor. avail olmayacak dnd den çıkmasın
                        {
                            sipClient.phoneLine1.DoNotDisturb = true;
                        }
                        if (newStateName == "Available") // -> available
                        {
                            sipClient.phoneLine1.DoNotDisturb = false;                            

                        }
                    }
                    else
                    {
                        main.errorModal(answer.reason);
                        return;
                    }
                }
                catch (Exception err)
                {
                    main.errorModal("Statü değiştirilemedi: " + err.Message.ToString());
                    return;
                }
            }
            else
            {
                main.errorModal("Form bulunamadi");
            }
        }

        internal static void getAgentAnnounces()
        {
            sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();
            setSounds setSounds = (from p in Application.OpenForms.OfType<setSounds>() select p).FirstOrDefault();
            if (setSounds != null)
                setSounds.announces.Rows.Clear();
            sipClient.announces.Rows.Clear();
            int i = 0;
            string[] package = {                                        
                                    sipClient.jwsSessionId
                               };
            try
            {
                var answer = jws.jAgentGetAnnounce(main.packUp(package));
                if (answer.result == "OK" && answer.records.ToString().Length > 0)
                {
                    
                    string[] fields = answer.records.ToString().Split(';');
                    foreach (string field in fields)
                    {
                        try
                        {
                            string[] datas = field.Split('|');
                            if (setSounds != null)
                                setSounds.announces.Rows.Insert(i, datas[0], datas[1], datas[2], datas[3], datas[4], datas[5], "Oynat");

                            sipClient.announces.Rows.Insert(i, datas[0], datas[1], datas[2], datas[3], "Oynat");
                            i++;
                        }
                        catch { }
                    }
                }
                else
                {
                    main.errorModal("Records Error: " + answer.result);
                }
            }
            catch { }
        }

        internal static void getAgentAnnounceFiles()
        {
            sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();
            string[] package = {                                        
                               sipClient.jwsSessionId
                               };
            try
            {
                var answer = jws.jAgentGetAnnounceFiles(main.packUp(package));
                if (answer.result == "OK" && answer.recordFile1 != null)
                {
                    System.IO.File.WriteAllBytes(main.announcePath + answer.recordFile1, answer.recordContent1);
                }
                if (answer.result == "OK" && answer.recordFile2 != null)
                {
                    System.IO.File.WriteAllBytes(main.announcePath + answer.recordFile2, answer.recordContent2);
                }
                if (answer.result == "OK" && answer.recordFile3 != null)
                {
                    System.IO.File.WriteAllBytes(main.announcePath + answer.recordFile3, answer.recordContent3);
                }
                if (answer.result == "OK" && answer.recordFile4 != null)
                {
                    System.IO.File.WriteAllBytes(main.announcePath + answer.recordFile4, answer.recordContent4);
                }
                if (answer.result == "OK" && answer.recordFile5 != null)
                {
                    System.IO.File.WriteAllBytes(main.announcePath + answer.recordFile5, answer.recordContent5);
                }
                if (answer.result == "OK" && answer.recordFile6 != null)
                {
                    System.IO.File.WriteAllBytes(main.announcePath + answer.recordFile6, answer.recordContent6);
                }
                if (answer.result == "OK" && answer.recordFile7 != null)
                {
                    System.IO.File.WriteAllBytes(main.announcePath + answer.recordFile7, answer.recordContent7);
                }
                if (answer.result == "OK" && answer.recordFile8 != null)
                {
                    System.IO.File.WriteAllBytes(main.announcePath + answer.recordFile8, answer.recordContent8);
                }
                if (answer.result == "OK" && answer.recordFile9 != null)
                {
                    System.IO.File.WriteAllBytes(main.announcePath + answer.recordFile9, answer.recordContent9);
                }
                if (answer.result == "OK" && answer.recordFile10 != null)
                {
                    System.IO.File.WriteAllBytes(main.announcePath + answer.recordFile10, answer.recordContent10);
                }

            }
            catch (Exception e) { main.errorModal("Announce: " + e.Message.ToString()); }
        }




        public static void fillSkills(string answerSkills)
        { // buraya Mola|1;Yemek|2; şeklinde data geliyor answer.skills içerisinde. Split edip kullanıyoruz.
            main.logAdd("", 1, "Downloading Skills...");
            string[] skills = answerSkills.Split(';');
            foreach (string skill in skills)
            {
                try
                {
                    string[] skillInfo = skill.Split('|');
                    sipClient sipClient = (from p in Application.OpenForms.OfType<sipClient>() select p).FirstOrDefault();
                    if (sipClient != null)
                    {
                        sipClient.ComboboxItem item = new sipClient.ComboboxItem();
                        item.Text = skillInfo[0];
                        item.Value = skillInfo[1];
                        sipClient.agentSkill.Items.Add(item);
                        main.logAdd("", 2, "New Skill: " + skillInfo[0]);
                    }
                    else
                        main.errorModal("Form'a erişilemedi. Kaynak: fillSkills");
                }
                catch (Exception e)
                {
                    main.logAdd("error", 1, e.Message.ToString());
                }
            }
            main.logAdd("", 1, "Downloaded Skills.");
        }


        public static void getSkills(string jwsSessionId, JupiterWS jws)
        {
            string[] package = { jwsSessionId };
            var answer = jws.jAgentGetStates(main.packUp(package));
            MessageBox.Show(answer.states.ToString());
        }

        public static string getPublicIp()
        {
            string[] package = { "1" };
            var answer = jws.jGetPublicIp(main.packUp(package));
            if (answer.result == "OK" && answer.publicIp.ToString().Length > 0)
            {
                return answer.publicIp.ToString();
            }
            else { return "0"; }
        }

    }
}
