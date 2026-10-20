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
using java.util;
//using MimeMessage = javax.mail.internet.MimeMessage;
using BasicEmailInfo = org.allbinary.logic.communication.smtp.info.BasicEmailInfo;
using EmailInfo = org.allbinary.logic.communication.smtp.info.EmailInfo;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.communication.smtp;

public class BasicEmail : EmailInterface
{
    private AbEmail email;
    public BasicEmail(EmailInfo emailInfo, string to)
    {
        BasicEmailInfo basicEmailInfo = emailInfo.getBasicEmailInfo();
        this.email = new AbEmail(basicEmailInfo.getEmailServerConfigurationInterface().getSmtpServer(), basicEmailInfo.getEmailServerConfigurationInterface().getAccountName(), to, basicEmailInfo.getSubject(), basicEmailInfo.getTextBody(), emailInfo.getHtmlAttachment(), emailInfo.getContentBase());
    }

    public virtual Email getEmail()
    {
        return ((Email) this.email.getEmail());
    }

    public virtual MimeMessage getMimeMessage()
    {
        return this.email.getMimeMessage();
    }

    public virtual string getDebugInfo()
    {
        return this.email.getDebugInfo();
    }

    // throws Exception
    public virtual string log()
    {
        return this.email.log();
    }

    // throws Exception
    public virtual HashMap<object, object> toHashMap()
    {
        return this.email.toHashMap();
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        return this.email.toXmlNode(document);
    }

    // throws Exception
    public virtual Document toXmlDoc()
    {
        return this.email.toXmlDoc();
    }

}

