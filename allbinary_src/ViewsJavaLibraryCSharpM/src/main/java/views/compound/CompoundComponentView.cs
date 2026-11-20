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
using XmlDocumentHelper = org.allbinary.data.tree.dom.document.XmlDocumentHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using HttpStoreComponentView = views.business.context.modules.storefront.HttpStoreComponentView;
using LogConfigTypeFactory = org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory;
using LogConfigTypes = org.allbinary.logic.communication.log.config.type.LogConfigTypes;

namespace views.compound;

public class CompoundComponentView : HttpStoreComponentView
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public CompoundComponentView(TransformInfoInterface transformInfoInterface) : base(transformInfoInterface)
    {
        // base(transformInfoInterface) is called from the constructor declaration
    }

    // throws Exception
    public override string view()
    {
        try {
            string success = XmlDocumentHelper.toString(this.getDoc());
            string result = new CompoundTransform(this.getTransformInfoInterface()).translate(success);
            return result;
        } catch (Exception e) {
            if (LogConfigTypes.LOGGING.contains(LogConfigTypeFactory.getInstance().TAGHELPERERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "view()", e);
            }
            throw e;
        }
    }

}

