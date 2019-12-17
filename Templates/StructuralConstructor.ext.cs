using Aikixd.CodeGeneration.CSharp.TypeInfo;
using Aikixd.CodeGeneration.TemplatesT4.Templates.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aikixd.CodeGeneration.TemplatesT4.Templates
{
    [Flags]
    public enum Modifier
    {
        None = 0,
        NotEmpty = 1
    }
    
    public class MemberModifier
    {
        public MemberInfo Member { get; }
        public Modifier Modifier { get; }

        public MemberModifier(MemberInfo member, Modifier modifier)
        {
            this.Member = member;
            this.Modifier = modifier;
        }
    }
    
    partial class StructuralConstructor
    {
        public DataTypeInfo DataTypeInfo { get; }
        public IEnumerable<MemberModifier> Modifiers { get; }
        public TypeInfo TypeInfo { get; }

        public StructuralConstructor(DataTypeInfo dataTypeInfo, IEnumerable<MemberModifier> modifiers)
        {
            this.DataTypeInfo = dataTypeInfo;
            this.Modifiers = modifiers;
            this.TypeInfo = dataTypeInfo.TypeInfo;
        }

        protected IEnumerable<(string name, TypeInfo type)> GetDataMembers()
        {
            return this.DataTypeInfo.DataMembers
                .Where(filter)
                .Select(map);

            bool filter(MemberInfo mi)
            {
                return
                    (mi.GetType() == typeof(FieldMemberInfo) ||
                    mi.GetType() == typeof(PropertyMemberInfo) && ((PropertyMemberInfo)mi).IsAutoProperty == true) &&
                    mi.IsStatic == false;
            }

            (string, TypeInfo) map(MemberInfo x)
            {
                switch (x)
                {
                    case PropertyMemberInfo p:
                        return (p.Name, p.Type);

                    case FieldMemberInfo p:
                        return (p.Name, p.Type);

                    default:
                        throw new InvalidOperationException($"Expected propery or field member. Got: {x.GetType()}");
                }
            }
        }

        private IEnumerable<Guard> GetGuards()
        {
            return
                this
                .Modifiers
                .Where(x => x.Modifier != 0)
                .SelectMany(convert);
                
            IEnumerable<Guard> convert(MemberModifier memberModifier)
            {
                var list = new LinkedList<Guard>();

                if (memberModifier.Modifier.HasFlag(Modifier.NotEmpty))
                {
                    list.AddLast(new Guard(
                        $"System.String.IsNullOrEmpty({ memberModifier.Member.Name })",
                        $"throw new System.ArgumentOutOfRangeException(\"{ memberModifier.Member.Name } must not be empty.\")"));
                }

                return list;
            }
        }

        protected string MakeConstructorParameters()
        {
            return string.Join(
                ", ",
                this.GetDataMembers()
                .Select(x => $"{x.type.FullName} {x.name}"));
        }
    }
}
