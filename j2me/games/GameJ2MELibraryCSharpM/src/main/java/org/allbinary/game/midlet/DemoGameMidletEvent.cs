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
using AllBinaryEventObject = org.allbinary.logic.util.@event.AllBinaryEventObject;

namespace org.allbinary.game.midlet;

public class DemoGameMidletEvent : AllBinaryEventObject
{
    private DemoGameMidletState demoGameMidletState;
    public DemoGameMidletEvent(object anyType, DemoGameMidletState demoGameMidletState) : base(anyType)
    {
        // base(anyType) is called from the constructor declaration
        this.demoGameMidletState = demoGameMidletState;
    }

    public virtual void init(object anyType)
    {
        this.setSource(anyType);
    }

    public virtual void setDemoGameMidletState(DemoGameMidletState demoGameMidletState)
    {
        this.demoGameMidletState = demoGameMidletState;
    }

    public virtual DemoGameMidletState getDemoGameMidletState()
    {
        return this.demoGameMidletState;
    }

}

