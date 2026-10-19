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
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.combat.destroy;

public class DestroyableBaseBehavior : DestroyableInterface
{
    private static readonly DestroyableBaseBehavior instance = new DestroyableBaseBehavior();
    public static DestroyableBaseBehavior getInstance()
    {
        return DestroyableBaseBehavior.instance;
    }

    public virtual string getName()
    {
        return this.GetType().FullName;
    }

    // throws Exception
    public virtual bool isDestroyed()
    {
        throw new Exception(CommonStrings.getInstance().NOT_IMPLEMENTED);
    }

    public virtual void setDestroyed(bool destroyed)
    {
    }

}

