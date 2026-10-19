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
//using File = java.io.File;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.gui.dialog;

public class FileJDialog : javax.swing.JDialog
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private FileJDialogListenerInterface finishedListenerInterface = null;
    public FileJDialog() : base()
    {
        // base() is called from the constructor declaration
        this.initComponents();
        this.getJFileChooser1().setMultiSelectionEnabled(true);
    }

    public FileJDialog(java.awt.Frame parent, bool modal) : base(parent, modal)
    {
        // base(parent, modal) is called from the constructor declaration
        this.initComponents();
        this.getJFileChooser1().setMultiSelectionEnabled(true);
    }

    public virtual void addFinishedListener(FileJDialogListenerInterface finishedListenerInterface)
    {
        this.finishedListenerInterface = finishedListenerInterface;
    }

    private void initComponents()
    {
        this.jFileChooser1 = new javax.swing.JFileChooser();
        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        this.jFileChooser1.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                jFileChooser1ActionPerformed(evt);
            }

#endif
);
        org.jdesktop.layout.GroupLayout layout = new org.jdesktop.layout.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(org.jdesktop.layout.GroupLayout.TRAILING, layout.createSequentialGroup().addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE).add(jFileChooser1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(layout.createSequentialGroup().addContainerGap().add(jFileChooser1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 357, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE).addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE)));
        pack();
    }

    private void jFileChooser1ActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.logUtil.putF("Starting Action Command: " + evt.getActionCommand(), this, "ActionPerformed");
        File[] files = this.getJFileChooser1().getSelectedFiles();
        if (evt.getActionCommand() == this.getJFileChooser1().CANCEL_SELECTION) {
            this.setVisible(false);
        }
        if (evt.getActionCommand() == this.getJFileChooser1().APPROVE_SELECTION) {
            if (files != null && files.Length > 0) {
                this.finishedListenerInterface.onFiles(files);
            }
        }
    }

    public static void main(string[] args)
    {
        java.awt.EventQueue.invokeLater(new ARunnable()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void run()
            {
                new FileJDialog(new javax.swing.JFrame(), true).setVisible(true);
            }

#endif
);
    }

    public virtual javax.swing.JFileChooser getJFileChooser1()
    {
        return this.jFileChooser1;
    }

    public virtual void setJFileChooser1(javax.swing.JFileChooser jFileChooser1)
    {
        this.jFileChooser1 = jFileChooser1;
    }

    private javax.swing.JFileChooser jFileChooser1 = null;
}

