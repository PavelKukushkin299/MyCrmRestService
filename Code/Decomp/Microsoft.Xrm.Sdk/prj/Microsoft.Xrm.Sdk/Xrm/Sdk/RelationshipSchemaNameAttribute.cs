// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.RelationshipSchemaNameAttribute
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;

namespace Microsoft.Xrm.Sdk
{
  [AttributeUsage(AttributeTargets.Property)]
  public sealed class RelationshipSchemaNameAttribute : Attribute
  {
    private readonly Relationship _relationship;

    public string SchemaName => this._relationship.SchemaName;

    public EntityRole? PrimaryEntityRole => this._relationship.PrimaryEntityRole;

    internal Relationship Relationship => this._relationship;

    public RelationshipSchemaNameAttribute(string schemaName)
      : this(schemaName, new EntityRole?())
    {
    }

    public RelationshipSchemaNameAttribute(string schemaName, EntityRole primaryEntityRole)
      : this(schemaName, new EntityRole?(primaryEntityRole))
    {
    }

    private RelationshipSchemaNameAttribute(string schemaName, EntityRole? primaryEntityRole)
    {
      this._relationship = !string.IsNullOrWhiteSpace(schemaName) ? new Relationship(schemaName) : throw new ArgumentNullException(nameof (schemaName));
      this._relationship.PrimaryEntityRole = primaryEntityRole;
    }
  }
}
