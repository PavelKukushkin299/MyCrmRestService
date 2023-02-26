// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.SaveChangesResultCollection
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Microsoft.Xrm.Sdk
{
  public sealed class SaveChangesResultCollection : Collection<SaveChangesResult>
  {
    public SaveChangesOptions Options { get; private set; }

    public bool HasError => this.Any<SaveChangesResult>((Func<SaveChangesResult, bool>) (result => result.Error != null));

    internal SaveChangesResultCollection(SaveChangesOptions options) => this.Options = options;
  }
}
