
namespace JasonParserManual
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MyInfoAttribute : Attribute
    {
        public string Description { get; }

        public MyInfoAttribute(string description)
        {
            Description = description;
        }
    }
}