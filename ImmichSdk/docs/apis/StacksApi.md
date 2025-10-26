# Org.OpenAPITools.Api.StacksApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateStack**](StacksApi.md#createstack) | **POST** /stacks |  |
| [**DeleteStack**](StacksApi.md#deletestack) | **DELETE** /stacks/{id} |  |
| [**DeleteStacks**](StacksApi.md#deletestacks) | **DELETE** /stacks |  |
| [**GetStack**](StacksApi.md#getstack) | **GET** /stacks/{id} |  |
| [**RemoveAssetFromStack**](StacksApi.md#removeassetfromstack) | **DELETE** /stacks/{id}/assets/{assetId} |  |
| [**SearchStacks**](StacksApi.md#searchstacks) | **GET** /stacks |  |
| [**UpdateStack**](StacksApi.md#updatestack) | **PUT** /stacks/{id} |  |

<a id="createstack"></a>
# **CreateStack**
> StackResponseDto CreateStack (StackCreateDto stackCreateDto)



This endpoint requires the `stack.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **stackCreateDto** | [**StackCreateDto**](StackCreateDto.md) |  |  |

### Return type

[**StackResponseDto**](StackResponseDto.md)

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

<a id="deletestack"></a>
# **DeleteStack**
> void DeleteStack (Guid id)



This endpoint requires the `stack.delete` permission.


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

<a id="deletestacks"></a>
# **DeleteStacks**
> void DeleteStacks (BulkIdsDto bulkIdsDto)



This endpoint requires the `stack.delete` permission.


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

<a id="getstack"></a>
# **GetStack**
> StackResponseDto GetStack (Guid id)



This endpoint requires the `stack.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

[**StackResponseDto**](StackResponseDto.md)

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

<a id="removeassetfromstack"></a>
# **RemoveAssetFromStack**
> void RemoveAssetFromStack (Guid assetId, Guid id)



This endpoint requires the `stack.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **assetId** | **Guid** |  |  |
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

<a id="searchstacks"></a>
# **SearchStacks**
> List&lt;StackResponseDto&gt; SearchStacks (Guid primaryAssetId = null)



This endpoint requires the `stack.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **primaryAssetId** | **Guid** |  | [optional]  |

### Return type

[**List&lt;StackResponseDto&gt;**](StackResponseDto.md)

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

<a id="updatestack"></a>
# **UpdateStack**
> StackResponseDto UpdateStack (Guid id, StackUpdateDto stackUpdateDto)



This endpoint requires the `stack.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **stackUpdateDto** | [**StackUpdateDto**](StackUpdateDto.md) |  |  |

### Return type

[**StackResponseDto**](StackResponseDto.md)

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

