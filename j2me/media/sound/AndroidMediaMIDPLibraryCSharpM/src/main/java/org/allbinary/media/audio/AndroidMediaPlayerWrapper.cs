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
//using MediaException = javax.microedition.media.MediaException;
//using Player = javax.microedition.media.Player;
//using PlayerListener = javax.microedition.media.PlayerListener;
using MediaPlayer = android.media.MediaPlayer;
using NullAndroidCanvas = org.allbinary.android.NullAndroidCanvas;
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.media.audio;

public class AndroidMediaPlayerWrapper : BasicPlayer
{
    public static AndroidMediaPlayerWrapper createPlayerWrapper()
    {
        try {
            return new AndroidMediaPlayerWrapper(StringUtil.getInstance().EMPTY_STRING);
        } catch (Exception e) {
            throw new SystemException();
        }
    }

    public static readonly AndroidMediaPlayerWrapper NULL_ANDROID_MEDIA_PLAYER_WRAPPER = AndroidMediaPlayerWrapper.createPlayerWrapper();
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private MediaPlayer mediaPlayer = NullAndroidCanvas.NULL_MEDIA_PLAYER;
    public AndroidMediaPlayerWrapper(string resource)
    {
        try {
            if (resource == StringUtil.getInstance().EMPTY_STRING) {
            } else {
                ResourceUtil resourceUtil = ResourceUtil.getInstance();
                MediaPlayer mediaPlayer = MediaPlayer.create(resourceUtil.getContext(), ((int) resourceUtil.getResourceId(resource)));
                if (mediaPlayer == null) {
                    throw new Exception(new StringMaker().append("Failed to create media player for: ").append(resource).append(" with id: ").append(resourceUtil.getResourceId(resource).ToString()).ToString());
                }
                this.setMediaPlayer(mediaPlayer);
                this.mediaPlayer.setLooping(false);
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION_LABEL + resource, this, this.commonStrings.CONSTRUCTOR, e);
            throw e;
        }
    }

    public override void setLoopCount(int count)
    {
        base.setLoopCount(count);
        if (this.mediaPlayer != NullAndroidCanvas.NULL_MEDIA_PLAYER && this.mediaPlayer != null) {
            if (count == 0) {
                this.mediaPlayer.setLooping(false);
            } else {
            }
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void addPlayerListener(PlayerListener playerListener)
    {
        base.addPlayerListener(playerListener);
    }

    public override void removePlayerListener(PlayerListener playerListener)
    {
        base.removePlayerListener(playerListener);
    }

    public override int getState()
    {
        if (this.mediaPlayer.isPlaying()) {
            return Player.STARTED;
        } else {
            return Player.PREFETCHED;
        }
    }

    public override void close()
    {
        try {
            this.mediaPlayer.release();
            this.mediaPlayer = NullAndroidCanvas.NULL_MEDIA_PLAYER;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.CLOSE, e);
        }
    }

    // throws MediaException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void start()
    {
        try {
            if (this.mediaPlayer.isPlaying()) {
                this.mediaPlayer.pause();
                this.mediaPlayer.seekTo(0);
            }
            this.mediaPlayer.start();
            base.start();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.START_METHOD_NAME, e);
        }
    }

    // throws MediaException
    [MethodImpl(MethodImplOptions.Synchronized)]
    public override void stop()
    {
        try {
            this.mediaPlayer.stop();
            this.mediaPlayer.prepare();
            base.stop();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "stop", e);
        }
    }

    public virtual void update(string @event)
    {
        this.logUtil.putF("LineEvent: " + @event, this, this.commonStrings.UPDATE);
        int size = this.listenersList.size();
        for (int index = 0; index < size; index++) {
            PlayerListener listener = ((PlayerListener) this.listenersList.objectArray[index]);
            listener.playerUpdate(this, @event, NullUtil.getInstance().NULL_OBJECT);
        }
    }

    public override void setVolume(int leftVolume, int rightVolume)
    {
        this.mediaPlayer.setVolume((((float) leftVolume)) / 100.0f, (((float) rightVolume)) / 100.0f);
    }

    public override long getDuration()
    {
        return ((long) this.mediaPlayer.getDuration());
    }

    public virtual void setMediaPlayer(MediaPlayer mediaPlayer)
    {
        this.mediaPlayer = mediaPlayer;
    }

    public virtual MediaPlayer getMediaPlayer()
    {
        return this.mediaPlayer;
    }

}

