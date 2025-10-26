# Org.OpenAPITools.Api.NotificationsAdminApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateNotification**](NotificationsAdminApi.md#createnotification) | **POST** /admin/notifications |  |
| [**GetNotificationTemplateAdmin**](NotificationsAdminApi.md#getnotificationtemplateadmin) | **POST** /admin/notifications/templates/{name} |  |
| [**SendTestEmailAdmin**](NotificationsAdminApi.md#sendtestemailadmin) | **POST** /admin/notifications/test-email |  |

<a id="createnotification"></a>
# **CreateNotification**
> NotificationDto CreateNotification (NotificationCreateDto notificationCreateDto)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **notificationCreateDto** | [**NotificationCreateDto**](NotificationCreateDto.md) |  |  |

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
| **201** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getnotificationtemplateadmin"></a>
# **GetNotificationTemplateAdmin**
> TemplateResponseDto GetNotificationTemplateAdmin (string name, TemplateDto templateDto)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **name** | **string** |  |  |
| **templateDto** | [**TemplateDto**](TemplateDto.md) |  |  |

### Return type

[**TemplateResponseDto**](TemplateResponseDto.md)

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

<a id="sendtestemailadmin"></a>
# **SendTestEmailAdmin**
> TestEmailResponseDto SendTestEmailAdmin (SystemConfigSmtpDto systemConfigSmtpDto)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **systemConfigSmtpDto** | [**SystemConfigSmtpDto**](SystemConfigSmtpDto.md) |  |  |

### Return type

[**TestEmailResponseDto**](TestEmailResponseDto.md)

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

