// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.WebServiceClient.WebProxyClient`1
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace Microsoft.Xrm.Sdk.WebServiceClient
{
  public abstract class WebProxyClient<TService> : ClientBase<TService>, IDisposable
    where TService : class
  {
    private string _xrmSdkAssemblyFileVersion;

    protected WebProxyClient(Uri serviceUrl, bool useStrongTypes)
      : base(WebProxyClient<TService>.CreateServiceEndpoint(serviceUrl, useStrongTypes, Utilites.DefaultTimeout, (Assembly) null))
    {
    }

    protected WebProxyClient(Uri serviceUrl, Assembly strongTypeAssembly)
      : base(WebProxyClient<TService>.CreateServiceEndpoint(serviceUrl, true, Utilites.DefaultTimeout, strongTypeAssembly))
    {
    }

    protected WebProxyClient(Uri serviceUrl, TimeSpan timeout, bool useStrongTypes)
      : base(WebProxyClient<TService>.CreateServiceEndpoint(serviceUrl, useStrongTypes, timeout, (Assembly) null))
    {
    }

    protected WebProxyClient(Uri serviceUrl, TimeSpan timeout, Assembly strongTypeAssembly)
      : base(WebProxyClient<TService>.CreateServiceEndpoint(serviceUrl, true, timeout, strongTypeAssembly))
    {
    }

    public string HeaderToken { get; set; }

    public string SdkClientVersion { get; set; }

    internal string ClientAppName { get; set; }

    internal string ClientAppVersion { get; set; }

    protected abstract WebProxyClientContextInitializer<TService> CreateNewInitializer();

    internal void ExecuteAction(Action action)
    {
      if (action == null)
        throw new ArgumentNullException(nameof (action));
      using (this.CreateNewInitializer())
        action();
    }

    internal TResult ExecuteAction<TResult>(Func<TResult> action)
    {
      if (action == null)
        throw new ArgumentNullException(nameof (action));
      using (this.CreateNewInitializer())
        return action();
    }

    protected static ServiceEndpoint CreateServiceEndpoint(
      Uri serviceUrl,
      bool useStrongTypes,
      TimeSpan timeout,
      Assembly strongTypeAssembly)
    {
      ServiceEndpoint baseServiceEndpoint = WebProxyClient<TService>.CreateBaseServiceEndpoint(serviceUrl, timeout);
      if (baseServiceEndpoint.EndpointBehaviors.Contains(typeof (ProxyTypesBehavior)))
      {
        IEndpointBehavior endpointBehavior = baseServiceEndpoint.EndpointBehaviors[typeof (ProxyTypesBehavior)];
        if (endpointBehavior != null)
          baseServiceEndpoint.EndpointBehaviors.Remove(endpointBehavior);
      }
      if (useStrongTypes)
        baseServiceEndpoint.EndpointBehaviors.Add(strongTypeAssembly != (Assembly) null ? (IEndpointBehavior) new ProxyTypesBehavior(strongTypeAssembly) : (IEndpointBehavior) new ProxyTypesBehavior());
      return baseServiceEndpoint;
    }

    private static ServiceEndpoint CreateBaseServiceEndpoint(
      Uri serviceUrl,
      TimeSpan timeout)
    {
      Binding binding = WebProxyClient<TService>.GetBinding(serviceUrl, timeout);
      EndpointAddress address = new EndpointAddress(serviceUrl, Array.Empty<AddressHeader>());
      ServiceEndpoint baseServiceEndpoint = new ServiceEndpoint(ContractDescription.GetContract(typeof (TService)), binding, address);
      foreach (OperationDescription operation in (Collection<OperationDescription>) baseServiceEndpoint.Contract.Operations)
      {
        DataContractSerializerOperationBehavior operationBehavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
        if (operationBehavior != null)
          operationBehavior.MaxItemsInObjectGraph = int.MaxValue;
      }
      return baseServiceEndpoint;
    }

    protected static Binding GetBinding(Uri serviceUrl, TimeSpan timeout)
    {
      BasicHttpBinding binding = new BasicHttpBinding(serviceUrl.Scheme == "https" ? BasicHttpSecurityMode.Transport : BasicHttpSecurityMode.TransportCredentialOnly);
      binding.MaxReceivedMessageSize = (long) int.MaxValue;
      binding.MaxBufferSize = int.MaxValue;
      binding.SendTimeout = timeout;
      binding.ReceiveTimeout = timeout;
      binding.OpenTimeout = timeout;
      binding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
      binding.ReaderQuotas.MaxArrayLength = int.MaxValue;
      binding.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
      binding.ReaderQuotas.MaxNameTableCharCount = int.MaxValue;
      return (Binding) binding;
    }

    [PermissionSet(SecurityAction.Demand, Unrestricted = true)]
    internal string GetXrmSdkAssemblyFileVersion()
    {
      if (string.IsNullOrEmpty(this._xrmSdkAssemblyFileVersion))
      {
        string[] strArray = new string[1]
        {
          "Microsoft.Xrm.Sdk.dll"
        };
        Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
        foreach (string str in strArray)
        {
          foreach (Assembly assembly in assemblies)
          {
            if (assembly.ManifestModule.Name.Equals(str, StringComparison.OrdinalIgnoreCase) && !string.IsNullOrEmpty(assembly.Location) && File.Exists(assembly.Location))
            {
              this._xrmSdkAssemblyFileVersion = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
              break;
            }
          }
        }
      }
      if (string.IsNullOrEmpty(this._xrmSdkAssemblyFileVersion))
        this._xrmSdkAssemblyFileVersion = "9.1.2.3";
      return this._xrmSdkAssemblyFileVersion;
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
    }

    ~WebProxyClient() => this.Dispose(false);
  }
}
