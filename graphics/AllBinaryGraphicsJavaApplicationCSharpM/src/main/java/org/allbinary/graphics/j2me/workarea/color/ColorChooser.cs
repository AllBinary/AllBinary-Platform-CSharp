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
//using BorderLayout = java.awt.BorderLayout;
//using JColorChooser = javax.swing.JColorChooser;
//using JPanel = javax.swing.JPanel;

namespace org.allbinary.graphics.j2me.workarea.color;

public class ColorChooser : JPanel
{
    public ColorChooser()
    {
        this.initComponents();
    }

    private void initComponents()
    {
        this.jColorChooser1 = new JColorChooser();
        setLayout(new BorderLayout());
        add(this.jColorChooser1, BorderLayout.CENTER);
    }

    private JColorChooser jColorChooser1 = null;
}

