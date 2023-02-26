// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.Wsdl.MultiPolicy
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.Linq;
using System.Xml.Serialization;

namespace Data8.PowerPlatform.Dataverse.Client.Wsdl
{
  public class MultiPolicy : PolicyItem
  {
    [XmlElement("ExactlyOne", Namespace = "http://schemas.xmlsoap.org/ws/2004/09/policy", Type = typeof (ExactlyOne))]
    [XmlElement("All", Namespace = "http://schemas.xmlsoap.org/ws/2004/09/policy", Type = typeof (All))]
    [XmlElement("EndorsingSupportingTokens", Namespace = "http://docs.oasis-open.org/ws-sx/ws-securitypolicy/200702", Type = typeof (EndorsingSupportingTokens))]
    [XmlElement("IssuedToken", Namespace = "http://docs.oasis-open.org/ws-sx/ws-securitypolicy/200702", Type = typeof (IssuedToken))]
    [XmlElement("SignedEncryptedSupportingTokens", Namespace = "http://docs.oasis-open.org/ws-sx/ws-securitypolicy/200702", Type = typeof (SignedEncryptedSupportingTokens))]
    [XmlElement("UsernameToken", Namespace = "http://docs.oasis-open.org/ws-sx/ws-securitypolicy/200702", Type = typeof (UsernameToken))]
    [XmlElement("Trust13", Namespace = "http://docs.oasis-open.org/ws-sx/ws-securitypolicy/200702", Type = typeof (Trust13))]
    [XmlElement("AuthenticationPolicy", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Services", Type = typeof (AuthenticationPolicy))]
    public PolicyItem[] PolicyItems { get; set; }

    public T FindPolicyItem<T>() where T : PolicyItem => this.PolicyItems == null ? default (T) : this.PolicyItems.OfType<T>().FirstOrDefault<T>() ?? this.PolicyItems.OfType<MultiPolicy>().Select<MultiPolicy, T>((Func<MultiPolicy, T>) (child => child.FindPolicyItem<T>())).Where<T>((Func<T, bool>) (m => (object) m != null)).FirstOrDefault<T>();
  }
}
