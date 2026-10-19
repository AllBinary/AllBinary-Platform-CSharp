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
using HardwareComponentInterface = org.allbinary.logic.system.hardware.components.interfaces.HardwareComponentInterface;
using VideoInterface = org.allbinary.logic.system.hardware.components.interfaces.VideoInterface;

namespace org.allbinary.logic.system.hardware.components.linux;

public class Video : HardwareComponentInterface, VideoInterface
{
    private string data;
    public Video(string data)
    {
        this.data = data;
    }

    public virtual bool compareTo(HardwareComponentInterface componentInterface)
    {
        return true;
    }

    public override string ToString()
    {
        return this.data;
    }

}

