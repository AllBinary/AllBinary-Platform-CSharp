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
using CircularIndexUtil = org.allbinary.util.CircularIndexUtil;

namespace org.allbinary.game.score;

public class HighScoresHelper : HighScoresHelperBase
{
    private readonly CircularIndexUtil circularIndexUtil = CircularIndexUtil.createInstanceAt(0, 0);
    public override void setHighScoresArray(HighScores[] highScoresArrayP)
    {
        base.setHighScoresArray(highScoresArrayP);
        this.circularIndexUtil.setSize(this.highScoresArrayP.Length);
    }

    public int lastIndex = -1;
    public override HighScores getNextHighScores()
    {
        HighScores highScores = this.highScoresArrayP[this.circularIndexUtil.getIndex()];
        int index = 0;
        while ((highScores.getTotal() < 1 || this.lastIndex == this.circularIndexUtil.getIndex()) && index < this.highScoresArrayP.Length) {
            this.circularIndexUtil.next();
            highScores = this.highScoresArrayP[this.circularIndexUtil.getIndex()];
            index++;
        }
        this.lastIndex = this.circularIndexUtil.getIndex();
        return highScores;
    }

    public override bool isAnyHighScores()
    {
        if (this.highScoresArrayP.Length < 1) {
            return false;
        }
        bool anyScores = false;
        HighScores highScores = null;
        for (int index = this.highScoresArrayP.Length - 1; index >= 0; index--) {
            highScores = this.highScoresArrayP[index];
            if (highScores.getTotal() > 0) {
                anyScores = true;
            }
        }
        return anyScores;
    }

}

