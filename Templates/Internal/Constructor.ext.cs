using Aikixd.CodeGeneration.CSharp.TypeInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aikixd.CodeGeneration.TemplatesT4.Templates.Internal
{
    partial class Constructor
    {
        internal string Name { get; }
        protected IEnumerable<DataMemberInfo> InvolvedMembers { get; }

        public Constructor(string name, IEnumerable<DataMemberInfo> involvedMembers)
        {
            this.Name = name;
            this.InvolvedMembers = involvedMembers;
        }

        protected string MakeConstructorParameters()
        {
            return string.Join(
                ", ",
                this.InvolvedMembers
                .Select(x => $"{x.Type.FullName} {x.Name}"));
        }
    }
}
