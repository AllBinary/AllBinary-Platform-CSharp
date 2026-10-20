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
using java.util;
//using javax.swing;
using InputRobotFactory = org.allbinary.input.automation.robot.InputRobotFactory;

namespace org.allbinary.input.automation.actions.script.condition.processors.input;

public class InputAutomationTypeDefaultComboBoxModelFactory
{
    private InputAutomationTypeDefaultComboBoxModelFactory()
    {
    }

    // throws Exception
    public static DefaultComboBoxModel getInstance()
    {
        DefaultComboBoxModel defaultComboBoxModel = new DefaultComboBoxModel();
        Set set = InputRobotFactory.getInstance().get().keySet();
        object[] nameArray = set.toArray();
        int size = nameArray.Length;
        for (int index = 0; index < size; index++) {
            defaultComboBoxModel.addElement(((string) nameArray[index]));
        }
        return defaultComboBoxModel;
    }

}

