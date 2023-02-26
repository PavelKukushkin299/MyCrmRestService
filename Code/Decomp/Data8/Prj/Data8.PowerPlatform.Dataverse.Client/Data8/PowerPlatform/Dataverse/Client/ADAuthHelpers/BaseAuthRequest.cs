// Decompiled with JetBrains decompiler
// Type: Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers.BaseAuthRequest
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Xml;

namespace Data8.PowerPlatform.Dataverse.Client.ADAuthHelpers
{
  internal abstract class BaseAuthRequest : BodyWriter
  {
    protected BaseAuthRequest()
      : base(true)
    {
    }

    protected abstract string Action { get; }

    public object Execute(string url, Authenticator auth)
    {
      XmlDocument xmlDoc = new XmlDocument();
      using (XmlWriter writer = xmlDoc.CreateNavigator().AppendChild())
        this.WriteBodyContents(XmlDictionaryWriter.CreateDictionaryWriter(writer));
      auth.AddToDigest(xmlDoc);
      Message message1 = Message.CreateMessage(MessageVersion.Soap12WSAddressing10, this.Action, (BodyWriter) this);
      message1.Headers.MessageId = new UniqueId(Guid.NewGuid());
      message1.Headers.ReplyTo = new EndpointAddress("http://www.w3.org/2005/08/addressing/anonymous");
      message1.Headers.To = new Uri(url);
      HttpWebRequest http = WebRequest.CreateHttp(url);
      http.Method = "POST";
      http.ContentType = "application/soap+xml; charset=utf-8";
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
              if (readerAtBodyContents.LocalName == "RequestSecurityTokenResponse")
                return (object) RequestSecurityTokenResponse.Read(readerAtBodyContents, auth, false);
              return readerAtBodyContents.LocalName == "RequestSecurityTokenResponseCollection" ? (object) RequestSecurityTokenResponseCollection.Read(readerAtBodyContents, auth) : throw new NotSupportedException("Unexpected response element " + readerAtBodyContents.LocalName);
            }
          }
        }
      }
      catch (WebException ex)
      {
        using (Stream responseStream = ex.Response.GetResponseStream())
        {
          Message message3 = Message.CreateMessage(XmlReader.Create(responseStream, new XmlReaderSettings()), 65536, MessageVersion.Soap12WSAddressing10);
          string action = message3.Headers.Action;
          using (XmlDictionaryReader readerAtBodyContents = message3.GetReaderAtBodyContents())
            throw FaultReader.ReadFault(readerAtBodyContents, action);
        }
      }
    }
  }
}
