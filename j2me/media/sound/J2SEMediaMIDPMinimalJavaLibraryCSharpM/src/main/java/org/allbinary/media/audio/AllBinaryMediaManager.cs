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
//using BufferedInputStream = java.io.BufferedInputStream;
//using ByteArrayInputStream = java.io.ByteArrayInputStream;
//using IOException = java.io.IOException;
//using InputStream = java.io.InputStream;
//using Manager = javax.microedition.media.Manager;
//using MediaException = javax.microedition.media.MediaException;
//using Player = javax.microedition.media.Player;
using TsUtil = org.allbinary.TsUtil;
using AudioContentTypeDataFactory = org.allbinary.audio.AudioContentTypeDataFactory;
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;
using Features = org.allbinary.game.configuration.feature.Features;
using GameFeatureFactory = org.allbinary.game.configuration.feature.GameFeatureFactory;
using ProgressCanvasFactory = org.allbinary.graphics.canvas.transition.progress.ProgressCanvasFactory;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.audio;

//J2SEMediaMIDPMinimalJavaLibrary
public class AllBinaryMediaManager
{
    private static readonly string THIS = "AllBinaryMediaManagerPC";
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

    private static readonly string CREATE_PLAYER = "createPlayer";
    // throws Exception
    public static Player createPlayer(string resource)
    {
        if (resource.StartsWith(Manager.TONE_DEVICE_LOCATOR)) {
            return AllBinaryMediaManager.createPlayerFromInputStream(new ByteArrayInputStream(NullUtil.getInstance().NULL_BYTE_ARRAY), AudioContentTypeDataFactory.getInstance().MIME_AUDIO_TONE.getName());
        } else if (Features.getInstance().isFeature(GameFeatureFactory.getInstance().SOUND)) {
            try {
                InputStream inputStream = ResourceUtil.getInstance().getResourceAsStream(resource);
                BufferedInputStream bufferedInputStream = new BufferedInputStream(inputStream);
                return new PCClipWavPlayer(bufferedInputStream);
            } catch (Exception e) {
                LogUtil logUtil = LogUtil.getInstance();
                CommonStrings commonString = CommonStrings.getInstance();
                logUtil.put(commonString.EXCEPTION, AllBinaryMediaManager.THIS, CREATE_PLAYER, e);
                return NoPlayer.NO_PLAYER;
            }
        } else {
            return NoPlayer.NO_PLAYER;
        }
    }

    // throws IOException, MediaException
    public static Player createPlayerFromInputStream(InputStream stream, string type)
    {
        throw new MediaException("No Impl");
    }

    // throws MediaException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public static void playTone(int frequency, int time, int volume)
    {
        throw new MediaException("No Impl");
    }

    public static bool isInitialized()
    {
        return true;
    }

}

