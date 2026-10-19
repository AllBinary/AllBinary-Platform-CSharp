// Generated Code Do Not Modify

using System;
using System.Linq;
//using ByteArrayOutputStream = java.io.ByteArrayOutputStream;
//using InputStream = java.io.InputStream;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;
using StreamUtil = org.allbinary.logic.io.StreamUtil;
using AbFile = org.allbinary.logic.io.file.AbFile;
using AbFileNativeUtil = org.allbinary.logic.io.file.AbFileNativeUtil;
using StringMaker = org.allbinary.logic.@string.StringMaker;

namespace org.apache.commons.fileupload;

public class FileItemUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly FileItemUtil instance = new FileItemUtil();
    public static FileItemUtil getInstance()
    {
        return FileItemUtil.instance;
    }

    public readonly string DEFAULT_CHARSET = "ISO-8859-1";
    // throws Exception
    public virtual string getString(sbyte[] byteArray)
    {
        return System.Text.Encoding.UTF8.GetString((byte[]) (Array) byteArray, this.DEFAULT_CHARSET);
    }

    // throws Exception
    public virtual string getString(FileItemStream fileItem)
    {
        return new string((this.getBytes(fileItem)).ToCharArray());
    }

    // throws Exception
    public virtual sbyte[] getBytes(FileItemStream fileItem)
    {
        StreamUtil streamUtil = StreamUtil.getInstance();
        InputStream inputStream = null;
        System.IO.MemoryStream outputStream = null;
        try {
            inputStream = fileItem.openStream();
            outputStream = new System.IO.MemoryStream();
            if (fileItem.isFormField()) {
                this.logUtil.putF("FileItemStream FieldName: " + fileItem.getFieldName(), this, "write()");
            } else {
                StringMaker stringBuffer = new StringMaker();
                stringBuffer.append("Uploaded File FieldName: ");
                stringBuffer.append(fileItem.getFieldName());
                stringBuffer.append(" name = ");
                stringBuffer.append(fileItem.getName());
                this.logUtil.putF(stringBuffer.ToString(), this, "write()");
            }
            outputStream = ((System.IO.MemoryStream) streamUtil.get(inputStream, outputStream, new sbyte[16384]));
            return ((sbyte[]) (Array) outputStream.ToArray());
        } finally {
            streamUtil.close(outputStream);
            streamUtil.close(inputStream);
        }
    }

    // throws Exception
    public virtual void write(FileItem fileItem, AbFile file)
    {
        fileItem.write(AbFileNativeUtil.get(file));
    }

}

