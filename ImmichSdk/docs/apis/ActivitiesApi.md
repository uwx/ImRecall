# Org.OpenAPITools.Api.ActivitiesApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateActivity**](ActivitiesApi.md#createactivity) | **POST** /activities |  |
| [**DeleteActivity**](ActivitiesApi.md#deleteactivity) | **DELETE** /activities/{id} |  |
| [**GetActivities**](ActivitiesApi.md#getactivities) | **GET** /activities |  |
| [**GetActivityStatistics**](ActivitiesApi.md#getactivitystatistics) | **GET** /activities/statistics |  |

<a id="createactivity"></a>
# **CreateActivity**
> ActivityResponseDto CreateActivity (ActivityCreateDto activityCreateDto)



This endpoint requires the `activity.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **activityCreateDto** | [**ActivityCreateDto**](ActivityCreateDto.md) |  |  |

### Return type

[**ActivityResponseDto**](ActivityResponseDto.md)

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

<a id="deleteactivity"></a>
# **DeleteActivity**
> void DeleteActivity (Guid id)



This endpoint requires the `activity.delete` permission.


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

<a id="getactivities"></a>
# **GetActivities**
> List&lt;ActivityResponseDto&gt; GetActivities (Guid albumId, Guid assetId = null, ReactionLevel level = null, ReactionType type = null, Guid userId = null)



This endpoint requires the `activity.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **albumId** | **Guid** |  |  |
| **assetId** | **Guid** |  | [optional]  |
| **level** | **ReactionLevel** |  | [optional]  |
| **type** | **ReactionType** |  | [optional]  |
| **userId** | **Guid** |  | [optional]  |

### Return type

[**List&lt;ActivityResponseDto&gt;**](ActivityResponseDto.md)

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

<a id="getactivitystatistics"></a>
# **GetActivityStatistics**
> ActivityStatisticsResponseDto GetActivityStatistics (Guid albumId, Guid assetId = null)



This endpoint requires the `activity.statistics` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **albumId** | **Guid** |  |  |
| **assetId** | **Guid** |  | [optional]  |

### Return type

[**ActivityStatisticsResponseDto**](ActivityStatisticsResponseDto.md)

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

