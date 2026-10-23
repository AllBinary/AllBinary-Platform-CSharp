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
//using Font = javax.microedition.lcdui.Font;
//using Graphics = javax.microedition.lcdui.Graphics;
using GameKey = org.allbinary.game.input.GameKey;
using GameKeyFactory = org.allbinary.game.input.GameKeyFactory;
using Input = org.allbinary.game.input.Input;
using PlatformInputMappingFactory = org.allbinary.game.input.PlatformInputMappingFactory;
using GameInputMapping = org.allbinary.game.input.mapping.GameInputMapping;
using PersistentInputMapping = org.allbinary.game.input.mapping.PersistentInputMapping;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using BasicColorUtil = org.allbinary.graphics.color.BasicColorUtil;
using NullUtil = org.allbinary.logic.NullUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonSeps = org.allbinary.@string.CommonSeps;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.paint.help;

public class InputMappingHelpPaintable : HelpPaintable
{
    private static readonly string AND = " and ";
    private static readonly string SEP = ", ";
    private static readonly string MORE_THAN_TWO_IN_LIST_AND = ", and ";
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public readonly CommonSeps commonSeps = CommonSeps.getInstance();
    public readonly StringUtil stringUtil = StringUtil.getInstance();
    private readonly BasicColorFactory basicColorFactory = BasicColorFactory.getInstance();
    private readonly GameKey NONE = GameKeyFactory.getInstance().NONE;
    private readonly string EMPTY_STRING = StringUtil.getInstance().EMPTY_STRING;
    private GameInputMapping[] gameInputMappingArray;
    private BasicArrayList[] keyMappingArray = new BasicArrayList[0];
    private BasicColor[] actionBasicColor = BasicColorUtil.getInstance().ZERO_ARRAY;
    private BasicColor[][] inputBasicColorArray = System.Linq.Enumerable.Range(0, 0).Select(_ => new BasicColor[0]).ToArray();
    private BasicColor selectedBasicColor = null;
    private class UpdateMyFontProperties
    {
        public string[] actionStringArray = StringUtil.getInstance().getArrayInstance();
        public int[] keymappingBeginWidthArray = NullUtil.getInstance().NULL_INT_ARRAY;
        public int[] actionStringDeltaXArray = NullUtil.getInstance().NULL_INT_ARRAY;
        public int[][] inputDeltaXArray = NullUtil.getInstance().NULL_INT_ARRAY_ARRAY;
        public string[][] sepArray = System.Linq.Enumerable.Range(0, 0).Select(_ => new string[0]).ToArray();
        public int[][] sepWidthArray = NullUtil.getInstance().NULL_INT_ARRAY_ARRAY;
        public int charHeight = 0;
    }
    private UpdateMyFontProperties updateMyFontProperties = new UpdateMyFontProperties();
    public InputMappingHelpPaintable(GameInputMapping[] gameInputMappingArray, BasicColor backgroundBasicColor, BasicColor basicColor) : base("Input Mapping", backgroundBasicColor, basicColor)
    {
        // base("Input Mapping", backgroundBasicColor, basicColor) is called from the constructor declaration
        this.gameInputMappingArray = gameInputMappingArray;
        this.update(this.NONE, this.NONE);
        if (backgroundBasicColor == this.basicColorFactory.WHITE || basicColor == this.basicColorFactory.WHITE) {
            this.selectedBasicColor = this.basicColorFactory.RED;
        } else {
            this.selectedBasicColor = this.basicColorFactory.WHITE;
        }
    }

    public override void updateMeasurement(Graphics graphics)
    {
        Font font = graphics.getFont();
        UpdateMyFontProperties updateMyFontProperties = new UpdateMyFontProperties();
        updateMyFontProperties.charHeight = font.getHeight();
        StringMaker stringMaker = new StringMaker();
        string[] inputInfo = this.inputInfo;
        int size = inputInfo.Length;
        updateMyFontProperties.actionStringArray = new string[size];
        updateMyFontProperties.keymappingBeginWidthArray = new int[size];
        updateMyFontProperties.actionStringDeltaXArray = new int[size];
        updateMyFontProperties.inputDeltaXArray = System.Linq.Enumerable.Range(0, size).Select(_ => new int[0]).ToArray();
        updateMyFontProperties.sepArray = System.Linq.Enumerable.Range(0, size).Select(_ => new string[0]).ToArray();
        updateMyFontProperties.sepWidthArray = System.Linq.Enumerable.Range(0, size).Select(_ => new int[0]).ToArray();
        BasicArrayList list = null;
        string keyMappings = null;
        string actionString = null;
        Input input = null;
        int size2 = 0;
        for (int index = 0; index < size; index++) {
            list = this.keyMappingArray[index];
            keyMappings = this.get(list);
            stringMaker.delete(0, stringMaker.length());
            actionString = stringMaker.append(inputInfo[index]).append(commonSeps.COLON).append(commonSeps.SPACE).append(commonSeps.SPACE).ToString();
            updateMyFontProperties.actionStringArray[index] = actionString;
            stringMaker.delete(0, stringMaker.length());
            updateMyFontProperties.keymappingBeginWidthArray[index] = (font.stringWidth(stringMaker.append(updateMyFontProperties.actionStringArray[index]).append(keyMappings).ToString()) >> 1);
            updateMyFontProperties.actionStringDeltaXArray[index] = font.stringWidth(actionString);
            size2 = list.size();
            updateMyFontProperties.inputDeltaXArray[index] = new int[size2];
            updateMyFontProperties.sepArray[index] = new string[size2];
            updateMyFontProperties.sepWidthArray[index] = new int[size2];
            for (int index2 = 0; index2 < size2; index2++) {
                input = ((Input) list.objectArray[index2]);
                updateMyFontProperties.inputDeltaXArray[index][index2] = font.stringWidth(input.getName());
                updateMyFontProperties.sepArray[index][index2] = EMPTY_STRING;
                if (index2 + 1 < list.size()) {
                    if (list.size() == 2) {
                        updateMyFontProperties.sepArray[index][index2] = InputMappingHelpPaintable.AND;
                    } else {
                        if (index2 + 2 == list.size()) {
                            updateMyFontProperties.sepArray[index][index2] = InputMappingHelpPaintable.MORE_THAN_TWO_IN_LIST_AND;
                        } else {
                            updateMyFontProperties.sepArray[index][index2] = InputMappingHelpPaintable.SEP;
                        }
                    }
                }
                if (updateMyFontProperties.sepArray[index][index2] != EMPTY_STRING) {
                    updateMyFontProperties.sepWidthArray[index][index2] = font.stringWidth(updateMyFontProperties.sepArray[index][index2]);
                }
            }
        }
        this.updateMyFontProperties = updateMyFontProperties;
        base.updateMeasurement(graphics);
    }

    public virtual void update(GameKey selectedGameKey, Input selectedInput)
    {
        StringMaker stringMaker = new StringMaker();
        this.logUtil.putF(stringMaker.append(CommonLabels.getInstance().START_LABEL).append("selected GameKey: ").append(this.stringUtil.toString(selectedGameKey)).append(" Input: ").append(this.stringUtil.toString(selectedInput)).ToString(), this, this.commonStrings.UPDATE);
        PersistentInputMapping gameKeyMapping = PlatformInputMappingFactory.getInstance().getPersistentInputMappingInstance();
        int size = this.gameInputMappingArray.Length;
        string[] keyInfo = new string[size];
        BasicArrayList[] keyMappingArray = new BasicArrayList[size];
        BasicColor[] actionBasicColor = new BasicColor[size];
        BasicColor[][] inputBasicColorArray = new BasicColor[size][];
        GameInputMapping gameInputMapping = null;
        GameKey gameKey = null;
        BasicArrayList list = null;
        for (int index = 0; index < size; index++) {
            gameInputMapping = this.gameInputMappingArray[index];
            gameKey = gameInputMapping.getGameKey();
            list = gameKeyMapping.getInputMapping().getMappedInput(gameKey);
            int size2 = list.size();
            inputBasicColorArray[index] = new BasicColor[size2];
            for (int index2 = 0; index2 < size2; index2++) {
                inputBasicColorArray[index][index2] = this.basicColor;
            }
            if (gameKey == selectedGameKey) {
                stringMaker.delete(0, stringMaker.length());
                this.logUtil.putF(stringMaker.append("Found: selected GameKey: ").append(this.stringUtil.toString(selectedGameKey)).ToString(), this, this.commonStrings.UPDATE);
                actionBasicColor[index] = this.selectedBasicColor;
                int indexOfSelectedInput = list.indexOf(selectedInput);
                if (indexOfSelectedInput >= 0) {
                    stringMaker.delete(0, stringMaker.length());
                    this.logUtil.putF(stringMaker.append("Found: selected Input: ").append(this.stringUtil.toString(selectedInput)).ToString(), this, this.commonStrings.UPDATE);
                    inputBasicColorArray[index][indexOfSelectedInput] = this.selectedBasicColor;
                }
            } else {
                actionBasicColor[index] = this.basicColor;
            }
            keyInfo[index] = gameInputMapping.getName();
            keyMappingArray[index] = list;
        }
        this.keyMappingArray = keyMappingArray;
        this.actionBasicColor = actionBasicColor;
        this.inputBasicColorArray = inputBasicColorArray;
        base.setInputInfoP(keyInfo);
        this.myFontProcessor = this.updateMyFontProcessor;
    }

    private string get(BasicArrayList keyList)
    {
        StringMaker stringBuffer = new StringMaker();
        Input key = null;
        int size = keyList.size();
        for (int index = 0; index < size; index++) {
            key = ((Input) keyList.objectArray[index]);
            stringBuffer.append(key.getName());
            if (index + 1 < keyList.size()) {
                if (keyList.size() == 2) {
                    stringBuffer.append(InputMappingHelpPaintable.AND);
                } else {
                    if (index + 2 == keyList.size()) {
                        stringBuffer.append(InputMappingHelpPaintable.MORE_THAN_TWO_IN_LIST_AND);
                    } else {
                        stringBuffer.append(InputMappingHelpPaintable.SEP);
                    }
                }
            }
        }
        return stringBuffer.ToString();
    }

    public override void paint(Graphics graphics)
    {
        this.myFontProcessor.process(graphics);
        int halfWidth = this.displayInfo.getLastHalfWidth();
        graphics.setColor(this.basicColor.intValue());
        graphics.drawString(this.title, halfWidth - this.titleBeginWidth, this.updateMyFontProperties.charHeight, this.anchor);
        string[] inputInfo = this.inputInfo;
        int size = inputInfo.Length;
        int y = 0;
        int deltaX = 0;
        int size2 = 0;
        string actionString = null;
        Input input = null;
        BasicArrayList list = null;
        string sep = null;
        int beginWidth = 0;
        for (int index = 0; index < size; index++) {
            y = (index + 3) * this.updateMyFontProperties.charHeight;
            deltaX = 0;
            list = this.keyMappingArray[index];
            size2 = list.size();
            beginWidth = this.updateMyFontProperties.keymappingBeginWidthArray[index];
            graphics.setColor(((int) this.actionBasicColor[index]));
            actionString = this.updateMyFontProperties.actionStringArray[index];
            graphics.drawString(actionString, halfWidth - beginWidth + deltaX, y, this.anchor);
            deltaX += this.updateMyFontProperties.actionStringDeltaXArray[index];
            for (int index2 = 0; index2 < size2; index2++) {
                input = ((Input) list.objectArray[index2]);
                graphics.setColor(((int) this.inputBasicColorArray[index][index2]));
                graphics.drawString(input.getName(), halfWidth - beginWidth + deltaX, y, this.anchor);
                deltaX += this.updateMyFontProperties.inputDeltaXArray[index][index2];
                sep = this.updateMyFontProperties.sepArray[index][index2];
                graphics.setColor(this.basicColor.intValue());
                graphics.drawString(sep, halfWidth - beginWidth + deltaX, y, this.anchor);
                deltaX += this.updateMyFontProperties.sepWidthArray[index][index2];
            }
        }
    }

}

