# Org.OpenAPITools.Api.ViewApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetAssetsByOriginalPath**](ViewApi.md#getassetsbyoriginalpath) | **GET** /view/folder |  |
| [**GetUniqueOriginalPaths**](ViewApi.md#getuniqueoriginalpaths) | **GET** /view/folder/unique-paths |  |

<a id="getassetsbyoriginalpath"></a>
# **GetAssetsByOriginalPath**
> List&lt;AssetResponseDto&gt; GetAssetsByOriginalPath (string path)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **path** | **string** |  |  |

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

<a id="getuniqueoriginalpaths"></a>
# **GetUniqueOriginalPaths**
> List&lt;string&gt; GetUniqueOriginalPaths ()




### Parameters
This endpoint does not need any parameter.
### Return type

**List<string>**

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

