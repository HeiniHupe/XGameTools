﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace X3TCTools.SectorObjects
{
    public partial class SectorObject
    {

        public const int MAIN_TYPE_COUNT = 32;
        public enum Main_Type : ushort
        {
            Bullet,
            Sector,
            Background,
            Sun,
            Planet,
            Dock,
            Factory,
            Ship,
            Laser,
            Shield,
            Missile,
            Ware_E,
            Ware_N,
            Ware_B,
            Ware_F,
            Ware_M,
            Ware_T,
            Asteroid,
            Gate,
            Camera,
            Special,

            Cockpit = 25,

            Debris = 28,
            Wreck,
            Factory_Wreck,
            Ship_Wreck
        }

        public static int ToFullType(Main_Type MainType, int SubType)
        {
            return (((int)MainType) << 16 | SubType);
        }

        public static void FromFullType(int FullType, out Main_Type MainType, out int SubType)
        {
            MainType = (Main_Type)(FullType >> 16);
            SubType = FullType & 0x0000ffff;
        }

        /// <summary>
        /// Returns the object's subtype in as a string. Takes maintype into account.
        /// </summary>
        /// <returns></returns>
        public string GetSubTypeAsString()
        {
            return (GetSubTypeAsString(MainType, SubType));
        }

        public static string GetSubTypeAsString(Main_Type main_Type, int SubType)
        {
            string path;

            switch (GameHook.GameVersion)
            {
                case GameHook.GameVersions.X3TC: path = "./X3TCSectorObjectTypes.csv"; break;
                case GameHook.GameVersions.X3AP: path = "./X3APSectorObjectTypes.csv"; break;
                default: throw new Exception();
            }

            var lines = File.ReadAllLines(path);

            if (lines.Length <= SubType) goto failed;

            var line = lines[SubType];

            var names = line.Split(',');

            if (names.Length <= (int)main_Type) goto failed;

            var name = names[(int)main_Type];

            if (string.IsNullOrEmpty(name)) goto failed;

            return name;

            failed:
            return SubType.ToString();
        }
    }
}
