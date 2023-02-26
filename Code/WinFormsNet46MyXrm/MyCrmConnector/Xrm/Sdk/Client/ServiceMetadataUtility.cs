// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.ServiceMetadataUtility
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Crm.Protocols.WSTrust.Bindings;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IdentityModel.Tokens;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Xml;

namespace MyCrmConnector.Client
{
    internal static class ServiceMetadataUtility
    {
        public static IssuerEndpointDictionary RetrieveIssuerEndpoints(
          EndpointAddress issuerMetadataAddress)
        {
            IssuerEndpointDictionary endpointDictionary = new IssuerEndpointDictionary();
            MetadataSet metadata = ServiceMetadataUtility.CreateMetadataClient(issuerMetadataAddress.Uri.Scheme).GetMetadata(issuerMetadataAddress.Uri, MetadataExchangeClientMode.HttpGet);
            if (metadata != null)
            {
                foreach (ServiceEndpoint importAllEndpoint in (Collection<ServiceEndpoint>)new WsdlImporter(metadata).ImportAllEndpoints())
                {
                    if (!(importAllEndpoint.Binding is NetTcpBinding))
                    {
                        TokenServiceCredentialType serviceCredentialType = TokenServiceCredentialType.None;
                        TrustVersion trustVersion = TrustVersion.Default;
                        if (importAllEndpoint.Binding is WS2007HttpBinding binding)
                        {
                            SecurityBindingElement securityBindingElement = binding.CreateBindingElements().Find<SecurityBindingElement>();
                            if (securityBindingElement != null)
                            {
                                trustVersion = securityBindingElement.MessageSecurityVersion.TrustVersion;
                                if (trustVersion == TrustVersion.WSTrust13)
                                {
                                    if (binding.Security.Message.ClientCredentialType == MessageCredentialType.UserName)
                                        serviceCredentialType = TokenServiceCredentialType.Username;
                                    else if (binding.Security.Message.ClientCredentialType == MessageCredentialType.Certificate)
                                        serviceCredentialType = TokenServiceCredentialType.Certificate;
                                    else if (binding.Security.Message.ClientCredentialType == MessageCredentialType.Windows)
                                        serviceCredentialType = TokenServiceCredentialType.Windows;
                                }
                            }
                        }
                        else
                        {
                            SecurityBindingElement securityElement = importAllEndpoint.Binding.CreateBindingElements().Find<SecurityBindingElement>();
                            if (securityElement != null)
                            {
                                trustVersion = securityElement.MessageSecurityVersion.TrustVersion;
                                if (trustVersion == TrustVersion.WSTrust13)
                                {
                                    IssuedSecurityTokenParameters issuedTokenParameters = ServiceMetadataUtility.GetIssuedTokenParameters(securityElement);
                                    if (issuedTokenParameters != null)
                                    {
                                        if (issuedTokenParameters.KeyType == SecurityKeyType.SymmetricKey)
                                            serviceCredentialType = TokenServiceCredentialType.SymmetricToken;
                                        else if (issuedTokenParameters.KeyType == SecurityKeyType.AsymmetricKey)
                                            serviceCredentialType = TokenServiceCredentialType.AsymmetricToken;
                                        else if (issuedTokenParameters.KeyType == SecurityKeyType.BearerKey)
                                            serviceCredentialType = TokenServiceCredentialType.Bearer;
                                    }
                                    else if (ServiceMetadataUtility.GetKerberosTokenParameters(securityElement) != null)
                                        serviceCredentialType = TokenServiceCredentialType.Kerberos;
                                }
                            }
                        }
                        if (serviceCredentialType != TokenServiceCredentialType.None)
                        {
                            string key = serviceCredentialType.ToString();
                            if (!endpointDictionary.ContainsKey(key))
                                endpointDictionary.Add(key, new IssuerEndpoint()
                                {
                                    IssuerAddress = importAllEndpoint.Address,
                                    IssuerBinding = importAllEndpoint.Binding,
                                    IssuerMetadataAddress = issuerMetadataAddress,
                                    CredentialType = serviceCredentialType,
                                    TrustVersion = trustVersion
                                });
                        }
                    }
                }
            }
            return endpointDictionary;
        }

        public static IssuerEndpointDictionary RetrieveLiveIdIssuerEndpoints(
          IdentityProviderTrustConfiguration identityProviderTrustConfiguration)
        {
            //IssuerEndpointDictionary endpointDictionary = new IssuerEndpointDictionary();
            //endpointDictionary.Add(TokenServiceCredentialType.Username.ToString(), new IssuerEndpoint()
            //{
            //  CredentialType = TokenServiceCredentialType.Username,
            //  IssuerAddress = new EndpointAddress(identityProviderTrustConfiguration.Endpoint.AbsoluteUri),
            //  IssuerBinding = identityProviderTrustConfiguration.Binding
            //});
            //IssuedTokenWSTrustBinding tokenWsTrustBinding1 = new IssuedTokenWSTrustBinding();
            //tokenWsTrustBinding1.TrustVersion = identityProviderTrustConfiguration.TrustVersion;
            //tokenWsTrustBinding1.SecurityMode = identityProviderTrustConfiguration.SecurityMode;
            //IssuedTokenWSTrustBinding tokenWsTrustBinding2 = tokenWsTrustBinding1;
            //tokenWsTrustBinding2.KeyType = SecurityKeyType.BearerKey;
            //endpointDictionary.Add(TokenServiceCredentialType.SymmetricToken.ToString(), new IssuerEndpoint()
            //{
            //  CredentialType = TokenServiceCredentialType.SymmetricToken,
            //  IssuerAddress = new EndpointAddress(identityProviderTrustConfiguration.Endpoint.AbsoluteUri),
            //  IssuerBinding = (Binding) tokenWsTrustBinding2
            //});
            //return endpointDictionary;
            Console.WriteLine("RetrieveLiveIdIssuerEndpoints");
            throw new NotImplementedException();
        }

        public static IssuerEndpointDictionary RetrieveDefaultIssuerEndpoint(
          AuthenticationProviderType authenticationProviderType,
          IssuerEndpoint issuer)
        {
            IssuerEndpointDictionary endpointDictionary = new IssuerEndpointDictionary();
            if (issuer != null && issuer.IssuerAddress != (EndpointAddress)null)
            {
                TokenServiceCredentialType serviceCredentialType;
                switch (authenticationProviderType)
                {
                    case AuthenticationProviderType.Federation:
                        serviceCredentialType = TokenServiceCredentialType.Kerberos;
                        break;
                    case AuthenticationProviderType.OnlineFederation:
                        serviceCredentialType = TokenServiceCredentialType.Username;
                        break;
                    default:
                        serviceCredentialType = TokenServiceCredentialType.Kerberos;
                        break;
                }
                endpointDictionary.Add(serviceCredentialType.ToString(), new IssuerEndpoint()
                {
                    CredentialType = serviceCredentialType,
                    IssuerAddress = issuer.IssuerAddress,
                    IssuerBinding = issuer.IssuerBinding
                });
            }
            return endpointDictionary;
        }

        public static IssuerEndpointDictionary RetrieveIssuerEndpoints(
          AuthenticationProviderType authenticationProviderType,
          ServiceEndpointDictionary endpoints,
          bool queryMetadata)
        {
            foreach (ServiceEndpoint serviceEndpoint in endpoints.Values)
            {
                try
                {
                    IssuerEndpoint issuer = ServiceMetadataUtility.GetIssuer(serviceEndpoint.Binding);
                    if (issuer != null)
                        return queryMetadata && issuer.IssuerMetadataAddress != (EndpointAddress)null ? ServiceMetadataUtility.RetrieveIssuerEndpoints(issuer.IssuerMetadataAddress) : ServiceMetadataUtility.RetrieveDefaultIssuerEndpoint(authenticationProviderType, issuer);
                }
                catch (Exception ex)
                {
                }
            }
            return new IssuerEndpointDictionary();
        }

        public static IssuerEndpoint GetIssuer(Binding binding)
        {
            if (binding == null)
                return (IssuerEndpoint)null;
            IssuedSecurityTokenParameters issuedTokenParameters = ServiceMetadataUtility.GetIssuedTokenParameters(binding.CreateBindingElements().Find<SecurityBindingElement>());
            if (issuedTokenParameters == null)
                return (IssuerEndpoint)null;
            return new IssuerEndpoint()
            {
                IssuerAddress = issuedTokenParameters.IssuerAddress,
                IssuerBinding = issuedTokenParameters.IssuerBinding,
                IssuerMetadataAddress = issuedTokenParameters.IssuerMetadataAddress
            };
        }

        private static KerberosSecurityTokenParameters GetKerberosTokenParameters(
          SecurityBindingElement securityElement)
        {
            return securityElement != null && securityElement.EndpointSupportingTokenParameters != null && securityElement.EndpointSupportingTokenParameters.Endorsing != null && securityElement.EndpointSupportingTokenParameters.Endorsing.Count > 0 ? securityElement.EndpointSupportingTokenParameters.Endorsing[0] as KerberosSecurityTokenParameters : (KerberosSecurityTokenParameters)null;
        }

        private static IssuedSecurityTokenParameters GetIssuedTokenParameters(
          SecurityBindingElement securityElement)
        {
            if (securityElement != null && securityElement.EndpointSupportingTokenParameters != null)
            {
                if (securityElement.EndpointSupportingTokenParameters.Endorsing != null && securityElement.EndpointSupportingTokenParameters.Endorsing.Count > 0)
                {
                    if (securityElement.EndpointSupportingTokenParameters.Endorsing[0] is IssuedSecurityTokenParameters issuedTokenParameters)
                        return issuedTokenParameters;
                    if (securityElement.EndpointSupportingTokenParameters.Endorsing[0] is SecureConversationSecurityTokenParameters securityTokenParameters)
                    {
                        if (securityTokenParameters.BootstrapSecurityBindingElement.EndpointSupportingTokenParameters.Endorsing.Count > 0)
                            return securityTokenParameters.BootstrapSecurityBindingElement.EndpointSupportingTokenParameters.Endorsing[0] as IssuedSecurityTokenParameters;
                        if (securityTokenParameters.BootstrapSecurityBindingElement.EndpointSupportingTokenParameters.Signed.Count > 0)
                            return securityTokenParameters.BootstrapSecurityBindingElement.EndpointSupportingTokenParameters.Signed[0] as IssuedSecurityTokenParameters;
                    }
                }
                else if (securityElement.EndpointSupportingTokenParameters.Signed != null && securityElement.EndpointSupportingTokenParameters.Signed.Count > 0)
                    return securityElement.EndpointSupportingTokenParameters.Signed[0] as IssuedSecurityTokenParameters;
            }
            return (IssuedSecurityTokenParameters)null;
        }

        public static CustomBinding SetIssuer(
          Binding binding,
          IssuerEndpoint issuerEndpoint)
        {
            BindingElementCollection bindingElements = binding.CreateBindingElements();
            IssuedSecurityTokenParameters issuedTokenParameters = ServiceMetadataUtility.GetIssuedTokenParameters(bindingElements.Find<SecurityBindingElement>());
            if (issuedTokenParameters != null)
            {
                issuedTokenParameters.IssuerAddress = issuerEndpoint.IssuerAddress;
                issuedTokenParameters.IssuerBinding = issuerEndpoint.IssuerBinding;
                if (issuerEndpoint.IssuerMetadataAddress != (EndpointAddress)null)
                    issuedTokenParameters.IssuerMetadataAddress = issuerEndpoint.IssuerMetadataAddress;
            }
            return new CustomBinding((IEnumerable<BindingElement>)bindingElements);
        }

        private static void ParseEndpoints(
          ServiceEndpointDictionary serviceEndpoints,
          ServiceEndpointCollection serviceEndpointCollection)
        {
            serviceEndpoints.Clear();
            if (serviceEndpointCollection == null)
                return;
            foreach (ServiceEndpoint serviceEndpoint in (Collection<ServiceEndpoint>)serviceEndpointCollection)
            {
                if (ServiceMetadataUtility.IsEndpointSupported(serviceEndpoint))
                    serviceEndpoints.Add(serviceEndpoint.Name, serviceEndpoint);
            }
        }

        private static bool IsEndpointSupported(ServiceEndpoint endpoint) => endpoint != null && !endpoint.Address.Uri.AbsolutePath.EndsWith("web", StringComparison.OrdinalIgnoreCase);

        internal static ServiceEndpointMetadata RetrieveServiceEndpointMetadata(
          System.Type contractType,
          Uri serviceUri,
          bool checkForSecondary)
        {
            ServiceEndpointMetadata serviceEndpointMetadata = new ServiceEndpointMetadata();
            serviceEndpointMetadata.ServiceUrls = ServiceConfiguration<IOrganizationService>.CalculateEndpoints(serviceUri);
            if (!checkForSecondary)
                serviceEndpointMetadata.ServiceUrls.AlternateEndpoint = (Uri)null;
            double numberFromAssembly = ServiceMetadataUtility.GetSDKVersionNumberFromAssembly();
            Uri address = new Uri(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "{0}{1}&sdkversion={2}", (object)serviceUri.AbsoluteUri, (object)"?wsdl", (object)numberFromAssembly));
            MetadataExchangeClient metadataClient = ServiceMetadataUtility.CreateMetadataClient(address.Scheme);
            if (metadataClient != null)
            {
                try
                {
                    serviceEndpointMetadata.ServiceMetadata = metadataClient.GetMetadata(address, MetadataExchangeClientMode.HttpGet);
                }
                catch (InvalidOperationException ex)
                {
                    bool flag = true;
                    if (checkForSecondary && ex.InnerException is WebException innerException && (innerException.Status == WebExceptionStatus.NameResolutionFailure || innerException.Status == WebExceptionStatus.Timeout) && serviceEndpointMetadata.ServiceUrls != null)
                    {
                        if (serviceEndpointMetadata.ServiceUrls.PrimaryEndpoint == serviceUri)
                            flag = ServiceMetadataUtility.TryRetrieveMetadata(metadataClient, new Uri(serviceEndpointMetadata.ServiceUrls.AlternateEndpoint.AbsoluteUri + "?wsdl"), serviceEndpointMetadata);
                        else if (serviceEndpointMetadata.ServiceUrls.AlternateEndpoint == serviceUri)
                            flag = ServiceMetadataUtility.TryRetrieveMetadata(metadataClient, new Uri(serviceEndpointMetadata.ServiceUrls.PrimaryEndpoint.AbsoluteUri + "?wsdl"), serviceEndpointMetadata);
                    }
                    if (flag)
                        throw;
                }
            }
            ClientExceptionHelper.ThrowIfNull((object)serviceEndpointMetadata.ServiceMetadata, "STS Metadata");
            Collection<ContractDescription> contractCollection = ServiceMetadataUtility.CreateContractCollection(contractType);
            if (contractCollection != null)
            {
                WsdlImporter importer = new WsdlImporter(serviceEndpointMetadata.ServiceMetadata);
                KeyedByTypeCollection<IWsdlImportExtension> importExtensions = importer.WsdlImportExtensions;
                List<IPolicyImportExtension> policyImporter = ServiceMetadataUtility.AddSecurityBindingToPolicyImporter(importer);
                WsdlImporter wsdlImporter = new WsdlImporter(serviceEndpointMetadata.ServiceMetadata, (IEnumerable<IPolicyImportExtension>)policyImporter, (IEnumerable<IWsdlImportExtension>)importExtensions);
                foreach (ContractDescription contract in contractCollection)
                    wsdlImporter.KnownContracts.Add(ServiceMetadataUtility.GetPortTypeQName(contract), contract);
                ServiceEndpointCollection serviceEndpointCollection = wsdlImporter.ImportAllEndpoints();
                if (wsdlImporter.Errors.Count > 0)
                {
                    foreach (MetadataConversionError error in wsdlImporter.Errors)
                        serviceEndpointMetadata.MetadataConversionErrors.Add(error);
                }
                ServiceMetadataUtility.ParseEndpoints(serviceEndpointMetadata.ServiceEndpoints, serviceEndpointCollection);
            }
            return serviceEndpointMetadata;
        }

        private static double GetSDKVersionNumberFromAssembly()
        {
            //string[] strArray = OrganizationServiceProxy.GetXrmSdkAssemblyFileVersion().Split('.');
            //double result = 0.0;
            //if (strArray.Length >= 2 && !double.TryParse(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "{0}.{1}", (object) strArray[0], (object) strArray[1]), out result))
            //  result = 0.0;
            //return result;
            return 0;
        }

        private static List<IPolicyImportExtension> AddSecurityBindingToPolicyImporter(
          WsdlImporter importer)
        {
            List<IPolicyImportExtension> policyImporter = new List<IPolicyImportExtension>();
            KeyedByTypeCollection<IPolicyImportExtension> importExtensions = importer.PolicyImportExtensions;
            SecurityBindingElementImporter importer1 = importExtensions.Find<SecurityBindingElementImporter>();
            if (importer1 != null)
                importExtensions.Remove<SecurityBindingElementImporter>();
            else
                importer1 = new SecurityBindingElementImporter();
            policyImporter.Add((IPolicyImportExtension)new AuthenticationPolicyImporter(importer1));
            policyImporter.AddRange((IEnumerable<IPolicyImportExtension>)importExtensions);
            return policyImporter;
            //throw new NotImplementedException();
        }

        private static bool TryRetrieveMetadata(
          MetadataExchangeClient mcli,
          Uri serviceEndpoint,
          ServiceEndpointMetadata serviceEndpointMetadata)
        {
            bool flag = true;
            try
            {
                serviceEndpointMetadata.ServiceMetadata = mcli.GetMetadata(serviceEndpoint, MetadataExchangeClientMode.HttpGet);
                serviceEndpointMetadata.ServiceUrls.GeneratedFromAlternate = true;
                flag = false;
            }
            catch
            {
            }
            return flag;
        }

        private static XmlQualifiedName GetPortTypeQName(ContractDescription contract) => new XmlQualifiedName(contract.Name, contract.Namespace);

        private static Collection<ContractDescription> CreateContractCollection(
          System.Type contract)
        {
            return new Collection<ContractDescription>()
      {
        ContractDescription.GetContract(contract)
      };
        }

        private static MetadataExchangeClient CreateMetadataClient(string scheme)
        {
            WSHttpBinding mexBinding = string.Compare(scheme, "https", StringComparison.OrdinalIgnoreCase) != 0 ? MetadataExchangeBindings.CreateMexHttpBinding() as WSHttpBinding : MetadataExchangeBindings.CreateMexHttpsBinding() as WSHttpBinding;
            mexBinding.MaxReceivedMessageSize = (long)int.MaxValue;
            mexBinding.ReaderQuotas.MaxNameTableCharCount = int.MaxValue;
            return new MetadataExchangeClient((Binding)mexBinding)
            {
                ResolveMetadataReferences = true,
                MaximumResolvedReferences = 100
            };
            //throw new NotImplementedException();
        }

        public static void ReplaceEndpointAddress(ServiceEndpoint endpoint, Uri adddress) => endpoint.Address = new EndpointAddressBuilder(endpoint.Address)
        {
            Uri = adddress
        }.ToEndpointAddress();

        internal static void AdjustUserNameForWindows(ClientCredentials clientCredentials)
        {
            //Microsoft.Xrm.Sdk.ClientExceptionHelper.ThrowIfNull((object) clientCredentials, nameof (clientCredentials));
            //if (string.IsNullOrWhiteSpace(clientCredentials.UserName.UserName))
            //  return;
            //NetworkCredential networkCredential;
            //if (clientCredentials.UserName.UserName.IndexOf('@') > -1)
            //{
            //  string[] strArray = clientCredentials.UserName.UserName.Split('@');
            //  networkCredential = strArray.Length <= 1 ? new NetworkCredential(strArray[0], clientCredentials.UserName.Password) : new NetworkCredential(strArray[0], clientCredentials.UserName.Password, strArray[1]);
            //}
            //else if (clientCredentials.UserName.UserName.IndexOf('\\') > -1)
            //{
            //  string[] strArray = clientCredentials.UserName.UserName.Split('\\');
            //  networkCredential = strArray.Length <= 1 ? new NetworkCredential(strArray[0], clientCredentials.UserName.Password) : new NetworkCredential(strArray[1], clientCredentials.UserName.Password, strArray[0]);
            //}
            //else
            //  networkCredential = new NetworkCredential(clientCredentials.UserName.UserName, clientCredentials.UserName.Password);
            //clientCredentials.Windows.ClientCredential = networkCredential;
            //clientCredentials.UserName.UserName = string.Empty;
            //clientCredentials.UserName.Password = string.Empty;
            Console.WriteLine("AdjustUserNameForWindows");
            throw new NotImplementedException();
        }
    }
}
