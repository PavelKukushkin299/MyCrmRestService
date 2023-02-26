// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.EmailEngagementAggregate
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/8.2/Contracts")]
  public sealed class EmailEngagementAggregate : IExtensibleDataObject
  {
    private int totalEmails;
    private int totalFollowedEmails;
    private int totalEmailOpens;
    private int totalEmailReplies;
    private int totalAttachmentOpens;
    private int totalLinkClicks;
    private ExtensionDataObject _extensionDataObject;

    [DataMember]
    public int TotalEmails
    {
      get => this.totalEmails;
      set => this.totalEmails = value;
    }

    [DataMember]
    public int TotalFollowedEmails
    {
      get => this.totalFollowedEmails;
      set => this.totalFollowedEmails = value;
    }

    [DataMember]
    public int TotalEmailOpens
    {
      get => this.totalEmailOpens;
      set => this.totalEmailOpens = value;
    }

    [DataMember]
    public int TotalEmailReplies
    {
      get => this.totalEmailReplies;
      set => this.totalEmailReplies = value;
    }

    [DataMember]
    public int TotalAttachmentOpens
    {
      get => this.totalAttachmentOpens;
      set => this.totalAttachmentOpens = value;
    }

    [DataMember]
    public int TotalLinkClicks
    {
      get => this.totalLinkClicks;
      set => this.totalLinkClicks = value;
    }

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
