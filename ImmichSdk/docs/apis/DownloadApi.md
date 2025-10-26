# Org.OpenAPITools.Api.DownloadApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DownloadArchive**](DownloadApi.md#downloadarchive) | **POST** /download/archive |  |
| [**GetDownloadInfo**](DownloadApi.md#getdownloadinfo) | **POST** /download/info |  |

<a id="downloadarchive"></a>
# **DownloadArchive**
> System.IO.Stream DownloadArchive (AssetIdsDto assetIdsDto, string key = null, string slug = null)



This endpoint requires the `asset.download` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **assetIdsDto** | [**AssetIdsDto**](AssetIdsDto.md) |  |  |
| **key** | **string** |  | [optional]  |
| **slug** | **string** |  | [optional]  |

### Return type

**System.IO.Stream**

### Authorization

[cookie](../README.md#cookie), [api_key](../README.md#api_key), [bearer](../README.md#bearer)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/octet-stream


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="getdownloadinfo"></a>
# **GetDownloadInfo**
> DownloadResponseDto GetDownloadInfo (DownloadInfoDto downloadInfoDto, string key = null, string slug = null)



This endpoint requires the `asset.download` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **downloadInfoDto** | [**DownloadInfoDto**](DownloadInfoDto.md) |  |  |
| **key** | **string** |  | [optional]  |
| **slug** | **string** |  | [optional]  |

### Return type

[**DownloadResponseDto**](DownloadResponseDto.md)

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

