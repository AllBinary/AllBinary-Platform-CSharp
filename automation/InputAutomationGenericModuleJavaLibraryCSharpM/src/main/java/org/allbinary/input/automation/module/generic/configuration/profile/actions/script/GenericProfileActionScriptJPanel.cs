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
//using MouseEvent = java.awt.@event.MouseEvent;
//using javax.swing;
//using DefaultMutableTreeNode = javax.swing.tree.DefaultMutableTreeNode;
//using DefaultTreeModel = javax.swing.tree.DefaultTreeModel;
//using TreePath = javax.swing.tree.TreePath;
using JTreeInterface = org.allbinary.input.automation.actions.script.JTreeInterface;
using CustomTreeNodeInterface = org.allbinary.input.automation.actions.script.condition.CustomTreeNodeInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.automation.module.generic.configuration.profile.actions.script;

public class GenericProfileActionScriptJPanel : javax.swing.JPanel, JTreeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private DefaultMutableTreeNode defaultMutableTreeNode = new DefaultMutableTreeNode("Root");
    private GenericProfileActionScript genericProfileActionScript = null;
    public GenericProfileActionScriptJPanel()
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        this.initComponents();
    }

    public virtual void updateJTree()
    {
        DefaultTreeModel defaultTreeModel = new DefaultTreeModel(this.getGenericProfileActionScript());
        this.getActionScriptJTree().setModel(defaultTreeModel);
        this.repaint();
        this.logUtil.putF("Updated UI", this, "updateJTree");
    }

    public virtual GenericProfileActionScript getGenericProfileActionScript()
    {
        return this.genericProfileActionScript;
    }

    public virtual void setGenericProfileActionScript(GenericProfileActionScript genericProfileActionScript)
    {
        this.genericProfileActionScript = genericProfileActionScript;
    }

    public virtual javax.swing.JTree getActionScriptJTree()
    {
        return this.actionScriptJTree;
    }

    public virtual void setActionScriptJTree(javax.swing.JTree actionScriptJTree)
    {
        this.actionScriptJTree = actionScriptJTree;
    }

    private void initComponents()
    {
        this.jScrollPane1 = new javax.swing.JScrollPane();
        this.actionScriptJTree = new javax.swing.JTree();
        setLayout(new java.awt.GridLayout(1, 0));
        this.actionScriptJTree.setPreferredSize(new java.awt.Dimension(500, 500));
        this.actionScriptJTree.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mouseClicked(java.awt.event.MouseEvent evt)
            {
                actionScriptJTreeMouseClicked(evt);
            }

            public virtual void mouseReleased(java.awt.event.MouseEvent evt)
            {
                actionScriptJTreeMouseReleased(evt);
            }

#endif
);
        this.jScrollPane1.setViewportView(this.actionScriptJTree);
        add(this.jScrollPane1);
    }

    private void actionScriptJTreeMouseReleased(java.awt.event.MouseEvent evt)
    {
        int button = evt.getButton();
        if (button == MouseEvent.BUTTON3) {
            TreePath treePath = this.getActionScriptJTree().getSelectionPath();
            if (treePath != null) {
                object anyType = treePath.getLastPathComponent();
                if (anyType is CustomTreeNodeInterface) {
                    CustomTreeNodeInterface customTreeNodeInterface = ((CustomTreeNodeInterface) anyType);
                    JPopupMenu jPopupMenu = customTreeNodeInterface.getJPopupMenu();
                    jPopupMenu.show(((JComponent) evt.getSource()), evt.getX(), evt.getY());
                }
            }
        }
    }

    private void actionScriptJTreeMouseClicked(java.awt.event.MouseEvent evt)
    {
    }

    private javax.swing.JTree actionScriptJTree = null;
    private javax.swing.JScrollPane jScrollPane1 = null;
}

