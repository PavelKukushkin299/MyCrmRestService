// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Extensions.LinkEntityExtensions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Xrm.Sdk.Extensions
{
  public static class LinkEntityExtensions
  {
    public static IEnumerable<LinkEntity> GetChildLinkEntities(
      this LinkEntity link)
    {
      yield return link;
      foreach (LinkEntity linkEntity in link.LinkEntities.SelectMany<LinkEntity, LinkEntity>(new Func<LinkEntity, IEnumerable<LinkEntity>>(LinkEntityExtensions.GetChildLinkEntities)))
        yield return linkEntity;
    }
  }
}
