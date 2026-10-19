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
//using DefaultMutableTreeNode = javax.swing.tree.DefaultMutableTreeNode;
//using MutableTreeNode = javax.swing.tree.MutableTreeNode;
//using TreePath = javax.swing.tree.TreePath;
using CanvasTreeLabel = org.allbinary.graphics.j2me.workarea.canvas.CanvasTreeLabel;
using MyCanvasEvent = org.allbinary.graphics.j2me.workarea.canvas.@event.MyCanvasEvent;
using MyCanvasEventService = org.allbinary.graphics.j2me.workarea.canvas.@event.MyCanvasEventService;
using MyCanvasEventSource = org.allbinary.graphics.j2me.workarea.canvas.@event.MyCanvasEventSource;
using MyGraphicItemEvent = org.allbinary.graphics.j2me.workarea.tools.@event.MyGraphicItemEvent;
using MyGraphicItemEventService = org.allbinary.graphics.j2me.workarea.tools.@event.MyGraphicItemEventService;
using MyGraphicItemEventSource = org.allbinary.graphics.j2me.workarea.tools.@event.MyGraphicItemEventSource;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;

namespace org.allbinary.graphics.j2me.workarea;

public class WorkAreaJTreeJPanel : javax.swing.JPanel
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private DefaultMutableTreeNode rootTreeNode;
    private JTree workAreaJTree = null;
    private BasicArrayList highlightedBasicArrayList;
    public WorkAreaJTreeJPanel(string workAreaName)
    {
        this.initComponents();
        this.rootTreeNode = new DefaultMutableTreeNode(workAreaName);
        this.workAreaPropertiesJPanel.removeAll();
        this.updateTree();
        this.highlightedBasicArrayList = new BasicArrayListD();
    }

    public virtual void add(MutableTreeNode treeNode)
    {
        this.rootTreeNode.add(treeNode);
    }

    public virtual void updateTree()
    {
        this.workAreaJTree = new JTree(this.rootTreeNode);
        this.workAreaJTree.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                workAreaJTreeMousePressed(evt);
            }

#endif
);
        this.workAreaPropertiesJPanel.removeAll();
        this.workAreaPropertiesJPanel.add(this.workAreaJTree);
    }

    public virtual BasicArrayList getNode(TreePath[] treePathArray)
    {
        BasicArrayList basicArrayList = new BasicArrayListD();
        if (treePathArray != null) {
            for (int index = 0; index < treePathArray.Length; index++) {
                basicArrayList.add(this.getNode(treePathArray[index]));
            }
        }
        return basicArrayList;
    }

    public virtual DefaultMutableTreeNode getNode(TreePath treePath)
    {
        if (treePath != null) {
            object[] obj = treePath.getPath();
            if (obj != null) {
                DefaultMutableTreeNode node = ((DefaultMutableTreeNode) obj[obj.Length - 1]);
                return node;
            }
        }
        return null;
    }

    // throws Exception
    public virtual void deselectAll()
    {
        int size = this.highlightedBasicArrayList.size();
        this.logUtil.putF("size: " + size, this, "deselectAll");
        for (int index = 0; index < size; index++) {
            DefaultMutableTreeNode node = ((DefaultMutableTreeNode) this.highlightedBasicArrayList.get(index));
            MyGraphicItemEventService.fire(new MyGraphicItemEvent(((object) new MyGraphicItemEventSource(MyGraphicItemEventService.DESELECT, node))));
        }
        this.highlightedBasicArrayList.clear();
    }

    // throws Exception
    public virtual void selectGraphicItem(DefaultMutableTreeNode node)
    {
        this.highlightedBasicArrayList.add(node);
        MyGraphicItemEventService.fire(new MyGraphicItemEvent(((object) new MyGraphicItemEventSource(MyGraphicItemEventService.SELECT, node))));
    }

    // throws Exception
    public virtual void removeGraphicItem(DefaultMutableTreeNode node)
    {
        MyGraphicItemEventService.fire(new MyGraphicItemEvent(((object) new MyGraphicItemEventSource(MyGraphicItemEventService.DELETE, node))));
    }

    // throws Exception
    public virtual void removeCanvas(DefaultMutableTreeNode node)
    {
        MyCanvasEventService.fire(new MyCanvasEvent(((object) new MyCanvasEventSource(MyCanvasEventService.DELETE, node))));
    }

    // throws Exception
    public virtual void remove(TreePath treePath)
    {
        DefaultMutableTreeNode node = this.getNode(treePath);
        if (node != null) {
            if (node.getUserObject() is CanvasTreeLabel) {
                this.removeCanvas(node);
            } else {
                this.removeGraphicItem(node);
            }
        }
        DefaultMutableTreeNode parent = ((DefaultMutableTreeNode) node.getParent());
        parent.remove(node);
    }

    // throws Exception
    private void copy()
    {
        TreePath treePath = this.workAreaJTree.getSelectionPath();
        this.copy(treePath);
        this.updateTree();
        this.expand();
        this.repaint();
    }

    // throws Exception
    private void copy(TreePath treePath)
    {
        DefaultMutableTreeNode node = this.getNode(treePath);
        if (node != null) {
            if (node.getUserObject() is CanvasTreeLabel) {
                MyCanvasEventService.fire(new MyCanvasEvent(((object) new MyCanvasEventSource(MyCanvasEventService.DUPLICATE, node))));
            } else {
                MyGraphicItemEventService.fire(new MyGraphicItemEvent(((object) new MyGraphicItemEventSource(MyGraphicItemEventService.DUPLICATE, node))));
            }
        }
    }

    // throws Exception
    public virtual void rotate(TreePath treePath, double angle)
    {
        DefaultMutableTreeNode node = this.getNode(treePath);
        if (node != null) {
            if (node.getUserObject() is CanvasTreeLabel) {
                MyCanvasEventService.fire(new MyCanvasEvent(((object) new MyCanvasEventSource(MyCanvasEventService.ROTATE, angle, node))));
            } else {
                MyGraphicItemEventService.fire(new MyGraphicItemEvent(((object) new MyGraphicItemEventSource(MyGraphicItemEventService.ROTATE, angle, node))));
            }
        }
    }

    public virtual MutableTreeNode getRootTreeNode()
    {
        return this.rootTreeNode;
    }

    public virtual void expand()
    {
        this.workAreaJTree.expandRow(0);
        this.workAreaJTree.expandRow(1);
    }

    public virtual void expand(TreePath treePath)
    {
        this.workAreaJTree.expandPath(treePath);
    }

    private void initComponents()
    {
        itemJPopupMenu = new javax.swing.JPopupMenu();
        this.deleteJMenuItem = new javax.swing.JMenuItem();
        this.copyJMenuItem = new javax.swing.JMenuItem();
        this.rotateJMenuItem = new javax.swing.JMenuItem();
        this.itemJScrollPane1 = new javax.swing.JScrollPane();
        this.workAreaPropertiesJPanel = new javax.swing.JPanel();
        itemJPopupMenu.addPopupMenuListener(new javax.swing.event.PopupMenuListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void popupMenuCanceled(javax.swing.event.PopupMenuEvent evt)
            {
            }

            public virtual void popupMenuWillBecomeInvisible(javax.swing.event.PopupMenuEvent evt)
            {
                itemJPopupMenuPopupMenuWillBecomeInvisible(evt);
            }

            public virtual void popupMenuWillBecomeVisible(javax.swing.event.PopupMenuEvent evt)
            {
                itemJPopupMenuPopupMenuWillBecomeVisible(evt);
            }

#endif
);
        this.deleteJMenuItem.setText("Delete");
        this.deleteJMenuItem.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                deleteJMenuItemMousePressed(evt);
            }

#endif
);
        this.itemJPopupMenu.add(this.deleteJMenuItem);
        this.copyJMenuItem.setText("Copy");
        this.copyJMenuItem.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                copyJMenuItemMousePressed(evt);
            }

#endif
);
        this.itemJPopupMenu.add(this.copyJMenuItem);
        this.rotateJMenuItem.setText("Rotate 45*");
        this.rotateJMenuItem.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                rotateJMenuItemMousePressed(evt);
            }

#endif
);
        this.itemJPopupMenu.add(this.rotateJMenuItem);
        setLayout(new java.awt.GridLayout(1, 1));
        this.workAreaPropertiesJPanel.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                workAreaPropertiesJPanelMousePressed(evt);
            }

#endif
);
        this.workAreaPropertiesJPanel.setLayout(new java.awt.GridLayout(1, 0));
        this.itemJScrollPane1.setViewportView(this.workAreaPropertiesJPanel);
        add(this.itemJScrollPane1);
    }

    private void rotateJMenuItemMousePressed(java.awt.event.MouseEvent evt)
    {
        try {
            TreePath treePath = this.workAreaJTree.getSelectionPath();
            this.rotate(treePath, 45);
            this.updateTree();
            this.expand();
            this.repaint();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "rotateJMenuItemMousePressed", e);
        }
    }

    private void workAreaJTreeMousePressed(java.awt.event.MouseEvent evt)
    {
        try {
            TreePath[] selectedTreePathArray = this.workAreaJTree.getSelectionPaths();
            BasicArrayList list = this.getNode(selectedTreePathArray);
            if (list.size() > 0) {
                if ((evt.getModifiers() & evt.BUTTON3_MASK) == evt.BUTTON3_MASK) {
                    for (int index = 0; index < selectedTreePathArray.Length; index++) {
                        DefaultMutableTreeNode defaultMutableTreeNode = ((DefaultMutableTreeNode) list.get(index));
                        if (defaultMutableTreeNode.getUserObject() is CanvasTreeLabel) {
                            this.itemJPopupMenu.show(this, evt.getX(), evt.getY());
                        } else {
                            this.itemJPopupMenu.show(this, evt.getX(), evt.getY());
                        }
                    }
                }
                if ((evt.getModifiers() & evt.BUTTON1_MASK) == evt.BUTTON1_MASK) {
                    this.deselectAll();
                    for (int index = 0; index < selectedTreePathArray.Length; index++) {
                        DefaultMutableTreeNode defaultMutableTreeNode = ((DefaultMutableTreeNode) list.get(index));
                        if (defaultMutableTreeNode.getUserObject() is CanvasTreeLabel) {
                            MyCanvasEventService.fire(new MyCanvasEvent(((object) new MyCanvasEventSource(MyCanvasEventService.SELECT, defaultMutableTreeNode))));
                        } else {
                            this.selectGraphicItem(defaultMutableTreeNode);
                        }
                    }
                }
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "workAreaJTreeMousePressed", e);
        }
    }

    private void itemJPopupMenuPopupMenuWillBecomeInvisible(javax.swing.event.PopupMenuEvent evt)
    {
    }

    private void itemJPopupMenuPopupMenuWillBecomeVisible(javax.swing.event.PopupMenuEvent evt)
    {
    }

    private void copyJMenuItemMousePressed(java.awt.event.MouseEvent evt)
    {
        try {
            this.copy();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "copyJMenuItemMousePressed", e);
        }
    }

    private void deleteJMenuItemMousePressed(java.awt.event.MouseEvent evt)
    {
        try {
            TreePath[] selectedTreePathArray = this.workAreaJTree.getSelectionPaths();
            for (int index = 0; index < selectedTreePathArray.Length; index++) {
                TreePath treePath = selectedTreePathArray[index];
                this.remove(treePath);
                this.updateTree();
                this.expand();
                this.repaint();
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "deleteJMenuItemMousePressed", e);
        }
    }

    private void workAreaPropertiesJPanelMousePressed(java.awt.event.MouseEvent evt)
    {
    }

    private javax.swing.JMenuItem copyJMenuItem = null;
    private javax.swing.JMenuItem deleteJMenuItem = null;
    private javax.swing.JPopupMenu itemJPopupMenu = null;
    private javax.swing.JScrollPane itemJScrollPane1 = null;
    private javax.swing.JMenuItem rotateJMenuItem = null;
    private javax.swing.JPanel workAreaPropertiesJPanel = null;
}

