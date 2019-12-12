using Aikixd.CodeGeneration.CSharp.TypeInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aikixd.CodeGeneration.TemplatesT4.Templates.Internal
{
    partial class TypeNestingStart
    {
        public TypeNestingStart(TypeInfo classInfo)
        {
            this.TypeInfo = classInfo;
        }

        protected TypeInfo TypeInfo { get; }

        protected IEnumerable<TypeInfo> Nesting
        {
            get
            {
                var l = new LinkedList<TypeInfo>();

                var n = this.TypeInfo.ContainingType;

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
