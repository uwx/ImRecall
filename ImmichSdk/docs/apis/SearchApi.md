# Org.OpenAPITools.Api.SearchApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetAssetsByCity**](SearchApi.md#getassetsbycity) | **GET** /search/cities |  |
| [**GetExploreData**](SearchApi.md#getexploredata) | **GET** /search/explore |  |
| [**GetSearchSuggestions**](SearchApi.md#getsearchsuggestions) | **GET** /search/suggestions |  |
| [**SearchAssetStatistics**](SearchApi.md#searchassetstatistics) | **POST** /search/statistics |  |
| [**SearchAssets**](SearchApi.md#searchassets) | **POST** /search/metadata |  |
| [**SearchLargeAssets**](SearchApi.md#searchlargeassets) | **POST** /search/large-assets |  |
| [**SearchPerson**](SearchApi.md#searchperson) | **GET** /search/person |  |
| [**SearchPlaces**](SearchApi.md#searchplaces) | **GET** /search/places |  |
| [**SearchRandom**](SearchApi.md#searchrandom) | **POST** /search/random |  |
| [**SearchSmart**](SearchApi.md#searchsmart) | **POST** /search/smart |  |

<a id="getassetsbycity"></a>
# **GetAssetsByCity**
> List&lt;AssetResponseDto&gt; GetAssetsByCity ()



This endpoint requires the `asset.read` permission.


### Parameters
This endpoint does not need any parameter.
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

<a id="getexploredata"></a>
# **GetExploreData**
> List&lt;SearchExploreResponseDto&gt; GetExploreData ()



This endpoint requires the `asset.read` permission.


### Parameters
This endpoint does not need any parameter.
### Return type

[**List&lt;SearchExploreResponseDto&gt;**](SearchExploreResponseDto.md)

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

<a id="getsearchsuggestions"></a>
# **GetSearchSuggestions**
> List&lt;string&gt; GetSearchSuggestions (SearchSuggestionType type, string country = null, bool includeNull = null, string lensModel = null, string make = null, string model = null, string state = null)



This endpoint requires the `asset.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **type** | **SearchSuggestionType** |  |  |
| **country** | **string** |  | [optional]  |
| **includeNull** | **bool** | This property was added in v111.0.0 | [optional]  |
| **lensModel** | **string** |  | [optional]  |
| **make** | **string** |  | [optional]  |
| **model** | **string** |  | [optional]  |
| **state** | **string** |  | [optional]  |

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

<a id="searchassetstatistics"></a>
# **SearchAssetStatistics**
> SearchStatisticsResponseDto SearchAssetStatistics (StatisticsSearchDto statisticsSearchDto)



This endpoint requires the `asset.statistics` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **statisticsSearchDto** | [**StatisticsSearchDto**](StatisticsSearchDto.md) |  |  |

### Return type

[**SearchStatisticsResponseDto**](SearchStatisticsResponseDto.md)

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

<a id="searchassets"></a>
# **SearchAssets**
> SearchResponseDto SearchAssets (MetadataSearchDto metadataSearchDto)



This endpoint requires the `asset.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **metadataSearchDto** | [**MetadataSearchDto**](MetadataSearchDto.md) |  |  |

### Return type

[**SearchResponseDto**](SearchResponseDto.md)

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

<a id="searchlargeassets"></a>
# **SearchLargeAssets**
> List&lt;AssetResponseDto&gt; SearchLargeAssets (List<Guid> albumIds = null, string city = null, string country = null, DateTime createdAfter = null, DateTime createdBefore = null, string deviceId = null, bool isEncoded = null, bool isFavorite = null, bool isMotion = null, bool isNotInAlbum = null, bool isOffline = null, string lensModel = null, Guid libraryId = null, string make = null, int minFileSize = null, string model = null, List<Guid> personIds = null, decimal rating = null, decimal size = null, string state = null, List<Guid> tagIds = null, DateTime takenAfter = null, DateTime takenBefore = null, DateTime trashedAfter = null, DateTime trashedBefore = null, AssetTypeEnum type = null, DateTime updatedAfter = null, DateTime updatedBefore = null, AssetVisibility visibility = null, bool withDeleted = null, bool withExif = null)



This endpoint requires the `asset.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **albumIds** | [**List&lt;Guid&gt;**](Guid.md) |  | [optional]  |
| **city** | **string** |  | [optional]  |
| **country** | **string** |  | [optional]  |
| **createdAfter** | **DateTime** |  | [optional]  |
| **createdBefore** | **DateTime** |  | [optional]  |
| **deviceId** | **string** |  | [optional]  |
| **isEncoded** | **bool** |  | [optional]  |
| **isFavorite** | **bool** |  | [optional]  |
| **isMotion** | **bool** |  | [optional]  |
| **isNotInAlbum** | **bool** |  | [optional]  |
| **isOffline** | **bool** |  | [optional]  |
| **lensModel** | **string** |  | [optional]  |
| **libraryId** | **Guid** |  | [optional]  |
| **make** | **string** |  | [optional]  |
| **minFileSize** | **int** |  | [optional]  |
| **model** | **string** |  | [optional]  |
| **personIds** | [**List&lt;Guid&gt;**](Guid.md) |  | [optional]  |
| **rating** | **decimal** |  | [optional]  |
| **size** | **decimal** |  | [optional]  |
| **state** | **string** |  | [optional]  |
| **tagIds** | [**List&lt;Guid&gt;**](Guid.md) |  | [optional]  |
| **takenAfter** | **DateTime** |  | [optional]  |
| **takenBefore** | **DateTime** |  | [optional]  |
| **trashedAfter** | **DateTime** |  | [optional]  |
| **trashedBefore** | **DateTime** |  | [optional]  |
| **type** | **AssetTypeEnum** |  | [optional]  |
| **updatedAfter** | **DateTime** |  | [optional]  |
| **updatedBefore** | **DateTime** |  | [optional]  |
| **visibility** | **AssetVisibility** |  | [optional]  |
| **withDeleted** | **bool** |  | [optional]  |
| **withExif** | **bool** |  | [optional]  |

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

<a id="searchperson"></a>
# **SearchPerson**
> List&lt;PersonResponseDto&gt; SearchPerson (string name, bool withHidden = null)



This endpoint requires the `person.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **name** | **string** |  |  |
| **withHidden** | **bool** |  | [optional]  |

### Return type

[**List&lt;PersonResponseDto&gt;**](PersonResponseDto.md)

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

<a id="searchplaces"></a>
# **SearchPlaces**
> List&lt;PlacesResponseDto&gt; SearchPlaces (string name)



This endpoint requires the `asset.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **name** | **string** |  |  |

### Return type

[**List&lt;PlacesResponseDto&gt;**](PlacesResponseDto.md)

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

<a id="searchrandom"></a>
# **SearchRandom**
> List&lt;AssetResponseDto&gt; SearchRandom (RandomSearchDto randomSearchDto)



This endpoint requires the `asset.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **randomSearchDto** | [**RandomSearchDto**](RandomSearchDto.md) |  |  |

### Return type

[**List&lt;AssetResponseDto&gt;**](AssetResponseDto.md)

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

<a id="searchsmart"></a>
# **SearchSmart**
> SearchResponseDto SearchSmart (SmartSearchDto smartSearchDto)



This endpoint requires the `asset.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **smartSearchDto** | [**SmartSearchDto**](SmartSearchDto.md) |  |  |

### Return type

[**SearchResponseDto**](SearchResponseDto.md)

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

