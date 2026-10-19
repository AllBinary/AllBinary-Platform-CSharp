// Generated Code Do Not Modify

using System;
using System.Linq;
//using Dictionary = java.util.Dictionary;

namespace org.osgi.framework;

public interface BundleContext
{
    Bundle[] getBundles();

    // throws BundleException
    Bundle installBundle(string location);

    ServiceRegistration registerService(string clazz, object service, Dictionary properties);

    object getService(ServiceReference reference);

    // throws InvalidSyntaxException
    ServiceReference[] getServiceReferences(string clazz, string filter);

    ServiceReference getServiceReference(string clazz);

}

