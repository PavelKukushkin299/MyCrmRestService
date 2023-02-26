// Decompiled with JetBrains decompiler
// Type: NSspi.SecPkgCapability
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;

namespace NSspi
{
  [Flags]
  public enum SecPkgCapability : uint
  {
    Integrity = 1,
    Privacy = 2,
    TokenOnly = 4,
    Datagram = 8,
    Connection = 16, // 0x00000010
    MultiLeg = 32, // 0x00000020
    ClientOnly = 64, // 0x00000040
    ExtendedError = 128, // 0x00000080
    Impersonation = 256, // 0x00000100
    AcceptWin32Name = 512, // 0x00000200
    Stream = 1024, // 0x00000400
    Negotiable = 2048, // 0x00000800
    GssCompatible = 4096, // 0x00001000
    Logon = 8192, // 0x00002000
    AsciiBuffers = 16384, // 0x00004000
    Fragment = 32768, // 0x00008000
    MutualAuth = 65536, // 0x00010000
    Delegation = 131072, // 0x00020000
    ReadOnlyChecksum = 262144, // 0x00040000
    RestrictedTokens = 524288, // 0x00080000
    ExtendsNego = 1048576, // 0x00100000
    Negotiable2 = 2097152, // 0x00200000
  }
}
