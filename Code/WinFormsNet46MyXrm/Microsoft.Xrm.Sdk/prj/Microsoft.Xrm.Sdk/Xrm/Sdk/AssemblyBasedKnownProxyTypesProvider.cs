// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.AssemblyBasedKnownProxyTypesProvider
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Security;

namespace Microsoft.Xrm.Sdk
{
  internal sealed class AssemblyBasedKnownProxyTypesProvider : KnownProxyTypesProvider
  {
    private static Dictionary<Assembly, AssemblyBasedKnownProxyTypesProvider.EarlyBoundTypeMap> _earlyBoundTypesMapByAssembly;
    private static Dictionary<Assembly, AssemblyBasedKnownProxyTypesProvider.EarlyBoundNameMap> _earlyBoundNamesMapByAssembly;
    private Assembly _currentlyLoadingAssembly;

    [SecuritySafeCritical]
    internal AssemblyBasedKnownProxyTypesProvider()
    {
      AssemblyBasedKnownProxyTypesProvider._earlyBoundTypesMapByAssembly = new Dictionary<Assembly, AssemblyBasedKnownProxyTypesProvider.EarlyBoundTypeMap>();
      AssemblyBasedKnownProxyTypesProvider._earlyBoundNamesMapByAssembly = new Dictionary<Assembly, AssemblyBasedKnownProxyTypesProvider.EarlyBoundNameMap>();
    }

    public override Type GetTypeForName(string name, Assembly proxyTypesAssembly)
    {
      if (proxyTypesAssembly == (Assembly) null)
        return (Type) null;
      this.RegisterAssembly(proxyTypesAssembly);
      lock (KnownProxyTypesProvider.ThisLock)
      {
        AssemblyBasedKnownProxyTypesProvider.EarlyBoundTypeMap earlyBoundTypeMap = (AssemblyBasedKnownProxyTypesProvider.EarlyBoundTypeMap) null;
        if (AssemblyBasedKnownProxyTypesProvider._earlyBoundTypesMapByAssembly.TryGetValue(proxyTypesAssembly, out earlyBoundTypeMap))
        {
          if (earlyBoundTypeMap.ContainsKey(name))
            return earlyBoundTypeMap[name];
        }
      }
      return (Type) null;
    }

    public override string GetNameForType(Type type)
    {
      Assembly assembly = type.Assembly;
      this.RegisterAssembly(assembly);
      lock (KnownProxyTypesProvider.ThisLock)
      {
        AssemblyBasedKnownProxyTypesProvider.EarlyBoundNameMap earlyBoundNameMap = (AssemblyBasedKnownProxyTypesProvider.EarlyBoundNameMap) null;
        if (AssemblyBasedKnownProxyTypesProvider._earlyBoundNamesMapByAssembly.TryGetValue(assembly, out earlyBoundNameMap))
        {
          if (earlyBoundNameMap.ContainsKey(type))
            return earlyBoundNameMap[type];
        }
      }
      return (string) null;
    }

    protected override void AddTypeMapping(Assembly assembly, Type type, string proxyName)
    {
      AssemblyBasedKnownProxyTypesProvider.EarlyBoundTypeMap earlyBoundTypeMap = (AssemblyBasedKnownProxyTypesProvider.EarlyBoundTypeMap) null;
      AssemblyBasedKnownProxyTypesProvider._earlyBoundTypesMapByAssembly.TryGetValue(assembly, out earlyBoundTypeMap);
      if (earlyBoundTypeMap == null)
      {
        earlyBoundTypeMap = new AssemblyBasedKnownProxyTypesProvider.EarlyBoundTypeMap();
        AssemblyBasedKnownProxyTypesProvider._earlyBoundTypesMapByAssembly[assembly] = earlyBoundTypeMap;
      }
      if (earlyBoundTypeMap.ContainsKey(proxyName))
        throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "A proxy type with the name {0} has been defined by multiple types. Current type: {1}, Existing type: {2}", (object) proxyName, (object) type.AssemblyQualifiedName, (object) earlyBoundTypeMap[proxyName].AssemblyQualifiedName), proxyName);
      earlyBoundTypeMap.Add(proxyName, type);
      AssemblyBasedKnownProxyTypesProvider.EarlyBoundNameMap earlyBoundNameMap = (AssemblyBasedKnownProxyTypesProvider.EarlyBoundNameMap) null;
      AssemblyBasedKnownProxyTypesProvider._earlyBoundNamesMapByAssembly.TryGetValue(assembly, out earlyBoundNameMap);
      if (earlyBoundNameMap == null)
      {
        earlyBoundNameMap = new AssemblyBasedKnownProxyTypesProvider.EarlyBoundNameMap();
        AssemblyBasedKnownProxyTypesProvider._earlyBoundNamesMapByAssembly[assembly] = earlyBoundNameMap;
      }
      if (earlyBoundNameMap.ContainsKey(type))
        throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "A proxy type with the name {0} has been defined by multiple types. Current type: {1}, Existing type: {2}", (object) proxyName, (object) type.AssemblyQualifiedName, (object) type.AssemblyQualifiedName), proxyName);
      earlyBoundNameMap.Add(type, proxyName);
    }

    protected override void OnBeginLoadTypes(Assembly targetAssembly) => this._currentlyLoadingAssembly = targetAssembly;

    protected override void OnEndLoadTypes() => this._currentlyLoadingAssembly = (Assembly) null;

    protected override void OnErrorLoadTypes()
    {
      if (this._currentlyLoadingAssembly != (Assembly) null && AssemblyBasedKnownProxyTypesProvider._earlyBoundTypesMapByAssembly.ContainsKey(this._currentlyLoadingAssembly))
        AssemblyBasedKnownProxyTypesProvider._earlyBoundTypesMapByAssembly.Remove(this._currentlyLoadingAssembly);
      this._currentlyLoadingAssembly = (Assembly) null;
    }

    private sealed class EarlyBoundTypeMap : Dictionary<string, Type>
    {
    }

    private sealed class EarlyBoundNameMap : Dictionary<Type, string>
    {
    }
  }
}
