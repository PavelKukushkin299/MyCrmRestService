// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Discovery.ClientPatchInfo
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;

namespace Microsoft.Xrm.Sdk.Discovery
{
  public sealed class ClientPatchInfo
  {
    private Guid _patchId;
    private string _title;
    private string _description;
    private bool _isMandatory;
    private int _depth;
    private string _linkId;

    public Guid PatchId
    {
      get => this._patchId;
      set => this._patchId = value;
    }

    public string Title
    {
      get => this._title;
      set => this._title = value;
    }

    public string Description
    {
      get => this._description;
      set => this._description = value;
    }

    public bool IsMandatory
    {
      get => this._isMandatory;
      set => this._isMandatory = value;
    }

    public int Depth
    {
      get => this._depth;
      set => this._depth = value;
    }

    public string LinkId
    {
      get => this._linkId;
      set => this._linkId = value;
    }
  }
}
