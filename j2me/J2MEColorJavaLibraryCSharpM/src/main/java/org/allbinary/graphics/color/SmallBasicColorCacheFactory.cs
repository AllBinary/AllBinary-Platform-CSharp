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
using StringUtil = org.allbinary.logic.@string.StringUtil;

namespace org.allbinary.graphics.color;

public class SmallBasicColorCacheFactory
{
    private static readonly SmallBasicColorCacheFactory instance = new SmallBasicColorCacheFactory();
    public static SmallBasicColorCacheFactory getInstance()
    {
        return SmallBasicColorCacheFactory.instance;
    }

    private readonly int SIZE = 255;
    private readonly int[] INDEX_TO_COLOR;
    private readonly BasicColor[] BASIC_COLOR_ARRAY;
    private int colorIndex = 0;
    private SmallBasicColorCacheFactory()
    {
        this.INDEX_TO_COLOR = new int[this.SIZE];
        this.BASIC_COLOR_ARRAY = new BasicColor[this.SIZE];
    }

    public virtual void add(BasicColor basicDefaultColor)
    {
        this.BASIC_COLOR_ARRAY[this.colorIndex] = basicDefaultColor;
        this.INDEX_TO_COLOR[this.colorIndex] = ((int) basicDefaultColor);
        this.colorIndex++;
    }

    public virtual BasicColor getAndOrCreate(int colorAsInt)
    {
        BasicColor basicColor = null;
        for (int index = 0; index < this.SIZE; index++) {
            if (this.INDEX_TO_COLOR[index] == colorAsInt) {
                return this.BASIC_COLOR_ARRAY[index];
            }
        }
        int ALPHA_MASK = 0xFF000000;
        basicColor = BasicColorFactory.getInstance().createInstanceAN(colorAsInt & ALPHA_MASK, colorAsInt & 0x00FFFFFF, StringUtil.getInstance().EMPTY_STRING);
        this.add(basicColor);
        return basicColor;
    }

}

