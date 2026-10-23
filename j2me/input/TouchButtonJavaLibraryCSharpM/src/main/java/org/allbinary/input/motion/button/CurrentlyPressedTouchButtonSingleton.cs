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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.input.motion.button;

public class CurrentlyPressedTouchButtonSingleton
{
    private static readonly CurrentlyPressedTouchButtonSingleton instance = new CurrentlyPressedTouchButtonSingleton();
    public static CurrentlyPressedTouchButtonSingleton getInstance()
    {
        return CurrentlyPressedTouchButtonSingleton.instance;
    }

    public readonly BasicArrayList list = new BasicArrayListD();
    public CurrentlyPressedTouchButtonSingleton()
    {
    }

    public virtual int size()
    {
        return this.list.size();
    }

    public virtual TouchButtonInput removeAt(int index)
    {
        return ((TouchButtonInput) this.list.removeAt(index));
    }

    public virtual bool remove(TouchButtonInput touchButtonInput)
    {
        return this.list.remove(touchButtonInput);
    }

    public virtual TouchButtonInput get(int index)
    {
        return ((TouchButtonInput) this.list.objectArray[index]);
    }

    public virtual bool contains(TouchButtonInput touchButtonInput)
    {
        return this.list.contains(touchButtonInput);
    }

    public virtual void add(TouchButtonInput touchButtonInput)
    {
        this.list.add(touchButtonInput);
    }

}

