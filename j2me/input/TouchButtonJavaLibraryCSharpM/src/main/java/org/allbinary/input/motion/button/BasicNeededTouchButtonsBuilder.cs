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
using Animation = org.allbinary.animation.Animation;
using NullAnimationFactory = org.allbinary.animation.NullAnimationFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.input.motion.button;

public class BasicNeededTouchButtonsBuilder : BaseTouchInput
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public override BasicArrayList getList()
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
            BasicArrayList list = new BasicArrayListD();
            TouchButtonLocationHelper touchButtonLocationHelper = new TouchButtonLocationHelper();
            BasicTouchButtonCellPositionFactory basicTouchButtonCellPositionFactory = new BasicTouchButtonCellPositionFactory();
            CommonButtons commonButtons = CommonButtons.getInstance();
            Animation animationInterface = NullAnimationFactory.getFactoryInstance().getInstance(0);
            TouchButton UP = new TouchButton(BasicTouchInputFactory.getInstance().UP, animationInterface, animationInterface, commonButtons.NORMAL_BUTTON, basicTouchButtonCellPositionFactory.SECOND_FROM_BOTTOM_LEFT, touchButtonLocationHelper.getColumnsRemainderHalf(), touchButtonLocationHelper.getRowsRemainderHalf());
            TouchButton DOWN = new TouchButton(BasicTouchInputFactory.getInstance().DOWN, animationInterface, animationInterface, commonButtons.NORMAL_BUTTON, basicTouchButtonCellPositionFactory.BOTTOM_LEFT, touchButtonLocationHelper.getColumnsRemainderHalf(), touchButtonLocationHelper.getRowsRemainderHalf());
            TouchButton LEFT = new TouchButton(BasicTouchInputFactory.getInstance().LEFT, animationInterface, animationInterface, commonButtons.NORMAL_BUTTON, basicTouchButtonCellPositionFactory.BOTTOM_SECOND_FROM_RIGHT, touchButtonLocationHelper.getColumnsRemainderHalf(), touchButtonLocationHelper.getRowsRemainderHalf());
            TouchButton RIGHT = new TouchButton(BasicTouchInputFactory.getInstance().RIGHT, animationInterface, animationInterface, commonButtons.NORMAL_BUTTON, basicTouchButtonCellPositionFactory.BOTTOM_RIGHT, touchButtonLocationHelper.getColumnsRemainderHalf(), touchButtonLocationHelper.getRowsRemainderHalf());
            list.add(UP);
            list.add(DOWN);
            list.add(LEFT);
            list.add(RIGHT);
            return list;
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, this.commonStrings.GET_LIST, e);
            return BasicArrayListUtil.getInstance().getImmutableInstance();
        }
    }

}

