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
using BasicColor = org.allbinary.graphics.color.BasicColor;
using GenericOperatingSystem = org.allbinary.logic.system.os.GenericOperatingSystem;
using OperatingSystemFactory = org.allbinary.logic.system.os.OperatingSystemFactory;

namespace org.allbinary.game.paint;

public class ColorFillPaintableFactory
{
    private static readonly ColorFillPaintableFactory instance = new ColorFillPaintableFactory();
    public static ColorFillPaintableFactory getInstance()
    {
        return ColorFillPaintableFactory.instance;
    }

    public virtual ColorFillBasePaintable getInstance(BasicColor basicColor, bool forThreedCanvas)
    {
        GenericOperatingSystem operatingSystem = OperatingSystemFactory.getInstance().getOperatingSystemInstance();
        if (operatingSystem.isOverScan()) {
            return new OverScanColorFillPaintable(basicColor);
        } else {
            return new ColorFillPaintable(basicColor);
        }
    }

}

