﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;

namespace X3TCTools.Bases
{
    public class EventFunctionStruct : MemoryObject
    {
        public const int ByteSize = 24;

        public IntPtr pPrimaryFunction;
        public IntPtr pFunction2;
        public IntPtr pFunction3;
        public IntPtr pFunction4;
        public IntPtr ppString;
        public int Index;

        public override byte[] GetBytes()
        {
            throw new NotImplementedException();
        }

        public override int GetByteSize()
        {
            return ByteSize;
        }

        public override void SetData(byte[] Memory)
        {
            var collection = new ObjectByteList(Memory);
            collection.PopFirst(ref pPrimaryFunction);
            collection.PopFirst(ref pFunction2);
            collection.PopFirst(ref pFunction3);
            collection.PopFirst(ref pFunction4);
            collection.PopFirst(ref ppString);
            collection.PopFirst(ref Index);
        }

        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
        }
    }
}
