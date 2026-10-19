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
//using InputStream = java.io.InputStream;
//using URIResolver = javax.xml.transform.URIResolver;
//using StreamSource = javax.xml.transform.stream.StreamSource;
using CompositeTransformInfoInterface = org.allbinary.logic.visual.transform.info.CompositeTransformInfoInterface;

namespace org.allbinary.logic.visual.transform;

public interface BasicTransformerInterface : CompositeTransformInfoInterface
{
    void setInputStream(InputStream inputStream);

    void setURIResolver(URIResolver uriResolver);

    StreamSource getStreamSource();

    InputStream getInputStream();

    URIResolver getURIResolver();

    // throws Exception
    string translate(string xmlDocumentStr);

}

