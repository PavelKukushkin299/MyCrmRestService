// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Linq.MemberInfoExtensions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Microsoft.Xrm.Sdk.Linq
{
  internal static class MemberInfoExtensions
  {
    private static readonly ConcurrentDictionary<MemberInfoExtensions.MemberInfoAttributeType, IEnumerable<object>> _memberInfoToAttributesLookup = new ConcurrentDictionary<MemberInfoExtensions.MemberInfoAttributeType, IEnumerable<object>>(8, 11);

    public static IEnumerable<T> GetCustomAttributes<T>(this MemberInfo info) where T : Attribute
    {
      MemberInfoExtensions.MemberInfoAttributeType key = new MemberInfoExtensions.MemberInfoAttributeType()
      {
        MemberInfo = info,
        Type = typeof (T)
      };
      return MemberInfoExtensions._memberInfoToAttributesLookup.GetOrAdd(key, (Func<MemberInfoExtensions.MemberInfoAttributeType, IEnumerable<object>>) (_ => (IEnumerable<object>) info.GetCustomAttributes(typeof (T), true))).Cast<T>();
    }

    public static T GetFirstOrDefaultCustomAttribute<T>(this MemberInfo info) where T : Attribute => info.GetCustomAttributes<T>().FirstOrDefault<T>();

    public static string GetLogicalName(this MemberInfo property)
    {
      AttributeLogicalNameAttribute defaultCustomAttribute1 = property.GetFirstOrDefaultCustomAttribute<AttributeLogicalNameAttribute>();
      if (defaultCustomAttribute1 != null)
        return defaultCustomAttribute1.LogicalName;
      EntityLogicalNameAttribute defaultCustomAttribute2 = property.GetFirstOrDefaultCustomAttribute<EntityLogicalNameAttribute>();
      if (defaultCustomAttribute2 != null)
        return defaultCustomAttribute2.LogicalName;
      return property.GetFirstOrDefaultCustomAttribute<RelationshipSchemaNameAttribute>()?.SchemaName;
    }

    private struct MemberInfoAttributeType
    {
      public MemberInfo MemberInfo;
      public Type Type;
    }
  }
}
