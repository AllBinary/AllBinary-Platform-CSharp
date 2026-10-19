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

public class SmallInsert
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private readonly CommonStrings commonStrings = CommonStrings.getInstance();
    private string fileName;
    private string @string;
    public SmallInsert(string fileName)
    {
        this.fileName = fileName;
        this.@string = AbFileSystem.getInstance().readAsString(fileName);
    }

    public virtual bool atBeginning(string text)
    {
        try {
            FileOutputStream idFile = new FileOutputStream(this.fileName);
            DataOutputStream idOutData = new DataOutputStream(idFile);
            idOutData.writeBytes(text + this.@string);
            return true;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().IDLOGGING)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "insertAtBeginning", e);
            }
            return false;
        }
    }

    public virtual bool after(string text, string after)
    {
        try {
            int index = this.@string.IndexOf(after);
            if (index < 0) {
                Console.WriteLine("No such start: " + after + " in: " + this.@string);
                return false;
            }
            index = index + after.Length;
            string start = this.@string.Substring(0, (index) - (0));
            string end = this.@string.Substring(index + 1, (this.@string.Length) - (index + 1));
            FileOutputStream idFile = new FileOutputStream(this.fileName);
            DataOutputStream idOutData = new DataOutputStream(idFile);
            idOutData.writeBytes(start + text + end);
            idOutData.close();
            idFile.close();
            return true;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().IDLOGGING)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "after", e);
            }
            return false;
        }
    }

    public virtual bool atEnd(string text)
    {
        try {
            FileOutputStream idFile = new FileOutputStream(this.fileName);
            DataOutputStream idOutData = new DataOutputStream(idFile);
            idOutData.writeBytes(this.@string + text);
            return true;
        } catch (Exception e) {
            if (org.allbinary.logic.communication.log.config.type.LogConfigTypes.LOGGING.contains(org.allbinary.logic.communication.log.config.type.LogConfigTypeFactory.getInstance().IDLOGGING)) {
                this.logUtil.put(this.commonStrings.EXCEPTION, this, "insertAtEnd", e);
            }
            return false;
        }
    }

}

