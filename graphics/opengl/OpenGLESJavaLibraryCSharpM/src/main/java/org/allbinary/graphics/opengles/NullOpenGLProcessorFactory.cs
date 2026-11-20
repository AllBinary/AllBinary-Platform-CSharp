// Generated Code Do Not Modify

extern alias ImageCacheOpenGLESJavaLibraryCSharp;
extern alias OpenGLNoneOtherJavaLibraryCSharp;
using System;
using System.Linq;

namespace org.allbinary.graphics.opengles;

public class NullOpenGLProcessorFactory
{
    private static readonly OpenGLProcessor instance = new OpenGLProcessor();
    public static OpenGLProcessor getInstance()
    {
        return NullOpenGLProcessorFactory.instance;
    }

}

