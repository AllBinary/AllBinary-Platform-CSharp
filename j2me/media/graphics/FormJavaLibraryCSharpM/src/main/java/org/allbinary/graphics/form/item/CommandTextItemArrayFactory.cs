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
//using Command = javax.microedition.lcdui.Command;
//using ImageItem = javax.microedition.lcdui.ImageItem;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using DisplayInfoSingleton = org.allbinary.graphics.displayable.DisplayInfoSingleton;
using ScreenInfo = org.allbinary.graphics.form.ScreenInfo;
using VectorUtil = org.allbinary.logic.VectorUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using Visitor = org.allbinary.logic.util.visitor.Visitor;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.graphics.form.item;

public class CommandTextItemArrayFactory
{
    private readonly BasicArrayList list = new BasicArrayListD();
    private readonly Visitor visitorInterface;
    public CommandTextItemArrayFactory(Visitor visitorInterface)
    {
        this.visitorInterface = visitorInterface;
    }

    public ABCustomItem[] getInstance(object vector, BasicColor backgroundBasicColor, BasicColor foregroundBasicColor)
    {
        VectorUtil vectorUtil = VectorUtil.getInstance();
        int size = vectorUtil.getSize(vector);
        this.list.clear();
        CommandTextItem textItem = null;
        int priorityLimit = 7;
        DisplayInfoSingleton displayInfo = DisplayInfoSingleton.getInstance();
        bool isLargeEnoughDisplayForBigMenu = (displayInfo.isPortrait() && displayInfo.getLastHeight() >= ScreenInfo.getInstance().MEDIUM_WIDTH) || (!displayInfo.isPortrait() && displayInfo.getLastWidth() >= ScreenInfo.getInstance().MEDIUM_WIDTH);
        if (!isLargeEnoughDisplayForBigMenu && size > 3) {
            priorityLimit = 3;
        }
        Command command = null;
        for (int index = 0; index < size; index++) {
            command = ((Command) vectorUtil.elementAt(vector, index));
            if (command.getPriority() < priorityLimit) {
                bool? aBoolean = ((bool?) this.visitorInterface.visit(command));
                if (aBoolean) {
                    textItem = new CommandTextItem(command, ImageItem.LAYOUT_DEFAULT, StringUtil.getInstance().EMPTY_STRING, backgroundBasicColor, foregroundBasicColor);
                    this.list.add(textItem);
                }
            }
        }
        ABCustomItem[] textItemArray = new ABCustomItem[this.list.size()];
        int size2 = textItemArray.Length;
        for (int index = 0; index < size2; index++) {
            textItemArray[index] = ((ABCustomItem) this.list.objectArray[index]);
        }
        return textItemArray;
    }

}

