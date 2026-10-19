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
using StringValidationUtil = org.allbinary.logic.@string.StringValidationUtil;
using AbeClientInformationInterface = org.allbinary.logic.system.security.licensing.AbeClientInformationInterface;
using TransformInfoInterface = org.allbinary.logic.visual.transform.info.TransformInfoInterface;
using Document = org.w3c.dom.Document;

namespace org.allbinary.logic.visual.transform.info.objectConfig;

public class TransformInfoObjectConfigAndManipulatorFactory : TransformInfoObjectConfigAndManipulatorFactoryBase
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly TransformInfoObjectConfigAndManipulatorFactory instance = new TransformInfoObjectConfigAndManipulatorFactory();
    public static TransformInfoObjectConfigAndManipulatorFactory getInstance()
    {
        return TransformInfoObjectConfigAndManipulatorFactory.instance;
    }

    private TransformInfoObjectConfigAndManipulatorFactory()
    {
    }

    // throws Exception
    public virtual TransformInfoObjectConfigInterface getInstance(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface, AbPath objectConfigFileAbPath)
    {
        try {
            string data = new CryptFileReader(TransformInfoObjectConfigData.getInstance().UNCRYPTED_EXTENSION, TransformInfoObjectConfigData.getInstance().ENCRYPTED_EXTENSION).get(objectConfigFileAbPath);
            return this.getInstance(abeClientInformation, transformInfoInterface, DomDocumentHelper.create(data));
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Could Not Load Object Config", getInstance(), this.commonStrings.GET_INSTANCE, e);
            }
            throw e;
        }
    }

    // throws Exception
    public virtual TransformInfoObjectConfigInterface getInstance(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface)
    {
        try {
            StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
            if (transformInfoInterface != null && !stringValidationUtil.isEmpty(transformInfoInterface.getStoreName())) {
                return ((TransformInfoObjectConfigInterface) new GenericStoreTransformInfoObjectConfig(abeClientInformation, transformInfoInterface));
            } else {
                return ((TransformInfoObjectConfigInterface) new TransformInfoObjectConfig(transformInfoInterface));
            }
        } catch (Exception e) {
            string error = "Failed To Get Instance: ";
            if (transformInfoInterface != null) {
                error = error + transformInfoInterface.getName();
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, getInstance(), commonStrings.GET_INSTANCE, e);
            }
            throw e;
        }
    }

    // throws Exception
    public virtual TransformInfoObjectConfigInterface getInstance(AbeClientInformationInterface abeClientInformation, TransformInfoInterface transformInfoInterface, Document document)
    {
        try {
            StringValidationUtil stringValidationUtil = StringValidationUtil.getInstance();
            if (transformInfoInterface != null && !stringValidationUtil.isEmpty(transformInfoInterface.getStoreName())) {
                return ((TransformInfoObjectConfigInterface) new GenericStoreTransformInfoObjectConfig(abeClientInformation, transformInfoInterface, document));
            } else {
                return ((TransformInfoObjectConfigInterface) new TransformInfoObjectConfig(transformInfoInterface, document));
            }
        } catch (Exception e) {
            string error = "Failed To Get Instance: ";
            if (transformInfoInterface != null) {
                error = error + transformInfoInterface.getName();
            }
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().TAGHELPERFACTORYERROR)) {
                this.logUtil.put(commonStrings.EXCEPTION, getInstance(), "getInstance(document)", e);
            }
            throw e;
        }
    }

}

