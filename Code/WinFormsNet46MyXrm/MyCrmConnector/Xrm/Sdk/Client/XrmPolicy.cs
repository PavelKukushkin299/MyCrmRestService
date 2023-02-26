// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Client.XrmPolicy
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.ServiceModel.Channels;

namespace MyCrmConnector.Client
{
  internal abstract class XrmPolicy : BindingElement
  {
    private readonly PolicyDictionary _policyElements = new PolicyDictionary();

    internal PolicyDictionary PolicyElements => this._policyElements;

    public override BindingElement Clone() => (BindingElement) this;

    public override T GetProperty<T>(BindingContext context) => context.GetInnerProperty<T>();
  }
}
