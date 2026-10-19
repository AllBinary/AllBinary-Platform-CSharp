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

namespace org.allbinary.graphics.j2me.workarea.tools;

public class ToolJPanel : javax.swing.JPanel
{
    public ToolJPanel()
    {
        this.initComponents();
    }

    private void initComponents()
    {
        lineJButton = new javax.swing.JButton();
        this.rectJButton = new javax.swing.JButton();
        this.arcJButton = new javax.swing.JButton();
        this.stringJButton = new javax.swing.JButton();
        this.charJButton = new javax.swing.JButton();
        this.roundRectJButton = new javax.swing.JButton();
        this.imageJButton = new javax.swing.JButton();
        this.fillArcJButton = new javax.swing.JButton();
        this.fillRectJButton = new javax.swing.JButton();
        this.fillRoundRectJButton = new javax.swing.JButton();
        this.dottedLineJButton = new javax.swing.JButton();
        this.dottedRectButton = new javax.swing.JButton();
        this.dottedArcJButton = new javax.swing.JButton();
        this.dottedFillRectJButton = new javax.swing.JButton();
        this.dottedFillArcJButton = new javax.swing.JButton();
        this.dottedFillRountRectJButton = new javax.swing.JButton();
        this.colorJPanel = new javax.swing.JPanel();
        this.colorJList = new javax.swing.JList();
        this.setLayout(new java.awt.GridLayout(17, 1));
        lineJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        lineJButton.setText(LinesGraphicItem.getStaticName());
        lineJButton.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mouseClicked(java.awt.event.MouseEvent evt)
            {
                lineJButtonMouseClicked(evt);
            }

#endif
);
        add(this.lineJButton);
        this.rectJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.rectJButton.setText("Rect");
        this.rectJButton.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mouseClicked(java.awt.event.MouseEvent evt)
            {
                rectJButtonMouseClicked(evt);
            }

#endif
);
        add(this.rectJButton);
        this.arcJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.arcJButton.setText("Arc");
        this.arcJButton.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                arcJButtonMousePressed(evt);
            }

#endif
);
        add(this.arcJButton);
        this.stringJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.stringJButton.setText("String");
        this.stringJButton.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                stringJButtonMousePressed(evt);
            }

#endif
);
        add(this.stringJButton);
        this.charJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.charJButton.setText("Char");
        this.charJButton.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                charJButtonMousePressed(evt);
            }

#endif
);
        add(this.charJButton);
        this.roundRectJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.roundRectJButton.setText("Round Rect");
        this.roundRectJButton.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                roundRectJButtonMousePressed(evt);
            }

#endif
);
        add(this.roundRectJButton);
        this.imageJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.imageJButton.setText("Image");
        this.imageJButton.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                imageJButtonMousePressed(evt);
            }

#endif
);
        add(this.imageJButton);
        this.fillArcJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.fillArcJButton.setText("Fill Arc");
        this.fillArcJButton.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                fillArcJButtonMousePressed(evt);
            }

#endif
);
        add(this.fillArcJButton);
        this.fillRectJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.fillRectJButton.setText("Fill Rect");
        this.fillRectJButton.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                fillRectJButtonMousePressed(evt);
            }

#endif
);
        add(this.fillRectJButton);
        this.fillRoundRectJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.fillRoundRectJButton.setText("Fill Rnd Rect");
        this.fillRoundRectJButton.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                fillRoundRectJButtonMousePressed(evt);
            }

#endif
);
        add(this.fillRoundRectJButton);
        this.dottedLineJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.dottedLineJButton.setText("Dot Line");
        this.dottedLineJButton.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                dottedLineJButtonMousePressed(evt);
            }

#endif
);
        add(this.dottedLineJButton);
        this.dottedRectButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.dottedRectButton.setText("Dot Rect");
        this.dottedRectButton.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                dottedRectButtonMousePressed(evt);
            }

#endif
);
        add(this.dottedRectButton);
        this.dottedArcJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.dottedArcJButton.setText("Dot Arc");
        this.dottedArcJButton.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                dottedArcJButtonMousePressed(evt);
            }

#endif
);
        add(this.dottedArcJButton);
        this.dottedFillRectJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.dottedFillRectJButton.setText("Dot Fill Rect");
        this.dottedFillRectJButton.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                dottedFillRectJButtonMousePressed(evt);
            }

#endif
);
        add(this.dottedFillRectJButton);
        this.dottedFillArcJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.dottedFillArcJButton.setText("Dot Fill Arc");
        this.dottedFillArcJButton.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                dottedFillArcJButtonMousePressed(evt);
            }

#endif
);
        add(this.dottedFillArcJButton);
        this.dottedFillRountRectJButton.setFont(new java.awt.Font("Dialog", 0, 10));
        this.dottedFillRountRectJButton.setText("Dot Fill Rnd Rect");
        this.dottedFillRountRectJButton.addMouseListener(new java.awt.event.MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(java.awt.event.MouseEvent evt)
            {
                dottedFillRountRectJButtonMousePressed(evt);
            }

#endif
);
        add(this.dottedFillRountRectJButton);
        this.colorJPanel.setLayout(new java.awt.GridLayout(1, 1));
        this.colorJPanel.add(this.colorJList);
        add(this.colorJPanel);
    }

    private void dottedFillRountRectJButtonMousePressed(java.awt.event.MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.dottedFillRountRectJButton.getText());
    }

    private void dottedFillArcJButtonMousePressed(java.awt.event.MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.dottedFillArcJButton.getText());
    }

    private void dottedFillRectJButtonMousePressed(java.awt.event.MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.dottedFillRectJButton.getText());
    }

    private void dottedArcJButtonMousePressed(java.awt.event.MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.dottedArcJButton.getText());
    }

    private void dottedRectButtonMousePressed(java.awt.event.MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.dottedRectButton.getText());
    }

    private void dottedLineJButtonMousePressed(java.awt.event.MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.dottedLineJButton.getText());
    }

    private void fillRoundRectJButtonMousePressed(java.awt.event.MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.fillRoundRectJButton.getText());
    }

    private void fillRectJButtonMousePressed(java.awt.event.MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.fillRectJButton.getText());
    }

    private void fillArcJButtonMousePressed(java.awt.event.MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.fillArcJButton.getText());
    }

    private void imageJButtonMousePressed(java.awt.event.MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.imageJButton.getText());
    }

    private void roundRectJButtonMousePressed(java.awt.event.MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.roundRectJButton.getText());
    }

    private void charJButtonMousePressed(java.awt.event.MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.charJButton.getText());
    }

    private void stringJButtonMousePressed(java.awt.event.MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.stringJButton.getText());
    }

    private void arcJButtonMousePressed(java.awt.event.MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.arcJButton.getText());
    }

    private void rectJButtonMouseClicked(java.awt.event.MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.rectJButton.getText());
    }

    private void lineJButtonMouseClicked(java.awt.event.MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.lineJButton.getText());
    }

    private javax.swing.JButton arcJButton = null;
    private javax.swing.JButton charJButton = null;
    private javax.swing.JList colorJList = null;
    private javax.swing.JPanel colorJPanel = null;
    private javax.swing.JButton dottedArcJButton = null;
    private javax.swing.JButton dottedFillArcJButton = null;
    private javax.swing.JButton dottedFillRectJButton = null;
    private javax.swing.JButton dottedFillRountRectJButton = null;
    private javax.swing.JButton dottedLineJButton = null;
    private javax.swing.JButton dottedRectButton = null;
    private javax.swing.JButton fillArcJButton = null;
    private javax.swing.JButton fillRectJButton = null;
    private javax.swing.JButton fillRoundRectJButton = null;
    private javax.swing.JButton imageJButton = null;
    private javax.swing.JButton lineJButton = null;
    private javax.swing.JButton rectJButton = null;
    private javax.swing.JButton roundRectJButton = null;
    private javax.swing.JButton stringJButton = null;
}

