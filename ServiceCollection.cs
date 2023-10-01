using System;
using System.Collections.Generic;

namespace JiraTempoAppGodot;

public static class ServiceCollection
{
    private static readonly Dictionary<Type, IService> Services = new();

    public static void Add(IService service)
    {
        Services.Add(service.GetType(), service);
    }

    public static T Get<T>() where T : class, IService
    {
        Services.TryGetValue(typeof(T), out var service);

        return service as T;
    }
}