# Org.OpenAPITools.Api.SharedLinksApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AddSharedLinkAssets**](SharedLinksApi.md#addsharedlinkassets) | **PUT** /shared-links/{id}/assets |  |
| [**CreateSharedLink**](SharedLinksApi.md#createsharedlink) | **POST** /shared-links |  |
| [**GetAllSharedLinks**](SharedLinksApi.md#getallsharedlinks) | **GET** /shared-links |  |
| [**GetMySharedLink**](SharedLinksApi.md#getmysharedlink) | **GET** /shared-links/me |  |
| [**GetSharedLinkById**](SharedLinksApi.md#getsharedlinkbyid) | **GET** /shared-links/{id} |  |
| [**RemoveSharedLink**](SharedLinksApi.md#removesharedlink) | **DELETE** /shared-links/{id} |  |
| [**RemoveSharedLinkAssets**](SharedLinksApi.md#removesharedlinkassets) | **DELETE** /shared-links/{id}/assets |  |
| [**UpdateSharedLink**](SharedLinksApi.md#updatesharedlink) | **PATCH** /shared-links/{id} |  |

<a id="addsharedlinkassets"></a>
# **AddSharedLinkAssets**
> List&lt;AssetIdsResponseDto&gt; AddSharedLinkAssets (Guid id, AssetIdsDto assetIdsDto, string key = null, string slug = null)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **assetIdsDto** | [**AssetIdsDto**](AssetIdsDto.md) |  |  |
| **key** | **string** |  | [optional]  |
| **slug** | **string** |  | [optional]  |

### Return type

[**List&lt;AssetIdsResponseDto&gt;**](AssetIdsResponseDto.md)

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

<a id="createsharedlink"></a>
# **CreateSharedLink**
> SharedLinkResponseDto CreateSharedLink (SharedLinkCreateDto sharedLinkCreateDto)



This endpoint requires the `sharedLink.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **sharedLinkCreateDto** | [**SharedLinkCreateDto**](SharedLinkCreateDto.md) |  |  |

### Return type

[**SharedLinkResponseDto**](SharedLinkResponseDto.md)

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

<a id="getallsharedlinks"></a>
# **GetAllSharedLinks**
> List&lt;SharedLinkResponseDto&gt; GetAllSharedLinks (Guid albumId = null)



This endpoint requires the `sharedLink.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **albumId** | **Guid** |  | [optional]  |

### Return type

[**List&lt;SharedLinkResponseDto&gt;**](SharedLinkResponseDto.md)

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

<a id="getmysharedlink"></a>
# **GetMySharedLink**
> SharedLinkResponseDto GetMySharedLink (string password = null, string token = null, string key = null, string slug = null)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **password** | **string** |  | [optional]  |
| **token** | **string** |  | [optional]  |
| **key** | **string** |  | [optional]  |
| **slug** | **string** |  | [optional]  |

### Return type

[**SharedLinkResponseDto**](SharedLinkResponseDto.md)

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

<a id="getsharedlinkbyid"></a>
# **GetSharedLinkById**
> SharedLinkResponseDto GetSharedLinkById (Guid id)



This endpoint requires the `sharedLink.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

[**SharedLinkResponseDto**](SharedLinkResponseDto.md)

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

<a id="removesharedlink"></a>
# **RemoveSharedLink**
> void RemoveSharedLink (Guid id)



This endpoint requires the `sharedLink.delete` permission.


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

<a id="removesharedlinkassets"></a>
# **RemoveSharedLinkAssets**
> List&lt;AssetIdsResponseDto&gt; RemoveSharedLinkAssets (Guid id, AssetIdsDto assetIdsDto, string key = null, string slug = null)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **assetIdsDto** | [**AssetIdsDto**](AssetIdsDto.md) |  |  |
| **key** | **string** |  | [optional]  |
| **slug** | **string** |  | [optional]  |

### Return type

[**List&lt;AssetIdsResponseDto&gt;**](AssetIdsResponseDto.md)

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

<a id="updatesharedlink"></a>
# **UpdateSharedLink**
> SharedLinkResponseDto UpdateSharedLink (Guid id, SharedLinkEditDto sharedLinkEditDto)



This endpoint requires the `sharedLink.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **sharedLinkEditDto** | [**SharedLinkEditDto**](SharedLinkEditDto.md) |  |  |

### Return type

[**SharedLinkResponseDto**](SharedLinkResponseDto.md)

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

