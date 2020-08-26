﻿using Common.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.Bases.Scripting.ScriptingMemory
{
    public interface IScriptMemoryObject_RaceData : IMemoryObject
    {
        int ASectorEventObjectID { get; }
        EventObject ASectorEventObject { get; }

        int pOwnedSectorEventObjectIDHashTableObject { get; }
        ScriptingHashTableObject OwnedSectorEventObjectIDHashTableObject { get; }

        int pOwnedShipEventObjectIDHashTableObject { get; }
        ScriptingHashTableObject OwnedShipEventObjectIDHashTableObject { get; }

        int pOwnedShipyardEventObjectIDHashTableObject { get; }
        ScriptingHashTableObject OwnedShipyardEventObjectIDHashTableObject { get; }

        int pOwnedStationEventObjectIDHashTableObject { get; }
        ScriptingHashTableObject OwnedStationEventObjectIDHashTableObject { get; }


        GameHook.RaceID RaceID { get; }
    }
}
