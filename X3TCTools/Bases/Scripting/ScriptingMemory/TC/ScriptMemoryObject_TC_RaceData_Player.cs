﻿using System;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_RaceData_Player : ScriptMemoryObject, IScriptMemoryObject_RaceData_Player
    {
        public const int VariableCount = 49;

        public GameHook.RaceID RaceID => GameHook.RaceID.Player;

        public int ASectorEventObjectID => throw new NotImplementedException();

        public EventObject ASectorEventObject => throw new NotImplementedException();

        public int pOwnedShipEventObjectIDHashTableObject => throw new NotImplementedException();

        public ScriptingHashTableObject OwnedShipEventObjectIDHashTableObject => throw new NotImplementedException();

        public int pOwnedStationEventObjectIDHashTableObject => throw new NotImplementedException();

        public ScriptingHashTableObject OwnedStationEventObjectIDHashTableObject => throw new NotImplementedException();

        public int pRaceDataWithSectorsEventObjectIDHashTable => throw new NotImplementedException();

        public ScriptingHashTableObject RaceDataWithSectorsEventObjectIDHashTable => throw new NotImplementedException();

        public int pRaceDataEventObjectIDHashTable => throw new NotImplementedException();

        public ScriptingHashTableObject RaceDataEventObjectIDHashTable => throw new NotImplementedException();

        public int pOwnedSectorEventObjectIDHashTableObject => throw new NotImplementedException();

        public ScriptingHashTableObject OwnedSectorEventObjectIDHashTableObject => throw new NotImplementedException();

        public int pOwnedShipyardEventObjectIDHashTableObject => throw new NotImplementedException();

        public ScriptingHashTableObject OwnedShipyardEventObjectIDHashTableObject => throw new NotImplementedException();

        public override string GetVariableName(int index)
        {
            return ((TC_RaceData_Player_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_RaceData_Player() : base(VariableCount)
        {

        }
    }
}
