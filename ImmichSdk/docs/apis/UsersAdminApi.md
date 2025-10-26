# Org.OpenAPITools.Api.UsersAdminApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateUserAdmin**](UsersAdminApi.md#createuseradmin) | **POST** /admin/users |  |
| [**DeleteUserAdmin**](UsersAdminApi.md#deleteuseradmin) | **DELETE** /admin/users/{id} |  |
| [**GetUserAdmin**](UsersAdminApi.md#getuseradmin) | **GET** /admin/users/{id} |  |
| [**GetUserPreferencesAdmin**](UsersAdminApi.md#getuserpreferencesadmin) | **GET** /admin/users/{id}/preferences |  |
| [**GetUserSessionsAdmin**](UsersAdminApi.md#getusersessionsadmin) | **GET** /admin/users/{id}/sessions |  |
| [**GetUserStatisticsAdmin**](UsersAdminApi.md#getuserstatisticsadmin) | **GET** /admin/users/{id}/statistics |  |
| [**RestoreUserAdmin**](UsersAdminApi.md#restoreuseradmin) | **POST** /admin/users/{id}/restore |  |
| [**SearchUsersAdmin**](UsersAdminApi.md#searchusersadmin) | **GET** /admin/users |  |
| [**UpdateUserAdmin**](UsersAdminApi.md#updateuseradmin) | **PUT** /admin/users/{id} |  |
| [**UpdateUserPreferencesAdmin**](UsersAdminApi.md#updateuserpreferencesadmin) | **PUT** /admin/users/{id}/preferences |  |

<a id="createuseradmin"></a>
# **CreateUserAdmin**
> UserAdminResponseDto CreateUserAdmin (UserAdminCreateDto userAdminCreateDto)



This endpoint is an admin-only route, and requires the `adminUser.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **userAdminCreateDto** | [**UserAdminCreateDto**](UserAdminCreateDto.md) |  |  |

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
| **201** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="deleteuseradmin"></a>
# **DeleteUserAdmin**
> UserAdminResponseDto DeleteUserAdmin (Guid id, UserAdminDeleteDto userAdminDeleteDto)



This endpoint is an admin-only route, and requires the `adminUser.delete` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **userAdminDeleteDto** | [**UserAdminDeleteDto**](UserAdminDeleteDto.md) |  |  |

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

<a id="getuseradmin"></a>
# **GetUserAdmin**
> UserAdminResponseDto GetUserAdmin (Guid id)



This endpoint is an admin-only route, and requires the `adminUser.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

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

<a id="getuserpreferencesadmin"></a>
# **GetUserPreferencesAdmin**
> UserPreferencesResponseDto GetUserPreferencesAdmin (Guid id)



This endpoint is an admin-only route, and requires the `adminUser.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

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

<a id="getusersessionsadmin"></a>
# **GetUserSessionsAdmin**
> List&lt;SessionResponseDto&gt; GetUserSessionsAdmin (Guid id)



This endpoint is an admin-only route, and requires the `adminSession.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

[**List&lt;SessionResponseDto&gt;**](SessionResponseDto.md)

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

<a id="getuserstatisticsadmin"></a>
# **GetUserStatisticsAdmin**
> AssetStatsResponseDto GetUserStatisticsAdmin (Guid id, bool isFavorite = null, bool isTrashed = null, AssetVisibility visibility = null)



This endpoint is an admin-only route, and requires the `adminUser.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **isFavorite** | **bool** |  | [optional]  |
| **isTrashed** | **bool** |  | [optional]  |
| **visibility** | **AssetVisibility** |  | [optional]  |

### Return type

[**AssetStatsResponseDto**](AssetStatsResponseDto.md)

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

<a id="restoreuseradmin"></a>
# **RestoreUserAdmin**
> UserAdminResponseDto RestoreUserAdmin (Guid id)



This endpoint is an admin-only route, and requires the `adminUser.delete` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

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

<a id="searchusersadmin"></a>
# **SearchUsersAdmin**
> List&lt;UserAdminResponseDto&gt; SearchUsersAdmin (Guid id = null, bool withDeleted = null)



This endpoint is an admin-only route, and requires the `adminUser.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  | [optional]  |
| **withDeleted** | **bool** |  | [optional]  |

### Return type

[**List&lt;UserAdminResponseDto&gt;**](UserAdminResponseDto.md)

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

<a id="updateuseradmin"></a>
# **UpdateUserAdmin**
> UserAdminResponseDto UpdateUserAdmin (Guid id, UserAdminUpdateDto userAdminUpdateDto)



This endpoint is an admin-only route, and requires the `adminUser.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **userAdminUpdateDto** | [**UserAdminUpdateDto**](UserAdminUpdateDto.md) |  |  |

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

<a id="updateuserpreferencesadmin"></a>
# **UpdateUserPreferencesAdmin**
> UserPreferencesResponseDto UpdateUserPreferencesAdmin (Guid id, UserPreferencesUpdateDto userPreferencesUpdateDto)



This endpoint is an admin-only route, and requires the `adminUser.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
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

