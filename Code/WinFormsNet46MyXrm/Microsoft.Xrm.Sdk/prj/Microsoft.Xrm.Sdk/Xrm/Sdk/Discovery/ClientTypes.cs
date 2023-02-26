// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Discovery.ClientTypes
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;

namespace Microsoft.Xrm.Sdk.Discovery
{
  [Flags]
  public enum ClientTypes
  {
    OutlookLaptop = 1,
    OutlookDesktop = 2,
    DataMigration = 4,
    OutlookConfiguration = 8,
    DataMigrationConfiguration = 16, // 0x00000010
  }
}
