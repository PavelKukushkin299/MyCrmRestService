// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.IKeyVaultClient
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

namespace Microsoft.Xrm.Sdk
{
  public interface IKeyVaultClient
  {
    AuthenticationType PreferredAuthType { get; set; }

    string GetSecret(string vaultAddress, string secretName);

    string GetSecret(string secretName);

    void SetSecret(string vaultAddress, string secretName, string value);

    void SetSecret(string secretName, string value);

    void DeleteSecret(string vaultAddress, string secretName);

    void DeleteSecret(string secretName);

    byte[] Encrypt(string keyIdentifier, string algorithm, byte[] rawData);

    byte[] Encrypt(string keyName, string keyVersion, string algorithm, byte[] rawData);

    byte[] Decrypt(string keyIdentifier, string algorithm, byte[] encryptedData);

    byte[] Decrypt(string keyName, string keyVersion, string algorithm, byte[] encryptedData);
  }
}
