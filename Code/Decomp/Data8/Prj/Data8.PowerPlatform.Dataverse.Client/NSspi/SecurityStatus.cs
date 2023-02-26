// Decompiled with JetBrains decompiler
// Type: NSspi.SecurityStatus
// Assembly: Data8.PowerPlatform.Dataverse.Client, Version=2.3.1.0, Culture=neutral, PublicKeyToken=null
// MVID: 46051771-6992-40AA-B70B-8E77B40B48CB
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Data8\Data8.PowerPlatform.Dataverse.Client.dll

namespace NSspi
{
  public enum SecurityStatus : uint
  {
    [EnumString("No error")] OK = 0,
    [EnumString("Authentication cycle needs to continue")] ContinueNeeded = 590610, // 0x00090312
    [EnumString("Authentication cycle needs to perform a 'complete'.")] CompleteNeeded = 590611, // 0x00090313
    [EnumString("Authentication cycle needs to perform a 'complete' and then continue.")] CompAndContinue = 590612, // 0x00090314
    [EnumString("The security context was used after its expiration time passed.")] ContextExpired = 590615, // 0x00090317
    [EnumString("The credentials supplied to the security context were not fully initialized.")] CredentialsNeeded = 590624, // 0x00090320
    [EnumString("The context data must be re-negotiated with the peer.")] Renegotiate = 590625, // 0x00090321
    [EnumString("Not enough memory.")] OutOfMemory = 2148074240, // 0x80090300
    [EnumString("The handle provided to the API was invalid.")] InvalidHandle = 2148074241, // 0x80090301
    [EnumString("The attempted operation is not supported.")] Unsupported = 2148074242, // 0x80090302
    [EnumString("The specified principle is not known in the authentication system.")] TargetUnknown = 2148074243, // 0x80090303
    [EnumString("An internal error occurred.")] InternalError = 2148074244, // 0x80090304
    [EnumString("The requested security package was not found.")] PackageNotFound = 2148074245, // 0x80090305
    [EnumString("The caller is not the owner of the desired credentials.")] NotOwner = 2148074246, // 0x80090306
    [EnumString("The requested security package failed to initalize, and thus cannot be used.")] CannotInstall = 2148074247, // 0x80090307
    [EnumString("The provided authentication token is invalid or corrupted.")] InvalidToken = 2148074248, // 0x80090308
    [EnumString("The security package is not able to marshall the logon buffer, so the logon attempt has failed.")] CannotPack = 2148074249, // 0x80090309
    [EnumString("The per-message Quality of Protection is not supported by the security package.")] QopNotSupported = 2148074250, // 0x8009030A
    [EnumString("Impersonation is not supported with the current security package.")] NoImpersonation = 2148074251, // 0x8009030B
    [EnumString("The logon was denied, perhaps because the provided credentials were incorrect.")] LogonDenied = 2148074252, // 0x8009030C
    [EnumString("The credentials provided are not recognized by the selected security package.")] UnknownCredentials = 2148074253, // 0x8009030D
    [EnumString("No credentials are available in the selected security package.")] NoCredentials = 2148074254, // 0x8009030E
    [EnumString("A message that was provided to the Decrypt or VerifySignature functions was altered after it was created.")] MessageAltered = 2148074255, // 0x8009030F
    [EnumString("A message was received out of the expected order.")] OutOfSequence = 2148074256, // 0x80090310
    [EnumString("The current security package cannot contact an authenticating authority.")] NoAuthenticatingAuthority = 2148074257, // 0x80090311
    [EnumString("The buffer provided to an SSPI API call contained a message that was not complete.")] IncompleteMessage = 2148074264, // 0x80090318
    [EnumString("The credentials supplied were not complete, and could not be verified. The context could not be initialized.")] IncompleteCredentials = 2148074272, // 0x80090320
    [EnumString("The buffers supplied to a security function were too small.")] BufferNotEnough = 2148074273, // 0x80090321
    [EnumString("The target principal name is incorrect.")] WrongPrincipal = 2148074274, // 0x80090322
    [EnumString("The clocks on the client and server machines are skewed.")] TimeSkew = 2148074276, // 0x80090324
    [EnumString("The certificate chain was issued by an authority that is not trusted.")] UntrustedRoot = 2148074277, // 0x80090325
    [EnumString("The message received was unexpected or badly formatted.")] IllegalMessage = 2148074278, // 0x80090326
    [EnumString("An unknown error occurred while processing the certificate.")] CertUnknown = 2148074279, // 0x80090327
    [EnumString("The received certificate has expired.")] CertExpired = 2148074280, // 0x80090328
    [EnumString("The client and server cannot communicate, because they do not possess a common algorithm.")] AlgorithmMismatch = 2148074289, // 0x80090331
    [EnumString("The security context could not be established due to a failure in the requested quality of service (e.g. mutual authentication or delegation).")] SecurityQosFailed = 2148074290, // 0x80090332
    [EnumString("Smartcard logon is required and was not used.")] SmartcardLogonRequired = 2148074302, // 0x8009033E
    [EnumString("An unsupported preauthentication mechanism was presented to the Kerberos package.")] UnsupportedPreauth = 2148074307, // 0x80090343
    [EnumString("Client's supplied SSPI channel bindings were incorrect.")] BadBinding = 2148074310, // 0x80090346
  }
}
