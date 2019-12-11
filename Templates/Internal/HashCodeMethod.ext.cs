using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aikixd.CodeGeneration.TemplatesT4.Templates.Internal
{
    partial class HashCodeMethod
    {
        public HashCodeMethod(IEnumerable<string> memberNames)
        {
            this.MemberNames = memberNames ?? throw new ArgumentNullException(nameof(memberNames));
        }

        public IEnumerable<string> MemberNames { get; }
    }
}
