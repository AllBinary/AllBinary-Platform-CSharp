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
using DefaultListModelHelper = org.allbinary.input.automation.module.DefaultListModelHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.input.automation.module.generic.configuration.profile.actions;

public class GenericProfileActionsJPanel : javax.swing.JPanel
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private GenericProfileActions genericProfileActions = null;
    private GenericProfileActionJPanel genericProfileActionJPanel = null;
    public GenericProfileActionsJPanel()
    {
        this.initComponents();
    }

    private void initComponents()
    {
        this.newProfileActionJDialog = new javax.swing.JDialog();
        this.newProfileActionJLabel = new javax.swing.JLabel();
        this.okNewProfileActionJButton = new javax.swing.JButton();
        this.newProfileActionJTextField = new javax.swing.JTextField();
        this.genericProfileActionsJPanel = new javax.swing.JPanel();
        this.genericProfileActionsJScrollPane = new javax.swing.JScrollPane();
        this.genericProfileActionsJList = new javax.swing.JList();
        this.newActionJButton = new javax.swing.JButton();
        this.deleteActionJButton = new javax.swing.JButton();
        this.saveJButton = new javax.swing.JButton();
        this.blankGenericProfileActionJPanel = new javax.swing.JPanel();
        this.newProfileActionJDialog.setMinimumSize(new java.awt.Dimension(250, 150));
        this.newProfileActionJDialog.setResizable(false);
        this.newProfileActionJLabel.setText("New Action Name");
        this.okNewProfileActionJButton.setText("Ok");
        this.okNewProfileActionJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                okNewProfileActionJButtonActionPerformed(evt);
            }

#endif
);
        javax.swing.GroupLayout newProfileActionJDialogLayout = new javax.swing.GroupLayout(this.newProfileActionJDialog.getContentPane());
        this.newProfileActionJDialog.getContentPane().setLayout(newProfileActionJDialogLayout);
        newProfileActionJDialogLayout.setHorizontalGroup(newProfileActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(newProfileActionJDialogLayout.createSequentialGroup().addGroup(newProfileActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(newProfileActionJDialogLayout.createSequentialGroup().addGap(93, 93, 93).addComponent(okNewProfileActionJButton)).addGroup(newProfileActionJDialogLayout.createSequentialGroup().addGap(75, 75, 75).addComponent(newProfileActionJLabel)).addGroup(newProfileActionJDialogLayout.createSequentialGroup().addGap(29, 29, 29).addComponent(newProfileActionJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, 178, javax.swing.GroupLayout.PREFERRED_SIZE))).addContainerGap(34, short.MaxValue)));
        newProfileActionJDialogLayout.setVerticalGroup(newProfileActionJDialogLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(javax.swing.GroupLayout.Alignment.TRAILING, newProfileActionJDialogLayout.createSequentialGroup().addContainerGap().addComponent(newProfileActionJLabel).addGap(21, 21, 21).addComponent(newProfileActionJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 20, short.MaxValue).addComponent(okNewProfileActionJButton).addContainerGap()));
        this.genericProfileActionsJPanel.setPreferredSize(new java.awt.Dimension(10000, 10000));
        this.genericProfileActionsJList.addListSelectionListener(new javax.swing.event.ListSelectionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void valueChanged(javax.swing.event.ListSelectionEvent evt)
            {
                genericProfileActionsJListValueChanged(evt);
            }

#endif
);
        this.genericProfileActionsJScrollPane.setViewportView(this.genericProfileActionsJList);
        this.newActionJButton.setText("New");
        this.newActionJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                newActionJButtonActionPerformed(evt);
            }

#endif
);
        this.deleteActionJButton.setText("Delete");
        this.deleteActionJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                deleteActionJButtonActionPerformed(evt);
            }

#endif
);
        this.saveJButton.setText("Save");
        this.saveJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                saveJButtonActionPerformed(evt);
            }

#endif
);
        this.blankGenericProfileActionJPanel.setMinimumSize(new java.awt.Dimension(500, 300));
        javax.swing.GroupLayout blankGenericProfileActionJPanelLayout = new javax.swing.GroupLayout(this.blankGenericProfileActionJPanel);
        this.blankGenericProfileActionJPanel.setLayout(blankGenericProfileActionJPanelLayout);
        blankGenericProfileActionJPanelLayout.setHorizontalGroup(blankGenericProfileActionJPanelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGap(0, 500, short.MaxValue));
        blankGenericProfileActionJPanelLayout.setVerticalGroup(blankGenericProfileActionJPanelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGap(0, 296, short.MaxValue));
        javax.swing.GroupLayout genericProfileActionsJPanelLayout = new javax.swing.GroupLayout(this.genericProfileActionsJPanel);
        this.genericProfileActionsJPanel.setLayout(genericProfileActionsJPanelLayout);
        genericProfileActionsJPanelLayout.setHorizontalGroup(genericProfileActionsJPanelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(genericProfileActionsJPanelLayout.createSequentialGroup().addComponent(genericProfileActionsJScrollPane, javax.swing.GroupLayout.PREFERRED_SIZE, 95, javax.swing.GroupLayout.PREFERRED_SIZE).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(blankGenericProfileActionJPanel, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, short.MaxValue)).addGroup(genericProfileActionsJPanelLayout.createSequentialGroup().addComponent(newActionJButton).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(deleteActionJButton).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addComponent(saveJButton).addContainerGap()));
        genericProfileActionsJPanelLayout.setVerticalGroup(genericProfileActionsJPanelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(genericProfileActionsJPanelLayout.createSequentialGroup().addGroup(genericProfileActionsJPanelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(newActionJButton).addComponent(deleteActionJButton).addComponent(saveJButton)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(genericProfileActionsJPanelLayout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING, false).addComponent(blankGenericProfileActionJPanel, 0, 296, short.MaxValue).addComponent(genericProfileActionsJScrollPane, javax.swing.GroupLayout.DEFAULT_SIZE, 296, short.MaxValue)).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, short.MaxValue)));
        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(this);
        this.setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addComponent(genericProfileActionsJPanel, javax.swing.GroupLayout.PREFERRED_SIZE, 596, javax.swing.GroupLayout.PREFERRED_SIZE).addContainerGap(javax.swing.GroupLayout.DEFAULT_SIZE, short.MaxValue)));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(genericProfileActionsJPanel, javax.swing.GroupLayout.PREFERRED_SIZE, 336, javax.swing.GroupLayout.PREFERRED_SIZE));
    }

    public virtual void setModel()
    {
        DefaultListModelHelper defaultListModelHelper = this.getGenericProfileActions().getDefaultListModelHelper();
        if (defaultListModelHelper.getListModel().getSize() > 0) {
            this.genericProfileActionsJList.setModel(defaultListModelHelper.getListModel());
        }
    }

    private void saveJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            this.getGenericProfileActions().save();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "saveJButtonActionPerformed", e);
        }
    }

    private void updateProfileActionUI(string profileActionNameString)
    {
        this.blankGenericProfileActionJPanel.removeAll();
        if (profileActionNameString != null) {
            GenericProfileAction genericProfileAction = this.getGenericProfileActions().getAction(profileActionNameString);
            this.setGenericProfileActionJPanel(new GenericProfileActionJPanel());
            this.getGenericProfileActionJPanel().setGenericProfileAction(genericProfileAction);
            this.getGenericProfileActionJPanel().updateProfileActionUI();
            javax.swing.GroupLayout layout = ((javax.swing.GroupLayout) this.blankGenericProfileActionJPanel.getLayout());
            layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGap(0, 395, short.MaxValue).addComponent(this.getGenericProfileActionJPanel(), javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE));
            layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGap(0, 256, short.MaxValue).addComponent(this.getGenericProfileActionJPanel(), javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE));
            this.logUtil.putF("Setting Configuration Profile Actions JPanel", this, "genericProfileActionsJListValueChanged");
        }
    }

    private void genericProfileActionsJListValueChanged(javax.swing.event.ListSelectionEvent evt)
    {
        try {
            string profileActionNameString = ((string) this.genericProfileActionsJList.getSelectedValue());
            this.updateProfileActionUI(profileActionNameString);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "genericProfileActionsJListValueChanged", e);
        }
    }

    private void okNewProfileActionJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            string newActionName = this.newProfileActionJTextField.getText();
            this.getGenericProfileActions().add(newActionName);
            this.setModel();
            this.genericProfileActionsJList.setSelectedValue(newActionName, true);
            this.newProfileActionJDialog.setVisible(false);
            this.updateProfileActionUI(newActionName);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "okNewProfileActionJButtonActionPerformed", e);
        }
    }

    private void deleteActionJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            object[] anyType = this.genericProfileActionsJList.getSelectedValues();
            for (int index = 0; index < anyType.Length; index++) {
                string nextSelectedValueString = ((string) anyType[index]);
                this.getGenericProfileActions().remove(nextSelectedValueString);
            }
            this.selectFirstElement();
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, this, "deleteActionJButtonActionPerformed", e);
        }
    }

    // throws Exception
    public virtual void selectFirstElement()
    {
        this.setModel();
        if (this.genericProfileActionsJList.getModel().getSize() > 0) {
            this.genericProfileActionsJList.setSelectedValue(this.genericProfileActionsJList.getModel().getElementAt(0), true);
            this.updateProfileActionUI(((string) this.genericProfileActionsJList.getModel().getElementAt(0)));
        } else {
            this.blankGenericProfileActionJPanel.removeAll();
            this.blankGenericProfileActionJPanel.repaint();
        }
    }

    public virtual GenericProfileActionJPanel getGenericProfileActionJPanel()
    {
        return this.genericProfileActionJPanel;
    }

    public virtual void setGenericProfileActionJPanel(GenericProfileActionJPanel genericProfileActionJPanel)
    {
        this.genericProfileActionJPanel = genericProfileActionJPanel;
    }

    public virtual GenericProfileActions getGenericProfileActions()
    {
        return this.genericProfileActions;
    }

    public virtual void setGenericProfileActions(GenericProfileActions genericProfileActions)
    {
        this.genericProfileActions = genericProfileActions;
    }

    private void newActionJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.newProfileActionJDialog.setVisible(true);
    }

    private javax.swing.JPanel blankGenericProfileActionJPanel = null;
    private javax.swing.JButton deleteActionJButton = null;
    private javax.swing.JList genericProfileActionsJList = null;
    private javax.swing.JPanel genericProfileActionsJPanel = null;
    private javax.swing.JScrollPane genericProfileActionsJScrollPane = null;
    private javax.swing.JButton newActionJButton = null;
    private javax.swing.JDialog newProfileActionJDialog = null;
    private javax.swing.JLabel newProfileActionJLabel = null;
    private javax.swing.JTextField newProfileActionJTextField = null;
    private javax.swing.JButton okNewProfileActionJButton = null;
    private javax.swing.JButton saveJButton = null;
}

