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
//using java.awt;
//using javax.swing;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.communication.log;

public class GuiLog
{
    private static readonly GuiLog instance = new GuiLog();
    public static GuiLog getInstance()
    {
        return GuiLog.instance;
    }

    private readonly LogFormatUtil logFormatUtil = LogFormatUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private GuiLog()
    {
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual void showDialog(string msg)
    {
        JDialog error = new JDialog();
        int size = msg.Length * 9;
        int x = size;
        if (x > 550) {
            x = 550;
        }
        error.getContentPane().setLayout(new GridLayout(1, 1));
        if (size > 255) {
            int y = 550;
            error.setSize(x, y);
            error.getContentPane().add(new javax.swing.JScrollPane(new javax.swing.JTextArea(msg)));
        } else if (size > 0) {
            int y = 50;
            error.setSize(x, y);
            error.getContentPane().add(new javax.swing.JScrollPane(new javax.swing.JLabel(msg)));
        }
        error.show();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual string put(string specialMessage, object anyType, string functionName)
    {
        return this.put(specialMessage, anyType, functionName, null);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual string put(string specialMessage, object anyType, string functionName, Exception exception)
    {
        try {
            string data = this.logFormatUtil.get(specialMessage, anyType.GetType().FullName, functionName, exception);
            this.showDialog(data);
            Console.WriteLine(data);
            return data;
        } catch (Exception e) {
            PreLogUtil.putOE(this.commonStrings.EXCEPTION, this, "put", e);
            return "Logging Error";
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual string put(string specialMessage, string className, string functionName)
    {
        return this.put(specialMessage, className, functionName, null);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public virtual string put(string specialMessage, string className, string functionName, Exception exception)
    {
        try {
            string data = this.logFormatUtil.get(specialMessage, className, functionName, exception);
            this.showDialog(data);
            Console.WriteLine(data);
            return data;
        } catch (Exception e) {
            PreLogUtil.putOE(this.commonStrings.EXCEPTION, this, "put", e);
            return "Logging Error";
        }
    }

}

