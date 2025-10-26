# Org.OpenAPITools.Api.MemoriesApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**AddMemoryAssets**](MemoriesApi.md#addmemoryassets) | **PUT** /memories/{id}/assets |  |
| [**CreateMemory**](MemoriesApi.md#creatememory) | **POST** /memories |  |
| [**DeleteMemory**](MemoriesApi.md#deletememory) | **DELETE** /memories/{id} |  |
| [**GetMemory**](MemoriesApi.md#getmemory) | **GET** /memories/{id} |  |
| [**MemoriesStatistics**](MemoriesApi.md#memoriesstatistics) | **GET** /memories/statistics |  |
| [**RemoveMemoryAssets**](MemoriesApi.md#removememoryassets) | **DELETE** /memories/{id}/assets |  |
| [**SearchMemories**](MemoriesApi.md#searchmemories) | **GET** /memories |  |
| [**UpdateMemory**](MemoriesApi.md#updatememory) | **PUT** /memories/{id} |  |

<a id="addmemoryassets"></a>
# **AddMemoryAssets**
> List&lt;BulkIdResponseDto&gt; AddMemoryAssets (Guid id, BulkIdsDto bulkIdsDto)



This endpoint requires the `memoryAsset.create` permission.


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

<a id="creatememory"></a>
# **CreateMemory**
> MemoryResponseDto CreateMemory (MemoryCreateDto memoryCreateDto)



This endpoint requires the `memory.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **memoryCreateDto** | [**MemoryCreateDto**](MemoryCreateDto.md) |  |  |

### Return type

[**MemoryResponseDto**](MemoryResponseDto.md)

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

<a id="deletememory"></a>
# **DeleteMemory**
> void DeleteMemory (Guid id)



This endpoint requires the `memory.delete` permission.


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

<a id="getmemory"></a>
# **GetMemory**
> MemoryResponseDto GetMemory (Guid id)



This endpoint requires the `memory.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

[**MemoryResponseDto**](MemoryResponseDto.md)

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

<a id="memoriesstatistics"></a>
# **MemoriesStatistics**
> MemoryStatisticsResponseDto MemoriesStatistics (DateTime varFor = null, bool isSaved = null, bool isTrashed = null, MemoryType type = null)



This endpoint requires the `memory.statistics` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **varFor** | **DateTime** |  | [optional]  |
| **isSaved** | **bool** |  | [optional]  |
| **isTrashed** | **bool** |  | [optional]  |
| **type** | **MemoryType** |  | [optional]  |

### Return type

[**MemoryStatisticsResponseDto**](MemoryStatisticsResponseDto.md)

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

<a id="removememoryassets"></a>
# **RemoveMemoryAssets**
> List&lt;BulkIdResponseDto&gt; RemoveMemoryAssets (Guid id, BulkIdsDto bulkIdsDto)



This endpoint requires the `memoryAsset.delete` permission.


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

<a id="searchmemories"></a>
# **SearchMemories**
> List&lt;MemoryResponseDto&gt; SearchMemories (DateTime varFor = null, bool isSaved = null, bool isTrashed = null, MemoryType type = null)



This endpoint requires the `memory.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **varFor** | **DateTime** |  | [optional]  |
| **isSaved** | **bool** |  | [optional]  |
| **isTrashed** | **bool** |  | [optional]  |
| **type** | **MemoryType** |  | [optional]  |

### Return type

[**List&lt;MemoryResponseDto&gt;**](MemoryResponseDto.md)

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

<a id="updatememory"></a>
# **UpdateMemory**
> MemoryResponseDto UpdateMemory (Guid id, MemoryUpdateDto memoryUpdateDto)



This endpoint requires the `memory.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **memoryUpdateDto** | [**MemoryUpdateDto**](MemoryUpdateDto.md) |  |  |

### Return type

[**MemoryResponseDto**](MemoryResponseDto.md)

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

