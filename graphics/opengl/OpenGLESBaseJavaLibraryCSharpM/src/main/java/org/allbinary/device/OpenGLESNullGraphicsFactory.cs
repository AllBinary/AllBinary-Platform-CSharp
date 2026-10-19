// Generated Code Do Not Modify

using System;
using System.Linq;

namespace org.allbinary.device;

public class OpenGLESNullGraphicsFactory
{
    private static readonly OpenGLESGraphics instance = new OpenGLESGraphics();
    public static OpenGLESGraphics getInstance()
    {
        return OpenGLESNullGraphicsFactory.instance;
    }

}

