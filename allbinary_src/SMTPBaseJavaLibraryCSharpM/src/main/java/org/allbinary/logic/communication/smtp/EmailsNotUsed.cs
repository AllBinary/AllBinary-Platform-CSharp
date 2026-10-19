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
using BasicErrorNodeUtil = org.allbinary.data.tree.dom.BasicErrorNodeUtil;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using StdUtil = org.allbinary.logic.StdUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CommonStrings = org.allbinary.@string.CommonStrings;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.logic.communication.smtp;

public class EmailsNotUsed : DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public readonly CommonStrings commonStrings = CommonStrings.getInstance();
    public BasicArrayList emailInfoVector;
    public EmailsNotUsed()
    {
        this.emailInfoVector = new BasicArrayListD();
    }

    // throws Exception
    public virtual Node toXmlNode(Document document)
    {
        try {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PAYMENT)) {
                this.logUtil.putF(this.commonStrings.START, this, "toXmlNode");
            }
            Node node = document.createElement(EmailData.NAME);
            int size = this.emailInfoVector.size();
            for (int index = 0; index < size; index++) {
                Email email = ((Email) this.emailInfoVector.get(index));
                Node emailNode = email.toXmlNode(document);
                if (emailNode != null) {
                    node.appendChild(emailNode);
                }
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().PAYMENT)) {
                this.logUtil.putF(this.commonStrings.END, this, "toXmlNode()");
            }
            return node;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().EMAILLOGGINGERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "toXmlNode()", e);
            }
            string error = "Error Processing Order.  Please contact us if error persists.<p/>";
            return BasicErrorNodeUtil.get(document, error);
        }
    }

}

