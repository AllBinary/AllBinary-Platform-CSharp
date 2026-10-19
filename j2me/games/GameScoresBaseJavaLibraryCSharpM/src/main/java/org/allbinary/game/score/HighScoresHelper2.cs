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

public class HighScoresHelper2 : HighScoresHelperBase
{
    private readonly CircularIndexUtil circularIndexUtil = CircularIndexUtil.createInstanceAt(0, 0);
    private HighScores selectedHighScores = NullHighScoresSingletonFactory.getInstance();
    public override void setSelectedHighScores(HighScores selectedHighScores)
    {
        this.selectedHighScores = selectedHighScores;
    }

    public override HighScores getSelectedHighScores()
    {
        return this.selectedHighScores;
    }

    public override void setHighScoresArray(HighScores[] highScoresArrayP)
    {
        base.setHighScoresArray(highScoresArrayP);
        this.circularIndexUtil.setSize(this.highScoresArrayP.Length);
        this.selectHighScores();
    }

    public override void selectHighScores()
    {
        if (this.highScoresArrayP.Length == 0) {
            this.setSelectedHighScores(NullHighScoresSingletonFactory.getInstance());
            return;
        }
        this.circularIndexUtil.next();
        HighScores highScores = this.highScoresArrayP[this.circularIndexUtil.getIndex()];
        int index = 0;
        while (highScores.getTotal() < 1 && index < this.highScoresArrayP.Length) {
            highScores = this.highScoresArrayP[this.circularIndexUtil.next()];
            index++;
        }
        this.setSelectedHighScores(highScores);
    }

}

