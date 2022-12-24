﻿using DiscordRpcDemo;
using FNAF_Engine_Reborn.bin;
using FNAF_Engine_Reborn.Main_Stuff;
using FNAF_Engine_Reborn.Object_Editors;
using FNAF_Engine_Reborn_GameData;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FNAF_Engine_Reborn
{
    public partial class reborn : Form
    {
        public GameData game;

        public bool showProject = true;
        public string Version = "0.9.7";
        public string Build_Version = "r97";
        public bool isopen = false;
        public bool draggable_ui = false;
        public bool animatronicselected = false;
        internal bool _0_2C = true;
        public bool inScriptEditor;
        string curMenuTag;
        public string script;
        public bool editable;

        public string style;

        private DiscordRpc.EventHandlers handlers = default(DiscordRpc.EventHandlers);
        private DiscordRpc.RichPresence presence;

        public bool DiscordRPCEnabled = false; //help

        internal static loadFERproject projectloader = new loadFERproject();

        public string projecto;

        private string v;

        public reborn()
        {
            InitializeComponent();
        }

        private void createFolder(string folder)
        {
            _ = Directory.CreateDirectory(projecto + folder);
        }
        public void GetFunctions(string v)
        {
            this.v = v;
        }
        private async void reborn_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;

            File.WriteAllText("DO_NOT_MODIFY.txt", "uncompressed_key=none");
#if DEBUG
            {
                //button67.Visible = true; //load editors button gets visible lol so useless
            }
#endif
            if (Version == "pre-1.0.0")
            {
                label93.Location = new Point(850, 1);
            }
            // else
            // {
            //     label93.Location = new Point(872, 1);
            // }

            this.Text = "FNAF Engine: Reborn";
            Random random = new Random();
            string[] randomStrings = { "Good Morning!", "You're Amazing!", "Reborn!", "Do you like cheese?", "Better late than never!", "Made by lily!", "I'm John!", "What's your name?", "Funny!", "Hmm hold on I'm thinking...", "Do you read these?", "Tons of effort!", "There's no limit!", "Was that an jojo reference?", "FE Was a blessing.", "How are you?", "Beatiful day outside!", "Feb 27 is an special day!", "Wow!", "Pigs :)", "69", "420", "Jokes!", "April Fools!", "Perhaps.", "According to Youtube's statistics, only a small percentage of people who watch my videos are actually subscribed,", "I won!", "FNF Engine?", "Wait what?", "For real!?", "For real?", "Did you do your homework yet?", "Do you love God?", "Check out FNAF Maker!", "Who's joe?", "Still beta!", "Yeah!", "Snow!" };
            label84.Text = randomStrings[random.Next(1, 38) - 1];

            if (DiscordRPCEnabled)
            {
                DiscordRpc.Initialize("970030742241439774", ref this.handlers, true, null);
                this.presence.details = "Version: " + Version;
                this.presence.state = "No project loaded";
                this.presence.largeImageKey = "1";
                this.presence.largeImageText = "Test";
                this.presence.smallImageText = "Test2";
                DiscordRpc.UpdatePresence(ref this.presence);
            }

            label93.Text = "Version: " + Version;
            label72.Text = "FE:R Build Version: \"" + Build_Version + "\"";

            while (draggable_ui == true)
            {
                await Task.Delay(1);
                foreach (Control control in this.Controls)
                {
                    if (control is Panel)
                    {
                        foreach (Control controls in control.Controls)
                        {
                            controls.Draggable(true);
                        }
                    }
                    control.Draggable(true);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            changelogs rebornChangelogs = new changelogs();
            rebornChangelogs.Show();
            Text = "FNAF Engine: Reborn - Changelogs";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createProject createNew = new createProject();
            _ = createNew.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            templateCreator templateMaker = new templateCreator();
            _ = templateMaker.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            createProject projectmaker = new createProject();
            projectmaker.Show();
        }

        private void createProjectBTN_MouseHover(object sender, EventArgs e)
        {
            bigProjectICON.BackColor = Color.FromArgb(39, 39, 39);
        }

        private void createProjectBTN_MouseLeave(object sender, EventArgs e)
        {
            bigProjectICON.BackColor = Color.FromArgb(34, 34, 34);
        }

        private void button43_Click(object sender, EventArgs e)
        {
            FNAF_Engine_Game theGameTest = new FNAF_Engine_Game(this);
            theGameTest.Show();
            Text = "FNAF Engine: Reborn - Testing Game";
        }

        private async void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                await Task.Delay(100);
                File.WriteAllText(projecto + "/game.txt", textBox6.Text);
            }
            else
            {

            }
        }

        private void button57_Click(object sender, EventArgs e)
        {
            _ = new FNAF_Engine_Game(this)
            {
                Text = textBox6.Text
            };
            textBox6.Text = textBox6.Text;
        }

        private void button60_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                if (comboBox43.SelectedItem == null)
                {
                    Logger.Log("Please select an animation!");
                }
                else
                {
                    Directory.Delete(comboBox43.SelectedItem?.ToString());
                    Logger.Log("Animation deleted!");
                    comboBox43.Items.Clear();
                    comboBox43.Items.AddRange(Directory.GetDirectories(projecto + "/animations/"));
                }
            }
            else
            {

            }
        }

        private void button61_Click(object sender, EventArgs e)
        {
            AnimAdd.Visible = true;
        }

        private void createSpritebtn_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                AnimAdd.Visible = false;
                if (spriteName.Text == "")
                {
                    Logger.Log("Please insert something in the name box!");
                }
                else
                {
                    string animName = spriteName.Text;
                    _ = Directory.CreateDirectory(projecto + "/animations/" + animName);
                    comboBox43.Items.Clear();
                    comboBox43.Items.AddRange(System.IO.Directory.GetDirectories(projecto + "/animations/"));
                }
            }
            else
            {

            }
        }

        private void createProjectBTN_Click(object sender, EventArgs e)
        {
            Text = "FNAF Engine: Reborn - Create Project";
            createProject projectMaker = new createProject();
            _ = projectMaker.ShowDialog();
        }

        private void loadProjectBTN_Click(object sender, EventArgs e)
        {
            Text = "FNAF Engine: Reborn - Load Project";
            loadFERproject projectLoader = new loadFERproject();
            _ = projectLoader.ShowDialog();
        }

        private void menu_Click(object sender, EventArgs e)
        {
            Text = "FNAF Engine: Reborn";
        }

        private void button66_Click(object sender, EventArgs e)
        {
            cutsceneMoment.Visible = true;
            menu.Hide();
        }

        private void playMusic(string musicS)
        {
            try
            {
                SoundPlayer music = new SoundPlayer("assets/music/" + musicS);
                music.Load();
                music.Play();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void stopMusic(string music)
        {
            System.Media.SoundPlayer musicP = new System.Media.SoundPlayer(@"assets/music/" + music);
            musicP.Stop();
        }

        private void cutsceneMoment_VisibleChanged(object sender, EventArgs e)
        {
            SoundPlayer music = new SoundPlayer(@"assets/music/fnaf_engine_reborn_credits.wav");
            music.Load();
            music.Play();
        }

        private void button67_Click(object sender, EventArgs e)
        {
            load_editors(projecto); //calls function below
        }

        public void load_editors(string projec) // loads all the editors, public so "loadFERproject.cs" can access and call this function. :)
        {
            //label108.Size = new Size(74, 60);
            //REBORNtitle.Location = new Point(-55, 1);
            //REBORNtitle.Size = new Size(1000, 60);
            menu.Hide();
            editable = true;
            Text = "FNAF Engine: Reborn";
            button38.Visible = true;
            //_ = projectloader.label3.Text;
            this.projecto = projec;
            if (showProject == true)
            {
                this.presence.state = "Project: " + File.ReadAllText(projecto + "/name.txt");
                if (DiscordRPCEnabled) DiscordRpc.UpdatePresence(ref this.presence);
            }
            else
            {
                //this.presence.state = "Version " + Version;
                //if (DiscordRPCEnabled) DiscordRpc.UpdatePresence(ref this.presence);
            }
            style = File.ReadAllText(v + "/style.txt");

        }

        public void j() //testing purposes
        {
            Console.WriteLine("testing purposes!");
        }

        private void AssetManagerPanel_Click(object sender, EventArgs e)
        {
            Text = "FNAF Engine: Reborn";
        }

        private void ProjectStuffs_Click(object sender, EventArgs e)
        {
            Text = "FNAF Engine: Reborn";
        }

        private void button75_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Show();
        }

        private void label108_Click(object sender, EventArgs e)
        {
            _ = System.Diagnostics.Process.Start("https://discord.gg/gGCdUpKDrW");
        }

        private void reborn_Click(object sender, EventArgs e)
        {
            Text = "FNAF Engine: Reborn";
        }

        private void menuEditorPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                //comboBox9.Items.Clear();
                if (Directory.Exists(projecto + "/menus"))
                {
                    //comboBox9.Items.AddRange(System.IO.Directory.GetDirectories(projecto + "/menus"));
                    UpdateMenuElements();
                }
                else
                {
                    _ = MessageBox.Show("Something went wrong! Fixing...");
                    createFolder(projecto + "/menus");
                    _ = MessageBox.Show("Fixed!");
                }
            }
            else
            {

            }
        }

        public void UpdateMenuElements()
        {
            Menus.Nodes.Clear();
            string[] dirs = Directory.GetDirectories(projecto + "/menus");
            foreach (string node in dirs)
            {
                string Name = File.ReadAllText(node + "/name.txt");
                TreeNode menu = new TreeNode
                {
                    Name = "Menu",
                    Text = Name,
                    ImageIndex = 0,
                    Tag = node
                };
                _ = Menus.Nodes.Add(menu);

                string[] texts = Directory.GetDirectories(projecto + "/menus/" + Name + "/text_elements");

                string[] images = Directory.GetDirectories(projecto + "/menus/" + Name + "/image_elements");

                foreach (string text in texts)
                {
                    string element_name = File.ReadAllText(text + "/id.txt");
                    if (File.ReadAllText(text + "/args.txt") == "False")
                    {
                        TreeNode element = new TreeNode
                        {
                            Name = "Text",
                            Text = element_name,
                            ImageIndex = 1,
                            SelectedImageIndex = 1
                        };
                        TreeNode[] Menus = this.Menus.Nodes.Find("Menu", true);
                        foreach (TreeNode Frame in Menus)
                        {
                            if (Frame.Tag.ToString() == node)
                            {
                                Frame.Nodes.Add(element);
                            }
                        }
                    }
                }

                foreach (string image in images)
                {
                    string element_name = File.ReadAllText(image + "/id.txt");
                    if (File.ReadAllText(image + "/args.txt") == "False")
                    {
                        TreeNode element = new TreeNode
                        {
                            Name = "Image",
                            Text = element_name,
                            ImageIndex = 2,
                            SelectedImageIndex = 2
                        };
                        TreeNode[] Menus = this.Menus.Nodes.Find("Menu", true);
                        foreach (TreeNode Frame in Menus)
                        {
                            if (Frame.Tag.ToString() == node)
                            {
                                Frame.Nodes.Add(element);
                            }
                        }
                    }
                }
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                createShit.Show();
            }
            else
            {

            }
        }

        private void minigameEditor_Click(object sender, EventArgs e)
        {
            MinigameMaker minigameMaker = new MinigameMaker();
            _ = minigameMaker.ShowDialog();
        }

        private void bigProjectICON_Click(object sender, EventArgs e)
        {
            Text = "FNAF Engine: Reborn - Create Project";
            createProject projectMaker = new createProject();
            _ = projectMaker.ShowDialog();
        }

        private void bigFolderICON_Click(object sender, EventArgs e)
        {
            Text = "FNAF Engine: Reborn - Load Project";
            loadFERproject projectLoader = new loadFERproject();
            _ = projectLoader.ShowDialog();
        }

        private void funTools_Click(object sender, EventArgs e)
        {
            templateCreator templateMaker = new templateCreator();
            _ = templateMaker.ShowDialog();
        }

        private void label87_Click(object sender, EventArgs e)
        {
            cutsceneMoment.Visible = true;
            menu.Hide();
        }

        private void button93_Click(object sender, EventArgs e)
        {
            menu.Show();
            cutsceneMoment.Visible = false;
        }

        private void label98_Click(object sender, EventArgs e)
        {
            MinigameMaker minigameMaker = new MinigameMaker();
            _ = minigameMaker.ShowDialog();
        }

        private void toolC_Click(object sender, EventArgs e)
        {
            templateCreator templateMaker = new templateCreator();
            _ = templateMaker.ShowDialog();
        }

        private void button38_Click(object sender, EventArgs e)
        {
            button38.Image = Image.FromFile(@"assets/images/johnBruh.png");
        }

        private void label166_Click(object sender, EventArgs e)
        {
            buildSettingsPanelMoment.BringToFront();
        }

        private async void label165_Click(object sender, EventArgs e)
        {
            if (editable == true)
            {
                if (_0_2C == true)
                {
                    try
                    {
                        if (Directory.Exists(projecto + "/animations"))
                        {
                            //aight
                        }
                        else
                        {
                            //_ = MessageBox.Show("Something went wrong!");
                            //_ = Directory.CreateDirectory(projecto + "/animations");
                            //_ = MessageBox.Show("Fixed!");
                        }
                        Sidebar.Show();
                        AssetManagerPanel.Show();
                        AssetManagerPanel.BringToFront();
                        Sidebar.BringToFront();
                        buildSettingsPanelMoment.Show();
                        SoundEditorPanel.Show();
                        menuEditorPanel.Show();
                        staticeffecteditor.Show();
                        GameDebugMenu.Show();
                        if (style == "standard")
                        {
                            //officeEditorPanel.Show();
                            //cameraEditorPanel.Show();
                            //ExtensionsPanel.Show();
                            //animationEditorPanel.Show();
                            //cutsceneEditorPanel.Show();
                            //ScriptEditorPanel.Show();
                            //animatronicEditorPNL2.Show();
                        }
                        else
                        {
                            officeEditorPanel.Show();
                            cameraEditorPanel.Show();
                            ExtensionsPanel.Show();
                            animationEditorPanel.Show();
                            cutsceneEditorPanel.Show();
                            ScriptEditorPanel.Show();
                            animatronicEditorPNL2.Show();
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            while (true)
            {
                await Task.Delay(1);
                Sidebar.BringToFront();
            }
        }

        private void label163_Click(object sender, EventArgs e)
        {
            animatronicEditorPNL2.BringToFront();
        }

        private void label162_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                if (Directory.Exists(projecto + "/cameras"))
                {
                    comboBox4.Items.Clear();
                    comboBox4.Items.AddRange(System.IO.Directory.GetDirectories(projecto + "/cameras/"));
                    cameraEditorPanel.BringToFront();
                }
                else
                {
                    createFolder("/cameras");
                    comboBox4.Items.Clear();
                    cameraEditorPanel.BringToFront();
                }
            }
            else
            {

            }
        }

        private void label164_Click(object sender, EventArgs e)
        {
            menuEditorPanel.Hide();
            menuEditorPanel.Show();
            menuEditorPanel.BringToFront();
        }

        private void label161_Click(object sender, EventArgs e)
        {
            officeEditorPanel.BringToFront();
        }

        private void label160_Click(object sender, EventArgs e)
        {
            animationEditorPanel.BringToFront();
        }

        private void label158_Click(object sender, EventArgs e)
        {
            cutsceneEditorPanel.BringToFront();
        }

        private void label157_Click(object sender, EventArgs e)
        {
            MinigameMaker minigameMaker = new MinigameMaker();
            _ = minigameMaker.ShowDialog();
        }

        private void label159_Click(object sender, EventArgs e)
        {
            ScriptEditorPanel.BringToFront();
        }

        private void label156_Click(object sender, EventArgs e)
        {
            SoundEditorPanel.BringToFront();
        }

        private void label91_Click_1(object sender, EventArgs e)
        {
            ExtensionsPanel.BringToFront();
        }

        private void button94_Click(object sender, EventArgs e)
        {
            extensionCreator extensionCreator = new extensionCreator();
            _ = extensionCreator.ShowDialog();
            Text = "FNAF Engine: Reborn - Custom Extensions";
        }

        private void AssetManagerPanel_VisibleChanged(object sender, EventArgs e)
        {
            plocation.Text = "Project Location: " + projecto;
            pname.Text = "Project Name: " + File.ReadAllText(projecto + "/name.txt");
            try
            {
                ptemplate.Text = "Project Template: " + File.ReadAllText(projecto + "/template.txt");
            }
            catch (Exception)
            {
                File.WriteAllText(projecto + "/template.txt", "None");
                ptemplate.Text = "Project Template: " + File.ReadAllText(projecto + "/template.txt");
            }

            if (style == "standard")
            {

            }
        }

        private void button95_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                _ = System.Diagnostics.Process.Start(projecto);
            }
            else
            {

            }
        }

        private void button96_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                if (Directory.Exists(projecto))
                {
                    _ = System.Diagnostics.Process.Start("explorer.exe", Application.StartupPath + projecto);
                }
                else
                {
                    Logger.Log("An error occured! Attempting to solve it...", "Error");
                    Logger.Log("Error solved!");
                    _ = System.Diagnostics.Process.Start("explorer.exe", Application.StartupPath + projecto);
                }
                try
                {
                    _ = System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = projecto,
                        UseShellExecute = true,
                        Verb = "open"
                    });
                }
                catch (Exception oh)
                {
                    Console.WriteLine("cringe exception: " + oh);
                }
            }
            else
            {

            }
        }

        private void button51_Click(object sender, EventArgs e)
        {
        }

        private void Corruption()
        {
            Logger.Log("Warning! With further examination, your project seems to be corrupted! Please join our Discord server and forward any issues you encounter!", "Fatal error");
        }

        private async void buildSettingsPanelMoment_VisibleChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                string optionstxt = File.ReadAllText(projecto + "/options.txt");
                string[] options = optionstxt.Split(',');
                _ = string.Join(",", options);
                if (File.Exists(projecto + "/options.txt"))
                {
                    checkBox8.Checked = options[0] == "fullscreen=true";
                    checkBox7.Checked = options[1] == "minigamesenabled=true";
                    checkBox10.Checked = options[2] == "watermarks=true";
                    checkBox9.Checked = options[3] == "sourcecode=true";
                }
                if (File.Exists(projecto + "/options.txt") == false)
                {
                    Logger.Log("Options are null. E729", "Fatal error");
                    _ = File.CreateText(projecto + "/options.txt");
                    Corruption();
                }
                if (File.Exists(projecto + "/game.txt") == true)
                {
                    await Task.Delay(100);
                    textBox6.Text = File.ReadAllText(projecto + "/game.txt");
                }
                else
                {
                    Logger.Log("ID is null. E745", "Fatal error");
                    _ = File.CreateText(projecto + "/game.txt");
                    Corruption();
                    textBox6.Text = File.ReadAllText(projecto + "/game.txt");
                }

                /*try
                {
                    label33.Image = Image.FromFile(projecto + "/images/icon.png");
                }
                catch (Exception)
                {
                    //uhm so you dont have the icon there, thats sad! letting the default one rn :)
                }*/
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                if (checkBox8.Checked == true)
                {
                    string optionstxt = File.ReadAllText(projecto + "/options.txt");
                    string[] options = optionstxt.Split(',');
                    options[0] = "fullscreen=true";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/options.txt", newoptions);
                }
                else
                {
                    string optionstxt = File.ReadAllText(projecto + "/options.txt");
                    string[] options = optionstxt.Split(',');
                    options[0] = "fullscreen=false";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/options.txt", newoptions);
                }
            }
        }

        private void deleteProjectBTN_Click(object sender, EventArgs e)
        {
            Deleteproject deleteproject = new Deleteproject();
            _ = deleteproject.ShowDialog();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                /*if (File.Exists(projecto + "/gameid.txt"))
                {
                    File.WriteAllText(projecto + "/gameid.txt", "");
                }
                else
                {
                    _ = MessageBox.Show("Something went wrong!, Fixing...");
                    _ = File.CreateText(project + "/gameid.txt");
                    _ = MessageBox.Show("Fixed!");
                    //textBox5.Text = File.ReadAllText(projecto + "/gameid.txt");
                }*/
            }
        }

        private void button88_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(menuName.Text))
                    {
                        Logger.Log("Please insert a name for your menu!", "Error");
                    }
                    else
                    {
                        string menuNam = menuName.Text;
                        _ = Directory.CreateDirectory(projecto + "/menus/" + menuNam);
                        _ = Directory.CreateDirectory(projecto + "/menus/" + menuNam + "/text_elements");
                        _ = Directory.CreateDirectory(projecto + "/menus/" + menuNam + "/image_elements");
                        _ = Directory.CreateDirectory(projecto + "/menus/" + menuNam + "/variables");
                        File.WriteAllText(projecto + "/menus/" + menuNam + "/name.txt", menuNam);
                        File.WriteAllText(projecto + "/menus/" + menuNam + "/ongameloop.txt", "");
                        File.WriteAllText(projecto + "/menus/" + menuNam + "/onmenustart.txt", "");
                        Menus.Nodes.Clear();
                        createShit.Hide();
                        menuEditorPanel.Hide();
                        menuEditorPanel.Show();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Cringe exception: " + ex);
                    Logger.Log("Special characters are not allowed!", "Error");
                }
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                if (Menus.SelectedNode == null)
                {
                    Logger.Log("Select a menu to delete!");
                }
                else
                {
                    DialogResult Confirmation = MessageBox.Show($"This can't be undone! Are you sure you want to delete the menu {Menus.SelectedNode.Text}?", "Menu Deletion", MessageBoxButtons.YesNo);

                    if (Confirmation == DialogResult.Yes)
                    {
                        Directory.Delete(curMenuTag, true);
                        Menus.Refresh();
                        menuEditorPanel.Hide();
                        menuEditorPanel.Show();
                    }
                }
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                comboBox4.Items.Clear();
                if (Directory.Exists(projecto + "/cameras"))
                {
                    panel6.Show();
                }
                else
                {
                    Logger.Log("Null cameras E876");
                    createFolder("/cameras");
                    panel6.Show();
                }
            }
            else
            {

            }
        }

        private void button57_Click_1(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                string cameraName = textBox17.Text;
                _ = Directory.CreateDirectory(projecto + "/cameras/" + cameraName);
                panel6.Hide();
                comboBox4.Items.Clear();
                comboBox4.Items.AddRange(System.IO.Directory.GetDirectories(projecto + "/cameras"));
                _ = Directory.CreateDirectory(projecto + "/cameras/" + cameraName + "/animations");
                //_ = File.CreateText("settings.txt");
            }
            else
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                if (comboBox4.SelectedItem == null)
                {
                    Logger.Log("Select a camera to delete!");
                }
                else
                {
                    Directory.Delete(comboBox4.SelectedItem.ToString());
                    comboBox4.Items.Clear();
                    comboBox4.Items.AddRange(System.IO.Directory.GetDirectories(projecto + "/cameras"));
                }
            }
            else
            {

            }
        }

        private void button99_Click(object sender, EventArgs e)
        {
            comboBox43.Items.Clear();
            comboBox43.Items.AddRange(Directory.GetDirectories(projecto + "/animations/"));
            Logger.Log("Updated!");
        }

        private void button62_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                //_ = listView1.Items.Add("frame2");
            }
            else
            {

            }
        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                if (checkBox13.Checked == true)
                {
                    CameraInput.Show();
                    string optionstxt = File.ReadAllText(projecto + "/offices/default/office.txt");
                    string[] options = optionstxt.Split(',');
                    options[3] = "camera=true";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/offices/default/office.txt", newoptions);
                }
                else
                {
                    CameraInput.Hide();
                    string optionstxt = File.ReadAllText(projecto + "/offices/default/office.txt");
                    string[] options = optionstxt.Split(',');
                    options[3] = "camera=false";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/offices/default/office.txt", newoptions);
                }
            }
        }

        private void button111_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                panel7.Show();
            }
            else
            {

            }
        }

        private void button112_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                string staticname = textBox20.Text;
                _ = Directory.CreateDirectory(projecto + "/statics/" + staticname);
                comboBox57.Items.Clear();
                comboBox57.Items.AddRange(System.IO.Directory.GetDirectories(projecto + "/statics"));
                panel7.Hide();
            }
            else
            {

            }
        }

        private void checkBox25_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox25.Checked == false)
            {
                DeleteFrameInfo_StaticEffectEditor.Show();
                StaticEffectEditor_addFrameInfo.Show();
                DeleteFrame_StaticEffectEditor.Show();
                AddFrame_StaticEffectEditor.Show();
                StaticEffectEditor_FrameList.Show();
            }
            else
            {
                DeleteFrameInfo_StaticEffectEditor.Hide();
                StaticEffectEditor_addFrameInfo.Hide();
                DeleteFrame_StaticEffectEditor.Hide();
                AddFrame_StaticEffectEditor.Hide();
                StaticEffectEditor_FrameList.Hide();
            }
        }

        private void label96_Click(object sender, EventArgs e)
        {
            staticeffecteditor.BringToFront();
        }

        private void button113_Click_1(object sender, EventArgs e)
        {
            if (Directory.Exists("assets/custom_assets/projects_cloud"))
            {

            }
        }

        private void exception(string ex)
        {
            throw new Exception(ex);
        }

        private void button91_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                panel8.Show();
            }
            else
            {

            }
        }

        private void button114_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                string animatronicName = textBox21.Text;
                try
                {
                    _ = Directory.CreateDirectory(projecto + "/animatronics/" + animatronicName);
                    File.WriteAllText(projecto + "/animatronics/" + animatronicName + "/jsound.fersound", "");
                    File.WriteAllText(projecto + "/animatronics/" + animatronicName + "/janimation.feranimation", "");
                    File.WriteAllText(projecto + "/animatronics/" + animatronicName + "/im.im", "false");
                    File.WriteAllText(projecto + "/animatronics/" + animatronicName + "/al.al", "false");
                    File.WriteAllText(projecto + "/animatronics/" + animatronicName + "/lbb.lbb", "false");
                    File.WriteAllText(projecto + "/animatronics/" + animatronicName + "/path.feranimpath", "");
                    BinaryWriter binWriter = new BinaryWriter(new FileStream(projecto + "/animatronics/" + animatronicName + "/path.feranimpath", FileMode.Open));
                    binWriter.Write(0);
                    binWriter.Flush();
                    binWriter.Dispose();
                    binWriter.Close();

                    if (checkBox2.Checked == true)
                    {
                        File.WriteAllText(projecto + "/animatronics/" + animatronicName + "/phantom.feranimext", "true");
                    }
                    else
                    {
                        File.WriteAllText(projecto + "/animatronics/" + animatronicName + "/phantom.feranimext", "false");
                    }
                    AnimatronicDropDown.Items.Clear();
                    AnimatronicDropDown.Items.AddRange(Directory.GetDirectories(projecto + "/animatronics/"));
                }
                catch (Exception)
                {
                    Logger.Log("Failed to create animatronic!", "Error");
                }
                finally
                {
                    panel8.Hide();
                }
            }
            else
            {

            }
        }

        private void button115_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                comboBox57.Items.Clear();
                comboBox57.Items.AddRange(Directory.GetDirectories(projecto + "/statics"));
            }
            else
            {

            }
        }

        private void button110_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                try
                {
                    Directory.Delete(projecto + "/statics/" + comboBox57.SelectedItem.ToString());
                    comboBox57.Items.Clear();
                    comboBox57.Items.AddRange(Directory.GetDirectories(projecto + "/statics"));
                }
                catch (Exception)
                {
                    Logger.Log("Failed to delete static effect", "Error 3");
                }
            }
            else
            {

            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                if (checkBox7.Checked == true)
                {
                    string optionstxt = File.ReadAllText(projecto + "/options.txt");
                    string[] options = optionstxt.Split(',');
                    options[1] = "minigamesenabled=true";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/options.txt", newoptions);
                }
                else
                {
                    string optionstxt = File.ReadAllText(projecto + "/options.txt");
                    string[] options = optionstxt.Split(',');
                    options[1] = "minigamesenabled=false";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/options.txt", newoptions);
                }
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                if (checkBox9.Checked == true)
                {
                    string optionstxt = File.ReadAllText(projecto + "/options.txt");
                    string[] options = optionstxt.Split(',');
                    options[3] = "sourcecode=true";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/options.txt", newoptions);
                }
                else
                {
                    string optionstxt = File.ReadAllText(projecto + "/options.txt");
                    string[] options = optionstxt.Split(',');
                    options[3] = "sourcecode=false";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/options.txt", newoptions);
                }
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                if (checkBox10.Checked == true)
                {
                    string optionstxt = File.ReadAllText(projecto + "/options.txt");
                    string[] options = optionstxt.Split(',');
                    options[2] = "watermarks=true";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/options.txt", newoptions);
                }
                else
                {
                    string optionstxt = File.ReadAllText(projecto + "/options.txt");
                    string[] options = optionstxt.Split(',');
                    options[2] = "watermarks=false";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/options.txt", newoptions);
                }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
            }
            else
            {

            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                if (checkBox4.Checked == true)
                {
                    string optionstxt = File.ReadAllText(projecto + "/options.txt");
                    string[] options = optionstxt.Split(',');
                    options[3] = "sourcecode=true";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/options.txt", newoptions);
                }
                else
                {
                    string optionstxt = File.ReadAllText(projecto + "/options.txt");
                    string[] options = optionstxt.Split(',');
                    options[3] = "sourcecode=false";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/options.txt", newoptions);
                }
            }
        }

        private void button92_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                Directory.Delete(AnimatronicDropDown.SelectedItem.ToString());
                AnimatronicDropDown.Items.Clear();
                AnimatronicDropDown.Items.AddRange(Directory.GetDirectories(projecto + "/animatronics"));
            }
            else
            {

            }
        }

        private void s() //function to enter the manual, i couldn't find a good name lol
        {
            if (isopen == false)//checks if the manual is already open, theres a bool up in the code for determining that. if manual is closed, open, if manual is open, do nothing since i only want it to open 1 time
            {
                manual form = new manual(); //determining manual form
                isopen = true; //it now tells the engine that manual is open
                form.Show(); //show manual
            }
            else
            {
                //uh it's open so do nothing
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {
            s(); // call function above ^^^^!
        }

        private void label21_Click(object sender, EventArgs e)
        {
            if (editable == true)
            {
                if (_0_2C == true)
                {
                    Compiler compiler = new Compiler(this, style, projecto);
                    _ = compiler.ShowDialog();
                    this.presence.details = "Compiling game...";
                    if (DiscordRPCEnabled) DiscordRpc.UpdatePresence(ref this.presence);
                }
            }
        }

        private void label94_Click(object sender, EventArgs e)
        {
            if (editable == true)
            {
                if (_0_2C == true)
                {
                    ReleaseOrDebug releaseordebug = new ReleaseOrDebug(this, style);
                    _ = releaseordebug.ShowDialog();
                    this.presence.details = "Testing game...";
                    if (DiscordRPCEnabled) DiscordRpc.UpdatePresence(ref this.presence);
                }
            }
        }

        private void button40_Click(object sender, EventArgs e) // add image
        {
            if (_0_2C == true)
            {
                OpenFileDialog p = new OpenFileDialog
                {
                    Filter = "Images (*.png)|*.png"
                };
                _ = p.ShowDialog();
                if (p.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = Path.GetFullPath(p.FileName);
                        string fileName = p.SafeFileName;
                        Import_Files.CreateSprite(filePath, fileName, projecto);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Cringe exception: " + ex);
                        Logger.Log("File already exists! If you want to overwrite it, select your image, delete it and insert again!");
                    }
                }
            }
            else
            {

            }
        }

        private void button39_Click(object sender, EventArgs e) // delete image
        {
        }

        private void button27_Click(object sender, EventArgs e) // add office state
        {
            panel9.Show();
        }

        private void button31_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                string officename = textBox25.Text;
                try
                {
                    _ = System.IO.Directory.CreateDirectory(projecto + "/offices/default/office_states/" + officename);
                    panel9.Hide();
                    comboBox17.Items.Clear();
                    comboBox17.Items.AddRange(Directory.GetDirectories(projecto + "/offices/default/office_states/"));
                }
                catch (Exception)
                {
                    Logger.Log("Special characters are not allowed!");
                }
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                try
                {
                    if (comboBox17.SelectedItem.Equals(projecto + "/offices/default/office_states/Default")) // if default office state selected, can't delete!
                                                                                                             // this is meant to avoid errors.
                    {
                        //yeah do nothing
                    }
                    else
                    {
                        Directory.Delete(comboBox17.SelectedItem.ToString(), true);
                        comboBox17.Items.Clear();
                        comboBox17.Items.AddRange(Directory.GetDirectories(projecto + "/offices/default/office_states/"));
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void button36_Click(object sender, EventArgs e) //set office state image
        {
            if (_0_2C == true)
            {
                if (comboBox17.SelectedItem == null)
                {

                }
                else
                {
                    try
                    {
                        OpenFileDialog p = new OpenFileDialog
                        {
                            Filter = "All Files (*.*)|*.*"
                        };
                        _ = p.ShowDialog();
                        if (p.ShowDialog() == DialogResult.OK)
                        {
                            string filePath = Path.GetFullPath(p.FileName);
                            string png = p.SafeFileName;
                            Import_Files.CreateSprite(filePath, png, projecto);
                            File.WriteAllText(comboBox17.SelectedItem.ToString() + "/mainsprite.txt", png);
                            officePreview.BackgroundImage = Image.FromFile(projecto + "/images/" + png);
                        }
                    }
                    catch (Exception)
                    {
                        //exception(ex.ToString());
                    }
                }
            }
        }

        private void comboBox17_SelectedIndexChanged(object sender, EventArgs e) //selected office state
        {
            if (_0_2C == true)
            {
                try
                {
                    string image = File.ReadAllText(comboBox17.SelectedItem.ToString() + "/mainsprite.txt");
                    var img = Image.FromFile(projecto + "/images/" + image);
                    if (img.Width <= 1280 && img.Height <= 720)
                    {
                        officePreview.BackgroundImageLayout = ImageLayout.Stretch;
                        officePreview.BackgroundImage = img;
                    }
                    else
                    {
                        if (checkBox24.Checked == false)
                        {
                            officePreview.BackgroundImageLayout = ImageLayout.Stretch;
                            officePreview.BackgroundImage = img;
                        }
                        else
                        {
                            officePreview.BackgroundImage = img;
                            officePreview.BackgroundImageLayout = ImageLayout.None;
                        }
                    }
                }
                catch (Exception)
                {
                    officePreview.BackgroundImage = null;
                }
            }
        }

        private async void officeEditorPanel_VisibleChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                Sprite amagos = new Sprite(this)
                {
                    project = projecto
                };
                amagos.Intiate();
                CameraAnim_ComboBox.Items.Clear();
                CameraAnim_ComboBox.Items.AddRange(Directory.GetDirectories(projecto + "/animations/"));
                MaskAnim_ComboBox.Items.Clear();
                MaskAnim_ComboBox.Items.AddRange(Directory.GetDirectories(projecto + "/animations/"));
                PowerOutAnim_ComboBox.Items.Clear();
                PowerOutAnim_ComboBox.Items.AddRange(Directory.GetDirectories(projecto + "/animations/"));
                comboBox14.Items.Clear();
                comboBox14.Items.AddRange(Directory.GetDirectories(projecto + "/animatronics"));
                comboBox17.Items.Clear();
                comboBox17.Items.AddRange(Directory.GetDirectories(projecto + "/offices/default/office_states/"));
                comboBox14.Items.Clear();
                comboBox14.Items.AddRange(Directory.GetDirectories(projecto + "/animatronics"));
                string optionstxt = File.ReadAllText(projecto + "/offices/default/office.txt");
                string[] options = optionstxt.Split(',');
                if (File.Exists(projecto + "/offices/default/office.txt"))
                {
                    checkBox16.Checked = options[0] == "power=true";
                    OfficeEditor_PowerThings.Visible = options[0] == "power=true";
                    checkBox12.Checked = options[1] == "toxic=true";
                    Toxic.Visible = options[1] == "toxic=true";
                    checkBox11.Checked = options[2] == "mask=true";
                    MaskInput.Visible = options[2] == "mask=true";
                    checkBox13.Checked = options[3] == "camera=true";
                    CameraInput.Visible = options[3] == "camera=true";
                    checkBox14.Checked = options[4] == "flashlight=true";
                    checkBox15.Checked = options[5] == "panorama=true";
                    //TODO PANORAMA
                    checkBox24.Checked = options[6] == "perspective=true";
                    if (checkBox24.Checked == false)
                    {
                        officePreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    }
                    else
                    {
                        officePreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                    }
                    checkBox17.Checked = options[7] == "ucnstyle=true";
                    gamehourstextbox.Text = options[9].Split('=')[1];
                    if (options[8] == "animatronic=")
                    {

                    }
                    else
                    {
                        _ = comboBox14.Controls.IndexOfKey(options[9]);
                    }
                }
                textBox7.Text = File.ReadAllText(projecto + "/offices/default/power_val.txt");
                try
                {
                    //GetPreviewSprites(p.SafeFileName);
                }
                catch (Exception)
                {

                }
                while (true)
                {
                    await Task.Delay(1);
                    OfficeEditor_PowerPercentage.Text = File.ReadAllText(projecto + "/offices/default/power_val.txt") + "%";
                }
            }
        }

        private void button33_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                OpenFileDialog p = new OpenFileDialog
                {
                    Filter = "Images (*.png)|*.png"
                };
                _ = p.ShowDialog();
                if (p.ShowDialog() == DialogResult.OK)
                {
                    Sprite s = new Sprite(this)
                    {
                        project = projecto
                    };
                    s.Add(p.SafeFileName, p.FileName);
                    s.Intiate();
                }
            }
        }

        private void createProjectBTN_Click_1(object sender, EventArgs e)
        {
            Text = "FNAF Engine: Reborn - Create Project";
            createProject projectMaker = new createProject();
            _ = projectMaker.ShowDialog();
        }

        private void label170_Click(object sender, EventArgs e)
        {
            Text = "FNAF Engine: Reborn - Create Project";
            createProject projectMaker = new createProject();
            _ = projectMaker.ShowDialog();
        }

        private void label171_Click(object sender, EventArgs e)
        {
            Text = "FNAF Engine: Reborn - Create Project";
            createProject projectMaker = new createProject();
            _ = projectMaker.ShowDialog();
        }

        private void label153_Click(object sender, EventArgs e)
        {
            Text = "FNAF Engine: Reborn - Load Project";
            loadFERproject projectLoader = new loadFERproject();
            _ = projectLoader.ShowDialog();
        }

        private void label154_Click(object sender, EventArgs e)
        {
            Text = "FNAF Engine: Reborn - Load Project";
            loadFERproject projectLoader = new loadFERproject();
            _ = projectLoader.ShowDialog();
        }

        private void label168_Click(object sender, EventArgs e)
        {
            Deleteproject deleteproject = new Deleteproject();
            _ = deleteproject.ShowDialog();
        }

        private void label169_Click(object sender, EventArgs e)
        {
            Deleteproject deleteproject = new Deleteproject();
            _ = deleteproject.ShowDialog();
        }

        private void label155_Click(object sender, EventArgs e)
        {
            templateCreator templateMaker = new templateCreator();
            _ = templateMaker.ShowDialog();
        }

        private void label167_Click(object sender, EventArgs e)
        {
            templateCreator templateMaker = new templateCreator();
            _ = templateMaker.ShowDialog();
        }

        private void label172_Click(object sender, EventArgs e)
        {
            cutsceneMoment.Visible = true;
            menu.Hide();
        }

        private void label173_Click(object sender, EventArgs e)
        {
            cutsceneMoment.Visible = true;
            menu.Hide();
        }

        private void checkBox16_CheckedChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                if (checkBox16.Checked == true)
                {
                    textBox7.Show();
                    powerPercentage_label.Show();
                    OfficeEditor_PowerThings.Show();
                    OfficeEditor_PowerThings.BringToFront();
                    string optionstxt = File.ReadAllText(projecto + "/offices/default/office.txt");
                    string[] options = optionstxt.Split(',');
                    options[0] = "power=true";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/offices/default/office.txt", newoptions);
                }
                else
                {
                    textBox7.Hide();
                    powerPercentage_label.Hide();
                    OfficeEditor_PowerThings.Hide();
                    string optionstxt = File.ReadAllText(projecto + "/offices/default/office.txt");
                    string[] options = optionstxt.Split(',');
                    options[0] = "power=false";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/offices/default/office.txt", newoptions);
                }
            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            if (comboBox17.SelectedItem == null)
            {

            }
            else
            {
                CreateDoorButton_OfficeEditor.Hide();
                CreateLightButton_OfficeEditor.Hide();
                button30.Hide();
                button33.Hide();
                CreatePanel_OfficeEditor.Hide();
                button37.Show();
                AnimationsOfficeEditor_CreateBox.Show();
            }
        }

        private void button37_Click(object sender, EventArgs e)
        {
            CreateDoorButton_OfficeEditor.Show();
            CreateLightButton_OfficeEditor.Show();
            button30.Show();
            button33.Show();
            CreatePanel_OfficeEditor.Show();
            button37.Hide();
            AnimationsOfficeEditor_CreateBox.Hide();
        }

        private void checkBox17_CheckedChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                if (checkBox17.Checked == true)
                {
                    displayOfficeEditorInfoAnimatronicKill.Hide();
                    comboBox14.Hide();
                    string optionstxt = File.ReadAllText(projecto + "/offices/default/office.txt");
                    string[] options = optionstxt.Split(',');
                    options[7] = "ucnstyle=true";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/offices/default/office.txt", newoptions);
                }
                else
                {
                    displayOfficeEditorInfoAnimatronicKill.Show();
                    comboBox14.Show();
                    string optionstxt = File.ReadAllText(projecto + "/offices/default/office.txt");
                    string[] options = optionstxt.Split(',');
                    options[7] = "ucnstyle=false";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/offices/default/office.txt", newoptions);
                }
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                if (checkBox12.Checked == true)
                {
                    string optionstxt = File.ReadAllText(projecto + "/offices/default/office.txt");
                    string[] options = optionstxt.Split(',');
                    options[1] = "toxic=true";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/offices/default/office.txt", newoptions);
                    Toxic.Show();
                }
                else
                {
                    string optionstxt = File.ReadAllText(projecto + "/offices/default/office.txt");
                    string[] options = optionstxt.Split(',');
                    options[1] = "toxic=false";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/offices/default/office.txt", newoptions);
                    Toxic.Hide();
                }
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                if (checkBox11.Checked == true)
                {
                    string optionstxt = File.ReadAllText(projecto + "/offices/default/office.txt");
                    string[] options = optionstxt.Split(',');
                    options[2] = "mask=true";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/offices/default/office.txt", newoptions);
                    MaskInput.Show();
                }
                else
                {
                    string optionstxt = File.ReadAllText(projecto + "/offices/default/office.txt");
                    string[] options = optionstxt.Split(',');
                    options[2] = "mask=false";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/offices/default/office.txt", newoptions);
                    MaskInput.Hide();
                }
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                if (checkBox14.Checked == true)
                {
                    string optionstxt = File.ReadAllText(projecto + "/offices/default/office.txt");
                    string[] options = optionstxt.Split(',');
                    options[4] = "flashlight=true";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/offices/default/office.txt", newoptions);
                }
                else
                {
                    string optionstxt = File.ReadAllText(projecto + "/offices/default/office.txt");
                    string[] options = optionstxt.Split(',');
                    options[4] = "flashlight=false";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/offices/default/office.txt", newoptions);
                }
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                if (checkBox15.Checked == true)
                {
                    string optionstxt = File.ReadAllText(projecto + "/offices/default/office.txt");
                    string[] options = optionstxt.Split(',');
                    options[5] = "panorama=true";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/offices/default/office.txt", newoptions);
                    //TODO PANORAMA
                }
                else
                {
                    string optionstxt = File.ReadAllText(projecto + "/offices/default/office.txt");
                    string[] options = optionstxt.Split(',');
                    options[5] = "panorama=false";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/offices/default/office.txt", newoptions);
                }
            }
        }

        private void checkBox24_CheckedChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                if (checkBox24.Checked == true)
                {
                    string optionstxt = File.ReadAllText(projecto + "/offices/default/office.txt");
                    string[] options = optionstxt.Split(',');
                    options[6] = "perspective=true";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/offices/default/office.txt", newoptions);
                    //OfficePreviewBG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                }
                else
                {
                    string optionstxt = File.ReadAllText(projecto + "/offices/default/office.txt");
                    string[] options = optionstxt.Split(',');
                    options[6] = "perspective=false";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/offices/default/office.txt", newoptions);
                    //OfficePreviewBG.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox7.Text) || textBox7.Text.Contains(" "))
            {
                textBox7.Text = "0";
            }
            File.WriteAllText(projecto + "/offices/default/power_val.txt", textBox7.Text);
        }

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                if (comboBox14.SelectedItem == null)
                {
                    string optionstxt = File.ReadAllText(projecto + "/offices/default/office.txt");
                    string[] options = optionstxt.Split(',');
                    options[8] = "animatronic=,";
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/offices/default/office.txt", newoptions);
                }
                else
                {
                    string optionstxt = File.ReadAllText(projecto + "/offices/default/office.txt");
                    string[] options = optionstxt.Split(',');
                    options[8] = "animatronic=," + comboBox14.Text;
                    string newoptions = string.Join(",", options);
                    File.WriteAllText(projecto + "/offices/default/office.txt", newoptions);
                }
            }
        }

        private void Code()
        {

        }
        private void label39_VisibleChanged(object sender, EventArgs e)
        {
            Code();
        }

        private void button42_Click(object sender, EventArgs e)
        {
            Code();
        }

        private void Offices_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Code();
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (Menus.SelectedNode.Name == "Text")
            {

            }
            else if (Menus.SelectedNode.Name == "Image")
            {

            }
            else if (Menus.SelectedNode.Name == "Menu")
            {
                this.curMenuTag = Menus.SelectedNode.Tag.ToString();
                this.presence.details = "Menu Editor, Editing Menu: " + File.ReadAllText(curMenuTag + "/name.txt");
                if (DiscordRPCEnabled) DiscordRpc.UpdatePresence(ref this.presence);
                Menu_Name_MenuCodeEditor_InfoLBL.Text = curMenuTag;
                Menu_Editor menu_Editor = new Menu_Editor(this);
                MenuPreview.Controls.Clear();
                Menu_Elements_Create.Hide();
                Menu_Elements_Create.Show();
                menu_Editor.RefreshElements(curMenuTag, projecto);
                if (File.Exists(curMenuTag + "/bg.txt"))
                {
                    MenuPreview.BackgroundImage = Image.FromFile(projecto + "/images/" + File.ReadAllText(curMenuTag + "/bg.txt"));
                    MenuPreview.Refresh();
                }
                if (File.Exists(curMenuTag + "/audio.txt"))
                {
                    try
                    {
                        FileInfo fileInfo = new FileInfo(File.ReadAllText(curMenuTag + "/audio.txt"));
                        string name = fileInfo.Name;
                        BackgroundAudio_MenuEditor.SelectedItem = name;
                    }
                    catch (Exception)
                    {
                        Logger.Log("Unable to load menu background: Invalid Image", "Corrupted Image");
                    }
                }
                else
                {

                }
            }
        }

        private void label119_Click(object sender, EventArgs e)
        {
            if (editable == true)
            {
                GameDebugMenu.BringToFront();
                //this.presence.details = "Debugging game...";
                //if (DiscordRPCEnabled) DiscordRpc.UpdatePresence(ref this.presence);
            }
        }

        private void staticeffecteditor_VisibleChanged(object sender, EventArgs e)
        {
            AnimationList_StaticEffectEditor.Items.Clear();
            AnimationList_StaticEffectEditor.Items.AddRange(System.IO.Directory.GetDirectories(projecto + "/animations"));
        }

        private void panel4_VisibleChanged(object sender, EventArgs e)
        {
            _ = ScriptEditor_Scripts_ComboBox.SelectedItem.ToString();
        }

        private void button52_Click(object sender, EventArgs e)
        {
            PanelCreatingNewScript.Show();
        }

        private void CreateScript_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                string Name = ScriptEditor_TextBoxname.Text;
                ScriptEditor scriptEditor = new ScriptEditor
                {
                    Project = projecto
                };
                scriptEditor.CreateScript(Name);
                ScriptEditor_Scripts_ComboBox.Items.Clear();
                ScriptEditor_Scripts_ComboBox.Items.AddRange(Directory.GetDirectories(projecto + "/scripts/visual/"));
                PanelCreatingNewScript.Hide();
            }
        }

        private void ScriptEditorPanel_VisibleChanged(object sender, EventArgs e)
        {
            ScriptEditor_Scripts_ComboBox.Items.Clear();
            ScriptEditor_Scripts_ComboBox.Items.AddRange(Directory.GetDirectories(projecto + "/scripts/visual/"));
        }
        private void GetEvent()
        {

        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                try
                {
                    string script = ScriptEditor_Scripts_ComboBox.SelectedItem.ToString();
                    ScriptEditor scripteditor = new ScriptEditor();
                    panel4.Show();
                    if (File.Exists(script + "/event.txt"))
                    {
                        if (scripteditor.HasEvent(script))
                        {
                            string event_ = scripteditor.ToEvent(script);
                            button25.Show();
                            button25.Text = event_;
                            button26.Show();
                        }
                        else
                        {
                            button25.Hide();
                            button26.Hide();
                            button10.Show();
                        }
                    }
                    else
                    {
                        button25.Hide();
                        button26.Hide();
                        button10.Show();
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                script = ScriptEditor_Scripts_ComboBox.SelectedItem.ToString();
                CodeblockSelector selector = new CodeblockSelector(this);
                selector.eventr = true;
                _ = selector.ShowDialog();
            }
        }

        private void button25_MouseClick(object sender, MouseEventArgs e)
        {
            if (_0_2C == true)
            {
                if (e.Button == MouseButtons.Right)
                {
                    CodeblockSelector codeblockselector = new CodeblockSelector(this)
                    {
                        Path = ScriptEditor_Scripts_ComboBox.SelectedItem.ToString()
                    };
                    _ = codeblockselector.ShowDialog();
                }
            }
        }

        private void create_text_menuEditorBTN_Click(object sender, EventArgs e)
        {
            Menu_Editor menu_Editor = new Menu_Editor(this);
            if (Directory.Exists(projecto + "/menus/" + text_ID_MenuEditor_Create))
            {
                _ = MessageBox.Show("Unable to create new text element: Error 1");
            }
            else
            {
                string id = text_ID_MenuEditor_Create.Text;
                menu_Editor.CreateText(id, Menu_Name_MenuCodeEditor_InfoLBL.Text);
                menu_Editor.RefreshElements(curMenuTag, projecto);
                textCreate_MenuEditor.Hide();
                UpdateMenuElements();
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                script = ScriptEditor_Scripts_ComboBox.SelectedItem.ToString();
                CodeblockSelector selector = new CodeblockSelector(this);
                selector.eventr = true;
                _ = selector.ShowDialog();
            }
        }

        private void button125_Click(object sender, EventArgs e)
        {
            textCreate_MenuEditor.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                OpenFileDialog p = new OpenFileDialog
                {
                    Filter = "Images (*.png)|*.png"
                };
                _ = p.ShowDialog();
                if (p.ShowDialog() == DialogResult.OK)
                {
                    string FileName = p.SafeFileName;
                    Import_Files.CreateSprite(p.FileName, FileName, projecto);
                    File.WriteAllText(curMenuTag + "/bg.txt", FileName);
                    MenuPreview.BackgroundImage = Image.FromFile(projecto + "/images/" + File.ReadAllText(curMenuTag + "/bg.txt"));
                }
            }
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox30_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cutsceneMoment_VisibleChanged_1(object sender, EventArgs e)
        {

        }

        private void animationEditorPanel_VisibleChanged(object sender, EventArgs e)
        {
            comboBox43.Items.Clear();
            comboBox43.Items.AddRange(System.IO.Directory.GetDirectories(projecto + "/animations/"));
        }

        private void GameManager_Variables_View_VisibleChanged(object sender, EventArgs e)
        {
            //DataValues.Project = projecto;
            //DataValues.Engine = this;
            //DataValues.RefreshDataValues();
        }

        private void addDataValue_GameManager_Click(object sender, EventArgs e)
        {
            if (DataValue_Name.Visible == false)
            {
                DataValue_Name.Show();
            }
            else
            {
                DataValue_Name.Text = DataValue_Name.Text.Replace(":", "");
                //DataValues.CreateDataValue(DataValue_Name.Text);
                //DataValues.RefreshDataValues();
                DataValue_Name.Hide();
            }
        }

        private void reassignDataValue_GameManager_Click(object sender, EventArgs e)
        {
            reassign_Value_GameManager_Textbox.Text = reassign_Value_GameManager_Textbox.Text.Replace(":", "");
            if (reassign_Value_GameManager_Textbox.Visible == false)
            {
                object tag = "Data_Values_List";
                if (GameManager_Variables_View.SelectedNode == null || GameManager_Variables_View.SelectedNode.Tag == tag || GameManager_Variables_View.SelectedNode.Name == "value")
                {
                    Logger.Log("Please select a data value to change the value!");
                }
                else
                {
                    reassign_Value_GameManager_Textbox.Show();
                }
            }
            else
            {
                string DataValue = GameManager_Variables_View.SelectedNode.Name;
                string Value = reassign_Value_GameManager_Textbox.Text;
                //var old = DataValues.GetDataValue(DataValue);
                //DataValues.ReassignDataValue(DataValue, old, Value);
                //DataValues.RefreshDataValues();
                reassign_Value_GameManager_Textbox.Hide();
            }
        }

        private void menu_Paint(object sender, PaintEventArgs e)
        {

        }
        private void GameDebugMenu_VisibleChanged(object sender, EventArgs e)
        {
            DataValuesFileLabel.Draggable(true);
            DataValuesFileLabel.Text = File.ReadAllText(projecto + "/data.txt");
        }

        private void MenuEditor_ScriptEditor_Click(object sender, EventArgs e)
        {
            if (curMenuTag != null)
            {
                Menu_CodeEditor.Show();
                Menu_CodeEditor.BringToFront();
            }
        }

        private void X_Leave_MenuCodeEditor_Click(object sender, EventArgs e)
        {
            Menu_CodeEditor.Hide();
        }

        private void Menu_CodeEditor_VisibleChanged(object sender, EventArgs e)
        {
            //MenuCodeEditor_Code_Tree.Nodes.
        }


        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {

        }

        private async void label29_Click(object sender, EventArgs e)
        {
            if (editable == true)
            {
                if (_0_2C == true)
                {
                    try
                    {
                        //Startup
                        //this.presence.details = "Editing game...";
                        //if (DiscordRPCEnabled) DiscordRpc.UpdatePresence(ref this.presence);
                        if (Directory.Exists(projecto + "/animations"))
                        {
                            //aight
                        }
                        else
                        {
                            //_ = MessageBox.Show("Something went wrong!");
                            //_ = Directory.CreateDirectory(projecto + "/animations");
                            //_ = MessageBox.Show("Fixed!");
                        }
                        Sidebar.Show();
                        AssetManagerPanel.Show();
                        AssetManagerPanel.BringToFront();
                        Sidebar.BringToFront();
                        buildSettingsPanelMoment.Show();
                        SoundEditorPanel.Show();
                        menuEditorPanel.Show();
                        staticeffecteditor.Show();
                        GameDebugMenu.Show();
                        if (style == "standard")
                        {
                            //officeEditorPanel.Show();
                            //cameraEditorPanel.Show();
                            //ExtensionsPanel.Show();
                            //animationEditorPanel.Show();
                            //cutsceneEditorPanel.Show();
                            //ScriptEditorPanel.Show();
                            //animatronicEditorPNL2.Show();
                        }
                        else
                        {
                            officeEditorPanel.Show();
                            cameraEditorPanel.Show();
                            ExtensionsPanel.Show();
                            animationEditorPanel.Show();
                            cutsceneEditorPanel.Show();
                            ScriptEditorPanel.Show();
                            animatronicEditorPNL2.Show();
                        }
                    }
                    catch (Exception) //It's okay
                    {

                    }
                }
            }
            while (true)
            {
                await Task.Delay(1);
                Sidebar.BringToFront();
            }
        }

        private void label124_Click(object sender, EventArgs e)
        {
            if (editable == true)
            {
                GameDebugMenu.BringToFront();
                //this.presence.details = "Debugging game...";
                //if (DiscordRPCEnabled) DiscordRpc.UpdatePresence(ref this.presence);
            }
        }

        private void label143_Click(object sender, EventArgs e)
        {
            if (editable == true)
            {
                if (_0_2C == true)
                {
                    ReleaseOrDebug releaseordebug = new ReleaseOrDebug(this, style);
                    _ = releaseordebug.ShowDialog();
                    //this.presence.details = "Testing game...";
                    //if (DiscordRPCEnabled) DiscordRpc.UpdatePresence(ref this.presence);
                }
            }
        }

        private void label83_Click(object sender, EventArgs e)
        {
            if (editable == true)
            {
                if (_0_2C == true)
                {
                    Compiler compiler = new Compiler(this, style, projecto);
                    _ = compiler.ShowDialog();
                    //this.presence.details = "Compiling game...";
                    //if (DiscordRPCEnabled) DiscordRpc.UpdatePresence(ref this.presence);
                }
            }
        }

        private void gamehourstextbox_TextChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                string optionstxt = File.ReadAllText(projecto + "/offices/default/office.txt");
                string[] options = optionstxt.Split(',');
                options[9] = "hours=" + gamehourstextbox.Text;
                string newoptions = string.Join(",", options);
                File.WriteAllText(projecto + "/offices/default/office.txt", newoptions);
            }
        }
        private void AddImage_MenuEditor_Click(object sender, EventArgs e)
        {
            OpenFileDialog icon = new OpenFileDialog
            {
                Filter = "Images (*.png)|*.png"
            };
            _ = icon.ShowDialog();
            if (icon.ShowDialog() == DialogResult.OK)
            {
                string filePath = icon.FileName;
                Menu_Editor menu_Editor = new Menu_Editor(this);
                if (Directory.Exists(projecto + "/menus/" + text_ID_MenuEditor_Create))
                {
                    Logger.Log("Unable to create new image element", "Error 1");
                }
                else
                {
                    string id = icon.SafeFileName;
                    menu_Editor.CreateImage(id, Menu_Name_MenuCodeEditor_InfoLBL.Text, filePath, projecto);
                    menu_Editor.RefreshElements(curMenuTag, projecto);
                    textCreate_MenuEditor.Hide();
                    menuEditorPanel.Hide();
                    menuEditorPanel.Show();
                }
            }
        }

        private void text_ID_MenuEditor_Create_TextChanged(object sender, EventArgs e)
        {
            text_ID_MenuEditor_Create.Text = text_ID_MenuEditor_Create.Text.Replace(" ", "");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                OpenFileDialog p = new OpenFileDialog
                {
                    Filter = "Audio (*.mp3;*.wav;*.ogg)|*.mp3;*.wav;*.ogg"
                };
                _ = p.ShowDialog();
                if (p.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filePath = Path.GetFullPath(p.FileName);
                        string fileName = p.SafeFileName;
                        Import_Files.CreateAudio(filePath, projecto);
                        Menu_Elements_Create.Show();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Cringe exception: " + ex);
                        Logger.Log("File already exists! If you want to overwrite it, select your image, delete it and insert again!");
                    }
                }
            }
            else
            {

            }
        }

        private void Menu_Elements_Create_VisibleChanged(object sender, EventArgs e)
        {
            var audios = Directory.GetFiles(projecto + "/sounds/");
            string fileName;
            foreach (string audio in audios)
            {
                FileInfo fileInfo = new FileInfo(audio);
                fileName = fileInfo.Name;
                BackgroundAudio_MenuEditor.Items.Add(fileName);
            }
        }

        private void BackgroundAudio_MenuEditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Menus.SelectedNode == null)
            {

            }
            else
            {
                //yoo its a menu
                //or is it
                if (Menus.SelectedNode.Name == "Menu")
                {
                    //it is!
                    //lets set the audio
                    File.WriteAllText(Menus.SelectedNode.Tag + "/audio.txt", projecto + "/sounds/" + BackgroundAudio_MenuEditor.SelectedItem.ToString());
                }
            }
        }

        private void animatronicEditorIgnoresMask_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (animatronicselected == true)
            {
                if (animatronicEditorIgnoresMask_Check.Checked == true)
                {
                    File.WriteAllText(AnimatronicDropDown.SelectedItem.ToString() + "/im.im", "true");
                }
                else
                {
                    File.WriteAllText(AnimatronicDropDown.SelectedItem.ToString() + "/im.im", "false");
                }
            }
        }

        private void animatronicEditorAudioLured_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (animatronicselected == true)
            {
                if (animatronicEditorAudioLured_Check.Checked == true)
                {
                    File.WriteAllText(AnimatronicDropDown.SelectedItem.ToString() + "/al.al", "true");
                }
                else
                {
                    File.WriteAllText(AnimatronicDropDown.SelectedItem.ToString() + "/al.al", "false");
                }
            }
        }

        private void animatronicEditorLikeBB_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (animatronicselected == true)
            {
                if (animatronicEditorLikeBB_Check.Checked == true)
                {
                    File.WriteAllText(AnimatronicDropDown.SelectedItem.ToString() + "/lbb.lbb", "true");
                }
                else
                {
                    File.WriteAllText(AnimatronicDropDown.SelectedItem.ToString() + "/lbb.lbb", "false");
                }
            }
        }

        private void AnimatronicDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            animatronicselected = true;
            bool phantom = Convert.ToBoolean(File.ReadAllText(AnimatronicDropDown.SelectedItem.ToString() + "/phantom.feranimext"));

            //properties

            if (phantom == true)
            {
                isphantom_animatronicEditor.Hide();
            }
            else
            {
                isphantom_animatronicEditor.Show();
            }

            //settings

            if (File.ReadAllText(AnimatronicDropDown.SelectedItem.ToString() + "/im.im") == "true")
            {
                animatronicEditorIgnoresMask_Check.Checked = true;
            }
            else
            {
                animatronicEditorIgnoresMask_Check.Checked = false;
            }

            if (File.ReadAllText(AnimatronicDropDown.SelectedItem.ToString() + "/al.al") == "true")
            {
                animatronicEditorAudioLured_Check.Checked = true;
            }
            else
            {
                animatronicEditorAudioLured_Check.Checked = false;
            }

            if (File.ReadAllText(AnimatronicDropDown.SelectedItem.ToString() + "/lbb.lbb") == "true")
            {
                animatronicEditorLikeBB_Check.Checked = true;
            }
            else
            {
                animatronicEditorLikeBB_Check.Checked = false;
            }

            //path

            if (File.ReadAllText(AnimatronicDropDown.SelectedItem.ToString() + "/path.feranimpath") == "")
            {

            }
            else
            {
                //RefreshAnimPathView(AnimatronicDropDown.SelectedItem.ToString());
            }
        }

        private void Menu_CodeEditor_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void label92_Click(object sender, EventArgs e) //CLOSE BUTTON
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void TheCutestCat_Click(object sender, EventArgs e)
        {
            //TODO: diamond cat
        }

        private void Menus_KeyDown(object sender, KeyEventArgs e)
        {
            if (Menus.SelectedNode != null)
            {
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.C)
                {
                    Clipboard.SetText("Menu: " + File.ReadAllText(curMenuTag + "/name.txt") + ", \nCode: On Game Loop, On Menu Start, \nElements: ", TextDataFormat.Text);
                }
            }
        }

        private void deleteDataValue_GameManager_Click(object sender, EventArgs e)
        {
            object tag = "Data_Values_List";
            if (GameManager_Variables_View.SelectedNode == null || GameManager_Variables_View.SelectedNode.Tag == tag || GameManager_Variables_View.SelectedNode.Name == "value")
            {
                Logger.Log("Select a data value first!");
            }
            else
            {
                //DataValues.DeleteDataValue(GameManager_Variables_View.SelectedNode.Name, DataValues.GetDataValue(GameManager_Variables_View.SelectedNode.Name));
                //DataValues.RefreshDataValues();
            }
        }

        private void animatronicEditorPNL2_VisibleChanged(object sender, EventArgs e)
        {
            if (_0_2C == true)
            {
                comboBox2.Items.Clear();
                comboBox2.Items.AddRange(Directory.GetDirectories(projecto + "/sounds"));
                comboBox3.Items.Clear();
                comboBox3.Items.AddRange(Directory.GetDirectories(projecto + "/animations"));
                animatronicselected = false;
                if (Directory.Exists(projecto + "/animatronics"))
                {
                    //aight
                }
                else
                {
                    Logger.Log("Animations is null. E2569");
                    _ = Directory.CreateDirectory(projecto + "/animatronics");
                }
                AnimatronicDropDown.Items.Clear();
                AnimatronicDropDown.Items.AddRange(Directory.GetDirectories(projecto + "/animatronics"));
            }
            else
            {

            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            script = ScriptEditor_Scripts_ComboBox.SelectedItem.ToString();
            CodeblockSelector selector = new CodeblockSelector(this);
            selector.eventr = false;
            _ = selector.ShowDialog();
        }

        private void AddPath_Click(object sender, EventArgs e)
        {
            ChooseAnimatronicPath.Show();
        }

        private void ThrowNotImplementedError(string type)
        {
            throw new NotImplementedException("Not implemented type: " + type);
        }

        //ANIM EDITOR PATH SELECTION

        private void CamIcon_AnimEditor_Click(object sender, EventArgs e)
        {

        }

        private void DoorIcon_AnimEditor_Click(object sender, EventArgs e)
        {

        }

        private void FlashlightIcon_AnimEditor_Click(object sender, EventArgs e)
        {

        }

        private void LightIcon_AnimEditor_Click(object sender, EventArgs e)
        {

        }

        private void MusicBox_AnimEditor_Click(object sender, EventArgs e)
        {

        }

        private void OfficeIcon_AnimEditor_Click(object sender, EventArgs e)
        {

        }

        private void AlternatePath_AnimEditor_Click(object sender, EventArgs e)
        {
            ThrowNotImplementedError("Alternate Path");
        }

        private void StateIcon_AnimEditor_Click(object sender, EventArgs e)
        {

        }

        private void Settings_Click(object sender, EventArgs e)
        {
            UI_Editor.Show();
        }

        private void OK_UIEditor_Click(object sender, EventArgs e)
        {
            draggable_ui = false;
            UI_Editor.Hide();
        }

        private async void Drag_UIEditor_Click(object sender, EventArgs e)
        {
            if (draggable_ui == false)
            {
                draggable_ui = true;
                Drag_.BackgroundImage = Properties.Resources.Cancel;
            }
            else if (draggable_ui == true)
            {
                draggable_ui = false;
                Drag_.BackgroundImage = Properties.Resources.Drag;
            }

            while (true)
            {
                await Task.Delay(1);
                foreach (Control control in this.Controls)
                {
                    if (control is Panel)
                    {
                        foreach (Control controls in control.Controls)
                        {
                            controls.Draggable(draggable_ui);
                            if (controls is Panel)
                            {
                                foreach (Control controlss in controls.Controls)
                                {
                                    controlss.Draggable(draggable_ui);
                                }
                            }
                        }
                    }
                    control.Draggable(draggable_ui);
                }
            }
        }

        private void Paint_UIEditor_Click(object sender, EventArgs e)
        {
            //Logger.Log("Every element you click from now on will change its color to what you pick here.");
        }

        private void MenuCodeEditor_Code_Tree_Click(object sender, EventArgs e)
        {
            MenuCodeEditor_Code_Tree.Nodes.Clear();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            createShit.Hide();
        }

        private void button45_Click(object sender, EventArgs e)
        {
            textCreate_MenuEditor.Hide();
        }

        private void GoToEditor_Click(object sender, EventArgs e)
        {
        }

        private void gamesettings_menubgcolor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();

            File.WriteAllText(projecto + "/menus/settings.txt", colorDialog.Color.R + "," + colorDialog.Color.G + "," + colorDialog.Color.B);
        }

        private void ScrollLeft_Office_MouseDown(object sender, MouseEventArgs e)
        {
            //OfficePreviewBG.Location = new Point(OfficePreviewBG.Location.X - 5, OfficePreviewBG.Location.Y);
        }

        private void ScrollRight_Office_MouseDown(object sender, MouseEventArgs e)
        {
            //OfficePreviewBG.Location = new Point(OfficePreviewBG.Location.X + 5, OfficePreviewBG.Location.Y);
        }

        private void AddFrame_StaticEffectEditor_Click(object sender, EventArgs e)
        {

        }

        private void DeleteFrame_StaticEffectEditor_Click(object sender, EventArgs e)
        {

        }

        private void label29_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.ToolTipTitle = "Game";
            toolTip.Show("Manage your game", label29);
        }

        private void label124_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.ToolTipTitle = "Debug";
            toolTip.Show("Debug your game", label124);
        }

        private void label143_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.ToolTipTitle = "Playtest";
            toolTip.Show("Try out your game!", label143);
        }

        private void label83_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.ToolTipTitle = "Build";
            toolTip.Show("Build your game!", label83);
        }

        private void label92_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.ToolTipTitle = "Close";
            toolTip.Show("Close your project!", label92);
        }

        private void label19_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.ToolTipTitle = "Help";
            toolTip.Show("How to use", label19);
        }

        private void Settings_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.ToolTipTitle = "Customize";
            toolTip.Show("Customize your workspace!", Settings);
        }

        private void label108_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.ToolTipTitle = "Discord Server";
            toolTip.Show("Join our Discord!", label108);
        }

        private void EditorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (EditorList.SelectedItem.ToString())
                {
                    case "Game Info":
                        buildSettingsPanelMoment.BringToFront();
                        break;
                    case "Menu Editor":
                        menuEditorPanel.BringToFront();
                        break;
                    case "Office Editor":
                        officeEditorPanel.BringToFront();
                        break;
                    case "Camera Editor":
                        cameraEditorPanel.BringToFront();
                        break;
                    case "Animatronic Editor":
                        animatronicEditorPNL2.BringToFront();
                        break;
                    case "Animation Editor":
                        animationEditorPanel.BringToFront();
                        break;
                    case "Sound Editor":
                        SoundEditorPanel.BringToFront();
                        break;
                    case "Script Editor":
                        ScriptEditorPanel.BringToFront();
                        break;
                    case "Extensions":
                        ExtensionsPanel.BringToFront();
                        break;

                    //exclusive  to fer
                    case "Minigame Editor":
                        MinigameMaker m = new MinigameMaker();
                        m.ShowDialog();
                        break;
                    case "Cutscene Editor":
                        cutsceneEditorPanel.BringToFront();
                        break;
                    case "Static Effect Editor":
                        staticeffecteditor.BringToFront();
                        break;
                }
                if (!EditorList.SelectedItem.ToString().Contains("=")) this.presence.details = EditorList.SelectedItem.ToString();
                if (this.presence.details == "Minigame Editor") this.presence.details = "Minigame Maker"; //huh
                if (DiscordRPCEnabled) DiscordRpc.UpdatePresence(ref this.presence);
            }
            catch (Exception)
            {
                Logger.Log("Something went horribly wrong! If this keeps happening, please report it on our discord server!", "Fatal error");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button127_Click(object sender, EventArgs e)
        {

        }

        private void button68_Click(object sender, EventArgs e)
        {

        }

        private void CreateLightButton_OfficeEditor_Click(object sender, EventArgs e)
        {

        }

        private void CreatePanel_OfficeEditor_Click(object sender, EventArgs e)
        {

        }

        private void CreateDoorButton_OfficeEditor_Click(object sender, EventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {

        }

        private void CreateInput_OfficeEditor_Click(object sender, EventArgs e)
        {

        }
    }
}