/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using GameAdStateFactory = org.allbinary.business.advertisement.GameAdStateFactory;
using GameAdState = org.allbinary.game.GameAdState;
using Features = org.allbinary.game.configuration.feature.Features;
using CurrentDisplayableFactory = org.allbinary.graphics.opengles.CurrentDisplayableFactory;
using OpenGLFeatureFactory = org.allbinary.graphics.opengles.OpenGLFeatureFactory;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;

namespace org.allbinary.game.displayable.canvas;

public class BaseGameBehavior : DemoGameBehavior
{
    private static readonly BaseGameBehavior instanceC = new BaseGameBehavior();
    public static DemoGameBehavior getInstance()
    {
        return BaseGameBehavior.instanceC;
    }

    // throws Exception
    public override void init()
    {
        GameAdState gameAdState = GameAdStateFactory.getInstance().getCurrentInstance();
        gameAdState.playingAdState();
    }

    public override void pause(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        Features features = Features.getInstance();
        if (features.isDefault(OpenGLFeatureFactory.getInstance().OPENGL_AS_GAME_THREAD)) {
            CurrentDisplayableFactory currentDisplayableFactory = CurrentDisplayableFactory.getInstance();
            currentDisplayableFactory.setRunnable(allBinaryGameCanvas.gamePauseRunnable);
        }
    }

    public override void unPause(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        if (Features.getInstance().isDefault(OpenGLFeatureFactory.getInstance().OPENGL_AS_GAME_THREAD)) {
            CurrentDisplayableFactory currentDisplayableFactory = CurrentDisplayableFactory.getInstance();
            currentDisplayableFactory.setRunnable(allBinaryGameCanvas.gameRunnable);
            currentDisplayableFactory.setDisplayable(allBinaryGameCanvas);
        }
    }

    // throws Exception
    public override void updateTouch(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        allBinaryGameCanvas.updateTouch2();
    }

    // throws Exception
    public override void updateScreenButtonPaintable(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        allBinaryGameCanvas.updateScreenButtonPaintable2();
    }

    // throws Exception
    public override void setGameState(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        allBinaryGameCanvas.updateGameState();
    }

    public override void removeAllGameKeyInputListeners(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        allBinaryGameCanvas.removeAllGameKeyInputListeners2();
    }

    // throws Exception
    public override void updateEndGameProcessor(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        allBinaryGameCanvas.updateEndGameProcessor2();
    }

    // throws Exception
    public override void buildGame(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        allBinaryGameCanvas.buildGame2();
    }

    // throws Exception
    public override void run(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        allBinaryGameCanvas.run2();
    }

    // throws Exception
    public override void setHighScore(AbeClientInformationInterface abeClientInformation, AllBinaryGameCanvas allBinaryGameCanvas, string name, long score, bool autoSubmit, bool isLast)
    {
        allBinaryGameCanvas.setHighScore2(abeClientInformation, name, score, autoSubmit, isLast);
    }

}

