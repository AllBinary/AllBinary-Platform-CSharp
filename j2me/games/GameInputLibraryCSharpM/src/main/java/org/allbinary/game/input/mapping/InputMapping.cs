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
using Input = org.allbinary.game.input.Input;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using StdUtil = org.allbinary.logic.StdUtil;
using org.allbinary.util;

namespace org.allbinary.game.input.mapping;

public class InputMapping
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly ABHashtable<object, object> hashtable = StdUtil.getInstance().createHashtable();
    private readonly BasicArrayList mappedList = new BasicArrayListD();
    protected InputMapping()
    {
    }

    public virtual int getTotalMapped()
    {
        return this.hashtable.size();
    }

    protected virtual bool isDefaultNew()
    {
        return false;
    }

    protected virtual InputToGameKeyMapping getDefault()
    {
        return InputToGameKeyMapping.getNullInstance();
    }

    protected virtual void removeAll()
    {
        this.hashtable.clear();
        this.mappedList.clear();
    }

    public virtual void remove(Input input, Input mappedToInput)
    {
        StringMaker stringBuffer = new StringMaker();
        StringUtil stringUtil = StringUtil.getInstance();
        stringBuffer.append(CommonLabels.getInstance().START_LABEL);
        stringBuffer.append(stringUtil.toString(input));
        stringBuffer.append(" == ");
        stringBuffer.append(stringUtil.toString(mappedToInput));
        this.logUtil.putF(stringBuffer.ToString(), this, "InputMapping::remove");
        BasicArrayList list = this.getMappedInput(input);
        if (list.contains(mappedToInput)) {
            list.remove(mappedToInput);
            this.mappedList.remove(mappedToInput);
            stringBuffer.delete(0, stringBuffer.length());
            stringBuffer.append("Removed: ");
            stringBuffer.append(stringUtil.toString(input));
            stringBuffer.append(" == ");
            stringBuffer.append(stringUtil.toString(mappedToInput));
            this.logUtil.putF(stringBuffer.ToString(), this, "InputMapping::remove");
        } else {
            stringBuffer.delete(0, stringBuffer.length());
            stringBuffer.append("Not Deleted: ");
            stringBuffer.append(stringUtil.toString(input));
            stringBuffer.append(" == ");
            stringBuffer.append(stringUtil.toString(mappedToInput));
            this.logUtil.putF(stringBuffer.ToString(), this, "InputMapping::remove");
        }
    }

    // throws Exception
    public virtual void addMapping(InputToGameKeyMapping inputToGameKeyMapping)
    {
        throw new Exception(this.commonStrings.NOT_IMPLEMENTED);
    }

    public virtual void add(Input input, Input mappedToInput)
    {
        BasicArrayList list = this.getMappedInput(input);
        if (!list.contains(mappedToInput)) {
            list.add(mappedToInput);
            this.mappedList.add(mappedToInput);
        }
    }

    public virtual bool isMapped(Input input)
    {
        return this.mappedList.contains(input);
    }

    public virtual BasicArrayList getMappedInput(Input id)
    {
        object mappingInputCanBeNullList = this.hashtable.get(id);
        if (mappingInputCanBeNullList == null) {
            BasicArrayList list = new BasicArrayListD();
            this.hashtable.put(id, list);
            return list;
        }
        return ((BasicArrayList) mappingInputCanBeNullList);
    }

    public virtual ABHashtable<object, object> getHashtable()
    {
        return this.hashtable;
    }

}

