// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.OrganizationServiceFault
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;
using System.Text;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "OrganizationServiceFault", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  [Serializable]
  public class OrganizationServiceFault : BaseServiceFault
  {
    private string _traceText;
    private OrganizationServiceFault _innerFault;

    public override string ToString()
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      for (OrganizationServiceFault organizationServiceFault = this; organizationServiceFault != null; organizationServiceFault = organizationServiceFault.InnerFault)
      {
        stringBuilder1.AppendLine("Exception details: ");
        stringBuilder1.AppendLine("ErrorCode: 0x" + organizationServiceFault.ErrorCode.ToString("X"));
        string str1 = "Message: " + organizationServiceFault.Message;
        stringBuilder1.AppendLine(str1);
        if (organizationServiceFault.ErrorDetails != null && organizationServiceFault.ErrorDetails.ContainsKey("CallStack"))
        {
          stringBuilder1.AppendLine("StackTrace: ");
          stringBuilder1.AppendLine(organizationServiceFault.ErrorDetails["CallStack"] as string);
        }
        StringBuilder stringBuilder2 = stringBuilder1;
        DateTime dateTime = organizationServiceFault.Timestamp;
        dateTime = dateTime.ToUniversalTime();
        string str2 = "TimeStamp: " + dateTime.ToString("o");
        stringBuilder2.AppendLine(str2);
        if (!string.IsNullOrWhiteSpace(organizationServiceFault.OriginalException))
          stringBuilder1.AppendLine("OriginalException: " + organizationServiceFault.OriginalException);
        if (!string.IsNullOrWhiteSpace(organizationServiceFault.ExceptionSource))
          stringBuilder1.AppendLine("ExceptionSource: " + organizationServiceFault.ExceptionSource);
        stringBuilder1.AppendLine("--");
      }
      return stringBuilder1.ToString();
    }

    [DataMember]
    public string TraceText
    {
      get => this._traceText;
      set => this._traceText = value;
    }

    [DataMember]
    public OrganizationServiceFault InnerFault
    {
      get => this._innerFault;
      set => this._innerFault = value;
    }

    [DataMember]
    internal string OriginalException { get; set; }

    [DataMember]
    internal string ExceptionSource { get; set; }

    [DataMember]
    internal bool ExceptionRetriable { get; set; }

    [IgnoreDataMember]
    internal override BaseServiceFault InnerServiceFault
    {
      get => (BaseServiceFault) this._innerFault;
      set => this._innerFault = (OrganizationServiceFault) value;
    }
  }
}
