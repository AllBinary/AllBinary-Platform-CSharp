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
//using Canvas = javax.microedition.lcdui.Canvas;
using Features = org.allbinary.game.configuration.feature.Features;
using MainFeatureFactory = org.allbinary.game.configuration.feature.MainFeatureFactory;
//using CommandListener = javax.microedition.lcdui.CommandListener;

namespace org.allbinary.canvas;

public class FullScreenUtil
{
    private static readonly FullScreenUtil instance = new FullScreenUtil();
    public static FullScreenUtil getInstance()
    {
        return FullScreenUtil.instance;
    }

    // throws Exception
    public void initOnRun(Canvas fullScreenInterface, CommandListener commandListener)
    {
        (((RunnableCanvas) fullScreenInterface)).waitOnNotify(0);
        if (commandListener != null) {
            this.init(fullScreenInterface);
        }
    }

    public void init(Canvas fullScreenInterface)
    {
        MainFeatureFactory mainFeatureFactory = MainFeatureFactory.getInstance();
        Features features = Features.getInstance();
        if (features.isFeature(mainFeatureFactory.FULL_SCREEN)) {
            fullScreenInterface.setFullScreenMode(true);
        } else {
            fullScreenInterface.setFullScreenMode(false);
        }
    }

    public bool isScreenChange(bool isFullScreen)
    {
        MainFeatureFactory mainFeatureFactory = MainFeatureFactory.getInstance();
        Features features = Features.getInstance();
        if (features.isFeature(mainFeatureFactory.FULL_SCREEN) != isFullScreen) {
            return true;
        }
        return false;
    }

    public bool isScreenChangeCanvas(Canvas fullScreenInterface)
    {
        return this.isScreenChange(fullScreenInterface.isFullScreenMode());
    }

}

