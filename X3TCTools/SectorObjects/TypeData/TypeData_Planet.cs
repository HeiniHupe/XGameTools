﻿using Common.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.SectorObjects
{
    public class TypeData_Planet : TypeData
    {
        public int ModelCollectionID;
        protected override void SetUniqueData(ObjectByteList obl)
        {
            ModelCollectionID = obl.PopInt(0x50);
        }
    }
}
