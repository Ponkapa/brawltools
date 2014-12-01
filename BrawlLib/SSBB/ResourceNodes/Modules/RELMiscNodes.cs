﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BrawlLib.SSBBTypes;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using BrawlLib.IO;
using System.PowerPcAssembly;

namespace BrawlLib.SSBB.ResourceNodes
{
    public unsafe class RELEntryNode : ResourceNode
    {
        public override ResourceType ResourceType { get { return ResourceType.Unknown; } }
        internal VoidPtr Data { get { return WorkingUncompressed.Address; } }
        
        [Browsable(false)]
        public uint RootOffset { get { return Root != null && Data != 0 ? ((uint)Data - (uint)BaseAddress) : 0; } }
        public string FileOffset { get { return "0x" + RootOffset.ToString("X"); } }

        [Browsable(false)]
        public VoidPtr BaseAddress { get { if (Root != null) return Root.WorkingUncompressed.Address; else return null; } }

        [Browsable(false)]
        public ResourceNode Root
        {
            get
            {
                ResourceNode n = _parent;
                while (!(n is ModuleNode) && (n != null))
                    n = n._parent;
                return n;
            }
        }

        //[Browsable(false)]
        //public ModuleSectionNode Location
        //{
        //    get
        //    {
        //        if (Root is RELNode)
        //            foreach (ModuleSectionNode s in (Root as RELNode)._sections)
        //                if (s.RootOffset <= RootOffset && s.RootOffset + s.Size > RootOffset)
        //                    return s;
        //        return null;
        //    }
        //}
    }
}
