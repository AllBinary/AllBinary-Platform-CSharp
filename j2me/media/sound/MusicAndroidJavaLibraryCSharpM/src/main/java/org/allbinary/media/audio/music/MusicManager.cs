// Generated Code Do Not Modify

using System;
using System.Linq;
using Activity = android.app.Activity;
using Context = android.content.Context;
using Intent = android.content.Intent;
using AndroidServicesUtil = org.allbinary.android.AndroidServicesUtil;
using ResourceUtil = org.allbinary.data.resource.ResourceUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using NoSound = org.allbinary.media.audio.NoSound;
using Sound = org.allbinary.media.audio.Sound;
using CommonStateStrings = org.allbinary.@string.CommonStateStrings;
using CommonStrings = org.allbinary.@string.CommonStrings;
using GameTickTimeDelayHelper = org.allbinary.time.GameTickTimeDelayHelper;
using GameTickTimeDelayHelperFactory = org.allbinary.time.GameTickTimeDelayHelperFactory;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.media.audio.music;

public class MusicManager
{
    private readonly string PLAY = "Play ";
    private readonly string FOR = " for: ";
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly MusicStrings musicStrings = MusicStrings.getInstance();
    private readonly CommonStateStrings commonStateStrings = CommonStateStrings.getInstance();
    private readonly BasicArrayListUtil basicArrayListUtil = BasicArrayListUtil.getInstance();
    private readonly ResourceUtil resourceUtil = ResourceUtil.getInstance();
    private readonly AndroidServicesUtil androidServicesUtil = AndroidServicesUtil.getInstance();
    private readonly GameTickTimeDelayHelper gameTickTimeDelayHelper = GameTickTimeDelayHelperFactory.getInstance();
    private readonly TimeDelayHelper timeDelayHelper = new TimeDelayHelper(0);
    private readonly TimeDelayHelper timeDelayHelper2 = new TimeDelayHelper(1200);
    private readonly BasicArrayList songList;
    private Sound currentSongSound = NoSound.getInstance();
    private Sound nextSongSound = NoSound.getInstance();
    private int leftVolume = 100;
    private int rightVolume = 100;
    private readonly Type musicServiceClass;
    private readonly Intent currentIntent;
    public MusicManager(Type musicServiceClass, BasicArrayList songList)
    {
        PreLogUtil.put(this.commonStateStrings.CONTEXT + this.resourceUtil.getContext(), this, this.commonStrings.CONSTRUCTOR);
        this.musicServiceClass = musicServiceClass;
        this.currentIntent = new Intent(this.resourceUtil.getContext(), musicServiceClass);
        this.songList = songList;
    }

    public virtual void nextSong(Sound nextSongSound, int leftVolume, int rightVolume)
    {
        if (nextSongSound == null) {
            nextSongSound = NoSound.getInstance();
        }
        this.nextSongSound = nextSongSound;
        this.leftVolume = leftVolume;
        this.rightVolume = rightVolume;
        this.reset();
    }

    public virtual void reset()
    {
        this.timeDelayHelper.delay = 0;
    }

    public virtual void process()
    {
        if (this.songList.size() == 0) {
            return;
        }
        if (this.timeDelayHelper.isTime(this.gameTickTimeDelayHelper.startTime)) {
            this.startNewSong();
            return;
        }
        if (this.timeDelayHelper2.isTime(this.gameTickTimeDelayHelper.startTime)) {
            if (this.androidServicesUtil.isServiceRunning(this.musicServiceClass.FullName)) {
            } else {
                this.startNewSong();
            }
        }
    }

    public virtual void show()
    {
        for (int index = this.songList.size(); --index >= 0; ) {
            Sound sound = ((Sound) this.songList.get(index));
            long duration = ((long) sound.getDuration());
            PreLogUtil.put(new StringMaker().append(this.PLAY).append(sound.getResource()).append(this.FOR).appendlong(duration).ToString(), this, this.commonStrings.PROCESS);
        }
    }

    public virtual void startNewSong()
    {
        try {
            this.resourceUtil.getContext().stopService(this.currentIntent);
            if (this.nextSongSound == NoSound.getInstance()) {
                this.currentSongSound = ((Sound) this.basicArrayListUtil.getRandom(this.songList));
            } else {
                this.currentSongSound = this.nextSongSound;
                this.nextSongSound = NoSound.getInstance();
            }
            long duration = ((long) this.currentSongSound.getDuration());
            PreLogUtil.put(new StringMaker().append(this.PLAY).append(this.currentSongSound.getResource()).append(this.FOR).appendlong(duration).ToString(), this, this.commonStrings.PROCESS);
            this.timeDelayHelper.delay = ((int) duration);
            this.currentIntent.putExtra(this.musicStrings.SONG_EXTRA, ((int) this.resourceUtil.getResourceId(this.currentSongSound.getResource())));
            this.currentIntent.putExtra(this.musicStrings.LEFT_VOLUME, this.leftVolume);
            this.currentIntent.putExtra(this.musicStrings.RIGHT_VOLUME, this.rightVolume);
            this.resourceUtil.getContext().startService(this.currentIntent);
        } catch (Exception e) {
            string resource = StringUtil.getInstance().EMPTY_STRING;
            if (this.currentSongSound != null) {
                resource = this.currentSongSound.getResource();
            }
            PreLogUtil.putOE(this.commonStrings.EXCEPTION_LABEL + resource, this, this.commonStrings.PROCESS, e);
        }
    }

    // throws Exception
    public virtual void stop()
    {
        this.resourceUtil.getContext().stopService(this.currentIntent);
    }

    public static void pause(Activity activity, Type musicServiceClass)
    {
        CommonStateStrings commonStateStrings = CommonStateStrings.getInstance();
        Intent musicPauseIntent = new Intent(((Context) activity), musicServiceClass);
        musicPauseIntent.putExtra(commonStateStrings.ON_START_COMMAND, 1);
        activity.startService(musicPauseIntent);
    }

    public static void resume(Activity activity, Type musicServiceClass)
    {
        if (AndroidServicesUtil.getInstance().isServiceRunning(musicServiceClass.FullName)) {
            CommonStateStrings commonStateStrings = CommonStateStrings.getInstance();
            Intent musicResumeIntent = new Intent(activity, musicServiceClass);
            musicResumeIntent.putExtra(commonStateStrings.ON_START_COMMAND, 2);
            activity.startService(musicResumeIntent);
        }
    }

}

