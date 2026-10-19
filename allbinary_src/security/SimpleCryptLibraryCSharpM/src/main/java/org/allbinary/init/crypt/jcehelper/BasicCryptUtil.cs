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
//using ByteArrayInputStream = java.io.ByteArrayInputStream;
//using ByteArrayOutputStream = java.io.ByteArrayOutputStream;
//using InputStream = java.io.InputStream;
using TsUtil = org.allbinary.TsUtil;
using LogUtil = org.allbinary.logic.communication.log.LogUtil;

namespace org.allbinary.init.crypt.jcehelper;

public class BasicCryptUtil
{
    public readonly LogUtil logUtil = LogUtil.getInstance();
    private static readonly BasicCryptUtil instance = new BasicCryptUtil();
    public static BasicCryptUtil getInstance()
    {
        return BasicCryptUtil.instance;
    }

    private readonly TsUtil tsUtil = TsUtil.getInstance();
    private readonly string XML_START = "<?xml";
    // throws Exception
    public virtual InputStream getDecryptedInputStream(InputStream inputStream, CryptInterface cryptInterface)
    {
        System.IO.MemoryStream buffer = new System.IO.MemoryStream();
        int ch = 0;
        while (true) {
            ch = inputStream.read();
            if (ch == -1) {
                break;
            }
            buffer.WriteByte((byte) (ch));
        }
        sbyte[] decrypted = cryptInterface.decrypt(((sbyte[]) (Array) buffer.ToArray()));
        string decryptedString = System.Text.Encoding.UTF8.GetString((byte[]) (Array) decrypted);
        int index = decryptedString.IndexOf(this.XML_START);
        if (index > 0) {
            decryptedString = decryptedString.Substring(index);
        }
        return new ByteArrayInputStream(this.tsUtil.getByteArray(decryptedString));
    }

}

