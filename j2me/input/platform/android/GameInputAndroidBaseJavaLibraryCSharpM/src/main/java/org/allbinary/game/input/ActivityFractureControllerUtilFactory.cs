// Generated Code Do Not Modify

using System;
using System.Linq;
using AndroidInfoFactory = org.allbinary.android.AndroidInfoFactory;

namespace org.allbinary.game.input;

public class ActivityFractureControllerUtilFactory
{
    public static AndroidKeyFactory getInstance()
    {
        int SDK_VERSION = AndroidInfoFactory.getInstance().getVersion();
        if (SDK_VERSION <= 8) {
            return AndroidAPI1KeyFactory.getInstance();
        } else if (SDK_VERSION <= 11) {
            return AndroidAPI9KeyFactory.getInstance();
        } else {
            return AndroidAPI12KeyFactory.getAPI12Instance();
        }
    }

}

