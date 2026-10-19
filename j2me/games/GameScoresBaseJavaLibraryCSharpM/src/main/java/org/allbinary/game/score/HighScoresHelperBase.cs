/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.score;

public class HighScoresHelperBase : HighScoresHelperBaseInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public HighScores[] highScoresArrayP = LastFetchHighScoresFactory.getInstance().highScoresArray;
    public virtual void setHighScoresArray(HighScores[] highScoresArrayP)
    {
        if (highScoresArrayP != null) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.putF(new StringMaker().append(commonStrings.START).appendint(highScoresArrayP.Length).ToString(), this, "setHighScoresArray");
        } else {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.putF(commonStrings.START, this, "setHighScoresArray");
        }
        this.highScoresArrayP = highScoresArrayP;
    }

    public virtual HighScores getNextHighScores()
    {
        return NullHighScoresSingletonFactory.getInstance();
    }

    public virtual bool isAnyHighScores()
    {
        throw new SystemException();
    }

    public virtual void setSelectedHighScores(HighScores selectedHighScores)
    {
    }

    public virtual HighScores getSelectedHighScores()
    {
        return NullHighScoresSingletonFactory.getInstance();
    }

    public virtual HighScores[] getHighScoresArray()
    {
        return this.highScoresArrayP;
    }

    public virtual void selectHighScores()
    {
    }

}

