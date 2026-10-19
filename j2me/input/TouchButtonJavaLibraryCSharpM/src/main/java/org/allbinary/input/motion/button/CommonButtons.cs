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

namespace org.allbinary.input.motion.button;

public class CommonButtons
{
    private static readonly CommonButtons instance = new CommonButtons();
    public static CommonButtons getInstance()
    {
        return CommonButtons.instance;
    }

    public readonly int STANDARD_BUTTON_SIZE;
    public readonly Rectangle NORMAL_BUTTON;
    public readonly Rectangle LARGE_BUTTON;
    private CommonButtons()
    {
        DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
        int commonButtonSize = 128;
        while (commonButtonSize > 64) {
            int totalColumns = displayInfo.getLastWidth() / commonButtonSize;
            int totalRows = displayInfo.getLastHeight() / commonButtonSize;
            int max = totalColumns;
            if (totalRows > max) {
                max = totalRows;
            }
            if (max > 9) {
                break;
            }
            commonButtonSize = commonButtonSize >> 1;
        }
        this.STANDARD_BUTTON_SIZE = commonButtonSize;
        this.NORMAL_BUTTON = new Rectangle(PointFactory.getInstance().ZERO_ZERO, this.STANDARD_BUTTON_SIZE, this.STANDARD_BUTTON_SIZE);
        this.LARGE_BUTTON = new Rectangle(PointFactory.getInstance().ZERO_ZERO, this.STANDARD_BUTTON_SIZE << 1, this.STANDARD_BUTTON_SIZE << 1);
    }

}

