namespace LoggingAspect;

using PostSharp.Aspects;
using PostSharp.Serialization;

[PSerializable]
class LoggingAspect:OnMethodBoundaryAspect{
    public override void OnException(MethodExecutionArgs args)
    {
        Console.WriteLine(args.Exception.Message+" this is from interceptor");
        base.OnException(args);
    }
   
}