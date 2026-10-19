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

namespace org.allbinary.input.automation.module.actions.script.condition.processors.output;

public class ProfileActionScriptOutputFactory
{
    private ProfileActionScriptOutputFactory()
    {
    }

    // throws Exception
    public static ProfileActionScriptOutputInterface getInstance(Node node)
    {
        ProfileActionScriptOutputInterface profileActionScriptOutputInterface = null;
        if (DomSearchHelper.getNodeNoThrow(ImageActionScriptOutputData.NAME, node.getChildNodes()) != null) {
            profileActionScriptOutputInterface = new ImageActionScriptOutput(node);
        } else {
            throw new Exception("No Such ActionScript Output");
        }
        return profileActionScriptOutputInterface;
    }

}

