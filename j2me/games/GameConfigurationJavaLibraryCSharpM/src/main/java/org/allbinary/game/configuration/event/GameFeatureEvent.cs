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

namespace org.allbinary.game.configuration.@event;

public class GameFeatureEvent : AllBinaryEventObject
{
    private readonly string whatChanged;
    public GameFeatureEvent(object anyType, string whatChanged) : base(anyType)
    {
        // base(anyType) is called from the constructor declaration
        this.whatChanged = whatChanged;
    }

    public virtual string getWhatChanged()
    {
        return this.whatChanged;
    }

    public virtual object getGameOption()
    {
        return this.getSource();
    }

}

