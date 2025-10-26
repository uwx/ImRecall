using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;

namespace ImRecall;

public static class HostConfiguration2
{
    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_services")]
    private static extern ref IServiceCollection GetServiceCollection(HostConfiguration c);

    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_HttpClientsAdded")]
    private static extern void SetHttpClientsAdded(HostConfiguration self, bool value);

    /// <summary>
    /// Configures the HttpClients.
    /// </summary>
    /// <param name="client"></param>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static HostConfiguration AddApiHttpClients
    (
        this HostConfiguration config,
        Action<IServiceProvider, HttpClient>? client = null, Action<IHttpClientBuilder>? builder = null)
    {
        if (client == null)
            client = (_, c) => c.BaseAddress = new Uri(ClientUtils.BASE_ADDRESS);

        List<IHttpClientBuilder> builders = new List<IHttpClientBuilder>();

        var _services = GetServiceCollection(config);
        builders.Add(_services.AddHttpClient<IAPIKeysApi, APIKeysApi>(client));
        builders.Add(_services.AddHttpClient<IActivitiesApi, ActivitiesApi>(client));
        builders.Add(_services.AddHttpClient<IAlbumsApi, AlbumsApi>(client));
        builders.Add(_services.AddHttpClient<IAssetsApi, AssetsApi>(client));
        builders.Add(_services.AddHttpClient<IAuthAdminApi, AuthAdminApi>(client));
        builders.Add(_services.AddHttpClient<IAuthenticationApi, AuthenticationApi>(client));
        builders.Add(_services.AddHttpClient<IDeprecatedApi, DeprecatedApi>(client));
        builders.Add(_services.AddHttpClient<IDownloadApi, DownloadApi>(client));
        builders.Add(_services.AddHttpClient<IDuplicatesApi, DuplicatesApi>(client));
        builders.Add(_services.AddHttpClient<IFacesApi, FacesApi>(client));
        builders.Add(_services.AddHttpClient<IJobsApi, JobsApi>(client));
        builders.Add(_services.AddHttpClient<ILibrariesApi, LibrariesApi>(client));
        builders.Add(_services.AddHttpClient<IMapApi, MapApi>(client));
        builders.Add(_services.AddHttpClient<IMemoriesApi, MemoriesApi>(client));
        builders.Add(_services.AddHttpClient<INotificationsApi, NotificationsApi>(client));
        builders.Add(_services.AddHttpClient<INotificationsAdminApi, NotificationsAdminApi>(client));
        builders.Add(_services.AddHttpClient<IOAuthApi, OAuthApi>(client));
        builders.Add(_services.AddHttpClient<IPartnersApi, PartnersApi>(client));
        builders.Add(_services.AddHttpClient<IPeopleApi, PeopleApi>(client));
        builders.Add(_services.AddHttpClient<ISearchApi, SearchApi>(client));
        builders.Add(_services.AddHttpClient<IServerApi, ServerApi>(client));
        builders.Add(_services.AddHttpClient<ISessionsApi, SessionsApi>(client));
        builders.Add(_services.AddHttpClient<ISharedLinksApi, SharedLinksApi>(client));
        builders.Add(_services.AddHttpClient<IStacksApi, StacksApi>(client));
        builders.Add(_services.AddHttpClient<ISyncApi, SyncApi>(client));
        builders.Add(_services.AddHttpClient<ISystemConfigApi, SystemConfigApi>(client));
        builders.Add(_services.AddHttpClient<ISystemMetadataApi, SystemMetadataApi>(client));
        builders.Add(_services.AddHttpClient<ITagsApi, TagsApi>(client));
        builders.Add(_services.AddHttpClient<ITimelineApi, TimelineApi>(client));
        builders.Add(_services.AddHttpClient<ITrashApi, TrashApi>(client));
        builders.Add(_services.AddHttpClient<IUsersApi, UsersApi>(client));
        builders.Add(_services.AddHttpClient<IUsersAdminApi, UsersAdminApi>(client));
        builders.Add(_services.AddHttpClient<IViewApi, ViewApi>(client));
        
        if (builder != null)
            foreach (IHttpClientBuilder instance in builders)
                builder(instance);

        SetHttpClientsAdded(config, true);

        return config;
    }
}