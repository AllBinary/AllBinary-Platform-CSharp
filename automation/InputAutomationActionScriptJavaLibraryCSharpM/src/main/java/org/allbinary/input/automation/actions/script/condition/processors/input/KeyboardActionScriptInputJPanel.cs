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
using KeySingletonFactory = org.allbinary.input.KeySingletonFactory;
using InputRobot = org.allbinary.input.automation.robot.InputRobot;
using InputRobotFactory = org.allbinary.input.automation.robot.InputRobotFactory;
using TempInputRobotNames = org.allbinary.input.automation.robot.TempInputRobotNames;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using CommonPhoneStrings = org.allbinary.@string.CommonPhoneStrings;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.automation.actions.script.condition.processors.input;

public class KeyboardActionScriptInputJPanel : javax.swing.JPanel
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private KeyboardActionScriptInputInterface keyActionScriptInputInterface;
    public KeyboardActionScriptInputJPanel(KeyboardActionScriptInputInterface keyActionScriptInputInterface)
    {
        this.logUtil.putF(this.commonStrings.START, this, this.commonStrings.CONSTRUCTOR);
        this.initComponents();
        this.keyActionScriptInputInterface = keyActionScriptInputInterface;
        DefaultComboBoxModel defaultComboBoxModel = new DefaultComboBoxModel();
        defaultComboBoxModel.addElement(TempInputRobotNames.DX_NAME);
        defaultComboBoxModel.addElement(InputRobot.NAME);
        this.inputAutomationTypeJComboBox.setModel(defaultComboBoxModel);
        this.keyNameJComboBox.setModel(KeyNameDefaultComboBoxModelFactory.getInstance());
        this.keyIntegerJComboBox.setModel(KeyCharDefaultComboBoxModelFactory.getInstance());
        if (this.keyActionScriptInputInterface.isNormal()) {
            this.normalJRadioButton.setSelected(true);
            this.pressJRadioButton.setSelected(false);
            this.releaseJRadioButton.setSelected(false);
        } else if (this.keyActionScriptInputInterface.isPress()) {
            this.normalJRadioButton.setSelected(false);
            this.pressJRadioButton.setSelected(true);
            this.releaseJRadioButton.setSelected(false);
        } else if (this.keyActionScriptInputInterface.isRelease()) {
            this.normalJRadioButton.setSelected(false);
            this.pressJRadioButton.setSelected(false);
            this.releaseJRadioButton.setSelected(true);
        }
        this.set();
    }

    private void set()
    {
        ComboBoxModel inputTypeComboBoxModel = this.inputAutomationTypeJComboBox.getModel();
        inputTypeComboBoxModel.setSelectedItem(this.keyActionScriptInputInterface.getInputRobotInterface().getName());
        this.textJTextField.setText(this.keyActionScriptInputInterface.getText());
        this.delayJTextField.setText((this.keyActionScriptInputInterface.getDelayBetweenKeys()).ToString());
        this.timeJTextField.setText((this.keyActionScriptInputInterface.getTime()).ToString());
        this.keyActionScriptInputInterface.log();
    }

    // throws Exception
    private void updateInputType()
    {
        ComboBoxModel comboBoxModel = this.inputAutomationTypeJComboBox.getModel();
        string selectedItem = ((string) comboBoxModel.getSelectedItem());
        if (!StringValidationUtil.getInstance().isEmpty(selectedItem)) {
            this.keyActionScriptInputInterface.setInputRobotInterface(InputRobotFactory.getInstance().get(selectedItem));
        }
    }

    private int? getSelectedKey()
    {
        ComboBoxModel comboBoxModel = this.keyNameJComboBox.getModel();
        string selectedItem = ((string) comboBoxModel.getSelectedItem());
        if (!StringValidationUtil.getInstance().isEmpty(selectedItem)) {
            return ((int?) KeySingletonFactory.getHashtable().get(selectedItem));
        }
        return null;
    }

    private void updateKeys()
    {
        string text = this.textJTextField.getText();
        this.keyActionScriptInputInterface.setText(text);
    }

    // throws Exception
    private void update()
    {
        this.updateInputType();
        this.updateKeys();
        this.keyActionScriptInputInterface.setTime(((int) (this.timeJTextField.getText()).ToString()));
        this.keyActionScriptInputInterface.log();
    }

    public virtual javax.swing.JDialog getKeyActionJDialog()
    {
        return this.keyActionJDialog;
    }

    public virtual void setKeyActionJDialog(javax.swing.JDialog keyActionJDialog)
    {
        this.keyActionJDialog = keyActionJDialog;
    }

    private void initComponents()
    {
        this.keyActionJDialog = new javax.swing.JDialog();
        this.titleJLabel = new javax.swing.JLabel();
        this.addKeyJLabel = new javax.swing.JLabel();
        this.keyNameJComboBox = new javax.swing.JComboBox();
        this.timeJTextField = new javax.swing.JTextField();
        this.holdTimeJLabel = new javax.swing.JLabel();
        this.inputAutomationTypeJComboBox = new javax.swing.JComboBox();
        this.inputTypeJLabel = new javax.swing.JLabel();
        this.delayJTextField = new javax.swing.JTextField();
        this.delayBetweenJLabel = new javax.swing.JLabel();
        this.testJLabel = new javax.swing.JLabel();
        this.textJTextField = new javax.swing.JTextField();
        this.pressJRadioButton = new javax.swing.JRadioButton();
        this.releaseJRadioButton = new javax.swing.JRadioButton();
        this.normalJRadioButton = new javax.swing.JRadioButton();
        this.simultaneousJRadioButton = new javax.swing.JRadioButton();
        this.sequenceJRadioButton = new javax.swing.JRadioButton();
        this.jPanel1 = new javax.swing.JPanel();
        this.okJButton = new javax.swing.JButton();
        this.keyIntegerJComboBox = new javax.swing.JComboBox();
        this.keyActionJButton = new javax.swing.JButton();
        this.jLabel1 = new javax.swing.JLabel();
        this.keyActionJDialog.setMinimumSize(new java.awt.Dimension(255, 280));
        this.titleJLabel.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        this.titleJLabel.setText("Keyboard Input Options");
        this.addKeyJLabel.setText("Add Key:");
        this.keyNameJComboBox.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                keyNameJComboBoxActionPerformed(evt);
            }

#endif
);
        this.timeJTextField.setText(CommonPhoneStrings.getInstance().ZERO);
        this.holdTimeJLabel.setText("Hold Time (ms):");
        this.inputTypeJLabel.setText("Input Type:");
        this.delayJTextField.setText(CommonPhoneStrings.getInstance().ZERO);
        this.delayBetweenJLabel.setText("Delay Between Keys (ms):");
        this.testJLabel.setText("Text:");
        this.textJTextField.setText(CommonPhoneStrings.getInstance().ZERO);
        this.pressJRadioButton.setText("Press");
        this.pressJRadioButton.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.pressJRadioButton.setMargin(new java.awt.Insets(0, 0, 0, 0));
        this.pressJRadioButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                pressJRadioButtonActionPerformed(evt);
            }

#endif
);
        this.releaseJRadioButton.setText("Release");
        this.releaseJRadioButton.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.releaseJRadioButton.setMargin(new java.awt.Insets(0, 0, 0, 0));
        this.releaseJRadioButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                releaseJRadioButtonActionPerformed(evt);
            }

#endif
);
        this.normalJRadioButton.setSelected(true);
        this.normalJRadioButton.setText("Normal");
        this.normalJRadioButton.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.normalJRadioButton.setMargin(new java.awt.Insets(0, 0, 0, 0));
        this.normalJRadioButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                normalJRadioButtonActionPerformed(evt);
            }

#endif
);
        this.simultaneousJRadioButton.setSelected(true);
        this.simultaneousJRadioButton.setText("Simultaneous");
        this.simultaneousJRadioButton.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.simultaneousJRadioButton.setMargin(new java.awt.Insets(0, 0, 0, 0));
        this.simultaneousJRadioButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                simultaneousJRadioButtonActionPerformed(evt);
            }

#endif
);
        this.sequenceJRadioButton.setText("Sequence");
        this.sequenceJRadioButton.setBorder(javax.swing.BorderFactory.createEmptyBorder(0, 0, 0, 0));
        this.sequenceJRadioButton.setMargin(new java.awt.Insets(0, 0, 0, 0));
        this.sequenceJRadioButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                sequenceJRadioButtonActionPerformed(evt);
            }

#endif
);
        this.okJButton.setText("OK");
        this.okJButton.setHorizontalTextPosition(javax.swing.SwingConstants.CENTER);
        this.okJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                okJButtonActionPerformed(evt);
            }

#endif
);
        this.jPanel1.add(this.okJButton);
        this.keyIntegerJComboBox.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                keyIntegerJComboBoxActionPerformed(evt);
            }

#endif
);
        javax.swing.GroupLayout keyActionJDialogLayout = new javax.swing.GroupLayout(this.keyActionJDialog.getContentPane());
        this.keyActionJDialog.getContentPane().setLayout(keyActionJDialogLayout);
        keyActionJDialogLayout.setHorizontalGroup(keyActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(keyActionJDialogLayout.createSequentialGroup().addContainerGap().addGroup(keyActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(keyActionJDialogLayout.createSequentialGroup().addGroup(keyActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false).addComponent(addKeyJLabel, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).addComponent(inputTypeJLabel, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(keyActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addComponent(inputAutomationTypeJComboBox, 0, 148, Short.MAX_VALUE).addComponent(textJTextField, javax.swing.GroupLayout.Alignment.LEADING, javax.swing.GroupLayout.DEFAULT_SIZE, 148, Short.MAX_VALUE).addGroup(keyActionJDialogLayout.createSequentialGroup().addComponent(keyNameJComboBox, 0, 101, Short.MAX_VALUE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(keyIntegerJComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, 41, javax.swing.GroupLayout.PREFERRED_SIZE)))).addComponent(testJLabel, javax.swing.GroupLayout.PREFERRED_SIZE, 60, javax.swing.GroupLayout.PREFERRED_SIZE).addGroup(keyActionJDialogLayout.createSequentialGroup().addComponent(normalJRadioButton).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(pressJRadioButton).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(releaseJRadioButton).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 48, javax.swing.GroupLayout.PREFERRED_SIZE)).addGroup(javax.swing.GroupLayout.Alignment.TRAILING, keyActionJDialogLayout.createSequentialGroup().addComponent(holdTimeJLabel).addGap(22, 22, 22).addComponent(timeJTextField, javax.swing.GroupLayout.DEFAULT_SIZE, 113, Short.MAX_VALUE)).addGroup(keyActionJDialogLayout.createSequentialGroup().addComponent(delayBetweenJLabel).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 15, Short.MAX_VALUE).addComponent(delayJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, 68, javax.swing.GroupLayout.PREFERRED_SIZE)).addGroup(keyActionJDialogLayout.createSequentialGroup().addComponent(simultaneousJRadioButton).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(sequenceJRadioButton))).addContainerGap()).addComponent(titleJLabel, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, 229, Short.MAX_VALUE).addComponent(jPanel1, javax.swing.GroupLayout.DEFAULT_SIZE, 229, Short.MAX_VALUE));
        keyActionJDialogLayout.setVerticalGroup(keyActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(keyActionJDialogLayout.createSequentialGroup().addComponent(titleJLabel).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(keyActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(inputTypeJLabel).addComponent(inputAutomationTypeJComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(keyActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(addKeyJLabel).addComponent(keyIntegerJComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(keyNameJComboBox, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(keyActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(testJLabel).addComponent(textJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(keyActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(pressJRadioButton).addComponent(normalJRadioButton).addComponent(releaseJRadioButton)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(keyActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(holdTimeJLabel).addComponent(timeJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(keyActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(delayBetweenJLabel).addComponent(delayJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(keyActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(simultaneousJRadioButton).addComponent(sequenceJRadioButton)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(jPanel1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addContainerGap()));
        setMinimumSize(new java.awt.Dimension(100, 0));
        this.keyActionJButton.setText("Edit");
        this.keyActionJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                keyActionJButtonActionPerformed(evt);
            }

#endif
);
        this.jLabel1.setText("Key:");
        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(jLabel1).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 49, Short.MAX_VALUE).addComponent(keyActionJButton)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(jLabel1).addComponent(keyActionJButton)));
    }

    private void prependText(int? integer)
    {
        if (integer != null) {
            string newKey = "&#" + integer.ToString() + ";";
            this.textJTextField.setText(newKey + this.textJTextField.getText());
        }
    }

    private void keyIntegerJComboBoxActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.keyIntegerJComboBox.getSelectedIndex();
        this.keyNameJComboBox.setSelectedIndex(this.keyIntegerJComboBox.getSelectedIndex());
    }

    private void sequenceJRadioButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        if (this.sequenceJRadioButton.isSelected()) {
            this.delayJTextField.setText(CommonPhoneStrings.getInstance().ONE);
            this.simultaneousJRadioButton.setSelected(false);
        }
    }

    private void simultaneousJRadioButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        if (this.simultaneousJRadioButton.isSelected()) {
            this.delayJTextField.setText(CommonPhoneStrings.getInstance().ZERO);
            this.sequenceJRadioButton.setSelected(false);
        }
    }

    private void keyNameJComboBoxActionPerformed(java.awt.event.ActionEvent evt)
    {
        int? integer = this.getSelectedKey();
        this.prependText(integer);
        this.keyIntegerJComboBox.setSelectedIndex(this.keyNameJComboBox.getSelectedIndex());
    }

    private void okJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            this.update();
            this.getKeyActionJDialog().setVisible(false);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "okButtonActionPerformed", e);
        }
    }

    private void keyActionJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.getKeyActionJDialog().setVisible(true);
    }

    private void normalJRadioButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        if (this.normalJRadioButton.isSelected()) {
            this.keyActionScriptInputInterface.setNormal();
            this.pressJRadioButton.setSelected(false);
            this.releaseJRadioButton.setSelected(false);
        }
    }

    private void releaseJRadioButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        if (this.releaseJRadioButton.isSelected()) {
            this.keyActionScriptInputInterface.setRelease(true);
            this.keyActionScriptInputInterface.setPress(false);
            this.pressJRadioButton.setSelected(false);
            this.normalJRadioButton.setSelected(false);
        }
    }

    private void pressJRadioButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        if (this.pressJRadioButton.isSelected()) {
            this.keyActionScriptInputInterface.setPress(true);
            this.keyActionScriptInputInterface.setRelease(false);
            this.releaseJRadioButton.setSelected(false);
            this.normalJRadioButton.setSelected(false);
        }
    }

    private javax.swing.JLabel addKeyJLabel = null;
    private javax.swing.JLabel delayBetweenJLabel = null;
    private javax.swing.JTextField delayJTextField = null;
    private javax.swing.JLabel holdTimeJLabel = null;
    private javax.swing.JComboBox inputAutomationTypeJComboBox = null;
    private javax.swing.JLabel inputTypeJLabel = null;
    private javax.swing.JLabel jLabel1 = null;
    private javax.swing.JPanel jPanel1 = null;
    private javax.swing.JButton keyActionJButton = null;
    private javax.swing.JDialog keyActionJDialog = null;
    private javax.swing.JComboBox keyIntegerJComboBox = null;
    private javax.swing.JComboBox keyNameJComboBox = null;
    private javax.swing.JRadioButton normalJRadioButton = null;
    private javax.swing.JButton okJButton = null;
    private javax.swing.JRadioButton pressJRadioButton = null;
    private javax.swing.JRadioButton releaseJRadioButton = null;
    private javax.swing.JRadioButton sequenceJRadioButton = null;
    private javax.swing.JRadioButton simultaneousJRadioButton = null;
    private javax.swing.JLabel testJLabel = null;
    private javax.swing.JTextField textJTextField = null;
    private javax.swing.JTextField timeJTextField = null;
    private javax.swing.JLabel titleJLabel = null;
}

