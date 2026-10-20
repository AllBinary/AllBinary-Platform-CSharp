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
using BasicArrayList = org.allbinary.util.BasicArrayList;
using BasicArrayListD = org.allbinary.util.BasicArrayListD;
//using PageContext = javax.servlet.jsp.PageContext;
using ModifyTable = admin.taghelpers.ModifyTable;
using TransformInfoEntityBuilder = org.allbinary.data.tables.transform.info.TransformInfoEntityBuilder;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using TransformInfoHttpInterface = org.allbinary.logic.visual.transform.info.TransformInfoHttpInterface;
using TransformInfoHttpStoreNoManipulation = org.allbinary.logic.visual.transform.info.TransformInfoHttpStoreNoManipulation;

namespace taghelpers.transform.info;

public class TransformInfoRequestHelper : ModifyTable
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private TransformInfoHttpInterface transformInfoInterface;
    public TransformInfoRequestHelper(HashMap<object, object> propertiesHashMap, PageContext pageContext)
    {
        this.transformInfoInterface = new TransformInfoHttpStoreNoManipulation(propertiesHashMap, pageContext);
    }

    public virtual string update()
    {
        try {
            string success = "Updated Successfully";
            HashMap<object, object> hashMapData = this.transformInfoInterface.toHashMap();
            TransformInfoEntityBuilder.getInstance().update(hashMapData);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "update()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to update storefronts table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "update()", e);
            }
            return error;
        }
    }

    public virtual string insert()
    {
        try {
            string success = "Added TransformInfo Successfully";
            BasicArrayList values = this.transformInfoInterface.toVector();
            TransformInfoEntityBuilder.getInstance().insert(values);
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "insert()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to add storefronts table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "insert()", e);
            }
            return error;
        }
    }

    public virtual string delete()
    {
        try {
            string success = "Delete Successfully";
            TransformInfoEntityBuilder.getInstance().delete(((string) this.transformInfoInterface.getKey()));
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGS)) {
                this.logUtil.putF(success, this, "delete()");
            }
            return success;
        } catch (Exception e) {
            string error = "Failed to delete storefronts table";
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().SQLTAGSERROR)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "delete()", e);
            }
            return error;
        }
    }

}

