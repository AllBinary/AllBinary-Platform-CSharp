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
using ArtificialIntelligence = org.allbinary.ai.ArtificialIntelligence;
using ArtificialIntelligenceInterface = org.allbinary.ai.ArtificialIntelligenceInterface;
using CollidableBaseBehavior = org.allbinary.game.collision.CollidableBaseBehavior;
using CollidableBaseBehaviorFactory = org.allbinary.game.collision.CollidableBaseBehaviorFactory;
using CollidableInterfaceCompositeInterface = org.allbinary.game.collision.CollidableInterfaceCompositeInterface;
using CollidableNeverCollideBehaviorFactory = org.allbinary.game.collision.CollidableNeverCollideBehaviorFactory;
using Rectangle = org.allbinary.graphics.Rectangle;
using RectangleFactory = org.allbinary.graphics.RectangleFactory;
using ForcedLogUtil = org.allbinary.logic.communication.log.ForcedLogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
using ViewPositionBase = org.allbinary.view.ViewPositionBase;
using NullUtil = org.allbinary.logic.NullUtil;

namespace org.allbinary.game.layer;

public class CollidableCompositeLayer : AllBinaryGameLayer, CollidableInterfaceCompositeInterface
{
    private static object NULL_COLLIDABLE_COMPOSITE_LAYER = NullUtil.getInstance().NULL_OBJECT;
    public static CollidableCompositeLayer getNullInstance()
    {
        if (CollidableCompositeLayer.NULL_COLLIDABLE_COMPOSITE_LAYER == NullUtil.getInstance().NULL_OBJECT) {
            CollidableCompositeLayer.NULL_COLLIDABLE_COMPOSITE_LAYER = new CollidableCompositeLayer(StringUtil.getInstance().EMPTY_STRING, RectangleFactory.SINGLETON, ViewPositionBase.NULL_VIEW_POSITION, CollidableNeverCollideBehaviorFactory.getInstance());
        }
        return ((CollidableCompositeLayer) CollidableCompositeLayer.NULL_COLLIDABLE_COMPOSITE_LAYER);
    }

    private CollidableBaseBehavior collidableInferface = CollidableNeverCollideBehaviorFactory.getInstance().createBehavior();
    public CollidableCompositeLayer(string name, Rectangle layerInfo, ViewPositionBase viewPosition, CollidableBaseBehaviorFactory collidableBaseBehaviorFactory) : base(name, layerInfo, viewPosition)
    {
        // base(name, layerInfo, viewPosition) is called from the constructor declaration
        if (collidableBaseBehaviorFactory != CollidableNeverCollideBehaviorFactory.getInstance()) {
            this.setCollidableInferface(collidableBaseBehaviorFactory.createBehavior());
        }
    }

    public virtual ArtificialIntelligenceInterface getArtificialIntelligenceInterface()
    {
        ForcedLogUtil.log(this.commonStrings.NOT_IMPLEMENTED, this);
        return ArtificialIntelligence.getInstance();
    }

    public override CollidableBaseBehavior getCollidableInferface()
    {
        return this.collidableInferface;
    }

    public virtual void setCollidableInferface(CollidableBaseBehavior collidableInferface)
    {
        this.collidableInferface = collidableInferface;
    }

    public override bool implmentsCollidableInterface()
    {
        return true;
    }

    public override void toStringAppend(StringMaker stringBuffer)
    {
        CommonSeps commonSeps = CommonSeps.getInstance();
        base.toStringAppend(stringBuffer);
        stringBuffer.append(commonSeps.NEW_LINE);
        stringBuffer.append(this.getCollidableInferface().ToString());
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        this.toStringAppend(stringBuffer);
        return stringBuffer.ToString();
    }

}

