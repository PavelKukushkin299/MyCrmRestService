// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.ProxySerializationSurrogate
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  internal sealed class ProxySerializationSurrogate : IDataContractSurrogate
  {
    private Assembly _proxyTypesAssembly;

    internal ProxySerializationSurrogate(Assembly proxyTypesAssembly) => this._proxyTypesAssembly = proxyTypesAssembly;

    object IDataContractSurrogate.GetCustomDataToExport(
      Type clrType,
      Type dataContractType)
    {
      return (object) null;
    }

    object IDataContractSurrogate.GetCustomDataToExport(
      MemberInfo memberInfo,
      Type dataContractType)
    {
      return (object) null;
    }

    Type IDataContractSurrogate.GetDataContractType(Type type)
    {
      if (type.IsAssignableFrom(typeof (OrganizationRequest)))
        return typeof (OrganizationRequest);
      if (type.IsAssignableFrom(typeof (OrganizationResponse)))
        return typeof (OrganizationResponse);
      return type.IsAssignableFrom(typeof (Entity)) ? typeof (Entity) : type;
    }

    object IDataContractSurrogate.GetDeserializedObject(
      object obj,
      Type targetType)
    {
      bool supportIndividualAssemblies = this._proxyTypesAssembly != (Assembly) null;
      switch (obj)
      {
        case OrganizationResponse organizationResponse:
          Type typeForName1 = KnownProxyTypesProvider.GetInstance(supportIndividualAssemblies).GetTypeForName(organizationResponse.ResponseName, this._proxyTypesAssembly);
          if (typeForName1 == (Type) null)
            return obj;
          OrganizationResponse instance1 = (OrganizationResponse) Activator.CreateInstance(typeForName1);
          instance1.ResponseName = organizationResponse.ResponseName;
          instance1.Results = organizationResponse.Results;
          return (object) instance1;
        case Entity entity:
          Type typeForName2 = KnownProxyTypesProvider.GetInstance(supportIndividualAssemblies).GetTypeForName(entity.LogicalName, this._proxyTypesAssembly);
          if (typeForName2 == (Type) null)
            return obj;
          Entity instance2 = (Entity) Activator.CreateInstance(typeForName2);
          entity.ShallowCopyTo(instance2);
          return (object) instance2;
        default:
          return obj;
      }
    }

    void IDataContractSurrogate.GetKnownCustomDataTypes(
      Collection<Type> customDataTypes)
    {
    }

    object IDataContractSurrogate.GetObjectToSerialize(
      object obj,
      Type targetType)
    {
      if (obj.GetType().IsSubclassOf(typeof (OrganizationRequest)))
      {
        OrganizationRequest organizationRequest = (OrganizationRequest) obj;
        if (KnownProxyTypesProvider.GetInstance(this._proxyTypesAssembly != (Assembly) null).GetTypeForName(organizationRequest.RequestName, this._proxyTypesAssembly) == (Type) null)
          return obj;
        return (object) new OrganizationRequest()
        {
          RequestName = organizationRequest.RequestName,
          Parameters = organizationRequest.Parameters,
          RequestId = organizationRequest.RequestId
        };
      }
      if (!obj.GetType().IsSubclassOf(typeof (Entity)))
        return obj;
      Entity entity = (Entity) obj;
      Entity objectToSerialize = new Entity();
      Entity target = objectToSerialize;
      entity.ShallowCopyTo(target);
      return (object) objectToSerialize;
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
  }
}
