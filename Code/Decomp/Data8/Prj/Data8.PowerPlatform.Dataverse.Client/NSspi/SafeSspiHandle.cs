// Decompiled with JetBrains decompiler
// Type: NSspi.SafeSspiHandle
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace NSspi
{
  public abstract class SafeSspiHandle : SafeHandle
  {
    internal RawSspiHandle rawHandle;

    protected SafeSspiHandle()
      : base(IntPtr.Zero, true)
    {
      this.rawHandle = new RawSspiHandle();
    }

    public override bool IsInvalid => this.IsClosed || this.rawHandle.IsZero();

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    protected override bool ReleaseHandle()
    {
      this.rawHandle.SetInvalid();
      return true;
    }
  }
}
