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
//using java.awt;
//using File = java.io.File;
using java.util;
//using javax.swing;
using XslHelper = org.allbinary.data.tree.dom.XslHelper;
using DomHelper = org.allbinary.dom.DomHelper;
using NewWorkAreaJDialog = org.allbinary.graphics.j2me.dialog.NewWorkAreaJDialog;
using RotateJDialog = org.allbinary.graphics.j2me.dialog.RotateJDialog;
using WorkAreaDom = org.allbinary.graphics.j2me.workarea.WorkAreaDom;
using WorkAreaJPanel = org.allbinary.graphics.j2me.workarea.WorkAreaJPanel;
using WorkAreaJPanelInterface = org.allbinary.graphics.j2me.workarea.WorkAreaJPanelInterface;
using MyCanvasEvent = org.allbinary.graphics.j2me.workarea.canvas.@event.MyCanvasEvent;
using MyCanvasEventService = org.allbinary.graphics.j2me.workarea.canvas.@event.MyCanvasEventService;
using MyCanvasEventSource = org.allbinary.graphics.j2me.workarea.canvas.@event.MyCanvasEventSource;
using FileJDialog = org.allbinary.gui.dialog.FileJDialog;
using FileJDialogListenerInterface = org.allbinary.gui.dialog.FileJDialogListenerInterface;
using HashMapJDialogListenerInterface = org.allbinary.gui.dialog.HashMapJDialogListenerInterface;
using LOGGING = org.allbinary.log.LOGGING;
using GuiLog = org.allbinary.logic.communication.log.GuiLog;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using SmallIntegerSingletonFactory = org.allbinary.logic.math.SmallIntegerSingletonFactory;
using AngleFactory = org.allbinary.math.AngleFactory;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;

namespace org.allbinary.graphics.j2me;

public class MyFrame : javax.swing.JFrame, FileJDialogListenerInterface, HashMapJDialogListenerInterface, java.awt.event.KeyListener
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly GuiLog guiLog = GuiLog.getInstance();
    private readonly XslHelper xslHelper = XslHelper.getInstance();
    private static readonly int MAXWORKAREAS = 10;
    private static int numberOfWorkAreas = 0;
    private readonly string JAVA_TEMPLATE = "svgExport.xsl";
    private readonly string SAVEEXTENSION = ".gxml";
    private readonly string JAVAEXTENSION = ".javax";
    private static readonly string PATH = "G:/mnt/bc/mydev/work/graphics/AllBinaryGraphicsJavaApplication";
    private static readonly string SAVE_PATH = MyFrame.PATH + "/save";
    private static readonly string TEMPLATE_EXPORT_PATH = MyFrame.PATH + "/templates/export";
    private FileJDialog fileJDialog;
    private RotateJDialog rotateJDialog;
    public MyFrame()
    {
        this.initComponents();
        this.setSize(new Dimension(550, 400));
        this.mainJPanel.setSize(new Dimension(550, 400));
        this.jTabbedPane.setSize(new Dimension(550, 400));
        this.fileJDialog = new FileJDialog();
        this.fileJDialog.addFinishedListener(this);
        this.rotateJDialog = new RotateJDialog(this, false);
    }

    private void initComponents()
    {
        jToolBar1 = new javax.swing.JToolBar();
        this.jButton2 = new javax.swing.JButton();
        this.saveJButton = new javax.swing.JButton();
        this.jButton1 = new javax.swing.JButton();
        this.openJButton = new javax.swing.JButton();
        this.jButton3 = new javax.swing.JButton();
        this.jButton4 = new javax.swing.JButton();
        this.jButton41 = new javax.swing.JButton();
        this.jButton5 = new javax.swing.JButton();
        this.animateJButton = new javax.swing.JButton();
        this.playJButton = new javax.swing.JButton();
        this.stopJjButton = new javax.swing.JButton();
        this.jPanel1 = new javax.swing.JPanel();
        this.mainJPanel = new javax.swing.JPanel();
        this.jTabbedPane = new javax.swing.JTabbedPane();
        this.statusJPanel = new javax.swing.JPanel();
        MyFrame.statusJLabel = new javax.swing.JLabel();
        this.menuJMenuBar = new javax.swing.JMenuBar();
        this.fileJMenu = new javax.swing.JMenu();
        this.newJMenuItem = new javax.swing.JMenuItem();
        this.openJMenuItem = new javax.swing.JMenuItem();
        this.saveJMenuItem = new javax.swing.JMenuItem();
        this.saveAsJMenuItem = new javax.swing.JMenuItem();
        this.exportJMenuItem1 = new javax.swing.JMenuItem();
        this.exitJMenuItem = new javax.swing.JMenuItem();
        this.viewJMenu = new javax.swing.JMenu();
        this.zoomInJMenuItem = new javax.swing.JMenuItem();
        this.zoomOutJMenuItem = new javax.swing.JMenuItem();
        this.objectJMenu = new javax.swing.JMenu();
        this.explodeAllJMenuItem = new javax.swing.JMenuItem();
        this.frameJMenu = new javax.swing.JMenu();
        this.previousFrameJMenuItem = new javax.swing.JMenuItem();
        this.nextFrameJMenuItem = new javax.swing.JMenuItem();
        this.removeJMenuItem = new javax.swing.JMenuItem();
        this.copyJMenuItem1 = new javax.swing.JMenuItem();
        this.insertAfterJMenuItem = new javax.swing.JMenuItem();
        this.insertBeforeJMenuItem = new javax.swing.JMenuItem();
        this.generateJMenu = new javax.swing.JMenu();
        this.centerJMenuItem = new javax.swing.JMenuItem();
        this.autoDamageJMenuItem = new javax.swing.JMenuItem();
        this.autoExplodeJMenuItem = new javax.swing.JMenuItem();
        this.autoGrowJMenuItem = new javax.swing.JMenuItem();
        this.jMenuItem1 = new javax.swing.JMenuItem();
        this.autoRotateGenerationJMenuItem = new javax.swing.JMenuItem();
        this.autoSheildMenuItem = new javax.swing.JMenuItem();
        this.autoShrinkJMenuItem = new javax.swing.JMenuItem();
        this.jMenu1 = new javax.swing.JMenu();
        addWindowListener(new java.awt.event.WindowAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void windowClosing(java.awt.event.WindowEvent evt)
            {
                exitForm(evt);
            }

#endif
);
        this.jButton2.setText("New");
        this.jButton2.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                jButton2ActionPerformed(evt);
            }

#endif
);
        this.jToolBar1.add(this.jButton2);
        this.saveJButton.setText("Save");
        this.saveJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                saveJButtonActionPerformed(evt);
            }

#endif
);
        this.jToolBar1.add(this.saveJButton);
        this.jButton1.setText("Export");
        this.jButton1.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                jButton1ActionPerformed(evt);
            }

#endif
);
        this.jToolBar1.add(this.jButton1);
        this.openJButton.setText("Open");
        this.openJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                openJButtonActionPerformed(evt);
            }

#endif
);
        this.jToolBar1.add(this.openJButton);
        this.jButton3.setText("Copy");
        this.jToolBar1.add(this.jButton3);
        this.jButton4.setText("Insert Before");
        this.jToolBar1.add(this.jButton4);
        this.jButton41.setText("Insert After");
        this.jToolBar1.add(this.jButton41);
        this.jButton5.setText("Delete");
        this.jToolBar1.add(this.jButton5);
        this.animateJButton.setText("AnimateEdit");
        this.jToolBar1.add(this.animateJButton);
        this.playJButton.setText("Play");
        this.playJButton.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                playJButtonMousePressed(evt);
            }

#endif
);
        this.jToolBar1.add(this.playJButton);
        this.stopJjButton.setText("Stop");
        this.stopJjButton.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                stopJjButtonMousePressed(evt);
            }

#endif
);
        this.jToolBar1.add(this.stopJjButton);
        getContentPane().add(this.jToolBar1, java.awt.BorderLayout.NORTH);
        this.jPanel1.setLayout(new java.awt.GridLayout(1, 0));
        this.mainJPanel.setLayout(new java.awt.GridLayout(1, 0));
        this.jTabbedPane.setMinimumSize(new java.awt.Dimension(550, 400));
        this.jTabbedPane.addChangeListener(new javax.swing.event.ChangeListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void stateChanged(javax.swing.event.ChangeEvent evt)
            {
                jTabbedPaneStateChanged(evt);
            }

#endif
);
        this.mainJPanel.add(this.jTabbedPane);
        this.jPanel1.add(this.mainJPanel);
        getContentPane().add(this.jPanel1, java.awt.BorderLayout.CENTER);
        this.statusJPanel.setLayout(new java.awt.GridLayout(1, 0));
        MyFrame.statusJLabel.setText("Status Bar");
        this.statusJPanel.add(MyFrame.statusJLabel);
        getContentPane().add(this.statusJPanel, java.awt.BorderLayout.SOUTH);
        this.fileJMenu.setText("File");
        this.fileJMenu.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                fileJMenuActionPerformed(evt);
            }

#endif
);
        this.newJMenuItem.setText("New");
        this.newJMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                newJMenuItemActionPerformed(evt);
            }

#endif
);
        this.fileJMenu.add(this.newJMenuItem);
        this.openJMenuItem.setText("Open");
        this.openJMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                openJMenuItemActionPerformed(evt);
            }

#endif
);
        this.fileJMenu.add(this.openJMenuItem);
        this.saveJMenuItem.setText("Save");
        this.saveJMenuItem.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                saveJMenuItemMousePressed(evt);
            }

#endif
);
        this.fileJMenu.add(this.saveJMenuItem);
        this.saveAsJMenuItem.setText("SaveAs");
        this.fileJMenu.add(this.saveAsJMenuItem);
        this.exportJMenuItem1.setText("Export");
        this.exportJMenuItem1.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                exportJMenuItem1ActionPerformed(evt);
            }

#endif
);
        this.fileJMenu.add(this.exportJMenuItem1);
        this.exitJMenuItem.setText("Exit");
        this.exitJMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                exitJMenuItemActionPerformed(evt);
            }

#endif
);
        this.fileJMenu.add(this.exitJMenuItem);
        this.menuJMenuBar.add(this.fileJMenu);
        this.viewJMenu.setText("View");
        this.zoomInJMenuItem.setText("Zoom In");
        this.zoomInJMenuItem.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                zoomInJMenuItemMousePressed(evt);
            }

#endif
);
        this.viewJMenu.add(this.zoomInJMenuItem);
        this.zoomOutJMenuItem.setText("Zoom Out");
        this.zoomOutJMenuItem.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                zoomOutJMenuItemMousePressed(evt);
            }

#endif
);
        this.viewJMenu.add(this.zoomOutJMenuItem);
        this.menuJMenuBar.add(this.viewJMenu);
        this.objectJMenu.setText("Objects");
        this.explodeAllJMenuItem.setText("Explode All");
        this.explodeAllJMenuItem.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                explodeAllJMenuItemMousePressed(evt);
            }

#endif
);
        this.objectJMenu.add(this.explodeAllJMenuItem);
        this.menuJMenuBar.add(this.objectJMenu);
        this.frameJMenu.setText("Frame");
        this.frameJMenu.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                frameJMenuActionPerformed(evt);
            }

#endif
);
        this.previousFrameJMenuItem.setText("Previous");
        this.frameJMenu.add(this.previousFrameJMenuItem);
        this.nextFrameJMenuItem.setText(CommonLabels.getInstance().NEXT);
        this.frameJMenu.add(this.nextFrameJMenuItem);
        this.removeJMenuItem.setText("Remove");
        this.frameJMenu.add(this.removeJMenuItem);
        this.copyJMenuItem1.setText("Copy");
        this.frameJMenu.add(this.copyJMenuItem1);
        this.insertAfterJMenuItem.setText("Ins After");
        this.frameJMenu.add(this.insertAfterJMenuItem);
        this.insertBeforeJMenuItem.setText("Ins Before");
        this.frameJMenu.add(this.insertBeforeJMenuItem);
        this.menuJMenuBar.add(this.frameJMenu);
        this.generateJMenu.setText("Generate");
        this.centerJMenuItem.setText("Center");
        this.centerJMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                centerJMenuItemActionPerformed(evt);
            }

#endif
);
        this.generateJMenu.add(this.centerJMenuItem);
        this.autoDamageJMenuItem.setText("Damage");
        this.generateJMenu.add(this.autoDamageJMenuItem);
        this.autoExplodeJMenuItem.setText("Explode");
        this.autoExplodeJMenuItem.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                autoExplodeJMenuItemMousePressed(evt);
            }

#endif
);
        this.generateJMenu.add(this.autoExplodeJMenuItem);
        this.autoGrowJMenuItem.setText("Grow");
        this.generateJMenu.add(this.autoGrowJMenuItem);
        this.jMenuItem1.setText("Mirror");
        this.jMenuItem1.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                jMenuItem1ActionPerformed(evt);
            }

#endif
);
        this.generateJMenu.add(this.jMenuItem1);
        this.autoRotateGenerationJMenuItem.setText("Rotate");
        this.autoRotateGenerationJMenuItem.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                autoRotateGenerationJMenuItemMousePressed(evt);
            }

#endif
);
        this.generateJMenu.add(this.autoRotateGenerationJMenuItem);
        this.autoSheildMenuItem.setText("Shield");
        this.generateJMenu.add(this.autoSheildMenuItem);
        this.autoShrinkJMenuItem.setText("Shrink");
        this.generateJMenu.add(this.autoShrinkJMenuItem);
        this.menuJMenuBar.add(this.generateJMenu);
        this.jMenu1.setText("Help");
        this.menuJMenuBar.add(this.jMenu1);
        setJMenuBar(this.menuJMenuBar);
        pack();
    }

    private void explodeAllJMenuItemMousePressed(java.awt.event.MouseEvent evt)
    {
        try {
            MyCanvasEventService.fire(new MyCanvasEvent(((object) new MyCanvasEventSource(MyCanvasEventService.EXPLODE, null))));
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "explodeAllJMenuItemMousePressed", e);
        }
    }

    private void autoExplodeJMenuItemMousePressed(java.awt.event.MouseEvent evt)
    {
        try {
            MyCanvasEventService.fire(new MyCanvasEvent(((object) new MyCanvasEventSource(MyCanvasEventService.AUTOEXPLODE, null))));
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "autoExplodeJMenuItemMousePressed", e);
        }
    }

    private void stopJjButtonMousePressed(java.awt.event.MouseEvent evt)
    {
        this.getSelectedWorkArea().stop();
    }

    private void playJButtonMousePressed(java.awt.event.MouseEvent evt)
    {
        this.getSelectedWorkArea().play();
    }

    private void autoRotateGenerationJMenuItemMousePressed(java.awt.event.MouseEvent evt)
    {
        this.rotateJDialog.setVisible(true);
    }

    private void zoomOutJMenuItemMousePressed(java.awt.event.MouseEvent evt)
    {
        this.getSelectedWorkArea().changeZoom(-1);
    }

    private void zoomInJMenuItemMousePressed(java.awt.event.MouseEvent evt)
    {
        this.getSelectedWorkArea().changeZoom(1);
    }

    private void openJMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.openGraphics();
    }

    private void exportJMenuItem1ActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.export();
    }

    private void saveJMenuItemMousePressed(java.awt.event.MouseEvent evt)
    {
        this.save();
    }

    private void jTabbedPaneStateChanged(javax.swing.event.ChangeEvent evt)
    {
        this.updateSelectedWorkArea();
    }

    private void frameJMenuActionPerformed(java.awt.event.ActionEvent evt)
    {
    }

    private void exitJMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        Environment.Exit(0);
    }

    private void newJMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.newGraphics();
    }

    private void fileJMenuActionPerformed(java.awt.event.ActionEvent evt)
    {
    }

    private void exitForm(java.awt.event.WindowEvent evt)
    {
        Environment.Exit(0);
    }

    private void openJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.openGraphics();
    }

    private void jButton2ActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.newGraphics();
    }

    private void centerJMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            MyCanvasEventService.fire(new MyCanvasEvent(((object) new MyCanvasEventSource(MyCanvasEventService.CENTER, null))));
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "centerJMenuItemActionPerformed", e);
        }
    }

    private void saveJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.save();
    }

    private void jButton1ActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.export();
    }

    private void jMenuItem1ActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            this.getSelectedWorkArea().autoMirror();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "centerJMenuItemActionPerformed", e);
        }
    }

    public virtual void onFiles(File[] files)
    {
        try {
            this.logUtil.putF("Reading: " + files, this, "onFiles");
            for (int index = 0; index < files.Length; index++) {
                Document document = DomHelper.getInstance().createDocument(files[index]);
                WorkAreaJPanel workAreaJPanel = new WorkAreaJPanel(new WorkAreaDom(document), this.getSize());
                workAreaJPanel.setLayout(new GridLayout(1, 1));
                this.add(((WorkAreaJPanelInterface) workAreaJPanel));
            }
            this.fileJDialog.setVisible(false);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "onFiles", e);
        }
    }

    private void newGraphics()
    {
        try {
            string newName = "graphic" + MyFrame.numberOfWorkAreas;
            Dimension dim = this.getSize();
            NewWorkAreaJDialog newDialog = new NewWorkAreaJDialog(this, false, dim, newName);
        } catch (Exception e) {
            if (LOGGING.contains(LOGGING.MENUEVENT)) {
                this.guiLog.put(this.commonStrings.EXCEPTION, this, "newJMenuItemActionPerformed", e);
            }
        }
    }

    private void openGraphics()
    {
        try {
            this.logUtil.putF("Starting", this, "openImageJMenuItemActionPerformed");
            this.fileJDialog.setVisible(true);
        } catch (Exception e) {
            if (LOGGING.contains(LOGGING.MENUEVENT)) {
                this.guiLog.put(this.commonStrings.EXCEPTION, this, "open", e);
            }
        }
    }

    private void export()
    {
        try {
            WorkAreaJPanelInterface workAreaJPanel = ((WorkAreaJPanelInterface) this.jTabbedPane.getSelectedComponent());
            File file = new File(this.SAVE_PATH + "/" + workAreaJPanel.getName() + this.JAVAEXTENSION);
            Document document = workAreaJPanel.toDocument();
            this.logUtil.putF("Export: " + DomHelper.getInstance().toString(document), this, "exportJMenuItem1ActionPerformed");
            this.xslHelper.export(file, MyFrame.TEMPLATE_EXPORT_PATH + "/" + this.JAVA_TEMPLATE, document);
        } catch (Exception e) {
            if (LOGGING.contains(LOGGING.MENUEVENT)) {
                this.guiLog.put(this.commonStrings.EXCEPTION, this, "export", e);
            }
        }
    }

    private void save()
    {
        try {
            WorkAreaJPanelInterface workAreaJPanel = ((WorkAreaJPanelInterface) this.jTabbedPane.getSelectedComponent());
            DomHelper.getInstance().save(new File(this.SAVE_PATH + "/" + workAreaJPanel.getName() + this.SAVEEXTENSION), workAreaJPanel.toDocument());
        } catch (Exception e) {
            if (LOGGING.contains(LOGGING.MENUEVENT)) {
                this.guiLog.put(this.commonStrings.EXCEPTION, this, this.commonStrings.SAVE, e);
            }
        }
    }

    // throws Exception
    public virtual void onHashMap(HashMap<object, object> hashMap)
    {
        int? angleIncrementInteger = ((int?) hashMap.get((0).ToString()));
        int? totalRotationInteger = ((int?) hashMap.get((1).ToString()));
        this.getSelectedWorkArea().autoRotate(((int) angleIncrementInteger), ((int) totalRotationInteger));
    }

    private WorkAreaJPanelInterface getSelectedWorkArea()
    {
        return ((WorkAreaJPanelInterface) this.jTabbedPane.getSelectedComponent());
    }

    public virtual void updateSelectedWorkArea()
    {
        int numberOfTabs = this.jTabbedPane.getTabCount();
        for (int index = 0; index < numberOfTabs; index++) {
            WorkAreaJPanelInterface workAreaJPanel = ((WorkAreaJPanelInterface) this.jTabbedPane.getComponentAt(index));
            workAreaJPanel.deselect();
        }
        WorkAreaJPanelInterface workAreaJPanel = ((WorkAreaJPanelInterface) this.jTabbedPane.getSelectedComponent());
        if (workAreaJPanel != null) {
            workAreaJPanel.select();
        }
    }

    // throws Exception
    public virtual void add(WorkAreaJPanelInterface newCanvasInterface)
    {
        try {
            this.numberOfWorkAreas++;
            if (this.numberOfWorkAreas == MyFrame.MAXWORKAREAS) {
                throw new Exception();
            }
            this.jTabbedPane.addTab(newCanvasInterface.getName(), ((JPanel) newCanvasInterface));
            this.jTabbedPane.setSelectedComponent(((JPanel) newCanvasInterface));
            global::org.allbinary.thread.NullThread animationThread = new global::org.allbinary.thread.NullThread(((global::java.lang.Runnable) newCanvasInterface));
            animationThread.start();
            this.updateSelectedWorkArea();
        } catch (Exception e) {
            if (LOGGING.contains(LOGGING.GRAPHICSCREATION)) {
                this.guiLog.put(this.commonStrings.EXCEPTION, this, "addNewCanvas", e);
            }
        }
    }

    public virtual void keyPressed(java.awt.event.KeyEvent keyEvent)
    {
        this.getSelectedWorkArea().keyPressed(keyEvent);
    }

    public virtual void keyReleased(java.awt.event.KeyEvent keyEvent)
    {
    }

    public virtual void keyTyped(java.awt.event.KeyEvent keyEvent)
    {
    }

    public static void main(string[] args)
    {
        try {
            AngleFactory.getInstance();
            SmallIntegerSingletonFactory.getInstance().init();
            new MyFrame().show();
        } catch (Exception e) {
            LogUtil logUtil = LogUtil.getInstance();
            logUtil.put(CommonStrings.getInstance().EXCEPTION, null, "main", e);
        }
    }

    private javax.swing.JButton animateJButton = null;
    private javax.swing.JMenuItem autoDamageJMenuItem = null;
    private javax.swing.JMenuItem autoExplodeJMenuItem = null;
    private javax.swing.JMenuItem autoGrowJMenuItem = null;
    private javax.swing.JMenuItem autoRotateGenerationJMenuItem = null;
    private javax.swing.JMenuItem autoSheildMenuItem = null;
    private javax.swing.JMenuItem autoShrinkJMenuItem = null;
    private javax.swing.JMenuItem centerJMenuItem = null;
    private javax.swing.JMenuItem copyJMenuItem1 = null;
    private javax.swing.JMenuItem exitJMenuItem = null;
    private javax.swing.JMenuItem explodeAllJMenuItem = null;
    private javax.swing.JMenuItem exportJMenuItem1 = null;
    private javax.swing.JMenu fileJMenu = null;
    private javax.swing.JMenu frameJMenu = null;
    private javax.swing.JMenu generateJMenu = null;
    private javax.swing.JMenuItem insertAfterJMenuItem = null;
    private javax.swing.JMenuItem insertBeforeJMenuItem = null;
    private javax.swing.JButton jButton1 = null;
    private javax.swing.JButton jButton2 = null;
    private javax.swing.JButton jButton3 = null;
    private javax.swing.JButton jButton4 = null;
    private javax.swing.JButton jButton41 = null;
    private javax.swing.JButton jButton5 = null;
    private javax.swing.JMenu jMenu1 = null;
    private javax.swing.JMenuItem jMenuItem1 = null;
    private javax.swing.JPanel jPanel1 = null;
    private javax.swing.JTabbedPane jTabbedPane = null;
    private javax.swing.JToolBar jToolBar1 = null;
    private javax.swing.JPanel mainJPanel = null;
    private javax.swing.JMenuBar menuJMenuBar = null;
    private javax.swing.JMenuItem newJMenuItem = null;
    private javax.swing.JMenuItem nextFrameJMenuItem = null;
    private javax.swing.JMenu objectJMenu = null;
    private javax.swing.JButton openJButton = null;
    private javax.swing.JMenuItem openJMenuItem = null;
    private javax.swing.JButton playJButton = null;
    private javax.swing.JMenuItem previousFrameJMenuItem = null;
    private javax.swing.JMenuItem removeJMenuItem = null;
    private javax.swing.JMenuItem saveAsJMenuItem = null;
    private javax.swing.JButton saveJButton = null;
    private javax.swing.JMenuItem saveJMenuItem = null;
    public static javax.swing.JLabel statusJLabel = null;
    private javax.swing.JPanel statusJPanel = null;
    private javax.swing.JButton stopJjButton = null;
    private javax.swing.JMenu viewJMenu = null;
    private javax.swing.JMenuItem zoomInJMenuItem = null;
    private javax.swing.JMenuItem zoomOutJMenuItem = null;
}

