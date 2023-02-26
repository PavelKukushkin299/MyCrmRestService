// Decompiled with JetBrains decompiler
// Type: NSspi.ByteWriter
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

namespace NSspi
{
  public static class ByteWriter
  {
    public static void WriteInt16_BE(short value, byte[] buffer, int position)
    {
      buffer[position] = (byte) ((uint) value >> 8);
      buffer[position + 1] = (byte) value;
    }

    public static void WriteInt32_BE(int value, byte[] buffer, int position)
    {
      buffer[position] = (byte) (value >> 24);
      buffer[position + 1] = (byte) (value >> 16);
      buffer[position + 2] = (byte) (value >> 8);
      buffer[position + 3] = (byte) value;
    }

    public static short ReadInt16_BE(byte[] buffer, int position) => (short) ((int) (short) ((int) buffer[position] << 8) + (int) buffer[position + 1]);

    public static int ReadInt32_BE(byte[] buffer, int position) => (int) buffer[position] << 24 | (int) buffer[position + 1] << 16 | (int) buffer[position + 2] << 8 | (int) buffer[position + 3];
  }
}
