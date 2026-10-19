// Generated Code Do Not Modify

using System;
using System.Linq;

namespace org.allbinary.game;

public class BasicGameInfoFactory
{
    private static readonly BasicGameInfoFactory SINGLETON = new BasicGameInfoFactory();
    public static BasicGameInfoFactory getInstance()
    {
        return BasicGameInfoFactory.SINGLETON;
    }

    public int currentReleaseIndex = 0;
    public int currentDestroyIndex = 0;
    public int total = 0;
    private BasicGameInfoFactory()
    {
    }

    public virtual void init(int total)
    {
        this.currentReleaseIndex = 0;
        this.currentDestroyIndex = 0;
        this.total = total;
    }

    public virtual bool isPeaked()
    {
        if (this.currentDestroyIndex >= this.total) {
            return true;
        } else {
            return false;
        }
    }

    public virtual int howManyLeft()
    {
        return this.total - this.currentDestroyIndex;
    }

}

