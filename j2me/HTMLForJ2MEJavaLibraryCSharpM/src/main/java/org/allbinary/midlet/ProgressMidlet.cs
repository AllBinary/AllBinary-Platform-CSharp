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
using Processor = org.allbinary.canvas.Processor;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using ClientInformationFactory = org.allbinary.logic.system.security.licensing.ClientInformationFactory;
using PrimaryThreadPool = org.allbinary.thread.PrimaryThreadPool;
using ThreadPool = org.allbinary.thread.ThreadPool;

namespace org.allbinary.midlet;

public class ProgressMidlet : AllBinaryMidlet
{
    public readonly AbeClientInformationInterface abeClientInformation;
    public ProgressMidlet(ClientInformationFactory clientInformationFactory)
    {
        this.preInit();
        this.abeClientInformation = clientInformationFactory.getInstance();
    }

    public virtual void preInit()
    {
    }

    protected virtual void exitProgress(bool isProgress)
    {
        Processor processor = MidletExitProcessorFactory.getInstance().getExitInstance(this);
        try {
            ThreadPool primaryThreadPool = PrimaryThreadPool.getInstance();
            Runnable runnable = new ExitRunnable(this, processor, isProgress);
            primaryThreadPool.runTask(runnable);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "exit", e);
            try {
                processor.process();
            } catch (Exception e2) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "exit", e);
            }
        }
    }

}

