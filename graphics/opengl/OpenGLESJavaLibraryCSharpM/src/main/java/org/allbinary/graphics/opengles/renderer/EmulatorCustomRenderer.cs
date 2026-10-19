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
//using EGLConfig = javax.microedition.khronos.egl.EGLConfig;
//using GL10 = javax.microedition.khronos.opengles.GL10;
using InitEmulatorFactory = org.allbinary.emulator.InitEmulatorFactory;
using CommonStrings = org.allbinary.@string.CommonStrings;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using PreLogUtil = org.allbinary.logic.communication.log.PreLogUtil;

namespace org.allbinary.graphics.opengles.renderer;

public class EmulatorCustomRenderer
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly RendererStrings renderStrings = RendererStrings.getInstance();
    public virtual void onSurfaceCreated(GL10 gl, EGLConfig eglConfig)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.renderStrings.ON_SURFACE_CREATED);
        InitEmulatorFactory initEmulatorFactory = InitEmulatorFactory.getInstance();
        if (!initEmulatorFactory.isInitEmulator()) {
            try {
                string WAIT_FOR_EMULATOR = "Waiting on Emulator Initialization";
                while (!initEmulatorFactory.isInitEmulator()) {
                    PreLogUtil.put(WAIT_FOR_EMULATOR, this, this.renderStrings.ON_SURFACE_CREATED);
                    System.Threading.Thread.Sleep((int) (180));
                }
            } catch (Exception e) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, this.renderStrings.ON_SURFACE_CREATED, e);
            }
        }
    }

}

