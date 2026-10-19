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

namespace org.allbinary.graphics.j2me.workarea.properties;

public class PropertiesJPanel : javax.swing.JPanel
{
    public PropertiesJPanel()
    {
        this.initComponents();
    }

    public virtual void set(JPanel panel)
    {
        this.workAreaPropertiesJPanel.add(panel);
        this.repaint();
    }

    private void initComponents()
    {
        this.workAreaPropertiesJPanel = new javax.swing.JPanel();
        this.modifierJPanel = new javax.swing.JPanel();
        this.copyVerticalJButton = new javax.swing.JButton();
        this.copyHorizontalJButton = new javax.swing.JButton();
        this.rotateJPanel = new javax.swing.JPanel();
        this.rotateJButton = new javax.swing.JButton();
        this.angleJTextField = new javax.swing.JTextField();
        this.jPanel7 = new javax.swing.JPanel();
        this.upJButton = new javax.swing.JButton();
        this.downJButton = new javax.swing.JButton();
        this.jPanel8 = new javax.swing.JPanel();
        this.leftJButton = new javax.swing.JButton();
        this.rightJButton = new javax.swing.JButton();
        setLayout(new java.awt.GridLayout(2, 1));
        this.workAreaPropertiesJPanel.setLayout(new java.awt.GridLayout());
        add(this.workAreaPropertiesJPanel);
        this.modifierJPanel.setLayout(new java.awt.GridLayout(6, 0));
        this.copyVerticalJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.copyVerticalJButton.setText("Copy Vertical");
        this.modifierJPanel.add(this.copyVerticalJButton);
        this.copyHorizontalJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.copyHorizontalJButton.setText("Copy Horizontal");
        this.modifierJPanel.add(this.copyHorizontalJButton);
        this.rotateJPanel.setLayout(new java.awt.GridLayout(1, 2));
        this.rotateJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.rotateJButton.setText("Rotate");
        this.rotateJPanel.add(this.rotateJButton);
        this.angleJTextField.setText("Angle");
        this.rotateJPanel.add(this.angleJTextField);
        this.modifierJPanel.add(this.rotateJPanel);
        this.jPanel7.setLayout(new java.awt.GridLayout(1, 2));
        this.upJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.upJButton.setText("Up");
        this.jPanel7.add(this.upJButton);
        this.downJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.downJButton.setText("Down");
        this.jPanel7.add(this.downJButton);
        this.modifierJPanel.add(this.jPanel7);
        this.jPanel8.setLayout(new java.awt.GridLayout(1, 2));
        this.leftJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.leftJButton.setText("Left");
        this.jPanel8.add(this.leftJButton);
        this.rightJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.rightJButton.setText("Right");
        this.jPanel8.add(this.rightJButton);
        this.modifierJPanel.add(this.jPanel8);
        add(this.modifierJPanel);
    }

    private javax.swing.JButton rotateJButton = null;
    private javax.swing.JButton copyVerticalJButton = null;
    private javax.swing.JButton leftJButton = null;
    private javax.swing.JPanel rotateJPanel = null;
    private javax.swing.JTextField angleJTextField = null;
    private javax.swing.JPanel workAreaPropertiesJPanel = null;
    private javax.swing.JPanel modifierJPanel = null;
    private javax.swing.JButton upJButton = null;
    private javax.swing.JPanel jPanel8 = null;
    private javax.swing.JButton downJButton = null;
    private javax.swing.JPanel jPanel7 = null;
    private javax.swing.JButton rightJButton = null;
    private javax.swing.JButton copyHorizontalJButton = null;
}

