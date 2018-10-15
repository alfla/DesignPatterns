using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    public class CodeBuilder
    {
        public string ClassName;
        public List<Field> Fields = new List<Field>();
        private const int indentSize = 2;

        public CodeBuilder(string className)
        {
            ClassName = className ?? throw new ArgumentNullException($"paramName: {nameof(className)}");
        }

        public CodeBuilder AddField(string name, string type)
        {
            Field field = new Field { Name = name, Type = type };
            Fields.Add(field);
            return this;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var i = new string(' ', indentSize);

            sb.AppendLine($"public class {ClassName}");
            sb.AppendLine("{");
            foreach (var field in Fields)
            {
                sb.AppendLine($"{i}public {field.Type} {field.Name};");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }

    public class Field
    {
        public string Name, Type;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cb = new CodeBuilder("Person")
                .AddField("Name", "string")
                .AddField("Age", "int");
            Console.WriteLine(cb);
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
