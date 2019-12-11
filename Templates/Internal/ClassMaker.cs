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
            return MakeTypedClassName(nfo.TypeInfo);
        }

        public static string MakeTypedClassName(TypeInfo nfo)
        {
            if (nfo.TypeParameters.Count() == 0)
                return nfo.Name;

            return $"{nfo.Name}<{string.Join(", ", nfo.TypeParameters.Select(x => x.Name))}>";
        }

        public static string MakeGetHashCode(IEnumerable<string> members)
        {
            return new HashCodeMethod(members).TransformText();
        }

        public static string MakeClassNestingStart(ClassInfo classInfo)
        {
            return new ClassNestingStart(classInfo).TransformText();
        }

        public static string MakeClassNestingEnd(ClassInfo classInfo)
        {
            return new ClassNestingEnd(classInfo).TransformText();
        }

        public static string MakeEqualsConformity(ClassInfo classInfo)
        {
            return new EqualsConformity(classInfo).TransformText();
        }
    }
}
