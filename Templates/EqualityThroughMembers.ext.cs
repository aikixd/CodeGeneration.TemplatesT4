using Aikixd.CodeGeneration.CSharp.TypeInfo;
using Aikixd.CodeGeneration.TemplatesT4.Templates.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aikixd.CodeGeneration.TemplatesT4.Templates
{
    partial class EqualityThroughMembers
    {
        public DataTypeInfo DataTypeInfo { get; }
        public TypeInfo TypeInfo => this.DataTypeInfo.TypeInfo;
        protected IEnumerable<string> StatedMembers { get; }

        public EqualityThroughMembers(DataTypeInfo dataTypeInfo)
            : this(
                dataTypeInfo,
                TypeAnalysis
                    .GenuineDataMembers(dataTypeInfo)
                    .Where(m => m.IsStatic == false)
                    .Select(m => m.Name))
        { }

        public EqualityThroughMembers(DataTypeInfo classInfo, IEnumerable<string> statedMembers)
        {
            this.DataTypeInfo = classInfo ?? throw new ArgumentNullException(nameof(classInfo));
            this.StatedMembers = statedMembers ?? throw new ArgumentNullException(nameof(statedMembers));
        }


        protected string MakeGetHashCode()
        {
            return new Internal.HashCodeMethod(this.StatedMembers).TransformText();
        }
    }
}
