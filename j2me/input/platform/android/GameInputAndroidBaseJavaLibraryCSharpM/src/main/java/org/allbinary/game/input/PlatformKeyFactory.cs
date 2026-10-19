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

    private readonly AndroidKeyFactory androidKeyFactory = ActivityFractureControllerUtilFactory.getInstance();
    public virtual string getString(int keyCode)
    {
        return AndroidGameKey.getString(keyCode);
    }

    public virtual bool isSubmission(Input input)
    {
        return this.androidKeyFactory.isSubmission(input);
    }

    public virtual bool isDelete(Input input)
    {
        return this.androidKeyFactory.isDelete(input);
    }

    public virtual bool isBackSpace(Input input)
    {
        return this.androidKeyFactory.isBackSpace(input);
    }

    public virtual bool isLeft(Input input)
    {
        return this.androidKeyFactory.isLeft(input);
    }

    public virtual bool isRight(Input input)
    {
        return this.androidKeyFactory.isRight(input);
    }

    public virtual bool isUp(Input input)
    {
        return this.androidKeyFactory.isUp(input);
    }

    public virtual bool isDown(Input input)
    {
        return this.androidKeyFactory.isDown(input);
    }

    public virtual bool isEnter(Input input)
    {
        return this.androidKeyFactory.isEnter(input);
    }

}

