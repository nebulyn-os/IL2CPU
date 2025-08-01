using System;
using Cosmos.IL2CPU.ILOpCodes;
using XSharp;
using XSharp.Assembler;
using static XSharp.XSRegisters;

namespace Cosmos.IL2CPU.X86.IL
{
    [OpCode(ILOpCode.Code.Calli)]
    public class Calli : ILOp
    {
        public Calli(Assembler aAsmblr)
            : base(aAsmblr)
        {
        }

        public override void Execute(Il2cpuMethodInfo aMethod, ILOpCode aOpCode)
        {
            var xOpSig = (OpSig)aOpCode;
            XS.Pop(EAX);
            XS.Call(EAX);
            if (xOpSig.HasReturnValue)
            {
                XS.Push(EAX);
            }
        }
    }
}
