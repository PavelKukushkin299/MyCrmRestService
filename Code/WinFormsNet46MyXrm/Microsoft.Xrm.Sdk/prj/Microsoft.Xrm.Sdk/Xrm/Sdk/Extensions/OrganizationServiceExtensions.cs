// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Extensions.OrganizationServiceExtensions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;

namespace Microsoft.Xrm.Sdk.Extensions
{
  public static class OrganizationServiceExtensions
  {
    public static EntityMetadata GetEntityMetadata(
      this IOrganizationService serviceProxy,
      string logicalName)
    {
      RetrieveEntityRequest request = new RetrieveEntityRequest()
      {
        EntityFilters = EntityFilters.Entity | EntityFilters.Attributes | EntityFilters.Relationships,
        LogicalName = logicalName
      };
      return ((RetrieveEntityResponse) serviceProxy.Execute((OrganizationRequest) request)).EntityMetadata;
    }
  }
}
