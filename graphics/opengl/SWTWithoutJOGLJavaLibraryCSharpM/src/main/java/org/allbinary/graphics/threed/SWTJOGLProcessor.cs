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
using Font = javax.microedition.lcdui.Font;
using MIDlet = javax.microedition.midlet.MIDlet;

namespace org.allbinary.graphics.threed;

//SWTWithoutJOGL
public class SWTJOGLProcessor : global::java.lang.Runnable
{
    private static readonly SWTJOGLProcessor instance = new SWTJOGLProcessor();
    public static SWTJOGLProcessor getInstance()
    {
        return SWTJOGLProcessor.instance;
    }

    public GLHolder glHolder;
    public virtual void init(object display, object comp)
    {
    }

    public virtual bool isHolderCreated()
    {
        return glHolder.isCreated;
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

    private sealed class __SwtClosure_N65773 : GLHolder
    {
        private readonly global::System.Action<__SwtClosure_N65773, object> callback1;

        public __SwtClosure_N65773(global::System.Action<__SwtClosure_N65773, object> callback1)
        {
            this.callback1 = callback1;
        }

        public override void run(object renderer) => callback1(this, renderer);
    }

    public SWTJOGLProcessor()
    {
        this.glHolder = new __SwtClosure_N65773((__swtSelf_N65773, renderer) => {
        });
    }

}

