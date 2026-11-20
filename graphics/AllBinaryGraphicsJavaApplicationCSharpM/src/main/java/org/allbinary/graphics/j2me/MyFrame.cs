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
using java.awt;
using File = java.io.File;
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
//using BorderLayout = java.awt.BorderLayout;
//using Dimension = java.awt.Dimension;
//using GridLayout = java.awt.GridLayout;
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
using KeyEvent = java.awt.@event.KeyEvent;
//using KeyListener = java.awt.@event.KeyListener;
//using MouseAdapter = java.awt.@event.MouseAdapter;
//using MouseEvent = java.awt.@event.MouseEvent;
//using WindowAdapter = java.awt.@event.WindowAdapter;
//using WindowEvent = java.awt.@event.WindowEvent;
//using JButton = javax.swing.JButton;
//using JFrame = javax.swing.JFrame;
//using JLabel = javax.swing.JLabel;
//using JMenu = javax.swing.JMenu;
//using JMenuBar = javax.swing.JMenuBar;
//using JMenuItem = javax.swing.JMenuItem;
//using JPanel = javax.swing.JPanel;
//using JTabbedPane = javax.swing.JTabbedPane;
//using JToolBar = javax.swing.JToolBar;
//using ChangeEvent = javax.swing.@event.ChangeEvent;
//using ChangeListener = javax.swing.@event.ChangeListener;

namespace org.allbinary.graphics.j2me;

public class MyFrame : JFrame, FileJDialogListenerInterface, HashMapJDialogListenerInterface, KeyListener
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private readonly GuiLog guiLog = GuiLog.getInstance();
    private readonly XslHelper xslHelper = XslHelper.getInstance();
    private const int MAXWORKAREAS = 10;
    private static int numberOfWorkAreas = 0;
    private readonly string JAVA_TEMPLATE = "svgExport.xsl";
    private readonly string SAVEEXTENSION = ".gxml";
    private readonly string JAVAEXTENSION = ".javax";
    private const string PATH = "G:/mnt/bc/mydev/work/graphics/AllBinaryGraphicsJavaApplication";
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
        jToolBar1 = new JToolBar();
        this.jButton2 = new JButton();
        this.saveJButton = new JButton();
        this.jButton1 = new JButton();
        this.openJButton = new JButton();
        this.jButton3 = new JButton();
        this.jButton4 = new JButton();
        this.jButton41 = new JButton();
        this.jButton5 = new JButton();
        this.animateJButton = new JButton();
        this.playJButton = new JButton();
        this.stopJjButton = new JButton();
        this.jPanel1 = new JPanel();
        this.mainJPanel = new JPanel();
        this.jTabbedPane = new JTabbedPane();
        this.statusJPanel = new JPanel();
        MyFrame.statusJLabel = new JLabel();
        this.menuJMenuBar = new JMenuBar();
        this.fileJMenu = new JMenu();
        this.newJMenuItem = new JMenuItem();
        this.openJMenuItem = new JMenuItem();
        this.saveJMenuItem = new JMenuItem();
        this.saveAsJMenuItem = new JMenuItem();
        this.exportJMenuItem1 = new JMenuItem();
        this.exitJMenuItem = new JMenuItem();
        this.viewJMenu = new JMenu();
        this.zoomInJMenuItem = new JMenuItem();
        this.zoomOutJMenuItem = new JMenuItem();
        this.objectJMenu = new JMenu();
        this.explodeAllJMenuItem = new JMenuItem();
        this.frameJMenu = new JMenu();
        this.previousFrameJMenuItem = new JMenuItem();
        this.nextFrameJMenuItem = new JMenuItem();
        this.removeJMenuItem = new JMenuItem();
        this.copyJMenuItem1 = new JMenuItem();
        this.insertAfterJMenuItem = new JMenuItem();
        this.insertBeforeJMenuItem = new JMenuItem();
        this.generateJMenu = new JMenu();
        this.centerJMenuItem = new JMenuItem();
        this.autoDamageJMenuItem = new JMenuItem();
        this.autoExplodeJMenuItem = new JMenuItem();
        this.autoGrowJMenuItem = new JMenuItem();
        this.jMenuItem1 = new JMenuItem();
        this.autoRotateGenerationJMenuItem = new JMenuItem();
        this.autoSheildMenuItem = new JMenuItem();
        this.autoShrinkJMenuItem = new JMenuItem();
        this.jMenu1 = new JMenu();
        addWindowListener(new WindowAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void windowClosing(WindowEvent evt)
            {
                exitForm(evt);
            }

#endif
);
        this.jButton2.setText("New");
        this.jButton2.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                jButton2ActionPerformed(evt);
            }

#endif
);
        this.jToolBar1.add(this.jButton2);
        this.saveJButton.setText("Save");
        this.saveJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                saveJButtonActionPerformed(evt);
            }

#endif
);
        this.jToolBar1.add(this.saveJButton);
        this.jButton1.setText("Export");
        this.jButton1.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                jButton1ActionPerformed(evt);
            }

#endif
);
        this.jToolBar1.add(this.jButton1);
        this.openJButton.setText("Open");
        this.openJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
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
        this.playJButton.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                playJButtonMousePressed(evt);
            }

#endif
);
        this.jToolBar1.add(this.playJButton);
        this.stopJjButton.setText("Stop");
        this.stopJjButton.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                stopJjButtonMousePressed(evt);
            }

#endif
);
        this.jToolBar1.add(this.stopJjButton);
        getContentPane().add(this.jToolBar1, BorderLayout.NORTH);
        this.jPanel1.setLayout(new GridLayout(1, 0));
        this.mainJPanel.setLayout(new GridLayout(1, 0));
        this.jTabbedPane.setMinimumSize(new Dimension(550, 400));
        this.jTabbedPane.addChangeListener(new ChangeListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void stateChanged(ChangeEvent evt)
            {
                jTabbedPaneStateChanged(evt);
            }

#endif
);
        this.mainJPanel.add(this.jTabbedPane);
        this.jPanel1.add(this.mainJPanel);
        getContentPane().add(this.jPanel1, BorderLayout.CENTER);
        this.statusJPanel.setLayout(new GridLayout(1, 0));
        MyFrame.statusJLabel.setText("Status Bar");
        this.statusJPanel.add(MyFrame.statusJLabel);
        getContentPane().add(this.statusJPanel, BorderLayout.SOUTH);
        this.fileJMenu.setText("File");
        this.fileJMenu.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                fileJMenuActionPerformed(evt);
            }

#endif
);
        this.newJMenuItem.setText("New");
        this.newJMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                newJMenuItemActionPerformed(evt);
            }

#endif
);
        this.fileJMenu.add(this.newJMenuItem);
        this.openJMenuItem.setText("Open");
        this.openJMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                openJMenuItemActionPerformed(evt);
            }

#endif
);
        this.fileJMenu.add(this.openJMenuItem);
        this.saveJMenuItem.setText("Save");
        this.saveJMenuItem.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                saveJMenuItemMousePressed(evt);
            }

#endif
);
        this.fileJMenu.add(this.saveJMenuItem);
        this.saveAsJMenuItem.setText("SaveAs");
        this.fileJMenu.add(this.saveAsJMenuItem);
        this.exportJMenuItem1.setText("Export");
        this.exportJMenuItem1.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                exportJMenuItem1ActionPerformed(evt);
            }

#endif
);
        this.fileJMenu.add(this.exportJMenuItem1);
        this.exitJMenuItem.setText("Exit");
        this.exitJMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                exitJMenuItemActionPerformed(evt);
            }

#endif
);
        this.fileJMenu.add(this.exitJMenuItem);
        this.menuJMenuBar.add(this.fileJMenu);
        this.viewJMenu.setText("View");
        this.zoomInJMenuItem.setText("Zoom In");
        this.zoomInJMenuItem.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                zoomInJMenuItemMousePressed(evt);
            }

#endif
);
        this.viewJMenu.add(this.zoomInJMenuItem);
        this.zoomOutJMenuItem.setText("Zoom Out");
        this.zoomOutJMenuItem.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                zoomOutJMenuItemMousePressed(evt);
            }

#endif
);
        this.viewJMenu.add(this.zoomOutJMenuItem);
        this.menuJMenuBar.add(this.viewJMenu);
        this.objectJMenu.setText("Objects");
        this.explodeAllJMenuItem.setText("Explode All");
        this.explodeAllJMenuItem.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                explodeAllJMenuItemMousePressed(evt);
            }

#endif
);
        this.objectJMenu.add(this.explodeAllJMenuItem);
        this.menuJMenuBar.add(this.objectJMenu);
        this.frameJMenu.setText("Frame");
        this.frameJMenu.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
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
        this.centerJMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                centerJMenuItemActionPerformed(evt);
            }

#endif
);
        this.generateJMenu.add(this.centerJMenuItem);
        this.autoDamageJMenuItem.setText("Damage");
        this.generateJMenu.add(this.autoDamageJMenuItem);
        this.autoExplodeJMenuItem.setText("Explode");
        this.autoExplodeJMenuItem.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                autoExplodeJMenuItemMousePressed(evt);
            }

#endif
);
        this.generateJMenu.add(this.autoExplodeJMenuItem);
        this.autoGrowJMenuItem.setText("Grow");
        this.generateJMenu.add(this.autoGrowJMenuItem);
        this.jMenuItem1.setText("Mirror");
        this.jMenuItem1.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                jMenuItem1ActionPerformed(evt);
            }

#endif
);
        this.generateJMenu.add(this.jMenuItem1);
        this.autoRotateGenerationJMenuItem.setText("Rotate");
        this.autoRotateGenerationJMenuItem.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
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

    private void explodeAllJMenuItemMousePressed(MouseEvent evt)
    {
        try {
            MyCanvasEventService.fire(new MyCanvasEvent(((object) new MyCanvasEventSource(MyCanvasEventService.EXPLODE, null))));
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "explodeAllJMenuItemMousePressed", e);
        }
    }

    private void autoExplodeJMenuItemMousePressed(MouseEvent evt)
    {
        try {
            MyCanvasEventService.fire(new MyCanvasEvent(((object) new MyCanvasEventSource(MyCanvasEventService.AUTOEXPLODE, null))));
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "autoExplodeJMenuItemMousePressed", e);
        }
    }

    private void stopJjButtonMousePressed(MouseEvent evt)
    {
        this.getSelectedWorkArea().stop();
    }

    private void playJButtonMousePressed(MouseEvent evt)
    {
        this.getSelectedWorkArea().play();
    }

    private void autoRotateGenerationJMenuItemMousePressed(MouseEvent evt)
    {
        this.rotateJDialog.setVisible(true);
    }

    private void zoomOutJMenuItemMousePressed(MouseEvent evt)
    {
        this.getSelectedWorkArea().changeZoom(-1);
    }

    private void zoomInJMenuItemMousePressed(MouseEvent evt)
    {
        this.getSelectedWorkArea().changeZoom(1);
    }

    private void openJMenuItemActionPerformed(ActionEvent evt)
    {
        this.openGraphics();
    }

    private void exportJMenuItem1ActionPerformed(ActionEvent evt)
    {
        this.export();
    }

    private void saveJMenuItemMousePressed(MouseEvent evt)
    {
        this.save();
    }

    private void jTabbedPaneStateChanged(ChangeEvent evt)
    {
        this.updateSelectedWorkArea();
    }

    private void frameJMenuActionPerformed(ActionEvent evt)
    {
    }

    private void exitJMenuItemActionPerformed(ActionEvent evt)
    {
        Environment.Exit(0);
    }

    private void newJMenuItemActionPerformed(ActionEvent evt)
    {
        this.newGraphics();
    }

    private void fileJMenuActionPerformed(ActionEvent evt)
    {
    }

    private void exitForm(WindowEvent evt)
    {
        Environment.Exit(0);
    }

    private void openJButtonActionPerformed(ActionEvent evt)
    {
        this.openGraphics();
    }

    private void jButton2ActionPerformed(ActionEvent evt)
    {
        this.newGraphics();
    }

    private void centerJMenuItemActionPerformed(ActionEvent evt)
    {
        try {
            MyCanvasEventService.fire(new MyCanvasEvent(((object) new MyCanvasEventSource(MyCanvasEventService.CENTER, null))));
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "centerJMenuItemActionPerformed", e);
        }
    }

    private void saveJButtonActionPerformed(ActionEvent evt)
    {
        this.save();
    }

    private void jButton1ActionPerformed(ActionEvent evt)
    {
        this.export();
    }

    private void jMenuItem1ActionPerformed(ActionEvent evt)
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
        int? angleIncrementInteger = ((int?) hashMap.get(int.Parse((0).ToString())));
        int? totalRotationInteger = ((int?) hashMap.get(int.Parse((1).ToString())));
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

    public virtual void keyPressed(KeyEvent keyEvent)
    {
        this.getSelectedWorkArea().keyPressed(keyEvent);
    }

    public virtual void keyReleased(KeyEvent keyEvent)
    {
    }

    public virtual void keyTyped(KeyEvent keyEvent)
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

    private JButton animateJButton = null;
    private JMenuItem autoDamageJMenuItem = null;
    private JMenuItem autoExplodeJMenuItem = null;
    private JMenuItem autoGrowJMenuItem = null;
    private JMenuItem autoRotateGenerationJMenuItem = null;
    private JMenuItem autoSheildMenuItem = null;
    private JMenuItem autoShrinkJMenuItem = null;
    private JMenuItem centerJMenuItem = null;
    private JMenuItem copyJMenuItem1 = null;
    private JMenuItem exitJMenuItem = null;
    private JMenuItem explodeAllJMenuItem = null;
    private JMenuItem exportJMenuItem1 = null;
    private JMenu fileJMenu = null;
    private JMenu frameJMenu = null;
    private JMenu generateJMenu = null;
    private JMenuItem insertAfterJMenuItem = null;
    private JMenuItem insertBeforeJMenuItem = null;
    private JButton jButton1 = null;
    private JButton jButton2 = null;
    private JButton jButton3 = null;
    private JButton jButton4 = null;
    private JButton jButton41 = null;
    private JButton jButton5 = null;
    private JMenu jMenu1 = null;
    private JMenuItem jMenuItem1 = null;
    private JPanel jPanel1 = null;
    private JTabbedPane jTabbedPane = null;
    private JToolBar jToolBar1 = null;
    private JPanel mainJPanel = null;
    private JMenuBar menuJMenuBar = null;
    private JMenuItem newJMenuItem = null;
    private JMenuItem nextFrameJMenuItem = null;
    private JMenu objectJMenu = null;
    private JButton openJButton = null;
    private JMenuItem openJMenuItem = null;
    private JButton playJButton = null;
    private JMenuItem previousFrameJMenuItem = null;
    private JMenuItem removeJMenuItem = null;
    private JMenuItem saveAsJMenuItem = null;
    private JButton saveJButton = null;
    private JMenuItem saveJMenuItem = null;
    public static JLabel statusJLabel = null;
    private JPanel statusJPanel = null;
    private JButton stopJjButton = null;
    private JMenu viewJMenu = null;
    private JMenuItem zoomInJMenuItem = null;
    private JMenuItem zoomOutJMenuItem = null;
}

