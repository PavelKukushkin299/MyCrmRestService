// Decompiled with JetBrains decompiler
// Type: NSspi.NativeMethods
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace NSspi
{
  internal static class NativeMethods
  {
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [DllImport("Secur32.dll", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus FreeContextBuffer(IntPtr buffer);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [DllImport("Secur32.dll", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus QuerySecurityPackageInfo(
      string packageName,
      ref IntPtr pkgInfo);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [DllImport("Secur32.dll", CharSet = CharSet.Unicode)]
    internal static extern SecurityStatus EnumerateSecurityPackages(
      ref int numPackages,
      ref IntPtr pkgInfoArry);

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    [DllImport("Kernel32.dll", SetLastError = true)]
    internal static extern bool CloseHandle(IntPtr handle);
  }
}
