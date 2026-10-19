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
using AllBinaryGameCanvas = org.allbinary.game.displayable.canvas.AllBinaryGameCanvas;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;

namespace org.allbinary.media.graphics.geography.map;

public class ColorFromEventUtil
{
    private static readonly ColorFromEventUtil instance = new ColorFromEventUtil();
    public static ColorFromEventUtil getInstance()
    {
        return ColorFromEventUtil.instance;
    }

    private readonly BasicColor YELLOW = BasicColorFactory.getInstance().YELLOW;
    public readonly int COLOR_INT;
    public virtual BasicColor getForegroundColor(AllBinaryGameCanvas gameCanvasInterface)
    {
        BasicColor color = this.YELLOW;
        GeographicMapCompositeInterface geographicMapCompositeInterface = ((GeographicMapCompositeInterface) gameCanvasInterface.getLayerManager());
        BasicGeographicMap geographicMapInterface = geographicMapCompositeInterface.getGeographicMapInterface()[0];
        if (geographicMapInterface != null) {
            BasicColor foregroundBasicColor = geographicMapInterface.getForegroundBasicColor();
            color = foregroundBasicColor;
        }
        return color;
    }

    public ColorFromEventUtil()
    {
        this.COLOR_INT = ((int) this.YELLOW);
    }

}

