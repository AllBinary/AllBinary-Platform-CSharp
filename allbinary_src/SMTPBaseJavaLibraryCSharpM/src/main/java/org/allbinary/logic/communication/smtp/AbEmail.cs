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
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.communication.smtp;

public class AbEmail : EmailInterface
{
    private Email email = null;
    public AbEmail(string server, string from, string to, string subject, string textBody, string htmlAttachment, string contentBase)
    {
        if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGINGERROR)) {
            this.email = new Email(from, to, subject, server, textBody, htmlAttachment, contentBase, true);
        } else {
            this.email = new Email(from, to, subject, server, textBody, htmlAttachment, contentBase);
        }
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
    public virtual HashMap toHashMap()
    {
        return this.email.toHashMap();
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        return this.email.toXmlNode(document);
    }

    public virtual Email getEmail()
    {
        return ((Email) this.email);
    }

    // throws Exception
    public virtual Document toXmlDoc()
    {
        return this.email.toXmlDoc();
    }

}

