# Org.OpenAPITools.Api.SessionsApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateSession**](SessionsApi.md#createsession) | **POST** /sessions |  |
| [**DeleteAllSessions**](SessionsApi.md#deleteallsessions) | **DELETE** /sessions |  |
| [**DeleteSession**](SessionsApi.md#deletesession) | **DELETE** /sessions/{id} |  |
| [**GetSessions**](SessionsApi.md#getsessions) | **GET** /sessions |  |
| [**LockSession**](SessionsApi.md#locksession) | **POST** /sessions/{id}/lock |  |
| [**UpdateSession**](SessionsApi.md#updatesession) | **PUT** /sessions/{id} |  |

<a id="createsession"></a>
# **CreateSession**
> SessionCreateResponseDto CreateSession (SessionCreateDto sessionCreateDto)



This endpoint requires the `session.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **sessionCreateDto** | [**SessionCreateDto**](SessionCreateDto.md) |  |  |

### Return type

[**SessionCreateResponseDto**](SessionCreateResponseDto.md)

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

<a id="deleteallsessions"></a>
# **DeleteAllSessions**
> void DeleteAllSessions ()



This endpoint requires the `session.delete` permission.


### Parameters
This endpoint does not need any parameter.
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

<a id="deletesession"></a>
# **DeleteSession**
> void DeleteSession (Guid id)



This endpoint requires the `session.delete` permission.


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

<a id="getsessions"></a>
# **GetSessions**
> List&lt;SessionResponseDto&gt; GetSessions ()



This endpoint requires the `session.read` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;SessionResponseDto&gt;**](SessionResponseDto.md)

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

<a id="locksession"></a>
# **LockSession**
> void LockSession (Guid id)



This endpoint requires the `session.lock` permission.


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

<a id="updatesession"></a>
# **UpdateSession**
> SessionResponseDto UpdateSession (Guid id, SessionUpdateDto sessionUpdateDto)



This endpoint requires the `session.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **sessionUpdateDto** | [**SessionUpdateDto**](SessionUpdateDto.md) |  |  |

### Return type

[**SessionResponseDto**](SessionResponseDto.md)

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

