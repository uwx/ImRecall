# Org.OpenAPITools.Api.AuthenticationApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**ChangePassword**](AuthenticationApi.md#changepassword) | **POST** /auth/change-password |  |
| [**ChangePinCode**](AuthenticationApi.md#changepincode) | **PUT** /auth/pin-code |  |
| [**GetAuthStatus**](AuthenticationApi.md#getauthstatus) | **GET** /auth/status |  |
| [**LockAuthSession**](AuthenticationApi.md#lockauthsession) | **POST** /auth/session/lock |  |
| [**Login**](AuthenticationApi.md#login) | **POST** /auth/login |  |
| [**Logout**](AuthenticationApi.md#logout) | **POST** /auth/logout |  |
| [**ResetPinCode**](AuthenticationApi.md#resetpincode) | **DELETE** /auth/pin-code |  |
| [**SetupPinCode**](AuthenticationApi.md#setuppincode) | **POST** /auth/pin-code |  |
| [**SignUpAdmin**](AuthenticationApi.md#signupadmin) | **POST** /auth/admin-sign-up |  |
| [**UnlockAuthSession**](AuthenticationApi.md#unlockauthsession) | **POST** /auth/session/unlock |  |
| [**ValidateAccessToken**](AuthenticationApi.md#validateaccesstoken) | **POST** /auth/validateToken |  |

<a id="changepassword"></a>
# **ChangePassword**
> UserAdminResponseDto ChangePassword (ChangePasswordDto changePasswordDto)



This endpoint requires the `auth.changePassword` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **changePasswordDto** | [**ChangePasswordDto**](ChangePasswordDto.md) |  |  |

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

<a id="changepincode"></a>
# **ChangePinCode**
> void ChangePinCode (PinCodeChangeDto pinCodeChangeDto)



This endpoint requires the `pinCode.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **pinCodeChangeDto** | [**PinCodeChangeDto**](PinCodeChangeDto.md) |  |  |

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

<a id="getauthstatus"></a>
# **GetAuthStatus**
> AuthStatusResponseDto GetAuthStatus ()




### Parameters
This endpoint does not need any parameter.
### Return type

[**AuthStatusResponseDto**](AuthStatusResponseDto.md)

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

<a id="lockauthsession"></a>
# **LockAuthSession**
> void LockAuthSession ()




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

<a id="login"></a>
# **Login**
> LoginResponseDto Login (LoginCredentialDto loginCredentialDto)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **loginCredentialDto** | [**LoginCredentialDto**](LoginCredentialDto.md) |  |  |

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

<a id="logout"></a>
# **Logout**
> LogoutResponseDto Logout ()




### Parameters
This endpoint does not need any parameter.
### Return type

[**LogoutResponseDto**](LogoutResponseDto.md)

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

<a id="resetpincode"></a>
# **ResetPinCode**
> void ResetPinCode (PinCodeResetDto pinCodeResetDto)



This endpoint requires the `pinCode.delete` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **pinCodeResetDto** | [**PinCodeResetDto**](PinCodeResetDto.md) |  |  |

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

<a id="setuppincode"></a>
# **SetupPinCode**
> void SetupPinCode (PinCodeSetupDto pinCodeSetupDto)



This endpoint requires the `pinCode.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **pinCodeSetupDto** | [**PinCodeSetupDto**](PinCodeSetupDto.md) |  |  |

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

<a id="signupadmin"></a>
# **SignUpAdmin**
> UserAdminResponseDto SignUpAdmin (SignUpDto signUpDto)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **signUpDto** | [**SignUpDto**](SignUpDto.md) |  |  |

### Return type

[**UserAdminResponseDto**](UserAdminResponseDto.md)

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

<a id="unlockauthsession"></a>
# **UnlockAuthSession**
> void UnlockAuthSession (SessionUnlockDto sessionUnlockDto)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **sessionUnlockDto** | [**SessionUnlockDto**](SessionUnlockDto.md) |  |  |

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

<a id="validateaccesstoken"></a>
# **ValidateAccessToken**
> ValidateAccessTokenResponseDto ValidateAccessToken ()




### Parameters
This endpoint does not need any parameter.
### Return type

[**ValidateAccessTokenResponseDto**](ValidateAccessTokenResponseDto.md)

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

