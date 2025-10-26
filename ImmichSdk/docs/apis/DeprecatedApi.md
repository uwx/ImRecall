# Org.OpenAPITools.Api.DeprecatedApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CreatePartnerDeprecated**](DeprecatedApi.md#createpartnerdeprecated) | **POST** /partners/{id} |  |
| [**GetRandom**](DeprecatedApi.md#getrandom) | **GET** /assets/random |  |
| [**ReplaceAsset**](DeprecatedApi.md#replaceasset) | **PUT** /assets/{id}/original | Replace the asset with new file, without changing its id |

<a id="createpartnerdeprecated"></a>
# **CreatePartnerDeprecated**
> PartnerResponseDto CreatePartnerDeprecated (Guid id)



This property was deprecated in v1.141.0. This endpoint requires the `partner.create` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

[**PartnerResponseDto**](PartnerResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getrandom"></a>
# **GetRandom**
> List&lt;AssetResponseDto&gt; GetRandom (decimal count = null)



This property was deprecated in v1.116.0. This endpoint requires the `asset.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **count** | **decimal** |  | [optional]  |

### Return type

[**List&lt;AssetResponseDto&gt;**](AssetResponseDto.md)

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

<a id="replaceasset"></a>
# **ReplaceAsset**
> AssetMediaResponseDto ReplaceAsset (Guid id, System.IO.Stream assetData, string deviceAssetId, string deviceId, DateTime fileCreatedAt, DateTime fileModifiedAt, string key = null, string slug = null, string duration = null, string filename = null)

Replace the asset with new file, without changing its id

This property was deprecated in v1.142.0. Replace the asset with new file, without changing its id. This endpoint requires the `asset.replace` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **assetData** | **System.IO.Stream****System.IO.Stream** |  |  |
| **deviceAssetId** | **string** |  |  |
| **deviceId** | **string** |  |  |
| **fileCreatedAt** | **DateTime** |  |  |
| **fileModifiedAt** | **DateTime** |  |  |
| **key** | **string** |  | [optional]  |
| **slug** | **string** |  | [optional]  |
| **duration** | **string** |  | [optional]  |
| **filename** | **string** |  | [optional]  |

### Return type

[**AssetMediaResponseDto**](AssetMediaResponseDto.md)

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: multipart/form-data
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

