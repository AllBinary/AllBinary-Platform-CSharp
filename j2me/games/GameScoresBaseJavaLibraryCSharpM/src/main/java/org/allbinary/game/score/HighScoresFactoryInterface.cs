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

namespace org.allbinary.game.score;

public interface HighScoresFactoryInterface
{
    void fetchHighScores(GameInfo gameInfo, HighScoresResultsListener highScoresResultsListener);

    void fetchHighScoresPreload(GameInfo gameInfo, HighScoresResultsListener highScoresResultsListener, bool preload);

    HighScoresHelperBaseInterface createHighScoresHelper();

}

