// Decompiled with JetBrains decompiler
// Type: NSspi.Buffers.SecureBufferAdapter
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace NSspi.Buffers
{
  internal sealed class SecureBufferAdapter : CriticalFinalizerObject, IDisposable
  {
    private bool disposed;
    private IList<SecureBuffer> buffers;
    private GCHandle descriptorHandle;
    private GCHandle bufferCarrierHandle;
    private GCHandle[] bufferHandles;
    private SecureBufferDescInternal descriptor;
    private SecureBufferInternal[] bufferCarrier;

    public SecureBufferAdapter(SecureBuffer buffer)
      : this((IList<SecureBuffer>) new SecureBuffer[1]
      {
        buffer
      })
    {
    }

    public SecureBufferAdapter(IList<SecureBuffer> buffers)
    {
      this.buffers = buffers;
      this.disposed = false;
      this.bufferHandles = new GCHandle[this.buffers.Count];
      this.bufferCarrier = new SecureBufferInternal[this.buffers.Count];
      for (int index = 0; index < this.buffers.Count; ++index)
      {
        this.bufferHandles[index] = GCHandle.Alloc((object) this.buffers[index].Buffer, GCHandleType.Pinned);
        this.bufferCarrier[index] = new SecureBufferInternal();
        this.bufferCarrier[index].Type = this.buffers[index].Type;
        ref SecureBufferInternal local = ref this.bufferCarrier[index];
        byte[] buffer = this.buffers[index].Buffer;
        int num = buffer != null ? buffer.Length : 0;
        local.Count = num;
        this.bufferCarrier[index].Buffer = this.bufferHandles[index].AddrOfPinnedObject();
      }
      this.bufferCarrierHandle = GCHandle.Alloc((object) this.bufferCarrier, GCHandleType.Pinned);
      this.descriptor = new SecureBufferDescInternal();
      this.descriptor.Version = 0;
      this.descriptor.NumBuffers = this.buffers.Count;
      this.descriptor.Buffers = this.bufferCarrierHandle.AddrOfPinnedObject();
      this.descriptorHandle = GCHandle.Alloc((object) this.descriptor, GCHandleType.Pinned);
    }

    public byte[] ExtractData(int index)
    {
      byte[] destination = new byte[this.bufferCarrier[index].Count];
      Marshal.Copy(this.bufferCarrier[index].Buffer, destination, 0, this.bufferCarrier[index].Count);
      return destination;
    }

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    ~SecureBufferAdapter() => this.Dispose(false);

    public IntPtr Handle
    {
      get
      {
        if (this.disposed)
          throw new ObjectDisposedException("Cannot use SecureBufferListHandle after it has been disposed");
        return this.descriptorHandle.AddrOfPinnedObject();
      }
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
    private void Dispose(bool disposing)
    {
      if (this.disposed)
        return;
      if (disposing)
      {
        for (int index = 0; index < this.buffers.Count; ++index)
          this.buffers[index].Length = this.bufferCarrier[index].Count;
      }
      for (int index = 0; index < this.bufferHandles.Length; ++index)
      {
        if (this.bufferHandles[index].IsAllocated)
          this.bufferHandles[index].Free();
      }
      if (this.bufferCarrierHandle.IsAllocated)
        this.bufferCarrierHandle.Free();
      if (this.descriptorHandle.IsAllocated)
        this.descriptorHandle.Free();
      this.disposed = true;
    }
  }
}
