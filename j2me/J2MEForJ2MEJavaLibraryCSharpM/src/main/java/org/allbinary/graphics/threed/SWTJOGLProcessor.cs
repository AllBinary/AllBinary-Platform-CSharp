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
//using Font = javax.microedition.lcdui.Font;
//using MIDlet = javax.microedition.midlet.MIDlet;

namespace org.allbinary.graphics.threed;

//OpenGLNone
public class SWTJOGLProcessor : Runnable
{
    private static readonly SWTJOGLProcessor instance = new SWTJOGLProcessor();
    public static SWTJOGLProcessor getInstance()
    {
        return SWTJOGLProcessor.instance;
    }

    public virtual void init(object display, object comp)
    {
    }

    public virtual bool isHolderCreated()
    {
        return true;
    }

    public virtual void setRenderer(object renderer)
    {
    }

    public virtual bool isJOGL()
    {
        return false;
    }

    public virtual void createSurface()
    {
    }

    public virtual void onSurfaceCreated()
    {
    }

    public virtual void onSurfaceChangedForEvent(object @event)
    {
    }

    public virtual void onSurfaceChanged()
    {
    }

    public virtual void onSurfaceChangedWH(int width, int height)
    {
    }

    public virtual void addListener()
    {
    }

    public virtual void addListeners(MIDlet midlet)
    {
    }

    public virtual void run()
    {
    }

    public virtual void clear()
    {
    }

    public virtual void setCustom(int width, int height, float ratio)
    {
    }

    public virtual void setRatioProcessor(RatioProcessor ratioProcessor)
    {
    }

    public virtual bool isPortraitRatioProcessor()
    {
        return true;
    }

    public virtual int charWidth(Font font, char ch)
    {
        throw new SystemException();
    }

    public virtual int charsWidth(Font font, char[] ch, int offset, int length)
    {
        throw new SystemException();
    }

    public virtual int stringWidth(Font font, string str)
    {
        throw new SystemException();
    }

    public virtual int substringWidth(Font font, string str, int offset, int len)
    {
        throw new SystemException();
    }

}

