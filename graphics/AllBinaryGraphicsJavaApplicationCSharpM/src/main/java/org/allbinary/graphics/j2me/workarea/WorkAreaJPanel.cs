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
using System.Runtime.CompilerServices;
//using java.awt;
//using EventListener = java.util.EventListener;
using java.util;
//using LinkedList = java.util.LinkedList;
//using javax.swing;
//using MutableTreeNode = javax.swing.tree.MutableTreeNode;
using DomHelper = org.allbinary.dom.DomHelper;
using StatusFactory = org.allbinary.graphics.j2me.StatusFactory;
using CanvasDom = org.allbinary.graphics.j2me.workarea.canvas.CanvasDom;
using CanvasJPanel = org.allbinary.graphics.j2me.workarea.canvas.CanvasJPanel;
using MyCanvasEvent = org.allbinary.graphics.j2me.workarea.canvas.@event.MyCanvasEvent;
using MyCanvasEventListener = org.allbinary.graphics.j2me.workarea.canvas.@event.MyCanvasEventListener;
using MyCanvasEventService = org.allbinary.graphics.j2me.workarea.canvas.@event.MyCanvasEventService;
using PropertiesJPanel = org.allbinary.graphics.j2me.workarea.properties.PropertiesJPanel;
using ToolJPanel = org.allbinary.graphics.j2me.workarea.tools.ToolJPanel;
using LOGGING = org.allbinary.log.LOGGING;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.graphics.j2me.workarea;

public class WorkAreaJPanel : JPanel, WorkAreaJPanelInterface, MyCanvasEventListener, EventListener, Runnable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private LinkedList canvasJPanelList = null;
    private JPanel canvasHolderJPanel = null;
    private string name = null;
    private int selectedFrame = 0;
    private static org.w3c.dom.Document document = null;
    private PropertiesJPanel propertiesJPanel = null;
    private WorkAreaJTreeJPanel workAreaJTreeJPanel = null;
    private bool isPlaying = false;
    public WorkAreaJPanel(string name, Dimension dimension, int x, int y)
    {
        try {
            this.initComponents();
            this.name = name;
            this.initMyComponents(dimension);
            this.workAreaJTreeJPanel = new WorkAreaJTreeJPanel(this.name);
            CanvasJPanel canvasJPanel = new CanvasJPanel(this.workAreaJTreeJPanel, this.getSize(), x, y);
            this.canvasJPanelList.add(canvasJPanel);
            this.selectedFrame = 0;
            this.propertiesJPanel.set(this.workAreaJTreeJPanel);
            this.canvasHolderJPanel.add(((Component) canvasJPanel));
        } catch (Exception e) {
            throw e;
        }
    }

    public WorkAreaJPanel(WorkAreaDom workAreaDom, Dimension dimension)
    {
        try {
            this.initComponents();
            this.name = workAreaDom.getName();
            this.initMyComponents(dimension);
            BasicArrayList canvasNodeList = workAreaDom.getCanvasNodes();
            int numberOfFrames = canvasNodeList.size();
            for (int index = 0; index < numberOfFrames; index++) {
                Node node = ((Node) canvasNodeList.get(index));
                CanvasJPanel canvasJPanel = new CanvasJPanel(this.workAreaJTreeJPanel, this.getSize(), new CanvasDom(node));
                this.canvasJPanelList.add(canvasJPanel);
            }
            this.selectedFrame = 0;
            this.canvasHolderJPanel.add(((Component) this.getCurrentFrame()));
            this.propertiesJPanel.set(this.workAreaJTreeJPanel);
        } catch (Exception e) {
            if (LOGGING.contains(LOGGING.LOADINGERROR)) {
                this.logUtil.put("Constructor Error", this, "WorkAreaJPanel", e);
            }
            throw e;
        }
    }

    private void initMyComponents(Dimension dimension)
    {
        this.workAreaJTreeJPanel = new WorkAreaJTreeJPanel(this.name);
        this.canvasHolderJPanel = new JPanel();
        this.canvasHolderJPanel.setSize(dimension);
        this.canvasHolderJPanel.setLayout(new GridLayout(1, 1));
        this.setSize(dimension);
        this.canvasJPanelList = new LinkedList();
        GridBagLayout gridBagLayout = new GridBagLayout();
        GridBagConstraints gridBagConstraints = new GridBagConstraints();
        this.innerJPanel.setLayout(gridBagLayout);
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.gridwidth = 1;
        gridBagConstraints.fill = java.awt.GridBagConstraints.BOTH;
        gridBagConstraints.weightx = .05;
        gridBagConstraints.weighty = .05;
        ToolJPanel toolJPanel = new ToolJPanel();
        gridBagLayout.setConstraints(toolJPanel, gridBagConstraints);
        this.innerJPanel.add(toolJPanel);
        gridBagConstraints = new GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.gridwidth = 6;
        gridBagConstraints.fill = java.awt.GridBagConstraints.BOTH;
        gridBagConstraints.weightx = 1;
        gridBagConstraints.weighty = 1;
        gridBagLayout.setConstraints(this.canvasHolderJPanel, gridBagConstraints);
        this.innerJPanel.add(this.canvasHolderJPanel);
        gridBagConstraints = new GridBagConstraints();
        gridBagConstraints.gridx = 8;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.gridwidth = java.awt.GridBagConstraints.REMAINDER;
        gridBagConstraints.fill = java.awt.GridBagConstraints.BOTH;
        gridBagConstraints.weightx = .1;
        gridBagConstraints.weighty = .1;
        this.propertiesJPanel = new PropertiesJPanel();
        gridBagLayout.setConstraints(this.propertiesJPanel, gridBagConstraints);
        this.innerJPanel.add(this.propertiesJPanel);
        MyCanvasEventService.addListener(((MyCanvasEventListener) this));
    }

    private HashMap getCanvasHashMap()
    {
        HashMap canvasJPanelHashMap = StdUtil.getInstance().createHashMap();
        int size = this.canvasJPanelList.size();
        for (int index = 0; index < size; index++) {
            CanvasJPanel canvasJPanel = ((CanvasJPanel) this.canvasJPanelList.get(index));
            canvasJPanelHashMap.put(canvasJPanel.getTreeNode(), index);
        }
        return canvasJPanelHashMap;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void play()
    {
        this.isPlaying = true;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void stop()
    {
        this.isPlaying = false;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual bool isPlaying()
    {
        return this.isPlaying;
    }

    public virtual string getName()
    {
        return this.name;
    }

    public virtual void setName(string value)
    {
        this.name = value;
    }

    public virtual void disableCanvas()
    {
        this.canvasHolderJPanel.removeAll();
    }

    public virtual void enableCanvas()
    {
        this.canvasHolderJPanel.add(((Component) this.getCurrentFrame()));
    }

    public virtual void deselect()
    {
        base.setVisible(false);
    }

    public virtual void select()
    {
        base.setVisible(true);
        if (this.canvasHolderJPanel.getComponentCount() == 1) {
            Component component = this.canvasHolderJPanel.getComponent(0);
            if (component != null) {
                component.repaint();
            }
        }
    }

    public virtual void changeZoom(int factor)
    {
        int size = this.canvasJPanelList.size();
        for (int index = 0; index < size; index++) {
            CanvasJPanel canvasJPanel = ((CanvasJPanel) this.canvasJPanelList.get(index));
            canvasJPanel.getGrid().setZoom(canvasJPanel.getGrid().getZoom() + factor);
        }
    }

    public virtual CanvasJPanel getCurrentFrame()
    {
        return ((CanvasJPanel) this.canvasJPanelList.get(this.selectedFrame));
    }

    private void initDuplicate(CanvasJPanel newCanvasJPanel)
    {
        if (newCanvasJPanel != null) {
            this.canvasJPanelList.add(newCanvasJPanel);
            this.select(this.canvasJPanelList.size() - 1);
        }
    }

    // throws Exception
    private void duplicate(MutableTreeNode treeNode)
    {
        HashMap canvasJPanelHashMap = this.getCanvasHashMap();
        if (canvasJPanelHashMap.containsKey(treeNode)) {
            int? frameInteger = ((int?) canvasJPanelHashMap.get(treeNode));
            CanvasJPanel canvasJPanel = ((CanvasJPanel) this.canvasJPanelList.get(((int) frameInteger)));
            this.initDuplicate(canvasJPanel.duplicate());
        }
    }

    // throws Exception
    public virtual void autoRotate(int increments, int totalAngle)
    {
        int incrementAngle = (totalAngle / increments);
        for (int index = 1; index < increments; index++) {
            CanvasJPanel canvasJPanel = ((CanvasJPanel) this.getCurrentFrame());
            CanvasJPanel newCanvasJPanel = canvasJPanel.duplicate();
            newCanvasJPanel.setAngle(incrementAngle * index);
            this.initDuplicate(newCanvasJPanel);
        }
    }

    public virtual void explodeAll()
    {
        CanvasJPanel canvasJPanel = ((CanvasJPanel) this.getCurrentFrame());
        canvasJPanel.explodeAll();
    }

    // throws Exception
    public virtual void autoExplode(int numberOfFrames, int explodeType)
    {
        for (int index = 1; index < numberOfFrames; index++) {
            CanvasJPanel canvasJPanel = ((CanvasJPanel) this.getCurrentFrame());
            CanvasJPanel newCanvasJPanel = canvasJPanel.duplicate();
            newCanvasJPanel.explode(index + 1, explodeType);
            this.initDuplicate(newCanvasJPanel);
        }
    }

    // throws Exception
    public virtual void autoMirror()
    {
        CanvasJPanel canvasJPanel = ((CanvasJPanel) this.getCurrentFrame());
        CanvasJPanel newCanvasJPanel = canvasJPanel.duplicate();
        newCanvasJPanel.mirror();
        this.initDuplicate(newCanvasJPanel);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    private void select(int index)
    {
        if (index < this.canvasJPanelList.size()) {
            CanvasJPanel canvasJPanel = ((CanvasJPanel) this.canvasJPanelList.get(index));
            if (canvasJPanel != null) {
                this.canvasHolderJPanel.removeAll();
                this.canvasHolderJPanel.add(canvasJPanel);
                this.selectedFrame = index;
                canvasJPanel.changed();
                this.canvasHolderJPanel.repaint();
                canvasJPanel.repaint();
            }
        }
    }

    private void select(MutableTreeNode treeNode)
    {
        HashMap canvasJPanelHashMap = this.getCanvasHashMap();
        int? frameInteger = ((int?) canvasJPanelHashMap.get(treeNode));
        if (frameInteger != null) {
            this.select(((int) frameInteger));
        }
    }

    public static Document getDocument()
    {
        return WorkAreaJPanel.document;
    }

    // throws Exception
    public virtual Document toDocument()
    {
        WorkAreaJPanel.document = DomHelper.getInstance().createDocument();
        Node workAreaNode = WorkAreaJPanel.document.createElement(WorkAreaDom.WORKAREA);
        Node nameNode = WorkAreaJPanel.document.createElement(WorkAreaDom.NAME);
        Node nameTextNode = WorkAreaJPanel.document.createTextNode(this.name);
        nameNode.appendChild(nameTextNode);
        Node framesNode = WorkAreaJPanel.document.createElement(WorkAreaDom.FRAMES);
        int size = this.canvasJPanelList.size();
        for (int index = 0; index < size; index++) {
            CanvasJPanel canvasJPanel = ((CanvasJPanel) this.canvasJPanelList.get(index));
            framesNode.appendChild(canvasJPanel.toDom());
        }
        workAreaNode.appendChild(nameNode);
        workAreaNode.appendChild(framesNode);
        WorkAreaJPanel.document.appendChild(workAreaNode);
        return document;
    }

    private void initComponents()
    {
        this.innerJPanel = new javax.swing.JPanel();
        setLayout(new java.awt.GridLayout(1, 1));
        this.innerJPanel.addKeyListener(new java.awt.event.KeyAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void keyTyped(java.awt.event.KeyEvent evt)
            {
                innerJPanelKeyTyped(evt);
            }

            public virtual void keyPressed(java.awt.event.KeyEvent evt)
            {
                innerJPanelKeyPressed(evt);
            }

            public virtual void keyReleased(java.awt.event.KeyEvent evt)
            {
                innerJPanelKeyReleased(evt);
            }

#endif
);
        add(this.innerJPanel);
    }

    private void innerJPanelKeyReleased(java.awt.event.KeyEvent evt)
    {
        StatusFactory.getInstance().setStatus("Key Pressed1");
    }

    private void innerJPanelKeyPressed(java.awt.event.KeyEvent evt)
    {
        StatusFactory.getInstance().setStatus("Key Pressed2");
    }

    private void innerJPanelKeyTyped(java.awt.event.KeyEvent evt)
    {
        StatusFactory.getInstance().setStatus("Key Pressed3");
    }

    public virtual void keyPressed(java.awt.event.KeyEvent keyEvent)
    {
        this.getCurrentFrame().keyPressed(keyEvent);
    }

    public virtual void keyReleased(java.awt.event.KeyEvent keyEvent)
    {
    }

    public virtual void keyTyped(java.awt.event.KeyEvent keyEvent)
    {
    }

    public virtual void delete(MyCanvasEvent evt)
    {
        HashMap canvasJPanelHashMap = this.getCanvasHashMap();
        if (canvasJPanelHashMap.containsKey(evt.getTreeNode())) {
            this.canvasHolderJPanel.removeAll();
            int? frameInt = ((int?) canvasJPanelHashMap.get(evt.getTreeNode()));
            this.canvasJPanelList.remove(((int) frameInt));
            this.select(((int) frameInt));
        }
    }

    // throws Exception
    public virtual void duplicate(MyCanvasEvent evt)
    {
        this.duplicate(evt.getTreeNode());
    }

    public virtual void select(MyCanvasEvent evt)
    {
        this.select(evt.getTreeNode());
        StatusFactory.getInstance().setStatus("Frame Selected");
    }

    public virtual void rotate(MyCanvasEvent evt)
    {
        HashMap canvasJPanelHashMap = this.getCanvasHashMap();
        MutableTreeNode treeNode = evt.getTreeNode();
        int? frameInt = ((int?) canvasJPanelHashMap.get(evt.getTreeNode()));
        CanvasJPanel canvasJPanel = ((CanvasJPanel) this.canvasJPanelList.get(((int) frameInt)));
        if (canvasJPanel != null) {
            canvasJPanel.addAngle(evt.getAngle());
            this.select(((int) frameInt));
        }
        StatusFactory.getInstance().setStatus("Canvas Rotated");
    }

    public virtual void explode(MyCanvasEvent evt)
    {
        this.explodeAll();
    }

    // throws Exception
    public virtual void autoExplode(MyCanvasEvent evt)
    {
        this.autoExplode(10, 0);
    }

    // throws Exception
    public virtual void center()
    {
        CanvasJPanel canvasJPanel = ((CanvasJPanel) this.getCurrentFrame());
        canvasJPanel.center();
    }

    // throws Exception
    public virtual void center(MyCanvasEvent evt)
    {
        this.center();
    }

    public virtual void run()
    {
        try {
            while (true) {
                if (this.isPlaying()) {
                    int size = this.canvasJPanelList.size();
                    for (int index = 0; index < size; index++) {
                        if (!this.isPlaying()) {
                            break;
                        }
                        this.select(index);
                        System.Threading.Thread.Sleep((int) (100));
                    }
                } else {
                    System.Threading.Thread.Sleep((int) (500));
                }
                System.Threading.Thread.Sleep((int) (250));
            }
        } catch (Exception e) {
        }
    }

    private javax.swing.JPanel innerJPanel = null;
}

