// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.StringFormatName
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "StringFormatName", Namespace = "http://schemas.microsoft.com/xrm/2013/Metadata")]
  public sealed class StringFormatName : ConstantsBase<string>
  {
    public static readonly StringFormatName Email = ConstantsBase<string>.Add<StringFormatName>(nameof (Email));
    public static readonly StringFormatName Text = ConstantsBase<string>.Add<StringFormatName>(nameof (Text));
    public static readonly StringFormatName TextArea = ConstantsBase<string>.Add<StringFormatName>(nameof (TextArea));
    public static readonly StringFormatName Url = ConstantsBase<string>.Add<StringFormatName>(nameof (Url));
    public static readonly StringFormatName TickerSymbol = ConstantsBase<string>.Add<StringFormatName>(nameof (TickerSymbol));
    public static readonly StringFormatName PhoneticGuide = ConstantsBase<string>.Add<StringFormatName>(nameof (PhoneticGuide));
    public static readonly StringFormatName VersionNumber = ConstantsBase<string>.Add<StringFormatName>(nameof (VersionNumber));
    public static readonly StringFormatName Phone = ConstantsBase<string>.Add<StringFormatName>(nameof (Phone));

    public static implicit operator StringFormatName(string formatName)
    {
      StringFormatName stringFormatName = new StringFormatName();
      stringFormatName.Value = formatName;
      return stringFormatName;
    }

    protected override bool ValueExistsInList(string value) => ConstantsBase<string>.ValidValues.Contains<string>(value, (IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if (obj is string strB)
        return string.Compare(this.Value, strB, StringComparison.OrdinalIgnoreCase) == 0;
      StringFormatName stringFormatName = obj as StringFormatName;
      return !(stringFormatName == (StringFormatName) null) && string.Compare(this.Value, stringFormatName.Value, StringComparison.OrdinalIgnoreCase) == 0;
    }

    public static bool operator ==(StringFormatName stringFormatA, StringFormatName stringFormatB)
    {
      if ((object) stringFormatA == (object) stringFormatB)
        return true;
      return (object) stringFormatA != null && (object) stringFormatB != null && stringFormatA.Equals((object) stringFormatB);
    }

    public static bool operator !=(StringFormatName stringFormatA, StringFormatName stringFormatB) => !(stringFormatA == stringFormatB);

    public override int GetHashCode() => this.Value.GetHashCode();
  }
}
