// Decompiled with JetBrains decompiler
// Type: NSspi.Credentials.Credential
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NSspi.Credentials
{
  public class Credential : IDisposable
  {
    private readonly string securityPackage;
    private bool disposed;
    private SafeCredentialHandle safeCredHandle;
    private DateTime expiry;

    public Credential(string package)
    {
      this.securityPackage = package;
      this.disposed = false;
      this.expiry = DateTime.MinValue;
      this.PackageInfo = PackageSupport.GetPackageCapabilities(this.SecurityPackage);
    }

    public SecPkgInfo PackageInfo { get; private set; }

    public string SecurityPackage
    {
      get
      {
        this.CheckLifecycle();
        return this.securityPackage;
      }
    }

    public string PrincipleName
    {
      get
      {
        string principleName = (string) null;
        bool success = false;
        this.CheckLifecycle();
        SecurityStatus securityStatus = SecurityStatus.InternalError;
        QueryNameAttribCarrier name = new QueryNameAttribCarrier();
        RuntimeHelpers.PrepareConstrainedRegions();
        try
        {
          this.safeCredHandle.DangerousAddRef(ref success);
        }
        catch (Exception ex)
        {
          if (success)
          {
            this.safeCredHandle.DangerousRelease();
            success = false;
          }
          throw;
        }
        finally
        {
          if (success)
          {
            securityStatus = CredentialNativeMethods.QueryCredentialsAttribute_Name(ref this.safeCredHandle.rawHandle, CredentialQueryAttrib.Names, ref name);
            this.safeCredHandle.DangerousRelease();
            if (securityStatus == SecurityStatus.OK)
            {
              if (name.Name != IntPtr.Zero)
              {
                try
                {
                  principleName = Marshal.PtrToStringUni(name.Name);
                }
                finally
                {
                  int num = (int) NSspi.NativeMethods.FreeContextBuffer(name.Name);
                }
              }
            }
          }
        }
        if (securityStatus.IsError())
          throw new SSPIException("Failed to query credential name", securityStatus);
        return principleName;
      }
    }

    public DateTime Expiry
    {
      get
      {
        this.CheckLifecycle();
        return this.expiry;
      }
      protected set
      {
        this.CheckLifecycle();
        this.expiry = value;
      }
    }

    public SafeCredentialHandle Handle
    {
      get
      {
        this.CheckLifecycle();
        return this.safeCredHandle;
      }
      protected set
      {
        this.CheckLifecycle();
        this.safeCredHandle = value;
      }
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this.disposed)
        return;
      if (disposing)
        this.safeCredHandle.Dispose();
      this.disposed = true;
    }

    private void CheckLifecycle()
    {
      if (this.disposed)
        throw new ObjectDisposedException(nameof (Credential));
    }
  }
}
