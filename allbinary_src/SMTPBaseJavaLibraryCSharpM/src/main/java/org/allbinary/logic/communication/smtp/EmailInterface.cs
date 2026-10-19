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
//using MimeMessage = javax.mail.internet.MimeMessage;
using DomNodeInterface = org.allbinary.data.tree.dom.DomNodeInterface;
using DomDocumentMappingInterface = org.allbinary.data.tree.dom.document.mapping.DomDocumentMappingInterface;

namespace org.allbinary.logic.communication.smtp;

public interface EmailInterface : DomNodeInterface, DomDocumentMappingInterface
{
    string getDebugInfo();

    MimeMessage getMimeMessage();

    // throws Exception
    string log();

}

