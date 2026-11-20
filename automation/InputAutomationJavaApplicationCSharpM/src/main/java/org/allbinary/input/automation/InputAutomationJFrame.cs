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
using URI = java.net.URI;
using URL = java.net.URL;
using Desktop = java.awt.Desktop;
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
//using Dimension = java.awt.Dimension;
//using EventQueue = java.awt.EventQueue;
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
//using FocusAdapter = java.awt.@event.FocusAdapter;
//using FocusEvent = java.awt.@event.FocusEvent;
//using WindowEvent = java.awt.@event.WindowEvent;
//using WindowFocusListener = java.awt.@event.WindowFocusListener;
//using GroupLayout = javax.swing.GroupLayout;
//using JCheckBoxMenuItem = javax.swing.JCheckBoxMenuItem;
//using JFrame = javax.swing.JFrame;
//using JLabel = javax.swing.JLabel;
//using JList = javax.swing.JList;
//using JMenu = javax.swing.JMenu;
//using JMenuBar = javax.swing.JMenuBar;
//using JMenuItem = javax.swing.JMenuItem;
//using JPanel = javax.swing.JPanel;
//using JScrollPane = javax.swing.JScrollPane;
//using JTabbedPane = javax.swing.JTabbedPane;
//using WindowConstants = javax.swing.WindowConstants;
//using ListSelectionEvent = javax.swing.@event.ListSelectionEvent;
//using ListSelectionListener = javax.swing.@event.ListSelectionListener;

namespace org.allbinary.input.automation;

public class InputAutomationJFrame : JFrame, InputAutomationConfigurationModuleChangeListener, InputAutomationRobotChangeListener, HelpSetListener
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
        this.noModuleSelectedJDialog = new JDialog();
        this.noModuleSelectedJLabel = new JLabel();
        this.gameRobotJTabbedPane = new JTabbedPane();
        this.inputAutomationModuleJPanel = new JPanel();
        this.jScrollPane1 = new JScrollPane();
        this.inputAutomationModuleJList = new JList();
        this.automationModuleConfigurationJPanel = new JPanel();
        this.mainJMenuBar = new JMenuBar();
        this.processingJMenu = new JMenu();
        this.startJMenuItem = new JMenuItem();
        this.stopJMenuItem = new JMenuItem();
        this.optionsJMenu = new JMenu();
        this.stopOnFocusJCheckBoxMenuItem = new JCheckBoxMenuItem();
        this.toolsJMenu = new JMenu();
        this.helpJMenuItem = new JMenuItem();
        this.updatesJMenuItem = new JMenuItem();
        this.subscriptionJMenuItem = new JMenuItem();
        this.modulesJMenuItem = new JMenuItem();
        this.aboutJMenuItem = new JMenuItem();
        this.noModuleSelectedJDialog.setMinimumSize(new Dimension(200, 100));
        this.noModuleSelectedJLabel.setText("Please Select A Module");
        GroupLayout noModuleSelectedJDialogLayout = new GroupLayout(this.noModuleSelectedJDialog.getContentPane());
        this.noModuleSelectedJDialog.getContentPane().setLayout(noModuleSelectedJDialogLayout);
        noModuleSelectedJDialogLayout.setHorizontalGroup(noModuleSelectedJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(noModuleSelectedJDialogLayout.createSequentialGroup().addContainerGap().addComponent(noModuleSelectedJLabel).addContainerGap(GroupLayout.DEFAULT_SIZE, short.MaxValue)));
        noModuleSelectedJDialogLayout.setVerticalGroup(noModuleSelectedJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(noModuleSelectedJLabel, GroupLayout.Alignment.TRAILING, GroupLayout.DEFAULT_SIZE, 48, short.MaxValue));
        setDefaultCloseOperation(WindowConstants.EXIT_ON_CLOSE);
        this.setMinimumSize(new Dimension(325, 215));
        setResizable(false);
        addWindowFocusListener(new WindowFocusListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void windowGainedFocus(WindowEvent evt)
            {
                formWindowGainedFocus(evt);
            }

            public virtual void windowLostFocus(WindowEvent evt)
            {
                formWindowLostFocus(evt);
            }

#endif
);
        addFocusListener(new FocusAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void focusGained(FocusEvent evt)
            {
                formFocusGained(evt);
            }

            public virtual void focusLost(FocusEvent evt)
            {
                formFocusLost(evt);
            }

#endif
);
        this.gameRobotJTabbedPane.setMinimumSize(new Dimension(320, 200));
        this.inputAutomationModuleJList.setMinimumSize(new Dimension(200, 0));
        this.inputAutomationModuleJList.addListSelectionListener(new ListSelectionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void valueChanged(ListSelectionEvent evt)
            {
                inputAutomationModuleJListValueChanged(evt);
            }

#endif
);
        this.jScrollPane1.setViewportView(this.inputAutomationModuleJList);
        GroupLayout inputAutomationModuleJPanelLayout = new GroupLayout(this.inputAutomationModuleJPanel);
        this.inputAutomationModuleJPanel.setLayout(inputAutomationModuleJPanelLayout);
        inputAutomationModuleJPanelLayout.setHorizontalGroup(inputAutomationModuleJPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(inputAutomationModuleJPanelLayout.createSequentialGroup().addComponent(jScrollPane1, GroupLayout.PREFERRED_SIZE, 199, GroupLayout.PREFERRED_SIZE).addContainerGap(367, short.MaxValue)));
        inputAutomationModuleJPanelLayout.setVerticalGroup(inputAutomationModuleJPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(inputAutomationModuleJPanelLayout.createSequentialGroup().addComponent(jScrollPane1, GroupLayout.PREFERRED_SIZE, 330, GroupLayout.PREFERRED_SIZE).addContainerGap(GroupLayout.DEFAULT_SIZE, short.MaxValue)));
        this.gameRobotJTabbedPane.addTab("Modules", inputAutomationModuleJPanel);
        GroupLayout automationModuleConfigurationJPanelLayout = new GroupLayout(this.automationModuleConfigurationJPanel);
        this.automationModuleConfigurationJPanel.setLayout(automationModuleConfigurationJPanelLayout);
        automationModuleConfigurationJPanelLayout.setHorizontalGroup(automationModuleConfigurationJPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGap(0, 566, short.MaxValue));
        automationModuleConfigurationJPanelLayout.setVerticalGroup(automationModuleConfigurationJPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGap(0, 334, short.MaxValue));
        this.gameRobotJTabbedPane.addTab("Configuration", automationModuleConfigurationJPanel);
        this.processingJMenu.setText("Processing");
        this.processingJMenu.setToolTipText("Set module processing state");
        this.startJMenuItem.setText(this.commonStrings.START);
        this.startJMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                startJMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.startJMenuItem);
        this.stopJMenuItem.setText("Stop");
        this.stopJMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                stopJMenuItemActionPerformed(evt);
            }

#endif
);
        this.processingJMenu.add(this.stopJMenuItem);
        this.mainJMenuBar.add(this.processingJMenu);
        this.optionsJMenu.setText("Options");
        this.optionsJMenu.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                optionsJMenuActionPerformed(evt);
            }

#endif
);
        this.stopOnFocusJCheckBoxMenuItem.setSelected(true);
        this.stopOnFocusJCheckBoxMenuItem.setEnabled(false);
        this.stopOnFocusJCheckBoxMenuItem.setLabel("Stop Module On Focus");
        this.stopOnFocusJCheckBoxMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                stopOnFocusJCheckBoxMenuItemActionPerformed(evt);
            }

#endif
);
        this.optionsJMenu.add(this.stopOnFocusJCheckBoxMenuItem);
        this.mainJMenuBar.add(this.optionsJMenu);
        this.toolsJMenu.setText("Help");
        this.helpJMenuItem.setText("Help");
        this.helpJMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                helpJMenuItemActionPerformed(evt);
            }

#endif
);
        this.toolsJMenu.add(this.helpJMenuItem);
        this.updatesJMenuItem.setText("Updates");
        this.updatesJMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                updatesJMenuItemActionPerformed(evt);
            }

#endif
);
        this.toolsJMenu.add(this.updatesJMenuItem);
        this.subscriptionJMenuItem.setText("Subscription");
        this.subscriptionJMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                subscriptionJMenuItemActionPerformed(evt);
            }

#endif
);
        this.toolsJMenu.add(this.subscriptionJMenuItem);
        this.modulesJMenuItem.setText("Module Manager");
        this.modulesJMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                modulesJMenuItemActionPerformed(evt);
            }

#endif
);
        this.toolsJMenu.add(this.modulesJMenuItem);
        this.aboutJMenuItem.setText("About");
        this.aboutJMenuItem.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                aboutJMenuItemActionPerformed(evt);
            }

#endif
);
        this.toolsJMenu.add(this.aboutJMenuItem);
        this.mainJMenuBar.add(this.toolsJMenu);
        setJMenuBar(this.mainJMenuBar);
        GroupLayout layout = new GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(gameRobotJTabbedPane, GroupLayout.Alignment.TRAILING, GroupLayout.DEFAULT_SIZE, 571, short.MaxValue));
        layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(gameRobotJTabbedPane, GroupLayout.Alignment.TRAILING, GroupLayout.DEFAULT_SIZE, 359, short.MaxValue));
        pack();
    }

    private void subscriptionJMenuItemActionPerformed(ActionEvent evt)
    {
        try {
            Desktop.getDesktop().browse(this.uri);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "subscriptionJMenuItemActionPerformed", e);
        }
    }

    private void updatesJMenuItemActionPerformed(ActionEvent evt)
    {
        try {
            Desktop.getDesktop().browse(this.uri);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "updatesJMenuItemActionPerformed", e);
        }
    }

    private void aboutJMenuItemActionPerformed(ActionEvent evt)
    {
        JDialog textJDialog = new BasicTextJDialog("Copyright (c) 2002-2007 AllBinary");
        textJDialog.setVisible(true);
        textJDialog.setLocationRelativeTo(this);
    }

    private void modulesJMenuItemActionPerformed(ActionEvent evt)
    {
        try {
            new DesktopBundle().start();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "modulesJMenuItemActionPerformed", e);
        }
    }

    private void helpJMenuItemActionPerformed(ActionEvent evt)
    {
        JavaHelpUtil.getInstance().show(this.helpSet);
    }

    private void stopOnFocusJCheckBoxMenuItemActionPerformed(ActionEvent evt)
    {
    }

    private void optionsJMenuActionPerformed(ActionEvent evt)
    {
    }

    private void formWindowLostFocus(WindowEvent evt)
    {
        this.logUtil.putF("Nothing", this, "focusLost");
    }

    private void formWindowGainedFocus(WindowEvent evt)
    {
        if (this.stopOnFocusJCheckBoxMenuItem.isSelected()) {
            this.logUtil.putF("Stopping", this, "focusGained");
            if (this.runnableInterface != null) {
                this.runnableInterface.setRunning(false);
            }
        }
    }

    private void formFocusLost(FocusEvent evt)
    {
    }

    private void formFocusGained(FocusEvent evt)
    {
    }

    private void inputAutomationModuleJListValueChanged(ListSelectionEvent evt)
    {
        try {
            string gameAutomationRobotModuleNameString = ((string) this.inputAutomationModuleJList.getSelectedValue());
            if (gameAutomationRobotModuleNameString != null) {
                this.inputAutomationModuleInterface = this.inputAutomationModuleFactory.getInstance(gameAutomationRobotModuleNameString);
                this.getAutomationModuleConfigurationJPanel().removeAll();
                GroupLayout layout = ((GroupLayout) this.getAutomationModuleConfigurationJPanel().getLayout());
                layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGap(0, 395, short.MaxValue).addComponent(this.inputAutomationModuleInterface.getConfigurationJPanel(), GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE));
                layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGap(0, 256, short.MaxValue).addComponent(this.inputAutomationModuleInterface.getConfigurationJPanel(), GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE));
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

    private void stopJMenuItemActionPerformed(ActionEvent evt)
    {
        if (this.runnableInterface != null) {
            this.runnableInterface.setRunning(false);
        } else {
            this.noModuleSelectedJDialog.setVisible(true);
            this.noModuleSelectedJDialog.setLocationRelativeTo(this);
        }
    }

    private void startJMenuItemActionPerformed(ActionEvent evt)
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
        WebappClassLoaderInfo.setLoader(global::java.lang.ClassLoader.getSystemClassLoader());
        EventQueue.invokeLater(new ARunnable()
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

    public virtual JPanel getAutomationModuleConfigurationJPanel()
    {
        return this.automationModuleConfigurationJPanel;
    }

    public virtual void setAutomationModuleConfigurationJPanel(JPanel automationModuleConfigurationJPanel)
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
            List<InputAutomationModuleConfiguration> inputAutomationModuleConfigurationList = inputAutomationConfiguration.getInputAutomationModuleConfigurationList();
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

    private JMenuItem aboutJMenuItem = null;
    private JPanel automationModuleConfigurationJPanel = null;
    private JTabbedPane gameRobotJTabbedPane = null;
    private JMenuItem helpJMenuItem = null;
    private JList inputAutomationModuleJList = null;
    private JPanel inputAutomationModuleJPanel = null;
    private JScrollPane jScrollPane1 = null;
    private JMenuBar mainJMenuBar = null;
    private JMenuItem modulesJMenuItem = null;
    private JDialog noModuleSelectedJDialog = null;
    private JLabel noModuleSelectedJLabel = null;
    private JMenu optionsJMenu = null;
    private JMenu processingJMenu = null;
    private JMenuItem startJMenuItem = null;
    private JMenuItem stopJMenuItem = null;
    private JCheckBoxMenuItem stopOnFocusJCheckBoxMenuItem = null;
    private JMenuItem subscriptionJMenuItem = null;
    private JMenu toolsJMenu = null;
    private JMenuItem updatesJMenuItem = null;
}

