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

namespace org.allbinary.graphics;

public class RendererStateFactory
{
    private static readonly RendererStateFactory instance = new RendererStateFactory();
    public static RendererStateFactory getInstance()
    {
        return RendererStateFactory.instance;
    }

    private bool loaded = false;
    private bool surfaceChanged = false;
    public virtual void setLoaded(bool loaded)
    {
        this.loaded = loaded;
    }

    public virtual bool isLoaded()
    {
        return this.loaded;
    }

    public virtual void setSurfaceChanged(bool initialized)
    {
        this.surfaceChanged = initialized;
    }

    public virtual bool isSurfaceChanged()
    {
        return this.surfaceChanged;
    }

}

