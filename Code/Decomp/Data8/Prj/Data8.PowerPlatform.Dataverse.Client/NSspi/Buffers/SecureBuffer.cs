// Decompiled with JetBrains decompiler
// Type: NSspi.Buffers.SecureBuffer
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

namespace NSspi.Buffers
{
  internal class SecureBuffer
  {
    public SecureBuffer(byte[] buffer, BufferType type)
    {
      this.Buffer = buffer;
      this.Type = type;
      byte[] buffer1 = this.Buffer;
      this.Length = buffer1 != null ? buffer1.Length : 0;
    }

    public BufferType Type { get; set; }

    public byte[] Buffer { get; set; }

    public int Length { get; internal set; }
  }
}
