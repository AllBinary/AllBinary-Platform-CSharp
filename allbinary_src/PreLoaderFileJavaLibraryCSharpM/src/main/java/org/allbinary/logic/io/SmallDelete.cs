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
//using DataOutputStream = java.io.DataOutputStream;
//using FileOutputStream = java.io.FileOutputStream;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using AbFileSystem = org.allbinary.logic.io.file.AbFileSystem;
using CommonStrings = org.allbinary.@string.CommonStrings;

namespace org.allbinary.logic.io;

public class SmallDelete
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private string fileName;
    private string @string;
    public SmallDelete(string fileName)
    {
        this.fileName = fileName;
        this.@string = AbFileSystem.getInstance().readAsString(fileName);
    }

    public virtual bool deleteAtStart(string start, string end)
    {
        try {
            int beginIndex = 0;
            int endIndex = 0;
            beginIndex = this.@string.IndexOf(start);
            endIndex = this.@string.IndexOf(end);
            if (endIndex > beginIndex && beginIndex >= 0 && endIndex >= 0 && beginIndex < 10 && endIndex < 525) {
                string text = this.@string.Substring(endIndex, (this.@string.Length) - (endIndex));
                FileOutputStream idFile = new FileOutputStream(this.fileName);
                DataOutputStream idOutData = new DataOutputStream(idFile);
                idOutData.writeBytes(text);
                return true;
            }
            return false;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().IDLOGGING)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "deleteAtStart", e);
            }
            return false;
        }
    }

    public virtual bool deleteBetween(string start, string end, string newText)
    {
        try {
            int beginIndex = 0;
            int endIndex = 0;
            beginIndex = this.@string.IndexOf(start);
            endIndex = this.@string.IndexOf(end);
            if (endIndex > beginIndex && beginIndex >= 0 && endIndex >= 0 && beginIndex < 50 && endIndex < 425) {
                string newStart = this.@string.Substring(0, (beginIndex) - (0));
                string text = this.@string.Substring(endIndex + end.Length, (this.@string.Length) - (endIndex + end.Length));
                FileOutputStream idFile = new FileOutputStream(this.fileName);
                DataOutputStream idOutData = new DataOutputStream(idFile);
                idOutData.writeBytes(newStart + newText + text);
                return true;
            }
            return false;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().IDLOGGING)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "deleteAtStart", e);
            }
            return false;
        }
    }

}

