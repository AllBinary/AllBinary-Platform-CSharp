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
using ScoreableInterface = org.allbinary.game.score.ScoreableInterface;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerCircularPool = org.allbinary.layer.AllBinaryLayerCircularPool;
using AllBinaryLayerFactoryInterface = org.allbinary.layer.AllBinaryLayerFactoryInterface;

namespace org.allbinary.game.ag.layer.pickup.points;

public class PointsLayerCircularStaticPool : AllBinaryLayerCircularPool
{
    public PointsLayerCircularStaticPool(AllBinaryLayerFactoryInterface allbinaryLayerFactoryInterface, int total)
    {
        base.initAllBinaryLayerCircularPool(allbinaryLayerFactoryInterface, total);
    }

    // throws Exception
    public virtual void visit(AllBinaryLayer sourceLayerInterface)
    {
        PointsLayer pointsLayer = ((PointsLayer) this.getNextInstance());
        ScoreableInterface scoreableInterface = ((ScoreableInterface) sourceLayerInterface);
        pointsLayer.visit(scoreableInterface);
    }

}

