using Aikixd.CodeGeneration.CSharp.TypeInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aikixd.CodeGeneration.TemplatesT4.Templates.Internal
{
    partial class EqualsConformity
    {
        protected ClassInfo ClassInfo { get; }

        public EqualsConformity(ClassInfo classInfo)
        {
            this.ClassInfo = classInfo;
        }
    }
}
