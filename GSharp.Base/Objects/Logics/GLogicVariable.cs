﻿using System;
using GSharp.Base.Cores;

namespace GSharp.Base.Objects.Logics
{
    [Serializable]
    public class GLogicVariable : GLogic, IVariable
    {
        #region 속성
        public string Name { get; set; }
        #endregion

        #region 생성자
        public GLogicVariable(string valueName)
        {
            Name = valueName;
        }
        #endregion

        public override string ToSource()
        {
            return Name;
        }
    }
}
