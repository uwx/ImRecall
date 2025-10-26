# Org.OpenAPITools.Api.LibrariesApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateLibrary**](LibrariesApi.md#createlibrary) | **POST** /libraries |  |
| [**DeleteLibrary**](LibrariesApi.md#deletelibrary) | **DELETE** /libraries/{id} |  |
| [**GetAllLibraries**](LibrariesApi.md#getalllibraries) | **GET** /libraries |  |
| [**GetLibrary**](LibrariesApi.md#getlibrary) | **GET** /libraries/{id} |  |
| [**GetLibraryStatistics**](LibrariesApi.md#getlibrarystatistics) | **GET** /libraries/{id}/statistics |  |
| [**ScanLibrary**](LibrariesApi.md#scanlibrary) | **POST** /libraries/{id}/scan |  |
| [**UpdateLibrary**](LibrariesApi.md#updatelibrary) | **PUT** /libraries/{id} |  |
| [**Validate**](LibrariesApi.md#validate) | **POST** /libraries/{id}/validate |  |

<a id="createlibrary"></a>
# **CreateLibrary**
> LibraryResponseDto CreateLibrary (CreateLibraryDto createLibraryDto)



This endpoint is an admin-only route, and requires the `library.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **createLibraryDto** | [**CreateLibraryDto**](CreateLibraryDto.md) |  |  |

### Return type

[**LibraryResponseDto**](LibraryResponseDto.md)

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

<a id="deletelibrary"></a>
# **DeleteLibrary**
> void DeleteLibrary (Guid id)



This endpoint is an admin-only route, and requires the `library.delete` permission.


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

<a id="getalllibraries"></a>
# **GetAllLibraries**
> List&lt;LibraryResponseDto&gt; GetAllLibraries ()



This endpoint is an admin-only route, and requires the `library.read` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;LibraryResponseDto&gt;**](LibraryResponseDto.md)

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

<a id="getlibrary"></a>
# **GetLibrary**
> LibraryResponseDto GetLibrary (Guid id)



This endpoint is an admin-only route, and requires the `library.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

[**LibraryResponseDto**](LibraryResponseDto.md)

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

<a id="getlibrarystatistics"></a>
# **GetLibraryStatistics**
> LibraryStatsResponseDto GetLibraryStatistics (Guid id)



This endpoint is an admin-only route, and requires the `library.statistics` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

[**LibraryStatsResponseDto**](LibraryStatsResponseDto.md)

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

<a id="scanlibrary"></a>
# **ScanLibrary**
> void ScanLibrary (Guid id)



This endpoint is an admin-only route, and requires the `library.update` permission.


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

<a id="updatelibrary"></a>
# **UpdateLibrary**
> LibraryResponseDto UpdateLibrary (Guid id, UpdateLibraryDto updateLibraryDto)



This endpoint is an admin-only route, and requires the `library.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **updateLibraryDto** | [**UpdateLibraryDto**](UpdateLibraryDto.md) |  |  |

### Return type

[**LibraryResponseDto**](LibraryResponseDto.md)

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

<a id="validate"></a>
# **Validate**
> ValidateLibraryResponseDto Validate (Guid id, ValidateLibraryDto validateLibraryDto)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **validateLibraryDto** | [**ValidateLibraryDto**](ValidateLibraryDto.md) |  |  |

### Return type

[**ValidateLibraryResponseDto**](ValidateLibraryResponseDto.md)

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

