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

namespace javax.microedition.lcdui;

public class ChoiceGroupImageFactory
{
    private static readonly ChoiceGroupImageFactory instance = new ChoiceGroupImageFactory();
    public static ChoiceGroupImageFactory getInstance()
    {
        return ChoiceGroupImageFactory.instance;
    }

    private readonly sbyte[] multiOff = new sbyte[] { ((sbyte) (-119)), 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 10, 0, 0, 0, 11, 2, 3, 0, 0, 0, 59, 0, ((sbyte) (-12)), ((sbyte) (-117)), 0, 0, 0, 6, 80, 76, 84, 69, ((sbyte) (-1)), ((sbyte) (-1)), ((sbyte) (-1)), ((sbyte) (-69)), ((sbyte) (-69)), ((sbyte) (-69)), ((sbyte) (-57)), 75, ((sbyte) (-33)), ((sbyte) (-8)), 0, 0, 0, 30, 73, 68, 65, 84, 120, ((sbyte) (-38)), 99, 96, 96, 96, 96, 12, 101, ((sbyte) (-8)), ((sbyte) (-51)), ((sbyte) (-32)), ((sbyte) (-64)), 32, ((sbyte) (-64)), ((sbyte) (-60)), ((sbyte) (-64)), ((sbyte) (-64)), ((sbyte) (-128)), 11, 51, ((sbyte) (-122)), 50, ((sbyte) (-4)), 6, 0, 63, 116, 3, 1, 53, ((sbyte) (-108)), 39, ((sbyte) (-26)), 0, 0, 0, 0, 73, 69, 78, 68, ((sbyte) (-82)), 66, 96, ((sbyte) (-126)) };
    private readonly sbyte[] multiOn = new sbyte[] { ((sbyte) (-119)), 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 10, 0, 0, 0, 11, 2, 3, 0, 0, 0, 59, 0, ((sbyte) (-12)), ((sbyte) (-117)), 0, 0, 0, 12, 80, 76, 84, 69, ((sbyte) (-1)), ((sbyte) (-1)), ((sbyte) (-1)), ((sbyte) (-69)), ((sbyte) (-69)), ((sbyte) (-69)), 106, 106, 106, 2, 2, 2, 106, ((sbyte) (-103)), 14, ((sbyte) (-47)), 0, 0, 0, 53, 73, 68, 65, 84, 120, ((sbyte) (-38)), 99, 96, 96, 124, ((sbyte) (-64)), ((sbyte) (-16)), ((sbyte) (-1)), ((sbyte) (-77)), 3, ((sbyte) (-45)), 65, ((sbyte) (-111)), 15, 76, 12, 108, 12, 76, 12, ((sbyte) (-4)), 12, 76, 12, 18, 12, 76, ((sbyte) (-68)), 127, 24, ((sbyte) (-104)), 126, 45, 96, 96, ((sbyte) (-7)), ((sbyte) (-11)), ((sbyte) (-109)), ((sbyte) (-127)), ((sbyte) (-23)), ((sbyte) (-65)), 3, 3, ((sbyte) (-29)), 127, ((sbyte) (-122)), ((sbyte) (-113)), 0, 5, 37, 12, ((sbyte) (-34)), 1, ((sbyte) (-99)), ((sbyte) (-83)), 100, 0, 0, 0, 0, 73, 69, 78, 68, ((sbyte) (-82)), 66, 96, ((sbyte) (-126)) };
    private readonly sbyte[] radioOff = new sbyte[] { ((sbyte) (-119)), 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 11, 0, 0, 0, 11, 2, 3, 0, 0, 0, ((sbyte) (-44)), ((sbyte) (-62)), ((sbyte) (-97)), ((sbyte) (-75)), 0, 0, 0, 9, 80, 76, 84, 69, ((sbyte) (-1)), ((sbyte) (-1)), ((sbyte) (-1)), ((sbyte) (-69)), ((sbyte) (-69)), ((sbyte) (-69)), 106, 106, 106, ((sbyte) (-44)), 13, ((sbyte) (-1)), ((sbyte) (-24)), 0, 0, 0, 42, 73, 68, 65, 84, 120, ((sbyte) (-38)), 99, 96, 90, ((sbyte) (-59)), ((sbyte) (-64)), 32, ((sbyte) (-63)), 48, ((sbyte) (-127)), 65, ((sbyte) (-127)), 65, ((sbyte) (-127)), 41, ((sbyte) (-127)), ((sbyte) (-31)), 5, 19, 3, 3, 3, 50, 102, 80, 96, 80, 96, ((sbyte) (-6)), ((sbyte) (-63)), 80, ((sbyte) (-64)), ((sbyte) (-64)), ((sbyte) (-76)), ((sbyte) (-118)), 1, 0, 113, 24, 5, 61, 73, ((sbyte) (-68)), ((sbyte) (-100)), 98, 0, 0, 0, 0, 73, 69, 78, 68, ((sbyte) (-82)), 66, 96, ((sbyte) (-126)) };
    private readonly sbyte[] radioOn = new sbyte[] { ((sbyte) (-119)), 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82, 0, 0, 0, 11, 0, 0, 0, 11, 2, 3, 0, 0, 0, ((sbyte) (-44)), ((sbyte) (-62)), ((sbyte) (-97)), ((sbyte) (-75)), 0, 0, 0, 12, 80, 76, 84, 69, ((sbyte) (-1)), ((sbyte) (-1)), ((sbyte) (-1)), ((sbyte) (-69)), ((sbyte) (-69)), ((sbyte) (-69)), 106, 106, 106, 2, 2, 2, 106, ((sbyte) (-103)), 14, ((sbyte) (-47)), 0, 0, 0, 50, 73, 68, 65, 84, 120, ((sbyte) (-38)), 5, ((sbyte) (-63)), 65, 13, 0, 32, 12, 4, ((sbyte) (-63)), ((sbyte) (-19)), ((sbyte) (-11)), ((sbyte) (-117)), 1, 18, 68, ((sbyte) (-100)), 10, 52, 19, 94, 72, 64, 17, 101, ((sbyte) (-122)), 44, ((sbyte) (-44)), ((sbyte) (-29)), 98, ((sbyte) (-52)), 89, 77, ((sbyte) (-102)), 40, 2, 85, ((sbyte) (-95)), ((sbyte) (-73)), ((sbyte) (-63)), ((sbyte) (-104)), ((sbyte) (-63)), 37, ((sbyte) (-117)), 15, ((sbyte) (-40)), 119, 10, 41, 78, 26, ((sbyte) (-79)), 59, 0, 0, 0, 0, 73, 69, 78, 68, ((sbyte) (-82)), 66, 96, ((sbyte) (-126)) };
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
        this.imgMultiOffO = Image.createImage(this.multiOff, 0, this.multiOff.Length);
        this.imgMultiOnO = Image.createImage(this.multiOn, 0, this.multiOn.Length);
        this.imgRadioOffO = Image.createImage(this.radioOff, 0, this.radioOff.Length);
        this.imgRadioOnO = Image.createImage(this.radioOn, 0, this.radioOn.Length);
        this.imgMultiOff = this.imgMultiOffO;
        this.imgMultiOn = this.imgMultiOnO;
        this.imgRadioOff = this.imgRadioOffO;
        this.imgRadioOn = this.imgRadioOnO;
        this.imageArray = new Image[] { this.imgMultiOff, this.imgMultiOn, this.imgRadioOff, this.imgRadioOn };
    }

}

