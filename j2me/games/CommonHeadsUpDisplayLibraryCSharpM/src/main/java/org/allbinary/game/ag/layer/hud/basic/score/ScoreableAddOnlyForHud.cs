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
using Scoreable = org.allbinary.game.score.Scoreable;

namespace org.allbinary.game.ag.layer.hud.basic.score;

public class ScoreableAddOnlyForHud : Scoreable
{
    private readonly ScoreHudWidget scoreHudWidget;
    public ScoreableAddOnlyForHud(ScoreHudWidget scoreVectorGraphic) : base(0)
    {
        // base(0) is called from the constructor declaration
        this.scoreHudWidget = scoreVectorGraphic;
        this.getScoreHudWidget().set(0);
    }

    public override void removePoints(int points)
    {
    }

    public override void addPoints(int points)
    {
        base.addPoints(points);
        this.getScoreHudWidget().add(points);
    }

    public virtual ScoreHudWidget getScoreHudWidget()
    {
        return this.scoreHudWidget;
    }

}

