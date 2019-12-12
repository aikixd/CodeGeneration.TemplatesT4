using Aikixd.CodeGeneration.CSharp.TypeInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aikixd.CodeGeneration.TemplatesT4.Templates.Internal
{
    internal class ClassMaker
    {
        public static string MakeTypedClassName(ClassInfo nfo)
        {
            return MakeTypedTypeName(nfo.TypeInfo);
        }

        public static string MakeTypedStructName(StructInfo nfo)
        {
            return MakeTypedTypeName(nfo.TypeInfo);
        }

        public static string MakeTypedTypeName(TypeInfo nfo)
        {
            if (nfo.TypeParameters.Count() == 0)
                return nfo.Name;

            return $"{nfo.Name}<{string.Join(", ", nfo.TypeParameters.Select(x => x.Name))}>";
        }

        public static string MakeGetHashCode(IEnumerable<string> members)
        {
            return new HashCodeMethod(members).TransformText();
        }

        public static string MakeTypeNestingStart(TypeInfo typeInfo)
        {
            return new TypeNestingStart(typeInfo).TransformText();
        }

        public static string MakeTypeNestingEnd(TypeInfo typeInfo)
        {
            return new TypeNestingEnd(typeInfo).TransformText();
        }

        public static string MakeEqualsConformity(DataTypeInfo dataTypeInfo)
        {
            return new EqualsConformity(dataTypeInfo).TransformText();
        }
    }
}
