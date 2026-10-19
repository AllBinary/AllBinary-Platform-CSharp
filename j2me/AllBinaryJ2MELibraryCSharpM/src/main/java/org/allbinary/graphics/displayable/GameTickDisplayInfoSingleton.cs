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

namespace org.allbinary.graphics.displayable;

public class GameTickDisplayInfoSingleton
{
    private static readonly GameTickDisplayInfoSingleton instance = new GameTickDisplayInfoSingleton();
    public static GameTickDisplayInfoSingleton getInstance()
    {
        return GameTickDisplayInfoSingleton.instance;
    }

    private readonly DisplayInfoSingleton displayInfoSingleton = DisplayInfoSingleton.getInstance();
    private int lastWidth;
    private int lastHeight;
    private int lastHalfWidth;
    private int lastHalfHeight;
    public virtual void update()
    {
        this.lastWidth = this.displayInfoSingleton.getLastWidth();
        this.lastHeight = this.displayInfoSingleton.getLastHeight();
        this.lastHalfWidth = this.displayInfoSingleton.getLastHalfWidth();
        this.lastHalfHeight = this.displayInfoSingleton.getLastHalfHeight();
    }

    public virtual int getLastWidth()
    {
        return this.lastWidth;
    }

    public virtual int getLastHeight()
    {
        return this.lastHeight;
    }

    public virtual int getLastHalfWidth()
    {
        return this.lastHalfWidth;
    }

    public virtual int getLastHalfHeight()
    {
        return this.lastHalfHeight;
    }

    public GameTickDisplayInfoSingleton()
    {
        this.lastWidth = this.displayInfoSingleton.getLastWidth();
        this.lastHeight = this.displayInfoSingleton.getLastHeight();
        this.lastHalfWidth = this.displayInfoSingleton.getLastHalfWidth();
        this.lastHalfHeight = this.displayInfoSingleton.getLastHalfHeight();
    }

}

