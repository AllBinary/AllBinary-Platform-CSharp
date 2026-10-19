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
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.control.contraints.display.browser;

public class DisplayInBrowserContraints : DisplayInBrowserContraintsInterface
{
    private bool frameable = false;
    private bool mountable = false;
    private bool quickFrameable = false;
    private string mountedLink = null;
    public DisplayInBrowserContraints(Node node)
    {
    }

    public virtual bool isMountable()
    {
        return this.mountable;
    }

    public virtual void setMountable(bool mountable)
    {
        this.mountable = mountable;
    }

    public virtual bool isFrameable()
    {
        return this.frameable;
    }

    public virtual void setFrameable(bool frameable)
    {
        this.frameable = frameable;
    }

    public virtual bool isQuickFrameable()
    {
        return this.quickFrameable;
    }

    public virtual void setQuickFrameable(bool quickFrameable)
    {
        this.quickFrameable = quickFrameable;
    }

    public virtual string getMountedLink()
    {
        return this.mountedLink;
    }

    public virtual void setMountedLink(string mountedLink)
    {
        this.mountedLink = mountedLink;
    }

}

