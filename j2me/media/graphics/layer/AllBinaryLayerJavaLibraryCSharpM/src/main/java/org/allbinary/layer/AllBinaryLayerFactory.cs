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
using Rectangle = org.allbinary.graphics.Rectangle;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using ViewPosition = org.allbinary.view.ViewPosition;

namespace org.allbinary.layer;

public class AllBinaryLayerFactory : AllBinaryLayerFactoryInterface
{
    private readonly Rectangle rectangle;
    public AllBinaryLayerFactory(Rectangle rectangle)
    {
        this.rectangle = rectangle;
    }

    public virtual AllBinaryLayer getInstance()
    {
        return new AllBinaryLayer(StringUtil.getInstance().EMPTY_STRING, this.rectangle, ViewPosition.getInstanceD());
    }

}

