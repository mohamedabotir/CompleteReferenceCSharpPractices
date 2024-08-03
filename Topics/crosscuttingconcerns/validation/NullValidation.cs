namespace validation;

[AttributeUsage(AttributeTargets.Property|AttributeTargets.Parameter|AttributeTargets.ReturnValue)]
class NullValidation :Attribute{

}
[Flags]public enum ValidationFlags {
    Properties = 1,
    Methods = 2,
    Arguments = 4,
    OutValues = 8,
    ReturnValues = 16,
    NonPublic = 32,
    AllPublicArguments = Properties | Methods | Arguments,
    AllPublic = AllPublicArguments | OutValues | ReturnValues,
    All = AllPublic | NonPublic
}