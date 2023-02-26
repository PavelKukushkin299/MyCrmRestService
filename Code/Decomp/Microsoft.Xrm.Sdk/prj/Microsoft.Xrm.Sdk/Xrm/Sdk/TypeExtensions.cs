// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.TypeExtensions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;

namespace Microsoft.Xrm.Sdk
{
  internal static class TypeExtensions
  {
    public static string GetLogicalName(this Type type) => KnownProxyTypesProvider.GetInstance(true).GetNameForType(type);

    public static Type GetUnderlyingType(this Type type)
    {
      Type underlyingType = Nullable.GetUnderlyingType(type);
      return (object) underlyingType != null ? underlyingType : type;
    }

    public static bool IsA<T>(this Type type) => type.IsA(typeof (T));

    public static bool IsA(this Type type, Type referenceType) => referenceType != (Type) null && referenceType.IsAssignableFrom(type);
  }
}
