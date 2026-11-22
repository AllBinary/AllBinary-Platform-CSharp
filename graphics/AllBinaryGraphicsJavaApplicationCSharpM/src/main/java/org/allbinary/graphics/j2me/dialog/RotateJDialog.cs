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
using java.util;
using HashMapJDialogListenerInterface = org.allbinary.gui.dialog.HashMapJDialogListenerInterface;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
//using EventQueue = java.awt.EventQueue;
//using Frame = java.awt.Frame;
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
//using WindowAdapter = java.awt.@event.WindowAdapter;
//using WindowEvent = java.awt.@event.WindowEvent;
//using GroupLayout = javax.swing.GroupLayout;
//using JButton = javax.swing.JButton;
//using JDialog = javax.swing.JDialog;
//using JFrame = javax.swing.JFrame;
//using JLabel = javax.swing.JLabel;
//using JPanel = javax.swing.JPanel;
//using JTextField = javax.swing.JTextField;
//using LayoutStyle = javax.swing.LayoutStyle;
//using WindowConstants = javax.swing.WindowConstants;

namespace org.allbinary.graphics.j2me.dialog;

public class RotateJDialog : JDialog
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
    public RotateJDialog(Frame parent, bool modal) : base(parent, modal)
    {
        // Constructor invocation emitted in the initializer.
        this.initComponents();
    }

    private void initComponents()
    {
        angleIncrementJTextField = new JTextField();
        this.jLabel1 = new JLabel();
        this.totalRotationJTextField = new JTextField();
        this.jLabel2 = new JLabel();
        this.jPanel1 = new JPanel();
        this.jButton1 = new JButton();
        setDefaultCloseOperation(WindowConstants.DISPOSE_ON_CLOSE);
        this.angleIncrementJTextField.setText("36");
        this.jLabel1.setText("Angle Increment:");
        this.totalRotationJTextField.setText("360");
        this.jLabel2.setText("Total Angular Rotation:");
        this.jButton1.setText("OK");
        this.jButton1.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(ActionEvent evt)
            {
                jButton1ActionPerformed(evt);
            }

#endif
);
        GroupLayout jPanel1Layout = new GroupLayout(this.jPanel1);
        this.jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(jPanel1Layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(jPanel1Layout.createSequentialGroup().addGap(62, 62, 62).addComponent(jButton1).addContainerGap(62, short.MaxValue)));
        jPanel1Layout.setVerticalGroup(jPanel1Layout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(jButton1));
        GroupLayout layout = new GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addContainerGap().addGroup(layout.createParallelGroup(GroupLayout.Alignment.TRAILING).addComponent(jLabel1).addComponent(jLabel2)).addPreferredGap(LayoutStyle.ComponentPlacement.UNRELATED).addGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addComponent(totalRotationJTextField, GroupLayout.Alignment.TRAILING, GroupLayout.DEFAULT_SIZE, 31, short.MaxValue).addComponent(angleIncrementJTextField, GroupLayout.Alignment.TRAILING, GroupLayout.PREFERRED_SIZE, 31, GroupLayout.PREFERRED_SIZE)).addContainerGap()).addComponent(jPanel1, GroupLayout.Alignment.TRAILING, GroupLayout.DEFAULT_SIZE, GroupLayout.DEFAULT_SIZE, short.MaxValue));
        layout.setVerticalGroup(layout.createParallelGroup(GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addContainerGap().addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(angleIncrementJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addComponent(jLabel1)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(GroupLayout.Alignment.BASELINE).addComponent(totalRotationJTextField, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addComponent(jLabel2)).addPreferredGap(LayoutStyle.ComponentPlacement.RELATED, 16, short.MaxValue).addComponent(jPanel1, GroupLayout.PREFERRED_SIZE, GroupLayout.DEFAULT_SIZE, GroupLayout.PREFERRED_SIZE).addContainerGap()));
        pack();
    }

    private void jButton1ActionPerformed(ActionEvent evt)
    {
        try {
            this.hashMap.put(int.Parse((0).ToString()), int.Parse((this.angleIncrementJTextField.getText()).ToString()));
            this.hashMap.put(int.Parse((1).ToString()), int.Parse((this.totalRotationJTextField.getText()).ToString()));
            (((HashMapJDialogListenerInterface) this.getParent())).onHashMap(this.hashMap);
            this.setVisible(false);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.putF(commonStrings.EXCEPTION, this, "jButton1ActionPerformed");
        }
    }

    public static void main(string[] args)
    {
        EventQueue.invokeLater(new __SwtClosure_N68782((__swtSelf_N68782) => {
                RotateJDialog dialog = new RotateJDialog(new JFrame(), true);
                dialog.addWindowListener(new WindowAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
                    public virtual void windowClosing(WindowEvent e)
                    {
                        Environment.Exit(0);
                    }

#endif
);
                dialog.setVisible(true);
            }));
    }

    private JTextField angleIncrementJTextField = null;
    private JButton jButton1 = null;
    private JLabel jLabel1 = null;
    private JLabel jLabel2 = null;
    private JPanel jPanel1 = null;
    private JTextField totalRotationJTextField = null;
    private sealed class __SwtClosure_N68782 : ARunnable
    {
        private readonly global::System.Action<__SwtClosure_N68782> callback1;

        public __SwtClosure_N68782(global::System.Action<__SwtClosure_N68782> callback1)
        {
            this.callback1 = callback1;
        }

        public override void run() => callback1(this);
    }

}

