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
using EventObject = java.util.EventObject;

namespace org.allbinary.graphics.j2me.workarea.tools.@event;

public class MyGraphicItemEvent : EventObject
{
    public MyGraphicItemEvent(object source) : base(source)
    {
        // Constructor invocation emitted in the initializer.
    }

    public virtual object getSource()
    {
        return base.getSource();
    }

    public override string ToString()
    {
        return base.ToString();
    }

    public virtual string getCommand()
    {
        MyGraphicItemEventSource myEventSource = ((MyGraphicItemEventSource) this.getSource());
        return myEventSource.getCommand();
    }

    public virtual MutableTreeNode getTreeNode()
    {
        MyGraphicItemEventSource myEventSource = ((MyGraphicItemEventSource) this.getSource());
        return myEventSource.getTreeNode();
    }

    public virtual double getAngle()
    {
        MyGraphicItemEventSource myEventSource = ((MyGraphicItemEventSource) this.getSource());
        return myEventSource.getAngle();
    }

}

