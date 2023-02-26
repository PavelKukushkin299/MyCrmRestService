// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.IdentityProviderLookup
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Web;
using System.Xml.Serialization;

namespace Microsoft.Xrm.Sdk.Client
{
  [SecuritySafeCritical]
  [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
  internal sealed class IdentityProviderLookup
  {
    private static IdentityProviderLookup _instance;
    private readonly IdentityProviderDictionary _identityProviderDictionary = new IdentityProviderDictionary();
    private const string OrgIdIdentityService = "{0}/GetUserRealm.srf";
    private const string OrgIdIdentityQuery = "login={0}&xml=1";

    public static IdentityProviderLookup Instance => IdentityProviderLookup._instance ?? (IdentityProviderLookup._instance = new IdentityProviderLookup());

    internal IdentityProviderDictionary IdentityProviderDictionary => this._identityProviderDictionary;

    public static void Clear() => IdentityProviderLookup._instance = (IdentityProviderLookup) null;

    public IdentityProvider GetIdentityProvider(
      Uri host,
      Uri orgIdServiceRoot,
      string userPrincipalName)
    {
      ClientExceptionHelper.ThrowIfNull((object) host, nameof (host));
      ClientExceptionHelper.ThrowIfNull((object) orgIdServiceRoot, nameof (orgIdServiceRoot));
      ClientExceptionHelper.ThrowIfNullOrEmpty(userPrincipalName, nameof (userPrincipalName));
      IdentityProvider identityProvider1;
      if (this.IdentityProviderDictionary.TryGetValue(userPrincipalName, out identityProvider1))
        return identityProvider1;
      string s = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "login={0}&xml=1", (object) HttpUtility.UrlEncode(userPrincipalName));
      string uriString = string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0}/GetUserRealm.srf", (object) host.AbsoluteUri.TrimEnd('/'));
      try
      {
        HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(new Uri(uriString));
        httpWebRequest.Method = "POST";
        httpWebRequest.ContentLength = (long) s.Length;
        httpWebRequest.ContentType = "application/x-www-form-urlencoded";
        RealmInfo realmInfo = (RealmInfo) null;
        using (Stream requestStream = httpWebRequest.GetRequestStream())
        {
          byte[] bytes = Encoding.UTF8.GetBytes(s);
          requestStream.Write(bytes, 0, s.Length);
        }
        using (HttpWebResponse response = (HttpWebResponse) httpWebRequest.GetResponse())
        {
          using (Stream responseStream = response.GetResponseStream())
          {
            using (StreamReader streamReader = new StreamReader(responseStream))
              realmInfo = new XmlSerializer(typeof (RealmInfo)).Deserialize((TextReader) streamReader) as RealmInfo;
          }
        }
        if (realmInfo != null)
        {
          IdentityProvider identityProvider2 = IdentityProviderLookup.ExtractIdentityProvider(orgIdServiceRoot, realmInfo);
          this.IdentityProviderDictionary[userPrincipalName] = identityProvider2;
          return identityProvider2;
        }
      }
      catch (WebException ex)
      {
      }
      return (IdentityProvider) null;
    }

    private static IdentityProvider ExtractIdentityProvider(
      Uri orgIdServiceRoot,
      RealmInfo realmInfo)
    {
      IdentityProvider identityProvider1 = (IdentityProvider) null;
      string namespaceType = realmInfo.NamespaceType;
      if (!string.IsNullOrEmpty(namespaceType))
      {
        if (string.Compare(namespaceType, "Managed", StringComparison.OrdinalIgnoreCase) == 0)
        {
          OnlineIdentityProvider identityProvider2 = new OnlineIdentityProvider();
          identityProvider2.IdentityProviderType = IdentityProviderType.OrgId;
          identityProvider2.ServiceUrl = orgIdServiceRoot;
          identityProvider1 = (IdentityProvider) identityProvider2;
        }
        else if (string.Compare(namespaceType, "Federated", StringComparison.OrdinalIgnoreCase) == 0)
        {
          if (string.IsNullOrEmpty(realmInfo.MetadataUrl))
          {
            OnlineIdentityProvider identityProvider3 = new OnlineIdentityProvider();
            identityProvider3.IdentityProviderType = IdentityProviderType.LiveId;
            identityProvider3.ServiceUrl = new Uri(realmInfo.TokenServiceAuthenticationUrl);
            identityProvider1 = (IdentityProvider) identityProvider3;
          }
          else
          {
            LocalIdentityProvider identityProvider4 = new LocalIdentityProvider();
            identityProvider4.IdentityProviderType = IdentityProviderType.ADFS;
            identityProvider4.ServiceUrl = new Uri(realmInfo.MetadataUrl);
            identityProvider1 = (IdentityProvider) identityProvider4;
          }
        }
      }
      return identityProvider1;
    }
  }
}
