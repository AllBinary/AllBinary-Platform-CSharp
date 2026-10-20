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
//using ByteArrayOutputStream = java.io.ByteArrayOutputStream;
//using PrintStream = java.io.PrintStream;
using java.util;
//using Properties = java.util.Properties;
//using Address = javax.mail.Address;
//using Authenticator = javax.mail.Authenticator;
//using Message = javax.mail.Message;
//using MessagingException = javax.mail.MessagingException;
//using Session = javax.mail.Session;
//using InternetAddress = javax.mail.internet.InternetAddress;
//using InternetHeaders = javax.mail.internet.InternetHeaders;
//using MimeBodyPart = javax.mail.internet.MimeBodyPart;
//using MimeMessage = javax.mail.internet.MimeMessage;
//using MimeMultipart = javax.mail.internet.MimeMultipart;
using ModDomHelper = org.allbinary.data.tree.dom.ModDomHelper;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StringUtil = org.allbinary.logic.@string.StringUtil;
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.communication.smtp;

public class Email : EmailInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private MimeMessage msg = null;
    private Properties properties = null;
    private System.IO.MemoryStream bs = null;
    private bool isDebug;
    private static readonly string DEBUG = "mail.debug";
    private static readonly string SMTP_HOST = "mail.smtp.host";
    private static readonly string SMTP_PORT = "mail.smtp.port";
    private static readonly string SMTP_USER = "mail.smtp.user";
    private static readonly string SMTP_RETURN_ADDRESS = "mail.from";
    private static readonly string SMTP_LOCAL_HOST = "mail.smtp.localhost";
    public Email(string from, string to, string subject, string server, string textBody, string htmlAttachment, string contentBase)
    {
        this.isDebug = false;
        this.init(from, to, subject, server, textBody, htmlAttachment, contentBase);
    }

    public Email(string from, string to, string subject, string server, string textBody, string htmlAttachment, string contentBase, bool isDebug)
    {
        this.isDebug = isDebug;
        this.init(from, to, subject, server, textBody, htmlAttachment, contentBase);
    }

    // throws Exception
    public virtual void init(string from, string to, string subject, string server, string textBody, string htmlAttachment, string contentBase)
    {
        try {
            StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
            MimeBodyPart[] mimeBodyParts = new MimeBodyPart[(!stringValidationUtil.isEmpty(htmlAttachment) ? 2 : 1)];
            mimeBodyParts[0] = new MimeBodyPart();
            mimeBodyParts[0].setText(textBody);
            if (!stringValidationUtil.isEmpty(htmlAttachment)) {
                InternetHeaders internetHeaders = new InternetHeaders();
                internetHeaders.addHeader("Content-Type", "text/html");
                if (!stringValidationUtil.isEmpty(contentBase)) {
                    internetHeaders.addHeader("Content-Base", contentBase);
                }
                mimeBodyParts[1] = new MimeBodyPart(internetHeaders, System.Text.Encoding.UTF8.GetBytes(htmlAttachment));
            }
            this.init(server, ((Authenticator) null), new InternetAddress[] { new InternetAddress(from) }, new InternetAddress[] { new InternetAddress(to) }, ((InternetAddress[]) null), ((InternetAddress[]) null), subject, mimeBodyParts);
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGINGERROR)) {
                CommonStrings commonStrings = CommonStrings.getInstance();
                this.logUtil.put(commonStrings.EXCEPTION, this, "emailConstructor", e);
            }
            throw e;
        }
    }

    // throws MessagingException
    public virtual void init(string server, Authenticator authenticator, InternetAddress[] addresses_from, InternetAddress[] addresses_to, InternetAddress[] addresses_cc, InternetAddress[] addresses_bcc, string subject, MimeBodyPart[] mimeBodyParts)
    {
        this.properties = new Properties();
        this.properties.put(Email.SMTP_HOST, server);
        try {
            string hostName = StringUtil.getInstance().EMPTY_STRING;
            if (StringValidationUtil.getInstance().isEmpty(hostName)) {
                if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGINGERROR)) {
                    this.logUtil.putF("Unable to get HostName so using fake", this, "init()");
                }
                this.properties.put(Email.SMTP_LOCAL_HOST, "FakeHostName");
            }
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGINGERROR)) {
                this.logUtil.put("Continuing on Exception: Unable to get HostName", this, "init()", e);
            }
            this.properties.put(Email.SMTP_LOCAL_HOST, "FakeHostName");
        }
        if (this.isDebug) {
            this.properties.put(Email.DEBUG, "true");
        }
        Session session = Session.getInstance(this.properties, authenticator);
        if (this.isDebug) {
            session.setDebug(true);
            this.bs = new System.IO.MemoryStream();
            PrintStream printStream = new PrintStream(this.bs);
            session.setDebugOut(printStream);
        }
        this.msg = new MimeMessage(session);
        this.msg.addFrom(addresses_from);
        this.msg.setRecipients(Message.RecipientType.TO, addresses_to);
        this.msg.setRecipients(Message.RecipientType.CC, addresses_cc);
        this.msg.setRecipients(Message.RecipientType.BCC, addresses_bcc);
        this.msg.setSubject(subject);
        MimeMultipart mimeMultipart = new MimeMultipart();
        for (int i = 0; i < mimeBodyParts.Length; i++) {
            mimeMultipart.addBodyPart(mimeBodyParts[i]);
        }
        this.msg.setContent(mimeMultipart);
    }

    public virtual MimeMessage getMimeMessage()
    {
        return this.msg;
    }

    public virtual string getDebugInfo()
    {
        if (this.isDebug) {
            return "More Logging Before This To Standard Out: " + new string((System.Text.Encoding.UTF8.GetString(this.bs.ToArray())).ToCharArray());
        } else {
            return "Debugging Is Off";
        }
    }

    // throws Exception
    public virtual string log()
    {
        return "\nHashMap: " + this.toHashMap().ToString();
    }

    // throws Exception
    public virtual HashMap<object, object> toHashMap()
    {
        try {
            HashMap<object, object> hashMap = StdUtil.getInstance().createHashMap();
            hashMap.put(EmailData.SERVER, ((string) this.properties.get(Email.SMTP_HOST)));
            Address[] addresses = this.msg.getFrom();
            if (addresses != null) {
                for (int index = 0; index < addresses.Length; index++) {
                    hashMap.put(EmailData.FROM, addresses[index].ToString());
                }
            }
            addresses = this.msg.getRecipients(Message.RecipientType.TO);
            if (addresses != null) {
                for (int index = 0; index < addresses.Length; index++) {
                    hashMap.put(EmailData.TO, addresses[index].ToString());
                }
            }
            addresses = this.msg.getRecipients(Message.RecipientType.CC);
            if (addresses != null) {
                for (int index = 0; index < addresses.Length; index++) {
                    hashMap.put(EmailData.CC, addresses[index].ToString());
                }
            }
            addresses = this.msg.getRecipients(Message.RecipientType.BCC);
            if (addresses != null) {
                for (int index = 0; index < addresses.Length; index++) {
                    hashMap.put(EmailData.BCC, addresses[index].ToString());
                }
            }
            hashMap.put(EmailData.SUBJECT, this.msg.getSubject());
            MimeMultipart mimeMultipart = ((MimeMultipart) msg.getContent());
            if (mimeMultipart != null) {
                for (int index = 0; index < mimeMultipart.getCount(); index++) {
                    string content = ((string) mimeMultipart.getBodyPart(index).getContent());
                    hashMap.put(EmailData.CONTENT, content);
                }
            }
            return hashMap;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGINGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "toHashMap()", e);
            }
            throw e;
        }
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        Node node = ModDomHelper.createNameValueNodes(document, EmailData.NAME, this.toHashMap());
        return node;
    }

    // throws Exception
    public virtual Document toXmlDoc()
    {
        throw new Exception(CommonStrings.getInstance().NOT_IMPLEMENTED);
    }

}

