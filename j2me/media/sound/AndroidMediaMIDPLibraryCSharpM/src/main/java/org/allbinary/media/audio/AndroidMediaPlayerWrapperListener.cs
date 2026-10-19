// Generated Code Do Not Modify

using System;
using System.Linq;
//using PlayerListener = javax.microedition.media.PlayerListener;
using MediaPlayer = android.media.MediaPlayer;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.media.audio;

public class AndroidMediaPlayerWrapperListener
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private AndroidMediaPlayerWrapper androidMediaPlayerWrapper = AndroidMediaPlayerWrapper.NULL_ANDROID_MEDIA_PLAYER_WRAPPER;
    public AndroidMediaPlayerWrapperListener(AndroidMediaPlayerWrapper androidMediaPlayerWrapper)
    {
        this.mOnBufferingUpdateListener = new AndroidMediaPlayerOnBufferingUpdateListener(this);
        this.mOnPreparedListener = new AndroidMediaPlayerOnPreparedListener(this);
        this.mOnErrorListener = new AndroidMediaPlayerOnErrorListener(this);
        this.mOnCompletionListener = new AndroidMediaPlayerOnCompletionListener(this);
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
            this.androidMediaPlayerWrapper = androidMediaPlayerWrapper;
            MediaPlayer mediaPlayer = androidMediaPlayerWrapper.getMediaPlayer();
            mediaPlayer.setOnCompletionListener(this.mOnCompletionListener);
            mediaPlayer.setOnBufferingUpdateListener(this.mOnBufferingUpdateListener);
            mediaPlayer.setOnPreparedListener(this.mOnPreparedListener);
            mediaPlayer.setOnErrorListener(this.mOnErrorListener);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.CONSTRUCTOR, e);
        }
    }

    private class MediaPlayerOnBufferingUpdateListener : MediaPlayer.OnBufferingUpdateListener
    {
        public virtual void onBufferingUpdate(MediaPlayer mediaPlayer, int i)
        {
        }

    }
    private class MediaPlayerOnPreparedListener : MediaPlayer.OnPreparedListener
    {
        public virtual void onPrepared(MediaPlayer mp)
        {
        }

    }
    private class MediaPlayerOnErrorListener : MediaPlayer.OnErrorListener
    {
        public virtual bool onError(MediaPlayer mp, int what, int extra)
        {
            return false;
        }

    }
    private class MediaPlayerOnCompletionListener : MediaPlayer.OnCompletionListener
    {
        public virtual void onCompletion(MediaPlayer mp)
        {
        }

    }
    private class AndroidMediaPlayerOnBufferingUpdateListener : MediaPlayerOnBufferingUpdateListener
    {
        private readonly string ON_BUFFERING_UPDATE = "onBufferingUpdate()";
        private readonly AndroidMediaPlayerWrapperListener androidMediaPlayerWrapperListener;
        public AndroidMediaPlayerOnBufferingUpdateListener(AndroidMediaPlayerWrapperListener androidMediaPlayerWrapperListener)
        {
            this.androidMediaPlayerWrapperListener = androidMediaPlayerWrapperListener;
        }

        public override void onBufferingUpdate(MediaPlayer mediaPlayer, int i)
        {
            LogUtil logUtil = LogUtil.getInstance();
            logUtil.putF(new StringMaker().append("Update buffer: ").appendint(i).append("%").ToString(), this, this.ON_BUFFERING_UPDATE);
            this.androidMediaPlayerWrapperListener.androidMediaPlayerWrapper.update(PlayerListener.DEVICE_UNAVAILABLE);
        }

    }
    private MediaPlayer.OnBufferingUpdateListener mOnBufferingUpdateListener;
    private class AndroidMediaPlayerOnPreparedListener : MediaPlayerOnPreparedListener
    {
        private readonly string ON_PREPARE = "onPrepare()";
        private readonly AndroidMediaPlayerWrapperListener androidMediaPlayerWrapperListener;
        public AndroidMediaPlayerOnPreparedListener(AndroidMediaPlayerWrapperListener androidMediaPlayerWrapperListener)
        {
            this.androidMediaPlayerWrapperListener = androidMediaPlayerWrapperListener;
        }

        public override void onPrepared(MediaPlayer mp)
        {
            LogUtil logUtil = LogUtil.getInstance();
            CommonStrings commonStrings = CommonStrings.getInstance();
            logUtil.putF(commonStrings.START, this, this.ON_PREPARE);
            this.androidMediaPlayerWrapperListener.androidMediaPlayerWrapper.update(PlayerListener.DEVICE_AVAILABLE);
        }

    }
    private MediaPlayer.OnPreparedListener mOnPreparedListener;
    private class AndroidMediaPlayerOnErrorListener : MediaPlayerOnErrorListener
    {
        private readonly string ON_ERROR = "onError()";
        private readonly AndroidMediaPlayerWrapperListener androidMediaPlayerWrapperListener;
        public AndroidMediaPlayerOnErrorListener(AndroidMediaPlayerWrapperListener androidMediaPlayerWrapperListener)
        {
            this.androidMediaPlayerWrapperListener = androidMediaPlayerWrapperListener;
        }

        public override bool onError(MediaPlayer mp, int what, int extra)
        {
            LogUtil logUtil = LogUtil.getInstance();
            logUtil.putF(new StringMaker().append(CommonLabels.getInstance().START_LABEL).append("What: ").appendint(what).append(" Extra: ").appendint(extra).ToString(), this, this.ON_ERROR);
            this.androidMediaPlayerWrapperListener.androidMediaPlayerWrapper.update(PlayerListener.ERROR);
            return true;
        }

    }
    private MediaPlayer.OnErrorListener mOnErrorListener;
    private class AndroidMediaPlayerOnCompletionListener : MediaPlayerOnCompletionListener
    {
        private readonly string ON_COMPLETE = "onComplete()";
        private readonly AndroidMediaPlayerWrapperListener androidMediaPlayerWrapperListener;
        public AndroidMediaPlayerOnCompletionListener(AndroidMediaPlayerWrapperListener androidMediaPlayerWrapperListener)
        {
            this.androidMediaPlayerWrapperListener = androidMediaPlayerWrapperListener;
        }

        public override void onCompletion(MediaPlayer mp)
        {
            LogUtil logUtil = LogUtil.getInstance();
            CommonStrings commonStrings = CommonStrings.getInstance();
            logUtil.putF(commonStrings.START, this, this.ON_COMPLETE);
            this.androidMediaPlayerWrapperListener.androidMediaPlayerWrapper.update(PlayerListener.END_OF_MEDIA);
        }

    }
    private MediaPlayer.OnCompletionListener mOnCompletionListener;
}

