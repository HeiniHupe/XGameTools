﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Memory;

namespace X3TCTools
{
    public class LinkedListStart<T> : MemoryObject where T:IMemoryObject, new()
    {

        public const int ByteSize = 12;

        public MemoryObjectPointer<T> pFirst = new MemoryObjectPointer<T>();
        public int NULL;
        public MemoryObjectPointer<T> pLast = new MemoryObjectPointer<T>();

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
            collection.PopFirst(ref pFirst);
            collection.PopFirst(ref NULL);
            collection.PopFirst(ref pLast);
        }
        public override void SetLocation(IntPtr hProcess, IntPtr address)
        {
            base.SetLocation(hProcess, address);
            pFirst.SetLocation(hProcess, address);
            pLast.SetLocation(hProcess, address + 8);
        }
    }
}
