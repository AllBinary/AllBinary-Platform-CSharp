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
using CanvasUtil = org.allbinary.game.displayable.canvas.CanvasUtil;
using GameInput = org.allbinary.game.input.GameInput;
using GameKeyEventSourceInterface = org.allbinary.game.input.GameKeyEventSourceInterface;
using GameKeyEventFactory = org.allbinary.game.input.@event.GameKeyEventFactory;
using AllBinaryLayer = org.allbinary.layer.AllBinaryLayer;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.ai;

public class BasicAI : ArtificialIntelligence, GameKeyEventSourceInterface
{
    public static readonly int? AI_VISITOR = SmallIntegerSingletonFactory.getInstance().getAt(2);
    public static readonly int? ID = SmallIntegerSingletonFactory.getInstance().getAt(1);
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly GameKeyEventFactory gameKeyEventFactory = GameKeyEventFactory.getInstance();
    private readonly AllBinaryLayer ownerLayerInterface;
    private readonly GameInput gameInput;
    private int lastKey = -1;
    public BasicAI(AllBinaryLayer ownerLayerInterface, GameInput gameInput)
    {
        this.ownerLayerInterface = ownerLayerInterface;
        this.gameInput = gameInput;
    }

    // throws Exception
    public override void processAI(AllBinaryLayerManager allBinaryLayerManager)
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    // throws Exception
    public virtual void processKeyAI(int key)
    {
        if (key != -1) {
            this.gameInput.add(this.gameKeyEventFactory.getInstanceForKey(this, key));
        }
    }

    public virtual void setLastKey(int lastKey)
    {
        this.lastKey = lastKey;
    }

    public virtual int getLastKey()
    {
        return this.lastKey;
    }

    public virtual AllBinaryLayer getOwnerLayerInterface()
    {
        return this.ownerLayerInterface;
    }

    public virtual GameInput getGameInput()
    {
        return this.gameInput;
    }

    public virtual string getName()
    {
        return this.GetType().FullName;
    }

    public override string ToString()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(CommonSeps.getInstance().NEW_LINE);
        stringBuffer.append(this.getName());
        stringBuffer.append(" LastKey: ");
        stringBuffer.append(CanvasUtil.getKeyName(this.getLastKey()));
        return stringBuffer.ToString();
    }

    public override int getSourceId()
    {
        return 1;
    }

}

