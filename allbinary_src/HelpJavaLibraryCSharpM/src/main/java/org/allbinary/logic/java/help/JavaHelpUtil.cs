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
//using java.awt;
//using ActionEvent = java.awt.@event.ActionEvent;
//using File = java.io.File;
//using URI = java.net.URI;
//using URL = java.net.URL;
//using CSH = javax.help.CSH;
//using HelpBroker = javax.help.HelpBroker;
//using HelpSet = javax.help.HelpSet;
//using javax.swing;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.java.help;

public class JavaHelpUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly JavaHelpUtil instance = new JavaHelpUtil();
    public static JavaHelpUtil getInstance()
    {
        return JavaHelpUtil.instance;
    }

    private readonly Point point = new Point(0, 0);
    private readonly Dimension dimension = new Dimension(640, 480);
    private ActionEvent contextSensitiveHelpActionEvent = new ActionEvent(new JLabel(), ActionEvent.ACTION_FIRST, null);
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private JavaHelpUtil()
    {
    }

    public virtual HelpSet getHelpSet(string filePath)
    {
        try {
            URI helpSetURI = new File(filePath).toURI();
            URL helpSetURL = helpSetURI.toURL();
            return this.getHelpSet(helpSetURL);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, getInstance(), "set", e);
            return null;
        }
    }

    public virtual HelpSet getHelpSet(URL url)
    {
        try {
            return new HelpSet(null, url);
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, getInstance(), "set", e);
            return null;
        }
    }

    public virtual void show(HelpSet helpSet)
    {
        try {
            HelpBroker helpBroker = helpSet.createHelpBroker();
            helpBroker.setLocation(this.point);
            helpBroker.setSize(this.dimension);
            new CSH.DisplayHelpFromSource(helpBroker).actionPerformed(this.contextSensitiveHelpActionEvent);
            this.logUtil.putF("CSH Action", getInstance(), "show");
        } catch (Exception e) {
            this.logUtil.put(this.commonStrings.EXCEPTION, getInstance(), "show", e);
        }
    }

    public static void main(string[] args)
    {
        try {
            JavaHelpUtil javaHelpUtil = JavaHelpUtil.getInstance();
            javaHelpUtil.show(javaHelpUtil.getHelpSet("G:/mnt/bc/mydev/working/automation/InputAutomationJavaApplication/AllBinaryInputAutomationHelp/AllBinaryInputAutomation.hs"));
        } catch (Exception e) {
        }
    }

}

