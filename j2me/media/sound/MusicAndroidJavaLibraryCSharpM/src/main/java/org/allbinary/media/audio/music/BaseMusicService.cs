// Generated Code Do Not Modify

using System;
using System.Linq;
using Service = android.app.Service;
using Intent = android.content.Intent;
using MediaPlayer = android.media.MediaPlayer;
using IBinder = android.os.IBinder;
using NullAndroidCanvas = org.allbinary.android.NullAndroidCanvas;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStateStrings = org.allbinary.@string.CommonStateStrings;
using CommonStrings = org.allbinary.@string.CommonStrings;
using ARunnable = org.allbinary.thread.ARunnable;

namespace org.allbinary.media.audio.music;

public class BaseMusicService : Service
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly CommonStateStrings commonStateStrings = CommonStateStrings.getInstance();
    private readonly string ALREADY_PLAYING = "This is one song per music service";
    private readonly string WAITING_FOR_MUSIC_TO_END = "Waiting for music to end";
    private MediaPlayer player = NullAndroidCanvas.NULL_MEDIA_PLAYER;
    private int songId = -1;
    private int leftVolume = -1;
    private int rightVolume = -1;
    public override IBinder onBind(Intent intent)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStateStrings.BIND);
        return null;
    }

    public override void onCreate()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStateStrings.CREATE);
    }

    public override void onDestroy()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStateStrings.DESTROY);
        if (this.player != NullAndroidCanvas.NULL_MEDIA_PLAYER) {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStateStrings.PAUSE);
            this.player.stop();
            this.player.reset();
            this.player.release();
        }
    }

    public virtual void pause()
    {
        if (this.player != NullAndroidCanvas.NULL_MEDIA_PLAYER) {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStateStrings.PAUSE);
            this.player.pause();
        }
    }

    public virtual void resume()
    {
        if (this.player != NullAndroidCanvas.NULL_MEDIA_PLAYER && !this.player.isPlaying()) {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStateStrings.RESUME);
            this.player.start();
        }
    }

    public virtual void start()
    {
        this.player = MediaPlayer.create(this, this.songId);
        this.player.setVolume((((float) this.leftVolume)) / 100.0f, (((float) this.rightVolume)) / 100.0f);
        this.player.setLooping(false);
        this.player.start();
    }

    public override void onStart(Intent intent, int startid)
    {
        this.onStartCommandIntent(intent);
        this.logUtil.putF(this.commonStrings.START, this, this.commonStateStrings.START);
    }

    public override int onStartCommand(Intent intent, int flags, int startId)
    {
        this.onStartCommandIntent(intent);
        return Service.START_STICKY;
    }

    public virtual void onStartCommandIntent(Intent intent)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStateStrings.ON_START_COMMAND);
        MusicStrings musicStrings = MusicStrings.getInstance();
        if (intent != null) {
            int command = intent.getIntExtra(this.commonStateStrings.ON_START_COMMAND, -1);
            this.logUtil.putF(CommonLabels.getInstance().COMMAND_LABEL + command, this, this.commonStateStrings.ON_START_COMMAND);
            if (command == 1) {
                this.pause();
                return;
            } else if (command == 2) {
                this.resume();
                return;
            } else {
                this.songId = intent.getIntExtra(musicStrings.SONG_EXTRA, -1);
                this.leftVolume = intent.getIntExtra(musicStrings.LEFT_VOLUME, -1);
                this.rightVolume = intent.getIntExtra(musicStrings.RIGHT_VOLUME, -1);
            }
        } else {
            throw new SystemException("Started service without intent");
        }
        if (this.songId != -1) {
            GC.Collect();
            if (this.player != NullAndroidCanvas.NULL_MEDIA_PLAYER && this.player.isPlaying()) {
                MediaPlayer player = this.player;
                this.logUtil.putF(this.ALREADY_PLAYING, this, this.commonStateStrings.ON_START_COMMAND);
                class MusicRunnable : ARunnable
                {
                    private readonly BaseMusicService baseMusicService;
                    public MusicRunnable(BaseMusicService baseMusicService)
                    {
                        this.baseMusicService = baseMusicService;
                    }

                    public override void run()
                    {
                        LogUtil logUtil = LogUtil.getInstance();
                        CommonStrings commonStrings = CommonStrings.getInstance();
                        CommonStateStrings commonStateStrings = CommonStateStrings.getInstance();
                        try {
                            while (player.isPlaying()) {
                                logUtil.putF(this.baseMusicService.WAITING_FOR_MUSIC_TO_END, this, commonStateStrings.ON_START_COMMAND);
                                System.Threading.Thread.Sleep((int) (1200));
                            }
                            this.baseMusicService.onStartCommandIntent(intent);
                        } catch (Exception e) {
                            logUtil.put(commonStrings.EXCEPTION, this, commonStateStrings.ON_START_COMMAND, e);
                        }
                    }

                }
                global::java.lang.Runnable runnable = new MusicRunnable(this);
                global::org.allbinary.thread.NullThread thread = new global::org.allbinary.thread.NullThread(runnable);
                thread.start();
                return;
            }
            this.start();
        }
    }

}

