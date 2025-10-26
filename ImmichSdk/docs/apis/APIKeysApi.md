# Org.OpenAPITools.Api.APIKeysApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateApiKey**](APIKeysApi.md#createapikey) | **POST** /api-keys |  |
| [**DeleteApiKey**](APIKeysApi.md#deleteapikey) | **DELETE** /api-keys/{id} |  |
| [**GetApiKey**](APIKeysApi.md#getapikey) | **GET** /api-keys/{id} |  |
| [**GetApiKeys**](APIKeysApi.md#getapikeys) | **GET** /api-keys |  |
| [**GetMyApiKey**](APIKeysApi.md#getmyapikey) | **GET** /api-keys/me |  |
| [**UpdateApiKey**](APIKeysApi.md#updateapikey) | **PUT** /api-keys/{id} |  |

<a id="createapikey"></a>
# **CreateApiKey**
> APIKeyCreateResponseDto CreateApiKey (APIKeyCreateDto aPIKeyCreateDto)



This endpoint requires the `apiKey.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **aPIKeyCreateDto** | [**APIKeyCreateDto**](APIKeyCreateDto.md) |  |  |

### Return type

[**APIKeyCreateResponseDto**](APIKeyCreateResponseDto.md)

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

<a id="deleteapikey"></a>
# **DeleteApiKey**
> void DeleteApiKey (Guid id)



This endpoint requires the `apiKey.delete` permission.


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

<a id="getapikey"></a>
# **GetApiKey**
> APIKeyResponseDto GetApiKey (Guid id)



This endpoint requires the `apiKey.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

[**APIKeyResponseDto**](APIKeyResponseDto.md)

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

<a id="getapikeys"></a>
# **GetApiKeys**
> List&lt;APIKeyResponseDto&gt; GetApiKeys ()



This endpoint requires the `apiKey.read` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;APIKeyResponseDto&gt;**](APIKeyResponseDto.md)

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

<a id="getmyapikey"></a>
# **GetMyApiKey**
> APIKeyResponseDto GetMyApiKey ()




### Parameters
This endpoint does not need any parameter.
### Return type

[**APIKeyResponseDto**](APIKeyResponseDto.md)

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

<a id="updateapikey"></a>
# **UpdateApiKey**
> APIKeyResponseDto UpdateApiKey (Guid id, APIKeyUpdateDto aPIKeyUpdateDto)



This endpoint requires the `apiKey.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **aPIKeyUpdateDto** | [**APIKeyUpdateDto**](APIKeyUpdateDto.md) |  |  |

### Return type

[**APIKeyResponseDto**](APIKeyResponseDto.md)

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

