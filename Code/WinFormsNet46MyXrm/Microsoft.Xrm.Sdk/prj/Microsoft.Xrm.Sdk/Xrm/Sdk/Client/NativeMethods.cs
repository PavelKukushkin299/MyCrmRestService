// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.NativeMethods
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Microsoft.Xrm.Sdk.Client
{
  [SecurityCritical]
  internal static class NativeMethods
  {
    [SecurityCritical]
    [DllImport("Rpcrt4", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
    public static extern long UuidCreateSequential(ref Guid ptrGuid);
  }
}
