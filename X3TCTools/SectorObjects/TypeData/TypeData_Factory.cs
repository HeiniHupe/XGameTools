﻿using Common.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X3TCTools.SectorObjects
{
    public class TypeData_Factory : TypeData
    {
        public enum FactoryClassification
        {
            Shipyard
        }

        protected override void SetUniqueData(ObjectByteList obl)
        {
            
        }

        public override string GetObjectClassAsString()
        {
            return ((FactoryClassification)ObjectClass).ToString();
        }
    }
}
