﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.AP
{
    public enum AP_Sun_Variables
    {
        PositionData,
        CurrentSectorEventObjectID,

        SubType = 7,
    }

    public enum AP_Planet_Variables
    {
        PositionData,
        CurrentSectorEventObjectID,

        SubType = 6,
    }
    public enum AP_Dock_Variables
    {
        PositionData,

        SubType = 13,

        InstalledShieldArray = 19,

        Hull = 24,

        ShieldStrength = 32,

        Cargo = 44
    }
    public enum AP_Gate_Variables
    {
        PositionData,
        CurrentSectorEventObjectID,

        Dest_Sector_X = 8,
        Dest_Sector_Y,

        DestSectorDataEventObjectID = 11,
    }
    public enum AP_Sector_Variables
    {
        Sector_X,
        Sector_Y,
        SectorDataEventObjectID,

        ShipEventObjectIDHashTable = 3,

        SunEventObjectIDHashTable = 5,
        DockEventObjectIDHashTable,
        FactoryEventObjectIDHashTable,

        GateEventObjectIDHashTable = 10,
        GateEventObjectIDArray,

        DebrisEventObjectIDHashTable = 14
    }
    public enum AP_Ship_Variables
    {
        PositionData,
        /// <summary>
        /// The ID of the EventObject that the ship is currently in.
        /// </summary>
        CurrentSectorEventObjectID,
        /// <summary>
        /// The ID of the EventObject that the ship was in previously in.
        /// </summary>
        PreviousSectorEventObjectID,

        SubType = 14,

        CustomShipName = 18,

        Hull = 20,

        WeaponArray = 23,

        ShieldStrength = 26,
        InstalledShieldArray,

        Cargo = 35,

        CurrentCargoVolume = 72,
    }

    public enum AP_Factory_Variables
    {
        PositionData,
        /// <summary>
        /// The ID of the EventObject that the ship is currently in.
        /// </summary>
        CurrentSectorEventObjectID,
        /// <summary>
        /// The ID of the EventObject that the ship was in previously in.
        /// </summary>
        PreviousSectorEventObjectID,

        SubType = 13,
    }

    public enum AP_Ware_Variables
    {
        PositionData,
        /// <summary>
        /// The ID of the EventObject that the ship is currently in.
        /// </summary>
        CurrentSectorEventObjectID,
        /// <summary>
        /// The ID of the EventObject that the ship was in previously in.
        /// </summary>
        PreviousSectorEventObjectID,

        Amount = 6,
        MainType,
        SubType
    }

    public enum AP_PositionData_Variables
    {
        Position_X,
        Position_Y,
        Position_Z,
        Rotation_Alpha,
        Rotation_Beta,
        Rotation_Gamma,
    }

    public enum AP_SectorData_Variables
    {
        OwnerRace,
        SectorEventObjectID,
    }
}
