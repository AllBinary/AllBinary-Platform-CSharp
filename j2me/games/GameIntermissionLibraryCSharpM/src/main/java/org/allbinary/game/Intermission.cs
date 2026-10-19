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
using TimeDelayHelper = org.allbinary.time.TimeDelayHelper;

namespace org.allbinary.game;

public class Intermission : IntermissionInterface
{
    private bool enabled = false;
    private readonly TimeDelayHelper timeElapsedHelper = new TimeDelayHelper(0);
    private IntermissionEnableListenerInterface intermissionEnableListener = NullIntermissionEnableListener.getInstance();
    public Intermission()
    {
    }

    public virtual void setListener(IntermissionEnableListenerInterface enableListener)
    {
        this.intermissionEnableListener = enableListener;
    }

    public virtual TimeDelayHelper getTimeDelayHelper()
    {
        return this.timeElapsedHelper;
    }

    public virtual void setEnabled(bool enabled)
    {
        this.enabled = enabled;
        if (this.isEnabled()) {
            this.getTimeDelayHelper().setStartTimeTNT();
        }
        this.intermissionEnableListener.notifyIntermission(enabled);
    }

    public virtual bool isEnabled()
    {
        return this.enabled;
    }

}

