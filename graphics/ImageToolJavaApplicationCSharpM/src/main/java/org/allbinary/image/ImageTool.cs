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
//using EventQueue = java.awt.EventQueue;

namespace org.allbinary.image;

public class ImageTool
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public ImageTool()
    {
    }

    public static void main(string[] args)
    {
        EventQueue.invokeLater(new __SwtClosure_N65811((__swtSelf_N65811) => {
                LogUtil logUtil = LogUtil.getInstance();
                CommonStrings commonStrings = CommonStrings.getInstance();
                try {
                    logUtil.putF(commonStrings.START, __swtSelf_N65811, commonStrings.RUN);
                    new ImageToolJFrame().setVisible(true);
                } catch (Exception e) {
                    logUtil.put(commonStrings.EXCEPTION, __swtSelf_N65811, commonStrings.RUN, e);
                }
            }));
    }

    private sealed class __SwtClosure_N65811 : ARunnable
    {
        private readonly global::System.Action<__SwtClosure_N65811> callback1;

        public __SwtClosure_N65811(global::System.Action<__SwtClosure_N65811> callback1)
        {
            this.callback1 = callback1;
        }

        public override void run() => callback1(this);
    }

}

