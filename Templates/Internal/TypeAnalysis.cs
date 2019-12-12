using Aikixd.CodeGeneration.CSharp.TypeInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aikixd.CodeGeneration.TemplatesT4.Templates.Internal
{
    internal static class TypeAnalysis
    {
        public static IEnumerable<DataMemberInfo> GenuineDataMembers(DataTypeInfo DataTypeInfo)
        {
            return
                DataTypeInfo
                .DataMembers
                .Where(filter)
                .Cast<DataMemberInfo>();

            bool filter(MemberInfo mi)
            {
                return
                    mi.GetType() == typeof(FieldMemberInfo) ||
                    mi.GetType() == typeof(PropertyMemberInfo) && ((PropertyMemberInfo)mi).IsAutoProperty == true;
            }
        }

        public static string GetTypeKeyword(TypeInfo typeInfo)
        {
            return
                typeInfo.Kind == TypeKind.Class     ? "class"     :
                typeInfo.Kind == TypeKind.Struct    ? "struct"    :
                typeInfo.Kind == TypeKind.Interface ? "interface" :
                throw new ArgumentOutOfRangeException(
                    nameof(typeInfo),
                    typeInfo,
                    "Provided TypeInfo is of unknown type kind.");
        }
    }

    //internal static class EqualityThroughHelper
    //{
    //    public static IEnumerable<string> MemberNames(ClassInfo classInfo)
    //    {
    //        throw new NotImplementedException();

    //        //return
    //        //    ((object[])
    //        //    classInfo.Attributes
    //        //    .Where(x => x.Type.Name == nameof(GenEqualityThroughAttribute))
    //        //    .Single()
    //        //    .PassedArguments
    //        //    .First())
    //        //    .Cast<string>();
    //    }
    //}
}
