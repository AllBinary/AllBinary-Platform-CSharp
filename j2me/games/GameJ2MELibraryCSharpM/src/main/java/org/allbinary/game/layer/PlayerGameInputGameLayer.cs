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
using PlayerGameInput = org.allbinary.game.input.PlayerGameInput;
using PlayerGameInputCompositeInterface = org.allbinary.game.input.PlayerGameInputCompositeInterface;
using PointFactory = org.allbinary.graphics.PointFactory;
using Rectangle = org.allbinary.graphics.Rectangle;
using CanvasStrings = org.allbinary.graphics.displayable.CanvasStrings;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StaticViewPosition = org.allbinary.view.StaticViewPosition;

namespace org.allbinary.game.layer;

public class PlayerGameInputGameLayer : AllBinaryGameLayer, PlayerGameInputCompositeInterface
{
    private PlayerGameInput playerGameInput;
    public PlayerGameInputGameLayer(int playerInputId) : base(StringUtil.getInstance().EMPTY_STRING, new Rectangle(PointFactory.getInstance().ZERO_ZERO, 0, 0), new StaticViewPosition(0, 0, 0))
    {
        // base(StringUtil.getInstance().EMPTY_STRING, new Rectangle(PointFactory.getInstance().ZERO_ZERO, 0, 0), new StaticViewPosition(0, 0, 0)) is called from the constructor declaration
        this.playerGameInput = new PlayerGameInput(this.getGameKeyEventList(), new BasicArrayListD(), playerInputId);
        CanvasStrings canvasStrings = CanvasStrings.getInstance();
        this.logUtil.putF("Danger Danger Danger: Should Not Be Called Except For Testing Input", this, canvasStrings.PAINT);
    }

    public override PlayerGameInput getPlayerGameInput()
    {
        return this.playerGameInput;
    }

    public override void initInputProcessors()
    {
    }

    // throws Exception
    public override void processInput(AllBinaryLayerManager myManager)
    {
    }

    public override void paint(Graphics graphics)
    {
    }

}

