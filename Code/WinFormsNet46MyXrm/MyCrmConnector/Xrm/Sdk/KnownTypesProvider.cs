// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.KnownTypesProvider
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

//using Microsoft.Xrm.Sdk.Client;
//using Microsoft.Xrm.Sdk.Metadata;
//using Microsoft.Xrm.Sdk.Metadata.Query;
//using Microsoft.Xrm.Sdk.Organization;
//using Microsoft.Xrm.Sdk.Query;
//using Microsoft.Xrm.Sdk;

//using Microsoft.Xrm.Sdk.Metadata;
using MyCrmConnector.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security;



namespace MyCrmConnector
{
  internal static class KnownTypesProvider
  {
    private static object _lockObj = new object();
    private static volatile List<Assembly> _knownAssemblies = (List<Assembly>) null;
    private static volatile Dictionary<string, Type> _knownCustomValueTypes = (Dictionary<string, Type>) null;
    private static volatile bool _regenerateknownCustomValueTypes = false;
    private static volatile Dictionary<string, Type> _knownOrganizationRequestResponseTypes = (Dictionary<string, Type>) null;
    private static volatile bool _regenerateknownOrganizationRequestResponseTypes = false;

    [SecuritySafeCritical]
    static KnownTypesProvider() => AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(KnownTypesProvider.CurrentDomain_AssemblyLoad);

    private static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args) => KnownTypesProvider.RegisterAssembly(args.LoadedAssembly);

    private static List<Assembly> KnownAssemblies
    {
      get
      {
        if (KnownTypesProvider._knownAssemblies == null)
        {
          lock (KnownTypesProvider._lockObj)
          {
            if (KnownTypesProvider._knownAssemblies == null)
            {
              List<Assembly> assemblyList = new List<Assembly>();
              foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
              {
                if (KnownTypesProvider.GetProxyTypesAttribute(assembly) != null && !assemblyList.Contains(assembly))
                {
                  assemblyList.Add(assembly);
                  KnownTypesProvider._regenerateknownCustomValueTypes = true;
                  KnownTypesProvider._regenerateknownOrganizationRequestResponseTypes = true;
                }
              }
              KnownTypesProvider._knownAssemblies = assemblyList;
            }
          }
        }
        return KnownTypesProvider._knownAssemblies;
      }
    }

    private static void RegisterAssembly(Assembly assembly)
    {
      if (KnownTypesProvider.GetProxyTypesAttribute(assembly) == null || KnownTypesProvider.KnownAssemblies.Contains(assembly))
        return;
      lock (KnownTypesProvider._lockObj)
      {
        if (KnownTypesProvider._knownAssemblies.Contains(assembly))
          return;
        KnownTypesProvider._knownAssemblies.Add(assembly);
        KnownTypesProvider._regenerateknownCustomValueTypes = true;
        KnownTypesProvider._regenerateknownOrganizationRequestResponseTypes = true;
      }
    }

    private static ProxyTypesAssemblyAttribute GetProxyTypesAttribute(
      Assembly assembly)
    {
      object[] customAttributes = assembly.GetCustomAttributes(typeof (ProxyTypesAssemblyAttribute), false);
      return customAttributes == null || customAttributes.Length == 0 ? (ProxyTypesAssemblyAttribute) null : customAttributes[0] as ProxyTypesAssemblyAttribute;
    }

    internal static Dictionary<string, Type> KnownCustomValueTypes
    {
      get
      {
        if (KnownTypesProvider._knownCustomValueTypes == null || KnownTypesProvider._regenerateknownCustomValueTypes)
        {
          lock (KnownTypesProvider._lockObj)
          {
            if (KnownTypesProvider._knownCustomValueTypes != null)
            {
              if (!KnownTypesProvider._regenerateknownCustomValueTypes)
                goto label_23;
            }
            List<Assembly> knownAssemblies = KnownTypesProvider.KnownAssemblies;
            Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
            foreach (Assembly assembly in knownAssemblies)
            {
              if (!(assembly == Assembly.GetExecutingAssembly()))
              {
                ProxyTypesAssemblyAttribute proxyTypesAttribute = KnownTypesProvider.GetProxyTypesAttribute(assembly);
                if (proxyTypesAttribute != null && proxyTypesAttribute.ContainsSharedContracts)
                {
                  foreach (Type exportedType in assembly.GetExportedTypes())
                  {
                    bool flag = false;
                    object[] customAttributes1 = exportedType.GetCustomAttributes(typeof (DataContractAttribute), false);
                    if (customAttributes1 != null && customAttributes1.Length != 0)
                    {
                      flag = true;
                    }
                    else
                    {
                      object[] customAttributes2 = exportedType.GetCustomAttributes(typeof (CollectionDataContractAttribute), false);
                      if (customAttributes2 != null && customAttributes2.Length != 0)
                        flag = true;
                    }
                    if (flag && !exportedType.IsSubclassOf(typeof (OrganizationRequest)) && !exportedType.IsSubclassOf(typeof (OrganizationResponse)) && !dictionary.ContainsKey(exportedType.Name))
                    {
                      dictionary.Add(exportedType.Name, exportedType);
                      dictionary.Add(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "ArrayOf{0}", (object) exportedType.Name), exportedType.MakeArrayType());
                      dictionary.Add(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "ArrayOfArrayOf{0}", (object) exportedType.Name), exportedType.MakeArrayType().MakeArrayType());
                    }
                  }
                }
              }
            }
            KnownTypesProvider._knownCustomValueTypes = dictionary;
            KnownTypesProvider._regenerateknownCustomValueTypes = false;
          }
        }
label_23:
        return KnownTypesProvider._knownCustomValueTypes;
      }
    }

    internal static Dictionary<string, Type> KnownOrganizationRequestResponseTypes
    {
      get
      {
        if (KnownTypesProvider._knownOrganizationRequestResponseTypes == null || KnownTypesProvider._regenerateknownOrganizationRequestResponseTypes)
        {
          lock (KnownTypesProvider._lockObj)
          {
            if (KnownTypesProvider._knownOrganizationRequestResponseTypes != null)
            {
              if (!KnownTypesProvider._regenerateknownOrganizationRequestResponseTypes)
                goto label_21;
            }
            List<Assembly> knownAssemblies = KnownTypesProvider.KnownAssemblies;
            Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
            foreach (Assembly assembly in knownAssemblies)
            {
              foreach (Type exportedType in assembly.GetExportedTypes())
              {
                object[] customAttributes = exportedType.GetCustomAttributes(typeof (DataContractAttribute), false);
                if (customAttributes != null && customAttributes.Length != 0 && (exportedType.IsSubclassOf(typeof (OrganizationRequest)) || exportedType.IsSubclassOf(typeof (OrganizationResponse))))
                {
                  foreach (DataContractAttribute contractAttribute in customAttributes)
                  {
                    string key = KnownTypesProvider.QualifiedName(contractAttribute.Name ?? exportedType.Name, contractAttribute.Namespace);
                    if (!dictionary.ContainsKey(key))
                      dictionary.Add(key, exportedType);
                  }
                }
              }
            }
            KnownTypesProvider._knownOrganizationRequestResponseTypes = dictionary;
            KnownTypesProvider._regenerateknownOrganizationRequestResponseTypes = false;
          }
        }
label_21:
        return KnownTypesProvider._knownOrganizationRequestResponseTypes;
      }
    }

    public static IEnumerable<Type> RetrieveKnownValueTypes()
    {
      List<Type> knownTypes = new List<Type>();
      KnownTypesProvider.AddKnownAttributeTypes(knownTypes);
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.AliasedValue));
      knownTypes.Add(typeof (Dictionary<string, string>));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Entity));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Entity[]));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Query.ColumnSet));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.EntityReferenceCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Query.QueryBase));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Query.QueryExpression));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Query.QueryExpression[]));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.LocalizedLabel[]));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Query.PagingInfo));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Relationship));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.AttributePrivilegeCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.RelationshipQueryCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.EntityMetadataCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.OneToManyRelationshipMetadata[]));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.Query.MetadataFilterExpression));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.Query.MetadataConditionExpression));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.Query.MetadataQueryBase));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.Query.DeletedMetadataFilters));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.Query.DeletedMetadataCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.ExecuteMultipleSettings));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.OrganizationRequestCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.OrganizationResponseCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.ExecuteMultipleResponseItemCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.QuickFindResultCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.QuickFindConfigurationCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.AttributeMappingCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.MailboxTrackingFolderMappingCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Organization.OrganizationDetail));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.KeyAttributeCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.BusinessEntityChanges));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.BusinessEntityChangesCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.ConcurrencyBehavior));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.ChangeType));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.NewOrUpdatedItem));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.RemovedOrDeletedItem));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.EntityAttributeCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.EmailEngagementAggregate));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.OptionSetValueCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Organization.OrganizationInfo));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.UserLicenseInfo));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.UserSearchFacet));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.UserSearchFacetCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.UserSearchFacetResponseCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.DependencyDepth));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.MetadataQuery));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.ImportFileUploadResponse));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.EntityRecordCountCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.DependencySummary));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.DependencySummary[]));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.LookupEntityInfo));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.EntityAndAttribute));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.LookupDataRequest));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.EntityFilePointersRequest));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.EntityFilePointersResponse));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.UpdatePointersRequest));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.ViewColumn));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.ViewColumn[]));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.LookupView));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.LookupEntityMetadata));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.LookupMetadata));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.LookupEntityResponse));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.LookupEntityResponse[]));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.LookupDataResponse));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.CascadeSPGenerationRequest));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.PrivilegeInfo));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.PrivilegeRoleMapping));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.PrivilegeRoleAssignmentRequest));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.AnalyticsStoreDetails));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.LayerDesiredOrder));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.LayerDesiredOrderType));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.SolutionParameters));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.SolutionInfo));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.StageSolutionResults));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.StageSolutionStatus));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.SolutionDetails));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.MissingDependency));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.SolutionComponentDetails));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.SolutionValidationResult));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.SolutionValidationResultType));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.SqlNameMappingOptions));
      foreach (Type type in KnownTypesProvider.KnownCustomValueTypes.Values)
        knownTypes.Add(type);
      return (IEnumerable<Type>) knownTypes;
    }

    public static IEnumerable<Type> RetrieveKnownConditionValueTypes()
    {
      List<Type> knownTypes = new List<Type>();
      KnownTypesProvider.AddKnownAttributeTypes(knownTypes);
      return (IEnumerable<Type>) knownTypes;
    }

    internal static void AddKnownAttributeTypes(List<Type> knownTypes)
    {
      knownTypes.Add(typeof (bool));
      knownTypes.Add(typeof (bool[]));
      knownTypes.Add(typeof (int));
      knownTypes.Add(typeof (int[]));
      knownTypes.Add(typeof (string));
      knownTypes.Add(typeof (string[]));
      knownTypes.Add(typeof (string[][]));
      knownTypes.Add(typeof (double));
      knownTypes.Add(typeof (double[]));
      knownTypes.Add(typeof (Decimal));
      knownTypes.Add(typeof (Decimal[]));
      knownTypes.Add(typeof (Guid));
      knownTypes.Add(typeof (Guid[]));
      knownTypes.Add(typeof (DateTime));
      knownTypes.Add(typeof (DateTime[]));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Money));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Money[]));
      knownTypes.Add(typeof (DataSet));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.EntityReference));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.EntityReference[]));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.OptionSetValue));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.OptionSetValue[]));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.EntityCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Money));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Label));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.LocalizedLabel));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.LocalizedLabelCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.EntityMetadata[]));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.EntityMetadata));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.AttributeMetadata[]));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.AttributeMetadata));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.RelationshipMetadataBase[]));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.RelationshipMetadataBase));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.EntityFilters));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.OptionSetMetadataBase));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.OptionSetMetadataBase[]));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.BooleanOptionSetMetadata));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.OptionSetType));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.ManagedPropertyMetadata));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.ManagedPropertyMetadata[]));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.EntityKeyMetadata[]));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.EntityKeyMetadata));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.EntitySetting[]));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.EntitySetting));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.BooleanManagedProperty));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Metadata.AttributeRequiredLevelManagedProperty));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.Organization.EndpointAccessType));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.GlobalSearchConfigurations));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.GlobalSearchConfigurationCollection));
      knownTypes.Add(typeof (Microsoft.Xrm.Sdk.GlobalSearchConfigurationResponseCollection));
    }

    public static List<Type> GetKnownMetadataEnumTypes() => new List<Type>()
    {
      typeof (object[]),
      typeof (Microsoft.Xrm.Sdk.Metadata.StringFormat),
      typeof (Microsoft.Xrm.Sdk.Metadata.StringFormat[]),
      typeof (Microsoft.Xrm.Sdk.Metadata.AttributeRequiredLevel),
      typeof (Microsoft.Xrm.Sdk.Metadata.AttributeRequiredLevel[]),
      typeof (Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode),
      typeof (Microsoft.Xrm.Sdk.Metadata.AttributeTypeCode[]),
      typeof (Microsoft.Xrm.Sdk.Metadata.CascadeType),
      typeof (Microsoft.Xrm.Sdk.Metadata.CascadeType[]),
      typeof (Microsoft.Xrm.Sdk.Metadata.DateTimeFormat),
      typeof (Microsoft.Xrm.Sdk.Metadata.DateTimeFormat[]),
      typeof (Microsoft.Xrm.Sdk.Metadata.IntegerFormat),
      typeof (Microsoft.Xrm.Sdk.Metadata.IntegerFormat[]),
      typeof (Microsoft.Xrm.Sdk.Metadata.LookupFormat),
      typeof (Microsoft.Xrm.Sdk.Metadata.LookupFormat[]),
      typeof (Microsoft.Xrm.Sdk.Metadata.ManagedPropertyEvaluationPriority),
      typeof (Microsoft.Xrm.Sdk.Metadata.ManagedPropertyEvaluationPriority[]),
      typeof (Microsoft.Xrm.Sdk.Metadata.ManagedPropertyOperation),
      typeof (Microsoft.Xrm.Sdk.Metadata.ManagedPropertyOperation[]),
      typeof (Microsoft.Xrm.Sdk.Metadata.ManagedPropertyType),
      typeof (Microsoft.Xrm.Sdk.Metadata.ManagedPropertyType[]),
      typeof (Microsoft.Xrm.Sdk.Metadata.SecurityTypes),
      typeof (Microsoft.Xrm.Sdk.Metadata.SecurityTypes[]),
      typeof (Microsoft.Xrm.Sdk.Metadata.OwnershipTypes),
      typeof (Microsoft.Xrm.Sdk.Metadata.OwnershipTypes[]),
      typeof (Microsoft.Xrm.Sdk.Metadata.ImeMode),
      typeof (Microsoft.Xrm.Sdk.Metadata.ImeMode[]),
      typeof (Microsoft.Xrm.Sdk.Metadata.RelationshipType),
      typeof (Microsoft.Xrm.Sdk.Metadata.RelationshipType[]),
      typeof (Microsoft.Xrm.Sdk.Metadata.AttributeTypeDisplayName),
      typeof (Microsoft.Xrm.Sdk.Metadata.AttributeTypeDisplayName[])
    };

    internal static string QualifiedName(string typeName, string typeNamespace) => string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0}/{1}", (object) typeNamespace, (object) typeName);
  }
}
