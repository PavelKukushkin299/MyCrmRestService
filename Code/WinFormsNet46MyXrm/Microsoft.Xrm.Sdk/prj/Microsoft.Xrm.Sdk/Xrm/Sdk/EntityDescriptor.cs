// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.EntityDescriptor
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

namespace Microsoft.Xrm.Sdk
{
  internal sealed class EntityDescriptor : Descriptor
  {
    public EntityReference Identity { get; private set; }

    public Entity Entity { get; private set; }

    public EntityDescriptor(EntityStates state, EntityReference identity, Entity entity)
      : base(state)
    {
      this.Identity = identity;
      this.Entity = entity;
    }
  }
}
