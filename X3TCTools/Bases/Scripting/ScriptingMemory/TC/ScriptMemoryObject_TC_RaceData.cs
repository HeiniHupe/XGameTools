﻿using System;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_RaceData : ScriptMemoryObject, IScriptMemoryObject_RaceData
    {
        public const int VariableCount = 9;

        public int ASectorEventObjectID => GetVariableValue((int)TC_RaceData_Variables.ASectorEventObjectID);
        public EventObject ASectorEventObject => GameHook.storyBase.GetEventObject(ASectorEventObjectID);

        public int pOwnedShipEventObjectIDHashTableObject => GetVariableValue((int)TC_RaceData_Variables.OwnedShipEventObjectIDHashTable);
        public ScriptingHashTableObject OwnedShipEventObjectIDHashTableObject { get { ScriptingHashTableObject table = new ScriptingHashTableObject(); table.SetLocation(GameHook.hProcess, (IntPtr)pOwnedShipEventObjectIDHashTableObject); table.ReloadFromMemory(); return table; } }


        public GameHook.RaceID RaceID => (GameHook.RaceID)GetVariableValue((int)TC_RaceData_Variables.RaceID);

        public int pOwnedStationEventObjectIDHashTableObject => throw new NotImplementedException();

        public ScriptingHashTableObject OwnedStationEventObjectIDHashTableObject => throw new NotImplementedException();

        public int pOwnedSectorEventObjectIDHashTableObject => throw new NotImplementedException();

        public ScriptingHashTableObject OwnedSectorEventObjectIDHashTableObject => throw new NotImplementedException();

        public int pOwnedShipyardEventObjectIDHashTableObject => throw new NotImplementedException();

        public ScriptingHashTableObject OwnedShipyardEventObjectIDHashTableObject => throw new NotImplementedException();

        public override string GetVariableName(int index)
        {
            return ((TC_RaceData_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_RaceData() : base(VariableCount)
        {

        }
    }
}
