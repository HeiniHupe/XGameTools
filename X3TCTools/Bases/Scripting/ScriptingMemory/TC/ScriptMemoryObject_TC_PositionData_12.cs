﻿namespace X3TCTools.Bases.Scripting.ScriptingMemory.TC
{
    public class ScriptMemoryObject_TC_PositionData_12 : ScriptMemoryObject
    {
        public override string GetVariableName(int index)
        {
            return ((TC_PositionData_Variables)index).ToString();
        }
        public ScriptMemoryObject_TC_PositionData_12() : base(12)
        {

        }
    }
}
