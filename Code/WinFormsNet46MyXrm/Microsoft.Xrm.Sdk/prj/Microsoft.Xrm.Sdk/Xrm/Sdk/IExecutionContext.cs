// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.IExecutionContext
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;

namespace Microsoft.Xrm.Sdk
{
  public interface IExecutionContext
  {
    int Mode { get; }

    int IsolationMode { get; }

    int Depth { get; }

    string MessageName { get; }

    string PrimaryEntityName { get; }

    Guid? RequestId { get; }

    string SecondaryEntityName { get; }

    ParameterCollection InputParameters { get; }

    ParameterCollection OutputParameters { get; }

    ParameterCollection SharedVariables { get; }

    Guid UserId { get; }

    Guid InitiatingUserId { get; }

    Guid BusinessUnitId { get; }

    Guid OrganizationId { get; }

    string OrganizationName { get; }

    Guid PrimaryEntityId { get; }

    EntityImageCollection PreEntityImages { get; }

    EntityImageCollection PostEntityImages { get; }

    EntityReference OwningExtension { get; }

    Guid CorrelationId { get; }

    bool IsExecutingOffline { get; }

    bool IsOfflinePlayback { get; }

    bool IsInTransaction { get; }

    Guid OperationId { get; }

    DateTime OperationCreatedOn { get; }
  }
}
