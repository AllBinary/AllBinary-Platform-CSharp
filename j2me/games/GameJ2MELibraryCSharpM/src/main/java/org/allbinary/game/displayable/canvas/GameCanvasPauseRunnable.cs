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
using AndroidUtil = org.allbinary.AndroidUtil;
using Features = org.allbinary.game.configuration.feature.Features;
using OpenGLFeatureFactory = org.allbinary.graphics.opengles.OpenGLFeatureFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.game.displayable.canvas;

public class GameCanvasPauseRunnable : GameRunnable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly AllBinaryGameCanvas allBinaryGameCanvas;
    public GameCanvasPauseRunnable(AllBinaryGameCanvas allBinaryGameCanvas)
    {
        this.allBinaryGameCanvas = allBinaryGameCanvas;
    }

    public override void run()
    {
    }

    // throws Exception
    public override void processLoopSleep()
    {
        try {
            Features features = Features.getInstance();
            bool isOpenGL = features.isDefault(OpenGLFeatureFactory.getInstance().OPENGL);
            if (isOpenGL) {
                this.allBinaryGameCanvas.processSleep();
            }
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
        }
    }

}

