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
//using Random = java.util.Random;
//using JsType = jsinterop.annotations.JsType;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsConstructor = jsinterop.annotations.JsConstructor;
using MathUtil = org.allbinary.logic.math.MathUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;

namespace org.allbinary.game.rand;

//Do not use in client code for money related things.
public class MyRandomFactory
{
    private static readonly MyRandomFactory instance = new MyRandomFactory();
    public static MyRandomFactory getInstance()
    {
        return MyRandomFactory.instance;
    }

    private readonly MathUtil mathUtil = MathUtil.getInstance();
    private Random rand;
    private MyRandomFactory()
    {
        this.rand = new Random(DateTimeOffset.Now.ToUnixTimeMilliseconds());
    }

    public virtual void setSeed(long seed)
    {
        this.rand = new Random(seed);
    }

    public virtual int getNextInt(int range)
    {
        int div = (Integer.MAX_VALUE / range) + 1;
        return ((int) (this.rand.nextInt() / div));
    }

    public virtual int getAbsoluteNextInt(int range)
    {
        return this.mathUtil.abs(this.getNextInt(range));
    }

    public virtual int getAbsoluteNextIntAllowZero(int range)
    {
        if (range == 0) {
            return 0;
        } else {
            return this.mathUtil.abs(this.getNextInt(range));
        }
    }

    public virtual void shuffle(int[] intArray)
    {
        this.shuffleTotal(intArray, intArray.Length * 7);
    }

    public virtual void shuffleTotal(int[] intArray, int shuffleTotal)
    {
        int size = intArray.Length;
        int randomIndex = 0;
        int randomIndex2 = 0;
        int value = 0;
        for (int index = 0; index < shuffleTotal; index++) {
            randomIndex = this.getAbsoluteNextIntAllowZero(size);
            randomIndex2 = this.getAbsoluteNextIntAllowZero(size);
            value = intArray[randomIndex];
            intArray[randomIndex] = intArray[randomIndex2];
            intArray[randomIndex2] = value;
        }
    }

    public virtual void shuffle2(int[] intArray, int[] intArray2)
    {
        this.shuffle2Total(intArray, intArray2, intArray.Length * 7);
    }

    public virtual void shuffle2Total(int[] intArray, int[] intArray2, int shuffleTotal)
    {
        int size = intArray.Length;
        int randomIndex = 0;
        int randomIndex2 = 0;
        int value = 0;
        int value2 = 0;
        for (int index = 0; index < shuffleTotal; index++) {
            randomIndex = this.getAbsoluteNextIntAllowZero(size);
            randomIndex2 = this.getAbsoluteNextIntAllowZero(size);
            value = intArray[randomIndex];
            value2 = intArray2[randomIndex];
            intArray[randomIndex] = intArray[randomIndex2];
            intArray[randomIndex2] = value;
            intArray2[randomIndex] = intArray2[randomIndex2];
            intArray2[randomIndex2] = value2;
        }
    }

    public static void main(string[] args)
    {
        MyRandomFactory randomFactory = MyRandomFactory.getInstance();
        StringMaker stringBuilder = new StringMaker();
        CommonSeps commonSeps = CommonSeps.getInstance();
        int size2 = 100;
        for (int index = 0; index < size2; index++) {
            stringBuilder.appendint(((int) randomFactory.getAbsoluteNextInt(3))).append(commonSeps.COMMA);
        }
        Console.WriteLine(stringBuilder.ToString());
        stringBuilder.delete(0, stringBuilder.length());
        int[] intArray = new int[52];
        int[] intArray2 = new int[52];
        int size = intArray.Length;
        for (int index = 0; index < size; index++) {
            intArray[index] = index;
            intArray2[index] = index;
        }
        randomFactory.shuffle2(intArray, intArray2);
        for (int index = 0; index < size; index++) {
            stringBuilder.appendint(intArray[index]).append(commonSeps.COMMA);
        }
        Console.WriteLine(stringBuilder.ToString());
        stringBuilder.delete(0, stringBuilder.length());
        for (int index = 0; index < size; index++) {
            stringBuilder.appendint(intArray2[index]).append(commonSeps.COMMA);
        }
        Console.WriteLine(stringBuilder.ToString());
        bool found = false;
        for (int index = 0; index < size; index++) {
            found = false;
            for (int index2 = 0; index2 < size; index2++) {
                if (intArray[index2] == index) {
                    found = true;
                }
            }
            if (!found) {
                throw new SystemException();
            }
        }
    }

}

