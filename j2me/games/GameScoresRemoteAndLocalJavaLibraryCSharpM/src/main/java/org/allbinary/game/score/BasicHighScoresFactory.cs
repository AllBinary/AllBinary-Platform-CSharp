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
using ARunnable = org.allbinary.thread.ARunnable;
using BasicHighScoresGameInfoFactory = org.allbinary.game.BasicHighScoresGameInfoFactory;
using GameInfo = org.allbinary.game.GameInfo;
using GameType = org.allbinary.game.GameType;
using GameTypeFactory = org.allbinary.game.GameTypeFactory;
using RemoteHighScores = org.allbinary.game.score.remote.RemoteHighScores;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BooleanFactory = org.allbinary.logic.java.@bool.BooleanFactory;
using SoftwareInformation = org.allbinary.logic.system.SoftwareInformation;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using SecondaryThreadPool = org.allbinary.thread.SecondaryThreadPool;

namespace org.allbinary.game.score;

public class BasicHighScoresFactory : HighScoresBase
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly AbeClientInformationInterface abeClientInformation;
    private readonly SoftwareInformation softwareInformation;
    public BasicHighScoresFactory(AbeClientInformationInterface abeClientInformation, SoftwareInformation softwareInformation)
    {
        this.abeClientInformation = abeClientInformation;
        this.softwareInformation = softwareInformation;
    }

    private readonly HighScores[] highScoresArray = new HighScores[2];
    private readonly string TOP = "Top";
    private readonly string SCORES = "Scores";
    private readonly string PERSONAL_HIGH_SCORES = "Personal Top Scores";
    private readonly string WORLD_TOP_SCORES = "World Top Scores";
    private readonly string FETCH = "fetchHighScores";
    public virtual void fetchHighScores(GameInfo gameInfo, HighScoresResultsListener highScoresResultsListener)
    {
        this.logUtil.putF("Getting Remote/Local HighScores", this, this.FETCH);
        this.fetchHighScoresPreload(gameInfo, highScoresResultsListener, true);
    }

    public virtual void fetchHighScoresPreload(GameInfo gameInfo, HighScoresResultsListener highScoresResultsListener, bool preload)
    {
        SecondaryThreadPool.getInstance().runTask(new ARunnable()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void run()
            {
                LogUtil logUtil = LogUtil.getInstance();
                try {
                    logUtil.putF(this.commonStrings.START, this, FETCH);
                    highScoresArray[0] = RecordStoreHighScores.getInstance(abeClientInformation, gameInfo, TOP, PERSONAL_HIGH_SCORES, SCORES, new ScoreComparator(true));
                    GameType gameType = gameInfo.getGameType();
                    GameTypeFactory gameTypeFactory = GameTypeFactory.getInstance();
                    GameInfo gameInfo2 = gameInfo;
                    if (gameType == gameTypeFactory.SINGLE_PLAYER || gameType == gameTypeFactory.BOT) {
                        gameInfo2 = BasicHighScoresGameInfoFactory.getInstance().SINGLE_PLAYER_SERVER;
                    } else if (gameType == gameTypeFactory.MULTI_PLAYER) {
                        gameInfo2 = BasicHighScoresGameInfoFactory.getInstance().MULTI_PLAYER_SERVER;
                    }
                    highScoresArray[1] = RemoteHighScores.getInstancePreload(abeClientInformation, softwareInformation, gameInfo2, WORLD_TOP_SCORES, SCORES, BooleanFactory.getInstance().FALSE, preload);
                    logUtil.putF(this.commonStrings.END, this, FETCH);
                    LastFetchHighScoresFactory.getInstance().highScoresArray = highScoresArray;
                    highScoresResultsListener.setHighScoresArray(highScoresArray);
                } catch (Exception e) {
                    logUtil.put(commonStrings.EXCEPTION, this, FETCH, e);
                }
            }

#endif
);
    }

    public virtual HighScoresHelperBaseInterface createHighScoresHelper()
    {
        return new HighScoresHelper2();
    }

    public static bool loaded(int index2)
    {
        if (index2 >= 0) {
            return true;
        }
        return false;
    }

}

