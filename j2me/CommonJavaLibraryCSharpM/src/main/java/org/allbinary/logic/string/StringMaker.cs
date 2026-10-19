// Generated Code Do Not Modify

using System;
using System.Linq;
//using JsType = jsinterop.annotations.JsType;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsConstructor = jsinterop.annotations.JsConstructor;

namespace org.allbinary.logic.@string;

public class StringMaker
{
    private char[] charArray;
    private int currentLength = 0;
    public StringMaker()
    {
        this.charArray = new char[20];
    }

    public virtual StringMaker append(string @string)
    {
        int stringLength = @string.Length;
        this.ensureCapacity(this.currentLength + stringLength);
        @string.CopyTo(0, this.charArray, this.currentLength, (stringLength) - (0));
        this.currentLength += stringLength;
        return this;
    }

    public virtual StringMaker appendchar(char c)
    {
        this.ensureCapacity(this.currentLength + 1);
        this.charArray[this.currentLength++] = c;
        return this;
    }

    public virtual StringMaker appendCharArray(char[] charArray, int start, int end)
    {
        this.ensureCapacity(this.currentLength + (end - start));
        for (int index = start; index < end; index++) {
            this.charArray[this.currentLength++] = charArray[index];
        }
        return this;
    }

    public virtual StringMaker appendbyte(sbyte b)
    {
        this.append((b).ToString());
        return this;
    }

    public virtual StringMaker appendshort(short b)
    {
        this.append((b).ToString());
        return this;
    }

    public virtual StringMaker appendint(int i)
    {
        this.append((i).ToString());
        return this;
    }

    public virtual StringMaker appendlong(long l)
    {
        this.append((l).ToString());
        return this;
    }

    public virtual StringMaker appendfloat(float f)
    {
        this.append((f).ToString());
        return this;
    }

    public virtual StringMaker appendboolean(bool @bool)
    {
        if (@bool) {
            this.ensureCapacity(this.currentLength + 4);
            this.charArray[this.currentLength++] = 't';
            this.charArray[this.currentLength++] = 'r';
            this.charArray[this.currentLength++] = 'u';
            this.charArray[this.currentLength++] = 'e';
        } else {
            this.ensureCapacity(this.currentLength + 5);
            this.charArray[this.currentLength++] = 'f';
            this.charArray[this.currentLength++] = 'a';
            this.charArray[this.currentLength++] = 'l';
            this.charArray[this.currentLength++] = 's';
            this.charArray[this.currentLength++] = 'e';
        }
        return this;
    }

    public virtual void ensureCapacity(int minSize)
    {
        int oldCapacity = this.charArray.Length;
        if (minSize > oldCapacity) {
            int newCapacity = oldCapacity * 3;
            if (newCapacity < minSize) {
                newCapacity = minSize;
            }
            char[] copy = new char[newCapacity];
            int min = this.min(this.charArray.Length, newCapacity);
            Array.Copy((Array) this.charArray, 0, (Array) copy, 0, min);
            this.charArray = copy;
        }
    }

    public virtual int min(int value, int value2)
    {
        return ((value <= value2) ? value : value2);
    }

    public virtual StringMaker delete(int start, int end)
    {
        this.currentLength -= (end - start);
        return this;
    }

    public virtual int length()
    {
        return this.currentLength;
    }

    public override string ToString()
    {
        return new string(this.charArray, 0, this.currentLength);
    }

}

