using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace Frm_menu
{
    public partial class frm_menu : Form
    {
        static DataTable packets        = new DataTable();
        static DataTable guids          = new DataTable();
        static DataTable copiedPackets  = new DataTable();
        static DataSet pasteTable       = new DataSet();

        string creature_guid = "";
        string creature_entry = "";
        string creature_name = "";
        int smart_id = 0;
        string SQLtext = "";

        string current_pid = "";

        struct Packet
        {
            public string guid;
            public string entry;
            public string time;

            public string pid;
            public string opcode;
            public string name;
            public string content;

            public string[] values;
        }

        public frm_menu()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            InitializeComponent();
        }

        private void frm_menu_Load(object sender, EventArgs e)
        {
            //chart.BackColor = Properties.Settings.Default.BackColour;
            //chart.ChartAreas[0].BackColor = Properties.Settings.Default.BackColour;
        }

        private void frm_menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void smartAIWikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://collab.kpsn.org/display/tc/smart_scripts");
        }

        private void toolStripButtonLoadSniff_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Open File";
            openFileDialog.Filter = "Parsed Sniff File (*.txt)|*.txt";
            openFileDialog.FileName = "*.txt";
            openFileDialog.FilterIndex = 1;
            openFileDialog.ShowReadOnly = false;
            openFileDialog.Multiselect = false;
            openFileDialog.CheckFileExists = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadSniffFileIntoDatatable(openFileDialog.FileName);
                toolStripTextBoxEntry.Enabled = true;
                toolStripButtonSearch.Enabled = true;
                //toolStripStatusLabel.Text = openFileDialog.FileName + " is selected for input.";
            }
            else
            {
                // This code runs if the dialog was cancelled
                return;
            }
        }

        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string temp = "0";
                if (toolStripTextBoxEntry.Text == "" || toolStripTextBoxEntry.Text == null)
                {
                    FillListBoxWithGuids(temp);
                }
                else
                {
                    temp = toolStripTextBoxEntry.Text;
                    FillListBoxWithGuids(temp);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Please provide number or leave blank.", "Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void listBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            // On guid select fill grid and graph.
            if ((string)listBox.SelectedItem != "" && (string)listBox.SelectedItem != null)
            {
                FillGrid();
            }
        }

        public void LoadSniffFileIntoDatatable(string fileName)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(fileName);
            var line = file.ReadLine();
            file.Close();

            //if (line == "# TrinityCore - WowPacketParser")
            //{
                packets.Clear();
                packets = GetDataSourceFromSniffFile(fileName);
            //}
            //else
            //{
            //    MessageBox.Show(fileName + " is is not a valid TrinityCore parsed sniff file.", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            //}
        }

        public DataTable GetDataSourceFromSniffFile(string fileName)
        {
            // Clear old sniff displays
            //toolStripStatusLabel.Text = "Loading File...";
            listBox.DataSource = null;
            listBox.Refresh();
            gridPacket.Rows.Clear();
            //chart.Titles.Clear();
            //chart.Series.Clear();

            // Set cursor as hourglass
            this.Cursor = Cursors.WaitCursor;
            Application.DoEvents();

            var lines = File.ReadAllLines(fileName);

            DataTable dt = new DataTable("Packets");

            Packet packet;

            packet.entry = "";
            packet.guid = "";
            packet.time = "";

            packet.pid = "";
            packet.name = "";
            packet.opcode = "";
            packet.content = "";

            packet.values = new string[10];

            string[] columns = null;

            string col = "entry,guid,time,pid,name,opcode,content";
            columns = col.Split(new char[] { ',' });
            foreach (var column in columns)
                dt.Columns.Add(column);

            for (int i = 1; i < packet.values.Length - 1; ++i)
                dt.Columns.Add("value" + i);

            int pid = 0;

            // reading rest of the data
            for (int i = 1; i < lines.Count(); i++)
            {
                if (lines[i].Contains("ServerToClient:"))
                {
                    string[] values = lines[i].Split(new char[] { ' ' });
                    string[] time = values[9].Split(new char[] { '.' });

                    pid++;

                    packet.time = time[0];
                    packet.opcode = values[1];
                    packet.name = values[2];
                    packet.pid = pid.ToString();

                    do
                    {
                        i++;
                        packet.content += lines[i] + Environment.NewLine;

                        if (lines[i].Contains("GUID: Full:"))
                        {
                            if (lines[i].Contains("Player/0"))
                                continue;

                            if (lines[i].Contains("Creature"))
                            {
                                string[] packetline = lines[i].Split(new char[] { ' ' });
                                packet.entry = packetline[6];
                                packet.guid = packetline[8];
                            }
                        }

                        if (packet.opcode.Contains("SMSG_ON_MONSTER_MOVE"))
                        {
                            if (lines[i].Contains("Position: X:"))
                            {
                                string[] packetline = lines[i].Split(new char[] { ' ' });
                                packet.values[0] = packetline[2];
                                packet.values[1] = packetline[4];
                                packet.values[2] = packetline[6];
                                packet.values[3] = "0";
                            }

                            if (lines[i].Contains("Points: X:"))
                            {
                                string[] packetline = lines[i].Split(new char[] { ' ' });
                                packet.values[0] = packetline[5];
                                packet.values[1] = packetline[7];
                                packet.values[2] = packetline[9];
                                packet.values[3] = "0";
                            }

                            if (lines[i].Contains("FaceDirection:"))
                            {
                                string[] packetline = lines[i].Split(new char[] { ' ' });
                                packet.values[3] = packetline[3];
                            }

                            if (lines[i].Contains("WayPoints: X:"))
                            {
                                string[] packetline = lines[i].Split(new char[] { ' ' });
                                packet.values[0] = packetline[5];
                                packet.values[1] = packetline[7];
                                packet.values[2] = packetline[9];
                                packet.values[3] = "0";
                            }
                        }

                        if (packet.opcode.Contains("SMSG_PLAY_SOUND"))
                        {
                            if (lines[i].Contains("Sound Id:"))
                            {
                                string[] packetline = lines[i].Split(new char[] { ' ' });
                                packet.values[0] = packetline[2];
                            }
                        }

                        if (packet.opcode.Contains("SMSG_CHAT"))
                        {
                            if (lines[i].Contains("Type:") && !lines[i].Contains("GUID: Full:"))
                            {
                                string[] packetline = lines[i].Split(new char[] { ' ' });
                                packet.values[0] = packetline[2].Replace("(", string.Empty).Replace(")", string.Empty);
                            }

                            if (lines[i].Contains("Language:"))
                            {
                                string[] packetline = lines[i].Split(new char[] { ' ' });
                                packet.values[1] = packetline[2].Replace("(", string.Empty).Replace(")", string.Empty);
                            }

                            if (lines[i].Contains("Text:"))
                            {
                                packet.values[2] = lines[i].Remove(0, lines[i].IndexOf(' ') + 1);
                            }
                        }

                        if (packet.opcode.Contains("SMSG_EMOTE"))
                        {
                            if (lines[i].Contains("Emote ID:"))
                            {
                                string[] packetline = lines[i].Split(new char[] { ' ' });
                                packet.values[0] = packetline[2].Replace("(", string.Empty).Replace(")", string.Empty);
                            }
                        }

                    } while (lines[i] != "");

                    if (packet.entry != "")
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = packet.entry;
                        dr[1] = packet.guid;
                        dr[2] = packet.time;
                        dr[3] = packet.pid;
                        dr[4] = packet.opcode;
                        dr[5] = packet.name;
                        dr[6] = packet.content;

                        dr[7] = packet.values[0];
                        dr[8] = packet.values[1];
                        dr[9] = packet.values[2];
                        dr[10] = packet.values[3];

                        dt.Rows.Add(dr);
                    }

                    packet.content = "";
                    packet.entry = "";
                }
            }

            packet.entry = "";
            packet.content = "";
            this.Cursor = Cursors.Default;
            return dt;
        }

        public void FillListBoxWithGuids(string entry)
        {
            guids.Clear();
            guids = packets.DefaultView.ToTable(true, "guid", "entry");
            List<string> lst = new List<string>();

            foreach (DataRow r in guids.Rows)
            {
                string val = r["guid"].ToString();
                if (entry != "0")
                {
                    if (entry == r["entry"].ToString())
                        lst.Add(val.ToString());
                }
                else
                {
                    int n;
                    if (val != String.Empty && int.TryParse(val, out n))
                        lst.Add(r["guid"].ToString());
                }
            }

            lst.Sort();
            if (listBox.DataSource != lst)
                listBox.DataSource = lst;
            listBox.Refresh();
        }

        public void FillGrid()
        {
            creature_guid = (string)listBox.SelectedItem;
            copiedPackets = packets.Clone();

            foreach (DataRow row in packets.Rows)
            {
                if (row.Field<string>(1) == creature_guid)
                    copiedPackets.ImportRow(row);
            }

            creature_entry = copiedPackets.Rows[0].Field<string>(0);

            gridPacket.Rows.Clear();

            for (var l = 0; l < copiedPackets.Rows.Count; l++)
                gridPacket.Rows.Add(copiedPackets.Rows[l].Field<string>(3), copiedPackets.Rows[l].Field<string>(4), copiedPackets.Rows[l].Field<string>(5), copiedPackets.Rows[l].Field<string>(2), "");
        }

        public void FillPacketInfo()
        {
            current_pid = gridPacket.SelectedRows[0].Cells[0].Value.ToString();
            creature_guid = listBox.SelectedItem.ToString();
            copiedPackets.Clear();

            textBox.Clear();

            foreach (DataRow dr in packets.Rows)
            {
                if (dr.Field<string>(1) == creature_guid &&
                    dr.Field<string>(3) == current_pid)
                    copiedPackets.ImportRow(dr);
            }

            for (var l = 0; l < copiedPackets.Rows.Count; l++)
                textBox.AppendText(copiedPackets.Rows[l].Field<string>(6));
        }

        public void BuildMovementHeader()
        {
            //Send to SQL
            SQLtext = "-- Pathing for " + creature_name + " Entry: " + creature_entry + "\r\n" + "SET @NPC := XXXXXX;" + "\r\n" + "SET @PATH := @NPC * 10;" + "\r\n";
            SQLtext = SQLtext + "UPDATE `creature` SET `spawndist`=0,`MovementType`=2,`position_x`=" + copiedPackets.Rows[0].Field<string>(7) + ",`position_y`=" + copiedPackets.Rows[0].Field<string>(8)
                + ",`position_z`=" + copiedPackets.Rows[0].Field<string>(9) + " WHERE `guid`=@NPC;" + "\r\n";
            SQLtext = SQLtext + "DELETE FROM `creature_addon` WHERE `guid`=@NPC;" + "\r\n";
            SQLtext = SQLtext + "INSERT INTO `creature_addon` (`guid`,`path_id`,`mount`,`bytes1`,`bytes2`,`emote`,`auras`) VALUES (@NPC,@PATH,0,0,1,0, '');" + "\r\n";
            SQLtext = SQLtext + "DELETE FROM `waypoint_data` WHERE `id`=@PATH;" + "\r\n";
            SQLtext = SQLtext + "INSERT INTO `waypoint_data` (`id`,`point`,`position_x`,`position_y`,`position_z`,`orientation`,`delay`,`move_type`,`action`,`action_chance`,`wpguid`) VALUES" + "\r\n";
        }

        public void BuildMovement(int index)
        {
            string facing = copiedPackets.Rows[index].Field<string>(10);
            if (facing == "")
                facing = "0";

            string time = copiedPackets.Rows[index].Field<string>(2);
            //int nextTime = 0;
            //if (l != copiedPackets.Rows.Count - 1)
            //    nextTime = int.Parse(copiedPackets.Rows[l + 1].Field<string>(3));

            string waittime = ""; // (nextTime - int.Parse(time)).ToString();
            if (waittime == "")
                waittime = "0";

            SQLtext = SQLtext + "(@PATH," + index + ",";

            for (var ll = 7; ll < 10; ll++)
            {
                SQLtext = SQLtext + copiedPackets.Rows[index].Field<string>(ll) + ",";
            }

            if (index < (gridPacket.RowCount - 1))
            {
                SQLtext = SQLtext + facing + "," + waittime + ",0,0,100,0)," + " -- " + time + "\r\n";
            }
            else
            {
                SQLtext = SQLtext + facing + "," + waittime + ",0,0,100,0);" + " -- " + time + "\r\n";
            }
        }

        public void BuildSmartScriptHeader()
        {
            //Send to SQL
            SQLtext = SQLtext + "INSERT INTO `smart_scripts` (`entryorguid`, `source_type`, `id`, `link`, `event_type`, `event_phase_mask`, `event_chance`, `event_flags`, `event_param1`, `event_param2`, `event_param3`, `event_param4`, `action_type`, `action_param1`, `action_param2`, `action_param3`, `action_param4`, `action_param5`, `action_param6`, `target_type`, `target_param1`, `target_param2`, `target_param3`, `target_x`, `target_y`, `target_z`, `target_o`, `comment`) VALUES ";
            SQLtext = SQLtext + "(" + creature_entry + ", 0, ";
            //                                            source_type: 0 (Creature)
        }

        public void BuildPlaySound(int index)
        {
            BuildSmartScriptHeader();

            string soundId = copiedPackets.Rows[index].Field<string>(7);

            string time = copiedPackets.Rows[index].Field<string>(2);
            string nextTime = "";
            if (index != copiedPackets.Rows.Count - 1)
                nextTime = copiedPackets.Rows[index + 1].Field<string>(2);

            string waittime = getTimeDiff(time, nextTime).ToString();
            if (waittime == "")
                waittime = "0";

            SQLtext = SQLtext + smart_id + ", 0, 1, 0, 100, 0, 0, 0, " + waittime + ", " + waittime + ", 4, " + soundId + ", 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, '" + creature_name + " - " + "Out of Combat - Play Sound " + soundId + "');" + "\r\n";

            smart_id++;
        }

        public void BuildChatHeader()
        {
            //Send to SQL
            SQLtext = SQLtext + "SET @ENTRY" + smart_id + ":= XXXXXX;" + "\r\n";
            SQLtext = SQLtext + "DELETE FROM `creature_text` WHERE `entry`= @ENTRY" + smart_id + ";" + "\r\n";
            SQLtext = SQLtext + "INSERT INTO `creature_text` (`entry`, `groupid`, `id`, `text`, `type`, `language`, `probability`, `emote`, `duration`, `sound`, `BroadcastTextId`, `TextRange`, `comment`) VALUES (";
        }

        public void BuildChat(int index)
        {
            BuildChatHeader();

            string type = copiedPackets.Rows[index].Field<string>(7); // type
            string language = copiedPackets.Rows[index].Field<string>(8); // type
            string text = copiedPackets.Rows[index].Field<string>(9); // type
            string newText = text.Replace(@"'", @"\'");

            string time = copiedPackets.Rows[index].Field<string>(2);
            string nextTime = "";
            if (index != (copiedPackets.Rows.Count - 1))
                nextTime = copiedPackets.Rows[index + 1].Field<string>(2);

            string waittime = getTimeDiff(time, nextTime).ToString();
            if (waittime == "")
                waittime = "0";

            SQLtext = SQLtext + "@ENTRY" + smart_id + ", 0, 0, " + "'" + newText + "', " + type + ", " + language + ", 100, 0, 0, 0, 0, 0, '" + creature_name + "');\r\n";

            BuildSmartScriptHeader();
            SQLtext = SQLtext + smart_id + ", 0, 1, 0, 100, 0, 0, 0, " + waittime + ", " + waittime + ", 1, " + "@ENTRY" + smart_id + ", 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, '" + creature_name + " - Out of Combat - Say Line');" + "\r\n";

            smart_id++;
        }

        public void BuildEmote(int index)
        {
            BuildSmartScriptHeader();

            string emoteId = copiedPackets.Rows[index].Field<string>(7);

            string time = copiedPackets.Rows[index].Field<string>(2);
            string nextTime = "";
            if (index != (copiedPackets.Rows.Count - 1))
                nextTime = copiedPackets.Rows[index + 1].Field<string>(2);

            string waittime = getTimeDiff(time, nextTime).ToString();
            if (waittime == "")
                waittime = "0";

            SQLtext = SQLtext + smart_id + ", 0, 1, 0, 100, 0, 0, 0, " + waittime + ", " + waittime + ", 5, " + emoteId + ", 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, '" + creature_name + " - Out of Combat - Play Emote');" + "\r\n";
            smart_id++;
        }

        public int getTimeDiff(String currentTime, String nextTime)
        {
            string[] timeSplitCurrent = currentTime.Split(new char[] { ':' });
            int timeCurrentHoursInt = 0;
            int timeCurrentMinutesInt = 0;
            int timeCurrentSecondsInt = 0;
            int.TryParse(timeSplitCurrent[0], out timeCurrentHoursInt);
            int.TryParse(timeSplitCurrent[1], out timeCurrentMinutesInt);
            int.TryParse(timeSplitCurrent[2], out timeCurrentSecondsInt);

            int timeNextHoursInt = 0;
            int timeNextMinutesInt = 0;
            int timeNextSecondsInt = 0;
            if (string.IsNullOrEmpty(nextTime))
                return 0;
            else
            {
                string[] timeSplitNext = nextTime.Split(new char[] { ':' });
                int.TryParse(timeSplitNext[0], out timeNextHoursInt);
                int.TryParse(timeSplitNext[1], out timeNextMinutesInt);
                int.TryParse(timeSplitNext[2], out timeNextSecondsInt);
            }

            int currentTimeInMS = (timeCurrentHoursInt * 60 * 60 * 1000) + (timeCurrentMinutesInt * 60 * 1000) + (timeCurrentSecondsInt * 1000);
            int nextTimeInMS = (timeNextHoursInt * 60 * 60 * 1000) + (timeNextMinutesInt * 60 * 1000) + (timeNextSecondsInt * 1000);

            return Math.Abs(currentTimeInMS - nextTimeInMS);
        }

        private void createSQL_TDB()
        {
            if (listBox.SelectedItem == null)
                return;

            creature_guid = listBox.SelectedItem.ToString();

            copiedPackets.Clear();
            foreach (DataRow dr in packets.Rows)
            {
                if (dr.Field<string>(1) == creature_guid)
                    copiedPackets.ImportRow(dr);
            }

            textBox.Clear();
            SQLtext = "";
            smart_id = 0;

            bool containsMovement = false;
            for (var i = 0; i < copiedPackets.Rows.Count; i++)
            {
                if (copiedPackets.Rows[i].Field<string>(4).Contains("SMSG_ON_MONSTER_MOVE"))
                {
                    containsMovement = true;
                    break;
                }
            }

            // create movement header
            if (containsMovement)
                BuildMovementHeader();

            for (var i = 0; i < copiedPackets.Rows.Count; i++)
            {
                if (copiedPackets.Rows[i].Field<string>(4).Contains("SMSG_ON_MONSTER_MOVE"))
                    BuildMovement(i);
            }

            for (var i = 0; i < copiedPackets.Rows.Count; i++)
            {
                 if (copiedPackets.Rows[i].Field<string>(4).Contains("SMSG_PLAY_SOUND"))
                    BuildPlaySound(i);
                else if (copiedPackets.Rows[i].Field<string>(4).Contains("SMSG_CHAT"))
                    BuildChat(i);
                else if (copiedPackets.Rows[i].Field<string>(4).Contains("SMSG_EMOTE"))
                    BuildEmote(i);
            }

            textBox.Text = textBox.Text + SQLtext + "\r\n";
        }

        private void createSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createSQL_TDB();
        }

        private void gridPacket_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            FillPacketInfo();
        }
    }
}
