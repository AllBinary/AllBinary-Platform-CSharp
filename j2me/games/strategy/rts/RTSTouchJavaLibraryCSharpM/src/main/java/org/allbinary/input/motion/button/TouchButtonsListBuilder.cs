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

namespace org.allbinary.input.motion.button;

public class TouchButtonsListBuilder : BaseTouchInput
{
    private readonly BasicArrayList baseTouchInputList = new BasicArrayListD();
    protected virtual void addList(BasicArrayList list)
    {
        int size = this.baseTouchInputList.size();
        BaseTouchInput baseTouchInput = null;
        for (int index = 0; index < size; index++) {
            baseTouchInput = ((BaseTouchInput) this.baseTouchInputList.get(index));
            list.addAllList(baseTouchInput.getList());
        }
    }

    public virtual void add(BaseTouchInput baseTouchInput)
    {
        this.baseTouchInputList.add(baseTouchInput);
    }

}

