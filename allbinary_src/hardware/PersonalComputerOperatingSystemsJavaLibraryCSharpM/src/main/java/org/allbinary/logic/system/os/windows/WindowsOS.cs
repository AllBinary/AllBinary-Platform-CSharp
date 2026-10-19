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
using GenericOperatingSystem = org.allbinary.logic.system.os.GenericOperatingSystem;

namespace org.allbinary.logic.system.os.windows;

public class WindowsOS : GenericOperatingSystem
{
    public WindowsOS()
    {
        this.scalable = true;
    }

    public override bool isAutoHide()
    {
        return true;
    }

}

