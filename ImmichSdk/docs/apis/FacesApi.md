# Org.OpenAPITools.Api.FacesApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreateFace**](FacesApi.md#createface) | **POST** /faces |  |
| [**DeleteFace**](FacesApi.md#deleteface) | **DELETE** /faces/{id} |  |
| [**GetFaces**](FacesApi.md#getfaces) | **GET** /faces |  |
| [**ReassignFacesById**](FacesApi.md#reassignfacesbyid) | **PUT** /faces/{id} |  |

<a id="createface"></a>
# **CreateFace**
> void CreateFace (AssetFaceCreateDto assetFaceCreateDto)



This endpoint requires the `face.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **assetFaceCreateDto** | [**AssetFaceCreateDto**](AssetFaceCreateDto.md) |  |  |

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
| **201** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="deleteface"></a>
# **DeleteFace**
> void DeleteFace (Guid id, AssetFaceDeleteDto assetFaceDeleteDto)



This endpoint requires the `face.delete` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **assetFaceDeleteDto** | [**AssetFaceDeleteDto**](AssetFaceDeleteDto.md) |  |  |

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

<a id="getfaces"></a>
# **GetFaces**
> List&lt;AssetFaceResponseDto&gt; GetFaces (Guid id)



This endpoint requires the `face.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

[**List&lt;AssetFaceResponseDto&gt;**](AssetFaceResponseDto.md)

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

<a id="reassignfacesbyid"></a>
# **ReassignFacesById**
> PersonResponseDto ReassignFacesById (Guid id, FaceDto faceDto)



This endpoint requires the `face.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **faceDto** | [**FaceDto**](FaceDto.md) |  |  |

### Return type

[**PersonResponseDto**](PersonResponseDto.md)

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

