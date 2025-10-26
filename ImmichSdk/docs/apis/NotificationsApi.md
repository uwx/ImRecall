# Org.OpenAPITools.Api.NotificationsApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeleteNotification**](NotificationsApi.md#deletenotification) | **DELETE** /notifications/{id} |  |
| [**DeleteNotifications**](NotificationsApi.md#deletenotifications) | **DELETE** /notifications |  |
| [**GetNotification**](NotificationsApi.md#getnotification) | **GET** /notifications/{id} |  |
| [**GetNotifications**](NotificationsApi.md#getnotifications) | **GET** /notifications |  |
| [**UpdateNotification**](NotificationsApi.md#updatenotification) | **PUT** /notifications/{id} |  |
| [**UpdateNotifications**](NotificationsApi.md#updatenotifications) | **PUT** /notifications |  |

<a id="deletenotification"></a>
# **DeleteNotification**
> void DeleteNotification (Guid id)



This endpoint requires the `notification.delete` permission.


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

<a id="deletenotifications"></a>
# **DeleteNotifications**
> void DeleteNotifications (NotificationDeleteAllDto notificationDeleteAllDto)



This endpoint requires the `notification.delete` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **notificationDeleteAllDto** | [**NotificationDeleteAllDto**](NotificationDeleteAllDto.md) |  |  |

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

<a id="getnotification"></a>
# **GetNotification**
> NotificationDto GetNotification (Guid id)



This endpoint requires the `notification.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

[**NotificationDto**](NotificationDto.md)

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

<a id="getnotifications"></a>
# **GetNotifications**
> List&lt;NotificationDto&gt; GetNotifications (Guid id = null, NotificationLevel level = null, NotificationType type = null, bool unread = null)



This endpoint requires the `notification.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  | [optional]  |
| **level** | **NotificationLevel** |  | [optional]  |
| **type** | **NotificationType** |  | [optional]  |
| **unread** | **bool** |  | [optional]  |

### Return type

[**List&lt;NotificationDto&gt;**](NotificationDto.md)

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

<a id="updatenotification"></a>
# **UpdateNotification**
> NotificationDto UpdateNotification (Guid id, NotificationUpdateDto notificationUpdateDto)



This endpoint requires the `notification.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **notificationUpdateDto** | [**NotificationUpdateDto**](NotificationUpdateDto.md) |  |  |

### Return type

[**NotificationDto**](NotificationDto.md)

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

<a id="updatenotifications"></a>
# **UpdateNotifications**
> void UpdateNotifications (NotificationUpdateAllDto notificationUpdateAllDto)



This endpoint requires the `notification.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **notificationUpdateAllDto** | [**NotificationUpdateAllDto**](NotificationUpdateAllDto.md) |  |  |

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

