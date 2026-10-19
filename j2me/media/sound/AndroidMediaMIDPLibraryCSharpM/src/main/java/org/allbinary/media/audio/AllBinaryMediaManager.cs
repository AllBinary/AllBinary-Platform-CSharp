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
//using IOException = java.io.IOException;
//using InputStream = java.io.InputStream;
//using MediaException = javax.microedition.media.MediaException;
//using Player = javax.microedition.media.Player;
using TsUtil = org.allbinary.TsUtil;
using Features = org.allbinary.game.configuration.feature.Features;
using GameFeatureFactory = org.allbinary.game.configuration.feature.GameFeatureFactory;
using ProgressCanvasFactory = org.allbinary.graphics.canvas.transition.progress.ProgressCanvasFactory;
using ABSystemWrapper = org.allbinary.logic.ABSystemWrapper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.audio;

//AndroidMediaMIDPLibrary
public class AllBinaryMediaManager
{
    private static readonly string THIS = "AllBinaryMediaManagerAndroid";
    private static int mostUsedTotal = 0;
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
        AllBinaryMediaManager.shutdown(soundsFactoryInterface);
        ProgressCanvasFactory.getInstance().addNormalPortion(50, "Media Manager");
        TsUtil.getInstance().gc();
        new Sounds(soundsFactoryInterface).init();
        logUtil.putF(commonString.END, AllBinaryMediaManager.THIS, commonString.INIT);
    }

    // throws Exception
    public static void shutdown(SoundsFactoryInterface soundsFactoryInterface)
    {
        LogUtil logUtil = LogUtil.getInstance();
        CommonStrings commonString = CommonStrings.getInstance();
        logUtil.putF(commonString.START, AllBinaryMediaManager.THIS, "shutdown");
        if (soundsFactoryInterface.isInitialized()) {
            new Sounds(soundsFactoryInterface).stopAll();
            Sound[] soundInterfaceArray = soundsFactoryInterface.getSoundInterfaceArray();
            Player player = null;
            Player player2 = null;
            AndroidMediaPlayerWrapper androidMediaPlayerWrapper = null;
            for (int i = 0; i < soundInterfaceArray.Length; i++) {
                if (soundInterfaceArray[i] != null) {
                    player = soundInterfaceArray[i].getPlayerP();
                    if (player != null) {
                        player2 = (((PlayerComposite) player)).getPlayerP();
                        if (player2 is AndroidMediaPlayerWrapper) {
                            androidMediaPlayerWrapper = ((AndroidMediaPlayerWrapper) player2);
                            MediaPlayerUtil.getInstance().waitForMediaPlayer(androidMediaPlayerWrapper.getMediaPlayer());
                        } else {
                            throw new Exception("Unknown Property Player: " + player.GetType().FullName);
                        }
                    }
                }
            }
            new Sounds(soundsFactoryInterface).closeAll();
            TsUtil.getInstance().gc();
            soundsFactoryInterface.setInitialized(false);
            AllBinaryMediaManager.mostUsedTotal = 0;
        }
        logUtil.putF(commonString.START, AllBinaryMediaManager.THIS, "shutdown");
    }

    // throws Exception
    public static Player createPlayer(string resource)
    {
        AllBinaryMediaManager.mostUsedTotal++;
        LogUtil logUtil = LogUtil.getInstance();
        if (Features.getInstance().isFeature(GameFeatureFactory.getInstance().SOUND)) {
            try {
                return new AndroidMediaPlayerWrapper(resource);
            } catch (Exception e) {
                logUtil.put("Could not create AndroidMediaPlayerWrapper using NoPlayer at " + CommonLabels.getInstance().TOTAL_LABEL + AllBinaryMediaManager.mostUsedTotal, AllBinaryMediaManager.THIS, "createPlayer", e);
                return NoPlayer.NO_PLAYER;
            }
        } else {
            return NoPlayer.NO_PLAYER;
        }
    }

    // throws IOException, MediaException
    public static Player createPlayerFromInputStream(InputStream stream, string type)
    {
        throw new MediaException("No Input Stream Player");
    }

    // throws MediaException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void playTone(int frequency, int time, int volume)
    {
        throw new MediaException("No Tone Player");
    }

    public static bool isInitialized()
    {
        return true;
    }

}

