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
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.game.input;

public class PlatformKeyFactory
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static PlatformKeyFactory getInstance()
    {
        if (PlatformKeyFactory.instance == NullUtil.getInstance().NULL_OBJECT) {
            PlatformKeyFactory.instance = new PlatformKeyFactory();
        }
        return ((PlatformKeyFactory) PlatformKeyFactory.instance);
    }

    public virtual string getString(int keyCode)
    {
        return PCGameKey.getString(keyCode);
    }

    public virtual bool isSubmission(Input input)
    {
        return PCKeyFactory.getInstance().isSubmission(input);
    }

    public virtual bool isDelete(Input input)
    {
        return PCKeyFactory.getInstance().isDelete(input);
    }

    public virtual bool isBackSpace(Input input)
    {
        return PCKeyFactory.getInstance().isBackSpace(input);
    }

    public virtual bool isUp(Input input)
    {
        return PCKeyFactory.getInstance().isUp(input);
    }

    public virtual bool isDown(Input input)
    {
        return PCKeyFactory.getInstance().isDown(input);
    }

    public virtual bool isEnter(Input input)
    {
        return PCKeyFactory.getInstance().isEnter(input);
    }

    public virtual bool isLeft(Input input)
    {
        return PCKeyFactory.getInstance().isLeft(input);
    }

    public virtual bool isRight(Input input)
    {
        return PCKeyFactory.getInstance().isRight(input);
    }

}

