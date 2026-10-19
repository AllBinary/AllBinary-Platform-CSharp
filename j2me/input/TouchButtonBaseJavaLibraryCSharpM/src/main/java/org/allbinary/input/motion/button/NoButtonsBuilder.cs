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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.input.motion.button;

public class NoButtonsBuilder : BaseTouchInput
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public override BasicArrayList getList()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
            BasicArrayList list = BasicArrayListUtil.getInstance().getImmutableInstance();
            return list;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.GET_LIST, e);
            return BasicArrayListUtil.getInstance().getImmutableInstance();
        }
    }

}

