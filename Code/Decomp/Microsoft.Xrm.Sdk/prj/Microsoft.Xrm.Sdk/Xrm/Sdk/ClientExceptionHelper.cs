// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.ClientExceptionHelper
// Assembly: Microsoft.Xrm.Sdk, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 6ED27353-7D93-4D8D-9CA3-2396F24E6015
// Assembly location: C:\Stas\Projects\Tricolor\To365\MyCrmRestService\Code\Decomp\Microsoft.Xrm.Sdk\Microsoft.Xrm.Sdk.dll

using System;
using System.Globalization;
using System.Text;

namespace Microsoft.Xrm.Sdk
{
  internal static class ClientExceptionHelper
  {
    internal static void ThrowIfNegative(int value, string parameterName)
    {
      if (value < 0)
        throw new ArgumentOutOfRangeException(parameterName, (object) value, "Value for this parameter must be equal or greater than zero.");
    }

    internal static void ThrowIfNull(object parameter, string name)
    {
      if (parameter == null)
        throw new ArgumentNullException(name);
    }

    internal static void ThrowIfNullOrEmpty(string parameter, string name)
    {
      if (string.IsNullOrEmpty(parameter))
        throw new ArgumentNullException(name);
    }

    internal static void ThrowIfGuidEmpty(Guid parameter, string name)
    {
      if (parameter == Guid.Empty)
        throw new ArgumentException("Expected non-empty Guid.", name);
    }

    internal static string FormatMessage(int errorCode, params object[] arguments)
    {
      if (errorCode == 0)
        return ClientExceptionHelper.BuildErrorTable(string.Empty, arguments);
      string str = errorCode.ToString((IFormatProvider) CultureInfo.InvariantCulture);
      try
      {
        return string.Format((IFormatProvider) CultureInfo.InvariantCulture, str, arguments);
      }
      catch (FormatException ex)
      {
        return ClientExceptionHelper.BuildErrorTable(str, arguments);
      }
    }

    private static string BuildErrorTable(string message, object[] arguments)
    {
      StringBuilder stringBuilder = new StringBuilder(message);
      for (int index = 0; index < arguments.Length; ++index)
        stringBuilder.Append(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "\nData[{0}] = \"{1}\"", (object) index, arguments[index]));
      return stringBuilder.ToString();
    }

    internal static void Assert(bool condition, string message, params object[] args) => ClientExceptionHelper.Assert(condition, string.Format((IFormatProvider) CultureInfo.InvariantCulture, message, args));

    internal static void Assert(bool condition, string message)
    {
      InvalidOperationException operationException = (InvalidOperationException) null;
      if (!condition)
        operationException = new InvalidOperationException(message);
      if (operationException != null)
        throw operationException;
    }

    internal static string GetString(string value, params object[] args)
    {
      string format = value;
      if (string.IsNullOrEmpty(value))
        return value;
      if (args != null && args.Length != 0)
        format = string.Format((IFormatProvider) CultureInfo.CurrentCulture, format, args);
      return format;
    }
  }
}
