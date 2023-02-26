// Decompiled with JetBrains decompiler
// Type: NSspi.Buffers.BufferType
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

namespace NSspi.Buffers
{
  internal enum BufferType
  {
    ReadOnlyFlag = -2147483648, // 0x80000000
    Empty = 0,
    Data = 1,
    Token = 2,
    Parameters = 3,
    Missing = 4,
    Extra = 5,
    Trailer = 6,
    Header = 7,
    Padding = 9,
    Stream = 10, // 0x0000000A
    ChannelBindings = 14, // 0x0000000E
    TargetHost = 16, // 0x00000010
    ReadOnlyWithChecksum = 268435456, // 0x10000000
  }
}
