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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using javax.swing;
//using TreePath = javax.swing.tree.TreePath;
using JTreeInterfaceFactory = org.allbinary.input.automation.actions.script.JTreeInterfaceFactory;
using ProfileActionScriptItem = org.allbinary.input.automation.actions.script.ProfileActionScriptItem;
using ProfileActionScriptNodeInterface = org.allbinary.input.automation.actions.script.ProfileActionScriptNodeInterface;
using ProfileActionScriptProcessorInterface = org.allbinary.input.automation.actions.script.condition.processors.ProfileActionScriptProcessorInterface;
using GenericProfileActionScriptInputData = org.allbinary.input.automation.actions.script.condition.processors.input.GenericProfileActionScriptInputData;
using KeyboardActionScriptInput = org.allbinary.input.automation.actions.script.condition.processors.input.KeyboardActionScriptInput;
using MouseActionScriptInput = org.allbinary.input.automation.actions.script.condition.processors.input.MouseActionScriptInput;
using ProfileActionScriptInputFactory = org.allbinary.input.automation.actions.script.condition.processors.input.ProfileActionScriptInputFactory;
using GenericProfileActionScriptOutputData = org.allbinary.input.automation.module.actions.script.condition.processors.output.GenericProfileActionScriptOutputData;
using ImageActionScriptOutput = org.allbinary.input.automation.module.actions.script.condition.processors.output.ImageActionScriptOutput;
using ProfileActionScriptOutputFactory = org.allbinary.input.automation.module.actions.script.condition.processors.output.ProfileActionScriptOutputFactory;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using NodeList = org.w3c.dom.NodeList;

namespace org.allbinary.input.automation.actions.script.condition;

public class BasicProfileActionScriptCondition : ProfileActionScriptItem, ProfileActionScriptConditionInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private BasicArrayList profileActionProcessorInterfaceVector = null;
    private BasicArrayList profileActionConditionInterfaceVector = null;
    public BasicProfileActionScriptCondition(string label, Node node) : base(label, node)
    {
        // base(label, node) is called from the constructor declaration
        this.init();
        NodeList nodeList = node.getChildNodes();
        for (int index = 0; index < nodeList.getLength(); index++) {
            Node actionItemNode = nodeList.item(index);
            if (actionItemNode.getNodeType() == Node.ELEMENT_NODE) {
                if (actionItemNode.getNodeName().compareTo(GenericProfileActionScriptConditionData.NAME) == 0) {
                    this.addCondition(ProfileActionScriptConditionFactory.getInstance(actionItemNode));
                } else if (actionItemNode.getNodeName().compareTo(GenericProfileActionScriptInputData.NAME) == 0) {
                    this.addProcessor(ProfileActionScriptInputFactory.getInstance(actionItemNode));
                } else if (actionItemNode.getNodeName().compareTo(GenericProfileActionScriptOutputData.NAME) == 0) {
                    this.addProcessor(ProfileActionScriptOutputFactory.getInstance(actionItemNode));
                }
            }
        }
    }

    // throws Exception
    public virtual void addProcessorNodes(Node node)
    {
        NodeList nodeList = node.getChildNodes();
        for (int index = 0; index < nodeList.getLength(); index++) {
            Node processorActionItemNode = nodeList.item(index);
            if (processorActionItemNode.getNodeName().compareTo(GenericProfileActionScriptInputData.NAME) == 0) {
                this.addProcessor(ProfileActionScriptInputFactory.getInstance(processorActionItemNode));
            } else if (processorActionItemNode.getNodeName().compareTo(GenericProfileActionScriptOutputData.NAME) == 0) {
                this.addProcessor(ProfileActionScriptOutputFactory.getInstance(processorActionItemNode));
            }
        }
    }

    public BasicProfileActionScriptCondition(string label) : base(label)
    {
        // base(label) is called from the constructor declaration
        this.init();
    }

    private void init()
    {
        this.setProfileActionProcessorInterfaceVector(new BasicArrayListD());
        this.setProfileActionConditionInterfaceVector(new BasicArrayListD());
        this.getJPopupMenu().add(this.getConditionJPopupMenu());
        this.getJPopupMenu().add(this.getInputJPopupMenu());
        this.getJPopupMenu().add(this.getOutputJPopupMenu());
    }

    private JMenu getConditionJPopupMenu()
    {
        JMenu jMenu = new JMenu(NEW_CONDITION);
        JMenuItem jMenuItemColorAt = new JMenuItem(NEW_COLOR_AT);
        JMenuItem jMenuItemAlways = new JMenuItem(NEW_ALWAYS);
        JMenuItem jMenuItemTimeInterval = new JMenuItem(NEW_TIME_INTERVAL);
        jMenuItemColorAt.addActionListener(this);
        jMenuItemAlways.addActionListener(this);
        jMenuItemTimeInterval.addActionListener(this);
        jMenu.add(jMenuItemColorAt);
        jMenu.add(jMenuItemAlways);
        jMenu.add(jMenuItemTimeInterval);
        return jMenu;
    }

    private JMenu getInputJPopupMenu()
    {
        JMenu jMenu = new JMenu(NEW_INPUT);
        JMenuItem jMenuItemKey = new JMenuItem(NEW_KEY_INPUT);
        JMenuItem jMenuItemMouse = new JMenuItem(NEW_MOUSE_INPUT);
        JMenuItem jMenuItemJoystick = new JMenuItem(NEW_JOYSTICK_INPUT);
        jMenuItemKey.addActionListener(this);
        jMenuItemMouse.addActionListener(this);
        jMenuItemJoystick.addActionListener(this);
        jMenu.add(jMenuItemKey);
        jMenu.add(jMenuItemMouse);
        jMenu.add(jMenuItemJoystick);
        return jMenu;
    }

    private JMenu getOutputJPopupMenu()
    {
        JMenu jMenu = new JMenu(NEW_OUTPUT);
        JMenuItem jMenuItemImage = new JMenuItem(NEW_IMAGE_OUTPUT);
        jMenuItemImage.addActionListener(this);
        jMenu.add(jMenuItemImage);
        return jMenu;
    }

    public virtual void addProcessor(ProfileActionScriptProcessorInterface profileActionProcessorInterface)
    {
        this.logUtil.putF(this.commonStrings.START, this, "addInput");
        this.getProfileActionProcessorInterfaceVector().add(profileActionProcessorInterface);
        this.add(profileActionProcessorInterface);
    }

    public virtual void removeProcessor(ProfileActionScriptProcessorInterface profileActionProcessorInterface)
    {
        this.logUtil.putF(this.commonStrings.START, this, "removeInput");
        this.getProfileActionProcessorInterfaceVector().remove(profileActionProcessorInterface);
        this.remove(profileActionProcessorInterface);
    }

    public virtual void removeCondition(ProfileActionScriptNodeInterface profileActionScriptNodeInterface)
    {
        this.logUtil.putF(this.commonStrings.START, this, "removeCondition");
        this.getProfileActionConditionInterfaceVector().remove(profileActionScriptNodeInterface);
        this.remove(profileActionScriptNodeInterface);
    }

    public virtual void addCondition(ProfileActionScriptNodeInterface profileActionScriptNodeInterface)
    {
        this.logUtil.putF(this.commonStrings.START, this, "addCondition");
        this.getProfileActionConditionInterfaceVector().add(profileActionScriptNodeInterface);
        this.add(profileActionScriptNodeInterface);
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = document.createElement(GenericProfileActionScriptConditionData.NAME);
        BasicArrayList profileActionConditionInterfaceVector = this.getProfileActionConditionInterfaceVector();
        int size = profileActionConditionInterfaceVector.size();
        for (int index = 0; index < size; index++) {
            ProfileActionScriptConditionInterface profileActionConditionInterface = ((ProfileActionScriptConditionInterface) profileActionConditionInterfaceVector.get(index));
            node.appendChild(profileActionConditionInterface.toXmlNode(document));
        }
        BasicArrayList profileActionProcessorInterfaceVector = this.getProfileActionProcessorInterfaceVector();
        int size2 = profileActionProcessorInterfaceVector.size();
        for (int index = 0; index < size2; index++) {
            ProfileActionScriptProcessorInterface profileActionProcessorInterface = ((ProfileActionScriptProcessorInterface) profileActionProcessorInterfaceVector.get(index));
            node.appendChild(profileActionProcessorInterface.toXmlNode(document));
        }
        return node;
    }

    public virtual BasicArrayList getProfileActionConditionInterfaceVector()
    {
        return this.profileActionConditionInterfaceVector;
    }

    public virtual void setProfileActionConditionInterfaceVector(BasicArrayList profileActionConditionInterfaceVector)
    {
        this.profileActionConditionInterfaceVector = profileActionConditionInterfaceVector;
    }

    public virtual void actionPerformed(ActionEvent actionEvent)
    {
        try {
            base.actionPerformed(actionEvent);
            if (actionEvent.getActionCommand().compareTo(DELETE) == 0) {
                if (this.getParent() is ProfileActionScriptNodeInterface) {
                    ProfileActionScriptNodeInterface profileActionScriptNodeInterface = ((ProfileActionScriptNodeInterface) this.getParent());
                    profileActionScriptNodeInterface.removeCondition(this);
                    JTreeInterfaceFactory.getInstance().getJTreeInterface().updateJTree();
                }
            } else if (actionEvent.getActionCommand().compareTo(NEW_COLOR_AT) == 0) {
                this.addCondition(new ColorAtActionScriptCondition());
                this.updateTree();
            } else if (actionEvent.getActionCommand().compareTo(NEW_ALWAYS) == 0) {
                this.addCondition(new AlwaysActionScriptCondition());
                this.updateTree();
            } else if (actionEvent.getActionCommand().compareTo(NEW_TIME_INTERVAL) == 0) {
                this.addCondition(new TimeIntervalActionScriptCondition());
                this.updateTree();
            } else if (actionEvent.getActionCommand().compareTo(NEW_KEY_INPUT) == 0) {
                this.addProcessor(new KeyboardActionScriptInput());
                this.updateTree();
            } else if (actionEvent.getActionCommand().compareTo(NEW_MOUSE_INPUT) == 0) {
                this.addProcessor(new MouseActionScriptInput());
                this.updateTree();
            } else if (actionEvent.getActionCommand().compareTo(NEW_IMAGE_OUTPUT) == 0) {
                this.addProcessor(new ImageActionScriptOutput());
                this.updateTree();
            }
        } catch (Exception e) {
            this.logUtil.put("Error", this, "actionPerformed", e);
        }
    }

    public virtual BasicArrayList getProfileActionProcessorInterfaceVector()
    {
        return this.profileActionProcessorInterfaceVector;
    }

    public virtual void setProfileActionProcessorInterfaceVector(BasicArrayList profileActionProcessorInterfaceVector)
    {
        this.profileActionProcessorInterfaceVector = profileActionProcessorInterfaceVector;
    }

    private void updateTree()
    {
        JTreeInterfaceFactory.getInstance().getJTreeInterface().updateJTree();
        TreePath treePath = new TreePath(this);
        JTreeInterfaceFactory.getInstance().getJTreeInterface().getActionScriptJTree().expandPath(treePath);
    }

    // throws Exception
    public virtual bool shouldProcess(long? frame)
    {
        BasicArrayList profileActionConditionInterfaceVector = this.getProfileActionConditionInterfaceVector();
        int size = profileActionConditionInterfaceVector.size();
        for (int index = 0; index < size; index++) {
            ProfileActionScriptConditionInterface profileActionScriptConditionInterface = ((ProfileActionScriptConditionInterface) profileActionConditionInterfaceVector.get(index));
            if (!profileActionScriptConditionInterface.shouldProcess(frame)) {
                return false;
            }
        }
        return true;
    }

    // throws Exception
    public virtual void process(long? frame)
    {
        this.logUtil.putF(new StringMaker().append("Start - Processing ").appendint(this.getProfileActionProcessorInterfaceVector().size()).append(" inputs").ToString(), this, this.commonStrings.PROCESS);
        BasicArrayList profileActionProcessorInterfaceVector = this.getProfileActionProcessorInterfaceVector();
        int size = profileActionProcessorInterfaceVector.size();
        for (int index = 0; index < size; index++) {
            ProfileActionScriptProcessorInterface profileActionScriptProcessorInterface = ((ProfileActionScriptProcessorInterface) profileActionProcessorInterfaceVector.get(index));
            profileActionScriptProcessorInterface.process(frame);
        }
    }

}

