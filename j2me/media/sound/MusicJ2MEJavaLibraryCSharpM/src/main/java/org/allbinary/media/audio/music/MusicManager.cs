// Generated Code Do Not Modify

using System;
using System.Linq;
using ARunnable = org.allbinary.thread.ARunnable;
//using Player = javax.microedition.media.Player;
//using PlayerListener = javax.microedition.media.PlayerListener;
using AvianUtil = org.allbinary.AvianUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using NoSound = org.allbinary.media.audio.NoSound;
using PlayerStateUtil = org.allbinary.media.audio.PlayerStateUtil;
using Sound = org.allbinary.media.audio.Sound;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using GameTickTimeDelayHelper = org.allbinary.time.GameTickTimeDelayHelper;
using GameTickTimeDelayHelperFactory = org.allbinary.time.GameTickTimeDelayHelperFactory;
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.media.audio.music;

public class MusicManager
{
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly CommonSeps commonSeps = CommonSeps.getInstance();
    private readonly BasicArrayListUtil basicArrayListUtil = BasicArrayListUtil.getInstance();
    private readonly GameTickTimeDelayHelper gameTickTimeDelayHelper = GameTickTimeDelayHelperFactory.getInstance();
    private readonly PlayerStateUtil playerStateUtil = PlayerStateUtil.getInstance();
    private readonly TimeDelayHelper timeDelayHelper = new TimeDelayHelper(0);
    //Handle Media ending for Avian
    private class MusicManagerPlayerListener : PlayerListener
    {
        public virtual void playerUpdate(Player player, string @event, object eventData)
        {
            PreLogUtil.put(@event, this, commonStrings.PROCESS);
            if (@event == PlayerListener.END_OF_MEDIA || @event == PlayerListener.STOPPED || @event == PlayerListener.CLOSED) {
                reset();
            }
        }

    }
    private readonly PlayerListener playerListener = new MusicManagerPlayerListener();
    private readonly string PLAY = "Play ";
    private readonly string SONG = " for: ";
    private readonly string NEXT_SONG = CommonLabels.getInstance().NEXT + " Song: ";
    private readonly string STOPPING = "Stopping Current Song: ";
    private readonly string ENDING = "Ending Current Song: ";
    private readonly string WAITING_FOR_MEDIA_TO_END = "Waiting for media to end";
    private readonly string ALREADY_PLAYING = "Already Playing: ";
    private readonly string ALREADY_ENDED = "Last Song already ended: ";
    private readonly BasicArrayList songList;
    private Sound currentSongSound = NoSound.getInstance();
    private Sound nextSongSound = NoSound.getInstance();
    private bool reset = false;
    private bool noDuration = false;
    private bool stopped = true;
    public MusicManager(Type musicServiceClass, BasicArrayList songList)
    {
        this.songList = songList;
    }

    public virtual void startNewSong()
    {
        if (this.nextSongSound == NoSound.getInstance()) {
            Sound randomSongSound = ((Sound) this.basicArrayListUtil.getRandom(this.songList));
            this.nextSong(randomSongSound, 0, 0);
        }
        this.process();
    }

    public virtual void nextSong(Sound nextSongSound, int leftVolume, int rightVolume)
    {
        PreLogUtil.put(new StringMaker().append(NEXT_SONG).append(nextSongSound.getResource()).ToString(), this, this.commonStrings.PROCESS);
        this.nextSongSound = nextSongSound;
        this.reset();
        this.stopped = false;
    }

    public virtual void reset()
    {
        this.reset = true;
    }

    public virtual void process()
    {
        try {
            if (this.stopped) {
                return;
            }
            if (this.songList.size() == 0) {
                return;
            }
            if ((this.timeDelayHelper.isTime(this.gameTickTimeDelayHelper.startTime) && !this.noDuration) || this.reset) {
                this.reset = false;
                this.noDuration = false;
                Sound endingCurrentSongSound = this.currentSongSound;
                Sound nextSongSound = this.nextSongSound;
                this.nextSongSound = NoSound.getInstance();
                if (nextSongSound == NoSound.getInstance()) {
                    this.currentSongSound = ((Sound) BasicArrayListUtil.getInstance().getRandom(this.songList));
                } else {
                    this.currentSongSound = nextSongSound;
                }
                Sound startingCurrentSongSound = this.currentSongSound;
                long duration = ((long) this.currentSongSound.getDuration());
                this.timeDelayHelper.delay = ((int) duration);
                if (duration <= 0L) {
                    string NO_DURATION_FOR = "No Duration for: ";
                    PreLogUtil.put(new StringMaker().append(NO_DURATION_FOR).append(this.currentSongSound.getResource()).ToString(), this, this.commonStrings.PROCESS);
                    this.currentSongSound.getPlayerP().addPlayerListener(playerListener);
                    this.noDuration = true;
                }
                if (endingCurrentSongSound != NoSound.getInstance()) {
                    if (endingCurrentSongSound == startingCurrentSongSound && endingCurrentSongSound.getPlayerP().getState() == Player.STARTED) {
                        PreLogUtil.put(new StringMaker().append(this.ALREADY_PLAYING).append(endingCurrentSongSound.getResource()).ToString(), this, this.commonStrings.PROCESS);
                        PreLogUtil.put(new StringMaker().append(this.STOPPING).append(endingCurrentSongSound.getResource()).append(this.SONG).appendlong(duration).ToString(), this, this.commonStrings.PROCESS);
                        endingCurrentSongSound.getPlayerP().stop();
                        this.waitForStateChange(endingCurrentSongSound, startingCurrentSongSound);
                    } else {
                        if (endingCurrentSongSound.getPlayerP().getState() == Player.STARTED) {
                            PreLogUtil.put(new StringMaker().append(this.STOPPING).append(endingCurrentSongSound.getResource()).append(this.SONG).appendlong(duration).ToString(), this, this.commonStrings.PROCESS);
                            endingCurrentSongSound.getPlayerP().stop();
                            this.waitForStateChange(endingCurrentSongSound, startingCurrentSongSound);
                        } else {
                            PreLogUtil.put(new StringMaker().append(this.ALREADY_ENDED).append(this.PLAY).append(startingCurrentSongSound.getResource()).ToString(), this, this.commonStrings.PROCESS);
                            if (AvianUtil.isAvian()) {
                                endingCurrentSongSound.getPlayerP().stop();
                                startingCurrentSongSound.getPlayerP().stop();
                            }
                            startingCurrentSongSound.getPlayerP().start();
                        }
                    }
                } else {
                    PreLogUtil.put(new StringMaker().append(this.PLAY).append(this.currentSongSound.getResource()).append(this.SONG).appendlong(duration).ToString(), this, this.commonStrings.PROCESS);
                    this.currentSongSound.getPlayerP().start();
                }
            }
        } catch (Exception e) {
            string resource = StringUtil.getInstance().EMPTY_STRING;
            if (this.currentSongSound != NoSound.getInstance()) {
                resource = this.currentSongSound.getResource();
            }
            PreLogUtil.putOE(this.commonStrings.EXCEPTION_LABEL + resource, this, this.commonStrings.PROCESS, e);
        }
    }

    // throws Exception
    private void waitForStateChange(Sound endingCurrentSongSound, Sound startingCurrentSongSound)
    {
        while (endingCurrentSongSound.getPlayerP().getState() == Player.STARTED) {
            PreLogUtil.put(this.WAITING_FOR_MEDIA_TO_END, this, this.commonStrings.PROCESS);
            System.Threading.Thread.Sleep((int) (100));
        }
        PreLogUtil.put(new StringMaker().append(this.playerStateUtil.convert(endingCurrentSongSound.getPlayerP().getState())).append(this.commonSeps.SPACE).append(this.PLAY).append(startingCurrentSongSound.getResource()).ToString(), this, this.commonStrings.PROCESS);
        startingCurrentSongSound.getPlayerP().start();
    }

    // throws Exception
    public virtual void stop()
    {
        try {
            Sound currentSongSound = this.currentSongSound;
            if (currentSongSound != NoSound.getInstance()) {
                this.stopped = true;
                PreLogUtil.put(new StringMaker().append(this.ENDING).append(currentSongSound.getResource()).ToString(), this, this.commonStrings.PROCESS);
                currentSongSound.getPlayerP().stop();
            }
            this.timeDelayHelper.setStartTime(0);
            PreLogUtil.put(new StringMaker().append(this.commonStrings.END).append(StringUtil.getInstance().toString(currentSongSound)).ToString(), this, this.commonStrings.END);
        } catch (Exception e) {
            string resource = StringUtil.getInstance().EMPTY_STRING;
            if (currentSongSound != NoSound.getInstance()) {
                resource = currentSongSound.getResource();
            }
            PreLogUtil.putOE(this.commonStrings.EXCEPTION_LABEL + resource, this, this.commonStrings.END, e);
        }
    }

}

