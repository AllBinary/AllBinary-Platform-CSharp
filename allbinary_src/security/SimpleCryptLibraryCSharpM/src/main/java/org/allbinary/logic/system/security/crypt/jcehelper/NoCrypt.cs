/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2022 AllBinary 
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
using CryptInterface = org.allbinary.init.crypt.jcehelper.CryptInterface;

namespace org.allbinary.logic.system.security.crypt.jcehelper;

public class NoCrypt : CryptInterface
{
    public virtual sbyte[] encrypt(sbyte[] array)
    {
        return array;
    }

    public virtual sbyte[] decrypt(sbyte[] array)
    {
        return array;
    }

}

