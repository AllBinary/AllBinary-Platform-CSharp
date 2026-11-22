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
using File = java.io.File;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
//using EventQueue = java.awt.EventQueue;
//using Frame = java.awt.Frame;
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
//using JDialog = javax.swing.JDialog;
//using JFileChooser = javax.swing.JFileChooser;
//using JFrame = javax.swing.JFrame;
//using WindowConstants = javax.swing.WindowConstants;

namespace org.allbinary.gui.dialog;

public class FileJDialog : JDialog
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private FileJDialogListenerInterface finishedListenerInterface = null;
    public FileJDialog() : base()
    {
        // Constructor invocation emitted in the initializer.
        this.initComponents();
        this.getJFileChooser1().setMultiSelectionEnabled(true);
    }

    public FileJDialog(Frame parent, bool modal) : base(parent, modal)
    {
        // Constructor invocation emitted in the initializer.
        this.initComponents();
        this.getJFileChooser1().setMultiSelectionEnabled(true);
    }

    public virtual void addFinishedListener(FileJDialogListenerInterface finishedListenerInterface)
    {
        this.finishedListenerInterface = finishedListenerInterface;
    }

    private void initComponents()
    {
        this.jFileChooser1 = new JFileChooser();
        setDefaultCloseOperation(WindowConstants.DISPOSE_ON_CLOSE);
        this.jFileChooser1.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                jFileChooser1ActionPerformed(evt);
            }

#endif
);
        org.jdesktop.layout.GroupLayout layout = new org.jdesktop.layout.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(org.jdesktop.layout.GroupLayout.TRAILING, layout.createSequentialGroup().addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, short.MaxValue).add(jFileChooser1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE).addContainerGap()));
        layout.setVerticalGroup(layout.createParallelGroup(org.jdesktop.layout.GroupLayout.LEADING).add(layout.createSequentialGroup().addContainerGap().add(jFileChooser1, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE, 357, org.jdesktop.layout.GroupLayout.PREFERRED_SIZE).addContainerGap(org.jdesktop.layout.GroupLayout.DEFAULT_SIZE, short.MaxValue)));
        pack();
    }

    private void jFileChooser1ActionPerformed(ActionEvent evt)
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
        EventQueue.invokeLater(new __SwtClosure_N67618((__swtSelf_N67618) => {
                new FileJDialog(new JFrame(), true).setVisible(true);
            }));
    }

    public virtual JFileChooser getJFileChooser1()
    {
        return this.jFileChooser1;
    }

    public virtual void setJFileChooser1(JFileChooser jFileChooser1)
    {
        this.jFileChooser1 = jFileChooser1;
    }

    private JFileChooser jFileChooser1 = null;
    private sealed class __SwtClosure_N67618 : ARunnable
    {
        private readonly global::System.Action<__SwtClosure_N67618> callback1;

        public __SwtClosure_N67618(global::System.Action<__SwtClosure_N67618> callback1)
        {
            this.callback1 = callback1;
        }

        public override void run() => callback1(this);
    }

}

