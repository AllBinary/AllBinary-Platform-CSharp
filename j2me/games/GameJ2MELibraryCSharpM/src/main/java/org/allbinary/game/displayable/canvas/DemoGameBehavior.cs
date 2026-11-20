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
using GameTypeFactory = org.allbinary.game.GameTypeFactory;
using NullPaintable = org.allbinary.graphics.paint.NullPaintable;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.displayable.canvas;

public class DemoGameBehavior
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly DemoGameBehavior instance = new DemoGameBehavior();
    public static DemoGameBehavior getInstance()
    {
        return DemoGameBehavior.instance;
    }

    // throws Exception
    public virtual void init()
    {
    }

    public virtual void pause(AllBinaryGameCanvas allBinaryGameCanvas)
    {
    }

    public virtual void unPause(AllBinaryGameCanvas allBinaryGameCanvas)
    {
    }

    // throws Exception
    public virtual void updateTouch(AllBinaryGameCanvas allBinaryGameCanvas)
    {
    }

    // throws Exception
    public virtual void updateScreenButtonPaintable(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        allBinaryGameCanvas.setTouchPaintableP(NullPaintable.getInstance());
    }

    // throws Exception
    public virtual void setGameState(AllBinaryGameCanvas allBinaryGameCanvas)
    {
    }

    public virtual void removeAllGameKeyInputListeners(AllBinaryGameCanvas allBinaryGameCanvas)
    {
    }

    // throws Exception
    public virtual void updateEndGameProcessor(AllBinaryGameCanvas allBinaryGameCanvas)
    {
    }

    // throws Exception
    public virtual void buildGame(AllBinaryGameCanvas allBinaryGameCanvas)
    {
    }

    // throws Exception
    public virtual void run(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        CommonStrings commonStrings = CommonStrings.getInstance();
        this.logUtil.putF(GameTypeFactory.getInstance().BOT.ToString(), this, commonStrings.RUN);
    }

    // throws Exception
    public virtual void setHighScore(AbeClientInformationInterface abeClientInformation, AllBinaryGameCanvas allBinaryGameCanvas, string name, long score, bool autoSubmit, bool isLast)
    {
    }

}

