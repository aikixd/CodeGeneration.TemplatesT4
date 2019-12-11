using Aikixd.CodeGeneration.CSharp.TypeInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aikixd.CodeGeneration.TemplatesT4.Templates.Internal
{
    partial class ClassNestingEnd
    {
        public ClassNestingEnd(ClassInfo classInfo)
        {
            this.ClassInfo = classInfo;
        }

        protected ClassInfo ClassInfo { get; }

        protected IEnumerable<TypeInfo> Nesting
        {
            get
            {
                var l = new LinkedList<TypeInfo>();

                var n = this.ClassInfo.TypeInfo.ContainingType;

                while (n != null)
                {
                    l.AddFirst(n);
                    n = n.ContainingType;
                }

                return l;
            }
        }
    }
}
