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
//using Dimension = java.awt.Dimension;
//using Insets = java.awt.Insets;
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
//using BorderFactory = javax.swing.BorderFactory;
//using GroupLayout = javax.swing.GroupLayout;
//using JButton = javax.swing.JButton;
//using JCheckBox = javax.swing.JCheckBox;
//using JComboBox = javax.swing.JComboBox;
//using JDialog = javax.swing.JDialog;
//using JLabel = javax.swing.JLabel;
//using JPanel = javax.swing.JPanel;
//using JTextField = javax.swing.JTextField;
//using LayoutStyle = javax.swing.LayoutStyle;

namespace org.allbinary.input.automation.actions.script.condition.processors.input;

public class MouseActionScriptInputJPanel : JPanel
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
        this.mouseActionScriptInputInterface.setTime(int.Parse((this.mouseDelayJTextField.getText()).ToString()));
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

    public virtual JDialog getMouseActionJDialog()
    {
        return this.mouseActionJDialog;
    }

    public virtual void setMouseActionJDialog(JDialog mouseActionJDialog)
    {
        this.mouseActionJDialog = mouseActionJDialog;
    }

    private void initComponents()
    {
        this.mouseActionJDialog = new JDialog();
        this.titleJLabel = new JLabel();
        this.okJButton = new JButton();
        this.jLabel2 = new JLabel();
        this.jLabel3 = new JLabel();
        this.button1JCheckBox = new JCheckBox();
        this.button2JCheckBox = new JCheckBox();
        this.jLabel4 = new JLabel();
        this.mouseXJTextField = new JTextField();
        this.jLabel5 = new JLabel();
        this.mouseYJTextField = new JTextField();
        this.inputTypeJLabel = new JLabel();
        this.inputAutomationTypeJComboBox = new JComboBox();
        this.jLabel6 = new JLabel();
        this.mouseDelayJTextField = new JTextField();
        this.mouseActionJButton = new JButton();
        this.jLabel1 = new JLabel();
        this.mouseActionJDialog.setMinimumSize(new Dimension(275, 185));
        this.titleJLabel.setText("Mouse Input Options");
        this.okJButton.setText("OK");
        this.okJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                okJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel2.setText("Buttons:");
        this.jLabel3.setText("Move To:");
        this.button1JCheckBox.setText(CommonPhoneStrings.getInstance().ONE);
        this.button1JCheckBox.setBorder(BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.button1JCheckBox.setMargin(new Insets(0, 0, 0, 0));
        this.button2JCheckBox.setText(CommonPhoneStrings.getInstance().TWO);
        this.button2JCheckBox.setBorder(BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.button2JCheckBox.setMargin(new Insets(0, 0, 0, 0));
        this.button2JCheckBox.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
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
        GroupLayout mouseActionJDialogLayout = new GroupLayout(this.mouseActionJDialog.getContentPane());
        this.mouseActionJDialog.getContentPane().setLayout(mouseActionJDialogLayout);
        mouseActionJDialogLayout.setHorizontalGroup(mouseActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(mouseActionJDialogLayout.createSequentialGroup().addContainerGap().addGroup(mouseActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(inputTypeJLabel).addGroup(GroupLayout.Alignment.TRAILING, mouseActionJDialogLayout.createSequentialGroup().addGroup(mouseActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(GroupLayout.Alignment.TRAILING, mouseActionJDialogLayout.createSequentialGroup().addComponent(jLabel2).addGap(25, 25, 25)).addGroup(mouseActionJDialogLayout.createSequentialGroup().addGroup(mouseActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(jLabel3).addComponent(jLabel6)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED))).addGroup(mouseActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(mouseDelayJTextField, GroupLayout.Alignment.TRAILING, GroupLayout.DEFAULT_SIZE, 154, short.MaxValue).addGroup(mouseActionJDialogLayout.createSequentialGroup().addComponent(titleJLabel).addGap(45, 45, 45)).addGroup(GroupLayout.Alignment.TRAILING, mouseActionJDialogLayout.createSequentialGroup().addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(inputAutomationTypeJComboBox, 0, 154, short.MaxValue)).addGroup(mouseActionJDialogLayout.createSequentialGroup().addComponent(button1JCheckBox).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(button2JCheckBox)).addGroup(mouseActionJDialogLayout.createSequentialGroup().addGroup(mouseActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.TRAILING).addGroup(mouseActionJDialogLayout.createSequentialGroup().addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(okJButton)).addGroup(mouseActionJDialogLayout.createSequentialGroup().addComponent(jLabel4).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED, 5, short.MaxValue).addComponent(mouseXJTextField, GroupLayout.PREFERRED_SIZE, 59, GroupLayout.PREFERRED_SIZE))).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(jLabel5).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addComponent(mouseYJTextField, GroupLayout.DEFAULT_SIZE, 62, short.MaxValue))))).addContainerGap()));
        mouseActionJDialogLayout.setVerticalGroup(mouseActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(mouseActionJDialogLayout.createSequentialGroup().addComponent(titleJLabel).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(mouseActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(inputTypeJLabel).addComponent(inputAutomationTypeJComboBox, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(mouseActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(jLabel2, GroupLayout.PREFERRED_SIZE, 15, GroupLayout.PREFERRED_SIZE).addGroup(mouseActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(button1JCheckBox).addComponent(button2JCheckBox))).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(mouseActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel6).addComponent(mouseDelayJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(mouseActionJDialogLayout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel3).addComponent(jLabel4).addComponent(jLabel5).addComponent(mouseYJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addComponent(mouseXJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED, GroupLayout.DEFAULT_SIZE, short.MaxValue).addComponent(okJButton).addContainerGap()));
        setMinimumSize(new Dimension(100, 0));
        this.mouseActionJButton.setText("Edit");
        this.mouseActionJButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                mouseActionJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel1.setText("Mouse:");
        GroupLayout layout = new GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jLabel1).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED, 36, short.MaxValue).addComponent(mouseActionJButton)));
        layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(jLabel1).addComponent(mouseActionJButton)));
    }

    private void button2JCheckBoxActionPerformed(ActionEvent evt)
    {
    }

    private void okJButtonActionPerformed(ActionEvent evt)
    {
        try {
            this.update();
            this.getMouseActionJDialog().setVisible(false);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "okButtonActionPerformed", e);
        }
    }

    private void mouseActionJButtonActionPerformed(ActionEvent evt)
    {
        this.getMouseActionJDialog().setVisible(true);
    }

    private JCheckBox button1JCheckBox = null;
    private JCheckBox button2JCheckBox = null;
    private JComboBox inputAutomationTypeJComboBox = null;
    private JLabel inputTypeJLabel = null;
    private JLabel jLabel1 = null;
    private JLabel jLabel2 = null;
    private JLabel jLabel3 = null;
    private JLabel jLabel4 = null;
    private JLabel jLabel5 = null;
    private JLabel jLabel6 = null;
    private JButton mouseActionJButton = null;
    private JDialog mouseActionJDialog = null;
    private JTextField mouseDelayJTextField = null;
    private JTextField mouseXJTextField = null;
    private JTextField mouseYJTextField = null;
    private JButton okJButton = null;
    private JLabel titleJLabel = null;
}

