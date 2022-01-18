﻿using CommonToolLib.Generics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCommonLib.Files.CatDat
{
    /// <summary>
    /// A compressed file used by the game. May be encrypted depending on the version of the game it is from.
    /// </summary>
    public abstract class PckFile : IBinaryObject
    {
        public byte[] DecompressedData
        {
            get
            {
                return DecompressData();
            }
            set
            {
                CompressData(value);
            }
        }
        public byte[] CompressedData
        {
            get;
            protected set;
        }

        protected abstract byte[] DecompressData();
        protected abstract void CompressData(byte[] data);

        public int ByteSize => CompressedData.Length;

        /// <summary>
        /// Get the compressed file.
        /// Encryption may be done when overriding this method.
        /// </summary>
        /// <returns>Compressed and (when required) encrypted bytes.</returns>
        public virtual byte[] GetBytes()
        {
            return CompressedData;
        }
        /// <summary>
        /// Set the compressed file.
        /// Decryption may be done when overriding this method.
        /// </summary>
        /// <param name="Memory">Compressed and (when required) encrypted bytes.</param>
        public virtual void SetData(byte[] Memory)
        {
            CompressedData = Memory;
        }
    }
}
