# Org.OpenAPITools.Api.OAuthApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**FinishOAuth**](OAuthApi.md#finishoauth) | **POST** /oauth/callback |  |
| [**LinkOAuthAccount**](OAuthApi.md#linkoauthaccount) | **POST** /oauth/link |  |
| [**RedirectOAuthToMobile**](OAuthApi.md#redirectoauthtomobile) | **GET** /oauth/mobile-redirect |  |
| [**StartOAuth**](OAuthApi.md#startoauth) | **POST** /oauth/authorize |  |
| [**UnlinkOAuthAccount**](OAuthApi.md#unlinkoauthaccount) | **POST** /oauth/unlink |  |

<a id="finishoauth"></a>
# **FinishOAuth**
> LoginResponseDto FinishOAuth (OAuthCallbackDto oAuthCallbackDto)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **oAuthCallbackDto** | [**OAuthCallbackDto**](OAuthCallbackDto.md) |  |  |

### Return type

[**LoginResponseDto**](LoginResponseDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="linkoauthaccount"></a>
# **LinkOAuthAccount**
> UserAdminResponseDto LinkOAuthAccount (OAuthCallbackDto oAuthCallbackDto)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **oAuthCallbackDto** | [**OAuthCallbackDto**](OAuthCallbackDto.md) |  |  |

### Return type

[**UserAdminResponseDto**](UserAdminResponseDto.md)

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

<a id="redirectoauthtomobile"></a>
# **RedirectOAuthToMobile**
> void RedirectOAuthToMobile ()




### Parameters
This endpoint does not need any parameter.
### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: Not defined


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="startoauth"></a>
# **StartOAuth**
> OAuthAuthorizeResponseDto StartOAuth (OAuthConfigDto oAuthConfigDto)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **oAuthConfigDto** | [**OAuthConfigDto**](OAuthConfigDto.md) |  |  |

### Return type

[**OAuthAuthorizeResponseDto**](OAuthAuthorizeResponseDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="unlinkoauthaccount"></a>
# **UnlinkOAuthAccount**
> UserAdminResponseDto UnlinkOAuthAccount ()




### Parameters
This endpoint does not need any parameter.
### Return type

[**UserAdminResponseDto**](UserAdminResponseDto.md)

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

