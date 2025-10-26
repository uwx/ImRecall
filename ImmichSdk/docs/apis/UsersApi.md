# Org.OpenAPITools.Api.UsersApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateProfileImage**](UsersApi.md#createprofileimage) | **POST** /users/profile-image |  |
| [**DeleteProfileImage**](UsersApi.md#deleteprofileimage) | **DELETE** /users/profile-image |  |
| [**DeleteUserLicense**](UsersApi.md#deleteuserlicense) | **DELETE** /users/me/license |  |
| [**DeleteUserOnboarding**](UsersApi.md#deleteuseronboarding) | **DELETE** /users/me/onboarding |  |
| [**GetMyPreferences**](UsersApi.md#getmypreferences) | **GET** /users/me/preferences |  |
| [**GetMyUser**](UsersApi.md#getmyuser) | **GET** /users/me |  |
| [**GetProfileImage**](UsersApi.md#getprofileimage) | **GET** /users/{id}/profile-image |  |
| [**GetUser**](UsersApi.md#getuser) | **GET** /users/{id} |  |
| [**GetUserLicense**](UsersApi.md#getuserlicense) | **GET** /users/me/license |  |
| [**GetUserOnboarding**](UsersApi.md#getuseronboarding) | **GET** /users/me/onboarding |  |
| [**SearchUsers**](UsersApi.md#searchusers) | **GET** /users |  |
| [**SetUserLicense**](UsersApi.md#setuserlicense) | **PUT** /users/me/license |  |
| [**SetUserOnboarding**](UsersApi.md#setuseronboarding) | **PUT** /users/me/onboarding |  |
| [**UpdateMyPreferences**](UsersApi.md#updatemypreferences) | **PUT** /users/me/preferences |  |
| [**UpdateMyUser**](UsersApi.md#updatemyuser) | **PUT** /users/me |  |

<a id="createprofileimage"></a>
# **CreateProfileImage**
> CreateProfileImageResponseDto CreateProfileImage (System.IO.Stream file)



This endpoint requires the `userProfileImage.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **file** | **System.IO.Stream****System.IO.Stream** |  |  |

### Return type

[**CreateProfileImageResponseDto**](CreateProfileImageResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="deleteprofileimage"></a>
# **DeleteProfileImage**
> void DeleteProfileImage ()



This endpoint requires the `userProfileImage.delete` permission.


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

<a id="deleteuserlicense"></a>
# **DeleteUserLicense**
> void DeleteUserLicense ()



This endpoint requires the `userLicense.delete` permission.


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

<a id="deleteuseronboarding"></a>
# **DeleteUserOnboarding**
> void DeleteUserOnboarding ()



This endpoint requires the `userOnboarding.delete` permission.


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

<a id="getmypreferences"></a>
# **GetMyPreferences**
> UserPreferencesResponseDto GetMyPreferences ()



This endpoint requires the `userPreference.read` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**UserPreferencesResponseDto**](UserPreferencesResponseDto.md)

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

<a id="getmyuser"></a>
# **GetMyUser**
> UserAdminResponseDto GetMyUser ()



This endpoint requires the `user.read` permission.


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

<a id="getprofileimage"></a>
# **GetProfileImage**
> System.IO.Stream GetProfileImage (Guid id)



This endpoint requires the `userProfileImage.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

**System.IO.Stream**

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getuser"></a>
# **GetUser**
> UserResponseDto GetUser (Guid id)



This endpoint requires the `user.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

[**UserResponseDto**](UserResponseDto.md)

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

<a id="getuserlicense"></a>
# **GetUserLicense**
> LicenseResponseDto GetUserLicense ()



This endpoint requires the `userLicense.read` permission.


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

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getuseronboarding"></a>
# **GetUserOnboarding**
> OnboardingResponseDto GetUserOnboarding ()



This endpoint requires the `userOnboarding.read` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**OnboardingResponseDto**](OnboardingResponseDto.md)

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

<a id="searchusers"></a>
# **SearchUsers**
> List&lt;UserResponseDto&gt; SearchUsers ()



This endpoint requires the `user.read` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;UserResponseDto&gt;**](UserResponseDto.md)

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

<a id="setuserlicense"></a>
# **SetUserLicense**
> LicenseResponseDto SetUserLicense (LicenseKeyDto licenseKeyDto)



This endpoint requires the `userLicense.update` permission.


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

<a id="setuseronboarding"></a>
# **SetUserOnboarding**
> OnboardingResponseDto SetUserOnboarding (OnboardingDto onboardingDto)



This endpoint requires the `userOnboarding.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **onboardingDto** | [**OnboardingDto**](OnboardingDto.md) |  |  |

### Return type

[**OnboardingResponseDto**](OnboardingResponseDto.md)

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

<a id="updatemypreferences"></a>
# **UpdateMyPreferences**
> UserPreferencesResponseDto UpdateMyPreferences (UserPreferencesUpdateDto userPreferencesUpdateDto)



This endpoint requires the `userPreference.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **userPreferencesUpdateDto** | [**UserPreferencesUpdateDto**](UserPreferencesUpdateDto.md) |  |  |

### Return type

[**UserPreferencesResponseDto**](UserPreferencesResponseDto.md)

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

<a id="updatemyuser"></a>
# **UpdateMyUser**
> UserAdminResponseDto UpdateMyUser (UserUpdateMeDto userUpdateMeDto)



This endpoint requires the `user.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **userUpdateMeDto** | [**UserUpdateMeDto**](UserUpdateMeDto.md) |  |  |

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

