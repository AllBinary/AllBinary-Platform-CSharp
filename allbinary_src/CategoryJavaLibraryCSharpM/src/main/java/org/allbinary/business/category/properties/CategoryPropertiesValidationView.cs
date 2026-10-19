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
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using ValidationInterface = org.allbinary.logic.control.validate.ValidationInterface;
using StringMaker = org.allbinary.logic.@string.StringMaker;
using Document = org.w3c.dom.Document;
using Node = org.w3c.dom.Node;

namespace org.allbinary.business.category.properties;

public class CategoryPropertiesValidationView : CategoryPropertiesView, ValidationInterface
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    public CategoryPropertiesValidationView(CategoryPropertiesInterface categoryPropertiesInterface) : base(categoryPropertiesInterface)
    {
        // base(categoryPropertiesInterface) is called from the constructor declaration
    }

    // throws Exception
    public virtual bool? isValid()
    {
        return this.categoryPropertiesInterface.isValid();
    }

    // throws Exception
    public virtual string validationInfo()
    {
        try {
            StringMaker stringBuffer = new StringMaker();
            stringBuffer.append(this.categoryPropertiesInterface.validationInfo());
            return stringBuffer.ToString();
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().VIEWERROR)) {
                this.logUtil.put("Failed to generate validation info error", this, "validationInfo()", e);
            }
            return "Error Validating Data";
        }
    }

    // throws Exception
    public virtual Document toValidationInfoDoc()
    {
        return null;
    }

    // throws Exception
    public virtual Node toValidationInfoNode(Document document)
    {
        return null;
    }

}

