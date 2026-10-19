// Generated Code Do Not Modify

using System;
using System.Linq;
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.game.input;

public class AndroidAPI1KeyFactory : AndroidKeyFactory
{
    private static object instance = NullUtil.getInstance().NULL_OBJECT;
    public static AndroidAPI1KeyFactory getInstance()
    {
        if (AndroidAPI1KeyFactory.instance == NullUtil.getInstance().NULL_OBJECT) {
            AndroidAPI1KeyFactory.instance = new AndroidAPI1KeyFactory();
        }
        return ((AndroidAPI1KeyFactory) AndroidAPI1KeyFactory.instance);
    }

    protected AndroidAPI1KeyFactory()
    {
    }

}

