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
using PointFactory = org.allbinary.graphics.PointFactory;
using Rectangle = org.allbinary.graphics.Rectangle;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.game.displayable.canvas;

public class FormUtil
{
    private static readonly FormUtil instance = new FormUtil();
    public static FormUtil getInstance()
    {
        return FormUtil.instance;
    }

    public virtual Rectangle createFormRectangle()
    {
        DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
        PointFactory pointFactory = PointFactory.getInstance();
        Rectangle rectangle = new Rectangle(pointFactory.createXY(30, 10), displayInfo.getLastWidth() - 30, displayInfo.getLastHeight() - 35);
        return rectangle;
    }

}

