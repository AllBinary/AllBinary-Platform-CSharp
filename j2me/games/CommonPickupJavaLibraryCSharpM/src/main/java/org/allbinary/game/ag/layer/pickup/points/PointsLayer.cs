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
//using Graphics = javax.microedition.lcdui.Graphics;
using ScoreableInterface = org.allbinary.game.score.ScoreableInterface;
using PointFactory = org.allbinary.graphics.PointFactory;
using Rectangle = org.allbinary.graphics.Rectangle;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using ViewPosition = org.allbinary.view.ViewPosition;

namespace org.allbinary.game.ag.layer.pickup.points;

public class PointsLayer : AllBinaryLayer
{
    private readonly int points;
    public PointsLayer(int points) : base(StringUtil.getInstance().EMPTY_STRING, new Rectangle(PointFactory.getInstance().ZERO_ZERO, 0, 0), ViewPosition.getInstanceD())
    {
        // base(StringUtil.getInstance().EMPTY_STRING, new Rectangle(PointFactory.getInstance().ZERO_ZERO, 0, 0), ViewPosition.getInstanceD()) is called from the constructor declaration
        this.points = points;
    }

    public override void paint(Graphics graphics)
    {
    }

    public virtual void visit(ScoreableInterface scoreableInterface)
    {
        scoreableInterface.addPoints(this.points);
    }

}

