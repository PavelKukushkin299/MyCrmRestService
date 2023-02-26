// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ProxyTypesAssemblyAttribute
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;

namespace Microsoft.Xrm.Sdk.Client
{
  [AttributeUsage(AttributeTargets.Assembly)]
  public sealed class ProxyTypesAssemblyAttribute : Attribute
  {
    private bool _containsSharedContracts;

    public ProxyTypesAssemblyAttribute()
    {
    }

    internal ProxyTypesAssemblyAttribute(bool containsSharedContracts) => this._containsSharedContracts = containsSharedContracts;

    internal bool ContainsSharedContracts => this._containsSharedContracts;
  }
}
