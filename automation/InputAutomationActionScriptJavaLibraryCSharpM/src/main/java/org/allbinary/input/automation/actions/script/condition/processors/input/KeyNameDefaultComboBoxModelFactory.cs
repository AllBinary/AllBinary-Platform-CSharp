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
//using KeyEvent = java.awt.@event.KeyEvent;
//using javax.swing;
using KeySingletonFactory = org.allbinary.input.KeySingletonFactory;

namespace org.allbinary.input.automation.actions.script.condition.processors.input;

public class KeyNameDefaultComboBoxModelFactory
{
    private KeyNameDefaultComboBoxModelFactory()
    {
    }

    public static DefaultComboBoxModel getInstance()
    {
        DefaultComboBoxModel defaultComboBoxModel = new DefaultComboBoxModel();
        int?[] keyArray = KeySingletonFactory.getArray();
        for (int index = 0; index < keyArray.Length; index++) {
            string keyAsString = KeyEvent.getKeyText(keyArray[index]);
            defaultComboBoxModel.addElement(keyAsString);
        }
        return defaultComboBoxModel;
    }

}

