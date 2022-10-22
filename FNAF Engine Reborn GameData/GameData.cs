﻿using FNAF_Engine_GameData.BinaryData.Binaries;
using FNAF_Engine_GameData.BinaryData.MenuStuff;
using FNAF_Engine_GameData.BinaryData.Options;
using FNAF_Engine_Reborn_GameData.BinaryData.Binaries;
using FNAF_Engine_Reborn_GameData.BinaryData.Stuff.Animations;
using FNAF_Engine_Reborn_GameData.BinaryData.Stuff.StaticEffects;
using FNAF_Engine_Reborn_GameData.BinaryData.Stuff.Values;
using System;
using System.Collections.Generic;
using System.IO;

namespace FNAF_Engine_Reborn_GameData
{
    public class GameData
    {
        public string _header { get; set; } = "";
        public byte _key { get; set; } = 0;
        public Stamp _stamp { get; set; } = new Stamp();

        public string Name { get; set; } = "";
        public string GameName { get; set; } = "";

        public string ID { get; private set; } = ""; //unused for now lol

        public GameOptions Options { get; set; } = new GameOptions();
        public System.Drawing.Color MenuSettings { get; set; } = new System.Drawing.Color();

        public List<Variable> DataValues { get; set; } = new List<Variable>(); 
        public List<StringVariable> DataStrings { get; set; } = new List<StringVariable>();
        public List<Variable> Variables { get; set; } = new List<Variable>();
        public List<StringVariable> StringVariables { get; set; } = new List<StringVariable>();

        public List<Image> ImageBank { get; set; } = new List<Image>(); //general image bank
        public List<Audio> AudioBank { get; set; } = new List<Audio>(); //general audio bank

        //misc
        public List<Animation> Animations { get; set; } = new List<Animation>();
        public List<StaticEffect> StaticEffects { get; set; } = new List<StaticEffect>();
        //game
        public List<FNAF_Engine_Menu> Menus { get; set; } = new List<FNAF_Engine_Menu>();

        public void Write(BinaryWriter Writer, bool binary, string projectpath)
        {
            if (binary == true)
            {
                Writer.Write(_header);
                Writer.Write(_key);
                _stamp.Write(Writer);

                Writer.Write(Name);
                Writer.Write(GameName);
                //options
                #region
                Options.Write(Writer, true, null);
                Writer.Write(MenuSettings.R);
                Writer.Write(MenuSettings.G);
                Writer.Write(MenuSettings.B);
                #endregion

                //data and vars
                #region
                Writer.Write((int)DataValues.Count);
                Writer.Write((int)Variables.Count);

                foreach (var Data in DataValues)
                {
                    Data.Write(Writer, true, "");
                }
                foreach (var var in DataValues)
                {
                    var.Write(Writer, true, "");
                }
                #endregion

                //Images and audio
                #region

                Writer.Write(ImageBank.Count);
                Writer.Write(AudioBank.Count);

                foreach (Image img in ImageBank)
                {
                    img.Write(Writer);
                }

                foreach (Audio aud in AudioBank)
                {
                    aud.Write(Writer);
                }

                #endregion

                //animations and stuff
                #region
                Writer.Write(Animations.Count);
                Writer.Write(StaticEffects.Count);

                foreach (var an in Animations)
                {
                    an.Write(Writer, true, "");
                }
                foreach (var s in StaticEffects)
                {
                    s.Write(Writer, true, "");
                }
                #endregion

                //Menus
                Writer.Write(Menus.Count);
                #region
                foreach (var m in Menus)
                {
                    m.Write(Writer, true, null, null);
                }
                #endregion

                Writer.Flush();
                Writer.Close();
            }
            else
            {
                File.WriteAllText(projectpath + "/name.txt", Name);

                //File.WriteAllText(projectpath + "/gameid.txt", ID);
                File.WriteAllText(projectpath + "/gameid.txt", "");
                File.WriteAllText(projectpath + "/game.txt", GameName);

                Options.Write(null, false, projectpath);
                //Menu settings VVVVVVVVVVVVVVV
                File.WriteAllText(projectpath + "/menus/settings.txt", MenuSettings.R + "," + MenuSettings.G + "," + MenuSettings.B);
                //Menu settings ^^^^^^^^^^^^^^^

            }
        }
        public void Read(BinaryReader reader, bool binary, string projectpath)
        {
            if (binary == true)
            {
                _header = reader.ReadString();
                _key = reader.ReadByte();
                reader.BaseStream.Position += 17;

                if (_header != "FER_DAT") throw new InvalidDataException("Bad header!");

                Name = reader.ReadString();
                GameName = reader.ReadString();

                Options.Read(reader, true, "");
                var r = reader.ReadByte();
                var g = reader.ReadByte();
                var b = reader.ReadByte();
                MenuSettings = System.Drawing.Color.FromArgb(r, g, b);

                var datavalc = reader.ReadInt32();
                var VARc = reader.ReadInt32();

                for (int I = 0; I < datavalc; I++)
                {
                    Variable dataval = new Variable();
                    dataval.Read(reader, true, "");
                    DataValues.Add(dataval);
                }
                for (int I = 0; I < VARc; I++)
                {
                    Variable varval = new Variable();
                    varval.Read(reader, true, "");
                    Variables.Add(varval);
                }

                var imgc = reader.ReadInt32();
                var audc = reader.ReadInt32();

                for (int i = 0; i < imgc; i++)
                {
                    Image img = new Image();
                    img.Read(reader, true, "", "");
                    ImageBank.Add(img);
                }
                for (int i = 0; i < audc; i++)
                {
                    Audio aud = new Audio();
                    aud.Read(reader, true, "", "");
                    AudioBank.Add(aud);
                }

                var animc = reader.ReadInt32();
                var sc = reader.ReadInt32();

                for (int i = 0; i < animc; i++)
                {
                    Animation anim = new Animation();
                    anim.Read(reader, true, "");
                    Animations.Add(anim);
                }
                for (int i = 0; i < sc; i++)
                {
                    StaticEffect se = new StaticEffect();
                    se.Read(reader, false, "");
                    StaticEffects.Add(se);
                }


                var menuCount = reader.ReadInt32();
                for (int i = 0; i < menuCount; i++)
                {
                    FNAF_Engine_Menu menu = new FNAF_Engine_Menu();
                    menu.Read(reader, true, null, null);
                    Menus.Add(menu);
                }



            }
            else
            {
                Name = File.ReadAllText(projectpath + "/name.txt");

                //ID = File.ReadAllText(projectpath + "/gameid.txt");
                GameName = File.ReadAllText(projectpath + "/game.txt");


                Options.Read(null, false, projectpath);

                string txt = File.ReadAllText(projectpath + "/menus/settings.txt");
                MenuSettings = System.Drawing.Color.FromArgb(Convert.ToInt32(txt.Split(',')[0]), Convert.ToInt32(txt.Split(',')[1]), Convert.ToInt32(txt.Split(',')[2]));


            }
        }
    }
}