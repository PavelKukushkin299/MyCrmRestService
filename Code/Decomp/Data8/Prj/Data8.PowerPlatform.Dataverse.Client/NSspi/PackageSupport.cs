// Decompiled with JetBrains decompiler
// Type: NSspi.PackageSupport
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NSspi
{
  public static class PackageSupport
  {
    public static SecPkgInfo GetPackageCapabilities(string packageName)
    {
      SecurityStatus errorCode = SecurityStatus.InternalError;
      IntPtr pkgInfo = new IntPtr();
      SecPkgInfo structure = new SecPkgInfo();
      RuntimeHelpers.PrepareConstrainedRegions();
      try
      {
      }
      finally
      {
        errorCode = NativeMethods.QuerySecurityPackageInfo(packageName, ref pkgInfo);
        if (pkgInfo != IntPtr.Zero)
        {
          try
          {
            if (errorCode == SecurityStatus.OK)
              Marshal.PtrToStructure<SecPkgInfo>(pkgInfo, structure);
          }
          finally
          {
            int num = (int) NativeMethods.FreeContextBuffer(pkgInfo);
          }
        }
      }
      if (errorCode != SecurityStatus.OK)
        throw new SSPIException("Failed to query security package provider details", errorCode);
      return structure;
    }

    public static SecPkgInfo[] EnumeratePackages()
    {
      SecurityStatus errorCode = SecurityStatus.InternalError;
      SecPkgInfo[] secPkgInfoArray = (SecPkgInfo[]) null;
      int numPackages = 0;
      int num1 = Marshal.SizeOf(typeof (SecPkgInfo));
      IntPtr pkgInfoArry = new IntPtr();
      RuntimeHelpers.PrepareConstrainedRegions();
      try
      {
      }
      finally
      {
        errorCode = NativeMethods.EnumerateSecurityPackages(ref numPackages, ref pkgInfoArry);
        if (pkgInfoArry != IntPtr.Zero)
        {
          try
          {
            if (errorCode == SecurityStatus.OK)
            {
              secPkgInfoArray = new SecPkgInfo[numPackages];
              for (int index = 0; index < numPackages; ++index)
                secPkgInfoArray[index] = new SecPkgInfo();
              for (int index = 0; index < numPackages; ++index)
                Marshal.PtrToStructure<SecPkgInfo>(IntPtr.Add(pkgInfoArry, index * num1), secPkgInfoArray[index]);
            }
          }
          finally
          {
            int num2 = (int) NativeMethods.FreeContextBuffer(pkgInfoArry);
          }
        }
      }
      if (errorCode != SecurityStatus.OK)
        throw new SSPIException("Failed to enumerate security package providers", errorCode);
      return secPkgInfoArray;
    }
  }
}
