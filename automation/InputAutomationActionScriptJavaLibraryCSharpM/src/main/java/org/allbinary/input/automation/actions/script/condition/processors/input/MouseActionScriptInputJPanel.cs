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
//using InputEvent = java.awt.@event.InputEvent;
//using javax.swing;
using InputRobot = org.allbinary.input.automation.robot.InputRobot;
using InputRobotFactory = org.allbinary.input.automation.robot.InputRobotFactory;
using TempInputRobotNames = org.allbinary.input.automation.robot.TempInputRobotNames;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using CommonLabels = org.allbinary.@string.CommonLabels;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.automation.actions.script.condition.processors.input;

public class MouseActionScriptInputJPanel : javax.swing.JPanel
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private MouseActionScriptInputInterface mouseActionScriptInputInterface;
    public MouseActionScriptInputJPanel(MouseActionScriptInputInterface mouseActionScriptInputInterface)
    {
        this.logUtil.putF(CommonLabels.getInstance().START + mouseActionScriptInputInterface, this, this.commonStrings.CONSTRUCTOR);
        this.initComponents();
        this.mouseActionScriptInputInterface = mouseActionScriptInputInterface;
        DefaultComboBoxModel defaultComboBoxModel = new DefaultComboBoxModel();
        defaultComboBoxModel.addElement(TempInputRobotNames.LOW_NAME);
        defaultComboBoxModel.addElement(TempInputRobotNames.SYS_NAME);
        defaultComboBoxModel.addElement(InputRobot.NAME);
        this.inputAutomationTypeJComboBox.setModel(defaultComboBoxModel);
        this.set();
    }

    private void set()
    {
        ComboBoxModel inputTypeComboBoxModel = this.inputAutomationTypeJComboBox.getModel();
        inputTypeComboBoxModel.setSelectedItem(this.mouseActionScriptInputInterface.getInputRobotInterface().getName());
        if ((this.mouseActionScriptInputInterface.getButtonClicks() & InputEvent.BUTTON1_MASK) != 0) {
            this.button1JCheckBox.setSelected(true);
        } else {
            this.button1JCheckBox.setSelected(false);
        }
        if ((this.mouseActionScriptInputInterface.getButtonClicks() & InputEvent.BUTTON2_MASK) != 0) {
            this.button2JCheckBox.setSelected(true);
        } else {
            this.button2JCheckBox.setSelected(false);
        }
        this.mouseDelayJTextField.setText((this.mouseActionScriptInputInterface.getTime()).ToString());
        this.mouseXJTextField.setText((this.mouseActionScriptInputInterface.getPoint().x).ToString());
        this.mouseYJTextField.setText((this.mouseActionScriptInputInterface.getPoint().y).ToString());
        this.mouseActionScriptInputInterface.log();
    }

    // throws Exception
    private void updateInputType()
    {
        ComboBoxModel comboBoxModel = this.inputAutomationTypeJComboBox.getModel();
        string selectedItem = ((string) comboBoxModel.getSelectedItem());
        if (!StringValidationUtil.getInstance().isEmpty(selectedItem)) {
            this.mouseActionScriptInputInterface.setInputRobotInterface(InputRobotFactory.getInstance().get(selectedItem));
        }
    }

    // throws Exception
    private void update()
    {
        this.updateInputType();
        this.mouseActionScriptInputInterface.setTime((this.mouseDelayJTextField.getText()).ToString());
        this.logUtil.putF("Button State: " + this.mouseActionScriptInputInterface.getButtonClicks(), this, "update");
        if (this.button1JCheckBox.isSelected()) {
            if ((this.mouseActionScriptInputInterface.getButtonClicks() & InputEvent.BUTTON1_MASK) == 0) {
                this.mouseActionScriptInputInterface.setButtonClicks(this.mouseActionScriptInputInterface.getButtonClicks() | InputEvent.BUTTON1_MASK);
                this.logUtil.putF("Button 1 Selected: " + this.mouseActionScriptInputInterface.getButtonClicks(), this, "update");
            }
        } else {
            if ((this.mouseActionScriptInputInterface.getButtonClicks() & InputEvent.BUTTON1_MASK) != 0) {
                this.mouseActionScriptInputInterface.setButtonClicks(this.mouseActionScriptInputInterface.getButtonClicks() ^ InputEvent.BUTTON1_MASK);
                this.logUtil.putF("Button 1 Deselected: " + this.mouseActionScriptInputInterface.getButtonClicks(), this, "update");
            }
        }
        if (this.button2JCheckBox.isSelected()) {
            if ((this.mouseActionScriptInputInterface.getButtonClicks() & InputEvent.BUTTON2_MASK) == 0) {
                this.mouseActionScriptInputInterface.setButtonClicks(this.mouseActionScriptInputInterface.getButtonClicks() | InputEvent.BUTTON2_MASK);
                this.logUtil.putF("Button 2 Selected: " + this.mouseActionScriptInputInterface.getButtonClicks(), this, "update");
            }
        } else {
            if ((this.mouseActionScriptInputInterface.getButtonClicks() & InputEvent.BUTTON2_MASK) != 0) {
                this.mouseActionScriptInputInterface.setButtonClicks(this.mouseActionScriptInputInterface.getButtonClicks() ^ InputEvent.BUTTON2_MASK);
                this.logUtil.putF("Button 2 Deselected: " + this.mouseActionScriptInputInterface.getButtonClicks(), this, "update");
            }
        }
        string mouseXString = this.mouseXJTextField.getText();
        if (!StringValidationUtil.getInstance().isEmpty(mouseXString) && StringValidationUtil.getInstance().isNumber(mouseXString)) {
            this.mouseActionScriptInputInterface.getPoint().x = int.Parse(mouseXString);
        }
        string mouseYString = this.mouseYJTextField.getText();
        if (!StringValidationUtil.getInstance().isEmpty(mouseYString) && StringValidationUtil.getInstance().isNumber(mouseYString)) {
            this.mouseActionScriptInputInterface.getPoint().y = int.Parse(mouseYString);
        }
        this.mouseActionScriptInputInterface.log();
    }

    public virtual javax.swing.JDialog getMouseActionJDialog()
    {
        return this.mouseActionJDialog;
    }

    public virtual void setMouseActionJDialog(javax.swing.JDialog mouseActionJDialog)
    {
        this.mouseActionJDialog = mouseActionJDialog;
    }

    private void initComponents()
    {
        this.mouseActionJDialog = new javax.swing.JDialog();
        this.titleJLabel = new javax.swing.JLabel();
        this.okJButton = new javax.swing.JButton();
        this.jLabel2 = new javax.swing.JLabel();
        this.jLabel3 = new javax.swing.JLabel();
        this.button1JCheckBox = new javax.swing.JCheckBox();
        this.button2JCheckBox = new javax.swing.JCheckBox();
        this.jLabel4 = new javax.swing.JLabel();
        this.mouseXJTextField = new javax.swing.JTextField();
        this.jLabel5 = new javax.swing.JLabel();
        this.mouseYJTextField = new javax.swing.JTextField();
        this.inputTypeJLabel = new javax.swing.JLabel();
        this.inputAutomationTypeJComboBox = new javax.swing.JComboBox();
        this.jLabel6 = new javax.swing.JLabel();
        this.mouseDelayJTextField = new javax.swing.JTextField();
        this.mouseActionJButton = new javax.swing.JButton();
        this.jLabel1 = new javax.swing.JLabel();
        this.mouseActionJDialog.setMinimumSize(new java.awt.Dimension(275, 185));
        this.titleJLabel.setText("Mouse Input Options");
        this.okJButton.setText("OK");
        this.okJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                okJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel2.setText("Buttons:");
        this.jLabel3.setText("Move To:");
        this.button1JCheckBox.setText(CommonPhoneStrings.getInstance().ONE);
        this.button1JCheckBox.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.button1JCheckBox.setMargin(new java.awt.Insets(0, 0, 0, 0));
        this.button2JCheckBox.setText(CommonPhoneStrings.getInstance().TWO);
        this.button2JCheckBox.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.button2JCheckBox.setMargin(new java.awt.Insets(0, 0, 0, 0));
        this.button2JCheckBox.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                button2JCheckBoxActionPerformed(evt);
            }

#endif
);
        this.jLabel4.setText("x:");
        this.mouseXJTextField.setText(CommonPhoneStrings.getInstance().ZERO);
        this.jLabel5.setText("y:");
        this.mouseYJTextField.setText(CommonPhoneStrings.getInstance().ZERO);
        this.inputTypeJLabel.setText("Input Type:");
        this.jLabel6.setText("Delay:");
        this.mouseDelayJTextField.setText("100");
        javax.swing.GroupLayout mouseActionJDialogLayout = new javax.swing.GroupLayout(this.mouseActionJDialog.getContentPane());
        this.mouseActionJDialog.getContentPane().setLayout(mouseActionJDialogLayout);
        mouseActionJDialogLayout.setHorizontalGroup(mouseActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(mouseActionJDialogLayout.createSequentialGroup().addContainerGap().addGroup(mouseActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(inputTypeJLabel).addGroup(javax.swing.GroupLayout.Alignment.TRAILING, mouseActionJDialogLayout.createSequentialGroup().addGroup(mouseActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(javax.swing.GroupLayout.Alignment.TRAILING, mouseActionJDialogLayout.createSequentialGroup().addComponent(jLabel2).addGap(25, 25, 25)).addGroup(mouseActionJDialogLayout.createSequentialGroup().addGroup(mouseActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(jLabel3).addComponent(jLabel6)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED))).addGroup(mouseActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(mouseDelayJTextField, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, 154, short.MaxValue).addGroup(mouseActionJDialogLayout.createSequentialGroup().addComponent(titleJLabel).addGap(45, 45, 45)).addGroup(javax.swing.GroupLayout.Alignment.TRAILING, mouseActionJDialogLayout.createSequentialGroup().addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(inputAutomationTypeJComboBox, 0, 154, short.MaxValue)).addGroup(mouseActionJDialogLayout.createSequentialGroup().addComponent(button1JCheckBox).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(button2JCheckBox)).addGroup(mouseActionJDialogLayout.createSequentialGroup().addGroup(mouseActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addGroup(mouseActionJDialogLayout.createSequentialGroup().addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(okJButton)).addGroup(mouseActionJDialogLayout.createSequentialGroup().addComponent(jLabel4).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 5, short.MaxValue).addComponent(mouseXJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, 59, javax.swing.GroupLayout.PREFERRED_SIZE))).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel5).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(mouseYJTextField, javax.swing.GroupLayout.DEFAULT_SIZE, 62, short.MaxValue))))).addContainerGap()));
        mouseActionJDialogLayout.setVerticalGroup(mouseActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(mouseActionJDialogLayout.createSequentialGroup().addComponent(titleJLabel).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(mouseActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(inputTypeJLabel).addComponent(inputAutomationTypeJComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(mouseActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(jLabel2, javax.swing.GroupLayout.PREFERRED_SIZE, 15, javax.swing.GroupLayout.PREFERRED_SIZE).addGroup(mouseActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(button1JCheckBox).addComponent(button2JCheckBox))).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(mouseActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(jLabel6).addComponent(mouseDelayJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(mouseActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(jLabel3).addComponent(jLabel4).addComponent(jLabel5).addComponent(mouseYJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(mouseXJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, javax.swing.GroupLayout.DEFAULT_SIZE, short.MaxValue).addComponent(okJButton).addContainerGap()));
        setMinimumSize(new java.awt.Dimension(100, 0));
        this.mouseActionJButton.setText("Edit");
        this.mouseActionJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                mouseActionJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel1.setText("Mouse:");
        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jLabel1).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 36, short.MaxValue).addComponent(mouseActionJButton)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(jLabel1).addComponent(mouseActionJButton)));
    }

    private void button2JCheckBoxActionPerformed(java.awt.event.ActionEvent evt)
    {
    }

    private void okJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            this.update();
            this.getMouseActionJDialog().setVisible(false);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "okButtonActionPerformed", e);
        }
    }

    private void mouseActionJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.getMouseActionJDialog().setVisible(true);
    }

    private javax.swing.JCheckBox button1JCheckBox = null;
    private javax.swing.JCheckBox button2JCheckBox = null;
    private javax.swing.JComboBox inputAutomationTypeJComboBox = null;
    private javax.swing.JLabel inputTypeJLabel = null;
    private javax.swing.JLabel jLabel1 = null;
    private javax.swing.JLabel jLabel2 = null;
    private javax.swing.JLabel jLabel3 = null;
    private javax.swing.JLabel jLabel4 = null;
    private javax.swing.JLabel jLabel5 = null;
    private javax.swing.JLabel jLabel6 = null;
    private javax.swing.JButton mouseActionJButton = null;
    private javax.swing.JDialog mouseActionJDialog = null;
    private javax.swing.JTextField mouseDelayJTextField = null;
    private javax.swing.JTextField mouseXJTextField = null;
    private javax.swing.JTextField mouseYJTextField = null;
    private javax.swing.JButton okJButton = null;
    private javax.swing.JLabel titleJLabel = null;
}

