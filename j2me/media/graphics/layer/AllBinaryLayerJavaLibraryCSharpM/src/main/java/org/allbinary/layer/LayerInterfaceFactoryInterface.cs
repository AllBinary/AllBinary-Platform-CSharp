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
using org.allbinary.util;

namespace org.allbinary.layer;

public interface LayerInterfaceFactoryInterface
{
    // throws Exception
    AllBinaryLayer getNextInstance(ABHashtable<object, object> hashtable, int x, int y, int z);

}

