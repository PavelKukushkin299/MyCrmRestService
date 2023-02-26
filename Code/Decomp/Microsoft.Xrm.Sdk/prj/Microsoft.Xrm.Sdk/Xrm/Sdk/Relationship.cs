// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Relationship
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  [DataContract(Name = "Relationship", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class Relationship : IExtensibleDataObject
  {
    private EntityRole? _primaryEntityRole;
    private string _schemaName;
    private ExtensionDataObject _extensionDataObject;

    public Relationship()
    {
    }

    public Relationship(string schemaName) => this._schemaName = schemaName;

    [DataMember]
    public string SchemaName
    {
      get => this._schemaName;
      set => this._schemaName = value;
    }

    [DataMember]
    public EntityRole? PrimaryEntityRole
    {
      get => this._primaryEntityRole;
      set => this._primaryEntityRole = value;
    }

    public override bool Equals(object obj)
    {
      if (!(obj is Relationship relationship) || !(this.SchemaName == relationship.SchemaName))
        return false;
      EntityRole? primaryEntityRole1 = this._primaryEntityRole;
      EntityRole? primaryEntityRole2 = relationship._primaryEntityRole;
      return primaryEntityRole1.GetValueOrDefault() == primaryEntityRole2.GetValueOrDefault() & primaryEntityRole1.HasValue == primaryEntityRole2.HasValue;
    }

    public override int GetHashCode()
    {
      int hashCode = (this._schemaName ?? string.Empty).GetHashCode();
      if (this._primaryEntityRole.HasValue)
        hashCode ^= this._primaryEntityRole.Value.GetHashCode();
      return hashCode;
    }

    public override string ToString() => string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0}.{1}", (object) (this._schemaName ?? string.Empty), this._primaryEntityRole.HasValue ? (object) this._primaryEntityRole.ToString() : (object) string.Empty);

    public ExtensionDataObject ExtensionData
    {
      get => this._extensionDataObject;
      set => this._extensionDataObject = value;
    }
  }
}
