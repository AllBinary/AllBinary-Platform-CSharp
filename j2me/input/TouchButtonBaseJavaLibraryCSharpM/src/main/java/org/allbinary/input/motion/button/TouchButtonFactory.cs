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
using System.Runtime.CompilerServices;
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListUtil = org.allbinary.util.BasicArrayListUtil;

namespace org.allbinary.input.motion.button;

public class TouchButtonFactory
{
    private static readonly TouchButtonFactory SINGLETON = new TouchButtonFactory();
    public static TouchButtonFactory getInstance()
    {
        return TouchButtonFactory.SINGLETON;
    }

    private BasicArrayList LIST = BasicArrayListUtil.getInstance().getImmutableInstance();
    private BasicArrayList list;
    private BasicArrayList savedList;
    private TouchButtonFactory()
    {
        this.list = this.LIST;
        this.savedList = this.LIST;
    }

    public virtual void defaultList()
    {
        this.list = this.LIST;
        this.toggle(false, this.LIST);
    }

    private bool saved = false;
    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void toggle(bool save, BasicArrayList list)
    {
        if (list != BasicArrayListUtil.getInstance().getImmutableInstance()) {
            this.savedList = list;
            if (!this.saved) {
                this.list = this.savedList;
            }
        } else {
            if (save) {
                if (!this.saved) {
                    this.saved = true;
                    this.savedList = this.list;
                    this.list = this.LIST;
                } else {
                }
            } else {
                this.list = this.savedList;
                this.saved = false;
            }
        }
    }

    // throws Exception
    public virtual void setList(BasicArrayList list)
    {
        if (list == null) {
            throw new Exception("Null List");
        }
        this.list = list;
    }

    public virtual BasicArrayList getList()
    {
        return this.list;
    }

}

