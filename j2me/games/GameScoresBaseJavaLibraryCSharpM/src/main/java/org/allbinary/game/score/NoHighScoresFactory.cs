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
using GameInfo = org.allbinary.game.GameInfo;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.game.score;

public class NoHighScoresFactory : HighScoresBase
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly NoHighScoresFactory instance = new NoHighScoresFactory();
    public static NoHighScoresFactory getInstance()
    {
        return NoHighScoresFactory.instance;
    }

    public readonly HighScores[] NO_HIGH_SCORES = new HighScores[0];
    private NoHighScoresFactory()
    {
    }

    public override void fetchHighScores(GameInfo gameInfo, HighScoresResultsListener highScoresResultsListener)
    {
        this.logUtil.putF("Getting No HighScores", this, "fetchHighScores");
        highScoresResultsListener.setHighScoresArray(this.NO_HIGH_SCORES);
    }

    public override HighScoresHelperBaseInterface createHighScoresHelper()
    {
        return new HighScoresHelperBase();
    }

}

