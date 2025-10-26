# Org.OpenAPITools.Api.MapApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetMapMarkers**](MapApi.md#getmapmarkers) | **GET** /map/markers |  |
| [**ReverseGeocode**](MapApi.md#reversegeocode) | **GET** /map/reverse-geocode |  |

<a id="getmapmarkers"></a>
# **GetMapMarkers**
> List&lt;MapMarkerResponseDto&gt; GetMapMarkers (bool isArchived = null, bool isFavorite = null, DateTime fileCreatedAfter = null, DateTime fileCreatedBefore = null, bool withPartners = null, bool withSharedAlbums = null)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **isArchived** | **bool** |  | [optional]  |
| **isFavorite** | **bool** |  | [optional]  |
| **fileCreatedAfter** | **DateTime** |  | [optional]  |
| **fileCreatedBefore** | **DateTime** |  | [optional]  |
| **withPartners** | **bool** |  | [optional]  |
| **withSharedAlbums** | **bool** |  | [optional]  |

### Return type

[**List&lt;MapMarkerResponseDto&gt;**](MapMarkerResponseDto.md)

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

<a id="reversegeocode"></a>
# **ReverseGeocode**
> List&lt;MapReverseGeocodeResponseDto&gt; ReverseGeocode (double lat, double lon)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **lat** | **double** |  |  |
| **lon** | **double** |  |  |

### Return type

[**List&lt;MapReverseGeocodeResponseDto&gt;**](MapReverseGeocodeResponseDto.md)

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

