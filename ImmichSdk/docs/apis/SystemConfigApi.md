# Org.OpenAPITools.Api.SystemConfigApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetConfig**](SystemConfigApi.md#getconfig) | **GET** /system-config |  |
| [**GetConfigDefaults**](SystemConfigApi.md#getconfigdefaults) | **GET** /system-config/defaults |  |
| [**GetStorageTemplateOptions**](SystemConfigApi.md#getstoragetemplateoptions) | **GET** /system-config/storage-template-options |  |
| [**UpdateConfig**](SystemConfigApi.md#updateconfig) | **PUT** /system-config |  |

<a id="getconfig"></a>
# **GetConfig**
> SystemConfigDto GetConfig ()



This endpoint is an admin-only route, and requires the `systemConfig.read` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**SystemConfigDto**](SystemConfigDto.md)

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

<a id="getconfigdefaults"></a>
# **GetConfigDefaults**
> SystemConfigDto GetConfigDefaults ()



This endpoint is an admin-only route, and requires the `systemConfig.read` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**SystemConfigDto**](SystemConfigDto.md)

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

<a id="getstoragetemplateoptions"></a>
# **GetStorageTemplateOptions**
> SystemConfigTemplateStorageOptionDto GetStorageTemplateOptions ()



This endpoint is an admin-only route, and requires the `systemConfig.read` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**SystemConfigTemplateStorageOptionDto**](SystemConfigTemplateStorageOptionDto.md)

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

<a id="updateconfig"></a>
# **UpdateConfig**
> SystemConfigDto UpdateConfig (SystemConfigDto systemConfigDto)



This endpoint is an admin-only route, and requires the `systemConfig.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **systemConfigDto** | [**SystemConfigDto**](SystemConfigDto.md) |  |  |

### Return type

[**SystemConfigDto**](SystemConfigDto.md)

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

