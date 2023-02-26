// Decompiled with JetBrains decompiler
// Type: NSspi.Credentials.SafeCredentialHandle
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System.Runtime.ConstrainedExecution;

namespace NSspi.Credentials
{
  public class SafeCredentialHandle : SafeSspiHandle
  {
    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    protected override bool ReleaseHandle()
    {
      int num = (int) CredentialNativeMethods.FreeCredentialsHandle(ref this.rawHandle);
      base.ReleaseHandle();
      return num == 0;
    }
  }
}
