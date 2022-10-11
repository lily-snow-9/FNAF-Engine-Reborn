﻿using FNAF_Engine_GameData.BinaryData.Binaries;
using System.IO;

namespace FNAF_Engine_Reborn_GameData.BinaryData.Stuff.StaticEffects
{
    public class StaticEffectFrame
    {
        public Image Image { get; set; }
        public ushort Speed { get; set; }

        public void Read(BinaryReader reader, bool binary, string projectpath)
        {
            if (binary == true)
            {
                Image.Read(reader, true, "", "");
                Speed = reader.ReadUInt16();
            }
            else
            {
                //todo
            }
        }
        public void Write(BinaryWriter Writer, bool binary, string projectpath)
        {
            if (binary == true)
            {
                Image.Write(Writer);
                Writer.Write((ushort)Speed);
            }
            else
            {
                //todo prj writing
            }
        }
    }
}
