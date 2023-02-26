// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.AttributeTypeDisplayName
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
  [DataContract(Name = "AttributeTypeDisplayName", Namespace = "http://schemas.microsoft.com/xrm/2013/Metadata")]
  public sealed class AttributeTypeDisplayName : ConstantsBase<string>
  {
    public static readonly AttributeTypeDisplayName BooleanType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (BooleanType));
    public static readonly AttributeTypeDisplayName CustomerType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (CustomerType));
    public static readonly AttributeTypeDisplayName DateTimeType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (DateTimeType));
    public static readonly AttributeTypeDisplayName DecimalType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (DecimalType));
    public static readonly AttributeTypeDisplayName DoubleType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (DoubleType));
    public static readonly AttributeTypeDisplayName IntegerType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (IntegerType));
    public static readonly AttributeTypeDisplayName LookupType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (LookupType));
    public static readonly AttributeTypeDisplayName MemoType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (MemoType));
    public static readonly AttributeTypeDisplayName MoneyType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (MoneyType));
    public static readonly AttributeTypeDisplayName OwnerType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (OwnerType));
    public static readonly AttributeTypeDisplayName PartyListType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (PartyListType));
    public static readonly AttributeTypeDisplayName PicklistType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (PicklistType));
    public static readonly AttributeTypeDisplayName StateType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (StateType));
    public static readonly AttributeTypeDisplayName StatusType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (StatusType));
    public static readonly AttributeTypeDisplayName StringType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (StringType));
    public static readonly AttributeTypeDisplayName UniqueidentifierType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (UniqueidentifierType));
    public static readonly AttributeTypeDisplayName CalendarRulesType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (CalendarRulesType));
    public static readonly AttributeTypeDisplayName VirtualType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (VirtualType));
    public static readonly AttributeTypeDisplayName BigIntType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (BigIntType));
    public static readonly AttributeTypeDisplayName ManagedPropertyType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (ManagedPropertyType));
    public static readonly AttributeTypeDisplayName EntityNameType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (EntityNameType));
    public static readonly AttributeTypeDisplayName ImageType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (ImageType));
    public static readonly AttributeTypeDisplayName MultiSelectPicklistType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (MultiSelectPicklistType));
    public static readonly AttributeTypeDisplayName FileType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (FileType));
    public static readonly AttributeTypeDisplayName CustomType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof (CustomType));

    public static implicit operator AttributeTypeDisplayName(
      string attributeTypeDisplayName)
    {
      AttributeTypeDisplayName attributeTypeDisplayName1 = new AttributeTypeDisplayName();
      attributeTypeDisplayName1.Value = attributeTypeDisplayName;
      return attributeTypeDisplayName1;
    }

    protected override bool ValueExistsInList(string value) => ConstantsBase<string>.ValidValues.Contains<string>(value, (IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if (obj is string strB)
        return string.Compare(this.Value, strB, StringComparison.OrdinalIgnoreCase) == 0;
      AttributeTypeDisplayName attributeTypeDisplayName = obj as AttributeTypeDisplayName;
      return !(attributeTypeDisplayName == (AttributeTypeDisplayName) null) && string.Compare(this.Value, attributeTypeDisplayName.Value, StringComparison.OrdinalIgnoreCase) == 0;
    }

    public static bool operator ==(
      AttributeTypeDisplayName attributeTypeDisplayNameA,
      AttributeTypeDisplayName attributeTypeDisplayNameB)
    {
      if ((object) attributeTypeDisplayNameA == (object) attributeTypeDisplayNameB)
        return true;
      return (object) attributeTypeDisplayNameA != null && (object) attributeTypeDisplayNameB != null && attributeTypeDisplayNameA.Equals((object) attributeTypeDisplayNameB);
    }

    public static bool operator !=(
      AttributeTypeDisplayName attributeTypeDisplayNameA,
      AttributeTypeDisplayName attributeTypeDisplayNameB)
    {
      return !(attributeTypeDisplayNameA == attributeTypeDisplayNameB);
    }

    public override int GetHashCode() => this.Value.GetHashCode();
  }
}
