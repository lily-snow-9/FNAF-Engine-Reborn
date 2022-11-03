﻿using FNAF_Engine_GameData.BinaryData.Binaries;
using FNAF_Engine_GameData.BinaryData.MenuStuff;
using FNAF_Engine_GameData.BinaryData.Options;
using FNAF_Engine_Reborn_GameData.BinaryData;
using FNAF_Engine_Reborn_GameData.BinaryData.Binaries;
using FNAF_Engine_Reborn_GameData.BinaryData.Memory;
using FNAF_Engine_Reborn_GameData.BinaryData.Office;
using FNAF_Engine_Reborn_GameData.BinaryData.Scripts;
using FNAF_Engine_Reborn_GameData.BinaryData.Stuff.Animations;
using FNAF_Engine_Reborn_GameData.BinaryData.Stuff.StaticEffects;
using FNAF_Engine_Reborn_GameData.BinaryData.Stuff.Values;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FNAF_Engine_Reborn_GameData
{
    public class GameData : BinaryClass
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
        public Office Office { get; set; } = new Office();
        public List<Camera> Cameras = new List<Camera>();
        public List<Animatronic> Animatronics = new List<Animatronic>();
        public List<Script> Scripts = new List<Script>();

        public void Write(ByteWriter Writer, bool binary, string projectpath)
        {
            if (binary == true)
            {
                Writer.WriteAscii(_header);
                Writer.WriteInt8(_key);
                _stamp.Write(Writer, true, null);

                Writer.AutoWriteUnicode(Name);
                Writer.AutoWriteUnicode(GameName);
                //options
                #region
                Options.Write(Writer, true, null);
                Writer.WriteInt8(MenuSettings.R);
                Writer.WriteInt8(MenuSettings.G);
                Writer.WriteInt8(MenuSettings.B);
                #endregion

                //data and vars
                #region
                Writer.WriteInt32(DataValues.Count);
                Writer.WriteInt32(DataStrings.Count);
                Writer.WriteInt32(0);

                foreach (var Data in DataValues)
                {
                    Data.Write(Writer, true, "");
                }

                foreach (var Data in DataStrings)
                {
                    Data.Write(Writer, true, "");
                }
                #endregion

                //Images and audio
                #region

                Writer.WriteInt32(ImageBank.Count);
                Writer.WriteInt32(AudioBank.Count);

                foreach (Image img in ImageBank)
                {
                    img.Write(Writer, true, null);
                }

                foreach (Audio aud in AudioBank)
                {
                    aud.Write(Writer, true, null);
                }

                #endregion

                //animations and stuff
                #region
                Writer.WriteInt32(Animations.Count);
                Writer.WriteInt32(StaticEffects.Count);

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
                Writer.WriteUInt16((ushort)Menus.Count);
                #region
                foreach (var m in Menus)
                {
                    m.Write(Writer, true, null);
                }
                #endregion

                Writer.WriteAscii("OFFC");

                Office.Write(Writer, true, null);
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

                File.WriteAllText(projectpath + "/datavalues.txt", "");
                File.WriteAllText(projectpath + "/datastrings.txt", "");
                foreach (var datathing in DataValues)
                {
                    string thing = datathing.Key + ":" + datathing.Value + ",";
                    File.AppendAllText(projectpath + "/datavalues.txt", thing);
                }
                foreach (var datathing in DataStrings)
                {
                    string thing = datathing.Key + ":" + datathing.Value + ",";
                    File.AppendAllText(projectpath + "/datastrings.txt", thing);
                }
                //TODO: Last check for data value/string(s)

                foreach(var img in ImageBank)
                {
                    img.Write(null, false, projectpath);
                }
                foreach(var aud in AudioBank)
                {
                    aud.Write(null, false, projectpath);
                }

                foreach(var anim in Animations)
                {
                    anim.Write(null, false, projectpath);
                }
                foreach(var se in StaticEffects)
                {
                    se.Write(null, false, projectpath);
                }

                foreach(var m in Menus)
                {
                    m.Write(null, true, projectpath);
                }

                Office.Write(null, false, projectpath);
            }
        }
        public void Read(ByteReader reader, bool binary, string projectpath)
        {
            if (binary == true)
            {
                _header = reader.ReadString();
                _key = reader.ReadByte();
                reader.BaseStream.Position += 17;

                if (_header != "FER_DAT") throw new InvalidDataException("Invalid header!");

                Name = reader.AutoReadUnicode();
                GameName = reader.AutoReadUnicode();

                Options.Read(reader, true, "");
                var r = reader.ReadByte();
                var g = reader.ReadByte();
                var b = reader.ReadByte();
                MenuSettings = System.Drawing.Color.FromArgb(r, g, b);

                var datavalc = reader.ReadInt32();
                var datastrc = reader.ReadInt32();
                var VARc = reader.ReadInt32();

                for (int I = 0; I < datavalc; I++)
                {
                    Variable dataval = new Variable();
                    dataval.Read(reader, true, "");
                    DataValues.Add(dataval);
                }
                for (int I = 0; I < datastrc; I++)
                {
                    StringVariable datastr = new StringVariable();
                    datastr.Read(reader, true, "");
                    DataStrings.Add(datastr);
                }
                var imgc = reader.ReadInt32();
                var audc = reader.ReadInt32();

                for (int i = 0; i < imgc; i++)
                {
                    Image img = new Image();
                    img.Read(reader, true, "");
                    ImageBank.Add(img);
                }
                for (int i = 0; i < audc; i++)
                {
                    Audio aud = new Audio();
                    aud.Read(reader, true, "");
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

                var menuCount = reader.ReadUInt16();
                for (int i = 0; i < menuCount; i++)
                {
                    FNAF_Engine_Menu menu = new FNAF_Engine_Menu();
                    menu.Read(reader, true, null);
                    Menus.Add(menu);
                }

                if (reader.ReadAscii(4) != "OFFC")
                {
                    reader.ReadInt64();
                }

                Office.Read(reader, true, null);

            }
            else
            {
                Name = File.ReadAllText(projectpath + "/name.txt");

                //ID = File.ReadAllText(projectpath + "/gameid.txt");
                GameName = File.ReadAllText(projectpath + "/game.txt");


                Options.Read(null, false, projectpath);

                string txt = File.ReadAllText(projectpath + "/menus/settings.txt");
                MenuSettings = System.Drawing.Color.FromArgb(Convert.ToInt32(txt.Split(',')[0]), Convert.ToInt32(txt.Split(',')[1]), Convert.ToInt32(txt.Split(',')[2]));

                foreach(var encoded_data_value in File.ReadAllText(projectpath + "/datavalues.txt").Split(','))
                {
                    var name = encoded_data_value.Split(':')[0];
                    var value = encoded_data_value.Split(':')[1];
                    Variable variable = new Variable();
                    variable.Key = name;
                    variable.Value = Convert.ToInt32(value);
                    DataValues.Add(variable);
                }
                foreach (var encoded_data_value in File.ReadAllText(projectpath + "/datastrings.txt").Split(','))
                {
                    var name = encoded_data_value.Split(':')[0];
                    var value = encoded_data_value.Split(':')[1];
                    StringVariable variable = new StringVariable();
                    variable.Key = name;
                    variable.Value = value;
                    DataStrings.Add(variable);
                }




            }
        }
    }
}