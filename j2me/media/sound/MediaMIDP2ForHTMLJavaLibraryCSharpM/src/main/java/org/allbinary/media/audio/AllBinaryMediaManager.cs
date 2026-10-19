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
//using Manager = javax.microedition.media.Manager;
//using MediaException = javax.microedition.media.MediaException;
//using Player = javax.microedition.media.Player;
using TsUtil = org.allbinary.TsUtil;
using Features = org.allbinary.game.configuration.feature.Features;
using GameFeatureFactory = org.allbinary.game.configuration.feature.GameFeatureFactory;
using ProgressCanvasFactory = org.allbinary.graphics.canvas.transition.progress.ProgressCanvasFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.audio;

//MediaMIDP2ForHTMLJavaLibrary
public class AllBinaryMediaManager
{
    private static readonly string THIS = "AllBinaryMediaManagerHTML5";
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

    // throws Exception
    public static Player createPlayer(string resource)
    {
        if (Features.getInstance().isFeature(GameFeatureFactory.getInstance().SOUND)) {
            if (TsUtil.getInstance().compareTo(resource, Manager.TONE_DEVICE_LOCATOR) == 0) {
                return Manager.createPlayer(resource);
            } else {
                return Manager.createPlayer(resource.Substring(0, (resource.Length - 4) - (0)));
            }
        } else {
            return NoPlayer.NO_PLAYER;
        }
    }

    // throws MediaException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void playTone(int frequency, int time, int volume)
    {
        if (Features.getInstance().isFeature(GameFeatureFactory.getInstance().SOUND)) {
            Manager.playTone(frequency, time, volume);
        }
    }

}

