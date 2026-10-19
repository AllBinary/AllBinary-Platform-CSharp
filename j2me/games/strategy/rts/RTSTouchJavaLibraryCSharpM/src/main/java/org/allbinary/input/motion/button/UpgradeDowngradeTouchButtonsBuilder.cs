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
using TouchButtonDowngradeResource = org.allbinary.game.input.resource.TouchButtonDowngradeResource;
using TouchButtonUpgradeResource = org.allbinary.game.input.resource.TouchButtonUpgradeResource;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CellPositionFactory = org.allbinary.graphics.CellPositionFactory;

namespace org.allbinary.input.motion.button;

public class UpgradeDowngradeTouchButtonsBuilder : BaseTouchInput
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public override BasicArrayList getList()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
            BasicArrayList list = new BasicArrayListD();
            TouchButtonLocationHelper touchButtonLocationHelper = new TouchButtonLocationHelper();
            CellPositionFactory cellPositionFactory = CellPositionFactory.getInstance();
            BasicTouchButtonCellPositionFactory basicTouchButtonCellPositionFactory = new BasicTouchButtonCellPositionFactory();
            if (basicTouchButtonCellPositionFactory.SECOND_FROM_TOP_LEFT != cellPositionFactory.NONE && basicTouchButtonCellPositionFactory.SECOND_FROM_TOP_RIGHT != cellPositionFactory.NONE) {
                CommonButtons commonButtons = CommonButtons.getInstance();
                TouchButton UP = TouchButton.createButton(BasicTouchInputFactory.getInstance().SPECIAL_BUTTON_TWO, TouchButtonUpgradeResource.getInstance(), commonButtons.NORMAL_BUTTON, basicTouchButtonCellPositionFactory.SECOND_FROM_TOP_LEFT, touchButtonLocationHelper.getColumnsRemainderHalf(), touchButtonLocationHelper.getRowsRemainderHalf());
                TouchButton DOWN = TouchButton.createButton(BasicTouchInputFactory.getInstance().SPECIAL_BUTTON_ONE, TouchButtonDowngradeResource.getInstance(), commonButtons.NORMAL_BUTTON, basicTouchButtonCellPositionFactory.SECOND_FROM_TOP_RIGHT, touchButtonLocationHelper.getColumnsRemainderHalf(), touchButtonLocationHelper.getRowsRemainderHalf());
                list.add(UP);
                list.add(DOWN);
            }
            return list;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.CONSTRUCTOR, e);
            return BasicArrayListUtil.getInstance().getImmutableInstance();
        }
    }

}

