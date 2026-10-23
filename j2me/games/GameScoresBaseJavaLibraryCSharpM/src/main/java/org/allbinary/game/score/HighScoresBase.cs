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
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.score;

public class HighScoresBase : HighScoresFactoryInterface
{
    public CommonStrings commonStrings = CommonStrings.getInstance();
    public HighScoresBase()
    {
    }

    public virtual void fetchHighScores(GameInfo gameInfo, HighScoresResultsListener highScoresResultsListener)
    {
        throw new SystemException();
    }

    public virtual void fetchHighScoresPreload(GameInfo gameInfo, HighScoresResultsListener highScoresResultsListener, bool preload)
    {
        throw new SystemException();
    }

    public virtual HighScoresHelperBaseInterface createHighScoresHelper()
    {
        throw new SystemException();
    }

}

