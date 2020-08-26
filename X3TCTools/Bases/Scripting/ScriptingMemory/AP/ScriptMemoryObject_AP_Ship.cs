﻿
using X3TCTools.SectorObjects;

namespace X3TCTools.Bases.Scripting.ScriptingMemory.AP
{
    public class ScriptMemoryObject_AP_Ship : ScriptMemoryObject, IScriptMemoryObject_Ship
    {
        public const int VariableCount = 108;
        public int SubType => GetVariableValue((int)AP_Ship_Variables.SubType);
        public CargoEntry[] CargoEntries
        {
            get
            {
                ScriptingHashTableObject cargoItems = GetVariable((int)AP_Ship_Variables.Cargo).GetAsHashTableObject();
                CargoEntry[] entries = new CargoEntry[cargoItems.hashTable.Count];
                int i = 0;
                foreach (DynamicValue id in cargoItems.hashTable.ScanContents())
                {
                    entries[i++] = new CargoEntry()
                    {
                        Type = SectorObject.Full_Type.FromInt(id.Value),
                        Count = cargoItems.hashTable.GetObject(id).Value
                    };
                }
                return entries;
            }
        }
        public int PreviousSectorEventObjectID => GetVariableValue((int)AP_Ship_Variables.PreviousSectorEventObjectID);
        public EventObject PreviousSectorEventObject => GameHook.storyBase.GetEventObject(PreviousSectorEventObjectID);
        public int CurrentSectorEventObjectID => GetVariableValue((int)AP_Ship_Variables.CurrentSectorEventObjectID);
        public EventObject CurrentSectorEventObject => GameHook.storyBase.GetEventObject(CurrentSectorEventObjectID);

        public int OwnerDataEventObjectID => GetVariableValue((int)AP_Ship_Variables.OwningRaceDataEventObjectID);
        public EventObject OwnerDataEventObject => GameHook.storyBase.GetEventObject(OwnerDataEventObjectID);

        public bool IsValid => SubType < GameHook.GetTypeDataCount((int)SectorObject.Main_Type.Ship);

        public override string GetVariableName(int index)
        {
            return ((AP_Ship_Variables)index).ToString();
        }
        public ScriptMemoryObject_AP_Ship() : base(VariableCount)
        {

        }
    }
}
