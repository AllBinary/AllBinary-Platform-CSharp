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

namespace org.allbinary.logic.system.loader;

public class NativeLibraryClassLoader : ClassLoader
{
    private string message = "This Class Loader Does Not Load Classes - Only For Loading and Unloading of Native Libraries";
    public NativeLibraryClassLoader(ClassLoader parent) : base(parent)
    {
        // base(parent) is called from the constructor declaration
    }

}

