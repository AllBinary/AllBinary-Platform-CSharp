// Generated Code Do Not Modify

using System;
using System.Linq;
//using JsType = jsinterop.annotations.JsType;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonSeps = org.allbinary.@string.CommonSeps;
//using JsMethod = jsinterop.annotations.JsMethod;
//using JsConstructor = jsinterop.annotations.JsConstructor;
//using JsProperty = jsinterop.annotations.JsProperty;

namespace org.allbinary.util;

//This is a very fast and simple resizable list.
public class BasicArrayList
{
    private static readonly string SIZE = ", Size: ";
    private readonly ArrayUtil arrayUtil = ArrayUtil.getInstance();
    public object[] objectArray;
    private int currentIndex = 0;
    public BasicArrayList(object[] objectArray)
    {
        this.objectArray = objectArray;
    }

    public virtual void addAt(int index, object element)
    {
        if (index > this.currentIndex || index < 0) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(CommonLabels.getInstance().INDEX_LABEL);
            stringBuffer.appendint(index);
            stringBuffer.append(BasicArrayList.SIZE);
            stringBuffer.appendint(this.currentIndex);
            throw new IndexOutOfRangeException(stringBuffer.ToString());
        }
        this.ensureCapacity(this.currentIndex + 1);
        Array.Copy((Array) this.objectArray, index, (Array) this.objectArray, index + 1, this.currentIndex - index);
        this.objectArray[index] = element;
        this.currentIndex++;
    }

    public virtual bool add(object anyType)
    {
        this.ensureCapacity(this.currentIndex + 1);
        this.objectArray[this.currentIndex++] = anyType;
        return true;
    }

    public virtual object removeAt(int index)
    {
        if (index >= this.currentIndex) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(CommonLabels.getInstance().INDEX_LABEL);
            stringBuffer.appendint(index);
            stringBuffer.append(BasicArrayList.SIZE);
            stringBuffer.appendint(this.currentIndex);
            throw new IndexOutOfRangeException(stringBuffer.ToString());
        }
        object oldValue = this.objectArray[index];
        int numMoved = this.currentIndex - index - 1;
        if (numMoved > 0) {
            Array.Copy((Array) this.objectArray, index + 1, (Array) this.objectArray, index, numMoved);
        }
        this.objectArray[--this.currentIndex] = null;
        return oldValue;
    }

    public virtual bool remove(object anyType)
    {
        if (anyType == null) {
            for (int index = 0; index < this.currentIndex; index++) {
                if (this.objectArray[index] == null) {
                    int numMoved = this.currentIndex - index - 1;
                    if (numMoved > 0) {
                        Array.Copy((Array) this.objectArray, index + 1, (Array) this.objectArray, index, numMoved);
                    }
                    this.objectArray[--this.currentIndex] = null;
                    return true;
                }
            }
        } else {
            for (int index = 0; index < this.currentIndex; index++) {
                if (anyType == this.objectArray[index] || anyType.Equals(this.objectArray[index])) {
                    int numMoved = this.currentIndex - index - 1;
                    if (numMoved > 0) {
                        Array.Copy((Array) this.objectArray, index + 1, (Array) this.objectArray, index, numMoved);
                    }
                    this.objectArray[--this.currentIndex] = null;
                    return true;
                }
            }
        }
        return false;
    }

    public virtual bool removeAll2(BasicArrayList list)
    {
        bool result = true;
        int size = list.size();
        for (int index = 0; index < size; index++) {
            if (this.remove(list.get(index))) {
            } else {
                result = false;
            }
        }
        return result;
    }

    public virtual bool addAll2(BasicArrayList list)
    {
        this.ensureCapacity(this.currentIndex + list.currentIndex);
        int listSize = list.currentIndex;
        for (int index = 0; index < listSize; index++) {
            this.objectArray[this.currentIndex++] = list.objectArray[index];
        }
        return true;
    }

    public virtual bool addAllList(BasicArrayList list)
    {
        object[] newObjectArray = list.toArray();
        return this.addAll(newObjectArray);
    }

    public virtual bool addAll(object[] newObjectArray)
    {
        int numSize = newObjectArray.Length;
        this.ensureCapacity(this.currentIndex + numSize);
        Array.Copy((Array) newObjectArray, 0, (Array) this.objectArray, this.currentIndex, numSize);
        this.currentIndex += numSize;
        return numSize != 0;
    }

    public virtual void ensureCapacity(int minSize)
    {
        int oldCapacity = this.objectArray.Length;
        if (minSize > oldCapacity) {
            int newCapacity = ((oldCapacity * 3) >> 1) + 1;
            if (newCapacity < minSize) {
                newCapacity = minSize;
            }
            this.objectArray = this.arrayUtil.copyOf(this.objectArray, newCapacity);
        }
    }

    public virtual void trimToSize()
    {
        int oldCapacity = this.objectArray.Length;
        if (this.currentIndex < oldCapacity) {
            this.objectArray = this.arrayUtil.copyOf(this.objectArray, this.currentIndex);
        }
    }

    public virtual int indexOf(object anyType)
    {
        if (anyType == null) {
            for (int i = 0; i < this.currentIndex; i++) {
                if (this.objectArray[i] == null) {
                    return i;
                }
            }
        } else {
            for (int i = 0; i < this.currentIndex; i++) {
                if (anyType.Equals(this.objectArray[i])) {
                    return i;
                }
            }
        }
        return -1;
    }

    public virtual int lastIndexOf(object anyType)
    {
        if (anyType == null) {
            for (int i = this.currentIndex - 1; i >= 0; i--) {
                if (this.objectArray[i] == null) {
                    return i;
                }
            }
        } else {
            for (int i = this.currentIndex - 1; i >= 0; i--) {
                if (anyType.Equals(this.objectArray[i])) {
                    return i;
                }
            }
        }
        return -1;
    }

    public virtual object get(int index)
    {
        if (index >= this.currentIndex) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(CommonLabels.getInstance().INDEX_LABEL);
            stringBuffer.appendint(index);
            stringBuffer.append(BasicArrayList.SIZE);
            stringBuffer.appendint(this.currentIndex);
            throw new IndexOutOfRangeException(stringBuffer.ToString());
        }
        return this.objectArray[index];
    }

    public virtual object set(int index, object element)
    {
        if (index >= this.currentIndex) {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(CommonLabels.getInstance().INDEX_LABEL);
            stringBuffer.appendint(index);
            stringBuffer.append(BasicArrayList.SIZE);
            stringBuffer.appendint(this.currentIndex);
            throw new IndexOutOfRangeException(stringBuffer.ToString());
        }
        object oldValue = this.objectArray[index];
        this.objectArray[index] = element;
        return oldValue;
    }

    public virtual void clear()
    {
        for (int i = 0; i < this.currentIndex; i++) {
            this.objectArray[i] = null;
        }
        this.currentIndex = 0;
    }

    public virtual int size()
    {
        return this.currentIndex;
    }

    public virtual bool isEmpty()
    {
        return this.currentIndex == 0;
    }

    public virtual bool contains(object anyType)
    {
        return this.indexOf(anyType) >= 0;
    }

    public virtual object[] toArray()
    {
        return this.arrayUtil.copyOf(this.objectArray, this.currentIndex);
    }

    public virtual object[] toArrayType(object[] objectArray)
    {
        if (objectArray.Length < this.currentIndex) {
            return this.arrayUtil.copyOfType(this.objectArray, this.currentIndex, objectArray.GetType());
        }
        Array.Copy((Array) this.objectArray, 0, (Array) objectArray, 0, this.currentIndex);
        if (objectArray.Length > this.currentIndex) {
            objectArray[this.currentIndex] = null;
        }
        return objectArray;
    }

    public virtual object clone()
    {
        int size = this.size();
        BasicArrayList list = new BasicArrayListS(size);
        object anyType = null;
        for (int index = 0; index < size; index++) {
            anyType = this.objectArray[index];
            list.add(anyType);
        }
        return list;
    }

    public override string ToString()
    {
        string COMMA_SEP = CommonSeps.getInstance().COMMA_SEP;
        StringMaker stringBuffer = new StringMaker();
        for (int index = 0; index < this.currentIndex; index++) {
            stringBuffer.append(this.objectArray[index].ToString());
            stringBuffer.append(COMMA_SEP);
        }
        return stringBuffer.ToString();
    }

}

