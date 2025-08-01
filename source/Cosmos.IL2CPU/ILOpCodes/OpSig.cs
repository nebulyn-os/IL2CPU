using System;
using System.Reflection;

namespace Cosmos.IL2CPU.ILOpCodes
{
    public class OpSig : ILOpCode
    {
        public int Value { get; }
        public byte[] Signature { get; set; }
        public int ParameterCount { get; set; }
        public bool HasReturnValue { get; set; }

        public OpSig(Code aOpCode, int aPos, int aNextPos, int aValue, _ExceptionRegionInfo aCurrentExceptionRegion)
          : base(aOpCode, aPos, aNextPos, aCurrentExceptionRegion)
        {
            Value = aValue;
            ParameterCount = 0;
            HasReturnValue = false;
        }

        public override int GetNumberOfStackPops(MethodBase aMethod)
        {
            switch (OpCode)
            {
                case Code.Calli:
                    return 1 + ParameterCount;
                default:
                    throw new NotImplementedException("OpCode '" + OpCode + "' not implemented!");
            }
        }

        public override int GetNumberOfStackPushes(MethodBase aMethod)
        {
            switch (OpCode)
            {
                case Code.Calli:
                    return HasReturnValue ? 1 : 0;
                default:
                    throw new NotImplementedException("OpCode '" + OpCode + "' not implemented!");
            }
        }

        protected override void DoInitStackAnalysis(MethodBase aMethod)
        {
            base.DoInitStackAnalysis(aMethod);
            
            if (OpCode == Code.Calli && HasReturnValue)
            {
                StackPushTypes[0] = typeof(int);
            }
        }

        public override void DoInterpretStackTypes() { }
    }
}
