using Aikixd.CodeGeneration.CSharp.TypeInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aikixd.CodeGeneration.TemplatesT4.Templates
{
    partial class EqualityThroughMembers
    {
        public ClassInfo ClassInfo { get; }
        protected IEnumerable<string> StatedMembers { get; }

        public EqualityThroughMembers(ClassInfo classInfo, IEnumerable<string> statedMembers)
        {
            this.ClassInfo = classInfo ?? throw new ArgumentNullException(nameof(classInfo));
            this.StatedMembers = statedMembers ?? throw new ArgumentNullException(nameof(statedMembers));
        }


        protected string MakeGetHashCode()
        {
            return new Internal.HashCodeMethod(this.StatedMembers).TransformText();
        }

        protected string MakeClassNestingStart()
        {
            return new Internal.ClassNestingStart(this.ClassInfo).TransformText();
        }

        protected string MakeClassNestingEnd()
        {
            return new Internal.ClassNestingEnd(this.ClassInfo).TransformText();
        }
    }
}
