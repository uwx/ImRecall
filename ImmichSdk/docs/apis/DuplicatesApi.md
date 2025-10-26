# Org.OpenAPITools.Api.DuplicatesApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeleteDuplicate**](DuplicatesApi.md#deleteduplicate) | **DELETE** /duplicates/{id} |  |
| [**DeleteDuplicates**](DuplicatesApi.md#deleteduplicates) | **DELETE** /duplicates |  |
| [**GetAssetDuplicates**](DuplicatesApi.md#getassetduplicates) | **GET** /duplicates |  |

<a id="deleteduplicate"></a>
# **DeleteDuplicate**
> void DeleteDuplicate (Guid id)



This endpoint requires the `duplicate.delete` permission.


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

<a id="deleteduplicates"></a>
# **DeleteDuplicates**
> void DeleteDuplicates (BulkIdsDto bulkIdsDto)



This endpoint requires the `duplicate.delete` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **bulkIdsDto** | [**BulkIdsDto**](BulkIdsDto.md) |  |  |

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

<a id="getassetduplicates"></a>
# **GetAssetDuplicates**
> List&lt;DuplicateResponseDto&gt; GetAssetDuplicates ()



This endpoint requires the `duplicate.read` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;DuplicateResponseDto&gt;**](DuplicateResponseDto.md)

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

