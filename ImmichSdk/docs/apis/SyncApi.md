# Org.OpenAPITools.Api.SyncApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeleteSyncAck**](SyncApi.md#deletesyncack) | **DELETE** /sync/ack |  |
| [**GetDeltaSync**](SyncApi.md#getdeltasync) | **POST** /sync/delta-sync |  |
| [**GetFullSyncForUser**](SyncApi.md#getfullsyncforuser) | **POST** /sync/full-sync |  |
| [**GetSyncAck**](SyncApi.md#getsyncack) | **GET** /sync/ack |  |
| [**GetSyncStream**](SyncApi.md#getsyncstream) | **POST** /sync/stream |  |
| [**SendSyncAck**](SyncApi.md#sendsyncack) | **POST** /sync/ack |  |

<a id="deletesyncack"></a>
# **DeleteSyncAck**
> void DeleteSyncAck (SyncAckDeleteDto syncAckDeleteDto)



This endpoint requires the `syncCheckpoint.delete` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **syncAckDeleteDto** | [**SyncAckDeleteDto**](SyncAckDeleteDto.md) |  |  |

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

<a id="getdeltasync"></a>
# **GetDeltaSync**
> AssetDeltaSyncResponseDto GetDeltaSync (AssetDeltaSyncDto assetDeltaSyncDto)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **assetDeltaSyncDto** | [**AssetDeltaSyncDto**](AssetDeltaSyncDto.md) |  |  |

### Return type

[**AssetDeltaSyncResponseDto**](AssetDeltaSyncResponseDto.md)

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

<a id="getfullsyncforuser"></a>
# **GetFullSyncForUser**
> List&lt;AssetResponseDto&gt; GetFullSyncForUser (AssetFullSyncDto assetFullSyncDto)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **assetFullSyncDto** | [**AssetFullSyncDto**](AssetFullSyncDto.md) |  |  |

### Return type

[**List&lt;AssetResponseDto&gt;**](AssetResponseDto.md)

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

<a id="getsyncack"></a>
# **GetSyncAck**
> List&lt;SyncAckDto&gt; GetSyncAck ()



This endpoint requires the `syncCheckpoint.read` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;SyncAckDto&gt;**](SyncAckDto.md)

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

<a id="getsyncstream"></a>
# **GetSyncStream**
> void GetSyncStream (SyncStreamDto syncStreamDto)



This endpoint requires the `sync.stream` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **syncStreamDto** | [**SyncStreamDto**](SyncStreamDto.md) |  |  |

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
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="sendsyncack"></a>
# **SendSyncAck**
> void SendSyncAck (SyncAckSetDto syncAckSetDto)



This endpoint requires the `syncCheckpoint.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **syncAckSetDto** | [**SyncAckSetDto**](SyncAckSetDto.md) |  |  |

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

