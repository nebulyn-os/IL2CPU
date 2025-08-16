using System;
using IL2CPU.API;


namespace Cosmos.IL2CPU.X86.IL
{
	[Cosmos.IL2CPU.OpCode(ILOpCode.Code.Ldvirtftn)]
	public class Ldvirtftn: ILOp
	{
		public Ldvirtftn(XSharp.Assembler.Assembler aAsmblr):base(aAsmblr)
		{
		}

	public override void Execute(Il2cpuMethodInfo aMethod, ILOpCode aOpCode) {
		// Stack prior: [objectref]
		// Pops object reference, pushes function pointer.
		DoNullReferenceCheck(Assembler, DebugEnabled, 0);
		// For now we resolve to the method's label directly. True virtual dispatch for delegates will occur at callsite.
		// This is a simplification: proper Ldvirtftn should walk vtable using the instance type.
		Cosmos.IL2CPU.ILOpCodes.OpMethod opMethod = (Cosmos.IL2CPU.ILOpCodes.OpMethod)aOpCode;
		XSharp.XS.Pop(XSharp.XSRegisters.EAX); // discard instance (was only for null check)
		XSharp.XS.Push(LabelName.Get(opMethod.Value));
	}

    
		// using System;
		// using System.IO;
		// 
		// 
		// using CPU = XSharp.Assembler.x86;
		// 
		// namespace Cosmos.IL2CPU.IL.X86 {
		// 	[XSharp.Assembler.OpCode(OpCodeEnum.Ldvirtftn)]
		// 	public class Ldvirtftn: Op {
		//         private string mNextLabel;
		// 	    private string mCurLabel;
		// 	    private uint mCurOffset;
		// 	    private MethodInformation mMethodInformation;
		// 		public Ldvirtftn(ILReader aReader, MethodInformation aMethodInfo)
		// 			: base(aReader, aMethodInfo) {
		//              mMethodInformation = aMethodInfo;
		// 		    mCurOffset = aReader.Position;
		// 		    mCurLabel = IL.Op.GetInstructionLabel(aReader);
		//             mNextLabel = IL.Op.GetInstructionLabel(aReader.NextPosition);
		// 		}
		// 		public override void DoAssemble() {
		//             EmitNotImplementedException(Assembler, GetServiceProvider(), "Ldvirtftn: This has not been implemented at all yet!", mCurLabel, mMethodInformation, mCurOffset, mNextLabel);
		// 		}
		// 	}
		// }
		
	}
}
