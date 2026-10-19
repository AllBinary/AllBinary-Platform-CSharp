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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using javax.swing;
using StdUtil = org.allbinary.logic.StdUtil;

namespace org.allbinary.input.automation.module;

public class DefaultListModelHelper
{
    private DefaultListModel defaultListModel;
    private BasicArrayList vector;
    public DefaultListModelHelper()
    {
        this.vector = new BasicArrayListD();
        this.defaultListModel = new DefaultListModel();
    }

    public virtual void initDefaultModelList()
    {
        this.defaultListModel = new DefaultListModel();
        int size = this.vector.size();
        for (int index = 0; index < size; index++) {
            string moduleName = ((string) this.vector.get(index));
            this.defaultListModel.addElement(moduleName);
        }
    }

    public virtual ListModel getListModel()
    {
        return ((ListModel) this.defaultListModel);
    }

    public virtual void add(string @string)
    {
        this.vector.add(@string);
    }

    public virtual void remove(string @string)
    {
        this.vector.remove(@string);
    }

}

