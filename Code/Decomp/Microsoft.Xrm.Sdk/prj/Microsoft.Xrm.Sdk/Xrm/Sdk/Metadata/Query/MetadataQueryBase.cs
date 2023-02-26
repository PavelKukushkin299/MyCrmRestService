// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Metadata.Query.MetadataQueryBase
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
  [KnownType(typeof (MetadataQueryExpression))]
  [DataContract(Name = "MetadataQueryBase", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
  public abstract class MetadataQueryBase : IExtensibleDataObject
  {
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal abstract void Accept(IMetadataQueryExpressionVisitor visitor);

    public ExtensionDataObject ExtensionData { get; set; }
  }
}
