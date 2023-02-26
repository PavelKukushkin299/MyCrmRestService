// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.IssuerEndpointDictionary
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;

namespace MyCrmConnector.Client
{
  [Serializable]
  public sealed class IssuerEndpointDictionary : Dictionary<string, IssuerEndpoint>
  {
    public IssuerEndpointDictionary()
    {
    }

    private IssuerEndpointDictionary(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    public IssuerEndpoint GetIssuerEndpoint(Microsoft.Xrm.Sdk.Client.TokenServiceCredentialType credentialType)
    {
      if (credentialType == Microsoft.Xrm.Sdk.Client.TokenServiceCredentialType.None)
        return (IssuerEndpoint) null;
      foreach (KeyValuePair<string, IssuerEndpoint> keyValuePair in (Dictionary<string, IssuerEndpoint>) this)
      {
        if (keyValuePair.Value.CredentialType == credentialType)
          return keyValuePair.Value;
      }
      throw new NotSupportedException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The authentication endpoint {0} was not found on the configured Secure Token Service!", (object) credentialType));
    }
  }
}
