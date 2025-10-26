# Org.OpenAPITools.Api.TimelineApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetTimeBucket**](TimelineApi.md#gettimebucket) | **GET** /timeline/bucket |  |
| [**GetTimeBuckets**](TimelineApi.md#gettimebuckets) | **GET** /timeline/buckets |  |

<a id="gettimebucket"></a>
# **GetTimeBucket**
> TimeBucketAssetResponseDto GetTimeBucket (string timeBucket, Guid albumId = null, bool isFavorite = null, bool isTrashed = null, string key = null, AssetOrder order = null, Guid personId = null, string slug = null, Guid tagId = null, Guid userId = null, AssetVisibility visibility = null, bool withCoordinates = null, bool withPartners = null, bool withStacked = null)



This endpoint requires the `asset.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **timeBucket** | **string** | Time bucket identifier in YYYY-MM-DD format (e.g., \&quot;2024-01-01\&quot; for January 2024) |  |
| **albumId** | **Guid** | Filter assets belonging to a specific album | [optional]  |
| **isFavorite** | **bool** | Filter by favorite status (true for favorites only, false for non-favorites only) | [optional]  |
| **isTrashed** | **bool** | Filter by trash status (true for trashed assets only, false for non-trashed only) | [optional]  |
| **key** | **string** |  | [optional]  |
| **order** | **AssetOrder** | Sort order for assets within time buckets (ASC for oldest first, DESC for newest first) | [optional]  |
| **personId** | **Guid** | Filter assets containing a specific person (face recognition) | [optional]  |
| **slug** | **string** |  | [optional]  |
| **tagId** | **Guid** | Filter assets with a specific tag | [optional]  |
| **userId** | **Guid** | Filter assets by specific user ID | [optional]  |
| **visibility** | **AssetVisibility** | Filter by asset visibility status (ARCHIVE, TIMELINE, HIDDEN, LOCKED) | [optional]  |
| **withCoordinates** | **bool** | Include location data in the response | [optional]  |
| **withPartners** | **bool** | Include assets shared by partners | [optional]  |
| **withStacked** | **bool** | Include stacked assets in the response. When true, only primary assets from stacks are returned. | [optional]  |

### Return type

[**TimeBucketAssetResponseDto**](TimeBucketAssetResponseDto.md)

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

<a id="gettimebuckets"></a>
# **GetTimeBuckets**
> List&lt;TimeBucketsResponseDto&gt; GetTimeBuckets (Guid albumId = null, bool isFavorite = null, bool isTrashed = null, string key = null, AssetOrder order = null, Guid personId = null, string slug = null, Guid tagId = null, Guid userId = null, AssetVisibility visibility = null, bool withCoordinates = null, bool withPartners = null, bool withStacked = null)



This endpoint requires the `asset.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **albumId** | **Guid** | Filter assets belonging to a specific album | [optional]  |
| **isFavorite** | **bool** | Filter by favorite status (true for favorites only, false for non-favorites only) | [optional]  |
| **isTrashed** | **bool** | Filter by trash status (true for trashed assets only, false for non-trashed only) | [optional]  |
| **key** | **string** |  | [optional]  |
| **order** | **AssetOrder** | Sort order for assets within time buckets (ASC for oldest first, DESC for newest first) | [optional]  |
| **personId** | **Guid** | Filter assets containing a specific person (face recognition) | [optional]  |
| **slug** | **string** |  | [optional]  |
| **tagId** | **Guid** | Filter assets with a specific tag | [optional]  |
| **userId** | **Guid** | Filter assets by specific user ID | [optional]  |
| **visibility** | **AssetVisibility** | Filter by asset visibility status (ARCHIVE, TIMELINE, HIDDEN, LOCKED) | [optional]  |
| **withCoordinates** | **bool** | Include location data in the response | [optional]  |
| **withPartners** | **bool** | Include assets shared by partners | [optional]  |
| **withStacked** | **bool** | Include stacked assets in the response. When true, only primary assets from stacks are returned. | [optional]  |

### Return type

[**List&lt;TimeBucketsResponseDto&gt;**](TimeBucketsResponseDto.md)

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

