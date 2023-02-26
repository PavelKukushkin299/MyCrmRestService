// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.DateTimeBehavior
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "DateTimeBehavior", Namespace = "http://schemas.microsoft.com/xrm/7.1/Metadata")]
  public sealed class DateTimeBehavior : ConstantsBase<string>
  {
    public static readonly DateTimeBehavior UserLocal = ConstantsBase<string>.Add<DateTimeBehavior>(nameof (UserLocal));
    public static readonly DateTimeBehavior DateOnly = ConstantsBase<string>.Add<DateTimeBehavior>(nameof (DateOnly));
    public static readonly DateTimeBehavior TimeZoneIndependent = ConstantsBase<string>.Add<DateTimeBehavior>(nameof (TimeZoneIndependent));

    public static implicit operator DateTimeBehavior(string behavior)
    {
      DateTimeBehavior dateTimeBehavior = new DateTimeBehavior();
      dateTimeBehavior.Value = behavior;
      return dateTimeBehavior;
    }

    protected override bool ValueExistsInList(string value) => ConstantsBase<string>.ValidValues.Contains<string>(value, (IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if (obj is string strB)
        return string.Compare(this.Value, strB, StringComparison.OrdinalIgnoreCase) == 0;
      DateTimeBehavior dateTimeBehavior = obj as DateTimeBehavior;
      return !(dateTimeBehavior == (DateTimeBehavior) null) && string.Compare(this.Value, dateTimeBehavior.Value, StringComparison.OrdinalIgnoreCase) == 0;
    }

    public static bool operator ==(DateTimeBehavior behaviorA, DateTimeBehavior behaviorB)
    {
      if ((object) behaviorA == (object) behaviorB)
        return true;
      return (object) behaviorA != null && (object) behaviorB != null && behaviorA.Equals((object) behaviorB);
    }

    public static bool operator !=(DateTimeBehavior behaviorA, DateTimeBehavior behaviorB) => !(behaviorA == behaviorB);

    public override int GetHashCode() => this.Value.GetHashCode();
  }
}
