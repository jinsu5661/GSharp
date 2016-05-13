﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GSharp.Graphic.Core;
using GSharp.Graphic.Holes;
using GSharp.Base.Cores;
using GSharp.Base.Objects;
using GSharp.Base.Statements;
using GSharp.Base.Objects.Logics;

namespace GSharp.Graphic.Statements
{
    /// <summary>
    /// LogicSetBlock.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LogicSetBlock : PrevStatementBlock
    {
        public LogicSetBlock()
        {
            InitializeComponent();
            InitializeBlock();
        }

        public override NextConnectHole NextConnectHole
        {
            get
            {
                return RealNextConnectHole;
            }
        }

        public override StatementBlock GetLastBlock()
        {
            if (NextConnectHole.StatementBlock == null)
            {
                return this;
            }

            return NextConnectHole.StatementBlock.GetLastBlock();
        }

        public GSet<GLogicVariable, GLogic> GSet
        {
            get
            {
                string variableName = VariableSelect.Text;
                GLogicVariable variable = new GLogicVariable(variableName);

                GLogic obj = LogicHole?.LogicBlock?.GLogic;

                if (obj == null)
                {
                    throw new ToObjectException("변수 설정 블럭이 완성되지 않았습니다.", this);
                }

                return new GSet<GLogicVariable, GLogic>(variable, obj);
            }
        }

        public override GStatement GStatement
        {
            get
            {
                return GSet;
            }
        }

        public override List<BaseHole> HoleList
        {
            get
            {
                return new List<BaseHole> { LogicHole, NextConnectHole };
            }
        }

        public override List<GBase> GObjectList
        {
            get
            {
                List<GBase> baseList = new List<GBase>();
                baseList.Add(GSet);

                List<GBase> nextList = NextConnectHole?.StatementBlock?.GObjectList;
                if (nextList != null)
                {
                    baseList.AddRange(nextList);
                }

                return baseList;
            }
        }
    }
}
