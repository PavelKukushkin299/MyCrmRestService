// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.IOrganizationService
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Query;
using System;
using System.ServiceModel;

namespace Microsoft.Xrm.Sdk
{
  [ServiceContract(Name = "IOrganizationService", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Services")]
  [KnownAssembly]
  public interface IOrganizationService
  {
    [OperationContract]
    [FaultContract(typeof (OrganizationServiceFault))]
    Guid Create(Entity entity);

    [OperationContract]
    [FaultContract(typeof (OrganizationServiceFault))]
    Entity Retrieve(string entityName, Guid id, ColumnSet columnSet);

    [OperationContract]
    [FaultContract(typeof (OrganizationServiceFault))]
    void Update(Entity entity);

    [OperationContract]
    [FaultContract(typeof (OrganizationServiceFault))]
    void Delete(string entityName, Guid id);

    [OperationContract]
    [FaultContract(typeof (OrganizationServiceFault))]
    OrganizationResponse Execute(OrganizationRequest request);

    [OperationContract]
    [FaultContract(typeof (OrganizationServiceFault))]
    void Associate(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities);

    [OperationContract]
    [FaultContract(typeof (OrganizationServiceFault))]
    void Disassociate(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities);

    [OperationContract]
    [FaultContract(typeof (OrganizationServiceFault))]
    EntityCollection RetrieveMultiple(QueryBase query);
  }
}
