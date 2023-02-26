// Decompiled with JetBrains decompiler
// Type: NSspi.Contexts.SafeTokenHandle
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.Runtime.InteropServices;

namespace NSspi.Contexts
{
  public class SafeTokenHandle : SafeHandle
  {
    public SafeTokenHandle()
      : base(IntPtr.Zero, true)
    {
    }

    public override bool IsInvalid => this.handle == IntPtr.Zero || this.handle == new IntPtr(-1);

    protected override bool ReleaseHandle()
    {
      NSspi.NativeMethods.CloseHandle(this.handle);
      return true;
    }
  }
}
