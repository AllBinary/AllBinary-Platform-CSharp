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
//using JsType = jsinterop.annotations.JsType;
using MyRandomFactory = org.allbinary.game.rand.MyRandomFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsProperty = jsinterop.annotations.JsProperty;

namespace org.allbinary.util;

public class BasicArrayListUtil
{
    private static readonly BasicArrayListUtil instance = new BasicArrayListUtil();
    public static BasicArrayListUtil getInstance()
    {
        return BasicArrayListUtil.instance;
    }

    public readonly BasicArrayList[][] NULL_ARRAY_OF_ARRAY = System.Linq.Enumerable.Range(0, 0).Select(_ => new BasicArrayList[0]).ToArray();
    private readonly MyRandomFactory myRandomFactory = MyRandomFactory.getInstance();
    private readonly BasicArrayList immutableInstance = new ImmutableBasicArrayList("Immutable", 0);
    public virtual object getRandom(BasicArrayList list)
    {
        int i_random = this.getRandomIndex(list);
        return list.objectArray[i_random];
    }

    public virtual int getRandomIndex(BasicArrayList list)
    {
        return this.myRandomFactory.getAbsoluteNextInt(list.size());
    }

    public virtual void reverse(BasicArrayList list)
    {
        int lastMinusOneIndex = list.size() - 2;
        object temp = null;
        int size = lastMinusOneIndex / 2;
        int secondSwapIndex = 0;
        for (int index = 0; index <= size; index++) {
            secondSwapIndex = lastMinusOneIndex - index;
            temp = list.removeAt(index);
            list.addAt(index, list.removeAt(secondSwapIndex));
            list.addAt(secondSwapIndex + 1, temp);
        }
    }

    public virtual string log(BasicArrayList list)
    {
        string S_LABEL = " s: ";
        int size = list.size();
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append(CommonLabels.getInstance().TOTAL_LABEL);
        stringBuffer.appendint(size);
        for (int index = size - 1; index >= 0; index--) {
            BasicArrayList usedList = ((BasicArrayList) list.objectArray[index]);
            stringBuffer.append(S_LABEL);
            stringBuffer.appendint(usedList.size());
        }
        return stringBuffer.ToString();
    }

    public virtual BasicArrayList getImmutableInstance()
    {
        return this.immutableInstance;
    }

    public static void main(string[] args)
    {
        CommonPhoneStrings commonPhoneStrings = CommonPhoneStrings.getInstance();
        BasicArrayList list = new BasicArrayListD();
        list.add(commonPhoneStrings.ONE);
        list.add(commonPhoneStrings.TWO);
        list.add(commonPhoneStrings.THREE);
        list.add(commonPhoneStrings.FOUR);
        list.add(commonPhoneStrings.FIVE);
        list.add(commonPhoneStrings.SIX);
        list.add(commonPhoneStrings.SEVEN);
        list.add(commonPhoneStrings.EIGHT);
        list.add(commonPhoneStrings.NINE);
        BasicArrayListUtil.getInstance().reverse(list);
        Console.WriteLine(list.ToString());
    }

}

