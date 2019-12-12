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
        protected DataTypeInfo DataTypeInfo { get; }
        protected TypeInfo TypeInfo => this.DataTypeInfo.TypeInfo;

        public EqualsConformity(DataTypeInfo dataTypeInfo)
        {
            this.DataTypeInfo = dataTypeInfo;
        }
    }
}
