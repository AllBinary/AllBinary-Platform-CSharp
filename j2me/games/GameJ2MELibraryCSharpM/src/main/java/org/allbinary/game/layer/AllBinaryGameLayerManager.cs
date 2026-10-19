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
using NullPlayerGameInputComposite = org.allbinary.game.input.NullPlayerGameInputComposite;
using PlayerGameInputCompositeInterface = org.allbinary.game.input.PlayerGameInputCompositeInterface;
using ItemColorFactory = org.allbinary.graphics.ItemColorFactory;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using AllBinaryLayerManager = org.allbinary.layer.AllBinaryLayerManager;
using LayerProcessor = org.allbinary.layer.LayerProcessor;
using NullUtil = org.allbinary.logic.NullUtil;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.layer;

public class AllBinaryGameLayerManager : AllBinaryLayerManager
{
    private static object NULL_ALLBINARY_LAYER_MANAGER = NullUtil.getInstance().NULL_OBJECT;
    public static AllBinaryGameLayerManager getNullInstance()
    {
        if (AllBinaryGameLayerManager.NULL_ALLBINARY_LAYER_MANAGER == NullUtil.getInstance().NULL_OBJECT) {
            AllBinaryGameLayerManager.NULL_ALLBINARY_LAYER_MANAGER = new AllBinaryGameLayerManager(BasicColorFactory.getInstance().BLACK, BasicColorFactory.getInstance().WHITE, GameInfo.NONE);
        }
        return ((AllBinaryGameLayerManager) AllBinaryGameLayerManager.NULL_ALLBINARY_LAYER_MANAGER);
    }

    public static readonly int? ID = SmallIntegerSingletonFactory.getInstance().getAt(22);
    private BasicColor backgroundBasicColor;
    private BasicColor foregroundBasicColor;
    private GameInfo gameInfo;
    private PlayerGameInputCompositeInterface playerGameInputCompositeInterface = NullPlayerGameInputComposite.NULL_PLAYER_GAME_INPUT_COMPOSITE;
    public AllBinaryGameLayerManager(BasicColor backgroundBasicColor, BasicColor foregroundBasicColor, GameInfo gameInfo)
    {
        this.backgroundBasicColor = backgroundBasicColor;
        this.foregroundBasicColor = foregroundBasicColor;
        ItemColorFactory itemColorFactory = ItemColorFactory.getInstance();
        itemColorFactory.INVERT_PAINT = ((int) this.backgroundBasicColor);
        itemColorFactory.PAINT = ((int) this.foregroundBasicColor);
        this.gameInfo = gameInfo;
    }

    public virtual AllBinaryLayerManager getLayerManager()
    {
        return this;
    }

    public virtual void init()
    {
    }

    public virtual BasicColor getBackgroundBasicColor()
    {
        return this.backgroundBasicColor;
    }

    public virtual void setBackgroundBasicColor(BasicColor backgroundBasicColor)
    {
        this.backgroundBasicColor = backgroundBasicColor;
        ItemColorFactory.getInstance().INVERT_PAINT = ((int) this.backgroundBasicColor);
    }

    public virtual BasicColor getForegroundBasicColor()
    {
        return this.foregroundBasicColor;
    }

    public virtual void setForegroundBasicColor(BasicColor foregroundBasicColor)
    {
        this.foregroundBasicColor = foregroundBasicColor;
        ItemColorFactory.getInstance().PAINT = ((int) this.foregroundBasicColor);
    }

    public virtual GameInfo getGameInfo()
    {
        return this.gameInfo;
    }

    public virtual void setGameInfo(GameInfo gameInfo)
    {
        this.gameInfo = gameInfo;
    }

    public virtual void setLayerProcessorList(BasicArrayList list)
    {
        LayerProcessor[] layerProcessorInterfaceArray = new LayerProcessor[list.size()];
        int size = layerProcessorInterfaceArray.Length;
        for (int index = 0; index < size; index++) {
            layerProcessorInterfaceArray[index] = ((LayerProcessor) list.objectArray[index]);
        }
        this.setLayerProcessorArray(layerProcessorInterfaceArray);
    }

    public virtual void setPlayerGameInputCompositeInterface(PlayerGameInputCompositeInterface playerGameInputCompositeInterface)
    {
        this.playerGameInputCompositeInterface = playerGameInputCompositeInterface;
    }

    public virtual PlayerGameInputCompositeInterface getPlayerGameInputCompositeInterface()
    {
        return this.playerGameInputCompositeInterface;
    }

}

