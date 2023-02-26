// Decompiled with JetBrains decompiler
// Type: NSspi.Contexts.ContextAttrib
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;

namespace NSspi.Contexts
{
  [Flags]
  public enum ContextAttrib
  {
    Zero = 0,
    Delegate = 1,
    MutualAuth = 2,
    ReplayDetect = 4,
    SequenceDetect = 8,
    Confidentiality = 16, // 0x00000010
    UseSessionKey = 32, // 0x00000020
    AllocateMemory = 256, // 0x00000100
    Connection = 2048, // 0x00000800
    InitExtendedError = 16384, // 0x00004000
    AcceptExtendedError = 32768, // 0x00008000
    InitStream = AcceptExtendedError, // 0x00008000
    AcceptStream = 65536, // 0x00010000
    InitIntegrity = AcceptStream, // 0x00010000
    AcceptIntegrity = 131072, // 0x00020000
    InitIdentify = AcceptIntegrity, // 0x00020000
    AcceptIdentify = 524288, // 0x00080000
    InitManualCredValidation = AcceptIdentify, // 0x00080000
    InitUseSuppliedCreds = 128, // 0x00000080
  }
}
