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
//using Font = java.awt.Font;
//using GridLayout = java.awt.GridLayout;
//using JButton = javax.swing.JButton;
//using JPanel = javax.swing.JPanel;
//using JTextField = javax.swing.JTextField;

namespace org.allbinary.graphics.j2me.workarea.properties;

public class PropertiesJPanel : JPanel
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
        this.workAreaPropertiesJPanel = new JPanel();
        this.modifierJPanel = new JPanel();
        this.copyVerticalJButton = new JButton();
        this.copyHorizontalJButton = new JButton();
        this.rotateJPanel = new JPanel();
        this.rotateJButton = new JButton();
        this.angleJTextField = new JTextField();
        this.jPanel7 = new JPanel();
        this.upJButton = new JButton();
        this.downJButton = new JButton();
        this.jPanel8 = new JPanel();
        this.leftJButton = new JButton();
        this.rightJButton = new JButton();
        setLayout(new GridLayout(2, 1));
        this.workAreaPropertiesJPanel.setLayout(new GridLayout());
        add(this.workAreaPropertiesJPanel);
        this.modifierJPanel.setLayout(new GridLayout(6, 0));
        this.copyVerticalJButton.setFont(new Font("Dialog", 0, 10));
        this.copyVerticalJButton.setText("Copy Vertical");
        this.modifierJPanel.add(this.copyVerticalJButton);
        this.copyHorizontalJButton.setFont(new Font("Dialog", 0, 10));
        this.copyHorizontalJButton.setText("Copy Horizontal");
        this.modifierJPanel.add(this.copyHorizontalJButton);
        this.rotateJPanel.setLayout(new GridLayout(1, 2));
        this.rotateJButton.setFont(new Font("Dialog", 0, 10));
        this.rotateJButton.setText("Rotate");
        this.rotateJPanel.add(this.rotateJButton);
        this.angleJTextField.setText("Angle");
        this.rotateJPanel.add(this.angleJTextField);
        this.modifierJPanel.add(this.rotateJPanel);
        this.jPanel7.setLayout(new GridLayout(1, 2));
        this.upJButton.setFont(new Font("Dialog", 0, 10));
        this.upJButton.setText("Up");
        this.jPanel7.add(this.upJButton);
        this.downJButton.setFont(new Font("Dialog", 0, 10));
        this.downJButton.setText("Down");
        this.jPanel7.add(this.downJButton);
        this.modifierJPanel.add(this.jPanel7);
        this.jPanel8.setLayout(new GridLayout(1, 2));
        this.leftJButton.setFont(new Font("Dialog", 0, 10));
        this.leftJButton.setText("Left");
        this.jPanel8.add(this.leftJButton);
        this.rightJButton.setFont(new Font("Dialog", 0, 10));
        this.rightJButton.setText("Right");
        this.jPanel8.add(this.rightJButton);
        this.modifierJPanel.add(this.jPanel8);
        add(this.modifierJPanel);
    }

    private JButton rotateJButton = null;
    private JButton copyVerticalJButton = null;
    private JButton leftJButton = null;
    private JPanel rotateJPanel = null;
    private JTextField angleJTextField = null;
    private JPanel workAreaPropertiesJPanel = null;
    private JPanel modifierJPanel = null;
    private JButton upJButton = null;
    private JPanel jPanel8 = null;
    private JButton downJButton = null;
    private JPanel jPanel7 = null;
    private JButton rightJButton = null;
    private JButton copyHorizontalJButton = null;
}

