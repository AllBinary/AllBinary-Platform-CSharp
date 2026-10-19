/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
 *  
 * By agreeing to this license you and any business entity you represent are 
 * legally bound to the AllBinary Open License Version 1 legal agreement. 
 *  
 * You may obtain the AllBinary Open License Version 1 legal agreement from 
 * AllBinary or the root directory of AllBinary's AllBinary Platform repository. 
 *  
 * Created By: Travis Berthelot 
 *   
 */
// Generated Code Do Not Modify

using System;
using System.Linq;

namespace org.allbinary.device;

public class OpenGLESGraphicsCompositeFactory
{
    private static readonly OpenGLESGraphicsCompositeFactory instance = new OpenGLESGraphicsCompositeFactory();
    public static OpenGLESGraphicsCompositeFactory getInstance()
    {
        return OpenGLESGraphicsCompositeFactory.instance;
    }

    private OpenGLESGraphicsFactory openGLESGraphicsFactory = new OpenGLESGraphicsFactory();
    public virtual void set(OpenGLESGraphicsFactory openGLESGraphicsFactory)
    {
        this.openGLESGraphicsFactory = openGLESGraphicsFactory;
    }

    public virtual OpenGLESGraphicsFactory get()
    {
        return this.openGLESGraphicsFactory;
    }

}

