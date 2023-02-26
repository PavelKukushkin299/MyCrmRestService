// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.Utilites
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Diagnostics;
using System.Reflection;

namespace Microsoft.Xrm.Sdk.Client
{
  internal static class Utilites
  {
    public static TimeSpan DefaultTimeout = new TimeSpan(0, 0, 2, 0);
    private static string _xrmSdkAssemblyFileVersion;

    internal static string GetXrmSdkAssemblyFileVersion()
    {
      if (string.IsNullOrEmpty(Utilites._xrmSdkAssemblyFileVersion))
      {
        string[] strArray = new string[1]
        {
          "Microsoft.Xrm.Sdk.dll"
        };
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (string str in strArray)
        {
          foreach (Assembly assembly in assemblies)
          {
            if (assembly.ManifestModule.Name.Equals(str, StringComparison.OrdinalIgnoreCase))
              Utilites._xrmSdkAssemblyFileVersion = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
          }
        }
      }
      return Utilites._xrmSdkAssemblyFileVersion;
    }
  }
}
