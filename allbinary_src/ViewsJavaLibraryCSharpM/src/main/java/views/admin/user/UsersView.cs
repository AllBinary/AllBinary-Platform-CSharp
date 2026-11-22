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
using UserDomNode = org.allbinary.business.user.UserDomNode;
using UsersData = org.allbinary.business.user.UsersData;
using User = org.allbinary.business.user.modules.User;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;
using HttpContextView = views.business.context.HttpContextView;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace views.admin.user;

public class UsersView : HttpContextView, DomNodeInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public BasicArrayList userVector = null;
    public UsersView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // Constructor invocation emitted in the initializer.
    }

    public virtual Node toXmlNode(Document document)
    {
        try {
            Node usersNode = document.createElement(UsersData.NAME);
            int size = this.userVector.size();
            for (int index = 0; index < size; index++) {
                User userInterface = ((User) this.userVector.get(index));
                if (userInterface != null) {
                    Node node = new UserDomNode(userInterface).toXmlNode(document);
                    usersNode.appendChild(node);
                } else {
                    this.logUtil.putF("UserHelper", this, "toXmlNode");
                }
            }
            return usersNode;
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().XSLLOGGINGERROR)) {
                this.logUtil.put(this.commonStrings.FAILURE, this, "toXmlNode", e);
            }
            return null;
        }
    }

    public virtual void addDomNodeInterfaces()
    {
        this.addDomNodeInterface(((DomNodeInterface) this));
    }

    // throws Exception
    public override string view()
    {
        try {
            this.addDomNodeInterfaces();
            return base.view();
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

}

