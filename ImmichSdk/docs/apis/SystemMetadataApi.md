# Org.OpenAPITools.Api.SystemMetadataApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetAdminOnboarding**](SystemMetadataApi.md#getadminonboarding) | **GET** /system-metadata/admin-onboarding |  |
| [**GetReverseGeocodingState**](SystemMetadataApi.md#getreversegeocodingstate) | **GET** /system-metadata/reverse-geocoding-state |  |
| [**GetVersionCheckState**](SystemMetadataApi.md#getversioncheckstate) | **GET** /system-metadata/version-check-state |  |
| [**UpdateAdminOnboarding**](SystemMetadataApi.md#updateadminonboarding) | **POST** /system-metadata/admin-onboarding |  |

<a id="getadminonboarding"></a>
# **GetAdminOnboarding**
> AdminOnboardingUpdateDto GetAdminOnboarding ()



This endpoint is an admin-only route, and requires the `systemMetadata.read` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**AdminOnboardingUpdateDto**](AdminOnboardingUpdateDto.md)

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

<a id="getreversegeocodingstate"></a>
# **GetReverseGeocodingState**
> ReverseGeocodingStateResponseDto GetReverseGeocodingState ()



This endpoint is an admin-only route, and requires the `systemMetadata.read` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**ReverseGeocodingStateResponseDto**](ReverseGeocodingStateResponseDto.md)

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

<a id="getversioncheckstate"></a>
# **GetVersionCheckState**
> VersionCheckStateResponseDto GetVersionCheckState ()



This endpoint is an admin-only route, and requires the `systemMetadata.read` permission.


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

<a id="updateadminonboarding"></a>
# **UpdateAdminOnboarding**
> void UpdateAdminOnboarding (AdminOnboardingUpdateDto adminOnboardingUpdateDto)



This endpoint is an admin-only route, and requires the `systemMetadata.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **adminOnboardingUpdateDto** | [**AdminOnboardingUpdateDto**](AdminOnboardingUpdateDto.md) |  |  |

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

