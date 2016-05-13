﻿using System;
using GSharp.Base.Cores;
using GSharp.Base.Objects;

namespace GSharp.Base.Singles
{
    [Serializable]
    public class GDefine : GSingle
    {
        public string Name { get; set; }

        public GDefine(string valueName)
        {
            Name = valueName;
        }

        public override string ToSource()
        {
            return string.Format
                (
                    "public object {0};",
                    Name
                );
        }
    }
}
