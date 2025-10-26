# Org.OpenAPITools.Api.AssetsApi

All URIs are relative to */api*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**CheckBulkUpload**](AssetsApi.md#checkbulkupload) | **POST** /assets/bulk-upload-check | checkBulkUpload |
| [**CheckExistingAssets**](AssetsApi.md#checkexistingassets) | **POST** /assets/exist | checkExistingAssets |
| [**DeleteAssetMetadata**](AssetsApi.md#deleteassetmetadata) | **DELETE** /assets/{id}/metadata/{key} |  |
| [**DeleteAssets**](AssetsApi.md#deleteassets) | **DELETE** /assets |  |
| [**DownloadAsset**](AssetsApi.md#downloadasset) | **GET** /assets/{id}/original |  |
| [**GetAllUserAssetsByDeviceId**](AssetsApi.md#getalluserassetsbydeviceid) | **GET** /assets/device/{deviceId} | getAllUserAssetsByDeviceId |
| [**GetAssetInfo**](AssetsApi.md#getassetinfo) | **GET** /assets/{id} |  |
| [**GetAssetMetadata**](AssetsApi.md#getassetmetadata) | **GET** /assets/{id}/metadata |  |
| [**GetAssetMetadataByKey**](AssetsApi.md#getassetmetadatabykey) | **GET** /assets/{id}/metadata/{key} |  |
| [**GetAssetStatistics**](AssetsApi.md#getassetstatistics) | **GET** /assets/statistics |  |
| [**GetRandom**](AssetsApi.md#getrandom) | **GET** /assets/random |  |
| [**PlayAssetVideo**](AssetsApi.md#playassetvideo) | **GET** /assets/{id}/video/playback |  |
| [**ReplaceAsset**](AssetsApi.md#replaceasset) | **PUT** /assets/{id}/original | Replace the asset with new file, without changing its id |
| [**RunAssetJobs**](AssetsApi.md#runassetjobs) | **POST** /assets/jobs |  |
| [**UpdateAsset**](AssetsApi.md#updateasset) | **PUT** /assets/{id} |  |
| [**UpdateAssetMetadata**](AssetsApi.md#updateassetmetadata) | **PUT** /assets/{id}/metadata |  |
| [**UpdateAssets**](AssetsApi.md#updateassets) | **PUT** /assets |  |
| [**UploadAsset**](AssetsApi.md#uploadasset) | **POST** /assets |  |
| [**ViewAsset**](AssetsApi.md#viewasset) | **GET** /assets/{id}/thumbnail |  |

<a id="checkbulkupload"></a>
# **CheckBulkUpload**
> AssetBulkUploadCheckResponseDto CheckBulkUpload (AssetBulkUploadCheckDto assetBulkUploadCheckDto)

checkBulkUpload

Checks if assets exist by checksums. This endpoint requires the `asset.upload` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **assetBulkUploadCheckDto** | [**AssetBulkUploadCheckDto**](AssetBulkUploadCheckDto.md) |  |  |

### Return type

[**AssetBulkUploadCheckResponseDto**](AssetBulkUploadCheckResponseDto.md)

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

<a id="checkexistingassets"></a>
# **CheckExistingAssets**
> CheckExistingAssetsResponseDto CheckExistingAssets (CheckExistingAssetsDto checkExistingAssetsDto)

checkExistingAssets

Checks if multiple assets exist on the server and returns all existing - used by background backup


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **checkExistingAssetsDto** | [**CheckExistingAssetsDto**](CheckExistingAssetsDto.md) |  |  |

### Return type

[**CheckExistingAssetsResponseDto**](CheckExistingAssetsResponseDto.md)

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

<a id="deleteassetmetadata"></a>
# **DeleteAssetMetadata**
> void DeleteAssetMetadata (Guid id, AssetMetadataKey key)



This endpoint requires the `asset.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **key** | **AssetMetadataKey** |  |  |

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

<a id="deleteassets"></a>
# **DeleteAssets**
> void DeleteAssets (AssetBulkDeleteDto assetBulkDeleteDto)



This endpoint requires the `asset.delete` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **assetBulkDeleteDto** | [**AssetBulkDeleteDto**](AssetBulkDeleteDto.md) |  |  |

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

<a id="downloadasset"></a>
# **DownloadAsset**
> System.IO.Stream DownloadAsset (Guid id, string key = null, string slug = null)



This endpoint requires the `asset.download` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **key** | **string** |  | [optional]  |
| **slug** | **string** |  | [optional]  |

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

<a id="getalluserassetsbydeviceid"></a>
# **GetAllUserAssetsByDeviceId**
> List&lt;string&gt; GetAllUserAssetsByDeviceId (string deviceId)

getAllUserAssetsByDeviceId

Get all asset of a device that are in the database, ID only.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **deviceId** | **string** |  |  |

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

<a id="getassetinfo"></a>
# **GetAssetInfo**
> AssetResponseDto GetAssetInfo (Guid id, string key = null, string slug = null)



This endpoint requires the `asset.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **key** | **string** |  | [optional]  |
| **slug** | **string** |  | [optional]  |

### Return type

[**AssetResponseDto**](AssetResponseDto.md)

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

<a id="getassetmetadata"></a>
# **GetAssetMetadata**
> List&lt;AssetMetadataResponseDto&gt; GetAssetMetadata (Guid id)



This endpoint requires the `asset.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |

### Return type

[**List&lt;AssetMetadataResponseDto&gt;**](AssetMetadataResponseDto.md)

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

<a id="getassetmetadatabykey"></a>
# **GetAssetMetadataByKey**
> AssetMetadataResponseDto GetAssetMetadataByKey (Guid id, AssetMetadataKey key)



This endpoint requires the `asset.read` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **key** | **AssetMetadataKey** |  |  |

### Return type

[**AssetMetadataResponseDto**](AssetMetadataResponseDto.md)

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

<a id="getassetstatistics"></a>
# **GetAssetStatistics**
> AssetStatsResponseDto GetAssetStatistics (bool isFavorite = null, bool isTrashed = null, AssetVisibility visibility = null)



This endpoint requires the `asset.statistics` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
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

<a id="playassetvideo"></a>
# **PlayAssetVideo**
> System.IO.Stream PlayAssetVideo (Guid id, string key = null, string slug = null)



This endpoint requires the `asset.view` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **key** | **string** |  | [optional]  |
| **slug** | **string** |  | [optional]  |

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

<a id="runassetjobs"></a>
# **RunAssetJobs**
> void RunAssetJobs (AssetJobsDto assetJobsDto)




### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **assetJobsDto** | [**AssetJobsDto**](AssetJobsDto.md) |  |  |

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

<a id="updateasset"></a>
# **UpdateAsset**
> AssetResponseDto UpdateAsset (Guid id, UpdateAssetDto updateAssetDto)



This endpoint requires the `asset.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **updateAssetDto** | [**UpdateAssetDto**](UpdateAssetDto.md) |  |  |

### Return type

[**AssetResponseDto**](AssetResponseDto.md)

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

<a id="updateassetmetadata"></a>
# **UpdateAssetMetadata**
> List&lt;AssetMetadataResponseDto&gt; UpdateAssetMetadata (Guid id, AssetMetadataUpsertDto assetMetadataUpsertDto)



This endpoint requires the `asset.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **assetMetadataUpsertDto** | [**AssetMetadataUpsertDto**](AssetMetadataUpsertDto.md) |  |  |

### Return type

[**List&lt;AssetMetadataResponseDto&gt;**](AssetMetadataResponseDto.md)

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

<a id="updateassets"></a>
# **UpdateAssets**
> void UpdateAssets (AssetBulkUpdateDto assetBulkUpdateDto)



This endpoint requires the `asset.update` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **assetBulkUpdateDto** | [**AssetBulkUpdateDto**](AssetBulkUpdateDto.md) |  |  |

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

<a id="uploadasset"></a>
# **UploadAsset**
> AssetMediaResponseDto UploadAsset (System.IO.Stream assetData, string deviceAssetId, string deviceId, DateTime fileCreatedAt, DateTime fileModifiedAt, List<AssetMetadataUpsertItemDto> metadata, string key = null, string slug = null, string xImmichChecksum = null, string duration = null, string filename = null, bool isFavorite = null, Guid livePhotoVideoId = null, System.IO.Stream sidecarData = null, AssetVisibility visibility = null)



This endpoint requires the `asset.upload` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **assetData** | **System.IO.Stream****System.IO.Stream** |  |  |
| **deviceAssetId** | **string** |  |  |
| **deviceId** | **string** |  |  |
| **fileCreatedAt** | **DateTime** |  |  |
| **fileModifiedAt** | **DateTime** |  |  |
| **metadata** | [**List&lt;AssetMetadataUpsertItemDto&gt;**](AssetMetadataUpsertItemDto.md) |  |  |
| **key** | **string** |  | [optional]  |
| **slug** | **string** |  | [optional]  |
| **xImmichChecksum** | **string** | sha1 checksum that can be used for duplicate detection before the file is uploaded | [optional]  |
| **duration** | **string** |  | [optional]  |
| **filename** | **string** |  | [optional]  |
| **isFavorite** | **bool** |  | [optional]  |
| **livePhotoVideoId** | **Guid** |  | [optional]  |
| **sidecarData** | **System.IO.Stream****System.IO.Stream** |  | [optional]  |
| **visibility** | **AssetVisibility** |  | [optional]  |

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
| **201** |  |  -  |

[[Back to top]](#) [[Back to API list]](../../README.md#documentation-for-api-endpoints) [[Back to Model list]](../../README.md#documentation-for-models) [[Back to README]](../../README.md)

<a id="viewasset"></a>
# **ViewAsset**
> System.IO.Stream ViewAsset (Guid id, string key = null, AssetMediaSize size = null, string slug = null)



This endpoint requires the `asset.view` permission.


### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **id** | **Guid** |  |  |
| **key** | **string** |  | [optional]  |
| **size** | **AssetMediaSize** |  | [optional]  |
| **slug** | **string** |  | [optional]  |

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

