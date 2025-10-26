# Org.OpenAPITools.Api.AlbumsApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AddAssetsToAlbum**](AlbumsApi.md#addassetstoalbum) | **PUT** /albums/{id}/assets |  |
| [**AddAssetsToAlbums**](AlbumsApi.md#addassetstoalbums) | **PUT** /albums/assets |  |
| [**AddUsersToAlbum**](AlbumsApi.md#adduserstoalbum) | **PUT** /albums/{id}/users |  |
| [**CreateAlbum**](AlbumsApi.md#createalbum) | **POST** /albums |  |
| [**DeleteAlbum**](AlbumsApi.md#deletealbum) | **DELETE** /albums/{id} |  |
| [**GetAlbumInfo**](AlbumsApi.md#getalbuminfo) | **GET** /albums/{id} |  |
| [**GetAlbumStatistics**](AlbumsApi.md#getalbumstatistics) | **GET** /albums/statistics |  |
| [**GetAllAlbums**](AlbumsApi.md#getallalbums) | **GET** /albums |  |
| [**RemoveAssetFromAlbum**](AlbumsApi.md#removeassetfromalbum) | **DELETE** /albums/{id}/assets |  |
| [**RemoveUserFromAlbum**](AlbumsApi.md#removeuserfromalbum) | **DELETE** /albums/{id}/user/{userId} |  |
| [**UpdateAlbumInfo**](AlbumsApi.md#updatealbuminfo) | **PATCH** /albums/{id} |  |
| [**UpdateAlbumUser**](AlbumsApi.md#updatealbumuser) | **PUT** /albums/{id}/user/{userId} |  |

<a id="addassetstoalbum"></a>
# **AddAssetsToAlbum**
> List&lt;BulkIdResponseDto&gt; AddAssetsToAlbum (Guid id, BulkIdsDto bulkIdsDto, string key = null, string slug = null)



This endpoint requires the `albumAsset.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **bulkIdsDto** | [**BulkIdsDto**](BulkIdsDto.md) |  |  |
| **key** | **string** |  | [optional]  |
| **slug** | **string** |  | [optional]  |

### Return type

[**List&lt;BulkIdResponseDto&gt;**](BulkIdResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="addassetstoalbums"></a>
# **AddAssetsToAlbums**
> AlbumsAddAssetsResponseDto AddAssetsToAlbums (AlbumsAddAssetsDto albumsAddAssetsDto, string key = null, string slug = null)



This endpoint requires the `albumAsset.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **albumsAddAssetsDto** | [**AlbumsAddAssetsDto**](AlbumsAddAssetsDto.md) |  |  |
| **key** | **string** |  | [optional]  |
| **slug** | **string** |  | [optional]  |

### Return type

[**AlbumsAddAssetsResponseDto**](AlbumsAddAssetsResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="adduserstoalbum"></a>
# **AddUsersToAlbum**
> AlbumResponseDto AddUsersToAlbum (Guid id, AddUsersDto addUsersDto)



This endpoint requires the `albumUser.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **addUsersDto** | [**AddUsersDto**](AddUsersDto.md) |  |  |

### Return type

[**AlbumResponseDto**](AlbumResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="createalbum"></a>
# **CreateAlbum**
> AlbumResponseDto CreateAlbum (CreateAlbumDto createAlbumDto)



This endpoint requires the `album.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createAlbumDto** | [**CreateAlbumDto**](CreateAlbumDto.md) |  |  |

### Return type

[**AlbumResponseDto**](AlbumResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="deletealbum"></a>
# **DeleteAlbum**
> void DeleteAlbum (Guid id)



This endpoint requires the `album.delete` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

void (empty response body)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getalbuminfo"></a>
# **GetAlbumInfo**
> AlbumResponseDto GetAlbumInfo (Guid id, string key = null, string slug = null, bool withoutAssets = null)



This endpoint requires the `album.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **key** | **string** |  | [optional]  |
| **slug** | **string** |  | [optional]  |
| **withoutAssets** | **bool** |  | [optional]  |

### Return type

[**AlbumResponseDto**](AlbumResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getalbumstatistics"></a>
# **GetAlbumStatistics**
> AlbumStatisticsResponseDto GetAlbumStatistics ()



This endpoint requires the `album.statistics` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**AlbumStatisticsResponseDto**](AlbumStatisticsResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getallalbums"></a>
# **GetAllAlbums**
> List&lt;AlbumResponseDto&gt; GetAllAlbums (Guid assetId = null, bool shared = null)



This endpoint requires the `album.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **assetId** | **Guid** | Only returns albums that contain the asset Ignores the shared parameter undefined: get all albums | [optional]  |
| **shared** | **bool** |  | [optional]  |

### Return type

[**List&lt;AlbumResponseDto&gt;**](AlbumResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="removeassetfromalbum"></a>
# **RemoveAssetFromAlbum**
> List&lt;BulkIdResponseDto&gt; RemoveAssetFromAlbum (Guid id, BulkIdsDto bulkIdsDto)



This endpoint requires the `albumAsset.delete` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **bulkIdsDto** | [**BulkIdsDto**](BulkIdsDto.md) |  |  |

### Return type

[**List&lt;BulkIdResponseDto&gt;**](BulkIdResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="removeuserfromalbum"></a>
# **RemoveUserFromAlbum**
> void RemoveUserFromAlbum (Guid id, string userId)



This endpoint requires the `albumUser.delete` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **userId** | **string** |  |  |

### Return type

void (empty response body)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="updatealbuminfo"></a>
# **UpdateAlbumInfo**
> AlbumResponseDto UpdateAlbumInfo (Guid id, UpdateAlbumDto updateAlbumDto)



This endpoint requires the `album.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **updateAlbumDto** | [**UpdateAlbumDto**](UpdateAlbumDto.md) |  |  |

### Return type

[**AlbumResponseDto**](AlbumResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="updatealbumuser"></a>
# **UpdateAlbumUser**
> void UpdateAlbumUser (Guid id, string userId, UpdateAlbumUserDto updateAlbumUserDto)



This endpoint requires the `albumUser.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **userId** | **string** |  |  |
| **updateAlbumUserDto** | [**UpdateAlbumUserDto**](UpdateAlbumUserDto.md) |  |  |

### Return type

void (empty response body)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **204** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

