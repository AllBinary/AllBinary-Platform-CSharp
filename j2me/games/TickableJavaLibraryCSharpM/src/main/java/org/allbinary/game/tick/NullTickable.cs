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
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;

namespace org.allbinary.game.tick;

public class NullTickable : TickableInterface
{
    private static readonly NullTickable SINGLETON = new NullTickable();
    public static NullTickable getInstance()
    {
        return NullTickable.SINGLETON;
    }

    // throws Exception
    public virtual void processTick(AllBinaryLayerManager allBinaryLayerManager)
    {
    }

    private readonly string NAME = "NulLTickable";
    public virtual string getName()
    {
        return this.NAME;
    }

}

