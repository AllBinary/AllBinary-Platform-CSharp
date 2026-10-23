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

namespace org.allbinary.gui.swing.workers;

public class JListSwingWorker : SwingWorker
{
    private JList jList = null;
    private ListModel listModel = null;
    public JListSwingWorker(JList jList, ListModel listModel)
    {
        this.setJList(jList);
        this.setListModel(listModel);
    }

    public virtual object doInBackground()
    {
        return null;
    }

    public virtual void done()
    {
        this.getJList().setModel(this.getListModel());
    }

    private JList getJList()
    {
        return this.jList;
    }

    private void setJList(JList jList)
    {
        this.jList = jList;
    }

    private ListModel getListModel()
    {
        return this.listModel;
    }

    private void setListModel(ListModel listModel)
    {
        this.listModel = listModel;
    }

}

