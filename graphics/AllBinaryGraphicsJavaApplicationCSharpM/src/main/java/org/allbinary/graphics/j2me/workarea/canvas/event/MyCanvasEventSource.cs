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
//using MutableTreeNode = javax.swing.tree.MutableTreeNode;

namespace org.allbinary.graphics.j2me.workarea.canvas.@event;

public class MyCanvasEventSource
{
    private string command;
    private MutableTreeNode treeNode;
    private double angle = 0.0;
    public MyCanvasEventSource(string command, MutableTreeNode treeNode)
    {
        this.command = command;
        this.treeNode = treeNode;
    }

    public MyCanvasEventSource(string command, double angle, MutableTreeNode treeNode)
    {
        this.command = command;
        this.treeNode = treeNode;
        this.setAngle(angle);
    }

    public virtual string getCommand()
    {
        return this.command;
    }

    public virtual MutableTreeNode getTreeNode()
    {
        return this.treeNode;
    }

    public virtual double getAngle()
    {
        return this.angle;
    }

    public virtual void setAngle(double angle)
    {
        this.angle = angle;
    }

}

