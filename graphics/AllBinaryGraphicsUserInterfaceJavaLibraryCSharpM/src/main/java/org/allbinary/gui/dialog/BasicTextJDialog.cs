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

namespace org.allbinary.gui.dialog;

public class BasicTextJDialog : javax.swing.JDialog
{
    private CloseJDialogListenerInterface closeListenerInterface = null;
    public BasicTextJDialog(java.awt.Frame parent, bool modal, string text) : base(parent, modal)
    {
        // base(parent, modal) is called from the constructor declaration
        this.initComponents();
        this.setText(text);
    }

    public virtual void setText(string text)
    {
        this.textJLabel.setText(text);
    }

    public virtual void addCloseListener(CloseJDialogListenerInterface closeListenerInterface)
    {
        this.closeListenerInterface = closeListenerInterface;
    }

    public BasicTextJDialog(string text)
    {
        this.initComponents();
        this.textJLabel.setText(text);
    }

    private void initComponents()
    {
        this.jButton1 = new javax.swing.JButton();
        this.textJLabel = new javax.swing.JLabel();
        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        this.jButton1.setText("OK");
        jButton1.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                jButton1ActionPerformed(evt);
            }

#endif
);
        this.textJLabel.setText("No Text Set");
        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addGap(80, 80, 80).addComponent(jButton1)).addGroup(layout.createSequentialGroup().addContainerGap().addComponent(textJLabel, javax.swing.GroupLayout.DEFAULT_SIZE, 184, short.MaxValue))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addGap(20, 20, 20).addComponent(textJLabel, javax.swing.GroupLayout.PREFERRED_SIZE, 20, javax.swing.GroupLayout.PREFERRED_SIZE).addGap(30, 30, 30).addComponent(jButton1)));
        pack();
    }

    private void jButton1ActionPerformed(java.awt.event.ActionEvent evt)
    {
        this.setVisible(false);
        if (this.closeListenerInterface != null) {
            this.closeListenerInterface.onClose();
        }
    }

    public static void main(string[] args)
    {
        java.awt.EventQueue.invokeLater(new ARunnable()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void run()
            {
                new BasicTextJDialog(new javax.swing.JFrame(), true, "Test").setVisible(true);
            }

#endif
);
    }

    private javax.swing.JButton jButton1 = null;
    private javax.swing.JLabel textJLabel = null;
}

