// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.ConvertDateAndTimeBehaviorRequest
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class ConvertDateAndTimeBehaviorRequest : OrganizationRequest
  {
    public EntityAttributeCollection Attributes
    {
      get => this.Parameters.Contains(nameof (Attributes)) ? (EntityAttributeCollection) this.Parameters[nameof (Attributes)] : (EntityAttributeCollection) null;
      set => this.Parameters[nameof (Attributes)] = (object) value;
    }

    public string ConversionRule
    {
      get => this.Parameters.Contains(nameof (ConversionRule)) ? (string) this.Parameters[nameof (ConversionRule)] : (string) null;
      set => this.Parameters[nameof (ConversionRule)] = (object) value;
    }

    public int TimeZoneCode
    {
      get => this.Parameters.Contains(nameof (TimeZoneCode)) ? (int) this.Parameters[nameof (TimeZoneCode)] : 0;
      set => this.Parameters[nameof (TimeZoneCode)] = (object) value;
    }

    public bool AutoConvert
    {
      get => this.Parameters.Contains(nameof (AutoConvert)) && (bool) this.Parameters[nameof (AutoConvert)];
      set => this.Parameters[nameof (AutoConvert)] = (object) value;
    }

    public ConvertDateAndTimeBehaviorRequest()
    {
      this.RequestName = "ConvertDateAndTimeBehavior";
      this.AutoConvert = true;
      this.Attributes = (EntityAttributeCollection) null;
    }
  }
}
