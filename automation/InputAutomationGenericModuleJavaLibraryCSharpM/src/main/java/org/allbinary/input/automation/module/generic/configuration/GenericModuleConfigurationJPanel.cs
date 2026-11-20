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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
using GenericProfile = org.allbinary.input.automation.module.generic.configuration.profile.GenericProfile;
using GenericProfileDataWorkerType = org.allbinary.input.automation.module.generic.configuration.profile.GenericProfileDataWorkerType;
using GenericProfiles = org.allbinary.input.automation.module.generic.configuration.profile.GenericProfiles;
using GenericProfileActions = org.allbinary.input.automation.module.generic.configuration.profile.actions.GenericProfileActions;
using GenericProfileActionsJPanel = org.allbinary.input.automation.module.generic.configuration.profile.actions.GenericProfileActionsJPanel;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
//using Dimension = java.awt.Dimension;
//using GridLayout = java.awt.GridLayout;
//using Insets = java.awt.Insets;
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
//using BorderFactory = javax.swing.BorderFactory;
//using ButtonGroup = javax.swing.ButtonGroup;
//using GroupLayout = javax.swing.GroupLayout;
//using JButton = javax.swing.JButton;
//using JCheckBox = javax.swing.JCheckBox;
//using JDialog = javax.swing.JDialog;
//using JLabel = javax.swing.JLabel;
//using JList = javax.swing.JList;
//using JPanel = javax.swing.JPanel;
//using JRadioButton = javax.swing.JRadioButton;
//using JScrollPane = javax.swing.JScrollPane;
//using JTabbedPane = javax.swing.JTabbedPane;
//using JTextField = javax.swing.JTextField;
//using LayoutStyle = javax.swing.LayoutStyle;
//using ListSelectionEvent = javax.swing.@event.ListSelectionEvent;
//using ListSelectionListener = javax.swing.@event.ListSelectionListener;

namespace org.allbinary.input.automation.module.generic.configuration;

public class GenericModuleConfigurationJPanel : JPanel, GenericModuleConfigurationInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly StringUtil stringUtil = StringUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private GenericProfiles genericProfiles = null;
    private GenericProfile selectedGenericProfile = null;
    public GenericModuleConfigurationJPanel()
    {
        this.initComponents();
        this.setGenericProfiles(new GenericProfiles(GenericProfiles.DEFAULT_FILE));
        this.selectFirstElement();
    }

    private void initComponents()
    {
        this.newProfileJDialog = new JDialog();
        this.okNewProfileJButton = new JButton();
        this.newProfileNameJLabel = new JLabel();
        this.newProfileNameJTextField = new JTextField();
        this.buttonGroup2 = new ButtonGroup();
        this.genericJTabbedPane = new JTabbedPane();
        this.genericProfilesJPanel = new JPanel();
        this.genericProfilesJScrollPane = new JScrollPane();
        this.genericProfilesJList = new JList();
        this.newProfileJButton = new JButton();
        this.deleteProfileJButton = new JButton();
        this.jPanel1 = new JPanel();
        this.screenCaptureJRadioButton = new JRadioButton();
        this.jLabel1 = new JLabel();
        this.jLabel2 = new JLabel();
        this.savedCaptureJRadioButton = new JRadioButton();
        this.captureMotionAnalysisJCheckBox = new JCheckBox();
        this.captureComparisonJCheckBox = new JCheckBox();
        this.jLabel3 = new JLabel();
        this.blankGenericProfileActionsJPanel = new JPanel();
        this.newProfileJDialog.setMinimumSize(new Dimension(250, 150));
        this.newProfileJDialog.setResizable(false);
        this.okNewProfileJButton.setText("Ok");
        this.okNewProfileJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                okNewProfileJButtonActionPerformed(evt);
            }

#endif
);
        this.newProfileNameJLabel.setText("New Profile Name");
        GroupLayout newProfileJDialogLayout = new GroupLayout(this.newProfileJDialog.getContentPane());
        this.newProfileJDialog.getContentPane().setLayout(newProfileJDialogLayout);
        newProfileJDialogLayout.setHorizontalGroup(newProfileJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(newProfileJDialogLayout.createSequentialGroup().addGroup(newProfileJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(newProfileJDialogLayout.createSequentialGroup().addGap(80, 80, 80).addComponent(newProfileNameJLabel)).addGroup(newProfileJDialogLayout.createSequentialGroup().addGap(30, 30, 30).addComponent(newProfileNameJTextField, GroupLayout.PREFERRED_SIZE, 180, GroupLayout.PREFERRED_SIZE)).addGroup(newProfileJDialogLayout.createSequentialGroup().addGap(100, 100, 100).addComponent(okNewProfileJButton))).addContainerGap(35, short.MaxValue)));
        newProfileJDialogLayout.setVerticalGroup(newProfileJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(newProfileJDialogLayout.createSequentialGroup().addGap(10, 10, 10).addComponent(newProfileNameJLabel).addGap(16, 16, 16).addComponent(newProfileNameJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addGap(20, 20, 20).addComponent(okNewProfileJButton)));
        setLayout(new GridLayout(1, 0));
        setMinimumSize(new Dimension(400, 300));
        setPreferredSize(new Dimension(700, 700));
        this.genericJTabbedPane.setToolTipText(this.stringUtil.EMPTY_STRING);
        this.genericJTabbedPane.setMinimumSize(new Dimension(800, 600));
        this.genericProfilesJPanel.setMinimumSize(new Dimension(400, 300));
        this.genericProfilesJPanel.setPreferredSize(new Dimension(0, 0));
        this.genericProfilesJList.addListSelectionListener(new ListSelectionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void valueChanged(ListSelectionEvent evt)
            {
                genericProfilesJListValueChanged(evt);
            }

#endif
);
        this.genericProfilesJScrollPane.setViewportView(this.genericProfilesJList);
        this.newProfileJButton.setText("New");
        this.newProfileJButton.setToolTipText("Creates a new profile");
        this.newProfileJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                newProfileJButtonActionPerformed(evt);
            }

#endif
);
        this.deleteProfileJButton.setText("Delete");
        this.deleteProfileJButton.setToolTipText("Deletes the selected profile");
        this.deleteProfileJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                deleteProfileJButtonActionPerformed(evt);
            }

#endif
);
        this.jPanel1.setPreferredSize(new Dimension(1000, 100));
        this.screenCaptureJRadioButton.setText("Screen Captures");
        this.screenCaptureJRadioButton.setToolTipText("Records the screen into memory for logical processing");
        this.screenCaptureJRadioButton.setBorder(BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.screenCaptureJRadioButton.setMargin(new Insets(0, 0, 0, 0));
        this.screenCaptureJRadioButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                screenCaptureJRadioButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel1.setText("Profile Options");
        this.jLabel2.setText("Process From:");
        this.savedCaptureJRadioButton.setText("Saved Images");
        this.savedCaptureJRadioButton.setToolTipText("Loads images from files for logical processing.  Usually for debugging your profile actions");
        this.savedCaptureJRadioButton.setBorder(BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.savedCaptureJRadioButton.setMargin(new Insets(0, 0, 0, 0));
        this.savedCaptureJRadioButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                savedCaptureJRadioButtonActionPerformed(evt);
            }

#endif
);
        this.captureMotionAnalysisJCheckBox.setText("Motion Analysis");
        this.captureMotionAnalysisJCheckBox.setToolTipText("Uses image comparison and contraints to locate moving objects");
        this.captureMotionAnalysisJCheckBox.setBorder(BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.captureMotionAnalysisJCheckBox.setMargin(new Insets(0, 0, 0, 0));
        this.captureMotionAnalysisJCheckBox.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                captureMotionAnalysisJCheckBoxActionPerformed(evt);
            }

#endif
);
        this.captureComparisonJCheckBox.setText("Comparison");
        this.captureComparisonJCheckBox.setToolTipText("Compares the last two input images for multi image logic");
        this.captureComparisonJCheckBox.setBorder(BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.captureComparisonJCheckBox.setMargin(new Insets(0, 0, 0, 0));
        this.captureComparisonJCheckBox.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                captureComparisonJCheckBoxActionPerformed(evt);
            }

#endif
);
        this.jLabel3.setText("Image Processing:");
        this.jLabel3.setToolTipText("Turns on/off various extended image processing");
        GroupLayout jPanel1Layout = new GroupLayout(this.jPanel1);
        this.jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(jPanel1Layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(jPanel1Layout.createSequentialGroup().addGroup(jPanel1Layout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(screenCaptureJRadioButton).addComponent(jLabel1).addComponent(jLabel2).addComponent(savedCaptureJRadioButton).addComponent(captureMotionAnalysisJCheckBox).addComponent(captureComparisonJCheckBox).addComponent(jLabel3)).addContainerGap(22, short.MaxValue)));
        jPanel1Layout.setVerticalGroup(jPanel1Layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(jPanel1Layout.createSequentialGroup().addComponent(jLabel1).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel2).addGap(7, 7, 7).addComponent(screenCaptureJRadioButton).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(savedCaptureJRadioButton).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel3).addGap(7, 7, 7).addComponent(captureComparisonJCheckBox).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(captureMotionAnalysisJCheckBox).addContainerGap(106, short.MaxValue)));
        GroupLayout genericProfilesJPanelLayout = new GroupLayout(this.genericProfilesJPanel);
        this.genericProfilesJPanel.setLayout(genericProfilesJPanelLayout);
        genericProfilesJPanelLayout.setHorizontalGroup(genericProfilesJPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(genericProfilesJPanelLayout.createSequentialGroup().addGroup(genericProfilesJPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(genericProfilesJPanelLayout.createSequentialGroup().addComponent(newProfileJButton).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(deleteProfileJButton)).addGroup(genericProfilesJPanelLayout.createSequentialGroup().addComponent(genericProfilesJScrollPane, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jPanel1, GroupLayout.DEFAULT_SIZE, 119, short.MaxValue))).addContainerGap()));
        genericProfilesJPanelLayout.setVerticalGroup(genericProfilesJPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(genericProfilesJPanelLayout.createSequentialGroup().addGroup(genericProfilesJPanelLayout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(newProfileJButton).addComponent(deleteProfileJButton)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(genericProfilesJPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(jPanel1, GroupLayout.DEFAULT_SIZE, 246, short.MaxValue).addComponent(genericProfilesJScrollPane, GroupLayout.DEFAULT_SIZE, 246, short.MaxValue))));
        this.genericJTabbedPane.addTab("Profiles", genericProfilesJPanel);
        GroupLayout blankGenericProfileActionsJPanelLayout = new GroupLayout(this.blankGenericProfileActionsJPanel);
        this.blankGenericProfileActionsJPanel.setLayout(blankGenericProfileActionsJPanelLayout);
        blankGenericProfileActionsJPanelLayout.setHorizontalGroup(blankGenericProfileActionsJPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGap(0, 395, short.MaxValue));
        blankGenericProfileActionsJPanelLayout.setVerticalGroup(blankGenericProfileActionsJPanelLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGap(0, 275, short.MaxValue));
        this.genericJTabbedPane.addTab("Actions", blankGenericProfileActionsJPanel);
        add(this.genericJTabbedPane);
    }

    private void savedCaptureJRadioButtonActionPerformed(ActionEvent evt)
    {
        try {
            if (this.savedCaptureJRadioButton.isSelected()) {
                this.logUtil.putF("Selected", this, "savedCaptureJRadioButtonActionPerformed");
                this.getSelectedGenericProfile().add(GenericProfileDataWorkerType.SAVED_CAPTURE);
                this.getSelectedGenericProfile().remove(GenericProfileDataWorkerType.SCREEN_CAPTURE);
                this.screenCaptureJRadioButton.setSelected(false);
                this.getGenericProfiles().save();
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "savedCaptureJRadioButtonActionPerformed", e);
        }
    }

    private void screenCaptureJRadioButtonActionPerformed(ActionEvent evt)
    {
        try {
            if (this.screenCaptureJRadioButton.isSelected()) {
                this.logUtil.putF("Selected", this, "screenCaptureJRadioButtonActionPerformed");
                this.getSelectedGenericProfile().add(GenericProfileDataWorkerType.SCREEN_CAPTURE);
                this.getSelectedGenericProfile().remove(GenericProfileDataWorkerType.SAVED_CAPTURE);
                this.savedCaptureJRadioButton.setSelected(false);
                this.getGenericProfiles().save();
            }
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "screenCaptureJRadioButtonActionPerformed", e);
        }
    }

    private void captureMotionAnalysisJCheckBoxActionPerformed(ActionEvent evt)
    {
        try {
            if (this.captureMotionAnalysisJCheckBox.isSelected()) {
                this.getSelectedGenericProfile().add(GenericProfileDataWorkerType.MOTION);
            } else {
                this.getSelectedGenericProfile().remove(GenericProfileDataWorkerType.MOTION);
            }
            this.getGenericProfiles().save();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "captureComparisonJCheckBoxActionPerformed", e);
        }
    }

    private void captureComparisonJCheckBoxActionPerformed(ActionEvent evt)
    {
        try {
            if (this.captureComparisonJCheckBox.isSelected()) {
                this.getSelectedGenericProfile().add(GenericProfileDataWorkerType.COMPARISON);
            } else {
                this.getSelectedGenericProfile().remove(GenericProfileDataWorkerType.COMPARISON);
            }
            this.getGenericProfiles().save();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "captureComparisonJCheckBoxActionPerformed", e);
        }
    }

    // throws Exception
    private void updateProfileUI(string profileNameString)
    {
        this.getBlankGenericProfileActionsJPanel().removeAll();
        if (profileNameString != null) {
            GenericProfileActionsJPanel genericProfileActionsJPanel = new GenericProfileActionsJPanel();
            this.setSelectedGenericProfile(this.getGenericProfiles().get(profileNameString));
            this.getSelectedGenericProfile().setGenericProfileActions(new GenericProfileActions(genericProfileActionsJPanel, profileNameString));
            genericProfileActionsJPanel.setGenericProfileActions(this.getSelectedGenericProfile().getGenericProfileActions());
            genericProfileActionsJPanel.selectFirstElement();
            GroupLayout layout = ((GroupLayout) this.getBlankGenericProfileActionsJPanel().getLayout());
            layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGap(0, 395, short.MaxValue).addComponent(genericProfileActionsJPanel, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE));
            layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGap(0, 256, short.MaxValue).addComponent(genericProfileActionsJPanel, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE));
            this.updateProfileOptions();
            this.logUtil.putF("Setting Configuration Profile JPanel", this, "updateProfileUI");
        } else {
            this.logUtil.putF("Null Configuration Profile", this, "updateProfileUI");
        }
    }

    // throws Exception
    private void selectFirstElement()
    {
        this.genericProfilesJList.setModel(this.getGenericProfiles().getDefaultListModelHelper().getListModel());
        if (this.genericProfilesJList.getModel().getSize() > 0) {
            this.genericProfilesJList.setSelectedValue(this.genericProfilesJList.getModel().getElementAt(0), true);
            this.updateProfileUI(((string) this.genericProfilesJList.getModel().getElementAt(0)));
        }
    }

    // throws Exception
    private void updateProfileOptions()
    {
        this.logUtil.putF(this.commonStrings.START, this, "updateProfileOptions");
        GenericProfile genericProfile = this.getSelectedGenericProfile();
        BasicArrayList vector = genericProfile.getGenericProfileDataWorkerTypeVector();
        this.screenCaptureJRadioButton.setSelected(false);
        this.savedCaptureJRadioButton.setSelected(false);
        this.captureComparisonJCheckBox.setSelected(false);
        this.captureMotionAnalysisJCheckBox.setSelected(false);
        int size = vector.size();
        for (int index = 0; index < size; index++) {
            GenericProfileDataWorkerType genericProfileDataWorkerType = ((GenericProfileDataWorkerType) vector.get(index));
            this.logUtil.putF(genericProfile.getName() + " has GenericProfileDataWorkerType: " + genericProfileDataWorkerType.ToString(), this, "updateProfileOptions");
            if (genericProfileDataWorkerType == GenericProfileDataWorkerType.SCREEN_CAPTURE) {
                this.logUtil.putF("Screen Capture Selected", this, "updateProfileOptions");
                this.screenCaptureJRadioButton.setSelected(true);
            } else if (genericProfileDataWorkerType == GenericProfileDataWorkerType.SAVED_CAPTURE) {
                this.logUtil.putF("Saved Capture Selected", this, "updateProfileOptions");
                this.savedCaptureJRadioButton.setSelected(true);
            } else if (genericProfileDataWorkerType == GenericProfileDataWorkerType.COMPARISON) {
                this.logUtil.putF("Checking Comparison Box", this, "updateProfileOptions");
                this.captureComparisonJCheckBox.setSelected(true);
            } else if (genericProfileDataWorkerType == GenericProfileDataWorkerType.MOTION) {
                this.logUtil.putF("Checking Motion Box", this, "updateProfileOptions");
                this.captureMotionAnalysisJCheckBox.setSelected(true);
            }
        }
        if (!this.screenCaptureJRadioButton.isSelected() && !this.savedCaptureJRadioButton.isSelected()) {
            this.screenCaptureJRadioButton.setSelected(true);
            this.getSelectedGenericProfile().add(GenericProfileDataWorkerType.SCREEN_CAPTURE);
        }
        this.logUtil.putF(this.commonStrings.END, this, "updateProfileOptions");
    }

    public virtual JPanel getBlankGenericProfileActionsJPanel()
    {
        return this.blankGenericProfileActionsJPanel;
    }

    public virtual void setBlankGenericProfileActionsJPanel(JPanel blankGenericProfileActionsJPanel)
    {
        this.blankGenericProfileActionsJPanel = blankGenericProfileActionsJPanel;
    }

    private GenericProfiles getGenericProfiles()
    {
        return this.genericProfiles;
    }

    private void setGenericProfiles(GenericProfiles genericProfiles)
    {
        this.genericProfiles = genericProfiles;
    }

    public virtual GenericProfile getSelectedGenericProfile()
    {
        return this.selectedGenericProfile;
    }

    public virtual void setSelectedGenericProfile(GenericProfile selectedGenericProfile)
    {
        this.selectedGenericProfile = selectedGenericProfile;
    }

    private void genericProfilesJListValueChanged(ListSelectionEvent evt)
    {
        try {
            string profileNameString = ((string) this.genericProfilesJList.getSelectedValue());
            this.updateProfileUI(profileNameString);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "genericProfilesJListValueChanged", e);
        }
    }

    private void deleteProfileJButtonActionPerformed(ActionEvent evt)
    {
        try {
            object[] anyType = this.genericProfilesJList.getSelectedValues();
            for (int index = 0; index < anyType.Length; index++) {
                string nextSelectedValueString = ((string) anyType[index]);
                this.getGenericProfiles().remove(nextSelectedValueString);
            }
            this.selectFirstElement();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "deleteProfileJButtonActionPerformed", e);
        }
    }

    private void okNewProfileJButtonActionPerformed(ActionEvent evt)
    {
        try {
            string newProfileName = this.newProfileNameJTextField.getText();
            this.getGenericProfiles().add(newProfileName);
            this.genericProfilesJList.setModel(this.getGenericProfiles().getDefaultListModelHelper().getListModel());
            this.genericProfilesJList.setSelectedValue(newProfileName, true);
            this.newProfileJDialog.setVisible(false);
            this.updateProfileUI(newProfileName);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "okNewProfileJButtonActionPerformed", e);
        }
    }

    private void newProfileJButtonActionPerformed(ActionEvent evt)
    {
        this.newProfileJDialog.setVisible(true);
    }

    private JPanel blankGenericProfileActionsJPanel = null;
    private ButtonGroup buttonGroup2 = null;
    private JCheckBox captureComparisonJCheckBox = null;
    private JCheckBox captureMotionAnalysisJCheckBox = null;
    private JButton deleteProfileJButton = null;
    private JTabbedPane genericJTabbedPane = null;
    private JList genericProfilesJList = null;
    private JPanel genericProfilesJPanel = null;
    private JScrollPane genericProfilesJScrollPane = null;
    private JLabel jLabel1 = null;
    private JLabel jLabel2 = null;
    private JLabel jLabel3 = null;
    private JPanel jPanel1 = null;
    private JButton newProfileJButton = null;
    private JDialog newProfileJDialog = null;
    private JLabel newProfileNameJLabel = null;
    private JTextField newProfileNameJTextField = null;
    private JButton okNewProfileJButton = null;
    private JRadioButton savedCaptureJRadioButton = null;
    private JRadioButton screenCaptureJRadioButton = null;
}

