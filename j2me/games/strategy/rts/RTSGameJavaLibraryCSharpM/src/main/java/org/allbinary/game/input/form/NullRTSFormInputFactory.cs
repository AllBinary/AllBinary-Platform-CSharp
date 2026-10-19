/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2003 AllBinary 
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
using BasicGroupFactory = org.allbinary.game.identification.BasicGroupFactory;

namespace org.allbinary.game.input.form;

public class NullRTSFormInputFactory
{
    private static readonly RTSFormInput SINGLETON = new RTSFormInput(BasicGroupFactory.getInstance().NONE_ARRAY);
    public static RTSFormInput getInstance()
    {
        return NullRTSFormInputFactory.SINGLETON;
    }

}

