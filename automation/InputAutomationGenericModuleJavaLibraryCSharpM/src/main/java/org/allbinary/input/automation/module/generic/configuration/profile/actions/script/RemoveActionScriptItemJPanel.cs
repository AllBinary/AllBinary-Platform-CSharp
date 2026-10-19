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
using ProfileActionScriptConditionInterface = org.allbinary.input.automation.actions.script.condition.ProfileActionScriptConditionInterface;
using GenericProfileAction = org.allbinary.input.automation.module.generic.configuration.profile.actions.GenericProfileAction;
using GenericProfileActionJPanel = org.allbinary.input.automation.module.generic.configuration.profile.actions.GenericProfileActionJPanel;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.input.automation.module.generic.configuration.profile.actions.script;

public class RemoveActionScriptItemJPanel : java.awt.Panel
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private GenericProfileActionJPanel genericProfileActionJPanel;
    private ProfileActionScriptConditionInterface profileActionScriptConditionInterface;
    public RemoveActionScriptItemJPanel(GenericProfileActionJPanel genericProfileActionJPanel, ProfileActionScriptConditionInterface profileActionScriptConditionInterface)
    {
        this.initComponents();
        this.genericProfileActionJPanel = genericProfileActionJPanel;
        this.profileActionScriptConditionInterface = profileActionScriptConditionInterface;
    }

    private void initComponents()
    {
        this.removeJButton = new javax.swing.JButton();
        setLayout(new java.awt.GridLayout());
        this.removeJButton.setText("Remove");
        this.removeJButton.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                removeJButtonActionPerformed(evt);
            }

#endif
);
        add(this.removeJButton);
    }

    private void removeJButtonActionPerformed(java.awt.event.ActionEvent evt)
    {
        GenericProfileAction genericProfileAction = this.genericProfileActionJPanel.getGenericProfileAction();
        if (genericProfileAction == null) {
            this.logUtil.putF("GenericProfileAction was null", this, "removeJButtonActionPerformed");
            return;
        }
        genericProfileAction.getGenericProfileActionScript().removeCondition(this.profileActionScriptConditionInterface);
        this.genericProfileActionJPanel.updateProfileActionUI();
    }

    private javax.swing.JButton removeJButton = null;
}

