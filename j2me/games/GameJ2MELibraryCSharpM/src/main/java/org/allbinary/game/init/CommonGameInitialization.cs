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
using ResourceInitialization = org.allbinary.game.resource.ResourceInitialization;
using ResourceLoadingLevelFactory = org.allbinary.game.resource.ResourceLoadingLevelFactory;
using PointFactory = org.allbinary.graphics.PointFactory;
using ProgressCanvas = org.allbinary.graphics.canvas.transition.progress.ProgressCanvas;
using ProgressCanvasFactory = org.allbinary.graphics.canvas.transition.progress.ProgressCanvasFactory;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using AngleFactory = org.allbinary.math.AngleFactory;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.init;

public class CommonGameInitialization : BaseGameInitialization
{
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    protected CommonGameInitialization(ResourceInitialization[] resourceInitializationArray, int portion) : base(resourceInitializationArray, portion)
    {
        // base(resourceInitializationArray, portion) is called from the constructor declaration
    }

    // throws Exception
    public override void init(AbeClientInformationInterface abeClientInformation, CommandListener commandListener, int level)
    {
        base.init(abeClientInformation, commandListener, level);
        ResourceLoadingLevelFactory resourceLoadingLevelFactory = ResourceLoadingLevelFactory.getInstance();
        if (!this.isGameInitialized() && level == resourceLoadingLevelFactory.LOAD_ALL.getLevel()) {
            this.setGameInitialized(true);
            ProgressCanvas progressCanvas = ProgressCanvasFactory.getInstance();
            SmallIntegerSingletonFactory.getInstance().init();
            progressCanvas.addNormalPortion(50, "Integers");
            PointFactory.getInstance().init();
            progressCanvas.addNormalPortion(50, "Points");
            AngleFactory.getInstance();
            progressCanvas.addNormalPortion(50, "Angles");
            this.initGame();
            this.resourceInitializationArray[this.GAME_RESOURCES].init();
        }
        base.resourceInitialization(level);
    }

    // throws Exception
    public virtual void initGame()
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

}

