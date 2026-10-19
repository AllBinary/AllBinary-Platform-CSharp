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
using GameKey = org.allbinary.game.input.GameKey;
using GameKeyFactory = org.allbinary.game.input.GameKeyFactory;
using Input = org.allbinary.game.input.Input;
using PlatformInputMappingFactory = org.allbinary.game.input.PlatformInputMappingFactory;
using GameInputMapping = org.allbinary.game.input.mapping.GameInputMapping;
using PersistentInputMapping = org.allbinary.game.input.mapping.PersistentInputMapping;
using BasicColor = org.allbinary.graphics.color.BasicColor;
using BasicColorFactory = org.allbinary.graphics.color.BasicColorFactory;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using CommonSeps = org.allbinary.@string.CommonSeps;
using BasicArrayList = org.allbinary.util.BasicArrayList;

namespace org.allbinary.game.paint.help;

public class BasicInputMappingHelpPaintable : HelpPaintable
{
    private GameInputMapping[] gameInputMappingArray;
    private readonly GameKey NONE = GameKeyFactory.getInstance().NONE;
    protected BasicInputMappingHelpPaintable(GameInputMapping[] gameInputMappingArray, BasicColor basicColor) : base("Help Screen", BasicColorFactory.getInstance().BLACK, basicColor)
    {
        // base("Help Screen", BasicColorFactory.getInstance().BLACK, basicColor) is called from the constructor declaration
        this.gameInputMappingArray = gameInputMappingArray;
        this.update(this.NONE, this.NONE);
    }

    public virtual void update(GameKey selectedGameKey, Input selectedInput)
    {
        PersistentInputMapping gameKeyMapping = PlatformInputMappingFactory.getInstance().getPersistentInputMappingInstance();
        string EQUAL = " = ";
        StringMaker stringMaker = new StringMaker();
        int size = this.gameInputMappingArray.Length;
        string[] keyInfo = new string[size];
        GameInputMapping gameInputMapping = null;
        GameKey gameKey = null;
        BasicArrayList list = null;
        for (int index = 0; index < size; index++) {
            gameInputMapping = this.gameInputMappingArray[index];
            gameKey = gameInputMapping.getGameKey();
            list = gameKeyMapping.getInputMapping().getMappedInput(gameKey);
            stringMaker.delete(0, stringMaker.length());
            keyInfo[index] = stringMaker.append(gameInputMapping.getName()).append(EQUAL).append(this.get(list)).ToString();
        }
        base.setInputInfoP(keyInfo);
    }

    private string get(BasicArrayList keyList)
    {
        CommonSeps commonSeps = CommonSeps.getInstance();
        StringMaker stringBuffer = new StringMaker();
        string AND = "and ";
        Input key = null;
        int size = keyList.size();
        for (int index = 0; index < size; index++) {
            key = ((Input) keyList.objectArray[index]);
            stringBuffer.append(key.getName());
            if (index + 1 < keyList.size()) {
                if (keyList.size() == 2) {
                    stringBuffer.append(commonSeps.SPACE).append(AND);
                } else {
                    if (index + 2 == keyList.size()) {
                        stringBuffer.append(commonSeps.COMMA_SEP);
                        stringBuffer.append(AND);
                    } else {
                        stringBuffer.append(commonSeps.COMMA_SEP);
                    }
                }
            }
        }
        return stringBuffer.ToString();
    }

}

