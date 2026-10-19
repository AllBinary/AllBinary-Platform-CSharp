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
using DomSearchHelper = org.allbinary.data.tree.dom.DomSearchHelper;
using Node = org.w3c.dom.Node;

namespace org.allbinary.input.automation.actions.script.condition.processors.input;

public class ProfileActionScriptInputFactory
{
    private ProfileActionScriptInputFactory()
    {
    }

    // throws Exception
    public static ProfileActionScriptInputInterface getInstance(Node node)
    {
        ProfileActionScriptInputInterface profileActionScriptInputInterface = null;
        if (DomSearchHelper.getNodeNoThrow(KeyboardActionScriptInputData.NAME, node.getChildNodes()) != null) {
            profileActionScriptInputInterface = new KeyboardActionScriptInput(node);
        } else if (DomSearchHelper.getNodeNoThrow(MouseActionScriptInputData.NAME, node.getChildNodes()) != null) {
            profileActionScriptInputInterface = new MouseActionScriptInput(node);
        } else {
            throw new Exception("No Such ActionScript Input");
        }
        return profileActionScriptInputInterface;
    }

}

