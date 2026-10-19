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
//using java.awt;
//using ActionEvent = java.awt.@event.ActionEvent;
//using ActionListener = java.awt.@event.ActionListener;
//using javax.swing;
using GraphicsException = org.allbinary.graphics.j2me.GraphicsException;
using MyFrame = org.allbinary.graphics.j2me.MyFrame;
using WorkAreaJPanel = org.allbinary.graphics.j2me.workarea.WorkAreaJPanel;
using WorkAreaJPanelInterface = org.allbinary.graphics.j2me.workarea.WorkAreaJPanelInterface;

namespace org.allbinary.graphics.j2me.dialog;

public class NewWorkAreaJDialog : javax.swing.JDialog
{
    private MyFrame parent = null;
    private Dimension dimension = null;
    private JTextField xSizeJTextField = null;
    private JTextField ySizeJTextField = null;
    private JTextField nameJTextField = null;
    public NewWorkAreaJDialog(MyFrame parent, bool modal, Dimension dimension, string newName) : base(((java.awt.Frame) parent), modal)
    {
        // base(((java.awt.Frame) parent), modal) is called from the constructor declaration
        try {
            this.initComponents();
            this.parent = parent;
            this.xSizeJTextField = new JTextField("12");
            this.ySizeJTextField = new JTextField("12");
            this.nameJTextField = new JTextField(newName);
            this.dimension = dimension;
            JButton submitButton = new JButton("Ok");
            submitButton.addActionListener(new ActionListener()
#if JAVA_ANONYMOUS_CLASS_BODY
                public virtual void actionPerformed(ActionEvent evt)
                {
                    try {
                        disposeNewDialog();
                    } catch (Exception e) {
                    }
                }

#endif
);
            this.setSize(150, 100);
            this.getContentPane().setLayout(new GridLayout(5, 2));
            this.getContentPane().add(new JLabel("Please enter"));
            this.getContentPane().add(new JLabel(" the size."));
            this.getContentPane().add(new JLabel("Name:"));
            this.getContentPane().add(this.nameJTextField);
            this.getContentPane().add(new JLabel("X: "));
            this.getContentPane().add(this.xSizeJTextField);
            this.getContentPane().add(new JLabel("Y: "));
            this.getContentPane().add(this.ySizeJTextField);
            this.getContentPane().add(submitButton);
            this.show();
        } catch (Exception e) {
            throw e;
        }
    }

    // throws Exception
    private void disposeNewDialog()
    {
        try {
            int? canvasWidth = this.xSizeJTextField.getText();
            int? canvasHeight = this.ySizeJTextField.getText();
            string newName = this.nameJTextField.getText();
            if (newName == null) {
                throw new GraphicsException("No Name", this, "disposeNewDialog");
            }
            WorkAreaJPanel workAreaJPanel = new WorkAreaJPanel(newName, this.dimension, ((int) canvasWidth), ((int) canvasHeight));
            workAreaJPanel.setLayout(new GridLayout(1, 1));
            this.parent.add(((WorkAreaJPanelInterface) workAreaJPanel));
            this.dispose();
        } catch (Exception e) {
            throw e;
        }
    }

    private void initComponents()
    {
        addWindowListener(new java.awt.event.WindowAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void windowClosing(java.awt.event.WindowEvent evt)
            {
                closeDialog(evt);
            }

#endif
);
        pack();
    }

    private void closeDialog(java.awt.event.WindowEvent evt)
    {
        setVisible(false);
        dispose();
    }

    public static void main(string[] args)
    {
        try {
            new NewWorkAreaJDialog(new MyFrame(), true, new Dimension(100, 100), "testing").show();
        } catch (Exception e) {
        }
    }

}

