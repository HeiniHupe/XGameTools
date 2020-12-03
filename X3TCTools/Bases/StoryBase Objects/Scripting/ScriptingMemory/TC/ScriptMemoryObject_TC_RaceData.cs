﻿using System;

namespace X3Tools.Bases.StoryBase_Objects.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_RaceData : ScriptMemoryObject, IScriptMemoryObject_RaceData
    {
        public const int VariableCount = 9;

        #region Memory
        public int ASectorScriptingObjectID => GetVariableValue((int)TC_RaceData_Variables.ASectorScriptingObjectID);
        public int pOwnedShipScriptingObjectIDHashTableObject => GetVariableValue((int)TC_RaceData_Variables.OwnedShipScriptingObjectIDHashTable);
        public GameHook.RaceID RaceID => (GameHook.RaceID)GetVariableValue((int)TC_RaceData_Variables.RaceID);
        public int pOwnedShipyardScriptingObjectIDHashTableObject => throw new NotImplementedException();
        public int pOwnedSectorScriptingObjectIDHashTableObject => throw new NotImplementedException();
        public int pOwnedStationScriptingObjectIDHashTableObject => GetVariableValue((int)TC_RaceData_Variables.OwnedStationScriptingObjectIDHashTable);

        #endregion
        #region Scripting Objects
        public ScriptingHashTableObject OwnedStationScriptingObjectIDHashTableObject { get { ScriptingHashTableObject table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pOwnedStationScriptingObjectIDHashTableObject); table.ReloadFromMemory(); return table; } }
        public ScriptingHashTableObject OwnedSectorScriptingObjectIDHashTableObject => throw new NotImplementedException();
        public ScriptingHashTableObject OwnedShipyardScriptingObjectIDHashTableObject => throw new NotImplementedException();
        public ScriptingHashTableObject OwnedShipScriptingObjectIDHashTableObject { get { ScriptingHashTableObject table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pOwnedShipScriptingObjectIDHashTableObject); table.ReloadFromMemory(); return table; } }
        public ScriptingObject ASectorScriptingObject => GameHook.storyBase.GetScriptingObject(ASectorScriptingObjectID);
        public ScriptingObject[] Ships
        {
            get
            {
                ScriptingObject[] ships = new ScriptingObject[OwnedShipScriptingObjectIDHashTableObject.hashTable.Count];
                int i = 0;
                foreach (DynamicValue shipID in OwnedShipScriptingObjectIDHashTableObject.hashTable.ScanContents())
                {
                    ships[i++] = GameHook.storyBase.GetScriptingObject(shipID.Value);
                }
                return ships;
            }
        }
        public ScriptingObject[] Stations
        {
            get
            {
                ScriptingObject[] stations = new ScriptingObject[OwnedStationScriptingObjectIDHashTableObject.hashTable.Count];
                int i = 0;
                foreach (DynamicValue shipID in OwnedStationScriptingObjectIDHashTableObject.hashTable.ScanContents())
                {
                    stations[i++] = GameHook.storyBase.GetScriptingObject(shipID.Value);
                }
                return stations;
            }
        }
        #endregion

        public override string GetVariableName(int index)
        {
            return ((TC_RaceData_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_RaceData() : base(VariableCount)
        {

        }
    }
}
