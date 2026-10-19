/*
 * 
 * AllBinary Open License Version 1 
 * Copyright (c) 2026 AllBinary 
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
//using Item = javax.microedition.lcdui.Item;
using CommandForm = org.allbinary.graphics.displayable.screen.CommandForm;

namespace org.allbinary.logic;

//Handle the differences in the public platform vs the raw JS build
public class MEUtil
{
    public static MEUtil getInstance()
    {
        return MEUtil.instance;
    }

    private static readonly MEUtil instance = new MEUtil();
    public virtual void appendItem(CommandForm form, Item item)
    {
        form.append(item);
    }

}

