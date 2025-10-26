# Org.OpenAPITools.Api.ServerApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeleteServerLicense**](ServerApi.md#deleteserverlicense) | **DELETE** /server/license |  |
| [**GetAboutInfo**](ServerApi.md#getaboutinfo) | **GET** /server/about |  |
| [**GetApkLinks**](ServerApi.md#getapklinks) | **GET** /server/apk-links |  |
| [**GetServerConfig**](ServerApi.md#getserverconfig) | **GET** /server/config |  |
| [**GetServerFeatures**](ServerApi.md#getserverfeatures) | **GET** /server/features |  |
| [**GetServerLicense**](ServerApi.md#getserverlicense) | **GET** /server/license |  |
| [**GetServerStatistics**](ServerApi.md#getserverstatistics) | **GET** /server/statistics |  |
| [**GetServerVersion**](ServerApi.md#getserverversion) | **GET** /server/version |  |
| [**GetStorage**](ServerApi.md#getstorage) | **GET** /server/storage |  |
| [**GetSupportedMediaTypes**](ServerApi.md#getsupportedmediatypes) | **GET** /server/media-types |  |
| [**GetTheme**](ServerApi.md#gettheme) | **GET** /server/theme |  |
| [**GetVersionCheck**](ServerApi.md#getversioncheck) | **GET** /server/version-check |  |
| [**GetVersionHistory**](ServerApi.md#getversionhistory) | **GET** /server/version-history |  |
| [**PingServer**](ServerApi.md#pingserver) | **GET** /server/ping |  |
| [**SetServerLicense**](ServerApi.md#setserverlicense) | **PUT** /server/license |  |

<a id="deleteserverlicense"></a>
# **DeleteServerLicense**
> void DeleteServerLicense ()



This endpoint is an admin-only route, and requires the `serverLicense.delete` permission.


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

<a id="getaboutinfo"></a>
# **GetAboutInfo**
> ServerAboutResponseDto GetAboutInfo ()



This endpoint requires the `server.about` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**ServerAboutResponseDto**](ServerAboutResponseDto.md)

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

<a id="getapklinks"></a>
# **GetApkLinks**
> ServerApkLinksDto GetApkLinks ()



This endpoint requires the `server.apkLinks` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**ServerApkLinksDto**](ServerApkLinksDto.md)

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

<a id="getserverconfig"></a>
# **GetServerConfig**
> ServerConfigDto GetServerConfig ()




### Parameters
This endpoint does not need any parameter.
### Return type

[**ServerConfigDto**](ServerConfigDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getserverfeatures"></a>
# **GetServerFeatures**
> ServerFeaturesDto GetServerFeatures ()




### Parameters
This endpoint does not need any parameter.
### Return type

[**ServerFeaturesDto**](ServerFeaturesDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getserverlicense"></a>
# **GetServerLicense**
> LicenseResponseDto GetServerLicense ()



This endpoint is an admin-only route, and requires the `serverLicense.read` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**LicenseResponseDto**](LicenseResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |
| **404** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getserverstatistics"></a>
# **GetServerStatistics**
> ServerStatsResponseDto GetServerStatistics ()



This endpoint is an admin-only route, and requires the `server.statistics` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**ServerStatsResponseDto**](ServerStatsResponseDto.md)

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

<a id="getserverversion"></a>
# **GetServerVersion**
> ServerVersionResponseDto GetServerVersion ()




### Parameters
This endpoint does not need any parameter.
### Return type

[**ServerVersionResponseDto**](ServerVersionResponseDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getstorage"></a>
# **GetStorage**
> ServerStorageResponseDto GetStorage ()



This endpoint requires the `server.storage` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**ServerStorageResponseDto**](ServerStorageResponseDto.md)

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

<a id="getsupportedmediatypes"></a>
# **GetSupportedMediaTypes**
> ServerMediaTypesResponseDto GetSupportedMediaTypes ()




### Parameters
This endpoint does not need any parameter.
### Return type

[**ServerMediaTypesResponseDto**](ServerMediaTypesResponseDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="gettheme"></a>
# **GetTheme**
> ServerThemeDto GetTheme ()




### Parameters
This endpoint does not need any parameter.
### Return type

[**ServerThemeDto**](ServerThemeDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getversioncheck"></a>
# **GetVersionCheck**
> VersionCheckStateResponseDto GetVersionCheck ()



This endpoint requires the `server.versionCheck` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**VersionCheckStateResponseDto**](VersionCheckStateResponseDto.md)

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

<a id="getversionhistory"></a>
# **GetVersionHistory**
> List&lt;ServerVersionHistoryResponseDto&gt; GetVersionHistory ()




### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;ServerVersionHistoryResponseDto&gt;**](ServerVersionHistoryResponseDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="pingserver"></a>
# **PingServer**
> ServerPingResponse PingServer ()




### Parameters
This endpoint does not need any parameter.
### Return type

[**ServerPingResponse**](ServerPingResponse.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="setserverlicense"></a>
# **SetServerLicense**
> LicenseResponseDto SetServerLicense (LicenseKeyDto licenseKeyDto)



This endpoint is an admin-only route, and requires the `serverLicense.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **licenseKeyDto** | [**LicenseKeyDto**](LicenseKeyDto.md) |  |  |

### Return type

[**LicenseResponseDto**](LicenseResponseDto.md)

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

