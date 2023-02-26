// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.AppDomainBasedKnownProxyTypesProvider
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
  internal sealed class AppDomainBasedKnownProxyTypesProvider : KnownProxyTypesProvider
  {
    private static Dictionary<string, Type> _nameMap;
    private static Dictionary<Type, string> _typeMap;
    private Dictionary<string, Type> _currentMap;

    [SecuritySafeCritical]
    internal AppDomainBasedKnownProxyTypesProvider()
    {
      AppDomainBasedKnownProxyTypesProvider._nameMap = new Dictionary<string, Type>();
      AppDomainBasedKnownProxyTypesProvider._typeMap = new Dictionary<Type, string>();
      AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(this.CurrentDomain_AssemblyLoad);
      this.InitializeLoadedAssemblies();
    }

    public override Type GetTypeForName(string name, Assembly notUsed)
    {
      if (AppDomainBasedKnownProxyTypesProvider._nameMap.ContainsKey(name))
        return AppDomainBasedKnownProxyTypesProvider._nameMap[name];
      lock (KnownProxyTypesProvider.ThisLock)
      {
        if (AppDomainBasedKnownProxyTypesProvider._nameMap.ContainsKey(name))
          return AppDomainBasedKnownProxyTypesProvider._nameMap[name];
      }
      return (Type) null;
    }

    public override string GetNameForType(Type type)
    {
      if (AppDomainBasedKnownProxyTypesProvider._typeMap.ContainsKey(type))
        return AppDomainBasedKnownProxyTypesProvider._typeMap[type];
      lock (KnownProxyTypesProvider.ThisLock)
      {
        if (AppDomainBasedKnownProxyTypesProvider._typeMap.ContainsKey(type))
          return AppDomainBasedKnownProxyTypesProvider._typeMap[type];
      }
      return (string) null;
    }

    protected override void AddTypeMapping(Assembly assembly, Type type, string proxyName)
    {
      if (this._currentMap == null)
        this.OnBeginLoadTypes(assembly);
      if (AppDomainBasedKnownProxyTypesProvider._nameMap.ContainsKey(proxyName))
        throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "A proxy type with the name {0} has been defined by another assembly. Current type: {1}, Existing type: {2}", (object) proxyName, (object) type.AssemblyQualifiedName, (object) AppDomainBasedKnownProxyTypesProvider._nameMap[proxyName].AssemblyQualifiedName), proxyName);
      if (this._currentMap.ContainsKey(proxyName))
        throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "A proxy type with the name {0} has been defined by an assembly. Current type: {1}, Existing type: {2}", (object) proxyName, (object) type.AssemblyQualifiedName, (object) this._currentMap[proxyName].AssemblyQualifiedName), proxyName);
      this._currentMap.Add(proxyName, type);
    }

    protected override void OnBeginLoadTypes(Assembly targetAssembly) => this._currentMap = new Dictionary<string, Type>();

    protected override void OnEndLoadTypes()
    {
      if (this._currentMap != null && this._currentMap.Count > 0)
      {
        foreach (string key in this._currentMap.Keys)
        {
          AppDomainBasedKnownProxyTypesProvider._nameMap[key] = this._currentMap[key];
          AppDomainBasedKnownProxyTypesProvider._typeMap[this._currentMap[key]] = key;
        }
      }
      this._currentMap = (Dictionary<string, Type>) null;
    }

    protected override void OnErrorLoadTypes() => this._currentMap = (Dictionary<string, Type>) null;

    private void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args) => this.RegisterAssembly(args.LoadedAssembly);
  }
}
