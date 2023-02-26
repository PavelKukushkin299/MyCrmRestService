// Decompiled with JetBrains decompiler
// Type: NSspi.TimeStamp
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;

namespace NSspi
{
  public struct TimeStamp
  {
    public static readonly DateTime Epoch = new DateTime(1601, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    private long time;

    public DateTime ToDateTime() => (ulong) (this.time + TimeStamp.Epoch.Ticks) > (ulong) DateTime.MaxValue.Ticks ? DateTime.MaxValue : DateTime.FromFileTimeUtc(this.time);
  }
}
