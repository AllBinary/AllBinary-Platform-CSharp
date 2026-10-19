// Generated Code Do Not Modify

using System;
using System.Linq;
//using Provider = java.security.Provider;

namespace org.bouncycastle.jce.provider;

public class BouncyCastleProvider : Provider
{
    private static string info = "BouncyCastle Security Provider v1.41";
    public static string PROVIDER_NAME = "BC";
    public BouncyCastleProvider() : base(BouncyCastleProvider.PROVIDER_NAME, 1.41, BouncyCastleProvider.info)
    {
        // base(BouncyCastleProvider.PROVIDER_NAME, 1.41, BouncyCastleProvider.info) is called from the constructor declaration
    }

    public virtual void setParameter(string parameterName, object parameter)
    {
    }

}

