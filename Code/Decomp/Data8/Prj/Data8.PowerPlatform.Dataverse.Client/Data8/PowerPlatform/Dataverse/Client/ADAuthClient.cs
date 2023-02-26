// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.ADAuthClient
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using NSspi.Contexts;
using NSspi.Credentials;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Data8.PowerPlatform.Dataverse.Client
{
  internal class ADAuthClient : 
    IOrganizationServiceAsync2,
    IOrganizationServiceAsync,
    IOrganizationService,
    IInnerOrganizationService
  {
    private readonly string _url;
    private readonly string _domain;
    private readonly string _username;
    private readonly string _password;
    private readonly string _upn;
    private readonly ProxySerializationSurrogate _serializationSurrogate;
    private DateTime _tokenExpires;
    private byte[] _proofToken;
    private SecurityContextToken _securityContextToken;

    public ADAuthClient(string url, string username, string password, string upn)
    {
      if (Environment.OSVersion.Platform == PlatformID.Unix)
        throw new PlatformNotSupportedException("Windows authentication is only available on Windows clients or when using .NET 7");
      this._url = url;
      this._upn = upn;
      this._serializationSurrogate = new ProxySerializationSurrogate();
      this.Timeout = TimeSpan.FromSeconds(30.0);
      if (string.IsNullOrEmpty(username))
        return;
      string str = "";
      string[] strArray1 = username.Split('\\');
      if (strArray1.Length == 2)
      {
        str = strArray1[0];
        username = strArray1[1];
      }
      else if (strArray1.Length == 1)
      {
        string[] strArray2 = username.Split('@');
        if (strArray2.Length == 2)
        {
          str = strArray2[1];
          username = strArray2[0];
        }
      }
      this._domain = str;
      this._username = username;
      this._password = password;
    }

    public TimeSpan Timeout { get; set; }

    public string SdkClientVersion { get; set; }

    public Guid CallerId { get; set; }

    private void Authenticate()
    {
      if (this._tokenExpires > DateTime.UtcNow.AddSeconds(10.0))
        return;
      ClientContext clientContext = new ClientContext(!string.IsNullOrEmpty(this._username) ? (Credential) new PasswordCredential(this._domain, this._username, this._password, "Negotiate", NSspi.Credentials.CredentialUse.Outbound) : (Credential) new CurrentCredential("Negotiate", NSspi.Credentials.CredentialUse.Outbound), this._upn, ContextAttrib.ReplayDetect | ContextAttrib.SequenceDetect | ContextAttrib.Confidentiality | ContextAttrib.AcceptIntegrity);
      byte[] outToken;
      NSspi.SecurityStatus securityStatus = clientContext.Init((byte[]) null, out outToken);
      if (securityStatus != NSspi.SecurityStatus.ContinueNeeded)
        throw new ApplicationException("Error authenticating with the server: " + securityStatus.ToString());
      Authenticator auth = new Authenticator();
      object obj = new RequestSecurityToken(outToken).Execute(this._url, auth);
      RequestSecurityTokenResponseCollection responseCollection = obj as RequestSecurityTokenResponseCollection;
      while (responseCollection == null)
      {
        if (obj is RequestSecurityTokenResponse securityTokenResponse)
        {
          securityStatus = clientContext.Init(securityTokenResponse.BinaryExchange.Token, out outToken);
          switch (securityStatus)
          {
            case NSspi.SecurityStatus.OK:
            case NSspi.SecurityStatus.ContinueNeeded:
              obj = new RequestSecurityTokenResponse(securityTokenResponse.Context, outToken).Execute(this._url, auth);
              responseCollection = obj as RequestSecurityTokenResponseCollection;
              continue;
            default:
              throw new ApplicationException("Error authenticating with the server: " + securityStatus.ToString());
          }
        }
      }
      byte[] cipherValue = responseCollection.Responses[0].RequestedProofToken.CipherValue;
      this._tokenExpires = responseCollection.Responses[0].Lifetime.Expires;
      this._securityContextToken = responseCollection.Responses[0].RequestedSecurityToken;
      if (securityStatus != NSspi.SecurityStatus.OK)
        securityStatus = clientContext.Init(responseCollection.Responses[0].BinaryExchange.Token, out byte[] _);
      if (securityStatus != NSspi.SecurityStatus.OK)
        throw new ApplicationException("Error authenticating with the server: " + securityStatus.ToString());
      this._proofToken = clientContext.Decrypt(cipherValue, true);
      auth.Validate(this._proofToken, responseCollection.Responses[1].Authenticator.Token);
    }

    public void EnableProxyTypes(Assembly assembly) => this._serializationSurrogate.LoadAssembly(assembly);

    public void Associate(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      this.Execute((OrganizationRequest) new AssociateRequest()
      {
        Target = new EntityReference(entityName, entityId),
        Relationship = relationship,
        RelatedEntities = relatedEntities
      });
    }

    public Guid Create(Entity entity) => ((CreateResponse) this.Execute((OrganizationRequest) new CreateRequest()
    {
      Target = entity
    })).id;

    public void Delete(string entityName, Guid id) => this.Execute((OrganizationRequest) new DeleteRequest()
    {
      Target = new EntityReference(entityName, id)
    });

    public void Disassociate(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      this.Execute((OrganizationRequest) new DisassociateRequest()
      {
        Target = new EntityReference(entityName, entityId),
        Relationship = relationship,
        RelatedEntities = relatedEntities
      });
    }

    public OrganizationResponse Execute(OrganizationRequest request)
    {
      this.Authenticate();
      Message message1 = Message.CreateMessage(MessageVersion.Soap12WSAddressing10, "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Execute", (BodyWriter) new ADAuthClient.ExecuteRequestWriter(request, this._serializationSurrogate));
      message1.Headers.MessageId = new UniqueId(Guid.NewGuid());
      message1.Headers.ReplyTo = new EndpointAddress("http://www.w3.org/2005/08/addressing/anonymous");
      message1.Headers.To = new Uri(this._url);
      message1.Headers.Add(MessageHeader.CreateHeader("SdkClientVersion", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) this.SdkClientVersion));
      message1.Headers.Add(MessageHeader.CreateHeader("UserType", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) "CrmUser"));
      message1.Headers.Add((MessageHeader) new SecurityHeader(this._securityContextToken, this._proofToken));
      if (this.CallerId != Guid.Empty)
        message1.Headers.Add(MessageHeader.CreateHeader("CallerId", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) this.CallerId));
      HttpWebRequest http = WebRequest.CreateHttp(this._url);
      http.Method = "POST";
      http.ContentType = "application/soap+xml; charset=utf-8";
      http.Timeout = (int) this.Timeout.TotalMilliseconds;
      using (Stream requestStream = http.GetRequestStream())
      {
        Stream output = requestStream;
        using (XmlWriter writer = XmlWriter.Create(output, new XmlWriterSettings()
        {
          OmitXmlDeclaration = true,
          Indent = false,
          Encoding = (Encoding) new UTF8Encoding(false),
          CloseOutput = true
        }))
        {
          using (XmlDictionaryWriter dictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer))
          {
            message1.WriteMessage(dictionaryWriter);
            dictionaryWriter.WriteEndDocument();
            dictionaryWriter.Flush();
          }
        }
      }
      try
      {
        using (WebResponse response = http.GetResponse())
        {
          using (Stream responseStream = response.GetResponseStream())
          {
            Message message2 = Message.CreateMessage(XmlReader.Create(responseStream, new XmlReaderSettings()), 65536, MessageVersion.Soap12WSAddressing10);
            string action = message2.Headers.Action;
            using (XmlDictionaryReader readerAtBodyContents = message2.GetReaderAtBodyContents())
            {
              readerAtBodyContents.ReadStartElement("ExecuteResponse", "http://schemas.microsoft.com/xrm/2011/Contracts/Services");
              OrganizationResponse organizationResponse = (OrganizationResponse) new DataContractSerializer(typeof (OrganizationResponse), "ExecuteResult", "http://schemas.microsoft.com/xrm/2011/Contracts/Services", (IEnumerable<System.Type>) null, int.MaxValue, false, true, (IDataContractSurrogate) this._serializationSurrogate).ReadObject(readerAtBodyContents, true, (DataContractResolver) new KnownTypesResolver());
              readerAtBodyContents.ReadEndElement();
              return organizationResponse;
            }
          }
        }
      }
      catch (WebException ex) when (ex.Response != null)
      {
        using (Stream responseStream = ex.Response.GetResponseStream())
        {
          Message message3 = Message.CreateMessage(XmlReader.Create(responseStream, new XmlReaderSettings()), 65536, MessageVersion.Soap12WSAddressing10);
          string action = message3.Headers.Action;
          using (XmlDictionaryReader readerAtBodyContents = message3.GetReaderAtBodyContents())
          {
            if (readerAtBodyContents.LocalName == "Fault" && readerAtBodyContents.NamespaceURI == "http://www.w3.org/2003/05/soap-envelope")
              throw FaultReader.ReadFault(readerAtBodyContents, action);
            throw;
          }
        }
      }
    }

    public Entity Retrieve(string entityName, Guid id, ColumnSet columnSet) => ((RetrieveResponse) this.Execute((OrganizationRequest) new RetrieveRequest()
    {
      Target = new EntityReference(entityName, id),
      ColumnSet = columnSet
    })).Entity;

    public EntityCollection RetrieveMultiple(QueryBase query) => ((RetrieveMultipleResponse) this.Execute((OrganizationRequest) new RetrieveMultipleRequest()
    {
      Query = query
    })).EntityCollection;

    public void Update(Entity entity) => this.Execute((OrganizationRequest) new UpdateRequest()
    {
      Target = entity
    });

    public Task AssociateAsync(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities,
      CancellationToken cancellationToken)
    {
      return (Task) this.ExecuteAsync((OrganizationRequest) new AssociateRequest()
      {
        Target = new EntityReference(entityName, entityId),
        Relationship = relationship,
        RelatedEntities = relatedEntities
      }, cancellationToken);
    }

    public async Task<Guid> CreateAsync(Entity entity, CancellationToken cancellationToken) => ((CreateResponse) await this.ExecuteAsync((OrganizationRequest) new CreateRequest()
    {
      Target = entity
    }, cancellationToken).ConfigureAwait(false)).id;

    public Task<Entity> CreateAndReturnAsync(
      Entity entity,
      CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public Task DeleteAsync(string entityName, Guid id, CancellationToken cancellationToken) => (Task) this.ExecuteAsync((OrganizationRequest) new DeleteRequest()
    {
      Target = new EntityReference(entityName, id)
    }, cancellationToken);

    public Task DisassociateAsync(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities,
      CancellationToken cancellationToken)
    {
      return (Task) this.ExecuteAsync((OrganizationRequest) new DisassociateRequest()
      {
        Target = new EntityReference(entityName, entityId),
        Relationship = relationship,
        RelatedEntities = relatedEntities
      }, cancellationToken);
    }

    public async Task<OrganizationResponse> ExecuteAsync(
      OrganizationRequest request,
      CancellationToken cancellationToken)
    {
      this.Authenticate();
      cancellationToken.ThrowIfCancellationRequested();
      Message message = Message.CreateMessage(MessageVersion.Soap12WSAddressing10, "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Execute", (BodyWriter) new ADAuthClient.ExecuteRequestWriter(request, this._serializationSurrogate));
      message.Headers.MessageId = new UniqueId(Guid.NewGuid());
      message.Headers.ReplyTo = new EndpointAddress("http://www.w3.org/2005/08/addressing/anonymous");
      message.Headers.To = new Uri(this._url);
      message.Headers.Add(MessageHeader.CreateHeader("SdkClientVersion", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) this.SdkClientVersion));
      message.Headers.Add(MessageHeader.CreateHeader("UserType", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) "CrmUser"));
      message.Headers.Add((MessageHeader) new SecurityHeader(this._securityContextToken, this._proofToken));
      if (this.CallerId != Guid.Empty)
        message.Headers.Add(MessageHeader.CreateHeader("CallerId", "http://schemas.microsoft.com/xrm/2011/Contracts", (object) this.CallerId));
      HttpWebRequest req = WebRequest.CreateHttp(this._url);
      req.Method = "POST";
      req.ContentType = "application/soap+xml; charset=utf-8";
      req.Timeout = (int) this.Timeout.TotalMilliseconds;
      using (Stream stream = await req.GetRequestStreamAsync().ConfigureAwait(false))
      {
        Stream output = stream;
        using (XmlWriter writer = XmlWriter.Create(output, new XmlWriterSettings()
        {
          OmitXmlDeclaration = true,
          Indent = false,
          Encoding = (Encoding) new UTF8Encoding(false),
          CloseOutput = true
        }))
        {
          using (XmlDictionaryWriter dictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(writer))
          {
            message.WriteMessage(dictionaryWriter);
            dictionaryWriter.WriteEndDocument();
            dictionaryWriter.Flush();
          }
        }
      }
      cancellationToken.ThrowIfCancellationRequested();
      OrganizationResponse organizationResponse1;
      try
      {
        using (WebResponse webResponse = await req.GetResponseAsync().ConfigureAwait(false))
        {
          using (Stream responseStream = webResponse.GetResponseStream())
          {
            Message message1 = Message.CreateMessage(XmlReader.Create(responseStream, new XmlReaderSettings()), 65536, MessageVersion.Soap12WSAddressing10);
            string action = message1.Headers.Action;
            using (XmlDictionaryReader readerAtBodyContents = message1.GetReaderAtBodyContents())
            {
              readerAtBodyContents.ReadStartElement("ExecuteResponse", "http://schemas.microsoft.com/xrm/2011/Contracts/Services");
              OrganizationResponse organizationResponse2 = (OrganizationResponse) new DataContractSerializer(typeof (OrganizationResponse), "ExecuteResult", "http://schemas.microsoft.com/xrm/2011/Contracts/Services", (IEnumerable<System.Type>) null, int.MaxValue, false, true, (IDataContractSurrogate) this._serializationSurrogate).ReadObject(readerAtBodyContents, true, (DataContractResolver) new KnownTypesResolver());
              readerAtBodyContents.ReadEndElement();
              organizationResponse1 = organizationResponse2;
            }
          }
        }
      }
      catch (WebException ex) when (ex.Response != null)
      {
        using (Stream responseStream = ex.Response.GetResponseStream())
        {
          Message message2 = Message.CreateMessage(XmlReader.Create(responseStream, new XmlReaderSettings()), 65536, MessageVersion.Soap12WSAddressing10);
          string action = message2.Headers.Action;
          using (XmlDictionaryReader readerAtBodyContents = message2.GetReaderAtBodyContents())
          {
            if (readerAtBodyContents.LocalName == "Fault" && readerAtBodyContents.NamespaceURI == "http://www.w3.org/2003/05/soap-envelope")
              throw FaultReader.ReadFault(readerAtBodyContents, action);
            throw;
          }
        }
      }
      message = (Message) null;
      req = (HttpWebRequest) null;
      return organizationResponse1;
    }

    public async Task<Entity> RetrieveAsync(
      string entityName,
      Guid id,
      ColumnSet columnSet,
      CancellationToken cancellationToken)
    {
      return ((RetrieveResponse) await this.ExecuteAsync((OrganizationRequest) new RetrieveRequest()
      {
        Target = new EntityReference(entityName, id),
        ColumnSet = columnSet
      }, cancellationToken).ConfigureAwait(false)).Entity;
    }

    public async Task<EntityCollection> RetrieveMultipleAsync(
      QueryBase query,
      CancellationToken cancellationToken)
    {
      return ((RetrieveMultipleResponse) await this.ExecuteAsync((OrganizationRequest) new RetrieveMultipleRequest()
      {
        Query = query
      }, cancellationToken).ConfigureAwait(false)).EntityCollection;
    }

    public Task UpdateAsync(Entity entity, CancellationToken cancellationToken) => (Task) this.ExecuteAsync((OrganizationRequest) new UpdateRequest()
    {
      Target = entity
    }, cancellationToken);

    public Task<Guid> CreateAsync(Entity entity) => this.CreateAsync(entity, CancellationToken.None);

    public Task<Entity> RetrieveAsync(string entityName, Guid id, ColumnSet columnSet) => this.RetrieveAsync(entityName, id, columnSet, CancellationToken.None);

    public Task UpdateAsync(Entity entity) => this.UpdateAsync(entity, CancellationToken.None);

    public Task DeleteAsync(string entityName, Guid id) => this.DeleteAsync(entityName, id, CancellationToken.None);

    public Task<OrganizationResponse> ExecuteAsync(
      OrganizationRequest request)
    {
      return this.ExecuteAsync(request, CancellationToken.None);
    }

    public Task AssociateAsync(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      return this.AssociateAsync(entityName, entityId, relationship, relatedEntities, CancellationToken.None);
    }

    public Task DisassociateAsync(
      string entityName,
      Guid entityId,
      Relationship relationship,
      EntityReferenceCollection relatedEntities)
    {
      return this.DisassociateAsync(entityName, entityId, relationship, relatedEntities, CancellationToken.None);
    }

    public Task<EntityCollection> RetrieveMultipleAsync(QueryBase query) => this.RetrieveMultipleAsync(query, CancellationToken.None);

    private class ExecuteRequestWriter : BodyWriter
    {
      private readonly OrganizationRequest _request;
      private readonly ProxySerializationSurrogate _serializationSurrogate;

      public ExecuteRequestWriter(
        OrganizationRequest request,
        ProxySerializationSurrogate serializationSurrogate)
        : base(true)
      {
        this._request = request;
        this._serializationSurrogate = serializationSurrogate;
      }

      protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
      {
        writer.WriteStartElement("Execute", "http://schemas.microsoft.com/xrm/2011/Contracts/Services");
        new DataContractSerializer(typeof (OrganizationRequest), "request", "http://schemas.microsoft.com/xrm/2011/Contracts/Services", (IEnumerable<System.Type>) null, int.MaxValue, false, true, (IDataContractSurrogate) this._serializationSurrogate).WriteObject(writer, (object) this._request, (DataContractResolver) new KnownTypesResolver());
        writer.WriteEndElement();
      }
    }
  }
}
