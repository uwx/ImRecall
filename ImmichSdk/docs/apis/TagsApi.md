# Org.OpenAPITools.Api.TagsApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**BulkTagAssets**](TagsApi.md#bulktagassets) | **PUT** /tags/assets |  |
| [**CreateTag**](TagsApi.md#createtag) | **POST** /tags |  |
| [**DeleteTag**](TagsApi.md#deletetag) | **DELETE** /tags/{id} |  |
| [**GetAllTags**](TagsApi.md#getalltags) | **GET** /tags |  |
| [**GetTagById**](TagsApi.md#gettagbyid) | **GET** /tags/{id} |  |
| [**TagAssets**](TagsApi.md#tagassets) | **PUT** /tags/{id}/assets |  |
| [**UntagAssets**](TagsApi.md#untagassets) | **DELETE** /tags/{id}/assets |  |
| [**UpdateTag**](TagsApi.md#updatetag) | **PUT** /tags/{id} |  |
| [**UpsertTags**](TagsApi.md#upserttags) | **PUT** /tags |  |

<a id="bulktagassets"></a>
# **BulkTagAssets**
> TagBulkAssetsResponseDto BulkTagAssets (TagBulkAssetsDto tagBulkAssetsDto)



This endpoint requires the `tag.asset` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **tagBulkAssetsDto** | [**TagBulkAssetsDto**](TagBulkAssetsDto.md) |  |  |

### Return type

[**TagBulkAssetsResponseDto**](TagBulkAssetsResponseDto.md)

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

<a id="createtag"></a>
# **CreateTag**
> TagResponseDto CreateTag (TagCreateDto tagCreateDto)



This endpoint requires the `tag.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **tagCreateDto** | [**TagCreateDto**](TagCreateDto.md) |  |  |

### Return type

[**TagResponseDto**](TagResponseDto.md)

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

<a id="deletetag"></a>
# **DeleteTag**
> void DeleteTag (Guid id)



This endpoint requires the `tag.delete` permission.


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

<a id="getalltags"></a>
# **GetAllTags**
> List&lt;TagResponseDto&gt; GetAllTags ()



This endpoint requires the `tag.read` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;TagResponseDto&gt;**](TagResponseDto.md)

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

<a id="gettagbyid"></a>
# **GetTagById**
> TagResponseDto GetTagById (Guid id)



This endpoint requires the `tag.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

[**TagResponseDto**](TagResponseDto.md)

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

<a id="tagassets"></a>
# **TagAssets**
> List&lt;BulkIdResponseDto&gt; TagAssets (Guid id, BulkIdsDto bulkIdsDto)



This endpoint requires the `tag.asset` permission.


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

<a id="untagassets"></a>
# **UntagAssets**
> List&lt;BulkIdResponseDto&gt; UntagAssets (Guid id, BulkIdsDto bulkIdsDto)



This endpoint requires the `tag.asset` permission.


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

<a id="updatetag"></a>
# **UpdateTag**
> TagResponseDto UpdateTag (Guid id, TagUpdateDto tagUpdateDto)



This endpoint requires the `tag.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **tagUpdateDto** | [**TagUpdateDto**](TagUpdateDto.md) |  |  |

### Return type

[**TagResponseDto**](TagResponseDto.md)

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

<a id="upserttags"></a>
# **UpsertTags**
> List&lt;TagResponseDto&gt; UpsertTags (TagUpsertDto tagUpsertDto)



This endpoint requires the `tag.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **tagUpsertDto** | [**TagUpsertDto**](TagUpsertDto.md) |  |  |

### Return type

[**List&lt;TagResponseDto&gt;**](TagResponseDto.md)

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

