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
//using ActionListener = java.awt.@event.ActionListener;
//using javax.swing;
//using DefaultMutableTreeNode = javax.swing.tree.DefaultMutableTreeNode;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Node = org.w3c.dom.Node;

namespace org.allbinary.input.automation.actions.script;

public class ProfileActionScriptItem : DefaultMutableTreeNode, ProfileActionScriptItemInterface, ActionListener
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private JPopupMenu jPopupMenu = null;
    private static readonly string EDIT = "Edit";
    public static readonly string DELETE = "Delete";
    public static readonly string NEW_CONDITION = "New Condition";
    public static readonly string NEW_INPUT = "New Input";
    public static readonly string NEW_OUTPUT = "New Output";
    public static readonly string NEW_COLOR_AT = "Color At";
    public static readonly string NEW_TIME_INTERVAL = "Time Interval";
    public static readonly string NEW_ALWAYS = "Always On/Off";
    public static readonly string NEW_KEY_INPUT = "Key";
    public static readonly string NEW_MOUSE_INPUT = "Mouse";
    public static readonly string NEW_JOYSTICK_INPUT = "Joystick";
    public static readonly string NEW_IMAGE_OUTPUT = "Image";
    public ProfileActionScriptItem(string label, Node node) : base(label)
    {
        // base(label) is called from the constructor declaration
        this.init();
        this.logUtil.putF("Label: " + label, this, this.commonStrings.CONSTRUCTOR);
    }

    public ProfileActionScriptItem(string label) : base(label)
    {
        // base(label) is called from the constructor declaration
        this.init();
        this.logUtil.putF("Label: " + label, this, this.commonStrings.CONSTRUCTOR);
    }

    private void init()
    {
        this.setJPopupMenu(new JPopupMenu());
        JMenuItem jMenuItemEdit = new JMenuItem(EDIT);
        JMenuItem jMenuItemDelete = new JMenuItem(DELETE);
        jMenuItemEdit.addActionListener(this);
        jMenuItemDelete.addActionListener(this);
        this.getJPopupMenu().add(jMenuItemEdit);
        this.getJPopupMenu().add(jMenuItemDelete);
    }

    // throws Exception
    public virtual void process(long? frame)
    {
        throw new SystemException();
    }

    public virtual JPopupMenu getJPopupMenu()
    {
        return this.jPopupMenu;
    }

    public virtual void showDialog()
    {
        throw new SystemException();
    }

    public virtual void actionPerformed(ActionEvent actionEvent)
    {
        if (actionEvent.getActionCommand().compareTo(ProfileActionScriptItem.EDIT) == 0) {
            this.showDialog();
        }
    }

    public virtual void setJPopupMenu(JPopupMenu jPopupMenu)
    {
        this.jPopupMenu = jPopupMenu;
    }

}

