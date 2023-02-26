// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.KnownTypesResolver
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Xml;

namespace Microsoft.Xrm.Sdk
{
  public sealed class KnownTypesResolver : DataContractResolver
  {
    private static readonly IDictionary<string, Tuple<XmlDictionaryString, XmlDictionaryString>> resolvedTypes;
    private static readonly IDictionary<KnownTypesResolver.XmlTypeName, Type> ResolvedNames;
    private static readonly Lazy<bool> IsResolvedNameLookupEnabled = new Lazy<bool>(new Func<bool>(KnownTypesResolver.InitializeIsResolvedNameLookupEnabled));
    public const string MicrosoftSerialization2003slash10 = "http://schemas.microsoft.com/2003/10/Serialization/";
    public const string MicrosoftSerialization2003slash10Arrays = "http://schemas.microsoft.com/2003/10/Serialization/Arrays";
    public const string W3XmlSchema2011 = "http://www.w3.org/2001/XMLSchema";
    public const string XrmContracts2011 = "http://schemas.microsoft.com/xrm/2011/Contracts";
    public const string CrmContracts2011 = "http://schemas.microsoft.com/crm/2011/Contracts";
    public const string XrmContracts7dot1 = "http://schemas.microsoft.com/xrm/7.1/Contracts";
    public const string XrmMetadata2011 = "http://schemas.microsoft.com/xrm/2011/Metadata";
    public const string XrmMetadata2013 = "http://schemas.microsoft.com/xrm/2013/Metadata";
    public const string XrmMetadata9 = "http://schemas.microsoft.com/xrm/9.0/Metadata";

    static KnownTypesResolver()
    {
      List<KnownTypesResolver.KnownType> knownTypeList = new List<KnownTypesResolver.KnownType>();
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("Guid", "guid", "System.Guid", "http://schemas.microsoft.com/2003/10/Serialization/"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("String[]", "ArrayOfstring", "System.String[]", "http://schemas.microsoft.com/2003/10/Serialization/Arrays"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("Boolean", "boolean", "System.Boolean", "http://www.w3.org/2001/XMLSchema"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("Byte[]", "base64Binary", "System.Byte[]", "http://www.w3.org/2001/XMLSchema"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("DateTime", "dateTime", "System.DateTime", "http://www.w3.org/2001/XMLSchema"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("Decimal", "decimal", "System.Decimal", "http://www.w3.org/2001/XMLSchema"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("Double", "double", "System.Double", "http://www.w3.org/2001/XMLSchema"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("Int32", "int", "System.Int32", "http://www.w3.org/2001/XMLSchema"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("Int64", "long", "System.Int64", "http://www.w3.org/2001/XMLSchema"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("String", "string", "System.String", "http://www.w3.org/2001/XMLSchema"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("DataSet", "DataSet", typeof (DataSet).AssemblyQualifiedName, "http://www.w3.org/2001/XMLSchema"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("AddPrivilegesRoleResponse", "AddPrivilegesRoleResponse", "Microsoft.Crm.Sdk.Messages.AddPrivilegesRoleResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("AddSolutionComponentResponse", "AddSolutionComponentResponse", "Microsoft.Crm.Sdk.Messages.AddSolutionComponentResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("AssignResponse", "AssignResponse", "Microsoft.Crm.Sdk.Messages.AssignResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("DebugFlushCacheResponse", "DebugFlushCacheResponse", "Microsoft.Crm.Sdk.Messages.DebugFlushCacheResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("DebugTraceBufferGetContentsResponse", "DebugTraceBufferGetContentsResponse", "Microsoft.Crm.Sdk.Messages.DebugTraceBufferGetContentsResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("ExportSolutionResponse", "ExportSolutionResponse", "Microsoft.Crm.Sdk.Messages.ExportSolutionResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("FetchXmlToQueryExpressionRequest", "FetchXmlToQueryExpressionRequest", "Microsoft.Crm.Sdk.Messages.FetchXmlToQueryExpressionRequest", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("FetchXmlToQueryExpressionResponse", "FetchXmlToQueryExpressionResponse", "Microsoft.Crm.Sdk.Messages.FetchXmlToQueryExpressionResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("ImportSolutionResponse", "ImportSolutionResponse", "Microsoft.Crm.Sdk.Messages.ImportSolutionResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("MissingComponent[]", "ArrayOfMissingComponent", "Microsoft.Crm.Sdk.Messages.MissingComponent[]", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("PublishAllXmlResponse", "PublishAllXmlResponse", "Microsoft.Crm.Sdk.Messages.PublishAllXmlResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("PublishXmlResponse", "PublishXmlResponse", "Microsoft.Crm.Sdk.Messages.PublishXmlResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("RemoveSolutionComponentResponse", "RemoveSolutionComponentResponse", "Microsoft.Crm.Sdk.Messages.RemoveSolutionComponentResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("RetrieveDependenciesForDeleteResponse", "RetrieveDependenciesForDeleteResponse", "Microsoft.Crm.Sdk.Messages.RetrieveDependenciesForDeleteResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("RetrieveDependenciesForUninstallResponse", "RetrieveDependenciesForUninstallResponse", "Microsoft.Crm.Sdk.Messages.RetrieveDependenciesForUninstallResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("RetrieveFormattedImportJobResultsResponse", "RetrieveFormattedImportJobResultsResponse", "Microsoft.Crm.Sdk.Messages.RetrieveFormattedImportJobResultsResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("RetrieveMissingComponentsResponse", "RetrieveMissingComponentsResponse", "Microsoft.Crm.Sdk.Messages.RetrieveMissingComponentsResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("RetrieveMissingDependenciesResponse", "RetrieveMissingDependenciesResponse", "Microsoft.Crm.Sdk.Messages.RetrieveMissingDependenciesResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("RetrieveRequiredComponentsResponse", "RetrieveRequiredComponentsResponse", "Microsoft.Crm.Sdk.Messages.RetrieveRequiredComponentsResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("RetrieveUserSettingsSystemUserResponse", "RetrieveUserSettingsSystemUserResponse", "Microsoft.Crm.Sdk.Messages.RetrieveUserSettingsSystemUserResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("RetrieveVersionResponse", "RetrieveVersionResponse", "Microsoft.Crm.Sdk.Messages.RetrieveVersionResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("RolePrivilege[]", "ArrayOfRolePrivilege", "Microsoft.Crm.Sdk.Messages.RolePrivilege[]", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("SetStateRequest", "SetStateRequest", "Microsoft.Crm.Sdk.Messages.SetStateRequest", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("SetStateResponse", "SetStateResponse", "Microsoft.Crm.Sdk.Messages.SetStateResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("WhoAmIResponse", "WhoAmIResponse", "Microsoft.Crm.Sdk.Messages.WhoAmIResponse", "http://schemas.microsoft.com/crm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("AliasedValue", "AliasedValue", "Microsoft.Xrm.Sdk.AliasedValue", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("BooleanManagedProperty", "BooleanManagedProperty", "Microsoft.Xrm.Sdk.BooleanManagedProperty", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("BusinessEntityChanges", "BusinessEntityChanges", "Microsoft.Xrm.Sdk.BusinessEntityChanges", "http://schemas.microsoft.com/xrm/7.1/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("ColumnSet", "ColumnSet", "Microsoft.Xrm.Sdk.Query.ColumnSet", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("CreateAttributeResponse", "CreateAttributeResponse", "Microsoft.Xrm.Sdk.Messages.CreateAttributeResponse", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("CreateEntityResponse", "CreateEntityResponse", "Microsoft.Xrm.Sdk.Messages.CreateEntityResponse", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("CreateRequest", "CreateRequest", "Microsoft.Xrm.Sdk.Messages.CreateRequest", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("CreateResponse", "CreateResponse", "Microsoft.Xrm.Sdk.Messages.CreateResponse", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("Entity", "Entity", "Microsoft.Xrm.Sdk.Entity", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("EntityCollection", "EntityCollection", "Microsoft.Xrm.Sdk.EntityCollection", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("EntityReference", "EntityReference", "Microsoft.Xrm.Sdk.EntityReference", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("IChangedItem", "IChangedItem", "Microsoft.Xrm.Sdk.IChangedItem", "http://schemas.microsoft.com/xrm/7.1/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("Money", "Money", "Microsoft.Xrm.Sdk.Money", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("LayerDesiredOrder", "LayerDesiredOrder", "Microsoft.Xrm.Sdk.LayerDesiredOrder", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("LayerDesiredOrderType", "LayerDesiredOrderType", "Microsoft.Xrm.Sdk.LayerDesiredOrderType", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("NewOrUpdatedItem", "NewOrUpdatedItem", "Microsoft.Xrm.Sdk.NewOrUpdatedItem", "http://schemas.microsoft.com/xrm/7.1/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("OptionSetValue", "OptionSetValue", "Microsoft.Xrm.Sdk.OptionSetValue", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("QueryByAttribute", "QueryByAttribute", "Microsoft.Xrm.Sdk.Query.QueryByAttribute", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("QueryExpression", "QueryExpression", "Microsoft.Xrm.Sdk.Query.QueryExpression", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("PagingInfo", "PagingInfo", "Microsoft.Xrm.Sdk.Query.PagingInfo", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("ParameterCollection", "ParameterCollection", "Microsoft.Xrm.Sdk.ParameterCollection", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("RemovedOrDeletedItem", "RemovedOrDeletedItem", "Microsoft.Xrm.Sdk.RemovedOrDeletedItem", "http://schemas.microsoft.com/xrm/7.1/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("RetrieveAllEntitiesResponse", "RetrieveAllEntitiesResponse", "Microsoft.Xrm.Sdk.Messages.RetrieveAllEntitiesResponse", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("RetrieveAttributeRequest", "RetrieveAttributeRequest", "Microsoft.Xrm.Sdk.Messages.RetrieveAttributeRequest", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("RetrieveAttributeResponse", "RetrieveAttributeResponse", "Microsoft.Xrm.Sdk.Messages.RetrieveAttributeResponse", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("RetrieveEntityChangesRequest", "RetrieveEntityChangesRequest", "Microsoft.Xrm.Sdk.Messages.RetrieveEntityChangesRequest", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("RetrieveEntityChangesResponse", "RetrieveEntityChangesResponse", "Microsoft.Xrm.Sdk.Messages.RetrieveEntityChangesResponse", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("RetrieveEntityResponse", "RetrieveEntityResponse", "Microsoft.Xrm.Sdk.Messages.RetrieveEntityResponse", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("RetrieveMultipleRequest", "RetrieveMultipleRequest", "Microsoft.Xrm.Sdk.Messages.RetrieveMultipleRequest", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("RetrieveMultipleResponse", "RetrieveMultipleResponse", "Microsoft.Xrm.Sdk.Messages.RetrieveMultipleResponse", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("RetrieveResponse", "RetrieveResponse", "Microsoft.Xrm.Sdk.Messages.RetrieveResponse", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("SolutionInfo", "SolutionInfo", "Microsoft.Xrm.Sdk.SolutionInfo", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("SqlNameMappingOptions", "SqlNameMappingOptions", "Microsoft.Xrm.Sdk.SqlNameMappingOptions", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("UpdateRequest", "UpdateRequest", "Microsoft.Xrm.Sdk.Messages.UpdateRequest", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("UpdateResponse", "UpdateResponse", "Microsoft.Xrm.Sdk.Messages.UpdateResponse", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("StageSolutionResults", "StageSolutionResults", "Microsoft.Xrm.Sdk.StageSolutionResults", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("StageSolutionStatus", "StageSolutionStatus", "Microsoft.Xrm.Sdk.StageSolutionStatus", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("SolutionParameters", "SolutionParameters", "Microsoft.Xrm.Sdk.SolutionParameters", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("SolutionDetails", "SolutionDetails", "Microsoft.Xrm.Sdk.SolutionDetails", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("MissingDependency", "MissingDependency", "Microsoft.Xrm.Sdk.MissingDependency", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("SolutionComponentDetails", "SolutionComponentDetails", "Microsoft.Xrm.Sdk.SolutionComponentDetails", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("SolutionValidationResultType", "SolutionValidationResultType", "Microsoft.Xrm.Sdk.SolutionValidationResultType", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("SolutionValidationResult", "SolutionValidationResult", "Microsoft.Xrm.Sdk.SolutionValidationResult", "http://schemas.microsoft.com/xrm/2011/Contracts"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("BigIntAttributeMetadata", "BigIntAttributeMetadata", "Microsoft.Xrm.Sdk.Metadata.BigIntAttributeMetadata", "http://schemas.microsoft.com/xrm/2011/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("BooleanAttributeMetadata", "BooleanAttributeMetadata", "Microsoft.Xrm.Sdk.Metadata.BooleanAttributeMetadata", "http://schemas.microsoft.com/xrm/2011/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("DateTimeAttributeMetadata", "DateTimeAttributeMetadata", "Microsoft.Xrm.Sdk.Metadata.DateTimeAttributeMetadata", "http://schemas.microsoft.com/xrm/2011/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("DecimalAttributeMetadata", "DecimalAttributeMetadata", "Microsoft.Xrm.Sdk.Metadata.DecimalAttributeMetadata", "http://schemas.microsoft.com/xrm/2011/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("DoubleAttributeMetadata", "DoubleAttributeMetadata", "Microsoft.Xrm.Sdk.Metadata.DoubleAttributeMetadata", "http://schemas.microsoft.com/xrm/2011/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("EntityMetadata", "EntityMetadata", "Microsoft.Xrm.Sdk.Metadata.EntityMetadata", "http://schemas.microsoft.com/xrm/2011/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("EntityMetadata[]", "ArrayOfEntityMetadata", "Microsoft.Xrm.Sdk.Metadata.EntityMetadata[]", "http://schemas.microsoft.com/xrm/2011/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("EntityNameAttributeMetadata", "EntityNameAttributeMetadata", "Microsoft.Xrm.Sdk.Metadata.EntityNameAttributeMetadata", "http://schemas.microsoft.com/xrm/2011/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("IntegerAttributeMetadata", "IntegerAttributeMetadata", "Microsoft.Xrm.Sdk.Metadata.IntegerAttributeMetadata", "http://schemas.microsoft.com/xrm/2011/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("LookupAttributeMetadata", "LookupAttributeMetadata", "Microsoft.Xrm.Sdk.Metadata.LookupAttributeMetadata", "http://schemas.microsoft.com/xrm/2011/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("ManagedPropertyAttributeMetadata", "ManagedPropertyAttributeMetadata", "Microsoft.Xrm.Sdk.Metadata.ManagedPropertyAttributeMetadata", "http://schemas.microsoft.com/xrm/2011/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("MemoAttributeMetadata", "MemoAttributeMetadata", "Microsoft.Xrm.Sdk.Metadata.MemoAttributeMetadata", "http://schemas.microsoft.com/xrm/2011/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("MoneyAttributeMetadata", "MoneyAttributeMetadata", "Microsoft.Xrm.Sdk.Metadata.MoneyAttributeMetadata", "http://schemas.microsoft.com/xrm/2011/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("PicklistAttributeMetadata", "PicklistAttributeMetadata", "Microsoft.Xrm.Sdk.Metadata.PicklistAttributeMetadata", "http://schemas.microsoft.com/xrm/2011/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("StateAttributeMetadata", "StateAttributeMetadata", "Microsoft.Xrm.Sdk.Metadata.StateAttributeMetadata", "http://schemas.microsoft.com/xrm/2011/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("StateOptionMetadata", "StateOptionMetadata", "Microsoft.Xrm.Sdk.Metadata.StateOptionMetadata", "http://schemas.microsoft.com/xrm/2011/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("StatusAttributeMetadata", "StatusAttributeMetadata", "Microsoft.Xrm.Sdk.Metadata.StatusAttributeMetadata", "http://schemas.microsoft.com/xrm/2011/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("StatusOptionMetadata", "StatusOptionMetadata", "Microsoft.Xrm.Sdk.Metadata.StatusOptionMetadata", "http://schemas.microsoft.com/xrm/2011/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("StringAttributeMetadata", "StringAttributeMetadata", "Microsoft.Xrm.Sdk.Metadata.StringAttributeMetadata", "http://schemas.microsoft.com/xrm/2011/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("ImageAttributeMetadata", "ImageAttributeMetadata", "Microsoft.Xrm.Sdk.Metadata.ImageAttributeMetadata", "http://schemas.microsoft.com/xrm/2013/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("MultiSelectPicklistAttributeMetadata", "MultiSelectPicklistAttributeMetadata", "Microsoft.Xrm.Sdk.Metadata.MultiSelectPicklistAttributeMetadata", "http://schemas.microsoft.com/xrm/9.0/Metadata"));
      knownTypeList.Add(KnownTypesResolver.KnownType.Create("FileAttributeMetadata", "FileAttributeMetadata", "Microsoft.Xrm.Sdk.Metadata.FileAttributeMetadata", "http://schemas.microsoft.com/xrm/9.0/Metadata"));
      KnownTypesResolver.resolvedTypes = (IDictionary<string, Tuple<XmlDictionaryString, XmlDictionaryString>>) new Dictionary<string, Tuple<XmlDictionaryString, XmlDictionaryString>>(knownTypeList.Count, (IEqualityComparer<string>) StringComparer.Ordinal);
      KnownTypesResolver.ResolvedNames = (IDictionary<KnownTypesResolver.XmlTypeName, Type>) new Dictionary<KnownTypesResolver.XmlTypeName, Type>(knownTypeList.Count);
      foreach (KnownTypesResolver.KnownType knownType in knownTypeList)
      {
        KnownTypesResolver.resolvedTypes.Add(knownType.ClrName, KnownTypesResolver.GetTuple(knownType.XmlName, knownType.XmlNamespace));
        Type type = Type.GetType(knownType.ClrFullName);
        if (type != (Type) null)
          KnownTypesResolver.ResolvedNames.Add(new KnownTypesResolver.XmlTypeName(knownType.XmlName, knownType.XmlNamespace), type);
      }
    }

    public override Type ResolveName(
      string typeName,
      string typeNamespace,
      Type declaredType,
      DataContractResolver knownTypeResolver)
    {
      Type type1;
      if (KnownTypesResolver.IsResolvedNameLookupEnabled.Value && KnownTypesResolver.ResolvedNames.TryGetValue(new KnownTypesResolver.XmlTypeName(typeName, typeNamespace), out type1))
        return type1;
      Type type2 = knownTypeResolver.ResolveName(typeName, typeNamespace, declaredType, (DataContractResolver) null);
      if (type2 == (Type) null && !KnownTypesProvider.KnownOrganizationRequestResponseTypes.TryGetValue(KnownTypesProvider.QualifiedName(typeName, typeNamespace), out type2))
        KnownTypesProvider.KnownCustomValueTypes?.TryGetValue(typeName, out type2);
      return type2;
    }

    public override bool TryResolveType(
      Type type,
      Type declaredType,
      DataContractResolver knownTypeResolver,
      out XmlDictionaryString typeName,
      out XmlDictionaryString typeNamespace)
    {
      typeName = (XmlDictionaryString) null;
      typeNamespace = (XmlDictionaryString) null;
      Tuple<XmlDictionaryString, XmlDictionaryString> tuple;
      if (this.ResolvedTypes.TryGetValue(type.Name, out tuple))
      {
        typeName = tuple.Item1;
        typeNamespace = tuple.Item2;
        return true;
      }
      if (!knownTypeResolver.TryResolveType(type, declaredType, (DataContractResolver) null, out typeName, out typeNamespace))
      {
        typeName = new XmlDictionaryString(XmlDictionary.Empty, type.Name, 0);
        Type type1 = type;
        if (type.IsArray)
        {
          Type elementType = type.GetElementType();
          if (elementType.IsArray)
            elementType = type1.GetElementType();
          Type type2 = elementType;
          if ((object) type2 == null)
            type2 = type;
          type1 = type2;
        }
        string empty = string.Empty;
        object[] customAttributes = type1.GetCustomAttributes(typeof (DataContractAttribute), false);
        if (customAttributes != null)
        {
          object[] objArray = customAttributes;
          int index = 0;
          if (index < objArray.Length)
          {
            DataContractAttribute contractAttribute = (DataContractAttribute) objArray[index];
            if (!string.IsNullOrEmpty(contractAttribute.Namespace))
            {
              string str = contractAttribute.Namespace;
              typeNamespace = new XmlDictionaryString(XmlDictionary.Empty, str, 0);
            }
          }
        }
        if (typeNamespace == null)
          typeNamespace = new XmlDictionaryString(XmlDictionary.Empty, type.Namespace, 0);
      }
      return true;
    }

    public IDictionary<string, Tuple<XmlDictionaryString, XmlDictionaryString>> ResolvedTypes => KnownTypesResolver.resolvedTypes;

    private static Tuple<XmlDictionaryString, XmlDictionaryString> GetTuple(
      string typeName,
      string typeNamespace)
    {
      XmlDictionary xmlDictionary = new XmlDictionary();
      return new Tuple<XmlDictionaryString, XmlDictionaryString>(xmlDictionary.Add(typeName), xmlDictionary.Add(typeNamespace));
    }

    private static bool InitializeIsResolvedNameLookupEnabled()
    {
      using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\MSCRM", false))
      {
        if (registryKey != null)
        {
          object obj = registryKey.GetValue("KnownTypeResolverResolvedNameLookup");
          if (obj != null)
          {
            if (obj is int num)
              return num > 0;
          }
        }
      }
      return true;
    }

    private class KnownType
    {
      public string ClrName;
      public string XmlName;
      public string ClrFullName;
      public string XmlNamespace;

      public static KnownTypesResolver.KnownType Create(
        string clrName,
        string xmlName,
        string clrFullName,
        string xmlNamespace)
      {
        return new KnownTypesResolver.KnownType()
        {
          ClrName = clrName,
          XmlName = xmlName,
          XmlNamespace = xmlNamespace,
          ClrFullName = clrFullName
        };
      }
    }

    private class XmlTypeName : IEquatable<KnownTypesResolver.XmlTypeName>
    {
      private readonly string typeName;
      private readonly string typeNamespace;

      public XmlTypeName(string typeName, string typeNamespace)
      {
        this.typeName = typeName;
        this.typeNamespace = typeNamespace;
      }

      public bool Equals(KnownTypesResolver.XmlTypeName other)
      {
        if ((object) other == null)
          return false;
        if ((object) this == (object) other)
          return true;
        return string.Equals(this.typeName, other.typeName) && string.Equals(this.typeNamespace, other.typeNamespace);
      }

      public override bool Equals(object obj)
      {
        if (obj == null)
          return false;
        if ((object) this == obj)
          return true;
        return !(obj.GetType() != this.GetType()) && this.Equals((KnownTypesResolver.XmlTypeName) obj);
      }

      public override int GetHashCode() => (this.typeName != null ? this.typeName.GetHashCode() : 0) * 397 ^ (this.typeNamespace != null ? this.typeNamespace.GetHashCode() : 0);

      public static bool operator ==(
        KnownTypesResolver.XmlTypeName left,
        KnownTypesResolver.XmlTypeName right)
      {
        return object.Equals((object) left, (object) right);
      }

      public static bool operator !=(
        KnownTypesResolver.XmlTypeName left,
        KnownTypesResolver.XmlTypeName right)
      {
        return !object.Equals((object) left, (object) right);
      }
    }
  }
}
