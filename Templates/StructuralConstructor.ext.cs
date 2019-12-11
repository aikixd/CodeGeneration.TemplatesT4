﻿using Aikixd.CodeGeneration.CSharp.TypeInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aikixd.CodeGeneration.TemplatesT4.Templates
{
    partial class StructuralConstructor
    {
        public ClassInfo ClassInfo { get; }

        public StructuralConstructor(ClassInfo classInfo)
        {
            this.ClassInfo = classInfo;
        }

        protected IEnumerable<(string name, TypeInfo type)> GetDataMembers()
        {
            return this.ClassInfo.Members
                .Where(filter)
                .Select(map);

            bool filter(MemberInfo mi)
            {
                return
                    (mi.GetType() == typeof(FieldMemberInfo) ||
                    mi.GetType() == typeof(PropertyMemberInfo) && ((PropertyMemberInfo)mi).IsAutoProperty == true) &&
                    mi.IsStatic == false;
            }

            (string, TypeInfo) map(MemberInfo x)
            {
                switch (x)
                {
                    case PropertyMemberInfo p:
                        return (p.Name, p.Type);

                    case FieldMemberInfo p:
                        return (p.Name, p.Type);

                    default:
                        throw new InvalidOperationException($"Expected propery or field member. Got: {x.GetType()}");
                }
            }
        }

        protected string MakeConstructorParameters()
        {
            return string.Join(
                ", ",
                this.GetDataMembers()
                .Select(x => $"{x.type.FullName} {x.name}"));
        }
    }
}