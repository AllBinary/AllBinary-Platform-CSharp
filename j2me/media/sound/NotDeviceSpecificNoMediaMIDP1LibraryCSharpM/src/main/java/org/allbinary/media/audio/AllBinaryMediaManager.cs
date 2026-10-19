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
using System.Runtime.CompilerServices;
//using InputStream = java.io.InputStream;
//using Player = javax.microedition.media.Player;
using TsUtil = org.allbinary.TsUtil;
using ProgressCanvasFactory = org.allbinary.graphics.canvas.transition.progress.ProgressCanvasFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.audio;

//NotDeviceSpecificNoMediaMIDP1Library
public class AllBinaryMediaManager
{
    private static readonly string THIS = "AllBinaryMediaManagerNoMediaMIDP1";
    private AllBinaryMediaManager()
    {
    }

    public static bool isMuted()
    {
        return false;
    }

    public static void setMuted(bool aMuted)
    {
    }

    public static bool update()
    {
        return true;
    }

    // throws Exception
    public static void init(SoundsFactoryInterface soundsFactoryInterface)
    {
        LogUtil logUtil = LogUtil.getInstance();
        CommonStrings commonString = CommonStrings.getInstance();
        logUtil.putF(commonString.START, AllBinaryMediaManager.THIS, commonString.INIT);
        ProgressCanvasFactory.getInstance().addNormalPortion(50, "Media Manager");
        new Sounds(soundsFactoryInterface).init();
    }

    // throws Exception
    public static void shutdown(SoundsFactoryInterface soundsFactoryInterface)
    {
        new Sounds(soundsFactoryInterface).stopAll();
        new Sounds(soundsFactoryInterface).closeAll();
        TsUtil.getInstance().gc();
    }

    public static Player createPlayerFromInputStream(InputStream stream, string type)
    {
        LogUtil logUtil = LogUtil.getInstance();
        CommonStrings commonString = CommonStrings.getInstance();
        logUtil.putF(commonString.START, AllBinaryMediaManager.THIS, "creatPlayer(InputStream)");
        return ((Player) NoPlayer.NO_PLAYER);
    }

    public static Player createPlayer(string locator)
    {
        LogUtil logUtil = LogUtil.getInstance();
        CommonStrings commonString = CommonStrings.getInstance();
        logUtil.putF(commonString.START, AllBinaryMediaManager.THIS, "creatPlayer(locator)");
        return ((Player) NoPlayer.NO_PLAYER);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void playTone(int frequency, int time, int volume)
    {
    }

    public static string[] getSupportedContentTypes(string protocol)
    {
        return StringUtil.getInstance().getArrayInstance();
    }

    public static string[] getSupportedProtocols(string content_type)
    {
        return StringUtil.getInstance().getArrayInstance();
    }

}

