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
using ARunnable = org.allbinary.thread.ARunnable;
//using URI = java.net.URI;
//using URL = java.net.URL;
//using Desktop = java.awt.Desktop;
//using java.util;
//using ImageIcon = javax.swing.ImageIcon;
//using JDialog = javax.swing.JDialog;
//using HelpSet = javax.help.HelpSet;
//using HelpSetEvent = javax.help.@event.HelpSetEvent;
//using HelpSetListener = javax.help.@event.HelpSetListener;
using InputAutomationBundleActivatorListenerInterface = bundle.input.automation.InputAutomationBundleActivatorListenerInterface;
using InputAutomationConfigurationModuleChangeListener = bundle.input.automation.module.configuration.InputAutomationConfigurationModuleChangeListener;
using InputAutomationRobotChangeListener = bundle.input.automation.robot.InputAutomationRobotChangeListener;
using AppUrlGlobals = org.allbinary.globals.AppUrlGlobals;
using URLGLOBALS = org.allbinary.globals.URLGLOBALS;
using BasicTextJDialog = org.allbinary.gui.dialog.BasicTextJDialog;
using JListSwingWorker = org.allbinary.gui.swing.workers.JListSwingWorker;
using InputAutomationConfiguration = org.allbinary.input.automation.configuration.InputAutomationConfiguration;
using InputAutomationConfigurationFactory = org.allbinary.input.automation.configuration.InputAutomationConfigurationFactory;
using InputAutomationConfigurationModuleChangeEvent = org.allbinary.input.automation.configuration.InputAutomationConfigurationModuleChangeEvent;
using InputAutomationModuleFactoryFactory = org.allbinary.input.automation.module.InputAutomationModuleFactoryFactory;
using InputAutomationModuleFactoryInterface = org.allbinary.input.automation.module.InputAutomationModuleFactoryInterface;
using InputAutomationModuleConfiguration = org.allbinary.input.automation.module.configuration.InputAutomationModuleConfiguration;
using InputAutomationModuleConfigurations = org.allbinary.input.automation.module.configuration.InputAutomationModuleConfigurations;
using DesktopBundle = org.allbinary.input.automation.osgi.DesktopBundle;
using InputRobotFactory = org.allbinary.input.automation.robot.InputRobotFactory;
using InputAutomationRobotChangeEvent = org.allbinary.input.automation.robot.osgi.InputAutomationRobotChangeEvent;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using JavaHelpUtil = org.allbinary.logic.java.help.JavaHelpUtil;
using WebappClassLoaderInfo = org.allbinary.logic.system.loader.WebappClassLoaderInfo;
using InputAutomationClientInformationFactory = org.allbinary.logic.system.security.licensing.InputAutomationClientInformationFactory;
using CommonStrings = org.allbinary.@string.CommonStrings;
using RunnableInterface = org.allbinary.thread.RunnableInterface;

namespace org.allbinary.input.automation;

public class InputAutomationJFrame : javax.swing.JFrame, InputAutomationConfigurationModuleChangeListener, InputAutomationRobotChangeListener, HelpSetListener
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private InputAutomationModuleConfigurations inputAutomationModuleConfigurations = new InputAutomationModuleConfigurations();
    private InputAutomationModuleFactoryFactory inputAutomationModuleFactory = null;
    private InputAutomationModuleFactoryInterface inputAutomationModuleInterface = null;
    private RunnableInterface runnableInterface = null;
    private global::org.allbinary.thread.NullThread thread = null;
    private HelpSet helpSet;
    private readonly URI uri = new URI("http://geocities.com/allbinary/");
    public InputAutomationJFrame()
    {
        this.initComponents();
        URL url = this.GetType().getResource("/help/Help.hs");
        this.logUtil.putF("URL: " + url, this, this.commonStrings.CONSTRUCTOR);
        this.helpSet = JavaHelpUtil.getInstance().getHelpSet(url);
        url = this.GetType().getResource("/resources/allbinaryicon8bit.jpg");
        ImageIcon imageIcon = new ImageIcon(url);
        this.setIconImage(imageIcon.getImage());
        this.init();
    }

    public virtual void helpSetAdded(HelpSetEvent helpSetEvent)
    {
        this.helpSet.add(helpSetEvent.getHelpSet());
    }

    public virtual void helpSetRemoved(HelpSetEvent helpSetEvent)
    {
        this.helpSet.remove(helpSetEvent.getHelpSet());
    }

    // throws Exception
    private void init()
    {
        InputAutomationConfigurationFactory inputAutomationConfigurationFactory = InputAutomationConfigurationFactory.getInstance();
        inputAutomationConfigurationFactory.init(InputAutomationClientInformationFactory.getInstance());
        List<InputAutomationModuleConfiguration> inputAutomationModuleConfigurationList = inputAutomationConfigurationFactory.inputAutomationConfiguration.getInputAutomationModuleConfigurationList();
        if (inputAutomationModuleConfigurationList == null) {
        } else {
            this.inputAutomationModuleConfigurations = new InputAutomationModuleConfigurations(inputAutomationModuleConfigurationList);
        }
        this.inputAutomationModuleFactory = new InputAutomationModuleFactoryFactory(inputAutomationModuleConfigurations, this);
        (new JListSwingWorker(this.inputAutomationModuleJList, this.inputAutomationModuleFactory.getListModel())).execute();
        this.gameRobotJTabbedPane.setEnabledAt(1, false);
        this.gameRobotJTabbedPane.setSelectedIndex(0);
    }

    private void initComponents()
    {
        this.noModuleSelectedJDialog = new javax.swing.JDialog();
        this.noModuleSelectedJLabel = new javax.swing.JLabel();
        this.gameRobotJTabbedPane = new javax.swing.JTabbedPane();
        this.inputAutomationModuleJPanel = new javax.swing.JPanel();
        this.jScrollPane1 = new javax.swing.JScrollPane();
        this.inputAutomationModuleJList = new javax.swing.JList();
        this.automationModuleConfigurationJPanel = new javax.swing.JPanel();
        this.mainJMenuBar = new javax.swing.JMenuBar();
        this.processingJMenu = new javax.swing.JMenu();
        this.startJMenuItem = new javax.swing.JMenuItem();
        this.stopJMenuItem = new javax.swing.JMenuItem();
        this.optionsJMenu = new javax.swing.JMenu();
        this.stopOnFocusJCheckBoxMenuItem = new javax.swing.JCheckBoxMenuItem();
        this.toolsJMenu = new javax.swing.JMenu();
        this.helpJMenuItem = new javax.swing.JMenuItem();
        this.updatesJMenuItem = new javax.swing.JMenuItem();
        this.subscriptionJMenuItem = new javax.swing.JMenuItem();
        this.modulesJMenuItem = new javax.swing.JMenuItem();
        this.aboutJMenuItem = new javax.swing.JMenuItem();
        this.noModuleSelectedJDialog.setMinimumSize(new java.awt.Dimension(200, 100));
        this.noModuleSelectedJLabel.setText("Please Select A Module");
        javax.swing.GroupLayout noModuleSelectedJDialogLayout = new javax.swing.GroupLayout(this.noModuleSelectedJDialog.getContentPane());
        this.noModuleSelectedJDialog.getContentPane().setLayout(noModuleSelectedJDialogLayout);
        noModuleSelectedJDialogLayout.setHorizontalGroup(noModuleSelectedJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(noModuleSelectedJDialogLayout.createSequentialGroup().addContainerGap().addComponent(noModuleSelectedJLabel).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, short.MaxValue)));
        noModuleSelectedJDialogLayout.setVerticalGroup(noModuleSelectedJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(noModuleSelectedJLabel, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, 48, short.MaxValue));
        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        this.setMinimumSize(new java.awt.Dimension(325, 215));
        setResizable(false);
        addWindowFocusListener(new java.awt.event.WindowFocusListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void windowGainedFocus(java.awt.event.WindowEvent evt)
            {
                formWindowGainedFocus(evt);
            }

            public virtual void windowLostFocus(java.awt.event.WindowEvent evt)
            {
                formWindowLostFocus(evt);
            }

#endif
);
        addFocusListener(new java.awt.event.FocusAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void focusGained(java.awt.event.FocusEvent evt)
            {
                formFocusGained(evt);
            }

            public virtual void focusLost(java.awt.event.FocusEvent evt)
            {
                formFocusLost(evt);
            }

#endif
);
        this.gameRobotJTabbedPane.setMinimumSize(new java.awt.Dimension(320, 200));
        this.inputAutomationModuleJList.setMinimumSize(new java.awt.Dimension(200, 0));
        this.inputAutomationModuleJList.addListSelectionListener(new javax.swing.event.ListSelectionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void valueChanged(javax.swing.event.ListSelectionEvent evt)
            {
                inputAutomationModuleJListValueChanged(evt);
            }

#endif
);
        this.jScrollPane1.setViewportView(this.inputAutomationModuleJList);
        javax.swing.GroupLayout inputAutomationModuleJPanelLayout = new javax.swing.GroupLayout(this.inputAutomationModuleJPanel);
        this.inputAutomationModuleJPanel.setLayout(inputAutomationModuleJPanelLayout);
        inputAutomationModuleJPanelLayout.setHorizontalGroup(inputAutomationModuleJPanelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(inputAutomationModuleJPanelLayout.createSequentialGroup().addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 199, javax.swing.GroupLayout.PREFERRED_SIZE).addContainerGap(367, short.MaxValue)));
        inputAutomationModuleJPanelLayout.setVerticalGroup(inputAutomationModuleJPanelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(inputAutomationModuleJPanelLayout.createSequentialGroup().addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 330, javax.swing.GroupLayout.PREFERRED_SIZE).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, short.MaxValue)));
        this.gameRobotJTabbedPane.addTab("Modules", inputAutomationModuleJPanel);
        javax.swing.GroupLayout automationModuleConfigurationJPanelLayout = new javax.swing.GroupLayout(this.automationModuleConfigurationJPanel);
        this.automationModuleConfigurationJPanel.setLayout(automationModuleConfigurationJPanelLayout);
        automationModuleConfigurationJPanelLayout.setHorizontalGroup(automationModuleConfigurationJPanelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGap(0, 566, short.MaxValue));
        automationModuleConfigurationJPanelLayout.setVerticalGroup(automationModuleConfigurationJPanelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGap(0, 334, short.MaxValue));
        this.gameRobotJTabbedPane.addTab("Configuration", automationModuleConfigurationJPanel);
        this.processingJMenu.setText("Processing");
        this.processingJMenu.setToolTipText("Set module processing state");
        this.startJMenuItem.setText(this.commonStrings.START);
        this.startJMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                startJMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.startJMenuItem);
        this.stopJMenuItem.setText("Stop");
        this.stopJMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                stopJMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.stopJMenuItem);
        this.mainJMenuBar.add(this.processingJMenu);
        this.optionsJMenu.setText("Options");
        this.optionsJMenu.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                optionsJMenuActionPerformed(evt);
            }

#endif
);
        this.stopOnFocusJCheckBoxMenuItem.setSelected(true);
        this.stopOnFocusJCheckBoxMenuItem.setEnabled(false);
        this.stopOnFocusJCheckBoxMenuItem.setLabel("Stop Module On Focus");
        this.stopOnFocusJCheckBoxMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                stopOnFocusJCheckBoxMenuItemActionPerformed(evt);
            }

#endif
);
        this.optionsJMenu.add(this.stopOnFocusJCheckBoxMenuItem);
        this.mainJMenuBar.add(this.optionsJMenu);
        this.toolsJMenu.setText("Help");
        this.helpJMenuItem.setText("Help");
        this.helpJMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                helpJMenuItemActionPerformed(evt);
            }

#endif
);
        this.toolsJMenu.add(this.helpJMenuItem);
        this.updatesJMenuItem.setText("Updates");
        this.updatesJMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                updatesJMenuItemActionPerformed(evt);
            }

#endif
);
        this.toolsJMenu.add(this.updatesJMenuItem);
        this.subscriptionJMenuItem.setText("Subscription");
        this.subscriptionJMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                subscriptionJMenuItemActionPerformed(evt);
            }

#endif
);
        this.toolsJMenu.add(this.subscriptionJMenuItem);
        this.modulesJMenuItem.setText("Module Manager");
        this.modulesJMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                modulesJMenuItemActionPerformed(evt);
            }

#endif
);
        this.toolsJMenu.add(this.modulesJMenuItem);
        this.aboutJMenuItem.setText("About");
        this.aboutJMenuItem.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                aboutJMenuItemActionPerformed(evt);
            }

#endif
);
        this.toolsJMenu.add(this.aboutJMenuItem);
        this.mainJMenuBar.add(this.toolsJMenu);
        setJMenuBar(this.mainJMenuBar);
        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(gameRobotJTabbedPane, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, 571, short.MaxValue));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(gameRobotJTabbedPane, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, 359, short.MaxValue));
        pack();
    }

    private void subscriptionJMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            Desktop.getDesktop().browse(this.uri);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "subscriptionJMenuItemActionPerformed", e);
        }
    }

    private void updatesJMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            Desktop.getDesktop().browse(this.uri);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "updatesJMenuItemActionPerformed", e);
        }
    }

    private void aboutJMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        JDialog textJDialog = new BasicTextJDialog("Copyright (c) 2002-2007 AllBinary");
        textJDialog.setVisible(true);
        textJDialog.setLocationRelativeTo(this);
    }

    private void modulesJMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            new DesktopBundle().start();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "modulesJMenuItemActionPerformed", e);
        }
    }

    private void helpJMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        JavaHelpUtil.getInstance().show(this.helpSet);
    }

    private void stopOnFocusJCheckBoxMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
    }

    private void optionsJMenuActionPerformed(java.awt.event.ActionEvent evt)
    {
    }

    private void formWindowLostFocus(java.awt.event.WindowEvent evt)
    {
        this.logUtil.putF("Nothing", this, "focusLost");
    }

    private void formWindowGainedFocus(java.awt.event.WindowEvent evt)
    {
        if (this.stopOnFocusJCheckBoxMenuItem.isSelected()) {
            this.logUtil.putF("Stopping", this, "focusGained");
            if (this.runnableInterface != null) {
                this.runnableInterface.setRunning(false);
            }
        }
    }

    private void formFocusLost(java.awt.event.FocusEvent evt)
    {
    }

    private void formFocusGained(java.awt.event.FocusEvent evt)
    {
    }

    private void inputAutomationModuleJListValueChanged(javax.swing.event.ListSelectionEvent evt)
    {
        try {
            string gameAutomationRobotModuleNameString = ((string) this.inputAutomationModuleJList.getSelectedValue());
            if (gameAutomationRobotModuleNameString != null) {
                this.inputAutomationModuleInterface = this.inputAutomationModuleFactory.getInstance(gameAutomationRobotModuleNameString);
                this.getAutomationModuleConfigurationJPanel().removeAll();
                javax.swing.GroupLayout layout = ((javax.swing.GroupLayout) this.getAutomationModuleConfigurationJPanel().getLayout());
                layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGap(0, 395, short.MaxValue).addComponent(this.inputAutomationModuleInterface.getConfigurationJPanel(), javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE));
                layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGap(0, 256, short.MaxValue).addComponent(this.inputAutomationModuleInterface.getConfigurationJPanel(), javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE));
                this.gameRobotJTabbedPane.setEnabledAt(1, true);
                this.logUtil.putF("Setting Module: " + gameAutomationRobotModuleNameString + " and Configuration JPanel", this, "gameAutomationRobotModuleJListValueChanged");
            } else {
                this.logUtil.putF("Module name was null", this, "gameAutomationRobotModuleJListValueChanged");
                this.gameRobotJTabbedPane.setEnabledAt(1, false);
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "gameAutomationRobotModuleJListValueChanged", e);
        }
    }

    private void stopJMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        if (this.runnableInterface != null) {
            this.runnableInterface.setRunning(false);
        } else {
            this.noModuleSelectedJDialog.setVisible(true);
            this.noModuleSelectedJDialog.setLocationRelativeTo(this);
        }
    }

    private void startJMenuItemActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            this.logUtil.putF("Starting", this, "startJMenuItemActionPerformed");
            if (this.inputAutomationModuleInterface != null) {
                this.runnableInterface = this.inputAutomationModuleInterface.getInstance();
                if (this.runnableInterface != null) {
                    this.thread = new global::org.allbinary.thread.NullThread(this.runnableInterface);
                    this.thread.setPriority(global::org.allbinary.thread.NullThread.MIN_PRIORITY + 1);
                    this.thread.start();
                } else {
                    this.logUtil.putF("Runnnable was null", this, "startJMenuItemActionPerformed");
                    this.noModuleSelectedJDialog.setVisible(true);
                    this.noModuleSelectedJDialog.setLocationRelativeTo(this);
                }
            } else {
                this.logUtil.putF("InputAutomationModuleInterface was null", this, "startJMenuItemActionPerformed");
                this.noModuleSelectedJDialog.setVisible(true);
                this.noModuleSelectedJDialog.setLocationRelativeTo(this);
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "startJMenuItemActionPerformed", e);
        }
    }

    private static InputAutomationJFrame INPUTAUTOMATION_JFRAME = null;
    public static InputAutomationJFrame getInstance()
    {
        return InputAutomationJFrame.INPUTAUTOMATION_JFRAME;
    }

    public static void destroy()
    {
        InputAutomationJFrame.INPUTAUTOMATION_JFRAME.setVisible(false);
    }

    public static void create(InputAutomationBundleActivatorListenerInterface inputAutomationBundleActivatorListenerInterface)
    {
        LogConfigTypeFactory.getInstance();
        AppUrlGlobals appUrlGlobals = new AppUrlGlobals();
        appUrlGlobals.setWebappPath("G:/mnt/bc/mydev/work_automation/automation/run/");
        URLGLOBALS.init(appUrlGlobals);
        WebappClassLoaderInfo.setLoader(appUrlGlobals.GetType().getClassLoader());
        java.awt.EventQueue.invokeLater(new ARunnable()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void run()
            {
                LogUtil logUtil = LogUtil.getInstance();
                CommonStrings commonStrings = CommonStrings.getInstance();
                try {
                    logUtil.putF("Running", this, commonStrings.RUN);
                    INPUTAUTOMATION_JFRAME = new InputAutomationJFrame();
                    InputRobotFactory.getInstance().addListener(InputAutomationJFrame.getInstance());
                    if (inputAutomationBundleActivatorListenerInterface != null) {
                        inputAutomationBundleActivatorListenerInterface.registerAsService();
                        inputAutomationBundleActivatorListenerInterface.useServices();
                    }
                    INPUTAUTOMATION_JFRAME.setVisible(true);
                } catch (Exception e) {
                    logUtil.put(commonStrings.EXCEPTION, this, commonStrings.RUN, e);
                }
            }

#endif
);
    }

    // throws Exception
    public static void main(string[] args)
    {
        InputAutomationJFrame.create(null);
    }

    public virtual javax.swing.JPanel getAutomationModuleConfigurationJPanel()
    {
        return this.automationModuleConfigurationJPanel;
    }

    public virtual void setAutomationModuleConfigurationJPanel(javax.swing.JPanel automationModuleConfigurationJPanel)
    {
        this.automationModuleConfigurationJPanel = automationModuleConfigurationJPanel;
    }

    public virtual void onAdd(InputAutomationRobotChangeEvent inputAutomationRobotChangeEvent)
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "onAdd");
            InputRobotFactory.getInstance().add(inputAutomationRobotChangeEvent.getInputAutomationRobotInterfaceWrapper().getInputRobotInterface());
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "onAdd", e);
        }
    }

    public virtual void onRemove(InputAutomationRobotChangeEvent inputAutomationRobotChangeEvent)
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "onRemove");
            InputRobotFactory.getInstance().add(inputAutomationRobotChangeEvent.getInputAutomationRobotInterfaceWrapper().getInputRobotInterface());
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "onRemove", e);
        }
    }

    public virtual void onAdd(InputAutomationConfigurationModuleChangeEvent inputAutomationConfigurationChangeEvent)
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "onAdd");
            this.inputAutomationModuleConfigurations.add(inputAutomationConfigurationChangeEvent.getInputAutomationModuleConfiguration());
            this.init();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "onAdd", e);
        }
    }

    public virtual void onRemove(InputAutomationConfigurationModuleChangeEvent inputAutomationConfigurationChangeEvent)
    {
        try {
            this.logUtil.putF(this.commonStrings.START, this, "onRemove");
            InputAutomationConfiguration inputAutomationConfiguration = InputAutomationConfigurationFactory.getInstance().inputAutomationConfiguration;
            java.util.List<InputAutomationModuleConfiguration> inputAutomationModuleConfigurationList = inputAutomationConfiguration.getInputAutomationModuleConfigurationList();
            if (inputAutomationModuleConfigurationList == null) {
                LogUtil logUtil = LogUtil.getInstance();
                CommonStrings commonStrings = CommonStrings.getInstance();
                logUtil.putF("inputAutomationModuleConfigurationList: " + inputAutomationModuleConfigurationList, this, commonStrings.INIT);
                throw new Exception();
            }
            InputAutomationModuleConfigurations inputAutomationModuleConfigurations = new InputAutomationModuleConfigurations(inputAutomationConfiguration.getInputAutomationModuleConfigurationList());
            inputAutomationModuleConfigurations.remove(inputAutomationConfigurationChangeEvent.getInputAutomationModuleConfiguration());
            this.init();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "onRemove", e);
        }
    }

    private javax.swing.JMenuItem aboutJMenuItem = null;
    private javax.swing.JPanel automationModuleConfigurationJPanel = null;
    private javax.swing.JTabbedPane gameRobotJTabbedPane = null;
    private javax.swing.JMenuItem helpJMenuItem = null;
    private javax.swing.JList inputAutomationModuleJList = null;
    private javax.swing.JPanel inputAutomationModuleJPanel = null;
    private javax.swing.JScrollPane jScrollPane1 = null;
    private javax.swing.JMenuBar mainJMenuBar = null;
    private javax.swing.JMenuItem modulesJMenuItem = null;
    private javax.swing.JDialog noModuleSelectedJDialog = null;
    private javax.swing.JLabel noModuleSelectedJLabel = null;
    private javax.swing.JMenu optionsJMenu = null;
    private javax.swing.JMenu processingJMenu = null;
    private javax.swing.JMenuItem startJMenuItem = null;
    private javax.swing.JMenuItem stopJMenuItem = null;
    private javax.swing.JCheckBoxMenuItem stopOnFocusJCheckBoxMenuItem = null;
    private javax.swing.JMenuItem subscriptionJMenuItem = null;
    private javax.swing.JMenu toolsJMenu = null;
    private javax.swing.JMenuItem updatesJMenuItem = null;
}

