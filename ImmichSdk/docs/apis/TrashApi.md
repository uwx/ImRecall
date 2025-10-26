# Org.OpenAPITools.Api.TrashApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**EmptyTrash**](TrashApi.md#emptytrash) | **POST** /trash/empty |  |
| [**RestoreAssets**](TrashApi.md#restoreassets) | **POST** /trash/restore/assets |  |
| [**RestoreTrash**](TrashApi.md#restoretrash) | **POST** /trash/restore |  |

<a id="emptytrash"></a>
# **EmptyTrash**
> TrashResponseDto EmptyTrash ()



This endpoint requires the `asset.delete` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**TrashResponseDto**](TrashResponseDto.md)

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

<a id="restoreassets"></a>
# **RestoreAssets**
> TrashResponseDto RestoreAssets (BulkIdsDto bulkIdsDto)



This endpoint requires the `asset.delete` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **bulkIdsDto** | [**BulkIdsDto**](BulkIdsDto.md) |  |  |

### Return type

[**TrashResponseDto**](TrashResponseDto.md)

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

<a id="restoretrash"></a>
# **RestoreTrash**
> TrashResponseDto RestoreTrash ()



This endpoint requires the `asset.delete` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**TrashResponseDto**](TrashResponseDto.md)

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

