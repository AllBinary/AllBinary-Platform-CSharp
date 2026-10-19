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
//using ActionEvent = java.awt.@event.ActionEvent;
using JTreeInterfaceFactory = org.allbinary.input.automation.actions.script.JTreeInterfaceFactory;
using ProfileActionScriptItem = org.allbinary.input.automation.actions.script.ProfileActionScriptItem;
using ProfileActionScriptConditionInterface = org.allbinary.input.automation.actions.script.condition.ProfileActionScriptConditionInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.input.automation.actions.script.condition.processors;

public class BasicProfileActionScriptProcessor : ProfileActionScriptItem, ProfileActionScriptProcessorInterface
{
    public BasicProfileActionScriptProcessor(string label, Node node) : base(label, node)
    {
        // base(label, node) is called from the constructor declaration
    }

    public BasicProfileActionScriptProcessor(string label) : base(label)
    {
        // base(label) is called from the constructor declaration
    }

    public virtual void actionPerformed(ActionEvent actionEvent)
    {
        base.actionPerformed(actionEvent);
        if (actionEvent.getActionCommand().compareTo(DELETE) == 0) {
            if (this.getParent() is ProfileActionScriptConditionInterface) {
                ProfileActionScriptConditionInterface profileActionScriptConditionInterface = ((ProfileActionScriptConditionInterface) this.getParent());
                profileActionScriptConditionInterface.removeProcessor(((ProfileActionScriptProcessorInterface) this));
                JTreeInterfaceFactory.getInstance().getJTreeInterface().updateJTree();
            }
        }
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = document.createElement(GenericProfileActionScriptProcessorData.NAME);
        return node;
    }

}

