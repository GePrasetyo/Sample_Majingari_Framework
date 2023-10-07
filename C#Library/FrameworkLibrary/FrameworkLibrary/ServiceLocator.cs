using System;
using System.Collections.Generic;

public static class ServiceLocator {
    private static readonly Dictionary<Type, object> Services = new Dictionary<Type, object>();

    public static void Register<T>(object serviceInstance) {
        Services[typeof(T)] = serviceInstance;
    }

    public static T Resolve<T>() {
        if (!Services.ContainsKey(typeof(T))) {
            return default(T);
        }

        return (T)Services[typeof(T)];
    }

    public static void Unregister<T>(out string messageResult) {
        if (!Services.ContainsKey(typeof(T))) {
            messageResult = $"Error : Attempted to unregister service of type {typeof(T)} which is not registered with the {typeof(T)}.";
            return;
        }

        messageResult = $"Success : service of type {typeof(T)} unregistered.";
        Services.Remove(typeof(T));
    }

    public static void Reset() {
        Services.Clear();
    }
}