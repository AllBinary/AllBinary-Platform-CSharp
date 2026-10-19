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
using org.allbinary.util;

namespace org.allbinary.logic.system.hardware;

public interface HardwareInterface
{
    HardwareComponentInterface getComponent(int index);

    string ToString();

    bool compareTo(HardwareInterface hardwareInterface);

    ABHashtable<object, object> difference(HardwareInterface hardwareInterface);

}

