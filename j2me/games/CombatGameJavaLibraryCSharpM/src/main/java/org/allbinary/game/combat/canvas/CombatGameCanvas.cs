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
//using CommandListener = javax.microedition.lcdui.CommandListener;
using DestroyedLayerProcessor = org.allbinary.game.combat.destroy.DestroyedLayerProcessor;
using DestroyEventCircularStaticPool = org.allbinary.game.combat.destroy.@event.DestroyEventCircularStaticPool;
using DestroyedEventHandler = org.allbinary.game.combat.destroy.@event.DestroyedEventHandler;
using Features = org.allbinary.game.configuration.feature.Features;
using GameFeatureFactory = org.allbinary.game.configuration.feature.GameFeatureFactory;
using AllBinaryGameCanvas = org.allbinary.game.displayable.canvas.AllBinaryGameCanvas;
using BasicBuildGameInitializerFactory = org.allbinary.game.init.BasicBuildGameInitializerFactory;
using AllBinaryGameLayerManager = org.allbinary.game.layer.AllBinaryGameLayerManager;
using DropLayerProcessor = org.allbinary.game.layer.drop.DropLayerProcessor;
using GroupLayerManagerListener = org.allbinary.game.layer.identification.GroupLayerManagerListener;
using HighScoresFactoryInterface = org.allbinary.game.score.HighScoresFactoryInterface;
using ProgressCanvasFactory = org.allbinary.graphics.canvas.transition.progress.ProgressCanvasFactory;
using BasicLayerProcessor = org.allbinary.layer.BasicLayerProcessor;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;

namespace org.allbinary.game.combat.canvas;

public class CombatGameCanvas : AllBinaryGameCanvas
{
    public static BasicLayerProcessor[] basicLayerProcessor = new BasicLayerProcessor[0];
    public CombatGameCanvas(CommandListener cmdListener, AllBinaryGameLayerManager gameLayerManager, HighScoresFactoryInterface highScoresFactoryInterface, BasicBuildGameInitializerFactory gameInitializationInterfaceFactoryInterface, bool buffered) : base(cmdListener, gameLayerManager, highScoresFactoryInterface, gameInitializationInterfaceFactoryInterface, buffered)
    {
        // base(cmdListener, gameLayerManager, highScoresFactoryInterface, gameInitializationInterfaceFactoryInterface, buffered) is called from the constructor declaration
    }

    private void CombatGameCanvas_init()
    {
        DestroyEventCircularStaticPool.getInstance().init(this);
        ProgressCanvasFactory.getInstance().addNormalPortion(50, "Destroy Events");
    }

    // throws Exception
    protected override void initApp(AbeClientInformationInterface abeClientInformation)
    {
        this.CombatGameCanvas_init();
        base.initApp(abeClientInformation);
    }

    protected virtual void initConfigurablePortion(int portion)
    {
        DestroyedLayerProcessor.init();
        ProgressCanvasFactory.getInstance().addNormalPortion(portion, "Basic Processors");
        Features features = Features.getInstance();
        GameFeatureFactory gameFeatureFactory = GameFeatureFactory.getInstance();
        if (features.isFeature(gameFeatureFactory.DROPPED_ITEMS) && features.isFeature(gameFeatureFactory.DROPPED_ITEMS_FROM_DEATH)) {
            CombatGameCanvas.basicLayerProcessor = new BasicLayerProcessor[2];
            CombatGameCanvas.basicLayerProcessor[0] = DestroyedLayerProcessor.getInstance();
            CombatGameCanvas.basicLayerProcessor[1] = DropLayerProcessor.getInstance();
        } else {
            CombatGameCanvas.basicLayerProcessor = new BasicLayerProcessor[1];
            CombatGameCanvas.basicLayerProcessor[0] = DestroyedLayerProcessor.getInstance();
        }
    }

    // throws Exception
    protected override void processPlayingGame()
    {
        base.processPlayingGame();
        for (int index = CombatGameCanvas.basicLayerProcessor.Length; --index >= 0; ) {
            CombatGameCanvas.basicLayerProcessor[index].process(this.gameLayerManager);
        }
    }

    // throws Exception
    protected override void cleanupGame()
    {
        base.cleanupGame();
        for (int index = CombatGameCanvas.basicLayerProcessor.Length; --index >= 0; ) {
            CombatGameCanvas.basicLayerProcessor[index].getList().clear();
        }
        GroupLayerManagerListener.getInstance().clear();
        GroupLayerManagerListener.getInstance().log();
        DestroyedEventHandler.getInstance().removeAllListeners();
        this.cleanupManager();
    }

    // throws Exception
    protected virtual void cleanupManager()
    {
        this.gameLayerManager.cleanup();
    }

}

