// Generated Code Do Not Modify

using System;
using System.Linq;
//using InputStream = java.io.InputStream;

namespace org.platform;

public class OpenGLResources
{
    private static readonly OpenGLResources instance = new OpenGLResources();
    public static OpenGLResources getInstance()
    {
        return OpenGLResources.instance;
    }

    public virtual void init()
    {
    }

    public virtual bool isExcluded(string name)
    {
        throw new SystemException();
    }

    public virtual int getIdentifier(string name, string defType, string defPackage)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual InputStream openRawResource(int id)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual InputStream openRawResourceFromName(string resourceName)
    {
        throw new SystemException();
    }

    // throws Exception
    public virtual InputStream getResourceAsStream(string resourceName)
    {
        throw new SystemException();
    }

    public virtual string getPackageName()
    {
        throw new SystemException();
    }

}

