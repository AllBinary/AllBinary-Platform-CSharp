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
//using Font = java.awt.Font;
//using GridLayout = java.awt.GridLayout;
//using MouseAdapter = java.awt.@event.MouseAdapter;
//using MouseEvent = java.awt.@event.MouseEvent;
//using JButton = javax.swing.JButton;
//using JList = javax.swing.JList;
//using JPanel = javax.swing.JPanel;

namespace org.allbinary.graphics.j2me.workarea.tools;

public class ToolJPanel : JPanel
{
    public ToolJPanel()
    {
        this.initComponents();
    }

    private void initComponents()
    {
        lineJButton = new JButton();
        this.rectJButton = new JButton();
        this.arcJButton = new JButton();
        this.stringJButton = new JButton();
        this.charJButton = new JButton();
        this.roundRectJButton = new JButton();
        this.imageJButton = new JButton();
        this.fillArcJButton = new JButton();
        this.fillRectJButton = new JButton();
        this.fillRoundRectJButton = new JButton();
        this.dottedLineJButton = new JButton();
        this.dottedRectButton = new JButton();
        this.dottedArcJButton = new JButton();
        this.dottedFillRectJButton = new JButton();
        this.dottedFillArcJButton = new JButton();
        this.dottedFillRountRectJButton = new JButton();
        this.colorJPanel = new JPanel();
        this.colorJList = new JList();
        this.setLayout(new GridLayout(17, 1));
        lineJButton.setFont(new Font("Dialog", 0, 10));
        lineJButton.setText(LinesGraphicItem.getStaticName());
        lineJButton.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mouseClicked(MouseEvent evt)
            {
                lineJButtonMouseClicked(evt);
            }

#endif
);
        add(this.lineJButton);
        this.rectJButton.setFont(new Font("Dialog", 0, 10));
        this.rectJButton.setText("Rect");
        this.rectJButton.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mouseClicked(MouseEvent evt)
            {
                rectJButtonMouseClicked(evt);
            }

#endif
);
        add(this.rectJButton);
        this.arcJButton.setFont(new Font("Dialog", 0, 10));
        this.arcJButton.setText("Arc");
        this.arcJButton.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                arcJButtonMousePressed(evt);
            }

#endif
);
        add(this.arcJButton);
        this.stringJButton.setFont(new Font("Dialog", 0, 10));
        this.stringJButton.setText("String");
        this.stringJButton.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                stringJButtonMousePressed(evt);
            }

#endif
);
        add(this.stringJButton);
        this.charJButton.setFont(new Font("Dialog", 0, 10));
        this.charJButton.setText("Char");
        this.charJButton.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                charJButtonMousePressed(evt);
            }

#endif
);
        add(this.charJButton);
        this.roundRectJButton.setFont(new Font("Dialog", 0, 10));
        this.roundRectJButton.setText("Round Rect");
        this.roundRectJButton.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                roundRectJButtonMousePressed(evt);
            }

#endif
);
        add(this.roundRectJButton);
        this.imageJButton.setFont(new Font("Dialog", 0, 10));
        this.imageJButton.setText("Image");
        this.imageJButton.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                imageJButtonMousePressed(evt);
            }

#endif
);
        add(this.imageJButton);
        this.fillArcJButton.setFont(new Font("Dialog", 0, 10));
        this.fillArcJButton.setText("Fill Arc");
        this.fillArcJButton.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                fillArcJButtonMousePressed(evt);
            }

#endif
);
        add(this.fillArcJButton);
        this.fillRectJButton.setFont(new Font("Dialog", 0, 10));
        this.fillRectJButton.setText("Fill Rect");
        this.fillRectJButton.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                fillRectJButtonMousePressed(evt);
            }

#endif
);
        add(this.fillRectJButton);
        this.fillRoundRectJButton.setFont(new Font("Dialog", 0, 10));
        this.fillRoundRectJButton.setText("Fill Rnd Rect");
        this.fillRoundRectJButton.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                fillRoundRectJButtonMousePressed(evt);
            }

#endif
);
        add(this.fillRoundRectJButton);
        this.dottedLineJButton.setFont(new Font("Dialog", 0, 10));
        this.dottedLineJButton.setText("Dot Line");
        this.dottedLineJButton.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                dottedLineJButtonMousePressed(evt);
            }

#endif
);
        add(this.dottedLineJButton);
        this.dottedRectButton.setFont(new Font("Dialog", 0, 10));
        this.dottedRectButton.setText("Dot Rect");
        this.dottedRectButton.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                dottedRectButtonMousePressed(evt);
            }

#endif
);
        add(this.dottedRectButton);
        this.dottedArcJButton.setFont(new Font("Dialog", 0, 10));
        this.dottedArcJButton.setText("Dot Arc");
        this.dottedArcJButton.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                dottedArcJButtonMousePressed(evt);
            }

#endif
);
        add(this.dottedArcJButton);
        this.dottedFillRectJButton.setFont(new Font("Dialog", 0, 10));
        this.dottedFillRectJButton.setText("Dot Fill Rect");
        this.dottedFillRectJButton.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                dottedFillRectJButtonMousePressed(evt);
            }

#endif
);
        add(this.dottedFillRectJButton);
        this.dottedFillArcJButton.setFont(new Font("Dialog", 0, 10));
        this.dottedFillArcJButton.setText("Dot Fill Arc");
        this.dottedFillArcJButton.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                dottedFillArcJButtonMousePressed(evt);
            }

#endif
);
        add(this.dottedFillArcJButton);
        this.dottedFillRountRectJButton.setFont(new Font("Dialog", 0, 10));
        this.dottedFillRountRectJButton.setText("Dot Fill Rnd Rect");
        this.dottedFillRountRectJButton.addMouseListener(new MouseAdapter()
#if JAVA_ANONYMOUS_CLASS_BODY
            public virtual void mousePressed(MouseEvent evt)
            {
                dottedFillRountRectJButtonMousePressed(evt);
            }

#endif
);
        add(this.dottedFillRountRectJButton);
        this.colorJPanel.setLayout(new GridLayout(1, 1));
        this.colorJPanel.add(this.colorJList);
        add(this.colorJPanel);
    }

    private void dottedFillRountRectJButtonMousePressed(MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.dottedFillRountRectJButton.getText());
    }

    private void dottedFillArcJButtonMousePressed(MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.dottedFillArcJButton.getText());
    }

    private void dottedFillRectJButtonMousePressed(MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.dottedFillRectJButton.getText());
    }

    private void dottedArcJButtonMousePressed(MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.dottedArcJButton.getText());
    }

    private void dottedRectButtonMousePressed(MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.dottedRectButton.getText());
    }

    private void dottedLineJButtonMousePressed(MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.dottedLineJButton.getText());
    }

    private void fillRoundRectJButtonMousePressed(MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.fillRoundRectJButton.getText());
    }

    private void fillRectJButtonMousePressed(MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.fillRectJButton.getText());
    }

    private void fillArcJButtonMousePressed(MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.fillArcJButton.getText());
    }

    private void imageJButtonMousePressed(MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.imageJButton.getText());
    }

    private void roundRectJButtonMousePressed(MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.roundRectJButton.getText());
    }

    private void charJButtonMousePressed(MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.charJButton.getText());
    }

    private void stringJButtonMousePressed(MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.stringJButton.getText());
    }

    private void arcJButtonMousePressed(MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.arcJButton.getText());
    }

    private void rectJButtonMouseClicked(MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.rectJButton.getText());
    }

    private void lineJButtonMouseClicked(MouseEvent evt)
    {
        ToolFactory.getInstance().setSelectedTool(this.lineJButton.getText());
    }

    private JButton arcJButton = null;
    private JButton charJButton = null;
    private JList colorJList = null;
    private JPanel colorJPanel = null;
    private JButton dottedArcJButton = null;
    private JButton dottedFillArcJButton = null;
    private JButton dottedFillRectJButton = null;
    private JButton dottedFillRountRectJButton = null;
    private JButton dottedLineJButton = null;
    private JButton dottedRectButton = null;
    private JButton fillArcJButton = null;
    private JButton fillRectJButton = null;
    private JButton fillRoundRectJButton = null;
    private JButton imageJButton = null;
    private JButton lineJButton = null;
    private JButton rectJButton = null;
    private JButton roundRectJButton = null;
    private JButton stringJButton = null;
}

