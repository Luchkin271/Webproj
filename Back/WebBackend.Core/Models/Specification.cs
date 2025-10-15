namespace WebBackend.Core.Models
{
    public class Specification
    {
        public string Name {  get; }
        public string Context { get; }
        private Specification(string name, string context)
        {
            Name = name;
            Context = context;
        }
        public static (Specification Specification, string Error) Create(string name, string context)
        {
            var error = string.Empty;

            var specification = new Specification(name, context);

            return (specification, error);
        }
    }
}
