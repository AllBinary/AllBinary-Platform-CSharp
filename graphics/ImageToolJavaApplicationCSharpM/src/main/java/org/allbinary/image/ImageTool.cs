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
using ARunnable = org.allbinary.thread.ARunnable;
using ImageToolJFrame = org.allbinary.image.gui.ImageToolJFrame;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.image;

public class ImageTool
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public ImageTool()
    {
    }

    public static void main(string[] args)
    {
        java.awt.EventQueue.invokeLater(new ARunnable()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void run()
            {
                LogUtil logUtil = LogUtil.getInstance();
                CommonStrings commonStrings = CommonStrings.getInstance();
                try {
                    logUtil.putF(commonStrings.START, this, commonStrings.RUN);
                    new ImageToolJFrame().setVisible(true);
                } catch (Exception e) {
                    logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
                }
            }

#endif
);
    }

}

