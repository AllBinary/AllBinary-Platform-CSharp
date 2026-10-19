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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.logic.util.cache;

public class KeylessBasicArrayListCache : IndexedBasicArrayListCache
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly BasicArrayListUtil basicArrayListUtil = BasicArrayListUtil.getInstance();
    public KeylessBasicArrayListCache()
    {
    }

    public virtual BasicArrayList get()
    {
        try {
            if (this.index >= this.list.size()) {
                this.addDefault();
            }
            BasicArrayList list = ((BasicArrayList) this.getAt(this.index++));
            return list;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.GET, e);
            return this.basicArrayListUtil.getImmutableInstance();
        }
    }

    public override void clear()
    {
        base.clear();
        BasicArrayList basicArrayList = null;
        for (int index = this.list.size() - 1; index >= 0; index--) {
            basicArrayList = (((BasicArrayList) this.list.objectArray[index]));
            basicArrayList.clear();
        }
    }

    public override string log()
    {
        StringMaker stringBuffer = new StringMaker();
        stringBuffer.append("S: ");
        stringBuffer.appendint(this.list.size());
        string S_LABEL = " s: ";
        BasicArrayList basicArrayList = null;
        for (int index = this.list.size() - 1; index >= 0; index--) {
            stringBuffer.append(S_LABEL);
            basicArrayList = (((BasicArrayList) this.list.objectArray[index]));
            stringBuffer.appendint(basicArrayList.size());
        }
        return stringBuffer.ToString();
    }

}

