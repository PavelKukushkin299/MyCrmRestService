// Decompiled with JetBrains decompiler
// Type: NSspi.RawSspiHandle
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace NSspi
{
  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  internal struct RawSspiHandle
  {
    private IntPtr lowPart;
    private IntPtr highPart;

    public bool IsZero() => this.lowPart == IntPtr.Zero && this.highPart == IntPtr.Zero;

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    public void SetInvalid()
    {
      this.lowPart = IntPtr.Zero;
      this.highPart = IntPtr.Zero;
    }
  }
}
