// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.LinkDescriptor
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System.Collections.Generic;

namespace Microsoft.Xrm.Sdk
{
  internal sealed class LinkDescriptor : Descriptor
  {
    internal static readonly IEqualityComparer<LinkDescriptor> EquivalenceComparer = (IEqualityComparer<LinkDescriptor>) new LinkDescriptor.LinkDescriptorComparer();

    public Entity Source { get; private set; }

    public Relationship Relationship { get; private set; }

    public Entity Target { get; private set; }

    public LinkDescriptor(Entity source, Relationship relationship, Entity target)
      : this(EntityStates.Unchanged, source, relationship, target)
    {
    }

    public LinkDescriptor(
      EntityStates state,
      Entity source,
      Relationship relationship,
      Entity target)
      : base(state)
    {
      this.Source = source;
      this.Relationship = relationship;
      this.Target = target;
    }

    private class LinkDescriptorComparer : IEqualityComparer<LinkDescriptor>
    {
      public bool Equals(LinkDescriptor x, LinkDescriptor y)
      {
        if (x == null && y == null)
          return true;
        return x != null && y != null && object.Equals((object) x.Source, (object) y.Source) && object.Equals((object) x.Relationship, (object) y.Relationship) && object.Equals((object) x.Target, (object) y.Target);
      }

      public int GetHashCode(LinkDescriptor obj) => obj == null ? 0 : obj.Source.GetHashCode() ^ (obj.Target != null ? obj.Target.GetHashCode() : 0) ^ (obj.Relationship != null ? obj.Relationship.GetHashCode() : 0);
    }
  }
}
