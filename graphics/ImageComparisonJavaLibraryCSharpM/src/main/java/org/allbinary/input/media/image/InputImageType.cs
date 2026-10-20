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
using java.util;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StdUtil = org.allbinary.logic.StdUtil;

namespace org.allbinary.input.media.image;

public class InputImageType
{
    private static HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
    private static readonly BasicArrayList TYPE_VECTOR = new BasicArrayListD();
    public static InputImageType CAPTURE = new InputImageType("Capture", 0);
    public static InputImageType COMPARISON = new InputImageType("Comparison", 1);
    public static InputImageType MOTION = new InputImageType("Motion", 2);
    private readonly string name;
    private readonly int index;
    private InputImageType(string name, int index)
    {
        this.name = name;
        this.index = index;
        InputImageType.TYPE_VECTOR.add(this);
        InputImageType.hashMap.put(this.getName(), this);
    }

    public override string ToString()
    {
        return "ImageType: " + this.getName();
    }

    public virtual string getName()
    {
        return this.name;
    }

    public static InputImageType getInstance(string imageTypeString)
    {
        return ((InputImageType) InputImageType.hashMap.get(imageTypeString));
    }

    public static BasicArrayList getAllAsVector()
    {
        return InputImageType.TYPE_VECTOR;
    }

    public virtual int getIndex()
    {
        return this.index;
    }

}

