// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.XrmBinding
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.ServiceModel.Channels;
using System.Xml;

namespace MyCrmConnector.Client
{
  public sealed class XrmBinding : CustomBinding
  {
    private TransportBindingElement _transportElement;
    private MtomMessageEncodingBindingElement _mtomMessageEncodingElement;
    private TextMessageEncodingBindingElement _textMessageEncodingElement;

    internal XrmBinding(Binding binding)
      : base(binding)
    {
      if (binding == null)
        throw new ArgumentNullException(nameof (binding));
      this.Initialize();
    }

    public int MaxBufferSize
    {
      get => this._transportElement is HttpTransportBindingElement transportElement ? transportElement.MaxBufferSize : -1;
      set
      {
        if (this._transportElement is HttpTransportBindingElement transportElement)
          transportElement.MaxBufferSize = value;
        if (this._mtomMessageEncodingElement == null)
          return;
        this._mtomMessageEncodingElement.MaxBufferSize = value;
      }
    }

    public long MaxReceivedMessageSize
    {
      get => this._transportElement != null ? this._transportElement.MaxReceivedMessageSize : -1L;
      set
      {
        if (this._transportElement == null)
          return;
        this._transportElement.MaxReceivedMessageSize = value;
      }
    }

    public XmlDictionaryReaderQuotas ReaderQuotas
    {
      get
      {
        if (this._textMessageEncodingElement != null)
          return this._textMessageEncodingElement.ReaderQuotas;
        return this._mtomMessageEncodingElement != null ? this._mtomMessageEncodingElement.ReaderQuotas : (XmlDictionaryReaderQuotas) null;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException(nameof (value));
        if (this._mtomMessageEncodingElement != null)
          value.CopyTo(this._mtomMessageEncodingElement.ReaderQuotas);
        if (this._textMessageEncodingElement == null)
          return;
        value.CopyTo(this._textMessageEncodingElement.ReaderQuotas);
      }
    }

    public override string Scheme => this._transportElement == null ? string.Empty : this._transportElement.Scheme;

    private void Initialize()
    {
      this._transportElement = this.Elements.Find<TransportBindingElement>();
      this._mtomMessageEncodingElement = this.Elements.Find<MtomMessageEncodingBindingElement>();
      this._textMessageEncodingElement = this.Elements.Find<TextMessageEncodingBindingElement>();
    }
  }
}
