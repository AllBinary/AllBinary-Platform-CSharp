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
using ARunnable = org.allbinary.thread.ARunnable;
//using Canvas = javax.microedition.lcdui.Canvas;
using Features = org.allbinary.game.configuration.feature.Features;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using OpenGLFeatureFactory = org.allbinary.graphics.opengles.OpenGLFeatureFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using NullRunnable = org.allbinary.thread.NullRunnable;

namespace org.allbinary.game.displayable;

public class AlwaysRepaintBehavior : RepaintBehavior
{
    private static readonly AlwaysRepaintBehavior instanceC = new AlwaysRepaintBehavior();
    public static AlwaysRepaintBehavior getInstance()
    {
        return AlwaysRepaintBehavior.instanceC;
    }

    private readonly string NAME = "AlwaysRepaintBehavior";
    public override void repaint(Canvas canvas)
    {
        Features features = Features.getInstance();
        OpenGLFeatureFactory openGLFeatureFactory = OpenGLFeatureFactory.getInstance();
        if (features.isFeature(openGLFeatureFactory.OPENGL)) {
            DisplayInfoSingleton.getInstance().process();
        } else {
            Thread thread = new Thread(new ARunnable()
#if JAVA_ANONYMOUS_CLASS_BODY
                public virtual void run()
                {
                    try {
                        canvas.repaint();
                        DisplayInfoSingleton.getInstance().process();
                    } catch (Exception e) {
                        CommonStrings commonStrings = CommonStrings.getInstance();
                        LogUtil logUtil = LogUtil.getInstance();
                        logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
                    }
                }

#endif
, this.NAME);
            thread.start();
        }
    }

    public override void onChangeRepaint(Canvas canvas)
    {
    }

}

