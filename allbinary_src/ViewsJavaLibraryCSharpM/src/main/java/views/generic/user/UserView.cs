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
using UserDomNode = org.allbinary.business.user.UserDomNode;
using UserInterface = org.allbinary.business.user.UserInterface;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace views.generic.user;

public class UserView : HttpStoreComponentView
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public UserInterface user = null;
    public UserView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // Constructor invocation emitted in the initializer.
    }

    public virtual void addDomNodeInterfaces()
    {
        this.addDomNodeInterface(((DomNodeInterface) new UserDomNode(this.user)));
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

