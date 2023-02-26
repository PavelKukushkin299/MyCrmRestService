// Decompiled with JetBrains decompiler
// Type: NSspi.SecPkgInfo
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System.Runtime.InteropServices;

namespace NSspi
{
  [StructLayout(LayoutKind.Sequential)]
  public class SecPkgInfo
  {
    public SecPkgCapability Capabilities;
    public short Version;
    public short RpcId;
    public int MaxTokenLength;
    [MarshalAs(UnmanagedType.LPWStr)]
    public string Name;
    [MarshalAs(UnmanagedType.LPWStr)]
    public string Comment;
  }
}
