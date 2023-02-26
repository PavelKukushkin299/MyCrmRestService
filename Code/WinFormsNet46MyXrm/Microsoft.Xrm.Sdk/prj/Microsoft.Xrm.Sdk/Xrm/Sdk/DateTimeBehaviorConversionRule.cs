// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.DateTimeBehaviorConversionRule
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Xrm.Sdk
{
  public sealed class DateTimeBehaviorConversionRule : ConstantsBase<string>
  {
    public static readonly DateTimeBehaviorConversionRule SpecificTimeZone = ConstantsBase<string>.Add<DateTimeBehaviorConversionRule>(nameof (SpecificTimeZone));
    public static readonly DateTimeBehaviorConversionRule CreatedByTimeZone = ConstantsBase<string>.Add<DateTimeBehaviorConversionRule>(nameof (CreatedByTimeZone));
    public static readonly DateTimeBehaviorConversionRule OwnerTimeZone = ConstantsBase<string>.Add<DateTimeBehaviorConversionRule>(nameof (OwnerTimeZone));
    public static readonly DateTimeBehaviorConversionRule LastUpdatedByTimeZone = ConstantsBase<string>.Add<DateTimeBehaviorConversionRule>(nameof (LastUpdatedByTimeZone));

    public static implicit operator DateTimeBehaviorConversionRule(
      string conversionRule)
    {
      DateTimeBehaviorConversionRule behaviorConversionRule = new DateTimeBehaviorConversionRule();
      behaviorConversionRule.Value = conversionRule;
      return behaviorConversionRule;
    }

    protected override bool ValueExistsInList(string value) => ConstantsBase<string>.ValidValues.Contains<string>(value, (IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if (obj is string strB)
        return string.Compare(this.Value, strB, StringComparison.OrdinalIgnoreCase) == 0;
      DateTimeBehaviorConversionRule behaviorConversionRule = obj as DateTimeBehaviorConversionRule;
      return !(behaviorConversionRule == (DateTimeBehaviorConversionRule) null) && string.Compare(this.Value, behaviorConversionRule.Value, StringComparison.OrdinalIgnoreCase) == 0;
    }

    public static bool operator ==(
      DateTimeBehaviorConversionRule conversionRuleA,
      DateTimeBehaviorConversionRule conversionRuleB)
    {
      if ((object) conversionRuleA == (object) conversionRuleB)
        return true;
      return (object) conversionRuleA != null && (object) conversionRuleB != null && conversionRuleA.Equals((object) conversionRuleB);
    }

    public static bool operator !=(
      DateTimeBehaviorConversionRule conversionRuleA,
      DateTimeBehaviorConversionRule conversionRuleB)
    {
      return !(conversionRuleA == conversionRuleB);
    }

    public override int GetHashCode() => this.Value.GetHashCode();
  }
}
