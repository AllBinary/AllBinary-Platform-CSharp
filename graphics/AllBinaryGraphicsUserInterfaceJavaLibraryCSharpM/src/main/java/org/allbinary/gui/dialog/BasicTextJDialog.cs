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
//using EventQueue = java.awt.EventQueue;
//using Frame = java.awt.Frame;
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
//using GroupLayout = javax.swing.GroupLayout;
//using JButton = javax.swing.JButton;
//using JDialog = javax.swing.JDialog;
//using JFrame = javax.swing.JFrame;
//using JLabel = javax.swing.JLabel;
//using WindowConstants = javax.swing.WindowConstants;

namespace org.allbinary.gui.dialog;

public class BasicTextJDialog : JDialog
{
    private CloseJDialogListenerInterface closeListenerInterface = null;
    public BasicTextJDialog(Frame parent, bool modal, string text) : base(parent, modal)
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
        this.jButton1 = new JButton();
        this.textJLabel = new JLabel();
        setDefaultCloseOperation(WindowConstants.DISPOSE_ON_CLOSE);
        this.jButton1.setText("OK");
        jButton1.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                jButton1ActionPerformed(evt);
            }

#endif
);
        this.textJLabel.setText("No Text Set");
        GroupLayout layout = new GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addGap(80, 80, 80).addComponent(jButton1)).addGroup(layout.createSequentialGroup().addContainerGap().addComponent(textJLabel, GroupLayout.DEFAULT_SIZE, 184, short.MaxValue))).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addGap(20, 20, 20).addComponent(textJLabel, GroupLayout.PREFERRED_SIZE, 20, GroupLayout.PREFERRED_SIZE).addGap(30, 30, 30).addComponent(jButton1)));
        pack();
    }

    private void jButton1ActionPerformed(ActionEvent evt)
    {
        this.setVisible(false);
        if (this.closeListenerInterface != null) {
            this.closeListenerInterface.onClose();
        }
    }

    public static void main(string[] args)
    {
        EventQueue.invokeLater(new ARunnable()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void run()
            {
                new BasicTextJDialog(new JFrame(), true, "Test").setVisible(true);
            }

#endif
);
    }

    private JButton jButton1 = null;
    private JLabel textJLabel = null;
}

