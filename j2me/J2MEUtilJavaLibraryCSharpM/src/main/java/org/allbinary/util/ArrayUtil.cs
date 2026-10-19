// Generated Code Do Not Modify

using System;
using System.Linq;
//using JsType = jsinterop.annotations.JsType;
using MathUtil = org.allbinary.logic.math.MathUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonSeps = org.allbinary.@string.CommonSeps;
//using JsMethod = jsinterop.annotations.JsMethod;

namespace org.allbinary.util;

public class ArrayUtil
{
    private static readonly ArrayUtil instance = new ArrayUtil();
    public static ArrayUtil getInstance()
    {
        return ArrayUtil.instance;
    }

    private readonly MathUtil mathUtil = MathUtil.getInstance();
    public virtual object[] copyOf(object[] original, int newLength)
    {
        return this.copyOfType(original, newLength, original.GetType());
    }

    public virtual object[] copyOfType(object[] original, int newLength, Type newType)
    {
        object[] copy = new object[newLength];
        Array.Copy((Array) original, 0, (Array) copy, 0, this.mathUtil.min(original.Length, newLength));
        return copy;
    }

    public virtual sbyte[] copyOfbyte(sbyte[] original, int newLength)
    {
        sbyte[] copy = new sbyte[newLength];
        Array.Copy((Array) original, 0, (Array) copy, 0, this.mathUtil.min(original.Length, newLength));
        return copy;
    }

    public virtual short[] copyOfshort(short[] original, int newLength)
    {
        short[] copy = new short[newLength];
        Array.Copy((Array) original, 0, (Array) copy, 0, this.mathUtil.min(original.Length, newLength));
        return copy;
    }

    public virtual int[] copyOfint(int[] original, int newLength)
    {
        int[] copy = new int[newLength];
        Array.Copy((Array) original, 0, (Array) copy, 0, this.mathUtil.min(original.Length, newLength));
        return copy;
    }

    public virtual long[] copyOflong(long[] original, int newLength)
    {
        long[] copy = new long[newLength];
        Array.Copy((Array) original, 0, (Array) copy, 0, this.mathUtil.min(original.Length, newLength));
        return copy;
    }

    public virtual char[] copyOfchar(char[] original, int newLength)
    {
        char[] copy = new char[newLength];
        Array.Copy((Array) original, 0, (Array) copy, 0, this.mathUtil.min(original.Length, newLength));
        return copy;
    }

    public virtual float[] copyOffloat(float[] original, int newLength)
    {
        float[] copy = new float[newLength];
        Array.Copy((Array) original, 0, (Array) copy, 0, this.mathUtil.min(original.Length, newLength));
        return copy;
    }

    public virtual double[] copyOfdouble(double[] original, int newLength)
    {
        double[] copy = new double[newLength];
        Array.Copy((Array) original, 0, (Array) copy, 0, this.mathUtil.min(original.Length, newLength));
        return copy;
    }

    public virtual bool[] copyOfboolean(bool[] original, int newLength)
    {
        bool[] copy = new bool[newLength];
        Array.Copy((Array) original, 0, (Array) copy, 0, this.mathUtil.min(original.Length, newLength));
        return copy;
    }

    public virtual void reverse(int[] intArray)
    {
        int length = intArray.Length - 1;
        int temp = 0;
        int size = length / 2;
        for (int index = 0; index <= size; index++) {
            temp = intArray[index];
            intArray[index] = intArray[length - index];
            intArray[length - index] = temp;
        }
    }

    public virtual void flip(int[] intArray, int width, int height)
    {
        int length = height - 1;
        int temp = 0;
        int index = 0;
        int rowIndex = 0;
        for (int y = 0; y <= length / 2; y++) {
            for (int x = 0; x < width; x++) {
                rowIndex = ((length - y) * width);
                index = x + (y * width);
                temp = intArray[index];
                intArray[index] = intArray[rowIndex + x];
                intArray[rowIndex + x] = temp;
            }
        }
    }

    public virtual string toStringFromTwoDimensionaArray(int[][] twoDimensionalIntArray)
    {
        StringMaker stringBuffer = new StringMaker();
        CommonSeps commonSeps = CommonSeps.getInstance();
        int endIndex = twoDimensionalIntArray.Length;
        int endIndex2 = twoDimensionalIntArray[0].Length;
        for (int index = 0; index < endIndex; index++) {
            stringBuffer.append(commonSeps.BRACE_OPEN);
            for (int index2 = 0; index2 < endIndex2; index2++) {
                stringBuffer.appendint(((int) twoDimensionalIntArray[index][index2]));
                stringBuffer.append(commonSeps.COMMA_SEP);
            }
            stringBuffer.append(commonSeps.BRACE_CLOSE);
            stringBuffer.append(commonSeps.NEW_LINE);
        }
        return stringBuffer.ToString();
    }

    public virtual string toStringFromObjectArray(object[] objectArray)
    {
        StringMaker stringBuffer = new StringMaker();
        CommonSeps commonSeps = CommonSeps.getInstance();
        for (int index = 0; index < objectArray.Length; index++) {
            stringBuffer.append(StringUtil.getInstance().toString(objectArray[index]));
            stringBuffer.append(commonSeps.COMMA_SEP);
        }
        return stringBuffer.ToString();
    }

    public virtual string toStringFromByteArray(sbyte[] byteArray)
    {
        StringMaker stringBuffer = new StringMaker();
        CommonSeps commonSeps = CommonSeps.getInstance();
        for (int index = 0; index < byteArray.Length; index++) {
            stringBuffer.appendbyte(byteArray[index]);
            stringBuffer.append(commonSeps.COMMA_SEP);
        }
        return stringBuffer.ToString();
    }

}

