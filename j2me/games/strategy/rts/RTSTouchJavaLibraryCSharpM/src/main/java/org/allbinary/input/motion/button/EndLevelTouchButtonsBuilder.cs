/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2007 AllBinary 
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
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.input.motion.button;

public class EndLevelTouchButtonsBuilder : TouchButtonsListBuilder
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public override BasicArrayList getList()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
            BasicArrayList list = new BasicArrayListD();
            list.addAllList(new BasicTouchButtonsBuilder().getList());
            list.addAllList(new BuildingScrollTouchButtonsBuilder().getList());
            list.addAllList(new UpgradeDowngradeTouchButtonsBuilder().getList());
            this.addList(list);
            return list;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.CONSTRUCTOR, e);
            return BasicArrayListUtil.getInstance().getImmutableInstance();
        }
    }

}

