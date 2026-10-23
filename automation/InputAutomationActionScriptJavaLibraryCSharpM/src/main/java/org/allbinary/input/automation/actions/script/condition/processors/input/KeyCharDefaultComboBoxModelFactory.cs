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
//using javax.swing;
using KeyStrokeMap = abbot.tester.KeyStrokeMap;
using KeySingletonFactory = org.allbinary.input.KeySingletonFactory;

namespace org.allbinary.input.automation.actions.script.condition.processors.input;

public class KeyCharDefaultComboBoxModelFactory
{
    private KeyCharDefaultComboBoxModelFactory()
    {
    }

    public static DefaultComboBoxModel getInstance()
    {
        DefaultComboBoxModel defaultComboBoxModel = new DefaultComboBoxModel();
        int?[] keyArray = KeySingletonFactory.getArray();
        for (int index = 0; index < keyArray.Length; index++) {
            int? nextKey = keyArray[index];
            KeyStroke keyStroke = KeyStroke.getKeyStroke(((int) nextKey), 0);
            char keyChar = KeyStrokeMap.getChar(keyStroke);
            defaultComboBoxModel.addElement((keyChar).ToString());
        }
        return defaultComboBoxModel;
    }

}

