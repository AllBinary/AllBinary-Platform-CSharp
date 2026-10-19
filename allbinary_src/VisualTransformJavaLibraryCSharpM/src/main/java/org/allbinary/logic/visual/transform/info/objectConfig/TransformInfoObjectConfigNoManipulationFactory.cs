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
using DomDocumentHelper = org.allbinary.data.tree.dom.document.DomDocumentHelper;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using CryptFileReader = org.allbinary.logic.control.crypt.file.CryptFileReader;
using AbPath = org.allbinary.logic.io.path.AbPath;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.visual.transform.info.objectConfig;

public class TransformInfoObjectConfigNoManipulationFactory
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly TransformInfoObjectConfigNoManipulationFactory instance = new TransformInfoObjectConfigNoManipulationFactory();
    public static TransformInfoObjectConfigNoManipulationFactory getInstance()
    {
        return TransformInfoObjectConfigNoManipulationFactory.instance;
    }

    private TransformInfoObjectConfigNoManipulationFactory()
    {
    }

    // throws Exception
    public virtual TransformInfoObjectConfigInterface getInstance(TransformInfoInterface transformInfoInterface, AbPath objectConfigFileAbPath)
    {
        try {
            TransformInfoObjectConfigData transformInfoObjectConfigData = TransformInfoObjectConfigData.getInstance();
            string data = new CryptFileReader(transformInfoObjectConfigData.UNCRYPTED_EXTENSION, transformInfoObjectConfigData.getInstance().ENCRYPTED_EXTENSION).get(objectConfigFileAbPath);
            return new TransformInfoObjectConfig(transformInfoInterface, DomDocumentHelper.create(data));
        } catch (Exception e) {
            CommonStrings commonStrings = CommonStrings.getInstance();
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Could Not Load Object Config", this, commonStrings.GET_INSTANCE, e);
            }
            throw e;
        }
    }

}

