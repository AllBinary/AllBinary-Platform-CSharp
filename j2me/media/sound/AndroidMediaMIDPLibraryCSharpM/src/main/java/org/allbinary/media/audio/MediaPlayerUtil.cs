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
using MediaPlayer = android.media.MediaPlayer;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.media.audio;

public class MediaPlayerUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly MediaPlayerUtil instance = new MediaPlayerUtil();
    public static MediaPlayerUtil getInstance()
    {
        return MediaPlayerUtil.instance;
    }

    // throws Exception
    public virtual void waitForMediaPlayer(MediaPlayer mediaPlayer)
    {
        string MESSAGE = "Not Stopped Waiting";
        string METHOD_NAME = "wait";
        int index = 0;
        while (mediaPlayer.isPlaying() && index < 50) {
            this.logUtil.putF(MESSAGE, this, METHOD_NAME);
            System.Threading.Thread.Sleep((int) (100));
            index++;
        }
    }

}

