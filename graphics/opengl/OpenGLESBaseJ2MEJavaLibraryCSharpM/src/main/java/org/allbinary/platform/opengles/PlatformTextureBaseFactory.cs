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
//using GL10 = javax.microedition.khronos.opengles.GL10;
//using Image = javax.microedition.lcdui.Image;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.platform.opengles;

public class PlatformTextureBaseFactory
{
    public static readonly PlatformTextureBaseFactory NULL_PLATFORM_TEXTURE_BASE_FACTORY = new PlatformTextureBaseFactory();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public virtual void load(GL10 gl, int target, int level, Image image, int border, bool flip)
    {
    }

}

