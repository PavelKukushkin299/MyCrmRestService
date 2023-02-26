// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Linq.LinkEntityExtensions
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Query;
using System;
using System.Linq;

namespace Microsoft.Xrm.Sdk.Linq
{
  public static class LinkEntityExtensions
  {
    public static LinkEntity Find(this LinkEntity link, Predicate<LinkEntity> match) => !match(link) ? link.LinkEntities.Select<LinkEntity, LinkEntity>((Func<LinkEntity, LinkEntity>) (child => child.Find(match))).FirstOrDefault<LinkEntity>((Func<LinkEntity, bool>) (result => result != null)) : link;
  }
}
