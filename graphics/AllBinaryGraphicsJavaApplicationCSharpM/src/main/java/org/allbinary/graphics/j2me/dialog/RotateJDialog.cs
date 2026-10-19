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

namespace org.allbinary.graphics.j2me.dialog;

public class RotateJDialog : javax.swing.JDialog
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private HashMap hashMap = StdUtil.getInstance().createHashMap();
    public RotateJDialog(java.awt.Frame parent, bool modal) : base(parent, modal)
    {
        // base(parent, modal) is called from the constructor declaration
        this.initComponents();
    }

    private void initComponents()
    {
        angleIncrementJTextField = new javax.swing.JTextField();
        this.jLabel1 = new javax.swing.JLabel();
        this.totalRotationJTextField = new javax.swing.JTextField();
        this.jLabel2 = new javax.swing.JLabel();
        this.jPanel1 = new javax.swing.JPanel();
        this.jButton1 = new javax.swing.JButton();
        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        this.angleIncrementJTextField.setText("36");
        this.jLabel1.setText("Angle Increment:");
        this.totalRotationJTextField.setText("360");
        this.jLabel2.setText("Total Angular Rotation:");
        this.jButton1.setText("OK");
        this.jButton1.addActionListener(new java.awt.event.ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void actionPerformed(java.awt.event.ActionEvent evt)
            {
                jButton1ActionPerformed(evt);
            }

#endif
);
        javax.swing.GroupLayout jPanel1Layout = new javax.swing.GroupLayout(this.jPanel1);
        this.jPanel1.setLayout(jPanel1Layout);
        jPanel1Layout.setHorizontalGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(jPanel1Layout.createSequentialGroup().addGap(62, 62, 62).addComponent(jButton1).addContainerGap(62, Short.MAX_VALUE)));
        jPanel1Layout.setVerticalGroup(jPanel1Layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(jButton1));
        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addContainerGap().addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING).addComponent(jLabel1).addComponent(jLabel2)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED).addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addComponent(totalRotationJTextField, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, 31, Short.MAX_VALUE).addComponent(angleIncrementJTextField, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.PREFERRED_SIZE, 31, javax.swing.GroupLayout.PREFERRED_SIZE)).addContainerGap()).addComponent(jPanel1, javax.swing.GroupLayout.Alignment.TRAILING, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, Short.MAX_VALUE));
        layout.setVerticalGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING).addGroup(layout.createSequentialGroup().addContainerGap().addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(angleIncrementJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(jLabel1)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED).addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.BASELINE).addComponent(totalRotationJTextField, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addComponent(jLabel2)).addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 16, Short.MAX_VALUE).addComponent(jPanel1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE).addContainerGap()));
        pack();
    }

    private void jButton1ActionPerformed(java.awt.event.ActionEvent evt)
    {
        try {
            this.hashMap.put((0).ToString(), (this.angleIncrementJTextField.getText()).ToString());
            this.hashMap.put((1).ToString(), (this.totalRotationJTextField.getText()).ToString());
            (((HashMapJDialogListenerInterface) this.getParent())).onHashMap(this.hashMap);
            this.setVisible(false);
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            this.logUtil.putF(commonStrings.EXCEPTION, this, "jButton1ActionPerformed");
        }
    }

    public static void main(string[] args)
    {
        java.awt.EventQueue.invokeLater(new ARunnable()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void run()
            {
                RotateJDialog dialog = new RotateJDialog(new javax.swing.JFrame(), true);
                dialog.addWindowListener(new java.awt.event.WindowAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
                    public virtual void windowClosing(java.awt.event.WindowEvent e)
                    {
                        Environment.Exit(0);
                    }

#endif
);
                dialog.setVisible(true);
            }

#endif
);
    }

    private javax.swing.JTextField angleIncrementJTextField = null;
    private javax.swing.JButton jButton1 = null;
    private javax.swing.JLabel jLabel1 = null;
    private javax.swing.JLabel jLabel2 = null;
    private javax.swing.JPanel jPanel1 = null;
    private javax.swing.JTextField totalRotationJTextField = null;
}

