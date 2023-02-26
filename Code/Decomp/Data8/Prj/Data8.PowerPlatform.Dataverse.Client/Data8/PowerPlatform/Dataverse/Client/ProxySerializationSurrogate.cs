// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.ProxySerializationSurrogate
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace Data8.PowerPlatform.Dataverse.Client
{
  internal class ProxySerializationSurrogate : IDataContractSurrogate
  {
    private Dictionary<string, Type> _requestTypes;
    private Dictionary<string, Type> _responseTypes;
    private Dictionary<string, Type> _entityTypes;

    public void LoadAssembly(Assembly assembly)
    {
      this._requestTypes = new Dictionary<string, Type>();
      this._responseTypes = new Dictionary<string, Type>();
      this._entityTypes = new Dictionary<string, Type>();
      foreach (Type exportedType in assembly.GetExportedTypes())
      {
        if (typeof (OrganizationRequest).IsAssignableFrom(exportedType))
        {
          RequestProxyAttribute customAttribute = exportedType.GetCustomAttribute<RequestProxyAttribute>();
          if (customAttribute != null)
            this._requestTypes[customAttribute.Name] = exportedType;
        }
        else if (typeof (OrganizationResponse).IsAssignableFrom(exportedType))
        {
          ResponseProxyAttribute customAttribute = exportedType.GetCustomAttribute<ResponseProxyAttribute>();
          if (customAttribute != null)
            this._responseTypes[customAttribute.Name] = exportedType;
        }
        else if (typeof (Entity).IsAssignableFrom(exportedType))
        {
          EntityLogicalNameAttribute customAttribute = exportedType.GetCustomAttribute<EntityLogicalNameAttribute>();
          if (customAttribute != null)
            this._entityTypes[customAttribute.LogicalName] = exportedType;
        }
      }
    }

    Type IDataContractSurrogate.GetDataContractType(Type type)
    {
      if (this._entityTypes == null)
        return type;
      if (typeof (OrganizationRequest).IsAssignableFrom(type))
        return typeof (OrganizationRequest);
      if (typeof (OrganizationResponse).IsAssignableFrom(type))
        return typeof (OrganizationResponse);
      return typeof (Entity).IsAssignableFrom(type) ? typeof (Entity) : type;
    }

    public object GetDeserializedObject(object obj, Type targetType)
    {
      if (this._entityTypes == null)
        return obj;
      switch (obj)
      {
        case OrganizationRequest organizationRequest:
          Type requestType = this.GetRequestType(organizationRequest.RequestName);
          if (requestType == (Type) null)
            return obj;
          OrganizationRequest instance1 = (OrganizationRequest) Activator.CreateInstance(requestType);
          instance1.RequestName = organizationRequest.RequestName;
          instance1.RequestId = organizationRequest.RequestId;
          instance1.Parameters = organizationRequest.Parameters;
          return (object) instance1;
        case OrganizationResponse organizationResponse:
          Type responseType = this.GetResponseType(organizationResponse.ResponseName);
          if (responseType == (Type) null)
            return obj;
          OrganizationResponse instance2 = (OrganizationResponse) Activator.CreateInstance(responseType);
          instance2.ResponseName = organizationResponse.ResponseName;
          instance2.Results = organizationResponse.Results;
          return (object) instance2;
        case Entity entity:
          Type entityType = this.GetEntityType(entity.LogicalName);
          if (entityType == (Type) null)
            return obj;
          return typeof (Entity).GetMethod("ToEntity").MakeGenericMethod(entityType).Invoke((object) entity, Array.Empty<object>());
        default:
          return obj;
      }
    }

    public object GetObjectToSerialize(object obj, Type targetType)
    {
      if (this._entityTypes == null || obj.GetType() == targetType)
        return obj;
      if (targetType == typeof (OrganizationRequest) && obj is OrganizationRequest organizationRequest)
      {
        if (this.GetRequestType(organizationRequest.RequestName) == (Type) null)
          return obj;
        return (object) new OrganizationRequest()
        {
          RequestName = organizationRequest.RequestName,
          Parameters = organizationRequest.Parameters,
          RequestId = organizationRequest.RequestId
        };
      }
      if (targetType == typeof (OrganizationResponse) && obj is OrganizationResponse organizationResponse)
      {
        if (this.GetResponseType(organizationResponse.ResponseName) == (Type) null)
          return obj;
        return (object) new OrganizationResponse()
        {
          ResponseName = organizationResponse.ResponseName,
          Results = organizationResponse.Results
        };
      }
      return obj is Entity entity && obj.GetType() != typeof (Entity) ? (object) entity.ToEntity<Entity>() : obj;
    }

    object IDataContractSurrogate.GetCustomDataToExport(
      MemberInfo memberInfo,
      Type dataContractType)
    {
      return (object) null;
    }

    object IDataContractSurrogate.GetCustomDataToExport(
      Type clrType,
      Type dataContractType)
    {
      return (object) null;
    }

    void IDataContractSurrogate.GetKnownCustomDataTypes(
      Collection<Type> customDataTypes)
    {
    }

    Type IDataContractSurrogate.GetReferencedTypeOnImport(
      string typeName,
      string typeNamespace,
      object customData)
    {
      return (Type) null;
    }

    CodeTypeDeclaration IDataContractSurrogate.ProcessImportedType(
      CodeTypeDeclaration typeDeclaration,
      CodeCompileUnit compileUnit)
    {
      return (CodeTypeDeclaration) null;
    }

    private Type GetRequestType(string name)
    {
      Type type;
      return this._requestTypes.TryGetValue(name, out type) ? type : (Type) null;
    }

    private Type GetResponseType(string name)
    {
      Type type;
      return this._responseTypes.TryGetValue(name, out type) ? type : (Type) null;
    }

    private Type GetEntityType(string name)
    {
      Type type;
      return this._entityTypes.TryGetValue(name, out type) ? type : (Type) null;
    }
  }
}
