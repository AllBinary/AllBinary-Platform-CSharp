/*
 *
 * AllBinary Open License Version 1
 * Copyright (c) 2011 AllBinary
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
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.image.opengles;

public class OpenGLImageSpecificFactory
{
    private static readonly OpenGLImageSpecificFactory instance = new OpenGLImageSpecificFactory();
    private OpenGLImageFactory imageFactory = OpenGLImageFactory.NULL_OPENGL_IMAGE_FACTORY;
    public bool updating = false;
    public static OpenGLImageSpecificFactory getInstance()
    {
        return OpenGLImageSpecificFactory.instance;
    }

    public virtual void setImageFactory(OpenGLImageFactory imageFactory)
    {
        this.imageFactory = imageFactory;
        PreLogUtil.put(new StringMaker().append("Selected Image Factory: ").append(StringUtil.getInstance().toString(this.imageFactory)).ToString(), this, "setImageFactory");
    }

    public virtual OpenGLImageFactory getImageFactory()
    {
        return this.imageFactory;
    }

}

