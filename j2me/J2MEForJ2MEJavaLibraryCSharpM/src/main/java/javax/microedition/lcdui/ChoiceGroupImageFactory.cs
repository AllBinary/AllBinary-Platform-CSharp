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
using MIDPUtil = org.allbinary.MIDPUtil;

namespace javax.microedition.lcdui;

public class ChoiceGroupImageFactory
{
    private static readonly ChoiceGroupImageFactory instance = new ChoiceGroupImageFactory();
    public static ChoiceGroupImageFactory getInstance()
    {
        return ChoiceGroupImageFactory.instance;
    }

    private readonly sbyte[] multiOff = new sbyte[] { unchecked(((sbyte) (-119))), 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 10, 0, 0, 0, 11, 2, 3, 0, 0, 0, 59, 0, unchecked(((sbyte) (-12))), unchecked(((sbyte) (-117))), 0, 0, 0, 6, 80, 76, 84, 69, unchecked(((sbyte) (-1))), unchecked(((sbyte) (-1))), unchecked(((sbyte) (-1))), unchecked(((sbyte) (-69))), unchecked(((sbyte) (-69))), unchecked(((sbyte) (-69))), unchecked(((sbyte) (-57))), 75, unchecked(((sbyte) (-33))), unchecked(((sbyte) (-8))), 0, 0, 0, 30, 73, 68, 65, 84, 120, unchecked(((sbyte) (-38))), 99, 96, 96, 96, 96, 12, 101, unchecked(((sbyte) (-8))), unchecked(((sbyte) (-51))), unchecked(((sbyte) (-32))), unchecked(((sbyte) (-64))), 32, unchecked(((sbyte) (-64))), unchecked(((sbyte) (-60))), unchecked(((sbyte) (-64))), unchecked(((sbyte) (-64))), unchecked(((sbyte) (-128))), 11, 51, unchecked(((sbyte) (-122))), 50, unchecked(((sbyte) (-4))), 6, 0, 63, 116, 3, 1, 53, unchecked(((sbyte) (-108))), 39, unchecked(((sbyte) (-26))), 0, 0, 0, 0, 73, 69, 78, 68, unchecked(((sbyte) (-82))), 66, 96, unchecked(((sbyte) (-126))) };
    private readonly sbyte[] multiOn = new sbyte[] { unchecked(((sbyte) (-119))), 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 10, 0, 0, 0, 11, 2, 3, 0, 0, 0, 59, 0, unchecked(((sbyte) (-12))), unchecked(((sbyte) (-117))), 0, 0, 0, 12, 80, 76, 84, 69, unchecked(((sbyte) (-1))), unchecked(((sbyte) (-1))), unchecked(((sbyte) (-1))), unchecked(((sbyte) (-69))), unchecked(((sbyte) (-69))), unchecked(((sbyte) (-69))), 106, 106, 106, 2, 2, 2, 106, unchecked(((sbyte) (-103))), 14, unchecked(((sbyte) (-47))), 0, 0, 0, 53, 73, 68, 65, 84, 120, unchecked(((sbyte) (-38))), 99, 96, 96, 124, unchecked(((sbyte) (-64))), unchecked(((sbyte) (-16))), unchecked(((sbyte) (-1))), unchecked(((sbyte) (-77))), 3, unchecked(((sbyte) (-45))), 65, unchecked(((sbyte) (-111))), 15, 76, 12, 108, 12, 76, 12, unchecked(((sbyte) (-4))), 12, 76, 12, 18, 12, 76, unchecked(((sbyte) (-68))), 127, 24, unchecked(((sbyte) (-104))), 126, 45, 96, 96, unchecked(((sbyte) (-7))), unchecked(((sbyte) (-11))), unchecked(((sbyte) (-109))), unchecked(((sbyte) (-127))), unchecked(((sbyte) (-23))), unchecked(((sbyte) (-65))), 3, 3, unchecked(((sbyte) (-29))), 127, unchecked(((sbyte) (-122))), unchecked(((sbyte) (-113))), 0, 5, 37, 12, unchecked(((sbyte) (-34))), 1, unchecked(((sbyte) (-99))), unchecked(((sbyte) (-83))), 100, 0, 0, 0, 0, 73, 69, 78, 68, unchecked(((sbyte) (-82))), 66, 96, unchecked(((sbyte) (-126))) };
    private readonly sbyte[] radioOff = new sbyte[] { unchecked(((sbyte) (-119))), 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 11, 0, 0, 0, 11, 2, 3, 0, 0, 0, unchecked(((sbyte) (-44))), unchecked(((sbyte) (-62))), unchecked(((sbyte) (-97))), unchecked(((sbyte) (-75))), 0, 0, 0, 9, 80, 76, 84, 69, unchecked(((sbyte) (-1))), unchecked(((sbyte) (-1))), unchecked(((sbyte) (-1))), unchecked(((sbyte) (-69))), unchecked(((sbyte) (-69))), unchecked(((sbyte) (-69))), 106, 106, 106, unchecked(((sbyte) (-44))), 13, unchecked(((sbyte) (-1))), unchecked(((sbyte) (-24))), 0, 0, 0, 42, 73, 68, 65, 84, 120, unchecked(((sbyte) (-38))), 99, 96, 90, unchecked(((sbyte) (-59))), unchecked(((sbyte) (-64))), 32, unchecked(((sbyte) (-63))), 48, unchecked(((sbyte) (-127))), 65, unchecked(((sbyte) (-127))), 65, unchecked(((sbyte) (-127))), 41, unchecked(((sbyte) (-127))), unchecked(((sbyte) (-31))), 5, 19, 3, 3, 3, 50, 102, 80, 96, 80, 96, unchecked(((sbyte) (-6))), unchecked(((sbyte) (-63))), 80, unchecked(((sbyte) (-64))), unchecked(((sbyte) (-64))), unchecked(((sbyte) (-76))), unchecked(((sbyte) (-118))), 1, 0, 113, 24, 5, 61, 73, unchecked(((sbyte) (-68))), unchecked(((sbyte) (-100))), 98, 0, 0, 0, 0, 73, 69, 78, 68, unchecked(((sbyte) (-82))), 66, 96, unchecked(((sbyte) (-126))) };
    private readonly sbyte[] radioOn = new sbyte[] { unchecked(((sbyte) (-119))), 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 11, 0, 0, 0, 11, 2, 3, 0, 0, 0, unchecked(((sbyte) (-44))), unchecked(((sbyte) (-62))), unchecked(((sbyte) (-97))), unchecked(((sbyte) (-75))), 0, 0, 0, 12, 80, 76, 84, 69, unchecked(((sbyte) (-1))), unchecked(((sbyte) (-1))), unchecked(((sbyte) (-1))), unchecked(((sbyte) (-69))), unchecked(((sbyte) (-69))), unchecked(((sbyte) (-69))), 106, 106, 106, 2, 2, 2, 106, unchecked(((sbyte) (-103))), 14, unchecked(((sbyte) (-47))), 0, 0, 0, 50, 73, 68, 65, 84, 120, unchecked(((sbyte) (-38))), 5, unchecked(((sbyte) (-63))), 65, 13, 0, 32, 12, 4, unchecked(((sbyte) (-63))), unchecked(((sbyte) (-19))), unchecked(((sbyte) (-11))), unchecked(((sbyte) (-117))), 1, 18, 68, unchecked(((sbyte) (-100))), 10, 52, 19, 94, 72, 64, 17, 101, unchecked(((sbyte) (-122))), 44, unchecked(((sbyte) (-44))), unchecked(((sbyte) (-29))), 98, unchecked(((sbyte) (-52))), 89, 77, unchecked(((sbyte) (-102))), 40, 2, 85, unchecked(((sbyte) (-95))), unchecked(((sbyte) (-73))), unchecked(((sbyte) (-63))), unchecked(((sbyte) (-104))), unchecked(((sbyte) (-63))), 37, unchecked(((sbyte) (-117))), 15, unchecked(((sbyte) (-40))), 119, 10, 41, 78, 26, unchecked(((sbyte) (-79))), 59, 0, 0, 0, 0, 73, 69, 78, 68, unchecked(((sbyte) (-82))), 66, 96, unchecked(((sbyte) (-126))) };
    private readonly MIDPUtil midpUtil = MIDPUtil.getInstance();
    private readonly Image imgMultiOffO;
    private readonly Image imgMultiOnO;
    private readonly Image imgRadioOffO;
    private readonly Image imgRadioOnO;
    public Image imgMultiOff;
    public Image imgMultiOn;
    public Image imgRadioOff;
    public Image imgRadioOn;
    private readonly Image[] imageArray;
    public virtual Image[] getImageArray()
    {
        return this.imageArray;
    }

    public virtual void init(Image[] imageArray)
    {
        this.imgMultiOff = imageArray[0];
        this.imageArray[0] = this.imgMultiOff;
        this.imgMultiOn = imageArray[1];
        this.imageArray[1] = this.imgMultiOn;
        this.imgRadioOff = imageArray[2];
        this.imageArray[2] = this.imgRadioOff;
        this.imgRadioOn = imageArray[3];
        this.imageArray[3] = this.imgRadioOn;
    }

    public ChoiceGroupImageFactory()
    {
        this.imgMultiOffO = this.midpUtil.createImageFromByteArray(this.multiOff, 0, this.multiOff.Length);
        this.imgMultiOnO = this.midpUtil.createImageFromByteArray(this.multiOn, 0, this.multiOn.Length);
        this.imgRadioOffO = this.midpUtil.createImageFromByteArray(this.radioOff, 0, this.radioOff.Length);
        this.imgRadioOnO = this.midpUtil.createImageFromByteArray(this.radioOn, 0, this.radioOn.Length);
        this.imgMultiOff = this.imgMultiOffO;
        this.imgMultiOn = this.imgMultiOnO;
        this.imgRadioOff = this.imgRadioOffO;
        this.imgRadioOn = this.imgRadioOnO;
        this.imageArray = new Image[] { this.imgMultiOff, this.imgMultiOn, this.imgRadioOff, this.imgRadioOn };
    }

}

